using System;
using System.Collections.Generic;
using System.Text;

namespace Sure.Crawler.General
{
   public  interface  IDownloadProgressListener
    {
         void OnDownloadSize(long size);
    }
}
