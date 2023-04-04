using Downloader.Common;
using Downloader.Config;
using Downloader.Downloader;
using Downloader.Model;
using Downloader.Model.ViewModel;
using System.ComponentModel;
using System.Diagnostics;

namespace Downloader
{
    public partial class Main : BaseForm
    {
        public Main()
        {
            InitializeComponent();
            Loger.MessageAcceptanceHandler += (msg) =>
            {
                InvokeFun(() =>
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
        private BindingList<DMFTaskDTO> dMFTaskDTOs = new BindingList<DMFTaskDTO>();
        private void LoadData()
        {
            dMFTaskDTOs = new BindingList<DMFTaskDTO>(taskManager.dMFTaskDTOs);
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
                InfoMessage("软件配置重启后生效");
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
            if (GUIConfig.isLogin)
                toolStripButton2.Text = "已登录";
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
                List<DMFTaskDTO> startList = new List<DMFTaskDTO>();
                foreach (DataGridViewRow selectRow in selectRows)
                {
                    DMFTaskDTO dto = selectRow.DataBoundItem as DMFTaskDTO;
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
                List<DMFTaskDTO> startList = new List<DMFTaskDTO>();
                foreach (DataGridViewRow selectRow in selectRows)
                {
                    DMFTaskDTO dto = selectRow.DataBoundItem as DMFTaskDTO;
                    if (dto != null)
                        startList.Add(dto);
                }
                foreach (var item in taskManager.DTOToDownloader(startList))
                    taskManager.Delete(item);
                LoadData();
            }
        }
        private DMFDownloader NewDMFDownloader(DMFTask dMFTask)
        {
            var downloader = new DMFDownloader(dMFTask);
            downloader.taskStateChangeHandler += (down) =>
            {
                InvokeFun(() =>
                {
                    LoadData();
                });
            };
            return downloader;
        }
        private async void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (!Config.GUIConfig.isLogin)
            {
                EorrMessage("尚未登录");
                return;
            }
            AddTask addTask = new AddTask();
            switch (addTask.ShowDialog())
            {
                case DialogResult.OK:
                    if (addTask.DMFTasks != null)
                    {
                        foreach (var task in addTask.DMFTasks)
                        {
                            var downloader = NewDMFDownloader(task);
                            taskManager.Add(downloader);
                        }
                        LoadData();
                    }
                    break;
                case DialogResult.Yes:
                    if (addTask.DMFTasks != null)
                    {
                        List<DMFDownloader> down = new List<DMFDownloader>();
                        foreach (var task in addTask.DMFTasks)
                        {
                            var downloader = NewDMFDownloader(task);
                            if (!taskManager.Contains(downloader))
                            {
                                taskManager.Add(downloader);
                                down.Add(downloader);
                            }
                        }
                        LoadData();
                        await taskManager.Start(down, 2);
                    }
                    break;
                default:
                    break;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (taskManager == null)
                return;
            var selectRows = dataGridView1.SelectedRows;
            if (selectRows != null)
            {
                List<DMFTaskDTO> stopList = new List<DMFTaskDTO>();
                foreach (DataGridViewRow selectRow in selectRows)
                {
                    DMFTaskDTO dto = selectRow.DataBoundItem as DMFTaskDTO;
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
            if (!GUIConfig._DMFConfig.DependencyConfig())
            {
                EorrMessage("DMF未配置");
                return;
            }
        }
    }
}
