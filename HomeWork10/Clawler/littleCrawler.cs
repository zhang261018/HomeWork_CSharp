using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using SimpleCrawler;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Clawler
{
    public partial class littleCrawler : Form
    {
        private static int WMA_InterPro = 0x004A;
        string validUrl = @"(http://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";

        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        public littleCrawler()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        protected override void DefWndProc(ref Message message)
        {
            if (message.Msg == WMA_InterPro)
            {
                COPYDATASTRUCT cds = new COPYDATASTRUCT();
                Type t = cds.GetType();
                cds = (COPYDATASTRUCT)message.GetLParam(t);
                string receiveInfo = cds.lpData;
                listBox1.Items.Add(receiveInfo);
            }
            else
            {
                base.DefWndProc(ref message);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            Crawler crawler = new Crawler();
            if (!(url == "") && new Regex(validUrl).IsMatch(url))
            {
                crawler.StartUrl = url;
            }
            Thread crawlerTh = new Thread(crawler.Crawl);
            crawlerTh.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
