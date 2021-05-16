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
        internal bool isPartial = false;
        public OrderService orderService;
        public BindingSource orderDBindingSource;
        // List<Order> show;
        ModifyWin modifyWindows;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            orderService = new OrderService();
            orderDBindingSource = new BindingSource();

            odrDataGridView.AutoGenerateColumns = false;
            odrDetailsGridView.AutoGenerateColumns = false;

            selectBy.Items.Add("Time");
            selectBy.Items.Add("Number");
            selectBy.Items.Add("Client");
            selectBy.Items.Add("Address");
            selectBy.Items.Add("Amount");
            selectBy.SelectedItem = selectBy.Items[1];

            modifyWindows = new ModifyWin(this);
            showSelect.Items.Add("当前选中");

            orderBindingSource.DataSource = orderService.QueryAll();
            orderDBindingSource.DataSource = null;

            odrDataGridView.DataSource = orderBindingSource;
            odrDetailsGridView.DataSource = orderDBindingSource;
        }

        private void 删除该订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentOrderNumber = odrDataGridView.CurrentRow.Index;
            int orderNumber = Convert.ToInt32(odrDataGridView.Rows[currentOrderNumber].Cells[0].Value.ToString());

            orderBindingSource.DataSource = null;

            try
            {
                orderService.Delete(orderNumber);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("删除成功");

            orderBindingSource.DataSource = orderService.QueryAll();
            orderDBindingSource.ResetBindings(isPartial);
            isPartial = false;
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
            orderBindingSource.DataSource = orderService.QueryAll();
        }

        private void OdrGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            if (row > -1)
            {
                showSelect.Items.Clear();
                Order findOrder = orderService.FindOrder(Convert.ToInt32(odrDataGridView.Rows[row].Cells[0].Value));
                orderDBindingSource.DataSource = orderService.QueryAllDetail(findOrder.OrderNumber);
                showSelect.Items.Add("当前选中:");
                showSelect.Items.Add(findOrder.OrderNumber.ToString()+"\t"+findOrder.Client+"\t"+findOrder.OrderAddress+"\t"
                    +findOrder.OrderAmount+"\t"+findOrder.OrderTime.ToString("yy-MM-dd"));
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
            int orderNumber = Convert.ToInt32(odrDataGridView.Rows[currentOrderNumber].Cells[0].Value);

            ModifyWin modifyWin = new ModifyWin(this.orderService, orderNumber);
            modifyWin.Show();
            orderBindingSource.DataSource = orderService.QueryAll();
            orderDBindingSource.ResetBindings(isPartial);
            isPartial = false;
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
            modifyWindows.Show();
        }

        private void OdrDetailsGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip2.Show(MousePosition);
        }

        private void 添加新订单明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int orderNumber = 0;
            Order targetOrder = new Order();
            int currentOrderNumber = odrDataGridView.CurrentRow.Index;

            try
            {
                orderNumber = Convert.ToInt32(odrDataGridView.Rows[currentOrderNumber].Cells[0].Value);
                targetOrder = orderService.FindOrder(orderNumber);
            }
            catch(Exception exp)
            {
                MessageBox.Show("请输入正确的参数" + exp.Message);
                return;
            }

            AddDetails newForm = new AddDetails(this);
            newForm.Show();

            orderDBindingSource.ResetBindings(false);
        }

        private void 删除该订单明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentOrderNumber = odrDataGridView.CurrentRow.Index, orderNumber = 0;
            int currentDetailNumber = odrDetailsGridView.CurrentRow.Index;
            string tradeName = "";

            try
            {
                orderNumber = Convert.ToInt32(odrDataGridView.Rows[currentOrderNumber].Cells[0].Value);
                tradeName = odrDetailsGridView.Rows[currentDetailNumber].Cells[0].Value.ToString();
            }
            catch(Exception exp)
            {
                MessageBox.Show("请输入正确参数" + exp.Message);
                return;
            }

            try
            {
                orderService.DeleteDetail(orderNumber, tradeName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("删除成功");

            orderDBindingSource.ResetBindings(false);
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string kind = "";
            string message = searchItem.Text.Trim();
            Func<Order, bool> filter;
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
                orderBindingSource.DataSource = orderService.QueryAll();
                orderBindingSource.ResetBindings(isPartial);
                isPartial = false;
                return;
            }
            try
            {
                switch (kind)
                {
                    case "Number": filter = od => od.OrderNumber.Equals(Convert.ToInt32(message)); break;
                    case "Time": filter = od => od.OrderTime.ToString("yy-MM-dd") == message; break;
                    case "Client": filter = od => od.Client == message; break;
                    case "Address": filter = od => od.OrderAddress == message; break;
                    case "Amount": filter = od => od.OrderAmount == Convert.ToInt32(message); break;
                    default: filter = od => true; break;
                }
                List<Order> ans = orderService.QueryOrder(filter);
                orderBindingSource.DataSource = ans;
                isPartial = true;
                orderBindingSource.ResetBindings(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
