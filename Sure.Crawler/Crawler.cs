namespace Sure.Crawler
{
    using Sure.Crawler.General;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Windows.Forms;
    using System.IO;
    using System.Dynamic;

    /*---------------------------------------------------------------------
    [author]:senlin.huang
    [time]:2018-1-25
    [explain]: Crawler
    -----------------------------------------------------------------------*/
    public partial class Crawler : Form
    {
        private static int threadNumber = 5; //开启线程数

        //创建下载对象
        private DownLoadFileGeneral downLoadFileGeneral = new DownLoadFileGeneral();

        /// <summary>
        /// 无参构造
        /// </summary>
        public Crawler() { InitializeComponent(); }

        //开始爬虫
        private void But_Crawler_Click(object sender, EventArgs e)
        {
            /*
            地址：
            http://www.46ek.com
            http://www.46ek.com/list/2.html
            http://www.46ek.com/view/22157.html
            正则：
            http://m4.26ts.com/[.0-9-a-zA-Z]*.mp4
            */

            if (string.IsNullOrEmpty(txt_Url.Text.Trim()))
                MessageBox.Show("请填写地址", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //地址请求
            string result = HTTPGeneral.HTTPCrawler(txt_Url.Text.Trim(), "GET");
            //存储提取到 List URL 请求
            List<string> listUrl = new List<string>();
            //提取页面的 a 标签
            var matches = Regex.Matches(result, @"<a href=""([^>]+?)"">([^<]+?)</a>", RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                var matchHref = Regex.Match(match.Value, @"<a[^>]*href=([""'])?(?<href>[^'""]+)\1[^>]*>", RegexOptions.IgnoreCase).Groups["href"].Value.ToString();
                //电影区
                if (matchHref.Contains("list") && !listUrl.Contains($"http://www.46ek.com{matchHref}"))
                    listUrl.Add($"http://www.46ek.com{matchHref}");
            }

            listUrl.Sort();
            list_url.Items.Clear();
            foreach (var item in listUrl) { list_url.Items.Add(item); }

            //启用该控件
            list_url.Enabled = true;
        }

        //下载
        private void but_Down_Click(object sender, EventArgs e)
        {
            //检测网络是否连接
            if (!NetworkState())
            {
                MessageBox.Show("无网络连接", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            downLoadFileGeneral.StartDown(3); //启动
        }

        #region Menu

        //爬取菜单
        private void 爬取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_url.SelectedItem == null)
            {
                MessageBox.Show("请选择地址", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //爬取一级菜单请求
            string result = HTTPGeneral.HTTPCrawler(list_url.SelectedItem.ToString(), "GET");
            List<string> listUrl = new List<string>();
            var matches = Regex.Matches(result, @"<a href=""([^>]+?)"">([^<]+?)</a>", RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                //爬取到最大页数
                var matchHref = Regex.Match(match.Value, @"<a[^>]*href=([""'])?(?<href>[^'""]+)\1[^>]*>", RegexOptions.IgnoreCase).Groups["href"].Value.ToString();
                if (matchHref.Contains("list") && !listUrl.Contains($"http://www.46ek.com{matchHref}"))
                    if (matchHref.Contains("_"))
                        listUrl.Add($"http://www.46ek.com{matchHref}");
            }
            list_sonurl.Enabled = true;

            //二级
            string prefix_url = string.Empty;
            List<int> newlistUrl = new List<int>();
            foreach (var item in listUrl)
            {
                newlistUrl.Add(int.Parse(item.Split('_')[1].Substring(0, item.Split('_')[1].IndexOf("."))));
                prefix_url = item.Split('_')[0].ToString();
            }
            newlistUrl.Sort(); //排序

            //二级子菜单
            list_sonurl.Items.Clear();
            for (int i = 1; i <= newlistUrl[newlistUrl.Count - 1]; i++)
            {
                if (i == 1) list_sonurl.Items.Add($"{prefix_url}.html");
                else list_sonurl.Items.Add($"{prefix_url}_{i}.html");
            }
        }

        //二级爬取
        private void 二级爬取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_sonurl.SelectedItem == null)
            {
                MessageBox.Show("请选择地址", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //爬取一级菜单请求
            string result = HTTPGeneral.HTTPCrawler(list_sonurl.SelectedItem.ToString(), "GET");

            List<string> listUrl = new List<string>();
            var matches = Regex.Matches(result, @"<a href=""([^>]+?)"">([^<]+?)</a>", RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                //爬取到最大页数
                var matchHref = Regex.Match(match.Value, @"<a[^>]*href=([""'])?(?<href>[^'""]+)\1[^>]*>", RegexOptions.IgnoreCase).Groups["href"].Value.ToString();
                if (matchHref.Contains("view") && !listUrl.Contains(matchHref))
                    listUrl.Add(matchHref);
            }

            List<int> listIndex = new List<int>();
            foreach (var item in listUrl)
                listIndex.Add(int.Parse(item.Substring(item.LastIndexOf('/') + 1, 5)));

            //爬取视频
            if (listIndex.Count <= 0)
                MessageBox.Show("没有爬取到信息数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            threadNumber = int.Parse(txt_thread.Text.Trim()); //线程数

            ThreadCrawler threadCrawler = new ThreadCrawler(1, listIndex.Count, threadNumber, listIndex);
            Thread[] threads = new Thread[threadNumber];
            for (int i = 1; i <= threadNumber; i++)
            {
                threads[i - 1] = new Thread(new ThreadStart(threadCrawler.Crawlers));
                threads[i - 1].SetApartmentState(ApartmentState.MTA);
                threads[i - 1].Name = i.ToString();
                threads[i - 1].IsBackground = true;
                threads[i - 1].Start();
            }

            //启动定时器
            timerList.Enabled = false;
            //阻塞线程，等待线程完成
            for (int i = 0; i < threadNumber; i++) { threads[i].Join(); }
            foreach (var item in ThreadCrawler.fileList)
            {
                ListViewItem listViewItem = listView.Items.Add(
                    new ListViewItem(
                        new string[] { (listView.Items.Count + 1).ToString(), item.FileName, item.FileSize, "0", "0%", "0", "0", DateTime.Now.ToString(), "等待中", item.FileUrl }));
                downLoadFileGeneral.AddDown(item.FileUrl, txtDownPath.Text.Trim(), listViewItem.Index);
            }
        }

        #endregion

        #region Private 方法


        //检测网络状态
        [DllImport("wininet.dll")]
        extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);

        /// <summary>
        /// 检测网络状态
        /// </summary>
        bool NetworkState()
        {
            int I = 0;
            bool state = InternetGetConnectedState(out I, 0);
            return state;
        }

        private void SendMsgHander(DownMsg msg)
        {
            switch (msg.Tag)
            {
                case DownStatus.Start:
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        listView.Items[msg.Id].SubItems[8].Text = "开始下载";
                        listView.Items[msg.Id].SubItems[7].Text = DateTime.Now.ToString();
                    });
                    break;
                case DownStatus.GetLength:
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        listView.Items[msg.Id].SubItems[3].Text = msg.LengthInfo;
                        listView.Items[msg.Id].SubItems[8].Text = "连接成功";
                    });
                    break;
                case DownStatus.End:
                case DownStatus.DownLoad:
                    this.Invoke(new MethodInvoker(() =>
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            listView.Items[msg.Id].SubItems[4].Text = msg.Progress.ToString() + "%";
                            listView.Items[msg.Id].SubItems[5].Text = msg.SpeedInfo;
                            listView.Items[msg.Id].SubItems[6].Text = msg.SurplusInfo;
                            if (msg.Tag == DownStatus.DownLoad)
                            {
                                listView.Items[msg.Id].SubItems[8].Text = "下载中";
                            }
                            else
                            {
                                listView.Items[msg.Id].SubItems[8].Text = "下载完成";
                            }
                            Application.DoEvents();
                        });
                    }));
                    break;
                case DownStatus.Error:
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        listView.Items[msg.Id].SubItems[6].Text = "失败";
                        listView.Items[msg.Id].SubItems[8].Text = msg.ErrMessage;
                        Application.DoEvents();
                    });
                    break;
            }
        }

        #endregion

        #region 禁用

        private void list_url_SelectedIndexChanged(object sender, EventArgs e)
        {
            二级爬取ToolStripMenuItem.Enabled = false;
            爬取ToolStripMenuItem.Enabled = true;
        }

        private void list_sonurl_SelectedIndexChanged(object sender, EventArgs e)
        {
            爬取ToolStripMenuItem.Enabled = false;
            二级爬取ToolStripMenuItem.Enabled = true;
        }

        #endregion

        //定时器加载数据到列表 
        private void timerList_Tick(object sender, EventArgs e)
        {
            listView.Clear();
            if (ThreadCrawler.fileList.Count > 0)
            {
                foreach (var item in ThreadCrawler.fileList)
                {
                    listView.Items.Add(
                        new ListViewItem(
                            new string[] { (item.FileID).ToString(), item.FileName, item.FileSize, "0", "0%", "0", "0", DateTime.Now.ToString(), "等待中", item.FileUrl }));
                }
            }
        }

        private void Crawler_Load(object sender, EventArgs e)
        {
            downLoadFileGeneral.ThreadNum = 3;//线程数，不设置默认为3
            downLoadFileGeneral.doSendMsg += SendMsgHander;//下载过程处理事件

            listView.Columns[6].Width = 0;
            listView.Columns[7].Width = 0;

            //设置默认路径
            txtDownPath.Text = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")) + "\\Vido";
            if (!Directory.Exists(txtDownPath.Text))
            {
                Directory.CreateDirectory(txtDownPath.Text);
            }
        }

        private void butOpenPath_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txtDownPath.Text);
        }
    }

    #region 多线程爬虫

    /// <summary>
    /// 线程执行
    /// </summary>
    public class ThreadCrawler
    {
        private int minValue = 0;
        private int maxValue = 0;
        private int threadNumber = 0;

        //文件大小单位
        private const double KBSize = 1024;
        private const double MBSize = KBSize * 1024;
        private const double GBSize = MBSize * 1024;
        private const double TBSize = GBSize * 1024;

        private static object o = new object();
        public static List<Model.FileInfo> fileList = null;
        public static List<int> listIndex = new List<int>();

        public static string regexString = @"http://m4.26ts.com/[.0-9-a-zA-Z]*.mp4,http://m2.26ts.com/[.0-9-a-zA-Z]*.mp4,http://m2.6666player.com/[.0-9-a-zA-Z]*.mp4,http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*).mp4";


        /// <summary>
        /// Log4net 配置路径
        /// </summary>
        private static string log4netPath = string.Empty;

        /// <summary>
        /// 有参构造
        /// </summary>
        /// <param name="_minValue">循环开始数</param>
        /// <param name="_maxValue">循环结束数</param>
        /// <param name="_threadNumber">线程数</param>
        public ThreadCrawler(int _minValue, int _maxValue, int _threadNumber)
        {
            minValue = _minValue;
            maxValue = _maxValue;
            threadNumber = _threadNumber;
        }

        /// <summary>
        /// 有参构造
        /// </summary>
        /// <param name="_minValue">循环开始数</param>
        /// <param name="_maxValue">循环结束数</param>
        /// <param name="_threadNumber">线程数</param>
        public ThreadCrawler(int _minValue, int _maxValue, int _threadNumber, List<int> _listIndex)
        {
            minValue = _minValue;
            maxValue = _maxValue;
            threadNumber = _threadNumber;
            listIndex = _listIndex;
            log4netPath = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")) + "\\App_Data\\log4net\\log4net.config";
        }

        /// <summary>
        /// 爬虫执行
        /// </summary>
        public void Crawler()
        {
            DateTime beginTime = DateTime.Now;
            int threadOrder = Convert.ToInt32(Thread.CurrentThread.Name);
            long step = (maxValue - minValue + 1) / threadNumber;
            long beginValue = minValue + step * (threadOrder - 1);
            long endValue = beginValue + step;
            if (threadOrder == threadNumber)
                endValue = beginValue + step + ((maxValue - minValue + 1) % threadNumber);

            for (long i = beginValue; i < endValue; i++)
            {
                try
                {
                    string url = $"http://www.46ek.com/view/{i}.html";
                    Regex regex = new Regex(regexString);
                    string result = HTTPGeneral.HTTPCrawler(url, "GET");
                    Match m = regex.Match(result);
                    if (!string.IsNullOrEmpty(m.Value))
                    {
                        lock (o)
                        {
                            fileList.Add(new Model.FileInfo()
                            {
                                FileID = i.ToString(), //从1开始
                                FileName = m.Value.Substring(m.Value.LastIndexOf('/') + 1),
                                FileSize = GetFileSize(m.Value),
                                FileUrl = m.Value,
                                SynProgress = "0%",
                                Tag = "等待",
                                SynSpeed = "0KB",
                                DownPath = m.Value,
                                Async = true
                            });
                            Console.WriteLine(m.Value);
                        }
                    }
                }
                catch (Exception) { Thread.Sleep(1000); continue; }
            }
            DateTime endTime = DateTime.Now;
            TimeSpan timeSpan = endTime - beginTime;
            string message = "线程ID:" + Thread.CurrentThread.Name + " ----> Start: " + beginValue.ToString() + " -- End:" + endValue.ToString() + ", 耗时:" + timeSpan.TotalMinutes.ToString() + "分钟。";
            Console.WriteLine(message);
            Thread.CurrentThread.Abort();
        }

        /// <summary>
        /// 爬虫执行
        /// </summary>
        public void Crawlers()
        {
            fileList = new List<Model.FileInfo>();
            DateTime beginTime = DateTime.Now;
            int threadOrder = Convert.ToInt32(Thread.CurrentThread.Name); //线程ID
            long step = (maxValue - minValue + 1) / threadNumber;

            long beginValue = minValue + step * (threadOrder - 1);
            long endValue = beginValue + step;
            if (threadOrder == threadNumber)
                endValue = beginValue + step + ((maxValue - minValue + 1) % threadNumber);

            string msgUrl = string.Empty;
            for (long i = beginValue; i < endValue; i++)
            {
                try
                {
                    string url = $"http://www.46ek.com/view/{listIndex[Convert.ToInt32(i) - 1]}.html";
                    string result = HTTPGeneral.HTTPCrawler(url, "GET");

                    string[] regexStrings = regexString.Split(',');
                    Match match = null;
                    for (int j = 0; j < regexStrings.Length; j++)
                    {
                        match = new Regex(regexStrings[j]).Match(result);
                        if (match.Success)
                            break;
                    }

                    if (!string.IsNullOrEmpty(match.Value))
                    {
                        msgUrl = match.Value; //存储404链接
                        lock (o)
                        {
                            fileList.Add(new Model.FileInfo()
                            {
                                FileID = i.ToString(), //从1开始
                                FileName = match.Value.Substring(match.Value.LastIndexOf('/') + 1),
                                FileSize = GetFileSize(match.Value),
                                FileUrl = match.Value,
                                SynProgress = "0%",
                                Tag = "等待",
                                SynSpeed = "0KB",
                                DownPath = match.Value,
                                Async = true
                            });
                            Console.WriteLine(match.Value);
                            Thread.Sleep(1000);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log4net.log4netCreate(typeof(ThreadCrawler), log4netPath).Error($"爬取地址[{msgUrl}]访问错误，信息: " + ex.Message);
                    Thread.Sleep(1000); continue;
                }
            }
            DateTime endTime = DateTime.Now;
            TimeSpan timeSpan = endTime - beginTime;
            string message = "线程ID:" + Thread.CurrentThread.Name + " ----> Start: " + beginValue.ToString() + " -- End:" + endValue.ToString() + ", 耗时:" + timeSpan.TotalMinutes.ToString() + "分钟。";
            Console.WriteLine(message);
            Thread.CurrentThread.Abort();
        }

        #region Private

        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <param name="url">文件url地址</param>
        /// <returns>string</returns>
        private static string GetFileSize(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.CreateDefault(new Uri(url));
            httpWebRequest.Method = "Head";
            httpWebRequest.Timeout = 5000;
            using (var webResponse = httpWebRequest.GetResponse())
            {
                return GetAutoSize(webResponse.ContentLength, 2);
            }
        }

        /// <summary>
        /// 文件大小相互转换
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="roundCount">保留纪委小数</param>
        /// <returns>string</returns>
        private static string GetAutoSize(double size, int roundCount)
        {
            if (KBSize > size) return Math.Round(size, roundCount) + "B";
            else if (MBSize > size) return Math.Round(size / KBSize, roundCount) + "KB";
            else if (GBSize > size) return Math.Round(size / MBSize, roundCount) + "MB";
            else if (TBSize > size) return Math.Round(size / GBSize, roundCount) + "GB";
            else return Math.Round(size / TBSize, roundCount) + "TB";
        }

        #endregion
    }

    #endregion
}
