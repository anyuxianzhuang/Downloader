using Downloader.Config;
using Downloader.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Downloader
{
    public class VodkaConsoleDownloader: AbstractDownloader
    {
        public VodkaConsoleDownloader(IDownloaderConfig config, ITask task) : base(config, task, new VodkaConsole_Wrapper((VodkaConfig)config))
        {
        }
    }
}
