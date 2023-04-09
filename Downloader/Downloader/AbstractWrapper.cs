using Downloader.Common;
using Downloader.Config;
using Downloader.Interface;
using Downloader.Task;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Downloader.Downloader
{
    public abstract class AbstractWrapper : IWrapper
    {
        public AbstractWrapper(IDownloaderConfig config)
        {
            this.config = config;
        }
        public IDownloaderConfig config { get; set; }
        public List<Process> processes = new List<Process>();
        public void Close()
        {
            if (processes != null)
                for (int i = processes.Count - 1; i >= 0; i--)
                {
                    var processe = processes[i];
                    if (processe != null && !processe.HasExited)
                        processe.Kill(true);
                }
            GC.SuppressFinalize(this);
        }
        public virtual int Login_ikoa(string username, string password)
        {
            try
            {
                GUIConfig.ChackDependencyConfig();
            }
            catch (Exception ex)
            {
                Loger.Debug($"执行环境缺失 {ex.Message}");
                return 2;
            }
            if (config is DMFConfig)
                if (!config.DependencyConfig())
                {
                    Loger.Debug($"登录失败 DMF配置有误");
                    return 2;
                }
            if (config is VodkaConfig)
                if (!config.DependencyConfig())
                {
                    Loger.Debug($"登录失败 Vodka配置有误");
                    return 2;
                }
            return 0;

        }
        public virtual int Download(ITask task)
        {
            try
            {
                GUIConfig.ChackDependencyConfig();
            }
            catch (Exception ex)
            {
                Loger.Debug($"执行环境缺失 {ex.Message}");
                return 2;
            }
            if (config is DMFConfig)
                if (!config.DependencyConfig())
                {
                    Loger.Debug($"take [{task.vid}] DMF配置有误");
                    return 2;
                }
            if (config is VodkaConfig)
                if (!config.DependencyConfig())
                {
                    Loger.Debug($"take [{task.vid}] Vodka配置有误");
                    return 2;
                }
            return 0;
        }

        private const int SW_SHOWNORMAL = 1;

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr parentWindow, IntPtr previousChildWindow, string windowClass, string windowTitle);

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr window, out int process);

        private IntPtr[] GetProcessWindows(int process)
        {
            IntPtr[] apRet = (new IntPtr[256]);
            int iCount = 0;
            IntPtr pLast = IntPtr.Zero;
            do
            {
                pLast = FindWindowEx(IntPtr.Zero, pLast, null, null);
                int iProcess_;
                GetWindowThreadProcessId(pLast, out iProcess_);
                if (iProcess_ == process) apRet[iCount++] = pLast;
            } while (pLast != IntPtr.Zero);
            System.Array.Resize(ref apRet, iCount);
            return apRet;
        }
        public void SwitchToThisWindow()
        {
            if (processes != null)
                for (int i = processes.Count - 1; i >= 0; i--)
                {
                    var processe = processes[i];
                    var ptrs = GetProcessWindows(processe.Id);
                    foreach (var ptr in ptrs)
                    {
                        ShowWindow(ptr, SW_SHOWNORMAL);
                        SetForegroundWindow(ptr);
                    }
                }
        }

    }
}
