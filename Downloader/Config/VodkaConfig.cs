using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Downloader.Common;
using Downloader.Interface;

namespace Downloader.Config
{
    public class VodkaConfig : IDownloaderConfig
    {
        public VodkaConfig()
        {
            retry = GUIConfig.retry;
        }
        public int retry { get; set; }
        public bool isLogin = false;
        public readonly string exeName = "iKOA_Vodka*.exe";
        public string exePath { get { return VodkaPath; } }
        public string VodkaPath = string.Empty;
        public string savePath = string.Empty;
        public string movePath = string.Empty;
        public string saveType = string.Empty;
        public readonly List<string> saveTypes = new List<string>() { "cid", "pid" };
        public readonly string mergeType = "mp4";
        private readonly List<string> mergeTypes = new List<string>() { "mp4", "ts" };
        public List<string> VodDownloadType = null;
        public bool autoDownAll = true;
        public int cdTime { get; } = 5;
        public bool eorrDelLoginState { get; } = false;
        public bool downCover = false;
        public bool delTempFile = true;
        public string configVer { get; private set; } = "3.1";

        public bool isMerge2D = true;
        public int parallel2DCount = 8;

        public bool isMerge4K = true;
        public int parallel4KCount = 8;

        public bool isMergeVR = true;
        public int parallelVRCount = 8;
        public bool DependencyConfig()
        {
            if (string.IsNullOrEmpty(VodkaPath))
                return false;
            if (!Directory.Exists(VodkaPath))
                return false;
            var files = Directory.GetFiles(VodkaPath, exeName);
            if (files.Length < 0)
                return false;
            return true;
        }
        public string GetExeFilePath()
        {
            if (Directory.Exists(VodkaPath))
            {
                var files = Directory.GetFiles(VodkaPath, exeName);
                if (files.Length > 0)
                    return files[0];
            }
            return string.Empty;
        }

    }
}
