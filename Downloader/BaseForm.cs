namespace Downloader
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        public void EorrMessage(string msg)
        {
            MessageBox.Show(msg, "错误", MessageBoxButtons.OK);
        }

        public void InfoMessage(string msg)
        {
            MessageBox.Show(msg, "提示", MessageBoxButtons.OK);
        }

        public void InvokeFun(Action action)
        {
            if (this.InvokeRequired)
                Invoke(action);
            else
                action();
        }
    }
}
