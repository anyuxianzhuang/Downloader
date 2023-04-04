using Downloader.Common;
using Downloader.Config;
using System.Diagnostics;

namespace Downloader.Downloader
{
    public class DMF_Wrapper
    {
        public DMF_Wrapper(IConfig Config)
        {
            config = Config;
            if (!config.DependencyConfig())
                throw new Exception("配置有误");
        }
        private IConfig config;
        private List<Process> processes = new List<Process>();
        public int Login_ikoa(string username, string password)
        {
            Loger.Debug($"{nameof(DMF_Wrapper)}.{nameof(Login_ikoa)} {username} {password}");
            ProcessStartInfo process = new ProcessStartInfo();
            process.UseShellExecute = false;
            process.RedirectStandardOutput = true;
            process.WorkingDirectory = config.exePath;
            process.CreateNoWindow = true;
            process.FileName = config.GetExeFilePath();
            process.Arguments = $"--login_ikoa --username {username} --password {password} ";
            Loger.Debug($"{process.WorkingDirectory} {process.FileName} ");
            Process? p = Process.Start(process);
            processes.Add(p);

            var line = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            Loger.Debug($"{nameof(DMF_Wrapper)}.{nameof(Login_ikoa)} result {line}");
            Loger.Debug($"{nameof(DMF_Wrapper)}.{nameof(Login_ikoa)} exitcode=" + p.ExitCode + " HasExited=" + p.HasExited);
            if (line.IndexOf("登录成功") >= 0)
                return 0;
            return 1;
        }

        public int Download(string type, string cid)
        {
            Loger.Debug($"{nameof(DMF_Wrapper)}.{nameof(Download)} {type} {cid}");
            ProcessStartInfo process = new ProcessStartInfo();
            process.UseShellExecute = false;
            process.RedirectStandardOutput = true;
            process.WorkingDirectory = config.exePath;
            process.CreateNoWindow = true;
            process.FileName = config.GetExeFilePath();
            process.Arguments = $"-w {type} -c {cid} ";
            Loger.Debug($"{process.WorkingDirectory} {process.FileName} {process.Arguments}");
            Process? p = Process.Start(process);
            processes.Add(p);

            var line = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            Loger.Debug($"{nameof(DMF_Wrapper)}.{nameof(Download)} result {line}");
            Loger.Debug($"{nameof(DMF_Wrapper)}.{nameof(Download)} exitcode=" + p.ExitCode + " HasExited=" + p.HasExited);
            if (line.IndexOf("文件移动成功") >= 0)
                return 0;
            if (line.IndexOf("下载成功") >= 0)
                return 0;
            return 1;
        }

        //private void P_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        //{
        //    Loger.Debug(e.Data);
        //}
        //private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        //{
        //    Loger.Debug(e.Data);
        //    progressChangeHandler?.Invoke(0);
        //}


        public delegate void progressChangeDelegate(float progress);
        public progressChangeDelegate progressChangeHandler;


        public void Dispose()
        {
            if (processes != null)
                foreach (var processe in processes)
                {
                    if (processe != null && !processe.HasExited)
                        processe.Kill(true);
                }
            GC.SuppressFinalize(this);
        }

    }
}
