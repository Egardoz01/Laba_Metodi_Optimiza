using Microsoft.SolverFoundation.Common;
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
    public partial class InsertBasicSolution : Form
    {
        private int var_num;
        public Rational[] solution;
        public InsertBasicSolution(int var_num)
        {
            InitializeComponent();
            this.var_num = var_num;
        }

        private void InsertBasicSolution_Load(object sender, EventArgs e)
        {
            string[] ar = new string[var_num];
            for (int i = 0; i < var_num; i++)
                dataGridView1.Columns.Add("","");
            for (int i = 1; i <=var_num; i++)
                ar[i-1] = "X" + i;
            dataGridView1.Rows.Add(ar);
            dataGridView1.Rows.Add();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            solution = new Rational[var_num];
            for (int i = 0; i < var_num; i++)
            {
                string s = dataGridView1.Rows[1].Cells[i].Value as string;
                try
                {
                  
                    solution[i] = s.ParseRational();
                }
                catch(Exception ex) {
                    MessageBox.Show("Неверный вормат ввода " + s);
                    return;
                }
            }
            Close();
        }
    }
}
