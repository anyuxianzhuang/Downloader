using Downloader.Common;
using Downloader.Config;
using Downloader.Downloader;
using Downloader.Interface;
using Downloader.Model;
using Downloader.Task;

namespace Downloader
{
    public class TaskManager
    {
        public TaskManager()
        {
            Downloaders = new List<IDownloader>();
            NewCancellationToken();
        }
        public List<IDownloader> Downloaders { get; private set; }
        public int runingCount = 0;
        private int sleepTime = 1000;
        private int state = 0;
        private Task<int> stateCheckTask;
        CancellationTokenSource cancellationToken;
        public CancellationToken token = CancellationToken.None;
        public List<TaskDTO> dMFTaskDTOs
        {
            get
            {
                List<TaskDTO> _dMFTaskDTOs = new List<TaskDTO>();
                _dMFTaskDTOs.Clear();
                foreach (var downTask in Downloaders)
                    switch (downTask)
                    {
                        case DMFDownloader:
                            var dmfDown = (DMFDownloader)downTask;
                            var dmfTask = (DMFTask)dmfDown.task;
                            _dMFTaskDTOs.Add(new TaskDTO()
                            {
                                id = dmfDown.id,
                                cid = dmfTask.vid,
                                cover = dmfTask.cover,
                                downloadType = dmfTask.downloadType,
                                downloaderType = nameof(DMFDownloader),
                                stateDisplay = stateToDisplay(dmfDown.state),
                                state = dmfDown.state,
                                title = dmfTask.title
                            });
                            break;
                        case VodkaDownloader:
                            var vodDown = (VodkaDownloader)downTask;
                            var vodTask = (VodTask)vodDown.task;
                            _dMFTaskDTOs.Add(new TaskDTO()
                            {
                                id = vodDown.id,
                                cid = vodTask.vid,
                                cover = vodTask.cover,
                                downloadType = vodTask.downloadType,
                                downloaderType = nameof(VodkaDownloader),
                                stateDisplay = stateToDisplay(vodDown.state),
                                state = vodDown.state,
                                title = vodTask.title
                            });
                            break;
                        case VodkaConsoleDownloader:
                            var vodDown2 = (VodkaConsoleDownloader)downTask;
                            var vodTask2 = (VodTask)vodDown2.task;
                            _dMFTaskDTOs.Add(new TaskDTO()
                            {
                                id = vodDown2.id,
                                cid = vodTask2.vid,
                                cover = vodTask2.cover,
                                downloadType = vodTask2.downloadType,
                                downloaderType = nameof(VodkaConsoleDownloader),
                                stateDisplay = stateToDisplay(vodDown2.state),
                                state = vodDown2.state,
                                title = vodTask2.title
                            });
                            break;
                        default:
                            break;
                    }

                return _dMFTaskDTOs;
            }
        }
        private string stateToDisplay(int state)
        {
            if (state == -1)
                return "下载错误";
            else if (state == 0)
                return "等待下载";
            else if (state == 1)
                return "下载中";
            else if (state == 2)
                return "下载完成";
            return "未知错误";
        }
        private void NewCancellationToken()
        {
            if (cancellationToken == null || cancellationToken.IsCancellationRequested)
            {
                cancellationToken = new CancellationTokenSource();
                token = cancellationToken.Token;
                token.Register(Cancel);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="downloader"></param>
        /// <returns></returns>
        public void Add(IDownloader downloader)
        {
            if (Downloaders == null)
                return;
            Downloaders.Add(downloader);
        }

        public void Delete(IDownloader downloader)
        {
            for (int i = Downloaders.Count - 1; i >= 0; i--)
            {
                var iDownload = Downloaders[i];
                if (iDownload != null && iDownload == downloader && iDownload.state != 1)
                    Downloaders.RemoveAt(i);
            }
        }
        public bool Contains(IDownloader downloader)
        {
            return Downloaders.Contains(downloader);
        }
        public List<IDownloader> DTOToDownloader(List<TaskDTO> dMFTaskDTOs)
        {
            List<IDownloader> dMFDownloaders = new List<IDownloader>();
            if (dMFTaskDTOs != null)
                for (int i = 0; i < dMFTaskDTOs.Count; i++)
                {
                    var dMFTaskDTO = dMFTaskDTOs[i];
                    var selectDown = Downloaders.FirstOrDefault(k => k.id == dMFTaskDTO.id);
                    if (selectDown != null)
                        dMFDownloaders.Add(selectDown);
                }
            return dMFDownloaders;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="downloaders"></param>
        /// <param name="mode">1 按照指定并行数全部运行 2 任意数量运行</param>
        /// <returns></returns>
        public Task<int> Start(List<IDownloader> downloaders, int mode)
        {
            NewCancellationToken();
            if (stateCheckTask == null || stateCheckTask.Status == TaskStatus.RanToCompletion)
            {
                stateCheckTask = new Task<int>(() =>
                {
                    state = 0;
                    if (Downloaders != null)
                    {
                        do
                        {
                            runingCount = Downloaders.Where(i => i.state == 1).Count();
                            for (int m = 0; m < Downloaders.Count; m++)
                            {
                                if (token.IsCancellationRequested)
                                {
                                    state = 0;
                                    return state;
                                }
                                IDownloader t = Downloaders[m];
                                if (t == null)
                                    continue;
                                if (t.state != 0)
                                    continue;
                                if (mode == 1 && runingCount < GUIConfig.taskParallelCount)
                                {
                                    t.Start(token);
                                    Interlocked.Increment(ref runingCount);
                                }
                            }
                            Thread.Sleep(sleepTime);
                        } while (runingCount != 0);
                        if (token.IsCancellationRequested)
                            state = 0;
                        else
                            state = 1;
                    }
                    return state;
                }, token);
                stateCheckTask.Start();
            }

            if (Downloaders != null)
                runingCount = Downloaders.Where(i => i.state == 1).Count();

            if (downloaders != null)
            {
                for (int m = 0; m < downloaders.Count; m++)
                {
                    if (token.IsCancellationRequested)
                        break;
                    IDownloader t = downloaders[m];
                    if (t == null)
                        continue;
                    if (t.state == 1)
                        continue;
                    if (t.state == 2)
                        continue;
                    else
                    {
                        if (mode == 1 && runingCount >= GUIConfig.taskParallelCount)
                            continue;
                        else
                        {
                            t.Start(token);
                            Interlocked.Increment(ref runingCount);
                        }
                    }
                }
            }
            return stateCheckTask;
        }
        public Task<int> StartAll()
        {
            return Start(Downloaders, 1);
        }
        public void Stop(List<IDownloader> downloaders)
        {
            if (downloaders != null)
                foreach (IDownloader downloader in downloaders)
                    downloader.Cancel();
        }
        public void StopAll()
        {
            if (cancellationToken == null)
                return;
            if (!cancellationToken.IsCancellationRequested)
                cancellationToken.Cancel();
            cancellationToken.Dispose();
        }
        private void Cancel()
        {
            StopAll();
            GC.SuppressFinalize(this);
        }
    }
}
