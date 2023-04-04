using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Model
{
    public class DMFTask
    {
        public string cid { get; set; }
        public string title { get; set; }
        public Image cover { get; set; }
        public string downloadType { get; set; }
    }
}
