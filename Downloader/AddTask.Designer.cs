namespace Downloader
{
    partial class AddTask
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
            button2 = new Button();
            button1 = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            button3 = new Button();
            toolTip1 = new ToolTip(components);
            label3 = new Label();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            label21 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(53, 59);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(438, 174);
            textBox1.TabIndex = 0;
            toolTip1.SetToolTip(textBox1, "视频的唯一标识cid pid fanhao");
            // 
            // button2
            // 
            button2.Location = new Point(415, 243);
            button2.Name = "button2";
            button2.Size = new Size(69, 26);
            button2.TabIndex = 11;
            button2.Text = "取消(&C)";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(310, 243);
            button1.Name = "button1";
            button1.Size = new Size(69, 26);
            button1.TabIndex = 10;
            button1.Text = "确认(&O)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(252, 20);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(95, 25);
            comboBox1.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(216, 24);
            label1.Name = "label1";
            label1.Size = new Size(33, 17);
            label1.TabIndex = 13;
            label1.Text = "type";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 61);
            label2.Name = "label2";
            label2.Size = new Size(25, 17);
            label2.TabIndex = 14;
            label2.Text = "vid";
            // 
            // button3
            // 
            button3.Location = new Point(142, 243);
            button3.Name = "button3";
            button3.Size = new Size(141, 26);
            button3.TabIndex = 15;
            button3.Text = "确定并直接开始(&S)";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 24);
            label3.Name = "label3";
            label3.Size = new Size(47, 17);
            label3.TabIndex = 19;
            label3.Text = "engine";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(53, 20);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(159, 25);
            comboBox2.TabIndex = 20;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "穷逼", "壕无人性" });
            comboBox3.Location = new Point(400, 20);
            comboBox3.Margin = new Padding(2, 2, 2, 2);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(91, 25);
            comboBox3.TabIndex = 26;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(353, 24);
            label21.Name = "label21";
            label21.Size = new Size(42, 17);
            label21.TabIndex = 25;
            label21.Text = "mode";
            // 
            // AddTask
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 282);
            Controls.Add(comboBox3);
            Controls.Add(label21);
            Controls.Add(comboBox2);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddTask";
            Text = "添加任务";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Button button3;
        private ToolTip toolTip1;
        private Label label3;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Label label21;
    }
}