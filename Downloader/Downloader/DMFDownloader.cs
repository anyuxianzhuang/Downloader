using Downloader.Common;
using Downloader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Downloader.Downloader
{
    public class DMFDownloader : IDownloader
    {
        public DMFDownloader(DMFTask dMFTask)
        {
            dmfTask = dMFTask;
            dMF_Wrapper = new DMF_Wrapper(Config.GUIConfig._DMFConfig);
        }
        public delegate void taskStateChangeDelegate(DMFDownloader progress);
        public taskStateChangeDelegate taskStateChangeHandler;
        private CancellationTokenSource cancellationToken;
        private DMF_Wrapper dMF_Wrapper;
        private CancellationToken tokenParallel = CancellationToken.None;
        public Guid id { get; private set; } = Guid.NewGuid();
        public DMFTask dmfTask { get; private set; }
        public float progress { get; private set; }
        /// <summary>
        /// -1 下载失败 0 初始化 1 下载中 2 下载完成
        /// </summary>
        public int state { get; private set; } = 0;

        public Task<bool> task { get; private set; }

        private void TaskStateChange(int State)
        {
            this.state = State;
            taskStateChangeHandler?.Invoke(this);
        }
        private void InitDownloadTask()
        {
            if (task == null || task.Status == TaskStatus.RanToCompletion)
            {
                task = new Task<bool>(() =>
                {
                    TaskStateChange(1);

                    dMF_Wrapper.progressChangeHandler += (progress) =>
                    {
                        this.progress = progress;
                    };
                    int downState = dMF_Wrapper.Download(dmfTask.downloadType, dmfTask.cid);
                    if (downState != 0)
                    {
                        TaskStateChange(0);
                        return false;
                    }
                    TaskStateChange(2);
                    return true;
                });
            }

        }
        public void Start(CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;

            if (state == 2)
                return;

            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(token);
            tokenParallel = cancellationToken.Token;
            tokenParallel.Register(Cancel);

            InitDownloadTask();

            if (task != null && task.Status == TaskStatus.Created)
                task.Start();
        }

        public void Cancel()
        {
            if (cancellationToken != null)
            {
                if (!cancellationToken.IsCancellationRequested)
                    cancellationToken.Cancel();
                dMF_Wrapper.Dispose();
                cancellationToken.Dispose();

                TaskStateChange(0);
            }
        }
    }
}
