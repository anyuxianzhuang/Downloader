using Downloader.Config;
using Downloader.Interface;
using Downloader.Task;
using System.Threading.Tasks;

namespace Downloader.Downloader
{
    public class VodkaDownloader : AbstractDownloader
    {
        public VodkaDownloader(IDownloaderConfig config, ITask task) : base(config, task, new Vodka_Wrapper((VodkaConfig)config))
        {
        }
    }
}
