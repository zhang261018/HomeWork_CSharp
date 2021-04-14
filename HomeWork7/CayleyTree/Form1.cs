using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Orange");
            comboBox1.Items.Add("Red");
            comboBox1.Items.Add("Blue");
            comboBox1.Items.Add("Green");
            comboBox1.Items.Add("Yellow");
            comboBox1.Items.Add("Pink");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int depth = 0;
            double leng = 0;
            string color = comboBox1.Text;
            try
            {
                depth = Convert.ToInt32(textBox1.Text);
                leng = Convert.ToDouble(textBox2.Text);
                per1 = Convert.ToDouble(textBox3.Text);
                per2 = Convert.ToDouble(textBox4.Text);
                th1 = Convert.ToDouble(textBox5.Text) * Math.PI / 180;
                th2 = Convert.ToDouble(textBox6.Text) * Math.PI / 180;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n输入参数无效。");
            }

            if (graphics == null) graphics = this.CreateGraphics();
            graphics.Clear(Color.White);
            // CleanText();

            DrawCayleyTree(depth, 200, 400, leng, -Math.PI / 2, color);
        }

        public void DrawCayleyTree(int n, double x0, double y0, double leng, double th, string color)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1, color);
            DrawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1, color);
            DrawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2, color);
        }

        private void drawLine(double x0, double y0, double x1, double y1, string color)
        {
            switch (color.ToLower().Trim()) 
            {
                case "orange": graphics.DrawLine(Pens.Orange, (int)x0, (int)y0, (int)x1, (int)y1);break;
                case "blue": graphics.DrawLine(Pens.AliceBlue, (int)x0, (int)y0, (int)x1, (int)y1); break;
                case "yellow": graphics.DrawLine(Pens.Yellow, (int)x0, (int)y0, (int)x1, (int)y1); break;
                case "red": graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1); break;
                case "pink": graphics.DrawLine(Pens.Pink, (int)x0, (int)y0, (int)x1, (int)y1); break;
                case "green": graphics.DrawLine(Pens.Green, (int)x0, (int)y0, (int)x1, (int)y1); break;
                default: graphics.DrawLine(Pens.Pink, (int)x0, (int)y0, (int)x1, (int)y1); break;
            }
        }

        private void CleanText()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
