using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Downloader.Interface;

namespace Downloader.Config
{
    public class DMFConfig : IDownloaderConfig
    {
        public DMFConfig()
        {
            retry = GUIConfig.retry;
        }
        public int retry { get; set; }
        public bool isLogin = false;
        public readonly string exeName = "iKOA_DMF_*.exe";
        public string DMFPath = string.Empty;
        public string DMFSavePath = string.Empty;
        public string DMFTempPath = string.Empty;
        public int DMFVideoThreading;
        public int DMFAudioThreading;
        public int DMFRetry;
        public string DMFServer;
        public List<string> DMFDownloadType;
        public bool enableStrict = false;
        public string exePath { get { return DMFPath; } }


        public string GetExeFilePath()
        {
            if (Directory.Exists(DMFPath))
            {
                var files = Directory.GetFiles(DMFPath, exeName);
                if (files.Length > 0)
                    return files[0];
            }
            return string.Empty;
        }
        public bool DependencyConfig()
        {
            if (string.IsNullOrEmpty(DMFPath))
                return false;
            if (!Directory.Exists(DMFPath))
                return false;
            var files = Directory.GetFiles(DMFPath, exeName);
            if (files.Length < 0)
                return false;
            return true;
        }

    }

}
