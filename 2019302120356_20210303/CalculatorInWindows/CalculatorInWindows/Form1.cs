using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorInWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form1_Load();
        }

        //为comboBox添加初始选项
        public void Form1_Load()
        {
            comboBox1.Items.Add("+");
            comboBox1.Items.Add("-");
            comboBox1.Items.Add("*");
            comboBox1.Items.Add("/");
        }

        //链接计算按钮的槽函数
        private void button1_Click(object sender, EventArgs e)
        {
            //获取用户输入的变量与选择的运算
            double num1 = Double.Parse(textBox1.Text.Trim());
            double num2 = Double.Parse(textBox2.Text.Trim());
            string _operator = comboBox1.SelectedItem.ToString().Trim();

            //判断运算种类
            try
            {
                switch (_operator)
                {
                    case "+": textBox4.Text = $"{num1 + num2}";break;
                    case "-": textBox4.Text = $"{num1 - num2}";break;
                    case "*": textBox4.Text = $"{num1 * num2}";break;
                    case "/": textBox4.Text = $"{num1 / num2}";break;
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.Write("divide by zero!");
                textBox4.Text = Double.NaN.ToString();
            }
        }

        //链接清空按钮的槽函数
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
        }

    }
}
