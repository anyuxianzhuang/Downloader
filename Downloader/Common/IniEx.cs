using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Common
{
    public class IniEx
    {
        public IniEx(string iniFileName)
        {
            this.iniFileName = iniFileName;
        }
        private string iniFileName { get; }
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);
        public void WriteContentValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, iniFileName);
        }
        public string ReadContentValue(string section, string key)
        {
            StringBuilder temp = new StringBuilder(1024);
            if (File.Exists(iniFileName))
                GetPrivateProfileString(section, key, "", temp, 1024, iniFileName);
            return temp.ToString();
        }
    }
}
