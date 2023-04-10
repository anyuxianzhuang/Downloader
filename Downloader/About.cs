using Downloader.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Downloader
{
    public partial class About : BaseForm
    {
        public About()
        {
            InitializeComponent();
            textBox1.Text = string.Join(Environment.NewLine, thankList);
            label4.Text = "版本: " + GUIConfig.version;
        }

        public List<string> thankList = new List<string>() { "dmf", "vod", "v2ray", "Newtonsoft.Json", "log4net" };
    }
}
