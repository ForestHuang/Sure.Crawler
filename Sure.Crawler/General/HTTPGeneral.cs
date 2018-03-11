namespace Sure.Crawler.General
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    /*---------------------------------------------------------------------
    [author]:senlin.huang
    [time]:2018-1-25
    [explain]: HTTPGeneral
    -----------------------------------------------------------------------*/
    public class HTTPGeneral
    {
        /// <summary>
        /// HTTPCrawler 爬取网页源码
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="method">请求方式</param>
        /// <returns>网页数据信息</returns>
        public static string HTTPCrawler(string url, string method)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Timeout = 20 * 1000;
                httpWebRequest.AllowAutoRedirect = true;
                httpWebRequest.UserAgent = "Mozilla/5.0 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)";
                httpWebRequest.Method = method;
                httpWebRequest.KeepAlive = true;
                HttpWebResponse Response = (HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader streamReader = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("GB18030")))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// HTTPDownloadFile 下载文件
        /// </summary>
        /// <param name="fileUrl">文件路径</param>
        /// <param name="downPath">存储路径</param>
        /// <param name="fileName">文件名</param>
        public static void HTTPDownloadFile(string fileUrl, string downPath, string fileName)
        {
            try
            {
                if (!Directory.Exists(downPath))
                    Directory.CreateDirectory(downPath);
                WebClient webClient = new WebClient();
                webClient.DownloadFile(fileUrl, downPath + fileName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
