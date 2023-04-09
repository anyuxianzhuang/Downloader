using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Model
{
    public enum CaptureType
    {
        DMM
    }
    public class CaptureData
    {
        public CaptureType Type { get; set; }
        public string vid { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public Image image { get; set; }
        public string imageUrl { get; set; }
        public string mgsSign { get; set; }

    }
}
