using Downloader.Config;
using System.ComponentModel;

namespace Downloader
{
    public partial class Option : BaseForm
    {
        public Option()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(GUIConfig._VodkaConfig.saveTypes.ToArray());
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedItem = comboBox1.Items[0];
        }

        private void LoadData()
        {
            textBox6.Text = GUIConfig.saveFilePath;

            textBox1.Text = GUIConfig._DMFConfig.DMFPath;
            textBox3.Text = GUIConfig._DMFConfig.DMFSavePath;
            textBox4.Text = GUIConfig._DMFConfig.DMFTempPath;
            numericUpDown1.Value = GUIConfig._DMFConfig.DMFVideoThreading;
            numericUpDown2.Value = GUIConfig._DMFConfig.DMFAudioThreading;
            numericUpDown3.Value = GUIConfig._DMFConfig.DMFRetry;
            textBox5.Text = GUIConfig._DMFConfig.DMFServer;
            checkBox3.Checked = GUIConfig._DMFConfig.enableStrict;
            checkBox1.Checked = GUIConfig.proxyEnable;
            textBox2.Text = GUIConfig.proxyHost.ToString();
            numericUpDown4.Value = GUIConfig.taskParallelCount;
            numericUpDown8.Value = GUIConfig.retry;

            textBox8.Text = GUIConfig._VodkaConfig.VodkaPath;
            textBox9.Text = GUIConfig._VodkaConfig.savePath;
            textBox7.Text = GUIConfig._VodkaConfig.movePath;
            comboBox1.SelectedItem = GUIConfig._VodkaConfig.saveType;
            checkBox4.Checked = GUIConfig._VodkaConfig.isMerge2D;
            checkBox5.Checked = GUIConfig._VodkaConfig.isMerge4K;
            checkBox6.Checked = GUIConfig._VodkaConfig.isMergeVR;
            numericUpDown5.Value = GUIConfig._VodkaConfig.parallel2DCount;
            numericUpDown6.Value = GUIConfig._VodkaConfig.parallel4KCount;
            numericUpDown7.Value = GUIConfig._VodkaConfig.parallelVRCount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CheckConfigSetting();

                GUIConfig._DMFConfig.DMFPath = textBox1.Text;
                if (!string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    GUIConfig.saveFilePath = textBox6.Text;
                    GUIConfig._DMFConfig.DMFSavePath = GUIConfig.saveFilePath;
                    GUIConfig._VodkaConfig.savePath = GUIConfig.saveFilePath;
                }
                else
                {
                    GUIConfig._DMFConfig.DMFSavePath = textBox3.Text;
                    GUIConfig._VodkaConfig.savePath = textBox9.Text;
                }
                GUIConfig._DMFConfig.DMFTempPath = textBox4.Text;
                GUIConfig._DMFConfig.DMFVideoThreading = (int)numericUpDown1.Value;
                GUIConfig._DMFConfig.DMFAudioThreading = (int)numericUpDown2.Value;
                GUIConfig._DMFConfig.DMFRetry = (int)numericUpDown3.Value;
                GUIConfig._DMFConfig.DMFServer = textBox5.Text;
                GUIConfig._DMFConfig.enableStrict = checkBox3.Checked;
                GUIConfig.proxyEnable = checkBox1.Checked;
                GUIConfig.proxyHost = new Uri(textBox2.Text);


                GUIConfig.taskParallelCount = (int)numericUpDown4.Value;
                GUIConfig.retry = (int)numericUpDown8.Value;


                GUIConfig._VodkaConfig.VodkaPath = textBox8.Text;
                GUIConfig._VodkaConfig.movePath = textBox7.Text;
                GUIConfig._VodkaConfig.saveType = comboBox1.SelectedItem?.ToString();
                GUIConfig._VodkaConfig.isMerge2D = checkBox4.Checked;
                GUIConfig._VodkaConfig.isMerge4K = checkBox5.Checked;
                GUIConfig._VodkaConfig.isMergeVR = checkBox6.Checked;
                GUIConfig._VodkaConfig.parallel2DCount = (int)numericUpDown5.Value;
                GUIConfig._VodkaConfig.parallel4KCount = (int)numericUpDown6.Value;
                GUIConfig._VodkaConfig.parallelVRCount = (int)numericUpDown7.Value;

                GUIConfig.Save();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                EorrMessage(ex?.Message);
            }
        }

        private void CheckConfigSetting()
        {
            if (!Directory.Exists(textBox6.Text))
                throw new Exception("保存路径输入错误");
            if (!Directory.Exists(textBox3.Text))
                throw new Exception("dmf保存路径输入错误");
            if (!Directory.Exists(textBox9.Text))
                throw new Exception("vodka保存路径输入错误");
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
            if (!string.IsNullOrEmpty(dmfPath))
            {
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
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {

        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox6.Text) && !Directory.Exists(textBox6.Text))
            {
                e.Cancel = true;
                EorrMessage("保存路径输入错误");
                return;
            }
        }

        private void textBox6_Validated(object sender, EventArgs e)
        {
            textBox3.Text = textBox6.Text;
            textBox9.Text = textBox6.Text;
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {
            string vodPath = textBox8.Text;
            if (!string.IsNullOrEmpty(vodPath))
            {
                if (!Directory.Exists(vodPath))
                {
                    e.Cancel = true;
                    EorrMessage("vod程序路径输入错误");
                    return;
                }
                if (Directory.GetFiles(vodPath, "iKOA_Vodka*.exe").Length <= 0)
                {
                    e.Cancel = true;
                    EorrMessage("vod程序路径输入错误");
                    return;
                }
            }
        }
    }
}
