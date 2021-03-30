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

namespace MetodiOptimizaciiLaba
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InputFormInit();
        }

        private void InputFormInit()
        {
            dataGridView1.Columns.Add("","");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Rows.Add("", "C");
            dataGridView1.Rows[0].ReadOnly = true;
            dataGridView1.Rows.Add("f(x)", "0");
            dataGridView1.Rows.Add("","b");
            dataGridView1.Rows[2].ReadOnly = true;
        }

        private void VariablesAmount_ValueChanged(object sender, EventArgs e)
        {
            int now = (int)VariablesAmount.Value;
            int before = dataGridView1.Columns.Count - 2;
            if (now > before)
            {
                dataGridView1.Columns.Add("", "");

                for (int i = 1; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[now + 1].Value = dataGridView1.Rows[i].Cells[now].Value;
                    dataGridView1.Rows[i].Cells[now].Value = "0";

                }
                    dataGridView1.Rows[0].Cells[now].Value = "C" + now;
                dataGridView1.Rows[0].Cells[now+1].Value = "C";

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
        }

        private void RestrAmount_ValueChanged(object sender, EventArgs e)
        {
            int now = (int)RestrAmount.Value;
            int before = dataGridView1.Rows.Count - 3;

            if (now > before)
            {
                dataGridView1.Rows.Add("𝜑" + now);
                for (int i = 1; i < dataGridView1.Columns.Count; i++)
                    dataGridView1.Rows[now + 3 -1].Cells[i].Value = "0";
            }
            else
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
            }
        }

        private void btnSve_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "CSV (*.csv)|*.csv";
                dlg.FileName = "Input.csv";

                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    int columnCount = dataGridView1.Columns.Count-1;
                    string[] outputCsv = new string[dataGridView1.Rows.Count + 1];

                    for (int i = 0; (i - 1) < dataGridView1.Rows.Count-1; i++)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            outputCsv[i] += dataGridView1.Rows[i].Cells[j].Value.ToString() + ",";
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

                    var data = File.ReadAllLines(dlg.FileName).Select( x=> x.Split(',')).ToArray();

                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    for (int i = 0; i < data[0].Length-1; i++)
                        dataGridView1.Columns.Add("", "");
                    for (int i = 0; i < data.Length-1; i++)
                    {
                        string[] strs = data[i];
                        dataGridView1.Rows.Add(strs);
                    }

                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Rows[0].ReadOnly = true;
                    dataGridView1.Rows[2].ReadOnly = true;

                }

               

            }
        }
    }
}
