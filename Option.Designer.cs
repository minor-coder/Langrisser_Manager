namespace TaskManager
{
    partial class Option
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
            this.button_Save = new System.Windows.Forms.Button();
            this.checkBox_Tooltip = new System.Windows.Forms.CheckBox();
            this.textBox_BossKey = new System.Windows.Forms.TextBox();
            this.textBox_VolumeUp = new System.Windows.Forms.TextBox();
            this.textBox_VolumeDown = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox_HotKey = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Screenshot = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_MuteKey = new System.Windows.Forms.TextBox();
            this.checkBox_RefreshMute = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_ingameShortcut = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox_cancel = new System.Windows.Forms.TextBox();
            this.textBox_ok = new System.Windows.Forms.TextBox();
            this.textBox_skill1 = new System.Windows.Forms.TextBox();
            this.textBox_skill2 = new System.Windows.Forms.TextBox();
            this.textBox_skill3 = new System.Windows.Forms.TextBox();
            this.textBox_wait = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox_HotKey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Save
            // 
            this.button_Save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Save.Location = new System.Drawing.Point(50, 222);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 1;
            this.button_Save.Text = "저장";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // checkBox_Tooltip
            // 
            this.checkBox_Tooltip.AutoSize = true;
            this.checkBox_Tooltip.Location = new System.Drawing.Point(152, 188);
            this.checkBox_Tooltip.Name = "checkBox_Tooltip";
            this.checkBox_Tooltip.Size = new System.Drawing.Size(116, 16);
            this.checkBox_Tooltip.TabIndex = 2;
            this.checkBox_Tooltip.Text = "윈도우 알림 표시";
            this.checkBox_Tooltip.UseVisualStyleBackColor = true;
            // 
            // textBox_BossKey
            // 
            this.textBox_BossKey.Location = new System.Drawing.Point(107, 20);
            this.textBox_BossKey.Name = "textBox_BossKey";
            this.textBox_BossKey.ReadOnly = true;
            this.textBox_BossKey.Size = new System.Drawing.Size(133, 21);
            this.textBox_BossKey.TabIndex = 3;
            this.textBox_BossKey.Text = "Ctrl + Shift + N";
            this.textBox_BossKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_BossKey_KeyUp);
            // 
            // textBox_VolumeUp
            // 
            this.textBox_VolumeUp.Location = new System.Drawing.Point(107, 46);
            this.textBox_VolumeUp.Name = "textBox_VolumeUp";
            this.textBox_VolumeUp.ReadOnly = true;
            this.textBox_VolumeUp.Size = new System.Drawing.Size(133, 21);
            this.textBox_VolumeUp.TabIndex = 4;
            this.textBox_VolumeUp.Text = "Alt + ↑";
            this.textBox_VolumeUp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_VolumeUp_KeyUp);
            // 
            // textBox_VolumeDown
            // 
            this.textBox_VolumeDown.Location = new System.Drawing.Point(107, 72);
            this.textBox_VolumeDown.Name = "textBox_VolumeDown";
            this.textBox_VolumeDown.ReadOnly = true;
            this.textBox_VolumeDown.Size = new System.Drawing.Size(133, 21);
            this.textBox_VolumeDown.TabIndex = 5;
            this.textBox_VolumeDown.Text = "Alt + ↓";
            this.textBox_VolumeDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_VolumeDown_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Boss Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Volume Up";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Volume Down";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(157, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "취소";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox_HotKey
            // 
            this.groupBox_HotKey.Controls.Add(this.label5);
            this.groupBox_HotKey.Controls.Add(this.textBox_Screenshot);
            this.groupBox_HotKey.Controls.Add(this.label4);
            this.groupBox_HotKey.Controls.Add(this.textBox_MuteKey);
            this.groupBox_HotKey.Controls.Add(this.textBox_VolumeUp);
            this.groupBox_HotKey.Controls.Add(this.textBox_BossKey);
            this.groupBox_HotKey.Controls.Add(this.label3);
            this.groupBox_HotKey.Controls.Add(this.textBox_VolumeDown);
            this.groupBox_HotKey.Controls.Add(this.label2);
            this.groupBox_HotKey.Controls.Add(this.label1);
            this.groupBox_HotKey.Location = new System.Drawing.Point(12, 12);
            this.groupBox_HotKey.Name = "groupBox_HotKey";
            this.groupBox_HotKey.Size = new System.Drawing.Size(256, 160);
            this.groupBox_HotKey.TabIndex = 10;
            this.groupBox_HotKey.TabStop = false;
            this.groupBox_HotKey.Text = "단축키";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "Screenshot Key";
            // 
            // textBox_Screenshot
            // 
            this.textBox_Screenshot.Location = new System.Drawing.Point(107, 125);
            this.textBox_Screenshot.Name = "textBox_Screenshot";
            this.textBox_Screenshot.ReadOnly = true;
            this.textBox_Screenshot.Size = new System.Drawing.Size(133, 21);
            this.textBox_Screenshot.TabIndex = 11;
            this.textBox_Screenshot.Text = "Ctrl + Shift + S";
            this.textBox_Screenshot.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_Screenshot_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "Mute Key";
            // 
            // textBox_MuteKey
            // 
            this.textBox_MuteKey.Location = new System.Drawing.Point(107, 98);
            this.textBox_MuteKey.Name = "textBox_MuteKey";
            this.textBox_MuteKey.ReadOnly = true;
            this.textBox_MuteKey.Size = new System.Drawing.Size(133, 21);
            this.textBox_MuteKey.TabIndex = 9;
            this.textBox_MuteKey.Text = "Ctrl + M";
            this.textBox_MuteKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_MuteKey_KeyUp);
            // 
            // checkBox_RefreshMute
            // 
            this.checkBox_RefreshMute.AutoSize = true;
            this.checkBox_RefreshMute.Location = new System.Drawing.Point(20, 188);
            this.checkBox_RefreshMute.Name = "checkBox_RefreshMute";
            this.checkBox_RefreshMute.Size = new System.Drawing.Size(124, 16);
            this.checkBox_RefreshMute.TabIndex = 11;
            this.checkBox_RefreshMute.Text = "새로고침시 음소거";
            this.checkBox_RefreshMute.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::TaskManager.Properties.Resources.skill;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(577, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(239, 235);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_ingameShortcut
            // 
            this.textBox_ingameShortcut.Location = new System.Drawing.Point(415, 32);
            this.textBox_ingameShortcut.Name = "textBox_ingameShortcut";
            this.textBox_ingameShortcut.ReadOnly = true;
            this.textBox_ingameShortcut.Size = new System.Drawing.Size(133, 21);
            this.textBox_ingameShortcut.TabIndex = 13;
            this.textBox_ingameShortcut.Text = "Ctrl + Shift + S";
            this.textBox_ingameShortcut.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_ingameShortcut_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(312, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "Ingame Shortcut";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::TaskManager.Properties.Resources.ok_cancel;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(309, 126);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(239, 106);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // textBox_cancel
            // 
            this.textBox_cancel.Location = new System.Drawing.Point(339, 195);
            this.textBox_cancel.Name = "textBox_cancel";
            this.textBox_cancel.ReadOnly = true;
            this.textBox_cancel.Size = new System.Drawing.Size(46, 21);
            this.textBox_cancel.TabIndex = 16;
            this.textBox_cancel.Text = "A";
            this.textBox_cancel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_cancel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_cancel_KeyUp);
            // 
            // textBox_ok
            // 
            this.textBox_ok.Location = new System.Drawing.Point(472, 195);
            this.textBox_ok.Name = "textBox_ok";
            this.textBox_ok.ReadOnly = true;
            this.textBox_ok.Size = new System.Drawing.Size(46, 21);
            this.textBox_ok.TabIndex = 17;
            this.textBox_ok.Text = "Space";
            this.textBox_ok.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ok.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_ok_KeyUp);
            // 
            // textBox_skill1
            // 
            this.textBox_skill1.Location = new System.Drawing.Point(604, 209);
            this.textBox_skill1.Name = "textBox_skill1";
            this.textBox_skill1.ReadOnly = true;
            this.textBox_skill1.Size = new System.Drawing.Size(46, 21);
            this.textBox_skill1.TabIndex = 18;
            this.textBox_skill1.Text = "W";
            this.textBox_skill1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_skill1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_skill1_KeyUp);
            // 
            // textBox_skill2
            // 
            this.textBox_skill2.Location = new System.Drawing.Point(661, 126);
            this.textBox_skill2.Name = "textBox_skill2";
            this.textBox_skill2.ReadOnly = true;
            this.textBox_skill2.Size = new System.Drawing.Size(46, 21);
            this.textBox_skill2.TabIndex = 19;
            this.textBox_skill2.Text = "E";
            this.textBox_skill2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_skill2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_skill2_KeyUp);
            // 
            // textBox_skill3
            // 
            this.textBox_skill3.Location = new System.Drawing.Point(743, 73);
            this.textBox_skill3.Name = "textBox_skill3";
            this.textBox_skill3.ReadOnly = true;
            this.textBox_skill3.Size = new System.Drawing.Size(46, 21);
            this.textBox_skill3.TabIndex = 20;
            this.textBox_skill3.Text = "R";
            this.textBox_skill3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_skill3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_skill3_KeyUp);
            // 
            // textBox_wait
            // 
            this.textBox_wait.Location = new System.Drawing.Point(735, 200);
            this.textBox_wait.Name = "textBox_wait";
            this.textBox_wait.ReadOnly = true;
            this.textBox_wait.Size = new System.Drawing.Size(46, 21);
            this.textBox_wait.TabIndex = 21;
            this.textBox_wait.Text = "Space";
            this.textBox_wait.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_wait.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_wait_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(312, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "스킬 확인 버튼";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(593, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 12);
            this.label8.TabIndex = 23;
            this.label8.Text = "스킬 버튼";
            // 
            // Option
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 259);
            this.ControlBox = false;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_wait);
            this.Controls.Add(this.textBox_skill3);
            this.Controls.Add(this.textBox_skill2);
            this.Controls.Add(this.textBox_skill1);
            this.Controls.Add(this.textBox_ok);
            this.Controls.Add(this.textBox_cancel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBox_ingameShortcut);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBox_RefreshMute);
            this.Controls.Add(this.groupBox_HotKey);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox_Tooltip);
            this.Controls.Add(this.button_Save);
            this.Name = "Option";
            this.Text = "설정";
            this.groupBox_HotKey.ResumeLayout(false);
            this.groupBox_HotKey.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.CheckBox checkBox_Tooltip;
        private System.Windows.Forms.TextBox textBox_BossKey;
        private System.Windows.Forms.TextBox textBox_VolumeUp;
        private System.Windows.Forms.TextBox textBox_VolumeDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox_HotKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_MuteKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Screenshot;
        private System.Windows.Forms.CheckBox checkBox_RefreshMute;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_ingameShortcut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox_cancel;
        private System.Windows.Forms.TextBox textBox_ok;
        private System.Windows.Forms.TextBox textBox_skill1;
        private System.Windows.Forms.TextBox textBox_skill2;
        private System.Windows.Forms.TextBox textBox_skill3;
        private System.Windows.Forms.TextBox textBox_wait;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}