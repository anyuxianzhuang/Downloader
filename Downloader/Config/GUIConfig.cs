using Downloader.Common;
using Downloader.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Downloader.Config
{
    public class GUIConfig
    {
        public static void ConfigInit()
        {
            _DMFConfig = new DMFConfig();
            _VodkaConfig = new VodkaConfig();

            IniEx iniEx = new IniEx(configPath);

            saveFilePath = iniEx.ReadContentValue("CommonConfig", "saveFilePath");

            _DMFConfig.DMFPath = iniEx.ReadContentValue("DMFConfig", "DMFPath");
            _DMFConfig.DMFSavePath = iniEx.ReadContentValue("DMFConfig", "DMFSavePath");
            _DMFConfig.DMFTempPath = iniEx.ReadContentValue("DMFConfig", "DMFTempPath");

            _DMFConfig.DMFVideoThreading = IntParse(iniEx.ReadContentValue("DMFConfig", "DMFVideoThreading"), 8);
            _DMFConfig.DMFAudioThreading = IntParse(iniEx.ReadContentValue("DMFConfig", "DMFAudioThreading"), 16);
            _DMFConfig.DMFRetry = IntParse(iniEx.ReadContentValue("DMFConfig", "DMFRetry"), 99);
            _DMFConfig.DMFServer = iniEx.ReadContentValue("DMFConfig", "DMFServer");
            if (string.IsNullOrWhiteSpace(_DMFConfig.DMFServer))
                _DMFConfig.DMFServer = "202.182.123.115";

            //var dmfDownloadType = iniEx.ReadContentValue("DMFConfig", "DMFDownloadType");
            //if (!string.IsNullOrEmpty(dmfDownloadType))
            //    _DMFConfig.DMFDownloadType = dmfDownloadType.Split(new string[] { splitStr }, StringSplitOptions.RemoveEmptyEntries).ToList();
            //else
            _DMFConfig.DMFDownloadType = new List<string>() {/* "dmmtv",*/ "mgs", "pdcf", "4kvp9", "pdcv", "ikoa" };
            _DMFConfig.isLogin = iniEx.ReadContentValue("DMFConfig", "isLogin") == "1" ? true : false;
            _DMFConfig.enableStrict = iniEx.ReadContentValue("DMFConfig", "enableStrict") == "1" ? true : false;


            _VodkaConfig.VodkaPath = iniEx.ReadContentValue("VodConfig", "VodkaPath");
            _VodkaConfig.savePath = iniEx.ReadContentValue("VodConfig", "savePath");
            _VodkaConfig.movePath = iniEx.ReadContentValue("VodConfig", "movePath");
            _VodkaConfig.saveType = iniEx.ReadContentValue("VodConfig", "saveType");
            _VodkaConfig.autoDownAll = iniEx.ReadContentValue("VodConfig", "autoDownAll") == "1" ? true : false;
            _VodkaConfig.downCover = iniEx.ReadContentValue("VodConfig", "downCover") == "1" ? true : false;
            _VodkaConfig.delTempFile = iniEx.ReadContentValue("VodConfig", "delTempFile") == "1" ? true : false;
            _VodkaConfig.isMerge2D = iniEx.ReadContentValue("VodConfig", "isMerge2D") == "1" ? true : false;
            _VodkaConfig.parallel2DCount = IntParse(iniEx.ReadContentValue("VodConfig", "parallel2DCount"), 8);
            _VodkaConfig.isMerge4K = iniEx.ReadContentValue("VodConfig", "isMerge4K") == "1" ? true : false;
            _VodkaConfig.parallel4KCount = IntParse(iniEx.ReadContentValue("VodConfig", "parallel4KCount"), 8);
            _VodkaConfig.isMergeVR = iniEx.ReadContentValue("VodConfig", "isMergeVR") == "1" ? true : false;
            _VodkaConfig.parallelVRCount = IntParse(iniEx.ReadContentValue("VodConfig", "parallelVRCount"), 8);
            _VodkaConfig.isLogin = iniEx.ReadContentValue("VodConfig", "isLogin") == "1" ? true : false;

            var vodDownloadType = iniEx.ReadContentValue("DMFConfig", "VodDownloadType");
            if (!string.IsNullOrEmpty(vodDownloadType))
                _VodkaConfig.VodDownloadType = vodDownloadType.Split(new string[] { splitStr }, StringSplitOptions.RemoveEmptyEntries).ToList();
            else
                _VodkaConfig.VodDownloadType = new List<string>() { "2d", "4k", "4k2d", "vr", "vr2" };


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

            retry = IntParse(iniEx.ReadContentValue("taskConfig", "retry"), 0);
            _VodkaConfig.retry = retry;
            _DMFConfig.retry = retry;
        }
        private static int IntParse(string str, int expectValue)
        {
            int result = expectValue;
            if (!int.TryParse(str, out result))
                result = expectValue;
            return result;
        }
        public static void ChackDependencyConfig()
        {
            if (!File.Exists(luaExe))
                throw new Exception("任务执行环境缺失");
        }
        public static void Save()
        {
            IniEx iniEx = new IniEx(configPath);

            iniEx.WriteContentValue("CommonConfig", "saveFilePath", saveFilePath);

            iniEx.WriteContentValue("DMFConfig", "DMFPath", _DMFConfig.DMFPath);
            iniEx.WriteContentValue("DMFConfig", "DMFSavePath", _DMFConfig.DMFSavePath);
            iniEx.WriteContentValue("DMFConfig", "DMFTempPath", _DMFConfig.DMFTempPath);
            iniEx.WriteContentValue("DMFConfig", "DMFVideoThreading", _DMFConfig.DMFVideoThreading.ToString());
            iniEx.WriteContentValue("DMFConfig", "DMFAudioThreading", _DMFConfig.DMFAudioThreading.ToString());
            iniEx.WriteContentValue("DMFConfig", "DMFRetry", _DMFConfig.DMFRetry.ToString());
            iniEx.WriteContentValue("DMFConfig", "DMFServer", _DMFConfig.DMFServer);
            iniEx.WriteContentValue("DMFConfig", "DMFDownloadType", _DMFConfig.DMFDownloadType != null ? string.Join(splitStr, _DMFConfig.DMFDownloadType.ToArray()) : "");
            iniEx.WriteContentValue("DMFConfig", "isLogin", _DMFConfig.isLogin ? "1" : "0");
            iniEx.WriteContentValue("DMFConfig", "enableStrict", _DMFConfig.enableStrict ? "1" : "0");



            iniEx.WriteContentValue("VodConfig", "VodkaPath", _VodkaConfig.VodkaPath);
            iniEx.WriteContentValue("VodConfig", "savePath", _VodkaConfig.savePath);
            iniEx.WriteContentValue("VodConfig", "movePath", _VodkaConfig.movePath);
            iniEx.WriteContentValue("VodConfig", "saveType", _VodkaConfig.saveType);
            iniEx.WriteContentValue("VodConfig", "autoDownAll", _VodkaConfig.autoDownAll ? "1" : "0");
            iniEx.WriteContentValue("VodConfig", "downCover", _VodkaConfig.downCover ? "1" : "0");
            iniEx.WriteContentValue("VodConfig", "delTempFile", _VodkaConfig.delTempFile ? "1" : "0");
            iniEx.WriteContentValue("VodConfig", "isMerge2D", _VodkaConfig.isMerge2D ? "1" : "0");
            iniEx.WriteContentValue("VodConfig", "parallel2DCount", _VodkaConfig.parallel2DCount.ToString());
            iniEx.WriteContentValue("VodConfig", "isMerge4K", _VodkaConfig.isMerge4K ? "1" : "0");
            iniEx.WriteContentValue("VodConfig", "parallel4KCount", _VodkaConfig.parallel4KCount.ToString());
            iniEx.WriteContentValue("VodConfig", "isMergeVR", _VodkaConfig.isMergeVR ? "1" : "0");
            iniEx.WriteContentValue("VodConfig", "parallelVRCount", _VodkaConfig.parallelVRCount.ToString());
            iniEx.WriteContentValue("VodConfig", "VodDownloadType", _VodkaConfig.VodDownloadType != null ? string.Join(splitStr, _VodkaConfig.VodDownloadType.ToArray()) : "");
            iniEx.WriteContentValue("VodConfig", "isLogin", _VodkaConfig.isLogin ? "1" : "0");

            iniEx.WriteContentValue("proxyConfig", "host", proxyHost.AbsoluteUri);
            iniEx.WriteContentValue("proxyConfig", "enable", proxyEnable ? "1" : "0");

            iniEx.WriteContentValue("taskConfig", "taskParallelCount", taskParallelCount.ToString());
            iniEx.WriteContentValue("taskConfig", "autoTaskSize", autoTaskSize ? "1" : "0");
            iniEx.WriteContentValue("taskConfig", "retry", retry.ToString());

            SaveConfig();
        }

        private static void SaveConfig()
        {
            if (!string.IsNullOrWhiteSpace(_DMFConfig.DMFPath) && Directory.Exists(_DMFConfig.DMFPath))
            {
                string dmfConfigFile = Path.Combine(_DMFConfig.DMFPath, "config.json");
                string config = string.Empty;
                if (!File.Exists(dmfConfigFile))
                    File.Create(dmfConfigFile);
                else
                {
                    using (StreamReader sR2 = new StreamReader(dmfConfigFile, Encoding.UTF8))
                        config = sR2.ReadToEnd();
                }
                JObject keyValuePairs = new JObject();
                if (string.IsNullOrEmpty(config))
                {
                    keyValuePairs.Add("global", new JObject() { { "token", "" }, { "download_path", _DMFConfig.DMFSavePath }, { "temp_path", _DMFConfig.DMFTempPath } });
                    keyValuePairs.Add("connection", new JObject() { { "video_threading", _DMFConfig.DMFVideoThreading }, { "audio_threading", _DMFConfig.DMFAudioThreading }, { "retry", _DMFConfig.DMFRetry }, { "ip", _DMFConfig.DMFServer } });
                    keyValuePairs.Add("proxy", new JObject() { { "protocol", proxyHost.Scheme }, { "port", proxyHost.Port }, { "enable", proxyEnable ? "true" : "false" } });
                }
                else
                {
                    keyValuePairs = (JObject)JsonConvert.DeserializeObject(config);
                    if (keyValuePairs["global"] != null)
                    {
                        if (keyValuePairs["global"]["download_path"] != null)
                            keyValuePairs["global"]["download_path"] = _DMFConfig.DMFSavePath;
                        if (keyValuePairs["global"]["temp_path"] != null)
                            keyValuePairs["global"]["temp_path"] = _DMFConfig.DMFTempPath;
                    }

                    if (keyValuePairs["connection"] != null)
                    {
                        if (keyValuePairs["connection"]["video_threading"] != null)
                            keyValuePairs["connection"]["video_threading"] = _DMFConfig.DMFVideoThreading;
                        if (keyValuePairs["connection"]["audio_threading"] != null)
                            keyValuePairs["connection"]["audio_threading"] = _DMFConfig.DMFAudioThreading;
                        if (keyValuePairs["connection"]["retry"] != null)
                            keyValuePairs["connection"]["retry"] = _DMFConfig.DMFRetry;
                        if (keyValuePairs["connection"]["ip"] != null)
                            keyValuePairs["connection"]["ip"] = _DMFConfig.DMFServer;
                    }

                    if (keyValuePairs["proxy"] != null)
                    {
                        if (keyValuePairs["proxy"]["protocol"] != null)
                            keyValuePairs["proxy"]["protocol"] = proxyHost.Scheme;
                        if (keyValuePairs["proxy"]["port"] != null)
                            keyValuePairs["proxy"]["port"] = proxyHost.Port;
                        if (keyValuePairs["proxy"]["enable"] != null)
                            keyValuePairs["proxy"]["enable"] = proxyEnable ? true : false;
                    }
                }
                config = keyValuePairs.ToString();
                using (StreamWriter sW2 = new StreamWriter(dmfConfigFile, false, new UTF8Encoding(false)))
                    sW2.Write(config);
            }

            if (!string.IsNullOrWhiteSpace(_VodkaConfig.VodkaPath) && Directory.Exists(_VodkaConfig.VodkaPath))
            {
                string configFile = Path.Combine(_VodkaConfig.VodkaPath, "config.ini");
                string copyFile = Path.Combine(_VodkaConfig.VodkaPath, "configBack.ini");
                if (File.Exists(configFile))
                {
                    File.Move(configFile, copyFile, true);
                    File.Delete(configFile);
                }
                List<string> strings = new List<string>();
                strings.Add($"下载存放目录={_VodkaConfig.savePath}");
                strings.Add($"下载完成移动目录={_VodkaConfig.movePath}");
                strings.Add($"是否使用代理={(proxyEnable ? "是" : "否")}");
                strings.Add($"代理地址={proxyHost.ToString()}");
                strings.Add($"文件名保存方式={_VodkaConfig.saveType}");
                strings.Add($"文件合并类型保存方式={_VodkaConfig.mergeType}");
                strings.Add($"自动选择下载全部分片={(_VodkaConfig.autoDownAll ? "是" : "否")}");
                strings.Add($"下载失败冷却={_VodkaConfig.cdTime.ToString()}");
                strings.Add($"是否登录失败时删除自动登录状态={(_VodkaConfig.eorrDelLoginState ? "是" : "否")}");
                strings.Add($"是否下载封面图片={(_VodkaConfig.downCover ? "是" : "否")}");
                strings.Add($"是否删除临时文件目录={(_VodkaConfig.delTempFile ? "是" : "否")}");
                strings.Add($"配置文件版本={(_VodkaConfig.configVer)}");
                strings.Add($"[2D下载设置]");
                strings.Add($"是否合并多part={(_VodkaConfig.isMerge2D ? "是" : "否")}");
                strings.Add($"最大同时下载数={(_VodkaConfig.parallel2DCount.ToString())}");
                strings.Add($"[4K下载设置]");
                strings.Add($"是否合并多part={(_VodkaConfig.isMerge4K ? "是" : "否")}");
                strings.Add($"最大同时下载数={_VodkaConfig.parallel4KCount.ToString()}");
                strings.Add($"[VR下载设置]");
                strings.Add($"是否合并多part={(_VodkaConfig.isMergeVR ? "是" : "否")}");
                strings.Add($"最大同时下载数={_VodkaConfig.parallelVRCount.ToString()}");
                using (var fs = new FileStream(configFile, FileMode.Create, FileAccess.Write, FileShare.Write))
                {
                    StreamWriter streamWriter = new StreamWriter(fs);
                    foreach (var str in strings)
                        streamWriter.WriteLine(str);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }

        }


        public static VodkaConfig _VodkaConfig = null;
        public static DMFConfig _DMFConfig = null;
        private static readonly string splitStr = ",";
        private static string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "guiConfig.ini");
        public static string data { get; private set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.xml");
        public static string luaExe { get; private set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "luaExpect.exe");
        public static string saveFilePath = string.Empty;

        public static Uri proxyHost = new Uri("http://127.0.0.1:10809");
        public static bool proxyEnable = false;

        public static int taskParallelCount = 8;
        public static int retry = 0;
        public static bool autoTaskSize = false;
        public static List<Type> downloaders { get; private set; } = Common.Utility.GetInterfaceSubClassType(typeof(IDownloader));

        public static string version = "1.3.2023041021";
    }
}
