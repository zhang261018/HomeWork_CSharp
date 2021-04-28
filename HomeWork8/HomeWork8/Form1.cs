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
        public OrderService orderService;
        public BindingSource orderBindingSource;
        public BindingSource orderDBindingSource;
        ModifyWin modifyWindows;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            orderService = new OrderService();
            orderBindingSource = new BindingSource();
            orderDBindingSource = new BindingSource();

            selectBy.Items.Add("Time");
            selectBy.Items.Add("Number");
            selectBy.Items.Add("Client");
            selectBy.Items.Add("Address");
            selectBy.Items.Add("Amount");
            selectBy.SelectedItem = selectBy.Items[1];

            modifyWindows = new ModifyWin(this);
            showSelect.Items.Add("当前选中");

            orderBindingSource.DataSource = orderService.OrderList;

            odrDataGridView.DataSource = orderBindingSource;
            odrDetailsGridView.DataSource = orderDBindingSource;
        }

        private void 删除该订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentOrderNumber = odrDataGridView.CurrentRow.Index;
            string orderNumber = odrDataGridView.Rows[currentOrderNumber].Cells[0].Value.ToString();

            // orderBindingSource.DataSource = null;

            try
            {
                orderService.Delete(orderNumber.Trim());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("删除成功");

            // orderBindingSource.DataSource = orderService.OrderList;
            orderBindingSource.ResetBindings(false);
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

        private void OdrGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            List<Order> odr = null;
            if (row > -1)
            {
                showSelect.Items.Clear();
                odr = orderService.SearchByNumber(odrDataGridView.Rows[row].Cells[0].Value.ToString());
                orderDBindingSource.DataSource = odr[0].Orders;
                showSelect.Items.Add("当前选中:");
                foreach (Order o in odr)
                {
                    showSelect.Items.Add(odr[0].ToString());
                }
            }

            if(e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(MousePosition);
        }

        private void OdrGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(MousePosition);
        }

        private void 修改该订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentOrderNumber = odrDataGridView.CurrentRow.Index;
            string orderNumber = odrDataGridView.Rows[currentOrderNumber].Cells[0].Value.ToString();

            ModifyWin modifyWin = new ModifyWin(this.orderService, orderNumber);
            modifyWin.Show();
            // orderBindingSource.DataSource = orderService.OrderList;
            orderBindingSource.ResetBindings(false);
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
            // ModifyWin tempWindows = new ModifyWin(this.orderService);
            modifyWindows.Show();

        }

        private void OdrDetailsGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip2.Show(MousePosition);
        }

        private void 添加新订单明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentOrderNumber = odrDataGridView.CurrentRow.Index;
            string orderNumber = odrDataGridView.Rows[currentOrderNumber].Cells[0].Value.ToString();
            Order targetOrder = orderService.OrderList.Find((Order order) => { return order.orderNumber == orderNumber; });

            AddDetails newForm = new AddDetails(targetOrder);
            newForm.Show();

            // orderDBindingSource.DataSource = targetOrder.Orders;
            orderDBindingSource.ResetBindings(false);
        }

        private void 删除该订单明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentOrderNumber = odrDataGridView.CurrentRow.Index;
            int currentDetailNumber = odrDetailsGridView.CurrentRow.Index;

            string orderNumber = odrDataGridView.Rows[currentOrderNumber].Cells[0].Value.ToString();
            string tradeName = odrDetailsGridView.Rows[currentDetailNumber].Cells[0].Value.ToString();
            string tradePrice = odrDetailsGridView.Rows[currentDetailNumber].Cells[1].Value.ToString();
            string tradeAmount = odrDetailsGridView.Rows[currentDetailNumber].Cells[2].Value.ToString();

            Order targetOrder = null;
            OrderDetails tmp = new OrderDetails(tradeName, tradePrice, tradeAmount);

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

            // orderDBindingSource.DataSource = targetOrder.Orders;
            orderDBindingSource.ResetBindings(false);
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string kind = "";
            string message = searchItem.Text.Trim();
            try
            {
                kind = selectBy.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (message == "")
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
                    default: orderBindingSource.DataSource = orderService.OrderList; break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
