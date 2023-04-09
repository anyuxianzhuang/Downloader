namespace Downloader
{
    partial class TaskCapture
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            button1 = new Button();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            vid = new DataGridViewTextBoxColumn();
            title = new DataGridViewTextBoxColumn();
            url = new DataGridViewTextBoxColumn();
            image = new DataGridViewImageColumn();
            Type = new DataGridViewTextBoxColumn();
            mgsSign = new DataGridViewTextBoxColumn();
            imageUrl = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            vid保存到剪切板ToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            statusStrip1 = new StatusStrip();
            toolStripProgressBar1 = new ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(85, 13);
            textBox1.Margin = new Padding(8, 8, 8, 8);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(437, 23);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(538, 13);
            button1.Margin = new Padding(8, 8, 8, 8);
            button1.Name = "button1";
            button1.Size = new Size(71, 24);
            button1.TabIndex = 2;
            button1.Text = "开始";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "msg", "dmm" });
            comboBox1.Location = new Point(9, 12);
            comboBox1.Margin = new Padding(8, 8, 8, 8);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(67, 25);
            comboBox1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { vid, title, url, image, Type, mgsSign, imageUrl });
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 45);
            dataGridView1.Margin = new Padding(2, 2, 2, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.RowTemplate.Height = 32;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(626, 494);
            dataGridView1.TabIndex = 4;
            // 
            // vid
            // 
            vid.DataPropertyName = "vid";
            vid.HeaderText = "vid";
            vid.MinimumWidth = 8;
            vid.Name = "vid";
            vid.ReadOnly = true;
            // 
            // title
            // 
            title.DataPropertyName = "title";
            title.HeaderText = "title";
            title.MinimumWidth = 8;
            title.Name = "title";
            title.ReadOnly = true;
            title.Resizable = DataGridViewTriState.True;
            title.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // url
            // 
            url.DataPropertyName = "url";
            url.HeaderText = "url";
            url.MinimumWidth = 8;
            url.Name = "url";
            url.ReadOnly = true;
            url.Resizable = DataGridViewTriState.True;
            url.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // image
            // 
            image.DataPropertyName = "image";
            image.HeaderText = "image";
            image.MinimumWidth = 8;
            image.Name = "image";
            image.ReadOnly = true;
            // 
            // Type
            // 
            Type.DataPropertyName = "Type";
            Type.HeaderText = "Type";
            Type.MinimumWidth = 8;
            Type.Name = "Type";
            Type.ReadOnly = true;
            Type.Visible = false;
            // 
            // mgsSign
            // 
            mgsSign.DataPropertyName = "mgsSign";
            mgsSign.HeaderText = "mgsSign";
            mgsSign.MinimumWidth = 8;
            mgsSign.Name = "mgsSign";
            mgsSign.ReadOnly = true;
            mgsSign.Visible = false;
            // 
            // imageUrl
            // 
            imageUrl.DataPropertyName = "imageUrl";
            imageUrl.HeaderText = "imageUrl";
            imageUrl.MinimumWidth = 8;
            imageUrl.Name = "imageUrl";
            imageUrl.ReadOnly = true;
            imageUrl.Visible = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { vid保存到剪切板ToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(174, 34);
            // 
            // vid保存到剪切板ToolStripMenuItem
            // 
            vid保存到剪切板ToolStripMenuItem.Image = Properties.Resources.add;
            vid保存到剪切板ToolStripMenuItem.Name = "vid保存到剪切板ToolStripMenuItem";
            vid保存到剪切板ToolStripMenuItem.Size = new Size(173, 30);
            vid保存到剪切板ToolStripMenuItem.Text = "vid保存到剪切板";
            vid保存到剪切板ToolStripMenuItem.Click += vid保存到剪切板ToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(textBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2, 2, 2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(626, 45);
            panel1.TabIndex = 5;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 517);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 9, 0);
            statusStrip1.Size = new Size(626, 22);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(64, 16);
            // 
            // TaskCapture
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(626, 539);
            Controls.Add(statusStrip1);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Margin = new Padding(5, 8, 5, 8);
            MinimumSize = new Size(642, 578);
            Name = "TaskCapture";
            Text = "Capture";
            Shown += TaskCapture_Shown;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private Button button1;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private Panel panel1;
        private DataGridViewTextBoxColumn vid;
        private DataGridViewTextBoxColumn title;
        private DataGridViewTextBoxColumn url;
        private DataGridViewImageColumn image;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn mgsSign;
        private DataGridViewTextBoxColumn imageUrl;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem vid保存到剪切板ToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar1;
    }
}