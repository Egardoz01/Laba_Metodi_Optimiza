﻿using System;
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
            SetText();
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
                dlg.Filter = "CSV (*.csv)|*.csv";
                dlg.FileName = "Input.csv";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    int columnCount = dataGridView1.Columns.Count;
                    string[] outputCsv = new string[dataGridView1.Rows.Count + 1];

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            outputCsv[i] += dataGridView1.Rows[i].Cells[j].Value.ToString() + (j != columnCount-1 ?  "," : "");
                        }
                    }

                    File.WriteAllLines(dlg.FileName, outputCsv, Encoding.UTF8);


                }


            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "CSV (*.csv)|*.csv";
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    var data = File.ReadAllLines(dlg.FileName).Select(x => x.Split(',')).ToArray();

                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    for (int i = 0; i < data[0].Length; i++)
                        dataGridView1.Columns.Add("", "");

                    for (int i = 0; i < data.Length - 1; i++)
                    {
                        string[] strs = data[i];
                        dataGridView1.Rows.Add(strs);
                    }

                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Rows[0].ReadOnly = true;
                    dataGridView1.Rows[2].ReadOnly = true;

                    change_value = false;
                    VariablesAmount.Value = dataGridView1.ColumnCount - 2;
                    RestrAmount.Value = dataGridView1.RowCount - 3;
                    change_value = true;
                    LoadBasicSolutionGrid((int)VariablesAmount.Value);
                    setStyle();
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

            Rational[,] restrs = new Rational[restrs_amount, vars_amount+1];

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
            if (!sm.ValidateInput())
                return;
            bool autoSteps = cbAutoSteps.Checked;

            try
            {
                if (rbGraphicMethod.Checked)
                {
                    if (sm.nVars-sm.nRestrs > 2)
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
                        sm.SetBasicSolution(GetBasicSolution());
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
                            SimplexMethod smTask = form.GetLastTable().GeterateRestrsAfterBasis(paseFunction());
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
            Rational[]  solution = new Rational[var_num];
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
            SetText();
        }


        private void SetText()
        {
            if (rbGraphicMethod.Checked)
                lblExample.Text = "A11*X1 + A12*X2 + ... + A1n*Xn <= b1\n\rA21*X1 + A22*X2 + ... + A2n*Xn <= b2\n\rAm1*X1 + Am2*X2 + ... + Amn*Xn <= bm\n\r";
            else
                lblExample.Text = "A11*X1 + A12*X2 + ... + A1n*Xn = b1\n\rA21*X1 + A22*X2 + ... + A2n*Xn = b2\n\rAm1*X1 + Am2*X2 + ... + Amn*Xn = bm\n\r";

        }

        private void cbAutoSteps_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
        
}
