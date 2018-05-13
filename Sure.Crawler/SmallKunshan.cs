using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Sure.Crawler.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sure.Crawler
{
    public partial class SmallKunshan : Form
    {
        public SmallKunshan()
        {
            InitializeComponent();
        }

        #region 属性

        /// <summary>
        /// 获取内容正则
        /// </summary>
        public const string regex = @"<img[^>]*{0}=([""'])?(?<{0}>[^'""]+)\1[^>]*>";
        public const string regexA = @"<a[^>]*{0}=([""'])?(?<{0}>[^'""]+)\1[^>]*>";

        /// <summary>
        /// 驾校地址 
        /// </summary>
        public const string urlCommon = "http://www.shxksjx.com/";

        /// <summary>
        /// 存储教练信息
        /// </summary>
        public static List<DetailedInfo> listDetailedInfo = new List<DetailedInfo>();

        /// <summary>
        /// 信号量
        /// </summary>
        public static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(5, 5);

        //Mongodb
        public static string serverHost = "mongodb://sure:HUANGsl@localhost/Sure_mongodbStudy";
        public static string databaseName = "Sure_mongodbStudy";
        public static string collectionName = "DetailedInfo";
        public static General.MongodbHelper<DetailedInfo> monodbHelper = new General.MongodbHelper<DetailedInfo>(serverHost, databaseName, collectionName);

        #endregion

        //抓取
        private void butGrab_Click(object sender, EventArgs e)
        {
            listDetailedInfo.Clear();
            if (GetDetailedInfo().Count != 0)
            {
                //相关操作
                BindListView(sender, e, GetDetailedInfo());
                return;
            }

            var _tasks = new Task[5];
            for (int i = 1; i <= 5; i++) { _tasks[i - 1] = Task.Factory.StartNew((num) => { GetDetail($"{textAddress.Text}?page={num}&"); }, i); }
            var finalTask = Task.Factory.ContinueWhenAll(_tasks, (tasks) =>
            {
                Task.WaitAll(_tasks);
                //插入
                InsertDetailedInfo(listDetailedInfo);
                //相关操作
                BindListView(sender, e, listDetailedInfo);
            });
            try { finalTask.Wait(); }
            catch (Exception ex)
            {
                MessageBox.Show($"butGrab_Click -- 数据抓取出错:\n{ex.Message}", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { semaphoreSlim.Dispose(); }
        }

        //筛选
        private void butQuery_Click(object sender, EventArgs e)
        {
            imageList.Images.Clear();
            listView.Clear();
            var listDetailedInfos = string.IsNullOrEmpty(textName.Text.Trim()) ? GetDetailedInfo() : GetDetailedInfo().Where(i => i.Name.StartsWith(textName.Text)).ToList<DetailedInfo>();
            foreach (DetailedInfo model in listDetailedInfos)
            {
                imageList.Images.Add(model.Name, Image.FromStream(WebRequest.Create(model.ImgAddress).GetResponse().GetResponseStream()));
            }
            BindListView(sender, e, listDetailedInfos);
        }

        //加载
        private void SmallKunshan_Load(object sender, EventArgs e)
        {
            textAddress.Text = $"http://www.shxksjx.com/dianping.asp";

            new Thread(() =>
            {
                foreach (var model in GetDetailedInfo())
                {
                    try
                    {
                        imageList.Images.Add(model.Name, Image.FromStream(WebRequest.Create(model.ImgAddress).GetResponse().GetResponseStream()));
                        Thread.Sleep(500);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }).Start();



        }

        #region 私有方法

        /// <summary>
        /// 获取教练信息
        /// </summary>
        /// <param name="urlAddress">爬取地址</param>
        private static void GetDetail(string urlAddress)
        {
            try
            {
                string content = HTTPGeneral.HTTPCrawler(urlAddress, "GET");
                //UL
                var regexULValue = new Regex("(?i)<ul[^>]+class[=\"\'\\s]+list[\"\']?[^>]*>(?:(?!<\\/ul>)[\\s\\S])+<\\/ul>").Match(content);
                //LI
                var regexLIValue = new Regex("(?i)<li[^>]*>(?:(?!<\\/li>)[\\s\\S])+<\\/li>").Matches(regexULValue.Value);
                for (int i = 0; i < regexLIValue.Count; i++)
                {
                    var _commentAddress = $"{urlCommon}{Regex.Match(regexLIValue[i].Value, string.Format(regexA, "href"), RegexOptions.IgnoreCase).Groups["href"].Value}";
                    var _imgAddress = $"{urlCommon}{Regex.Match(regexLIValue[i].Value, string.Format(regex, "src"), RegexOptions.IgnoreCase).Groups["src"].Value}";
                    var _name = Regex.Match(regexLIValue[i].Value, string.Format(regex, "alt"), RegexOptions.IgnoreCase).Groups["alt"].Value;

                    //组织数据
                    listDetailedInfo.Add(new DetailedInfo()
                    {
                        Index = i + 1,
                        Name = _name,
                        CommentAddress = _commentAddress,
                        ImgAddress = _imgAddress
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 绑定ListView列表
        /// </summary>
        /// <param name="listDetailInfo">数据集合</param>
        private void BindListView(object sender, EventArgs e, List<DetailedInfo> listDetailInfo)
        {
            try
            {
                if (imageList.Images.Count <= 0)
                {
                    foreach (var model in listDetailedInfo)
                    {
                        imageList.Images.Add(model.Name, Image.FromStream(WebRequest.Create(model.ImgAddress).GetResponse().GetResponseStream()));
                    }
                }

                ListView.CheckForIllegalCrossThreadCalls = false;
                listView.View = View.LargeIcon;
                listView.LargeImageList = imageList;
                int index = 0;
                foreach (DetailedInfo model in listDetailInfo)
                {
                    listView.Items.Add(model.Name);
                    listView.Items[index].ImageIndex = index;
                    index++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"BindListView -- 绑定列表出错:\n{ex.Message}", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Mongodb 查询数据
        /// </summary>
        /// <returns>集合</returns>
        public List<DetailedInfo> GetDetailedInfo()
        {
            int pageCount = 0;
            Expression<Func<DetailedInfo, bool>> func = (t) => t.Index != 0;
            Func<DetailedInfo, int> orderby = (t) => t.Index;
            IEnumerable<DetailedInfo> result = monodbHelper.FindAll<DetailedInfo, int>(out pageCount, func, orderby);
            return result.ToList<DetailedInfo>();
        }

        /// <summary>
        /// 插入数据到 Mongodb
        /// </summary>
        /// <param name="listDetailedInfo">数据源</param>
        public void InsertDetailedInfo(List<DetailedInfo> listDetailedInfo)
        {
            monodbHelper.InsertBatch(listDetailedInfo);
        }

        #endregion

        #region 内容类

        /// <summary>
        /// 内容Info
        /// </summary>
        public class DetailedInfo
        {
            [BsonRepresentation(BsonType.ObjectId)]
            public string id { set; get; }

            /// <summary>
            /// Id
            /// </summary>
            public int Index { get; set; }

            /// <summary>
            /// 名称
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 图片地址
            /// </summary>
            public string ImgAddress { get; set; }

            /// <summary>
            /// 图片流
            /// </summary>
            //public Stream ImgStream { get; set; }

            /// <summary>
            /// 点评地址
            /// </summary>
            public string CommentAddress { get; set; }
        }

        #endregion

        private void 查看点评ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = this.listView.SelectedItems[0].Text;
            var model = GetDetailedInfo().Where(i => i.Name.Equals(name)).FirstOrDefault();
            string chromePath = @"G:\Software Installation\Chrome\Google\Chrome\Application\chrome.exe";
            System.Diagnostics.Process.Start(chromePath, model.CommentAddress);
        }
    }
}
