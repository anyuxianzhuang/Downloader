using Downloader.Config;
using Downloader.Model;
using System.Text.RegularExpressions;

namespace Downloader
{
    public partial class AddTask : BaseForm
    {
        public AddTask()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(GUIConfig._DMFConfig.DMFDownloadType?.ToArray());
            comboBox1.SelectedItem = GUIConfig._DMFConfig.DMFDownloadType?.LastOrDefault();
        }
        public List<DMFTask> DMFTasks { get; private set; }
        private void button1_Click(object sender, EventArgs e)
        {
            FormatValue();
            DialogResult = DialogResult.OK;
        }
        private void FormatValue()
        {
            DMFTasks = new List<DMFTask>();
            var cids = textBox1.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)?.Distinct();
            foreach (var cid in cids)
                if (!string.IsNullOrWhiteSpace(cid))
                    DMFTasks.Add(new DMFTask() { cid = cid, downloadType = comboBox1.Text });
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FormatValue();
            DialogResult = DialogResult.Yes;
        }
    }
}
