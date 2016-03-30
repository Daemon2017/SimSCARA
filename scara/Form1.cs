using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scara
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double O2, O3, O, x0, y0, x1, y1, x01, y01;
        double a2, a3, x, y;

        private void Form1_Load(object sender, EventArgs e)
        {
            x0 = (pictureBox1.Size.Width / 2);
            y0 = (pictureBox1.Size.Height / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x = double.Parse(textBox1.Text);
            y = double.Parse(textBox2.Text);
            a2 = double.Parse(textBox3.Text);
            a3 = double.Parse(textBox4.Text);

            O2 = Math.Atan(y / x) - Math.Asin((a3 / Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2))) * Math.Sqrt(1 - Math.Pow(((Math.Pow(x, 2) + Math.Pow(y, 2) - Math.Pow(a2, 2) - Math.Pow(a3, 2)) / (2 * a2 * a3)), 2)));
            O3 = Math.Acos((Math.Pow(x, 2) + Math.Pow(y, 2) - Math.Pow(a2, 2) - Math.Pow(a3, 2)) / (2 * a2 * a3));

            label2.Text = O2.ToString();
            label3.Text = O3.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            O2 = double.Parse(textBox8.Text);
            O3 = double.Parse(textBox7.Text);
            a2 = double.Parse(textBox3.Text);
            a3 = double.Parse(textBox4.Text);

            x1 = a3 * Math.Cos(O2 + O3) + a2 * Math.Cos(O2);
            y1 = a3 * Math.Sin(O2 + O3) + a2 * Math.Sin(O2);

            label5.Text = x1.ToString();
            label6.Text = y1.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics graph = pictureBox1.CreateGraphics();

            Pen pen_black = new Pen(Brushes.Black, 4);
            Pen pen_red = new Pen(Brushes.Red, 3);

            x01 = x0 + a2 * Math.Cos(O2);
            y01 = y0 + a2 * Math.Sin(O2);

            graph.DrawLine(pen_red, (float)x0, (float)y0, (float)x01, (float)y01);
            graph.DrawLine(pen_red, (float)x01, (float)y01, (float)(x0 + x1), (float)(y0 + y1));

            graph.DrawEllipse(pen_black, (float)x0, (float)y0, 1, 1);
            graph.DrawEllipse(pen_black, (float)x01, (float)y01, 1, 1);
            graph.DrawEllipse(pen_black, (float)(x0 + x1), (float)(y0 + y1), 1, 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                O = O3;
                O3 = O3 + 0.1;

                if (O3 != O)
                {
                    O3 = O3 + 0.01;
                    O2 = O2 + 0.01;

                    Graphics graph = pictureBox1.CreateGraphics();

                    Pen pen_black = new Pen(Brushes.Black, 4);
                    Pen pen_red = new Pen(Brushes.Red, 3);

                    x01 = x0 + a2 * Math.Cos(O2);
                    y01 = y0 + a2 * Math.Sin(O2);

                    x1 = a3 * Math.Cos(O2 + O3) + a2 * Math.Cos(O2);
                    y1 = a3 * Math.Sin(O2 + O3) + a2 * Math.Sin(O2);

                    graph.DrawLine(pen_red, (float)x0, (float)y0, (float)x01, (float)y01);
                    graph.DrawLine(pen_red, (float)x01, (float)y01, (float)(x0 + x1), (float)(y0 + y1));

                    graph.DrawEllipse(pen_black, (float)x0, (float)y0, 1, 1);
                    graph.DrawEllipse(pen_black, (float)x01, (float)y01, 1, 1);
                    graph.DrawEllipse(pen_black, (float)(x0 + x1), (float)(y0 + y1), 1, 1);
                }
                else
                {
                    timer1.Stop();
                }
        }
    }
}
