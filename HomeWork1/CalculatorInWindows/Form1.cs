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
            comboBox1.Items.Add("%");
        }

        //链接计算按钮的槽函数
        private void button1_Click(object sender, EventArgs e)
        {
            double num1 = 0, num2 = 0;
            string _operator = comboBox1.SelectedItem.ToString().Trim();

            //获取用户输入的变量与选择的运算
            try
            {
                num1 = Double.Parse(textBox1.Text.Trim());
                num2 = Double.Parse(textBox2.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input correct numbers plz.");
                return;
            }

            //判断运算种类
            try
            {
                switch (_operator)
                {
                    case "+": textBox4.Text = $"{num1 + num2}"; break;
                    case "-": textBox4.Text = $"{num1 - num2}"; break;
                    case "*": textBox4.Text = $"{num1 * num2}"; break;
                    //C#除以0会得到无穷，这是我们想要的结果，故此处不抛出异常
                    case "/": textBox4.Text = $"{num1 / num2}"; break;
                    case "%":
                        {
                            if (Math.Abs(num2) >= 1e-7)
                                textBox4.Text = $"{num1 % num2}";
                            else
                                throw new DivideByZeroException("mod zero Exception.");
                        }
                        break;
                }
            }
            //模零异常处理
            catch (DivideByZeroException ex)
            {
                MessageBox.Show("you can't mod zero.");
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
