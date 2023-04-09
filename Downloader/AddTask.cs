using Downloader.Config;
using Downloader.Downloader;
using Downloader.Factory;
using Downloader.Interface;
using Downloader.Task;
using System.Text.RegularExpressions;

namespace Downloader
{
    public partial class AddTask : BaseForm
    {
        public AddTask()
        {
            InitializeComponent();
            if (comboBox3.Items.Count > 0)
                comboBox3.SelectedItem = comboBox3.Items[0];
            comboBox2.Items.AddRange(GUIConfig.downloaders.Select(i => i.Name).ToArray());
            comboBox2.SelectedItem = GUIConfig.downloaders?.FirstOrDefault()?.Name;
            downloaderName = comboBox2.Text;
            VodDownTypeUIUpdate();
        }

        private void VodDownTypeUIUpdate()
        {
            if (comboBox2.SelectedItem?.ToString() == nameof(VodkaDownloader))
            {
                label21.Visible = true;
                comboBox3.Visible = true;
            }
            else
            {
                label21.Visible = false;
                comboBox3.Visible = false;
            }
        }
        public List<ITask> tasks { get; private set; }
        public string downloaderName { get; private set; }
        private void button1_Click(object sender, EventArgs e)
        {
            FormatValue();
            DialogResult = DialogResult.OK;
        }
        private void FormatValue()
        {
            tasks = new List<ITask>();
            if (comboBox2.SelectedItem?.ToString() == nameof(DMFDownloader))
            {
                var cids = textBox1.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)?.Distinct();
                foreach (var cid in cids)
                    if (!string.IsNullOrWhiteSpace(cid))
                        tasks.Add(new DMFTask() { vid = cid, downloadType = comboBox1.Text });
            }
            else if (comboBox2.SelectedItem?.ToString() == nameof(VodkaDownloader) || comboBox2.SelectedItem?.ToString() == nameof(VodkaConsoleDownloader))
            {
                var cids = textBox1.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)?.Distinct();
                foreach (var cid in cids)
                    if (!string.IsNullOrWhiteSpace(cid))
                        tasks.Add(new VodTask() { vid = cid, downloadType = comboBox1.Text, downType = (comboBox3.SelectedIndex == 0 ? 2 : 1), selectType = cid.IndexOf('-') >= 0 ? 2 : 1 });
            }

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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            downloaderName = comboBox2.Text;
            if (comboBox2.SelectedItem?.ToString() == nameof(DMFDownloader))
            {
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(GUIConfig._DMFConfig.DMFDownloadType?.ToArray());
                comboBox1.SelectedItem = GUIConfig._DMFConfig.DMFDownloadType?.LastOrDefault();
            }
            else if (comboBox2.SelectedItem?.ToString() == nameof(VodkaDownloader) || comboBox2.SelectedItem?.ToString() == nameof(VodkaConsoleDownloader))
            {
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(GUIConfig._VodkaConfig.VodDownloadType?.ToArray());
                comboBox1.SelectedItem = GUIConfig._VodkaConfig.VodDownloadType?.FirstOrDefault();
            }
            VodDownTypeUIUpdate();
        }
    }
}
