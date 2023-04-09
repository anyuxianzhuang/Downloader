using Downloader.Config;
using Downloader.Interface;
using Downloader.Task;

namespace Downloader.Downloader
{
    public class DMFDownloader : AbstractDownloader
    {
        public DMFDownloader(IDownloaderConfig config, ITask task) : base(config, task, new DMF_Wrapper((DMFConfig)config))
        {
        }
    }
}
