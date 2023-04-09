using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Downloader.Interface;

namespace Downloader.Task
{
    public class VodTask : ITask
    {
        public string vid { get; set; }
        public string title { get; set; }
        public Image cover { get; set; }
        public string downloadType { get; set; }
        public int selectType { get; set; } = 1;
        public int downType { get; set; } = 1;
        public int downloadId
        {
            get
            {
                int id = 1;
                switch (downloadType)
                {
                    case "2d":
                        id = 1;
                        break;
                    case "4k":
                        id = 2;
                        break;
                    case "4k2d":
                        id = 3;
                        break;
                    case "vr":
                        id = 4;
                        break;
                    case "vr2":
                        id = 5;
                        break;
                }
                return id;

            }
        }
    }
}
