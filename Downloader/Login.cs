using Downloader.Config;
using Downloader.Downloader;

namespace Downloader
{
    public partial class Login : BaseForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DMF_Wrapper dMF_Wrapper = new DMF_Wrapper(Config.GUIConfig._DMFConfig);
            int loginState = dMF_Wrapper.Login_ikoa(txtName.Text, txtPwd.Text);
            if (loginState == 0)
            {
                GUIConfig.isLogin = true;
                GUIConfig.Save();
                DialogResult = DialogResult.OK;
            }
            else
            {
                GUIConfig.isLogin = false;
                GUIConfig.Save();
                EorrMessage("登录失败");
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
