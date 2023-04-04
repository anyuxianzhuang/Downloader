using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Config
{
    public class DMFConfig : IConfig
    {
        public readonly string exeName = "iKOA_DMF_*.exe";
        public string DMFPath = string.Empty;
        public string DMFSavePath = string.Empty;
        public string DMFTempPath = string.Empty;
        public int DMFVideoThreading;
        public int DMFAudioThreading;
        public int DMFRetry;
        public string DMFServer;
        public List<string> DMFDownloadType;

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

        public void SaveDMFConfig()
        {
            string dmfConfigFile = Path.Combine(DMFPath, "config.json");
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
                keyValuePairs.Add("global", new JObject() { { "token", "" }, { "download_path", GUIConfig._DMFConfig.DMFSavePath }, { "temp_path", GUIConfig._DMFConfig.DMFTempPath } });
                keyValuePairs.Add("connection", new JObject() { { "video_threading", GUIConfig._DMFConfig.DMFVideoThreading }, { "audio_threading", GUIConfig._DMFConfig.DMFAudioThreading }, { "retry", GUIConfig._DMFConfig.DMFRetry }, { "ip", GUIConfig._DMFConfig.DMFServer } });
                keyValuePairs.Add("proxy", new JObject() { { "protocol", GUIConfig.proxyHost.Scheme }, { "port", GUIConfig.proxyHost.Port }, { "enable", GUIConfig.proxyEnable ? "true" : "false" } });

            }
            else
            {
                keyValuePairs = (JObject)JsonConvert.DeserializeObject(config);
                if (keyValuePairs["global"] != null)
                {
                    if (keyValuePairs["global"]["download_path"] != null)
                        keyValuePairs["global"]["download_path"] = GUIConfig._DMFConfig.DMFSavePath;
                    if (keyValuePairs["global"]["temp_path"] != null)
                        keyValuePairs["global"]["temp_path"] = GUIConfig._DMFConfig.DMFTempPath;
                }

                if (keyValuePairs["connection"] != null)
                {
                    if (keyValuePairs["connection"]["video_threading"] != null)
                        keyValuePairs["connection"]["video_threading"] = GUIConfig._DMFConfig.DMFVideoThreading;
                    if (keyValuePairs["connection"]["audio_threading"] != null)
                        keyValuePairs["connection"]["audio_threading"] = GUIConfig._DMFConfig.DMFAudioThreading;
                    if (keyValuePairs["connection"]["retry"] != null)
                        keyValuePairs["connection"]["retry"] = GUIConfig._DMFConfig.DMFRetry;
                    if (keyValuePairs["connection"]["ip"] != null)
                        keyValuePairs["connection"]["ip"] = GUIConfig._DMFConfig.DMFServer;
                }

                if (keyValuePairs["proxy"] != null)
                {
                    if (keyValuePairs["proxy"]["protocol"] != null)
                        keyValuePairs["proxy"]["protocol"] = GUIConfig.proxyHost.Scheme;
                    if (keyValuePairs["proxy"]["port"] != null)
                        keyValuePairs["proxy"]["port"] = GUIConfig.proxyHost.Port;
                    if (keyValuePairs["proxy"]["enable"] != null)
                        keyValuePairs["proxy"]["enable"] = GUIConfig.proxyEnable ? "true" : "false";
                }
            }
            config = keyValuePairs.ToString();
            using (StreamWriter sW2 = new StreamWriter(dmfConfigFile, false, new UTF8Encoding(false)))
                sW2.Write(config);

        }


    }

}
