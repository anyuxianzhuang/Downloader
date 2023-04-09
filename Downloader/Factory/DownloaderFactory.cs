using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Downloader.Config;
using Downloader.Downloader;
using Downloader.Interface;
using Downloader.Task;

namespace Downloader.Factory
{
    public class DownloaderFactory
    {
        public DMFDownloader CreateDMFDownloader(IDownloaderConfig config, ITask task)
        {
            return new DMFDownloader(config, task);
        }
        public VodkaDownloader CreateVodkaDownloader(IDownloaderConfig config, ITask task)
        {
            return new VodkaDownloader(config, task);
        }

        public VodkaConsoleDownloader CreateVodkaConsoleDownloader(IDownloaderConfig config, ITask task)
        {
            return new VodkaConsoleDownloader(config, task);
        }
    }
}
