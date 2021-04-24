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
        public SimplexMethodForm(SimplexMethod sm)
        {
            InitializeComponent();
            nSteps = 0;
            curStep = 0;
            steps = new List<SimplexMethod>();
            steps.Add(sm);
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

            DrawOporniyElements();
        }

        private void DrawOporniyElements()
        {
            List<Point> elements = steps[curStep].GetAvailableOporniyElements();

            foreach (Point el in elements)
            {
                SimplexTable.Rows[el.X + 1].Cells[el.Y + 1].Style.BackColor = Color.Green;
            }
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

                steps.Add(new SimplexMethod(steps[nSteps]));
                nSteps++;
                curStep++;
                steps[nSteps].MakeStep(p);
                DrawCurStep();
                CheckButtonsState();
            }
        }

        private void CheckButtonsState()
        {
            btnNextStep.Enabled = (curStep != nSteps);

            btnPrevStep.Enabled = curStep != 0;
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
    }
}
