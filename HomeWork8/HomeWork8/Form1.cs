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
    public partial class Form1 : Form
    {
        OrderService orderService;
        BindingSource orderBindingSource;
        BindingSource orderDBindingSource;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            orderService = new OrderService();
            orderBindingSource = new BindingSource();
            orderDBindingSource = new BindingSource();

            comboBox1.Items.Add("Time");
            comboBox1.Items.Add("Number");
            comboBox1.Items.Add("Client");
            comboBox1.Items.Add("Address");
            comboBox1.Items.Add("Amount");
            comboBox1.SelectedItem = comboBox1.Items[1];

            orderBindingSource.DataSource = orderService.OrderList;

            dataGridView1.DataSource = orderBindingSource;
            dataGridView2.DataSource = orderDBindingSource;
        }

        private void 删除该订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentOrderNumber = dataGridView1.CurrentRow.Index;
            string orderNumber = dataGridView1.Rows[currentOrderNumber].Cells[0].Value.ToString();

            orderBindingSource.DataSource = null;

            try
            {
                orderService.Delete(orderNumber.Trim());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("删除成功");

            orderBindingSource.DataSource = orderService.OrderList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kind = "";
            string message = textBox1.Text.Trim();
            try
            {
                kind = comboBox1.SelectedItem.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if(message == "")
            {
                orderBindingSource.DataSource = orderService.OrderList;
                return;
            }
            try
            {
                switch (kind)
                {
                    case "Number": orderBindingSource.DataSource = orderService.SearchByNumber(message); break;
                    case "Time": orderBindingSource.DataSource = orderService.SearchByTime(message); break;
                    case "Client": orderBindingSource.DataSource = orderService.SearchByClient(message); break;
                    case "Address": orderBindingSource.DataSource = orderService.SearchByAddress(message); break;
                    case "Amount": orderBindingSource.DataSource = orderService.SearchByAmount(Convert.ToDouble(message)); break;
                    default: orderBindingSource.DataSource = orderService.OrderList;break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 导入数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string loadPath = "";
            OpenFileDialog tempForm = new OpenFileDialog();
            tempForm.InitialDirectory = Application.StartupPath;
            tempForm.Title = "请选择导入的文件（请选择xml格式文件）";
            tempForm.Filter = "xml文件|*.xml";
            try
            {
                //当文件选择正确并点击确认的时候继续执行
                if (tempForm.ShowDialog() == DialogResult.OK)
                {
                    loadPath = tempForm.FileName;
                }
                //选择取消等则直接退出
                else
                {
                    return;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("文件读取失败，请检查格式是否正确" + exception.StackTrace);
            }

            orderService.Import(loadPath);
            orderBindingSource.DataSource = orderService.OrderList;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            List<Order> odr = null;
            if (row > -1)
            {
                odr = orderService.SearchByNumber(dataGridView1.Rows[row].Cells[0].Value.ToString());
                orderDBindingSource.DataSource = odr[0].Orders;
                label1.Text = "当前选中：";
                foreach (Order o in odr)
                {
                    label1.Text += o.ToString();
                }
            }

            if(e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(MousePosition);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(MousePosition);
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void 修改该订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentOrderNumber = dataGridView1.CurrentRow.Index;
            string orderNumber = dataGridView1.Rows[currentOrderNumber].Cells[0].Value.ToString();

            orderBindingSource.DataSource = null;
            ModifyWin tmpForm = new ModifyWin(this.orderService, orderNumber);
            tmpForm.Show();
            orderBindingSource.DataSource = orderService.OrderList;
        }

        private void 导出数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string savePath = "";
            OpenFileDialog tempForm = new OpenFileDialog();

            tempForm.Title = "请选择导出的文件（请选择xml格式文件）";
            tempForm.Filter = "xml文件|*.xml";

            try
            {
                //当文件选择正确的时候继续执行
                if (tempForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                savePath = tempForm.FileName;
            }
            catch (Exception exception)
            {
                MessageBox.Show("文件导出失败，请检查格式是否正确" + exception.StackTrace);
            }

            orderService.Export(savePath);
        }

        private void 创建新订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifyWin tempWindows = new ModifyWin(this.orderService);
            orderBindingSource.DataSource = null;
            tempWindows.Show();
            orderBindingSource.DataSource = orderService.OrderList;
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip2.Show(MousePosition);
        }

        private void 添加新订单明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentOrderNumber = dataGridView1.CurrentRow.Index;
            string orderNumber = dataGridView1.Rows[currentOrderNumber].Cells[0].Value.ToString();
            Order targetOrder = orderService.OrderList.Find((Order order) => { return order.orderNumber == orderNumber; });

            orderDBindingSource.DataSource = null;

            AddDetails newForm = new AddDetails(targetOrder);
            newForm.Show();

            orderDBindingSource.DataSource = targetOrder.Orders;
        }

        private void 删除该订单明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentOrderNumber = dataGridView1.CurrentRow.Index;
            int currentDetailNumber = dataGridView2.CurrentRow.Index;

            string orderNumber = dataGridView1.Rows[currentOrderNumber].Cells[0].Value.ToString();
            string tradeName = dataGridView2.Rows[currentDetailNumber].Cells[0].Value.ToString();
            string tradePrice = dataGridView2.Rows[currentDetailNumber].Cells[1].Value.ToString();
            string tradeAmount = dataGridView2.Rows[currentDetailNumber].Cells[2].Value.ToString();

            Order targetOrder = null;
            OrderDetails tmp = new OrderDetails(tradeName, tradePrice, tradeAmount);

            orderDBindingSource.DataSource = null;
            try
            {
                targetOrder = orderService.OrderList.Find((Order order) => { return order.orderNumber == orderNumber; });
                targetOrder.Orders.Remove(tmp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("删除成功");

            orderDBindingSource.DataSource = targetOrder.Orders;
        }

    }
}
