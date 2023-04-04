namespace Downloader
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            menuStrip1 = new MenuStrip();
            设置ToolStripMenuItem = new ToolStripMenuItem();
            帮助HToolStripMenuItem = new ToolStripMenuItem();
            更新程序UToolStripMenuItem = new ToolStripMenuItem();
            关于AToolStripMenuItem = new ToolStripMenuItem();
            调试模式DToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStrip1 = new ToolStrip();
            toolStripButton2 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            toolStripButton5 = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton7 = new ToolStripButton();
            toolStripButton6 = new ToolStripButton();
            programBindingSource = new BindingSource(components);
            taskExBindingSource2 = new BindingSource(components);
            textBox1 = new TextBox();
            groupBox1 = new GroupBox();
            splitContainer1 = new SplitContainer();
            id = new DataGridViewTextBoxColumn();
            cidDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            downloadTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            titleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            coverDataGridViewImageColumn = new DataGridViewImageColumn();
            stateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            stateID = new DataGridViewTextBoxColumn();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            statusStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)programBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)taskExBindingSource2).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 设置ToolStripMenuItem, 帮助HToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1661, 34);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            设置ToolStripMenuItem.Size = new Size(87, 28);
            设置ToolStripMenuItem.Text = "设置(&A)";
            设置ToolStripMenuItem.Click += 设置ToolStripMenuItem_Click;
            // 
            // 帮助HToolStripMenuItem
            // 
            帮助HToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 更新程序UToolStripMenuItem, 关于AToolStripMenuItem, 调试模式DToolStripMenuItem });
            帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            帮助HToolStripMenuItem.Size = new Size(88, 28);
            帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 更新程序UToolStripMenuItem
            // 
            更新程序UToolStripMenuItem.Name = "更新程序UToolStripMenuItem";
            更新程序UToolStripMenuItem.Size = new Size(208, 34);
            更新程序UToolStripMenuItem.Text = "更新程序(&U)";
            更新程序UToolStripMenuItem.Click += 更新程序UToolStripMenuItem_Click;
            // 
            // 关于AToolStripMenuItem
            // 
            关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            关于AToolStripMenuItem.Size = new Size(208, 34);
            关于AToolStripMenuItem.Text = "关于(&A)";
            关于AToolStripMenuItem.Click += 关于AToolStripMenuItem_Click;
            // 
            // 调试模式DToolStripMenuItem
            // 
            调试模式DToolStripMenuItem.Checked = true;
            调试模式DToolStripMenuItem.CheckOnClick = true;
            调试模式DToolStripMenuItem.CheckState = CheckState.Checked;
            调试模式DToolStripMenuItem.Name = "调试模式DToolStripMenuItem";
            调试模式DToolStripMenuItem.Size = new Size(208, 34);
            调试模式DToolStripMenuItem.Text = "调试模式(&D)";
            调试模式DToolStripMenuItem.CheckedChanged += 调试模式DToolStripMenuItem_CheckedChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, cidDataGridViewTextBoxColumn, downloadTypeDataGridViewTextBoxColumn, titleDataGridViewTextBoxColumn, coverDataGridViewImageColumn, stateDataGridViewTextBoxColumn, stateID });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = SystemColors.ButtonFace;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1661, 489);
            dataGridView1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 1069);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 17, 0);
            statusStrip1.Size = new Size(1661, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 15);
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton2, toolStripButton4, toolStripButton5, toolStripButton1, toolStripButton3, toolStripButton7, toolStripButton6 });
            toolStrip1.Location = new Point(0, 34);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1661, 57);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            toolStripButton2.Image = Properties.Resources.login;
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(50, 52);
            toolStripButton2.Text = "登录";
            toolStripButton2.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // toolStripButton4
            // 
            toolStripButton4.Image = Properties.Resources.add;
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(50, 52);
            toolStripButton4.Text = "添加";
            toolStripButton4.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButton4.Click += toolStripButton4_Click;
            // 
            // toolStripButton5
            // 
            toolStripButton5.Image = Properties.Resources.del;
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(50, 52);
            toolStripButton5.Text = "删除";
            toolStripButton5.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButton5.Click += toolStripButton5_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = Properties.Resources.start;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(50, 52);
            toolStripButton1.Text = "开始";
            toolStripButton1.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton1.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripButton3
            // 
            toolStripButton3.Image = Properties.Resources.stop;
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(50, 52);
            toolStripButton3.Text = "停止";
            toolStripButton3.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButton3.Click += toolStripButton3_Click;
            // 
            // toolStripButton7
            // 
            toolStripButton7.Image = Properties.Resources.start;
            toolStripButton7.ImageTransparentColor = Color.Magenta;
            toolStripButton7.Name = "toolStripButton7";
            toolStripButton7.Size = new Size(86, 52);
            toolStripButton7.Text = "队列运行";
            toolStripButton7.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton7.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButton7.Click += toolStripButton7_Click;
            // 
            // toolStripButton6
            // 
            toolStripButton6.Image = Properties.Resources.stop;
            toolStripButton6.ImageTransparentColor = Color.Magenta;
            toolStripButton6.Name = "toolStripButton6";
            toolStripButton6.Size = new Size(86, 52);
            toolStripButton6.Text = "全部停止";
            toolStripButton6.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButton6.Click += toolStripButton6_Click;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(3, 26);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(1655, 456);
            textBox1.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1661, 485);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "信息";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 91);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(1661, 978);
            splitContainer1.SplitterDistance = 489;
            splitContainer1.TabIndex = 6;
            // 
            // id
            // 
            id.DataPropertyName = "id";
            id.HeaderText = "id";
            id.MinimumWidth = 8;
            id.Name = "id";
            id.ReadOnly = true;
            // 
            // cidDataGridViewTextBoxColumn
            // 
            cidDataGridViewTextBoxColumn.DataPropertyName = "cid";
            cidDataGridViewTextBoxColumn.HeaderText = "cid";
            cidDataGridViewTextBoxColumn.MinimumWidth = 8;
            cidDataGridViewTextBoxColumn.Name = "cidDataGridViewTextBoxColumn";
            cidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // downloadTypeDataGridViewTextBoxColumn
            // 
            downloadTypeDataGridViewTextBoxColumn.DataPropertyName = "downloadType";
            downloadTypeDataGridViewTextBoxColumn.HeaderText = "downloadType";
            downloadTypeDataGridViewTextBoxColumn.MinimumWidth = 8;
            downloadTypeDataGridViewTextBoxColumn.Name = "downloadTypeDataGridViewTextBoxColumn";
            downloadTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            titleDataGridViewTextBoxColumn.HeaderText = "title";
            titleDataGridViewTextBoxColumn.MinimumWidth = 8;
            titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // coverDataGridViewImageColumn
            // 
            coverDataGridViewImageColumn.DataPropertyName = "cover";
            coverDataGridViewImageColumn.HeaderText = "cover";
            coverDataGridViewImageColumn.MinimumWidth = 8;
            coverDataGridViewImageColumn.Name = "coverDataGridViewImageColumn";
            coverDataGridViewImageColumn.ReadOnly = true;
            // 
            // stateDataGridViewTextBoxColumn
            // 
            stateDataGridViewTextBoxColumn.DataPropertyName = "stateDisplay";
            stateDataGridViewTextBoxColumn.HeaderText = "state";
            stateDataGridViewTextBoxColumn.MinimumWidth = 8;
            stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            stateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stateID
            // 
            stateID.DataPropertyName = "state";
            stateID.HeaderText = "stateID";
            stateID.MinimumWidth = 8;
            stateID.Name = "stateID";
            stateID.ReadOnly = true;
            stateID.Visible = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1661, 1091);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5);
            MinimumSize = new Size(973, 781);
            Name = "Main";
            Text = "Downloader";
            FormClosed += Main_FormClosed;
            Shown += Main_Shown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)programBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)taskExBindingSource2).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource programBindingSource;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新程序UToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.BindingSource taskExBindingSource2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private TextBox textBox1;
        private GroupBox groupBox1;
        private ToolStripMenuItem 调试模式DToolStripMenuItem;
        private ToolStripButton toolStripButton7;
        private SplitContainer splitContainer1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn cidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn downloadTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private DataGridViewImageColumn coverDataGridViewImageColumn;
        private DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn stateID;
    }
}

