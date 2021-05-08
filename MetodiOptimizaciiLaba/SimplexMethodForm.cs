using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodiOptimizaciiLaba
{
    public partial class SimplexMethodForm : Form
    {
        private List<SimplexMethod> steps;
        private int nSteps;
        private int curStep;
        private bool basisMethod;
        private bool autoSteps;
        public SimplexMethodForm(SimplexMethod sm, bool autoSteps, bool basisMethod = false)
        {
            InitializeComponent();
            nSteps = 0;
            curStep = 0;
            steps = new List<SimplexMethod>();
            steps.Add(sm);
            this.basisMethod = basisMethod;
            if (basisMethod)
                btnFinish.Text = "Продолжить решение с данным базисным решением";

            this.autoSteps = autoSteps;

            if (autoSteps)
                doAuto();
        }

        private void doAuto()
        {
            while (steps[curStep].GetAvailableOporniyElements().Count != 0)
                makeStep(steps[curStep].GetAvailableOporniyElements()[0]);

        }

        private void SimplexMethodForm_Load(object sender, EventArgs e)
        {
            DrawCurStep();
            CheckButtonsState();
        }

        private void DrawCurStep()
        {
            SimplexTable.Columns.Clear();
            SimplexTable.Rows.Clear();

            lblCurStep.Text = $"Текущий шаг {curStep} из {nSteps}";

            SimplexMethod sm = steps[curStep];

            for (int i = 0; i < sm.freeVariables.Count + 2; i++)
                SimplexTable.Columns.Add("", "");
            List<string> r1 = new List<string>();
            r1.Add($"X({sm.NStep})");
            for (int i = 0; i < sm.freeVariables.Count; i++)
                r1.Add("X" + sm.freeVariables[i]);
            r1.Add("");

            SimplexTable.Rows.Add(r1.ToArray());
            for (int i = 0; i <= sm.basisVariables.Count; i++)
            {
                List<string> r = new List<string>();
                if (i != sm.basisVariables.Count)
                    r.Add("X" + sm.basisVariables[i]);
                else
                    r.Add("");
                for (int j = 0; j < sm.freeVariables.Count + 1; j++)
                    r.Add(sm.table[i, j].ToString());

                SimplexTable.Rows.Add(r.ToArray());
            }

            SimplexTable.ClearSelection();
            DrawOporniyElements();
            setStyle();
            WriteSolution();
        }

        private void DrawOporniyElements()
        {
            List<Point> elements = steps[curStep].GetAvailableOporniyElements();

            foreach (Point el in elements)
            {
                SimplexTable.Rows[el.X + 1].Cells[el.Y + 1].Style.BackColor = Color.Green;
            }
            if (steps[curStep].OporniyElement != new Point(-1, -1))
                SimplexTable.Rows[steps[curStep].OporniyElement.X + 1].Cells[steps[curStep].OporniyElement.Y + 1].Style.BackColor = Color.Aqua;
        }

        private void SimplexTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (nSteps == curStep)
            {
                Point p = new Point(e.RowIndex - 1, e.ColumnIndex - 1);
                List<Point> elements = steps[nSteps].GetAvailableOporniyElements();
                if (!elements.Contains(p))
                {
                    MessageBox.Show("Опорный элемент выбран неправильно");
                    return;
                }
                makeStep(p);
            }
        }

        private void makeStep(Point p)
        {
            steps.Add(new SimplexMethod(steps[nSteps]));
            steps[nSteps].OporniyElement = p;
            nSteps++;
            curStep++;
            steps[nSteps].MakeStep(p);
            DrawCurStep();
            CheckButtonsState();
        }

        private void CheckButtonsState()
        {
            btnNextStep.Enabled = (curStep != nSteps);

            btnPrevStep.Enabled = curStep != 0;

            if (isFinal())
                btnFinish.Enabled = true;

            btnMakeStepCurrent.Enabled = curStep != nSteps;

        }

        private void WriteSolution()
        {
            if (basisMethod || !steps[nSteps].isInfinity())
            {
                lblF.Text = "F*(X)=" + steps[nSteps].GetFmin().ToString();
                lblX.Text = "X*=(";
                var v = steps[nSteps].GetSolution();
                for (int i = 0; i < v.Length; i++)
                {

                    lblX.Text += v[i];
                    if (i != v.Length - 1)
                        lblX.Text += ",";
                    else
                        lblX.Text += ")";

                }
            }
            else
            {
                if (steps[nSteps].isMax)
                {
                    lblF.Text = "F*(X)=∞";

                    lblX.Text = "Функция не ограничена свурху";
                }
                else
                {
                    lblF.Text = "F*(X)=-∞";

                    lblX.Text = "Функция не ограничена снизу";

                }
            }
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            curStep++;
            DrawCurStep();
            CheckButtonsState();
        }

        private void btnPrevStep_Click(object sender, EventArgs e)
        {

            curStep--;
            DrawCurStep();
            CheckButtonsState();
        }


        private void setStyle()
        {
            for (int i = 0; i < SimplexTable.ColumnCount; i++)
                SimplexTable.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < SimplexTable.RowCount; i++)
                SimplexTable.Rows[i].Cells[0].Style.BackColor = Color.LightGray;

            for (int i = 0; i < SimplexTable.ColumnCount; i++)
                SimplexTable.Rows[0].Cells[i].Style.BackColor = Color.LightGray;

        }

        public SimplexMethod GetLastTable()
        {
            return steps[nSteps];
        }
        public bool isFinal()
        {
            if (!basisMethod)
            {
                if (isInfinity())
                    return true;
            }
            return steps[nSteps].GetAvailableOporniyElements().Count == 0;
        }

        public bool isInfinity()
        {
            return steps[nSteps].isInfinity();
        }

        private void btnMakeStepCurrent_Click(object sender, EventArgs e)
        {
            while (nSteps != curStep)
            {
                steps.RemoveAt(nSteps);
                nSteps--;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
