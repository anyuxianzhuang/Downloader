using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Downloader.Interface;
using Newtonsoft.Json.Linq;

namespace Downloader.Task
{
    public class DMFTask : ITask
    {
        public string vid { get; set; }
        public string title { get; set; }
        public Image cover { get; set; }
        public string downloadType { get; set; }
    }
}
