using Downloader.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Config
{
    public class GUIConfig
    {
        public static void ConfigInit()
        {
            _DMFConfig = new DMFConfig();
            IniEx iniEx = new IniEx(configPath);
            _DMFConfig.DMFPath = iniEx.ReadContentValue("DMFConfig", "DMFPath");
            _DMFConfig.DMFSavePath = iniEx.ReadContentValue("DMFConfig", "DMFSavePath");
            _DMFConfig.DMFTempPath = iniEx.ReadContentValue("DMFConfig", "DMFTempPath");

            _DMFConfig.DMFVideoThreading = IntParse(iniEx.ReadContentValue("DMFConfig", "DMFVideoThreading"), 8);
            _DMFConfig.DMFAudioThreading = IntParse(iniEx.ReadContentValue("DMFConfig", "DMFAudioThreading"), 16);
            _DMFConfig.DMFRetry = IntParse(iniEx.ReadContentValue("DMFConfig", "DMFRetry"), 99);
            _DMFConfig.DMFServer = iniEx.ReadContentValue("DMFConfig", "DMFServer");
            if (string.IsNullOrWhiteSpace(_DMFConfig.DMFServer))
                _DMFConfig.DMFServer = "202.182.123.115";

            var dmfDownloadType = iniEx.ReadContentValue("DMFConfig", "DMFDownloadType");
            if (!string.IsNullOrEmpty(dmfDownloadType))
                _DMFConfig.DMFDownloadType = dmfDownloadType.Split(new string[] { SplitStr }, StringSplitOptions.RemoveEmptyEntries).ToList();
            else
                _DMFConfig.DMFDownloadType = new List<string>() { "dmmtv", "mgs", "pdcf", "pdcv" };

            try
            {
                proxyHost = new Uri(iniEx.ReadContentValue("proxyConfig", "host"));
            }
            catch (Exception)
            {
            }
            proxyEnable = iniEx.ReadContentValue("proxyConfig", "enable") == "1" ? true : false;

            taskParallelCount = IntParse(iniEx.ReadContentValue("taskConfig", "taskParallelCount"), 8);
            autoTaskSize = iniEx.ReadContentValue("taskConfig", "autoTaskSize") == "1" ? true : false;
            isLogin = iniEx.ReadContentValue("taskConfig", "isLogin") == "1" ? true : false;

            version = iniEx.ReadContentValue("sysConfig", "version");
        }
        private static int IntParse(string str, int expectValue)
        {
            int result = expectValue;
            if (!int.TryParse(str, out result))
                result = expectValue;
            return result;
        }
        public static void Save()
        {
            IniEx iniEx = new IniEx(configPath);
            iniEx.WriteContentValue("DMFConfig", "DMFPath", _DMFConfig.DMFPath);
            iniEx.WriteContentValue("DMFConfig", "DMFSavePath", _DMFConfig.DMFSavePath);
            iniEx.WriteContentValue("DMFConfig", "DMFTempPath", _DMFConfig.DMFTempPath);
            iniEx.WriteContentValue("DMFConfig", "DMFVideoThreading", _DMFConfig.DMFVideoThreading.ToString());
            iniEx.WriteContentValue("DMFConfig", "DMFAudioThreading", _DMFConfig.DMFAudioThreading.ToString());
            iniEx.WriteContentValue("DMFConfig", "DMFRetry", _DMFConfig.DMFRetry.ToString());
            iniEx.WriteContentValue("DMFConfig", "DMFServer", _DMFConfig.DMFServer);
            iniEx.WriteContentValue("DMFConfig", "DMFDownloadType", _DMFConfig.DMFDownloadType != null ? string.Join(SplitStr, _DMFConfig.DMFDownloadType.ToArray()) : "");

            iniEx.WriteContentValue("proxyConfig", "host", proxyHost.Host);
            iniEx.WriteContentValue("proxyConfig", "enable", proxyEnable ? "1" : "0");

            iniEx.WriteContentValue("taskConfig", "taskParallelCount", taskParallelCount.ToString());
            iniEx.WriteContentValue("taskConfig", "autoTaskSize", autoTaskSize ? "1" : "0");
            iniEx.WriteContentValue("taskConfig", "isLogin", isLogin ? "1" : "0");
        }

        public static DMFConfig _DMFConfig = null;
        private static readonly string SplitStr = ",";
        private static string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");
        public static bool isLogin = false;

        public static Uri proxyHost = new Uri("http://127.0.0.1:10809");
        public static bool proxyEnable = false;

        public static int taskParallelCount = 8;
        public static bool autoTaskSize = false;

        public static string version = "1.1.2023040420";
    }
}
