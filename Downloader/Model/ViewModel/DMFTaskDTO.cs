using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Model.ViewModel
{
    public class DMFTaskDTO
    {
        public Guid id { get; set; }
        public string cid { get; set; }
        public string title { get; set; }
        public Image cover { get; set; }
        public string downloadType { get; set; }

        public int state { get; set; }
        public string stateDisplay { get; set; }
        public float progress { get; set; }

    }
}
