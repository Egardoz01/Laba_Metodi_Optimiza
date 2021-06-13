using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SolverFoundation.Common;

namespace MetodiOptimizaciiLaba
{



    public partial class InputDialog : Form
    {
        public InputDialog()
        {
            InitializeComponent();
            InputFormInit();

        }
        private bool change_value = true;

        private void InputFormInit()
        {
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Rows.Add("", "C");
            dataGridView1.Rows[0].ReadOnly = true;
            dataGridView1.Rows.Add("f(x)", "0");
            dataGridView1.Rows.Add("", "b");
            dataGridView1.Rows[2].ReadOnly = true;
            setStyle();
        }

        private void VariablesAmount_ValueChanged(object sender, EventArgs e)
        {
            if (!change_value)
                return;
            int now = (int)VariablesAmount.Value;
            int before = dataGridView1.Columns.Count - 2;
            if (!ValidateVariablesAmount())
            {
                VariablesAmount.Value = before;
                return;
            }
            LoadBasicSolutionGrid(now);
            if (now > before)
            {
                dataGridView1.Columns.Add("", "");


                for (int i = 1; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[now + 1].Value = dataGridView1.Rows[i].Cells[now].Value;
                    dataGridView1.Rows[i].Cells[now].Value = "0";

                }
                dataGridView1.Rows[0].Cells[now].Value = "C" + now;
                dataGridView1.Rows[0].Cells[now + 1].Value = "C";

                dataGridView1.Rows[2].Cells[now].Value = "a" + now;
                dataGridView1.Rows[2].Cells[now + 1].Value = "b";


            }
            if (now < before)
            {
                dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 1);
                if (now != 0)
                    dataGridView1.Rows[0].Cells[now].Value = "C" + now;
                dataGridView1.Rows[0].Cells[now + 1].Value = "C";
                if (now != 0)
                    dataGridView1.Rows[2].Cells[now].Value = "a" + now;
                dataGridView1.Rows[2].Cells[now + 1].Value = "b";
            }

            setStyle();

        }


        private void setStyle()
        {
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < dataGridView2.ColumnCount; i++)
                dataGridView2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.LightGray;

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.LightGray;

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Rows[2].Cells[i].Style.BackColor = Color.LightGray;

            for (int i = 0; i < dataGridView2.ColumnCount; i++)
                dataGridView2.Rows[0].Cells[i].Style.BackColor = Color.LightGray;

            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
        }

        private void RestrAmount_ValueChanged(object sender, EventArgs e)
        {
            if (!change_value)
                return;
            int now = (int)RestrAmount.Value;
            int before = dataGridView1.Rows.Count - 3;
            if (!ValidateVariablesAmount())
            {
                RestrAmount.Value = before;
                return;
            }
            if (now > before)
            {
                dataGridView1.Rows.Add("𝜑" + now);
                for (int i = 1; i < dataGridView1.Columns.Count; i++)
                    dataGridView1.Rows[now + 3 - 1].Cells[i].Value = "0";
            }
            if (now < before)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
            }

            setStyle();
        }

        private bool ValidateVariablesAmount()
        {
            int variables = (int)VariablesAmount.Value;
            int restr = (int)RestrAmount.Value;
            if (!rbGraphicMethod.Checked && restr > variables)
            {
                MessageBox.Show("Количество ограничений не может быть больше количества переменных");
                return false;
            }
            return true;
        }

        private void btnSve_Click(object sender, EventArgs e)
        {
            if (!parseInput().ValidateInput())
                return;

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "TXT (*.txt)|*.txt";
                dlg.FileName = "Input.txt";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    List<string> output = new List<string>();
                    output.Add(VariablesAmount.Value + " " + RestrAmount.Value);
                    for (int row = 1; row < dataGridView1.RowCount; row++)
                    {
                        if (row == 2)
                            continue;
                        string cur = "";
                        for (int i = 1; i < dataGridView1.ColumnCount; i++)
                        {

                            cur += " " + dataGridView1.Rows[row].Cells[i].Value;
                        }

                        output.Add(cur);
                    }

                    File.WriteAllLines(dlg.FileName, output, Encoding.UTF8);


                }


            }
        }

        private void clearAll()
        {
            int vars = (int)VariablesAmount.Value;
            int restrs = (int)RestrAmount.Value;

            for (int i = restrs - 1; i >=0; i--)
                RestrAmount.Value = i;

            for (int i = vars - 1; i >=0; i--)
                VariablesAmount.Value = i;

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            clearAll();
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "TXT (*.txt)|*.txt";
           
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    var data = File.ReadAllLines(dlg.FileName).Select(x => x.Split(' ')).ToArray();
                    
                    var a = data[0].Select( x => x=="" || x==" "? 0 : int.Parse(x)).ToArray();
                    int vars = a[0];
                    int rests = a[1];

                    for (int i = 1; i <= vars; i++)
                        VariablesAmount.Value = i;

                    for (int i = 1; i <= rests; i++)
                        RestrAmount.Value = i;

                    for (int i = 1; i <= vars + 1; i++)
                        dataGridView1.Rows[1].Cells[i].Value = data[1][i];

                    for (int j = 2; j < rests + 2; j++)
                    {
                        for (int i = 1; i <= vars + 1; i++)
                            dataGridView1.Rows[j + 1].Cells[i].Value = data[j][i];
                    }

                    LoadBasicSolutionGrid((int)VariablesAmount.Value);
                    setStyle();

                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Rows[0].ReadOnly = true;
                    dataGridView1.Rows[2].ReadOnly = true;
                }



            }
        }

        private Rational[] paseFunction()
        {
            int vars_amount = dataGridView1.ColumnCount - 2;
            Rational[] f = new Rational[vars_amount + 1];
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                string s = (string)dataGridView1.Rows[1].Cells[i].Value;
                try
                {
                    f[i - 1] = s.ParseRational();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Неверный формат ввода ", s);
                    return null;
                }

            }
            return f;
        }

        private SimplexMethod parseInput()
        {

            int vars_amount = dataGridView1.ColumnCount - 2;
            int restrs_amount = dataGridView1.RowCount - 3;
            Rational[] f = paseFunction();

            Rational[,] restrs = new Rational[restrs_amount, vars_amount + 1];

            for (int i = 3; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                {
                    string s = (string)dataGridView1.Rows[i].Cells[j].Value;

                    try
                    {
                        restrs[i - 3, j - 1] = s.ParseRational();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверный формат ввода ", s);
                        return null;
                    }
                }
            }

            SimplexMethod sm = new SimplexMethod(f, restrs);

            return sm;
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            SimplexMethod sm = parseInput();

            if (rbGraphicMethod.Checked)
            {
                if (sm.nVars - sm.nRestrs > 2)
                {
                    MessageBox.Show("Данную задачу нельзя решить графически в 2д");
                    return;
                }
            }

            if (rbGraphicMethod.Checked)
            {
                if (sm.nVars - sm.nRestrs == 1)
                {
                    VariablesAmount.Value = VariablesAmount.Value + 1;
                    sm = parseInput();
                }

                if (sm.nVars - sm.nRestrs == 0)
                {
                    VariablesAmount.Value = VariablesAmount.Value + 1;
                    VariablesAmount.Value = VariablesAmount.Value + 1;
                    sm = parseInput();
                }
            }
            if (!sm.ValidateInput())
                return;
            bool autoSteps = cbAutoSteps.Checked;

            if (rbMax.Checked)
            {
                sm.isMax = true;
                sm.changeFunctionnSign();
            }
            try
            {
                if (rbGraphicMethod.Checked)
                {
                    if (sm.nVars - sm.nRestrs > 2)
                    {
                        MessageBox.Show("Данную задачу нельзя решить графически в 2д");
                        return;
                    }



                    sm.CountGauss();
                    GraphicMethodForm form = new GraphicMethodForm(sm);
                    this.Hide();
                    form.ShowDialog();
                    this.Show();
                }
                else
                {


                    if (rbSolutionMethod.Checked)
                    {
                        sm.SetBasicSolution(GetBasicSolution(),sm.nRestrs);
                        sm.CountTable();
                        SimplexMethodForm form = new SimplexMethodForm(sm, autoSteps);
                        this.Hide();
                        form.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        SimplexMethod basisTask = sm.GenerateArtificialBasisTask();

                        basisTask.CountTable();
                        SimplexMethodForm form = new SimplexMethodForm(basisTask, autoSteps, true);
                        this.Hide();
                        form.ShowDialog();
                        this.Show();

                        if (form.isFinal())
                        {

                            if (form.resultF() != 0)
                            {
                                MessageBox.Show("Ограничения системы не совместны, решений нет ");
                                return;
                            }
                            SimplexMethod smTask = form.GetLastTable().GeterateRestrsAfterBasis(paseFunction());
                            if (rbMax.Checked)
                            {
                                smTask.isMax = true;
                                smTask.changeFunctionnSign();
                            }
                            smTask.CountTable();
                            SimplexMethodForm form2 = new SimplexMethodForm(smTask, autoSteps);
                            this.Hide();
                            form2.ShowDialog();
                            this.Show();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void LoadBasicSolutionGrid(int var_num)
        {
           
            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();
            if (var_num == 0)
                return;
            string[] ar = new string[var_num];
            for (int i = 0; i < var_num; i++)
                dataGridView2.Columns.Add("", "");
            for (int i = 1; i <= var_num; i++)
                ar[i - 1] = "X" + i;
            dataGridView2.Rows.Add(ar);
            dataGridView2.Rows.Add();
        }

        private Rational[] GetBasicSolution()
        {
            int var_num = dataGridView2.Columns.Count;
            Rational[] solution = new Rational[var_num];
            for (int i = 0; i < var_num; i++)
            {
                string s = dataGridView2.Rows[1].Cells[i].Value as string;
                try
                {
                    solution[i] = s.ParseRational();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Неверный вормат ввода " + s);
                    return null;
                }
            }
            return solution;
        }

        private void BasicSolutionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView2.Visible = rbSolutionMethod.Checked;

            cbAutoSteps.Enabled = rbSolutionMethod.Checked || rbBasisMethod.Checked;
        }



        private void cbAutoSteps_CheckedChanged(object sender, EventArgs e)
        {

        }


    }

}
