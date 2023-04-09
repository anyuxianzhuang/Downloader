using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Interface
{
    public interface IDownloader
    {
        /// <summary>
        /// -1 失败 0 初始化 1 下载中 2 下载完成
        /// </summary>
        int state { get; }
        Guid id { get; }
        void Start(CancellationToken token);
        void Cancel();
        bool Activate();
    }
}
