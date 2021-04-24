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
        private readonly SimplexMethod sm;
        public SimplexMethodForm(SimplexMethod sm)
        {
            InitializeComponent();
            this.sm = sm;
        }

        private void SimplexMethodForm_Load(object sender, EventArgs e)
        {
            DrawTable();
        }

        private void DrawTable()
        {
            SimplexTable.Columns.Clear();
            SimplexTable.Rows.Clear();

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
            List<Point> elements = sm.GetAvailableOporniyElements();

            foreach (Point el in elements)
            {
                SimplexTable.Rows[el.X + 1].Cells[el.Y + 1].Style.BackColor = Color.Green;
            }
        }

        private void SimplexTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Point p = new Point(e.RowIndex - 1, e.ColumnIndex - 1);
            List<Point> elements = sm.GetAvailableOporniyElements();
            if (!elements.Contains(p))
            {
                MessageBox.Show("Опорный элемент выбран неправильно");
                return;
            }

            sm.MakeStep(p);
            DrawTable();
        }
    }
}
