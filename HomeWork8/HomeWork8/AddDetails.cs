using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManager;

namespace HomeWork8
{
    public partial class AddDetails : Form
    {
        Order operateOrder;
        public AddDetails(Order order)
        {
            InitializeComponent();
            operateOrder = order;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newTradeName = textBox1.Text.Trim();
            string newTradePrice = textBox3.Text.Trim();
            string newTradeAmount = textBox2.Text.Trim();
            try
            {
                Convert.ToInt32(newTradePrice);
                Convert.ToInt32(textBox2.Text.Trim());
            }catch(Exception)
            {
                MessageBox.Show("请输入有效数字");
            }

            OrderDetails newOrderDetails = new OrderDetails(newTradeName,newTradePrice,newTradeAmount);
            operateOrder.Orders.Add(newOrderDetails);

            this.Close();
        }
    }
}
