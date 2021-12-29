namespace Plcway.ClientTool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBox_error = new System.Windows.Forms.ListBox();
            this.list_msg = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_msg_clear = new System.Windows.Forms.Button();
            this.txt_args = new System.Windows.Forms.TextBox();
            this.btn_remove = new System.Windows.Forms.Button();
            this.listBox_ip = new System.Windows.Forms.ListBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_run = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.radio_1500 = new System.Windows.Forms.RadioButton();
            this.radio_1200 = new System.Windows.Forms.RadioButton();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1158, 829);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "西门子测试";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox_error);
            this.groupBox3.Controls.Add(this.list_msg);
            this.groupBox3.Location = new System.Drawing.Point(475, 29);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(665, 794);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据";
            // 
            // listBox_error
            // 
            this.listBox_error.FormattingEnabled = true;
            this.listBox_error.ItemHeight = 20;
            this.listBox_error.Location = new System.Drawing.Point(17, 388);
            this.listBox_error.Name = "listBox_error";
            this.listBox_error.Size = new System.Drawing.Size(624, 284);
            this.listBox_error.TabIndex = 1;
            // 
            // list_msg
            // 
            this.list_msg.FormattingEnabled = true;
            this.list_msg.ItemHeight = 20;
            this.list_msg.Location = new System.Drawing.Point(17, 38);
            this.list_msg.Name = "list_msg";
            this.list_msg.Size = new System.Drawing.Size(624, 324);
            this.list_msg.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_msg_clear);
            this.groupBox2.Controls.Add(this.txt_args);
            this.groupBox2.Controls.Add(this.btn_remove);
            this.groupBox2.Controls.Add(this.listBox_ip);
            this.groupBox2.Controls.Add(this.btn_stop);
            this.groupBox2.Controls.Add(this.btn_run);
            this.groupBox2.Controls.Add(this.btn_add);
            this.groupBox2.Controls.Add(this.radio_1500);
            this.groupBox2.Controls.Add(this.radio_1200);
            this.groupBox2.Controls.Add(this.txt_ip);
            this.groupBox2.Location = new System.Drawing.Point(14, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 794);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设置";
            // 
            // btn_msg_clear
            // 
            this.btn_msg_clear.Location = new System.Drawing.Point(307, 672);
            this.btn_msg_clear.Name = "btn_msg_clear";
            this.btn_msg_clear.Size = new System.Drawing.Size(94, 29);
            this.btn_msg_clear.TabIndex = 9;
            this.btn_msg_clear.Text = "清除消息";
            this.btn_msg_clear.UseVisualStyleBackColor = true;
            this.btn_msg_clear.Click += new System.EventHandler(this.btn_msg_clear_Click);
            // 
            // txt_args
            // 
            this.txt_args.Location = new System.Drawing.Point(163, 79);
            this.txt_args.Name = "txt_args";
            this.txt_args.Size = new System.Drawing.Size(63, 27);
            this.txt_args.TabIndex = 3;
            // 
            // btn_remove
            // 
            this.btn_remove.Location = new System.Drawing.Point(326, 78);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(94, 29);
            this.btn_remove.TabIndex = 8;
            this.btn_remove.Text = "移除";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // listBox_ip
            // 
            this.listBox_ip.FormattingEnabled = true;
            this.listBox_ip.ItemHeight = 20;
            this.listBox_ip.Location = new System.Drawing.Point(36, 131);
            this.listBox_ip.Name = "listBox_ip";
            this.listBox_ip.Size = new System.Drawing.Size(267, 484);
            this.listBox_ip.TabIndex = 7;
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(178, 672);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(94, 29);
            this.btn_stop.TabIndex = 6;
            this.btn_stop.Text = "停止";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(36, 667);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(94, 29);
            this.btn_run.TabIndex = 4;
            this.btn_run.Text = "运行";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(242, 77);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(68, 29);
            this.btn_add.TabIndex = 3;
            this.btn_add.Text = "添加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // radio_1500
            // 
            this.radio_1500.AutoSize = true;
            this.radio_1500.Location = new System.Drawing.Point(115, 38);
            this.radio_1500.Name = "radio_1500";
            this.radio_1500.Size = new System.Drawing.Size(66, 24);
            this.radio_1500.TabIndex = 2;
            this.radio_1500.Text = "1500";
            this.radio_1500.UseVisualStyleBackColor = true;
            // 
            // radio_1200
            // 
            this.radio_1200.AutoSize = true;
            this.radio_1200.Checked = true;
            this.radio_1200.Location = new System.Drawing.Point(36, 38);
            this.radio_1200.Name = "radio_1200";
            this.radio_1200.Size = new System.Drawing.Size(66, 24);
            this.radio_1200.TabIndex = 1;
            this.radio_1200.TabStop = true;
            this.radio_1200.Text = "1200";
            this.radio_1200.UseVisualStyleBackColor = true;
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(36, 79);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(111, 27);
            this.txt_ip.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 853);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Tool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox txt_ip;
        private ListBox list_msg;
        private ListBox listBox_error;
        private RadioButton radio_1200;
        private RadioButton radio_1500;
        private Button btn_add;
        private Button btn_run;
        private Button btn_stop;
        private ListBox listBox_ip;
        private Button btn_remove;
        private TextBox txt_args;
        private Button btn_msg_clear;
    }
}