namespace TaskManager
{
    partial class TaskManager
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskManager));
            this.pictureBox_ProcessStatus = new System.Windows.Forms.PictureBox();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.클라숨기기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새로고침ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.button_Hide = new System.Windows.Forms.Button();
            this.trackBar_sound = new System.Windows.Forms.TrackBar();
            this.button_mute = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ProcessStatus)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_sound)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_ProcessStatus
            // 
            this.pictureBox_ProcessStatus.BackColor = System.Drawing.Color.Red;
            this.pictureBox_ProcessStatus.Location = new System.Drawing.Point(152, 223);
            this.pictureBox_ProcessStatus.Name = "pictureBox_ProcessStatus";
            this.pictureBox_ProcessStatus.Size = new System.Drawing.Size(52, 52);
            this.pictureBox_ProcessStatus.TabIndex = 0;
            this.pictureBox_ProcessStatus.TabStop = false;
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(34, 252);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(85, 23);
            this.button_Refresh.TabIndex = 1;
            this.button_Refresh.Text = "새로고침";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "프로그램이 실행 중 입니다.";
            this.notifyIcon.BalloonTipTitle = "작업 관리자";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "작업 관리자";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.클라숨기기ToolStripMenuItem,
            this.새로고침ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.종료ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(139, 76);
            // 
            // 클라숨기기ToolStripMenuItem
            // 
            this.클라숨기기ToolStripMenuItem.Name = "클라숨기기ToolStripMenuItem";
            this.클라숨기기ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.클라숨기기ToolStripMenuItem.Text = "클라 숨기기";
            this.클라숨기기ToolStripMenuItem.Click += new System.EventHandler(this.클라숨기기ToolStripMenuItem_Click);
            // 
            // 새로고침ToolStripMenuItem
            // 
            this.새로고침ToolStripMenuItem.Name = "새로고침ToolStripMenuItem";
            this.새로고침ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.새로고침ToolStripMenuItem.Text = "새로고침";
            this.새로고침ToolStripMenuItem.Click += new System.EventHandler(this.새로고침ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(135, 6);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::TaskManager.Properties.Resources.w6;
            this.pictureBox.Location = new System.Drawing.Point(34, 37);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(170, 170);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // button_Hide
            // 
            this.button_Hide.Location = new System.Drawing.Point(34, 223);
            this.button_Hide.Name = "button_Hide";
            this.button_Hide.Size = new System.Drawing.Size(85, 23);
            this.button_Hide.TabIndex = 4;
            this.button_Hide.Text = "클라 숨기기";
            this.button_Hide.UseVisualStyleBackColor = true;
            this.button_Hide.Click += new System.EventHandler(this.button_Hide_Click);
            // 
            // trackBar_sound
            // 
            this.trackBar_sound.LargeChange = 30;
            this.trackBar_sound.Location = new System.Drawing.Point(237, 37);
            this.trackBar_sound.Maximum = 100;
            this.trackBar_sound.Name = "trackBar_sound";
            this.trackBar_sound.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_sound.Size = new System.Drawing.Size(45, 200);
            this.trackBar_sound.SmallChange = 10;
            this.trackBar_sound.TabIndex = 5;
            this.trackBar_sound.TickFrequency = 5;
            this.trackBar_sound.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_sound.Scroll += new System.EventHandler(this.trackBar_sound_Scroll);
            // 
            // button_mute
            // 
            this.button_mute.Image = global::TaskManager.Properties.Resources.Mute;
            this.button_mute.Location = new System.Drawing.Point(239, 239);
            this.button_mute.Name = "button_mute";
            this.button_mute.Size = new System.Drawing.Size(36, 36);
            this.button_mute.TabIndex = 6;
            this.button_mute.UseVisualStyleBackColor = true;
            this.button_mute.Click += new System.EventHandler(this.button_mute_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(314, 24);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientHideToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.fileToolStripMenuItem.Text = "파일";
            // 
            // clientHideToolStripMenuItem
            // 
            this.clientHideToolStripMenuItem.Name = "clientHideToolStripMenuItem";
            this.clientHideToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.clientHideToolStripMenuItem.Text = "클라 숨기기";
            this.clientHideToolStripMenuItem.Click += new System.EventHandler(this.clientHideToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.refreshToolStripMenuItem.Text = "새로고침";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(135, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.exitToolStripMenuItem.Text = "종료";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.optionToolStripMenuItem.Text = "옵션";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingToolStripMenuItem.Text = "설정";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.infoToolStripMenuItem.Text = "정보";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // TaskManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 291);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.button_mute);
            this.Controls.Add(this.trackBar_sound);
            this.Controls.Add(this.button_Hide);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.pictureBox_ProcessStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "TaskManager";
            this.Text = "작업 관리자";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ProcessStatus)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_sound)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_ProcessStatus;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 새로고침ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 클라숨기기ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button button_Hide;
        private System.Windows.Forms.TrackBar trackBar_sound;
        private System.Windows.Forms.Button button_mute;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem clientHideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
    }
}

