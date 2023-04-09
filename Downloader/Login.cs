using Downloader.Downloader;
using Downloader.Config;
using Downloader.Common;

namespace Downloader
{
    public partial class Login : BaseForm
    {
        public Login()
        {
            InitializeComponent();
            comboBox2.Items.Add(ALLLoginField);
            comboBox2.Items.AddRange(GUIConfig.downloaders.Where(i => i.Name != nameof(VodkaConsoleDownloader)).Select(i => i.Name).ToArray());
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedItem = comboBox2.Items[0].ToString();
        }
        private string ALLLoginField = "ALL";
        private void button1_Click(object sender, EventArgs e)
        {
            int loginState = 0;
            string selectItem = comboBox2.SelectedItem?.ToString();
            if ((selectItem == nameof(DMFDownloader) || selectItem == ALLLoginField))
            {
                Loger.Info(nameof(DMFDownloader) + " 正在登录");
                DMF_Wrapper dMF_Wrapper = new DMF_Wrapper(GUIConfig._DMFConfig);
                loginState = dMF_Wrapper.Login_ikoa(txtName.Text, txtPwd.Text);
                GUIConfig._DMFConfig.isLogin = (loginState == 0);
                if (loginState != 0)
                {
                    EorrMessage("DMF登录失败");
                    return;
                }
                Loger.Info(nameof(DMFDownloader) + " 登录成功");
            }
            if ((selectItem == nameof(VodkaDownloader) || selectItem == ALLLoginField))
            {
                Loger.Info(nameof(VodkaDownloader) + " 正在登录");
                Vodka_Wrapper vodka_Wrapper = new Vodka_Wrapper(GUIConfig._VodkaConfig);
                loginState = vodka_Wrapper.Login_ikoa(txtName.Text, txtPwd.Text);
                GUIConfig._VodkaConfig.isLogin = (loginState == 0);
                if (loginState != 0)
                {
                    EorrMessage("Vodka登录失败");
                    return;
                }
                Loger.Info(nameof(VodkaDownloader) + " 登录成功");
            }
            GUIConfig.Save();
            DialogResult = DialogResult.OK;
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
