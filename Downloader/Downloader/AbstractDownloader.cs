using Downloader.Common;
using Downloader.Config;
using Downloader.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Downloader.Downloader
{
    public abstract class AbstractDownloader : IDownloader
    {
        public AbstractDownloader(IDownloaderConfig config, ITask task, IWrapper wrapper)
        {
            this.task = task;
            this.config = config;
            if (config != null)
                retry = config.retry;
            this.wrapper = wrapper;
        }
        public delegate void taskStateChangeDelegate(IDownloader progress);
        public taskStateChangeDelegate taskStateChangeHandler;
        private CancellationTokenSource cancellationToken;
        private IWrapper wrapper;
        private IDownloaderConfig config;
        public ITask task { get; private set; }
        public Task<bool> taskCycle { get; private set; }
        private CancellationToken tokenParallel = CancellationToken.None;
        public Guid id { get; private set; } = Guid.NewGuid();
        public int state { get; private set; } = 0;
        public int retry { get; private set; }
        public int retryTime = 5000;
        public bool Activate()
        {
            wrapper.SwitchToThisWindow();
            return true;
        }
        public void Cancel()
        {
            if (cancellationToken != null)
            {
                if (!cancellationToken.IsCancellationRequested)
                    cancellationToken.Cancel();
                wrapper?.Close();
                cancellationToken.Dispose();
                TaskStateChange(0);
            }
        }
        private void TaskStateChange(int State)
        {
            this.state = State;
            switch (this.state)
            {
                case 0:
                    Loger.Info($"Task [{task.vid}] 等待下载");
                    break;
                case 1:
                    Loger.Info($"Task [{task.vid}] 正在下载");
                    break;
                case 2:
                    Loger.Info($"Task [{task.vid}] 下载成功");
                    break;
                case -1:
                    Loger.Info($"Task [{task.vid}] 下载错误");
                    break;
                default:
                    break;
            }
            taskStateChangeHandler?.Invoke(this);
        }
        public void Start(CancellationToken token)
        {
            lock (this)
            {
                if (token.IsCancellationRequested)
                    return;

                if (state == 2)
                    return;

                cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(token);
                tokenParallel = cancellationToken.Token;
                tokenParallel.Register(Cancel);

                InitDownloadTask();

                if (taskCycle != null && taskCycle.Status == TaskStatus.Created)
                    taskCycle.Start();
            }
        }

        private void InitDownloadTask()
        {
            if (taskCycle == null || taskCycle.Status == TaskStatus.RanToCompletion)
            {
                taskCycle = new Task<bool>(() =>
                {
                    TaskStateChange(1);
                    int retryCount = 0;
                    int? downState = 2;
                    do
                    {
                        if (tokenParallel.IsCancellationRequested)
                        {
                            TaskStateChange(0);
                            return false;
                        }
                        if (retry != -1)
                            if (retryCount > retry)
                                break;
                        downState = wrapper?.Download(task);
                        if (downState == null)
                            downState = 2;
                        if (downState != 0)
                        {
                            if (downState == 2 || retry == 0)
                            {
                                TaskStateChange(-1);
                                return false;
                            }
                            Loger.Info($"Task [{task.vid}] 正在重试");
                            retryCount++;
                        }
                        Thread.Sleep(retryTime);

                    } while (downState != 0);
                    if (downState != 0)
                    {
                        TaskStateChange(-1);
                        return false;
                    }
                    TaskStateChange(2);
                    return true;
                });
            }
        }
    }
}
