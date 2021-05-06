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
    public partial class GraphicMethodForm : Form
    {
        SimplexMethod sm;
        double scale = 10;// 10 пикселей это одна условная единица
        int interval = 5;
        Point start;
        List<Color> colors = new List<Color>() { Color.Red, Color.Green, Color.Blue, Color.Pink, Color.Violet, Color.Brown, Color.Orange};
        public GraphicMethodForm(SimplexMethod sm)
        {
            InitializeComponent();
            this.sm = sm;
            start = new Point(20, panel1.Height - 40);
            this.panel1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseWheel);
        }


        private void DrawAsis(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.Black);
            Font font = new Font("Serif", 8);
            Font font2 = new Font("Serif", 10, FontStyle.Bold);

            g.DrawLine(pen, start.X, 0, start.X, panel1.Height);
            g.DrawLine(pen, 0, start.Y, panel1.Width, start.Y);

            interval = panel1.Width / (int)(10*scale);
            if (interval <=0)
                interval = 1;
            int x = start.X + (int)Math.Round(scale * interval);
            int cur = interval;
            while (x < panel1.Width)
            {
                g.DrawLine(pen, x, start.Y - 5, x, start.Y + 5);
                g.DrawString(cur.ToString(), font, brush, x - 5, start.Y + 15);
                cur += interval;
                x += (int)Math.Round(scale * interval);
            }

            int y = start.Y - (int)Math.Round(scale * interval);
            cur = interval;
            while (y > 50)
            {
                g.DrawLine(pen, start.X - 5, y, start.X + 5, y);
                g.DrawString(cur.ToString(), font, brush, start.X - 20, y - 5);
                cur += interval;
                y -= (int)Math.Round(scale * interval);
            }

            g.DrawString("X1", font2, brush, panel1.Width - 20, start.Y + 10);

            g.DrawString("X2", font2, brush, start.X - 20, 0);
            g.DrawString("0", font2, brush, start.X - 20, start.Y + 10);
        }

      

        private void panel1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (scale + e.Delta / 36 > 0)
            {
                scale += e.Delta / 36;
                panel1.Refresh();
            }
        }

        private void DrawRestrs(Graphics g)
        {
       
            for (int i = 0; i < sm.nRestrs; i++)
            {
                Pen pen = new Pen(colors[i % colors.Count],2);
                Rational a1, c1, b1;
                a1 = sm.table[i, 0];
                b1 = sm.table[i, 1];
                c1 = sm.table[i, 2];
                if (a1.IsZero)
                {
                    Rational y = c1 / b1;
                    g.DrawLine(pen, 0, (int)Math.Round(y.ToDouble()), panel1.Width, (int)Math.Round(y.ToDouble()));
                }
                else if (b1.IsZero)
                {
                    Rational x = c1 / a1;
                    g.DrawLine(pen, (int)Math.Round(x.ToDouble()), 0, (int)Math.Round(x.ToDouble()), panel1.Height);
                }
                else
                {
                    Rational y = c1 / b1;
                    Rational x = c1 / a1;
                    Point p1, p2;
                    if (y >= 0)
                    {
                        p1 = toPixel(0, y);
                    }
                    else
                    {
                        Rational x1 = x * 100;
                        Rational y1 = -y * 100;

                        p1 = toPixel(x1, y1);
                    }

                    if (x >= 0)
                    {
                        p2 = toPixel(x, 0);
                    }
                    else
                    {
                        Rational x1 = -x*100;
                        Rational y1 = y*100;

                        p2 = toPixel(x1, y1);

                    }
                    g.DrawLine(pen, p1, p2);
                }
            }
        }

        private Point toPixel(Rational x, Rational y)
        {
            x *= scale;
            x += start.X;
            y *= scale;
            y = start.Y - y;
            return new Point((int)Math.Round(x.ToDouble()), (int)Math.Round(y.ToDouble()));
        }

        private KeyValuePair<Rational, Rational> countBest()
        {
            List<KeyValuePair<Rational, Rational>> v = new List<KeyValuePair<Rational, Rational>>();

            for (int i = 0; i < sm.nRestrs; i++)
                for (int j = i + 1; j < sm.nRestrs; j++)
                {
                    Rational a1, a2, b1, b2, c1, c2;

                    a1 = sm.table[i, 0];
                    a2 = sm.table[j, 0];
                    b1 = sm.table[i, 1];
                    b2 = sm.table[j, 1];
                    c1 = sm.table[i, 2];
                    c2 = sm.table[j, 2];

                    try
                    {
                        if (a1.IsZero)
                        {
                            Rational y = c1 / b1;
                            Rational x = (c2 - b2 * y) / a2;

                        }
                        else
                        {
                            Rational y = (c2 - c1 * a2 / a1) / (b2 - b1 * a2 / a1);
                            Rational x = (c1 - b1 * y) / a1;
                            v.Add(new KeyValuePair<Rational, Rational>(x, y));
                        }
                    }
                    catch (Exception ex)
                    {
                        //прямые параллельны
                    }
                }

            for (int i = 0; i < sm.nRestrs; i++)
            {
                Rational a1, c1, b1;
                a1 = sm.table[i, 0];
                b1 = sm.table[i, 1];
                c1 = sm.table[i, 2];
                v.Add(new KeyValuePair<Rational, Rational>(0, c1 / b1));
                v.Add(new KeyValuePair<Rational, Rational>(c1 / a1, 0));
            }

            KeyValuePair<Rational, Rational> best = new KeyValuePair<Rational, Rational>();
            bool isFirst = true;
            foreach (var p in v)
            {
                for (int i = 0; i < sm.nRestrs; i++)
                {
                    if (p.Key * sm.table[i, 0] + p.Value * sm.table[i, 1] <= sm.table[i, 2])
                    {
                        if (isFirst || countValue(best) > countValue(p))
                        {
                            isFirst = false;
                            best = p;
                        }
                    }
                }
            }

            return best;
        }

        private Rational countValue(KeyValuePair<Rational, Rational> p)
        {
            Rational[] v = new Rational[2] { p.Key, p.Value };
            return sm.CountRes(v);
        }

        private void GraphicMethodForm_Load(object sender, EventArgs e)
        {
            List<Panel> panels = new List<Panel>();
            List<Label> labels = new List<Label>();
            panels.Add(panelRestr1);
            labels.Add(LabelRestr1);

            for (int i = 1; i < sm.nRestrs; i++)
            {
                panels.Add(new Panel());
                labels.Add(new Label());
                this.Controls.Add(panels[i]);
                this.Controls.Add(labels[i]);
                
            }

            int x = panelRestr1.Left;
            int y = LabelRestr1.Top;
            for (int i = 0; i < sm.nRestrs; i++)
            {
                panels[i].BackColor = colors[i % colors.Count];
                panels[i].Size = panels[0].Size;

                labels[i].Text = $"{sm.table[i, 0]}*X1 { ((sm.table[i, 1] > 0) ? "+" : "")} {sm.table[i, 1]}*X2 <= {sm.table[i, 2]}";
                labels[i].Font = labels[0].Font;
                labels[i].AutoSize = true;

                panels[i].Left = x;
                panels[i].Top = y;

                labels[i].Left = x + 20;
                labels[i].Top = y;
                y += 20;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawAsis(e.Graphics);
            DrawRestrs(e.Graphics);
        }
    }
}
