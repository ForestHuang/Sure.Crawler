using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Sure.Crawler.General
{
    /// <summary>
    /// 多线程下载文件
    /// </summary>
    public class DownLoadFileGeneral
    {
        /// <summary>
        /// 线程数
        /// </summary>
        public int ThreadNum = 3;

        /// <summary>
        /// 线程集合（下载队列）
        /// </summary>
        private List<Thread> listThread = new List<Thread>();

        /// <summary>
        /// 委托
        /// </summary>
        public delegate void delegateSendMsg(DownMsg downMsg);

        /// <summary>
        /// 事件
        /// </summary>
        public event delegateSendMsg doSendMsg;

        /// <summary>
        /// Log4net
        /// </summary>
        private static string log4netPath = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")) + "\\App_Data\\log4net\\log4net.config";

        /// <summary>
        /// 无参构造
        /// </summary>
        public DownLoadFileGeneral() { doSendMsg += DownLoadFileChange; }

        /// <summary>
        /// 情动线程下载
        /// </summary>
        private void DownLoadFileChange(DownMsg downMsg)
        {
            if (downMsg.Tag == DownStatus.Error || downMsg.Tag == DownStatus.End)
            {
                StartDown(ThreadNum);
            }
        }

        /// <summary>
        /// 添加到下载队列
        /// </summary>
        /// <param name="DownUrl">下载路径</param>
        /// <param name="Dir">下载路径</param>
        /// <param name="Id">ID</param>
        /// <param name="FileName">文件名</param>
        public void AddDown(string DownUrl, string Dir, int Id = 0, string FileName = "")
        {
            Thread thread = new Thread(() => { Download(DownUrl, Dir, FileName, Id); });
            listThread.Add(thread);
        }

        /// <summary>
        /// 启动线程开始下载
        /// </summary>
        /// <param name="StartNum">线程数</param>
        public void StartDown(int StartNum)
        {
            for (int i2 = 0; i2 < StartNum; i2++)
            {
                lock (listThread)
                {
                    for (int i = 0; i < listThread.Count; i++)
                    {
                        if (listThread[i].ThreadState == System.Threading.ThreadState.Unstarted || listThread[i].ThreadState == ThreadState.Suspended)
                        {
                            listThread[i].Start();
                            break;
                        }
                    }
                }
            }
        }

        private void Download(string path, string dir, string filename, int id = 0)
        {
            try
            {
                DownMsg downMsg = new DownMsg();
                downMsg.Id = id;
                downMsg.Tag = 0;
                doSendMsg(downMsg);

                FileDownloader loader = new FileDownloader(path, dir, filename, ThreadNum);
                loader.data.Clear();
                downMsg.Tag = DownStatus.Start;
                downMsg.Length = (int)loader.getFileSize(); ;
                doSendMsg(downMsg);

                DownloadProgressListener linstenter = new DownloadProgressListener(downMsg);
                linstenter.doSendMsg = new DownloadProgressListener.dlgSendMsg(doSendMsg);
                loader.download(linstenter);
            }
            catch (Exception ex)
            {
                Log4net.log4netCreate(typeof(DownLoadFileGeneral), log4netPath).Error("错误信息: " + ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

    }

}
