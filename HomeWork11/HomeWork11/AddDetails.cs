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
        Form1 form;
        OrderService service;
        public AddDetails(Form1 form)
        {
            InitializeComponent();
            service = form.orderService;
            this.form = form;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string newTradeName = textBox1.Text.Trim();
            string newTradePrice = textBox3.Text.Trim();
            string newTradeAmount = textBox2.Text.Trim();
            string orderNumber = textBox4.Text.Trim();
            try
            {
                Convert.ToInt32(newTradePrice);
                Convert.ToInt32(textBox2.Text.Trim());
                Convert.ToInt32(orderNumber);
            }catch(Exception)
            {
                MessageBox.Show("请输入有效数字");
            }

            OrderDetail newOrderDetails = new OrderDetail();
            newOrderDetails.OrderNumber = Convert.ToInt32(orderNumber);
            newOrderDetails.TradeName = newTradeName.Trim();
            newOrderDetails.TradePrice = Convert.ToInt32(newTradePrice);
            newOrderDetails.TradeAmount = Convert.ToInt32(newTradeAmount);
            service.AddDetail(newOrderDetails);

            form.orderDBindingSource.ResetBindings(false);

            this.Close();
        }

        private void AddDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
