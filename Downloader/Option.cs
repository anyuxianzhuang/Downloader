using Downloader.Config;
using System.ComponentModel;

namespace Downloader
{
    public partial class Option : BaseForm
    {
        public Option()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            textBox1.Text = GUIConfig._DMFConfig.DMFPath;
            textBox3.Text = GUIConfig._DMFConfig.DMFSavePath;
            textBox4.Text = GUIConfig._DMFConfig.DMFTempPath;
            numericUpDown1.Value = GUIConfig._DMFConfig.DMFVideoThreading;
            numericUpDown2.Value = GUIConfig._DMFConfig.DMFAudioThreading;
            numericUpDown3.Value = GUIConfig._DMFConfig.DMFRetry;
            textBox5.Text = GUIConfig._DMFConfig.DMFServer;
            checkBox1.Checked = GUIConfig.proxyEnable;
            textBox2.Text = GUIConfig.proxyHost.ToString();
            numericUpDown4.Value = GUIConfig.taskParallelCount;
            checkBox2.Checked = GUIConfig.autoTaskSize;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CheckDMFFile();
                GUIConfig._DMFConfig.DMFPath = textBox1.Text;
                GUIConfig._DMFConfig.DMFSavePath = textBox3.Text;
                GUIConfig._DMFConfig.DMFTempPath = textBox4.Text;
                GUIConfig._DMFConfig.DMFVideoThreading = (int)numericUpDown1.Value;
                GUIConfig._DMFConfig.DMFAudioThreading = (int)numericUpDown2.Value;
                GUIConfig._DMFConfig.DMFRetry = (int)numericUpDown3.Value;
                GUIConfig._DMFConfig.DMFServer = textBox5.Text;
                GUIConfig.proxyEnable = checkBox1.Checked;
                GUIConfig.proxyHost = new Uri(textBox2.Text);


                GUIConfig.taskParallelCount = (int)numericUpDown4.Value;
                GUIConfig.autoTaskSize = checkBox2.Checked;
                GUIConfig.Save();
                GUIConfig._DMFConfig.SaveDMFConfig();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                EorrMessage(ex?.Message);
            }
        }

        private void CheckDMFFile()
        {
            string dmfPath = textBox1.Text;
            if (!Directory.Exists(textBox3.Text))
                throw new Exception("保存路径输入错误");
            if (!Directory.Exists(textBox4.Text))
                throw new Exception("缓存路径输入错误");
            if (numericUpDown1.Value <= 0)
                throw new Exception("DMFVideoThreading输入错误");
            if (string.IsNullOrWhiteSpace(textBox5.Text))
                throw new Exception("server未设置");
        }
        private void Option_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            string dmfPath = textBox1.Text;
            if (!Directory.Exists(dmfPath))
            {
                e.Cancel = true;
                EorrMessage("dmf程序路径输入错误");
                return;
            }
            if (Directory.GetFiles(dmfPath, "iKOA_DMF_*.exe").Length <= 0)
            {
                e.Cancel = true;
                EorrMessage("dmf程序路径输入错误");
                return;
            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            var savePath = Path.Combine(textBox1.Text, "video");
            Directory.CreateDirectory(savePath);
            var tempPath = Path.Combine(textBox1.Text, "temp");
            Directory.CreateDirectory(tempPath);
            textBox3.Text = savePath;
            textBox4.Text = tempPath;
        }
    }
}
