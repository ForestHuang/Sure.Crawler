using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sure.Crawler.Model
{
    public class FileInfo
    {
        /// <summary>
        /// 文件ID
        /// </summary>
        public string FileID { set; get; }

        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { set; get; }

        /// <summary>
        /// 文件URL
        /// </summary>
        public string FileUrl { set; get; }

        /// <summary>
        /// 文件下载路径
        /// </summary>
        public string DownPath { set; get; }

        /// <summary>
        /// 文件总大小
        /// </summary>
        public string FileSize { set; get; }

        /// <summary>
        /// 文件下载速度
        /// </summary>
        public string SynSpeed { set; get; }

        /// <summary>
        /// 文件状态
        /// </summary>
        public string Tag { set; get; }

        /// <summary>
        /// 文件下载进度
        /// </summary>
        public string SynProgress { set; get; }

        /// <summary>
        /// 是否异步下载
        /// </summary>
        public bool Async { set; get; }
    }
}
