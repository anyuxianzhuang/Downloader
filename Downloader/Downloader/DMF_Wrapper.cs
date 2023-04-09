using Downloader.Common;
using Downloader.Config;
using Downloader.Interface;
using Downloader.Task;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Downloader.Downloader
{
    public class DMF_Wrapper : AbstractWrapper
    {
        public DMF_Wrapper(DMFConfig config) : base(config)
        {
            _config = config;
        }
        private DMFConfig _config;
        public int Login_ikoa(string username, string password)
        {
            if (base.Login_ikoa(username, password) != 0)
                return 2;

            var lua = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DMFLogin.lua");
            if (!File.Exists(lua))
            {
                Loger.Debug("DMFLogin.lua缺失");
                return 2;
            }

            Loger.Debug($"{nameof(DMF_Wrapper)}.{nameof(Login_ikoa)}");
            ProcessStartInfo process = new ProcessStartInfo();
            process.WorkingDirectory = config?.exePath;
            process.FileName = GUIConfig.luaExe;
            process.Arguments = $"{lua} {username} {password} {config?.GetExeFilePath()}";
            Loger.Debug($"{process.WorkingDirectory} {process.FileName}");
            Process? p = Process.Start(process);
            processes.Add(p);
            p.WaitForExit();
            Loger.Debug($"{nameof(DMF_Wrapper)}.{nameof(Login_ikoa)}");
            Loger.Debug($"{nameof(DMF_Wrapper)}.{nameof(Login_ikoa)} exitcode=" + p.ExitCode + " HasExited=" + p.HasExited);
            return p.ExitCode;
        }

        public override int Download(ITask task)
        {
            if (base.Download(task) != 0)
                return 2;

            if (_config == null)
                return 2;

            var lua = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DMFDown.lua");
            if (!File.Exists(lua))
            {
                Loger.Debug("DMFDown.lua缺失");
                return 2;
            }

            bool enableStrict = false;
            DMFTask dMFTask = task as DMFTask;
            if (dMFTask == null)
                return 2;


            Loger.Debug($"{nameof(DMF_Wrapper)}.{nameof(Download)} {dMFTask.vid} {dMFTask.downloadType}");
            ProcessStartInfo process = new ProcessStartInfo();
            process.WorkingDirectory = config?.exePath;
            process.FileName = GUIConfig.luaExe;
            process.Arguments = $"{lua} {dMFTask.downloadType} {dMFTask.vid} {(dMFTask.downloadType == "pdcv" && _config.enableStrict ? "1" : "0")} {config?.GetExeFilePath()}";
            Loger.Debug($"{process.WorkingDirectory} {process.FileName} {process.Arguments}");
            Process? p = Process.Start(process);
            processes.Add(p);
            p.WaitForExit();
            Loger.Debug($"{nameof(DMF_Wrapper)}.{nameof(Download)}");
            Loger.Debug($"{nameof(DMF_Wrapper)}.{nameof(Download)} exitcode=" + p.ExitCode + " HasExited=" + p.HasExited);
            return p.ExitCode;
        }

        //public delegate void progressChangeDelegate(float progress);
        //public progressChangeDelegate progressChangeHandler;
    }
}
