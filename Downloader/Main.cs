using Downloader.Common;
using Downloader.Interface;
using Downloader.Downloader;
using System.ComponentModel;
using System.Diagnostics;
using Downloader.Config;
using Downloader.Task;
using Downloader.Model;
using Downloader.Factory;
using System.Runtime.InteropServices;
using Polenter.Serialization;

namespace Downloader
{
    public partial class Main : BaseForm
    {
        public Main()
        {
            InitializeComponent();
            调试模式DToolStripMenuItem.Checked = Loger.showDebugInfo;
            this.Text = this.Text + " " + GUIConfig.version;
            Loger.MessageAcceptanceHandler += (msg) =>
            {
                BeginInvokeFun(() =>
                {
                    string msgStr = $"{DateTime.Now.ToString("MM-dd HH:mm:ss")} {msg?.ToString()}";
                    ShowMsg(msgStr);
                });
            };
            UpdateLoginUI();
            LoadData();
        }

        private int FocusIndex;
        private TaskManager taskManager = new TaskManager();
        private BindingList<TaskDTO> dMFTaskDTOs = new BindingList<TaskDTO>();
        private void LoadData()
        {
            dMFTaskDTOs = new BindingList<TaskDTO>(taskManager.dMFTaskDTOs);
            toolStripStatusLabel1.Text = string.Format("共{0}个任务", dMFTaskDTOs.Count);
            if (dataGridView1.SelectedRows.Count > 0)
                FocusIndex = dataGridView1.SelectedRows[0].Index;
            dataGridView1.DataSource = dMFTaskDTOs;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                dataGridView1.Rows[i].Selected = (i == FocusIndex);
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Option option = new Option();
            if (option.ShowDialog() == DialogResult.OK)
                InfoMessage("已运行任务软件配置重启后生效");
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            var res = login.ShowDialog();
            if (res == DialogResult.OK || res == DialogResult.Cancel)
                UpdateLoginUI();
        }

        private void UpdateLoginUI()
        {
            if (GUIConfig._DMFConfig.isLogin && GUIConfig._VodkaConfig.isLogin)
                toolStripButton2.Text = "已登录(DMF,Vodka)";
            else if (GUIConfig._DMFConfig.isLogin)
                toolStripButton2.Text = "已登录(DMF)";
            else if (GUIConfig._VodkaConfig.isLogin)
                toolStripButton2.Text = "已登录(Vodka)";
            else
                toolStripButton2.Text = "登录";
        }

        private async void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (taskManager == null)
                return;
            var selectRows = dataGridView1.SelectedRows;
            if (selectRows != null)
            {
                List<TaskDTO> startList = new List<TaskDTO>();
                foreach (DataGridViewRow selectRow in selectRows)
                {
                    TaskDTO dto = selectRow.DataBoundItem as TaskDTO;
                    if (dto != null)
                        startList.Add(dto);
                }
                await taskManager.Start(taskManager.DTOToDownloader(startList), 2);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (taskManager == null)
                return;
            var selectRows = dataGridView1.SelectedRows;
            if (selectRows != null)
            {
                List<TaskDTO> startList = new List<TaskDTO>();
                foreach (DataGridViewRow selectRow in selectRows)
                {
                    TaskDTO dto = selectRow.DataBoundItem as TaskDTO;
                    if (dto != null)
                        startList.Add(dto);
                }
                foreach (var item in taskManager.DTOToDownloader(startList))
                    taskManager.Delete(item);
                LoadData();
            }
        }
        private async void toolStripButton4_Click(object sender, EventArgs e)
        {
            AddTask addTask = new AddTask();
            switch (addTask.ShowDialog())
            {
                case DialogResult.OK:
                    CreateNewDownloader(addTask.tasks, addTask.downloaderName);
                    break;
                case DialogResult.Yes:
                    var downs = CreateNewDownloader(addTask.tasks, addTask.downloaderName);
                    await taskManager.Start(downs, 2);
                    break;
                default:
                    break;
            }
        }
        private DownloaderFactory downloaderFactory = new DownloaderFactory();

        public List<IDownloader> CreateNewDownloader(List<ITask> tasks, string downloaderName)
        {
            List<IDownloader> downloaders = new List<IDownloader>();
            foreach (var task in tasks)
            {
                if (downloaderName == nameof(DMFDownloader))
                {
                    var dMFDownloader = downloaderFactory.CreateDMFDownloader(GUIConfig._DMFConfig, task);
                    dMFDownloader.taskStateChangeHandler += (down) =>
                    {
                        InvokeFun(() => { LoadData(); });
                    };
                    taskManager.Add(dMFDownloader);
                    downloaders.Add(dMFDownloader);
                }
                else if (downloaderName == nameof(VodkaDownloader))
                {
                    var vodkaDownloader = downloaderFactory.CreateVodkaDownloader(GUIConfig._VodkaConfig, task);
                    vodkaDownloader.taskStateChangeHandler += (down) =>
                    {
                        InvokeFun(() => { LoadData(); });
                    };
                    taskManager.Add(vodkaDownloader);
                    downloaders.Add(vodkaDownloader);
                }
                else if (downloaderName == nameof(VodkaConsoleDownloader))
                {
                    var vodkaDownloader = downloaderFactory.CreateVodkaConsoleDownloader(GUIConfig._VodkaConfig, task);
                    vodkaDownloader.taskStateChangeHandler += (down) =>
                    {
                        InvokeFun(() => { LoadData(); });
                    };
                    taskManager.Add(vodkaDownloader);
                    downloaders.Add(vodkaDownloader);
                }
            }
            LoadData();
            return downloaders;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (taskManager == null)
                return;
            var selectRows = dataGridView1.SelectedRows;
            if (selectRows != null)
            {
                List<TaskDTO> stopList = new List<TaskDTO>();
                foreach (DataGridViewRow selectRow in selectRows)
                {
                    TaskDTO dto = selectRow.DataBoundItem as TaskDTO;
                    if (dto != null)
                        stopList.Add(dto);
                }
                taskManager.Stop(taskManager.DTOToDownloader(stopList));
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            taskManager.StopAll();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            var serializer = new SharpSerializer();
            var processesName = Path.GetFileNameWithoutExtension(GUIConfig._DMFConfig.GetExeFilePath());
            if (!string.IsNullOrEmpty(processesName))
                foreach (var node in Process.GetProcessesByName(processesName))
                    node.Kill();
            Environment.Exit(0);
        }
        private void ShowMsg(string msg)
        {
            if (textBox1.Lines.Length > 999)
                ClearMsg();
            textBox1.AppendText(msg);
            if (!msg.EndsWith(Environment.NewLine))
                textBox1.AppendText(Environment.NewLine);
        }
        /// <summary>
        /// 清除信息
        /// </summary>
        private void ClearMsg()
        {
            textBox1.Clear();
        }

        private void 调试模式DToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Loger.showDebugInfo = 调试模式DToolStripMenuItem.Checked;
        }

        private async void toolStripButton7_Click(object sender, EventArgs e)
        {
            await taskManager.StartAll();
        }

        private void 更新程序UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoMessage("暂不提供在线更新");
        }

        private void Main_Shown(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            if (row == null)
                return;
            TaskDTO dto = row.DataBoundItem as TaskDTO;
            if (dto != null)
            {
                var downloader = taskManager.DTOToDownloader(new List<TaskDTO>() { dto });
                if (downloader.Count > 0)
                    downloader[0].Activate();
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            TaskCapture taskCapture = new TaskCapture();
            taskCapture.Show();
        }
    }
}
