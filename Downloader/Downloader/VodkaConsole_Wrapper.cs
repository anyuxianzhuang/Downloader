using Downloader.Common;
using Downloader.Config;
using Downloader.Interface;
using Downloader.Task;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Downloader
{
    public class VodkaConsole_Wrapper: AbstractWrapper
    {
        public VodkaConsole_Wrapper(VodkaConfig config) : base(config)
        {
        }
        public int Login_ikoa(string username, string password)
        {
            if (base.Login_ikoa(username, password) != 0)
                return 2;

            Loger.Debug($"{nameof(VodkaConsole_Wrapper)}.{nameof(Login_ikoa)}");
            ProcessStartInfo process = new ProcessStartInfo();
            process.WorkingDirectory = config?.exePath;
            process.FileName = GUIConfig.luaExe;
            process.Arguments = $"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VodLogin.lua")} {username} {password} {config?.GetExeFilePath()}";
            Loger.Debug($"{process.WorkingDirectory} {process.FileName}");
            Process? p = Process.Start(process);
            processes.Add(p);
            p.WaitForExit();
            Loger.Debug($"{nameof(VodkaConsole_Wrapper)}.{nameof(Login_ikoa)} ");
            Loger.Debug($"{nameof(VodkaConsole_Wrapper)}.{nameof(Login_ikoa)} exitcode=" + p.ExitCode + " HasExited=" + p.HasExited);
            return p.ExitCode;
        }

        public override int Download(ITask task)
        {
            if (base.Download(task) != 0)
                return 2;

            VodTask? vodTask = task as VodTask;
            if (vodTask == null)
                return 2;

            Loger.Debug($"{nameof(VodkaConsole_Wrapper)}.{nameof(Download)} {vodTask.downloadType} {vodTask.downloadId} {vodTask.vid}");
            ProcessStartInfo process = new ProcessStartInfo();
            process.WorkingDirectory = config?.exePath;
            process.UseShellExecute = true;
            process.FileName = config?.GetExeFilePath();
            Loger.Debug($"{process.WorkingDirectory} {process.FileName} {process.Arguments}");
            Process? p = Process.Start(process);
            processes.Add(p);
            p.WaitForExit();
            Loger.Debug($"{nameof(VodkaConsole_Wrapper)}.{nameof(Download)} ");
            Loger.Debug($"{nameof(VodkaConsole_Wrapper)}.{nameof(Download)} exitcode=" + p.ExitCode + " HasExited=" + p.HasExited);
            return p.ExitCode;
        }
    }
}
