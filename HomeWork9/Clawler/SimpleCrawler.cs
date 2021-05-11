using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SimpleCrawler
{
    class Crawler
    {
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);
        const int WM_COPYDATA = 0x004A;

        private string startUrl = "http://www.cnblogs.com/dstang2000/";
        private string Host;
        private Regex crawlNext = new Regex("((.html?|.aspx|.jsp|.php)$|^[^.]+$)");    //判断网页格式 
        private Regex urlContent = new Regex(@"^(?<site>(?<protocal>https?)://(?<host>[\w.-]+)(:\d+)?($|/))(\w+/)*(?<type>[^#?]*)");
        private Hashtable urls = new Hashtable();
        private int count = 0;

        public string StartUrl {
            set{
                if (value is string)
                {
                    startUrl = value; urls.Clear();
                    Host = urlContent.Match(startUrl).Groups["host"].Value;
                    urls.Add(startUrl, false);
                }
            }
        }

        public Hashtable URLs { get => urls;  }

        public Crawler(string url = "http://www.cnblogs.com/dstang2000/")
        {
            startUrl = url;
            Host = urlContent.Match(startUrl).Groups["host"].Value;
            this.urls.Add(startUrl, false);
        }

        public void Crawl()
        {
            int hWnd = (int)FindWindow(null, "littleCrawler");
            bool find = (hWnd != 0);
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }

                if (current == null || count > 200) break;

                try
                {
                    urls[current] = true; count++;
                    string html = DownLoad(current); // 下载
                    Parse(html, current);
                    if (find) current = "爬取成功: " + current;
                }
                catch (Exception)
                {
                    if (find) current = "爬取失败: " + current;
                }

                //向窗口发送信息
                byte[] byteStr = System.Text.Encoding.Default.GetBytes(current);
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)0;
                cds.cbData = byteStr.Length + 1;
                cds.lpData = current;
                SendMessage(hWnd, WM_COPYDATA, 0, ref cds);
            }
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }

        private void Parse(string html, string baseURL)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', '>');
                if (strRef.Length == 0 || strRef.StartsWith("javascript:")) continue;

                strRef = CompletURL(strRef, baseURL);
                string currentHost = urlContent.Match(strRef).Groups["host"].Value;
                string currentFileType = urlContent.Match(strRef).Groups["type"].Value;
                if (Regex.IsMatch(currentHost, Host) && crawlNext.IsMatch(currentFileType) && urls[strRef] == null) urls[strRef] = false;
            }
        }

        private string CompletURL(string url, string baseURL)
        {
            if (url.Contains("://")) return url;
            else if (url.StartsWith("//"))
            {
                MatchCollection matches = urlContent.Matches(baseURL);
                return matches[matches.Count - 1].Groups["protocal"].Value + ":" + url;
            }
            else if (url.StartsWith("/"))
            {
                MatchCollection matches = urlContent.Matches(baseURL);
                string site = matches[matches.Count - 1].Groups["site"].Value;
                return site + (site.EndsWith("/")?url.Substring(1):url);
            }
            else if (url.StartsWith("./")) return CompletURL(url.Substring(2), baseURL);
            else if (url.StartsWith("../"))
            {
                int lastIndex = baseURL.Substring(3).LastIndexOf("/");
                return CompletURL(url, baseURL.Substring(0, 3 + lastIndex));
            }
            int idx = baseURL.LastIndexOf("/");
            return baseURL.Substring(0, idx) + "/" + url;
        }
    }
}


