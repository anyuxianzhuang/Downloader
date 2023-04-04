using Downloader.Common;
using Downloader.Config;
using Downloader.Downloader;
using Downloader.Model;
using Downloader.Model.ViewModel;
using System.Threading.Tasks;

namespace Downloader
{
    public class TaskManager
    {
        public TaskManager()
        {
            Downloaders = new List<DMFDownloader>();
            NewCancellationToken();
        }
        public List<DMFDownloader> Downloaders { get; private set; }
        public int runingCount = 0;
        private int sleepTime = 1000;
        private int state = 0;
        private Task<int> stateCheckTask;
        CancellationTokenSource cancellationToken;
        public CancellationToken token = CancellationToken.None;
        public List<DMFTaskDTO> dMFTaskDTOs
        {
            get
            {
                List<DMFTaskDTO> _dMFTaskDTOs = new List<DMFTaskDTO>();
                _dMFTaskDTOs.Clear();
                foreach (var downTask in Downloaders)
                    _dMFTaskDTOs.Add(new DMFTaskDTO()
                    {
                        id = downTask.id,
                        cid = downTask.dmfTask.cid,
                        cover = downTask.dmfTask.cover,
                        downloadType = downTask.dmfTask.downloadType,
                        stateDisplay = stateToDisplay(downTask.state),
                        state = downTask.state,
                        progress = downTask.progress,
                        title = downTask.dmfTask.title
                    });
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
        public void Add(DMFDownloader downloader)
        {
            if (Downloaders == null)
                return;
            Downloaders.Add(downloader);
        }

        public void Delete(DMFDownloader downloader)
        {
            for (int i = Downloaders.Count - 1; i >= 0; i--)
            {
                var iDownload = Downloaders[i];
                if (iDownload != null && iDownload == downloader && iDownload.state != 1)
                    Downloaders.RemoveAt(i);
            }
        }
        public bool Contains(DMFDownloader downloader)
        {
            return Downloaders.Contains(downloader);
        }
        public List<DMFDownloader> DTOToDownloader(List<DMFTaskDTO> dMFTaskDTOs)
        {
            List<DMFDownloader> dMFDownloaders = new List<DMFDownloader>();
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
        public Task<int> Start(List<DMFDownloader> downloaders, int mode)
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
                                DMFDownloader t = Downloaders[m];
                                if (t == null)
                                    continue;
                                if (mode == 1 && runingCount < GUIConfig.taskParallelCount)
                                {
                                    t.Start(token);
                                    runingCount++;
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
                    DMFDownloader t = downloaders[m];
                    if (t == null)
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
                            runingCount++;
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
        public void Stop(List<DMFDownloader> downloaders)
        {
            if (downloaders != null)
                foreach (DMFDownloader downloader in downloaders)
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
