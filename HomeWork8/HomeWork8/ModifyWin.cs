﻿using System;
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
        private string modifyOrder;
        public ModifyWin(OrderService orderService)
        {
            InitializeComponent();
            this.orderService = orderService;
            modifyOrder = "";
        }

        public ModifyWin(OrderService orderService, string modify)
        {
            this.orderService = orderService;
            this.modifyOrder = modify;
        }

        private void modify_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string orderNumber = textBox1.Text.Trim();
            string Client = textBox2.Text.Trim();
            string orderAmount = textBox3.Text.Trim();
            string orderAddress = textBox4.Text.Trim();
            DateTime dateTime = monthCalendar1.SelectionStart;
            List<OrderDetails> newOrders = new List<OrderDetails>();

            Order newOrder = new Order(newOrders, orderNumber,Client,orderAmount,orderAddress,dateTime);
            orderService.Add(newOrder);

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(modifyOrder == "")
            {
                MessageBox.Show("不能从添加按钮中进行修改");
                return;
            }

            string orderNumber = textBox1.Text.Trim();
            string Client = textBox2.Text.Trim();
            string orderAmount = textBox3.Text.Trim();
            string orderAddress = textBox4.Text.Trim();
            DateTime dateTime = monthCalendar1.SelectionStart;
            List<OrderDetails> newOrders = new List<OrderDetails>();

            Order newOrder = new Order(newOrders, orderNumber, Client, orderAmount, orderAddress, dateTime);
            orderService.Modify(modifyOrder, newOrder);
        }
    }
}