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
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_MuteKey = new System.Windows.Forms.TextBox();
            this.groupBox_HotKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Save
            // 
            this.button_Save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Save.Location = new System.Drawing.Point(49, 196);
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
            this.checkBox_Tooltip.Location = new System.Drawing.Point(84, 163);
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
            this.button1.Location = new System.Drawing.Point(156, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "취소";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox_HotKey
            // 
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
            this.groupBox_HotKey.Size = new System.Drawing.Size(256, 133);
            this.groupBox_HotKey.TabIndex = 10;
            this.groupBox_HotKey.TabStop = false;
            this.groupBox_HotKey.Text = "단축키";
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
            // Option
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 229);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox_HotKey);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox_Tooltip);
            this.Controls.Add(this.button_Save);
            this.Name = "Option";
            this.Text = "설정";
            this.groupBox_HotKey.ResumeLayout(false);
            this.groupBox_HotKey.PerformLayout();
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
    }
}