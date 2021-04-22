using Microsoft.SolverFoundation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodiOptimizaciiLaba
{
    public class SimplexMethod
    {
        private Rational[] f;
        private Rational[,] restrs;
        private Rational[,] table;
        public Rational[] solution;

        public int nVars;
        public int nRestrs;
        public List<int> basisVariables;
        public List<int> freeVariables;
        public SimplexMethod(Rational[] f, Rational[,] restrs)
        {
            this.f = f.Clone() as Rational[];
            this.restrs = restrs.Clone() as Rational[,];
            nVars = f.Length - 1;
            nRestrs = restrs.GetLength(0);
        }

        public bool ValidateInput()
        {
            if (getRang(restrs) != restrs.GetLength(0))
            {
                MessageBox.Show("Ранг матрицы ограничений не совпадает с количеством ограничений");
                return false;
            }
            return true;
        }


        private int getRang(Rational[,] inputMatrix)
        {
            Rational[,] matrix = inputMatrix.Clone() as Rational[,];
            int num_rows = matrix.GetLength(0);
            int num_cols = matrix.GetLength(1);

            int rang = 0;
            for (int cur_row = 0, cur_col = 0; cur_row < num_rows && cur_col < num_cols;)
            {
                if (matrix[cur_row, cur_col].IsZero)
                {
                    for (int r2 = cur_row + 1; r2 < num_rows; r2++)
                    {
                        if (!matrix[r2, cur_col].IsZero)
                        {
                            for (int c = 0; c < num_cols; c++)
                            {
                                Rational tmp = matrix[cur_row, c];
                                matrix[cur_row, c] = matrix[r2, c];
                                matrix[r2, c] = tmp;
                            }
                            break;
                        }
                    }
                }

                if (!matrix[cur_row, cur_col].IsZero)
                {

                    for (int r2 = cur_row + 1; r2 < num_rows; r2++)
                    {
                        Rational factor = -matrix[r2, cur_col] / matrix[cur_row, cur_col];
                        for (int c = cur_row; c < num_cols; c++)
                        {
                            matrix[r2, c] = matrix[r2, c] + factor * matrix[cur_row, c];
                        }
                    }
                    cur_row++;
                    cur_col++;
                    rang++;
                }
                else
                {
                    cur_col++;
                }
            }

            return rang;
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;
        }

        public void SetBasicSolution(Rational[] solution)
        {
            if (solution.Length != nVars)
                throw new Exception("Решение не соответствует количеству переменных");
           
            basisVariables = new List<int>();
            freeVariables = new List<int>();
            for (int i = 0; i < nVars; i++)
                if (solution[i] != 0)
                    basisVariables.Add(i + 1);
                else
                    freeVariables.Add(i + 1);

            for (int i = 0; i < nRestrs; i++)
            {
                Rational sum = 0;
                for (int j = 0; j < nVars; j++)
                {
                    sum += solution[j] * restrs[i, j];
                }
                if (sum != restrs[i, nVars])
                    throw new Exception("Решение не соответствует ограничениям задачи");
            }

            this.solution = solution.Clone() as Rational[];
        }

        public void CountTable()
        {  
            table = new Rational[basisVariables.Count+1, freeVariables.Count+1];

            Rational[,] matrix = restrs.Clone() as Rational[,];

            for (int c1 = 0; c1 < basisVariables.Count(); c1++)
            {

                int c2 = basisVariables[c1] - 1;

                for (int i = 0; i < nRestrs; i++)
                {
                    Rational tmp = matrix[i,c1];
                    matrix[i, c1] = matrix[i, c2];
                    matrix[i, c2] = tmp;
                }
            }

            int num_rows = matrix.GetLength(0);
            int num_cols = matrix.GetLength(1);

            for (int cur_row = 0, cur_col = 0; cur_row < num_rows && cur_col < num_cols;)//пряиой ход
            {
                if (matrix[cur_row, cur_col].IsZero)
                {
                    for (int r2 = cur_row + 1; r2 < num_rows; r2++)
                    {
                        if (!matrix[r2, cur_col].IsZero)
                        {
                            for (int c = 0; c < num_cols; c++)
                            {
                                Rational tmp = matrix[cur_row, c];
                                matrix[cur_row, c] = matrix[r2, c];
                                matrix[r2, c] = tmp;
                            }
                            break;
                        }
                    }
                }



                if (!matrix[cur_row, cur_col].IsZero)
                {
                    Rational biba = matrix[cur_row, cur_col];
                    for (int c = 0; c < num_cols; c++)
                        matrix[cur_row, c] /= biba;

                    for (int r2 = cur_row + 1; r2 < num_rows; r2++)
                    {
                        Rational factor = -matrix[r2, cur_col];
                        for (int c = cur_row; c < num_cols; c++)
                        {
                            matrix[r2, c] = matrix[r2, c] + factor * matrix[cur_row, c];
                        }
                    }
                    cur_row++;
                    cur_col++;
                }
                else
                {
                    cur_col++;
                }
            }

            for (int cur_row = num_rows - 1; cur_row >= 0; cur_row--)//Обратный ход
            {

                for (int r2 = cur_row - 1; r2 >= 0; r2--)
                {
                    Rational factor = -matrix[r2, cur_row];
                    for (int c = cur_row; c < num_cols; c++)
                    {
                        matrix[r2, c] = matrix[r2, c] + factor * matrix[cur_row, c];
                    }
                }
            }

            int nFree = freeVariables.Count;
            int nBasis = basisVariables.Count;

            for (int i = 0; i < nBasis; i++)
            {
                for (int j = 0; j < nFree; j++)
                {
                    table[i,j] = matrix[i,j + nBasis];
                }
            }
            for (int i = 0; i < nBasis; i++)
            {
                table[i,nFree] = matrix[i, nFree + nBasis];
            }

            for (int i = 0; i < nFree; i++)
            {
                table[nBasis, i] = f[freeVariables[i] - 1];
                for (int j = 0; j < nBasis; j++)
                {
                    table[nBasis, i] -= f[basisVariables[j] - 1] * table[j, i];
                }
            }

            Rational sum = f[nVars];
            for (int i = 0; i < nVars; i++)
                sum += f[i] * solution[i];

            table[nBasis, nFree] = -sum;
            
            int a = 0;
        }
    }
}
