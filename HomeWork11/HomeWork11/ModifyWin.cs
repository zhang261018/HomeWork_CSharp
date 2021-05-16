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
    public partial class ModifyWin : Form
    {
        private OrderService orderService;
        private int modifyOrder;
        private Form1 form;
        public ModifyWin(Form1 form)
        {
            InitializeComponent();
            modifyOrder = Int32.MinValue;
            this.form = form;
            orderService = new OrderService();
        }

        public ModifyWin(OrderService orderService, int modify)
        {
            InitializeComponent();
            this.orderService = orderService;
            this.modifyOrder = modify;
        }

        private void modify_Load(object sender, EventArgs e)
        {
            
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            int orderNumber = 0;
            string Client = "";
            string orderAmount = "";
            string orderAddress = "";
            DateTime dateTime = new DateTime();

            try
            {
                orderNumber = Convert.ToInt32(textBox1.Text.Trim());
                Client = textBox2.Text.Trim();
                orderAmount = textBox3.Text.Trim();
                orderAddress = textBox4.Text.Trim();
                dateTime = monthCalendar1.SelectionStart;
            }
            catch(Exception exp)
            {
                MessageBox.Show("请输入正确的参数" + exp.Message);
            }

            Order newOrder = new Order();
            newOrder.OrderNumber = orderNumber;
            newOrder.Client = Client;
            newOrder.OrderAmount = Convert.ToInt32(orderAmount);
            newOrder.OrderAddress = orderAddress;
            newOrder.OrderTime = dateTime;

            form.orderService.Add(newOrder);

            form.orderBindingSource.DataSource = orderService.QueryAll();
            form.orderBindingSource.ResetBindings(form.isPartial);
            form.isPartial = false;

            this.Hide();
        }

        private void ModifyButton_Click(object sender, EventArgs e)
        {
            if(modifyOrder == Int32.MinValue)
            {
                MessageBox.Show("不能从添加按钮中进行修改");
                return;
            }

            int orderNumber = 0;
            string Client = "";
            string orderAmount = "";
            string orderAddress = "";
            DateTime dateTime = new DateTime();

            try
            {
                orderNumber = Convert.ToInt32(textBox1.Text.Trim());
                Client = textBox2.Text.Trim();
                orderAmount = textBox3.Text.Trim();
                orderAddress = textBox4.Text.Trim();
                dateTime = monthCalendar1.SelectionStart;
            }
            catch(Exception exp)
            {
                MessageBox.Show("请输入正确的参数" + exp.Message);
            }

            Order newOrder = new Order();
            newOrder.OrderNumber = orderNumber;
            newOrder.Client = Client;
            newOrder.OrderAmount = Convert.ToInt32(orderAmount);
            newOrder.OrderAddress = orderAddress;
            newOrder.OrderTime = dateTime;

            orderService.Modify(modifyOrder, newOrder);
            form.orderBindingSource.ResetBindings(false);
            this.Close();
        }
    }
}
