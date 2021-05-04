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

namespace SimpleCrawler
{
    class Crawler
    {
        private string startUrl = "";
        private Regex crawlNext = new Regex(@"\.(html|HTML|aspx|jsp)$");    //判断网页格式 
        private Regex absolutePath = new Regex(@"^[a-zA-Z]+:.*");           //判断是否为绝对路径
        private Hashtable urls = new Hashtable();
        private int count = 0;

        public string StartUrl { set => startUrl = value; }

        static void Main(string[] args)
        { 
            Crawler myCrawler = new Crawler();
            new Thread(myCrawler.Crawl).Start();
        }

        Crawler(string url = "http://www.cnblogs.com/dstang2000/")
        {
            startUrl = url;
            this.urls.Add(startUrl, false);
        }

        private void Crawl()
        {
            Console.WriteLine("开始爬行了.... ");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }

                if (current == null ||count > 50) break;

                // 将相对地址转换成绝对地址
                if(!absolutePath.IsMatch(current))
                {
                    current = System.IO.Path.GetFullPath(current);
                }

                Console.WriteLine("爬行" + current + "页面!");
                string html = DownLoad(current); // 下载
                urls[current] = true;
                count++;

                // 当爬取html等网页时才解析并加入新链接
                if(crawlNext.IsMatch(current))
                    Parse(html);

                Console.WriteLine("爬行结束");
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
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        private void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
