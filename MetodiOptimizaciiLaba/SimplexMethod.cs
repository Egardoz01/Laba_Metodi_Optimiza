using Microsoft.SolverFoundation.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodiOptimizaciiLaba
{
    public class SimplexMethod
    {
        public Rational[] f;
        public Rational[,] restrs;
        public Rational[,] table;
        public Rational[] solution;
        public int NStep;
        public int nVars;
        public int nRestrs;
        public List<int> basisVariables;
        public List<int> freeVariables;
        public Point OporniyElement = new Point(-1, -1);

        public SimplexMethod(SimplexMethod sm)
        {
            table = sm.table.Clone() as Rational[,];
            basisVariables = new List<int>(sm.basisVariables);
            freeVariables = new List<int>(sm.freeVariables);
            NStep = sm.NStep;
            f = sm.f.Clone() as Rational[];
            restrs = sm.restrs.Clone() as Rational[,];
            solution = sm.solution.Clone() as Rational[];
            nVars = sm.nVars;
            nRestrs = sm.nRestrs;
        }

        public Rational CountRes(Rational[] point)
        {
            Rational sum = f[f.Length - 1];
            for (int i = 0; i < point.Length; i++)
                sum += f[i] * point[i];

            return sum;
        }

        public SimplexMethod(Rational[] f, Rational[,] restrs)
        {
            this.f = f.Clone() as Rational[];
            this.restrs = restrs.Clone() as Rational[,];
            nVars = f.Length - 1;
            nRestrs = restrs.GetLength(0);
            NStep = 0;
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

        public void CountGauss()
        {
            Rational[,] matrix = restrs.Clone() as Rational[,];
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
            Rational[] fun = new Rational[3];


            table = new Rational[nRestrs, 3];

            int off = nRestrs;

            fun[0] = f[off];
            fun[1] = f[off + 1];
            fun[2] = f[off + 2];
            for (int i = 0; i < nRestrs; i++)
            {
                table[i, 0] = matrix[i, off];
                table[i, 1] = matrix[i, off + 1];
                table[i, 2] = matrix[i, off + 2];


                fun[0] -= f[i] * matrix[i, off];
                fun[1] -= f[i] * matrix[i, off + 1];
                fun[2] += f[i] * matrix[i, off + 2];

            }

            f = fun;

        }

        public void CountTable()
        {

            table = new Rational[basisVariables.Count + 1, freeVariables.Count + 1];
            Rational[,] matrix = restrs.Clone() as Rational[,];

            for (int c1 = 0; c1 < basisVariables.Count(); c1++)
            {

                int c2 = basisVariables[c1] - 1;
                for (int c = c2 - 1; c >= c1; c--)
                {
                    for (int i = 0; i < nRestrs; i++)
                    {
                        Rational tmp = matrix[i, c];
                        matrix[i, c] = matrix[i, c + 1];
                        matrix[i, c + 1] = tmp;
                    }
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
                    table[i, j] = matrix[i, j + nBasis];
                }
            }
            for (int i = 0; i < nBasis; i++)
            {
                table[i, nFree] = matrix[i, nFree + nBasis];
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

        }

        public List<Point> GetAvailableOporniyElements()
        {
            List<Point> elements = new List<Point>();

            int last = nRestrs;
            for (int i = 0; i < freeVariables.Count; i++)
            {
                if (table[last, i] < 0)
                {
                    int oporniy = -1;
                    Rational otn = 0;
                    for (int j = 0; j < last; j++)
                    {
                        if (table[j, i] > 0)
                        {
                            oporniy = j;
                            otn = table[j, freeVariables.Count] / table[j, i];
                            break;
                        }
                    }
                    if (oporniy == -1)
                        continue;
                    for (int j = oporniy + 1; j < last; j++)
                    {
                        if (table[j, i] > 0)
                        {
                            Rational otn2 = table[j, freeVariables.Count] / table[j, i];
                            if (otn2 < otn)
                            {
                                oporniy = j;
                                otn = otn2;
                            }
                        }
                    }
                    elements.Add(new Point(oporniy, i));
                }
            }
            return elements;
        }

        public void MakeStep(Point element)
        {

            Rational[,] nextTable = new Rational[table.GetLength(0), table.GetLength(1)];
            int row = element.X;
            int col = element.Y;

            nextTable[row, col] = 1 / table[row, col];

            for (int i = 0; i <= freeVariables.Count; i++)
                nextTable[row, i] = table[row, i] / table[row, col];

            for (int i = 0; i <= basisVariables.Count; i++)
            {
                if (i == row)
                    continue;
                for (int j = 0; j <= freeVariables.Count; j++)
                {
                    nextTable[i, j] = table[i, j] - table[i, col] * nextTable[row, j];
                }
            }


            for (int i = 0; i <= basisVariables.Count; i++)
                nextTable[i, col] = -table[i, col] / table[row, col];

            nextTable[row, col] = 1 / table[row, col];

            table = nextTable;
            int tmp = freeVariables[col];
            freeVariables[col] = basisVariables[row];
            basisVariables[row] = tmp;
            NStep++;
        }

        public SimplexMethod GenerateArtificialBasisTask()
        {
            int nVars = this.nVars + this.nRestrs;
            int nRestrs = this.nRestrs;
            Rational[] f = new Rational[nVars + 1];
            Rational[,] r = new Rational[nRestrs, nVars + 1];

            for (int i = 0; i < nVars; i++)
            {
                if (i >= this.nVars)
                    f[i] = 1;
            }
            for (int i = 0; i < this.nRestrs; i++)
                for (int j = 0; j < this.nVars; j++)
                    r[i, j] = restrs[i, j];

            for (int i = 0; i < nRestrs; i++)
                r[i, i + this.nVars] = 1;

            for (int i = 0; i < nRestrs; i++)
                r[i, nVars] = restrs[i, this.nVars];

            SimplexMethod sm = new SimplexMethod(f, r);
            Rational[] sol = new Rational[nVars];
            for (int i = 0; i < nRestrs; i++)
                sol[this.nVars + i] = r[i, nVars];

            sm.SetBasicSolution(sol);
            return sm;
        }

        public SimplexMethod GeterateRestrsAfterBasis(Rational[] f)
        {
            int nVars = this.nVars - this.nRestrs;
            int nRestrs = this.nRestrs;
            Rational[,] r = new Rational[nRestrs, nVars + 1];
            for (int j = 0; j < freeVariables.Count; j++)
            {
                if (freeVariables[j] <= nVars)
                {
                    for (int i = 0; i < nRestrs; i++)
                    {
                        r[i, freeVariables[j] - 1] = table[i, j];
                    }
                }
            }

            for (int i = 0; i < basisVariables.Count; i++)
                r[i, basisVariables[i] - 1] = 1;

            Rational[] sol = new Rational[nVars];
            for (int i = 0; i < nRestrs; i++)
            {
                sol[basisVariables[i] - 1] = table[i, nVars];
                r[i, nVars] = table[i, nVars];
            }

            SimplexMethod sm = new SimplexMethod(f, r);
            sm.SetBasicSolution(sol);

            return sm;
        }

        public Rational GetFmin()
        {
            return -table[basisVariables.Count, freeVariables.Count];
        }

        public Rational[] GetSolution()
        {
            Rational[] v = new Rational[nVars];

            for (int i = 0; i < freeVariables.Count; i++)
                v[freeVariables[i] - 1] = 0;

            for (int i = 0; i < basisVariables.Count; i++)
                v[basisVariables[i] - 1] = table[i, freeVariables.Count];

            return v;
        }

        public void changeFunctionnSign()
        {
            for (int i = 0; i < f.Length; i++)
                f[i] = -f[i];
        }
    }
}
