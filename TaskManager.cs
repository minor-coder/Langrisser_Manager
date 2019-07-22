using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace TaskManager
{
    public partial class TaskManager : Form
    {
        public Process _Process = null;
        public bool _isHide = false;
        public bool _isMute = true;

        public List<Image> _ListWeapon = null;

        [DllImport("user32")]
        public static extern int ShowWindow(int hwnd, int nCmdShow);
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int BOSSKEY_ID = 0;
        const int VOLUMEUPKEY_ID = 1;
        const int VOLUMEDOWNKEY_ID = 2;
        const int MUTEKEY_ID = 3;

        const int WM_HOTKEY = 0x0312;

        protected override void WndProc(ref Message message)
        {
            if (message.Msg == WM_HOTKEY)
            {
                Keys key = (Keys)(((int)message.LParam >> 16) & 0xFFFF);
                KeyModifiers modifier = (KeyModifiers)((int)message.LParam & 0xFFFF);

                // BossKey
                if ((KeyModifiers)(Properties.Settings.Default.BossKeyModifiers) == modifier && (Keys)(Properties.Settings.Default.BossKey) == key)
                {
                    HideClient();
                }

                // Volume Up
                if ((KeyModifiers)(Properties.Settings.Default.VolumeUpModifiers) == modifier && (Keys)(Properties.Settings.Default.VolumeUpKey) == key)
                {
                    if (100 - 5 < trackBar_sound.Value)
                        trackBar_sound.Value = 100;
                    else
                        trackBar_sound.Value += 5;

                    if(null != _Process)
                        VolumeMixer.SetApplicationVolume(_Process.Id, trackBar_sound.Value);
                }

                // Volume Down
                if ((KeyModifiers)(Properties.Settings.Default.VolumeDownModifiers) == modifier && (Keys)(Properties.Settings.Default.VolumeDownKey) == key)
                {
                    if (5 > trackBar_sound.Value)
                        trackBar_sound.Value = 0;
                    else
                        trackBar_sound.Value -= 5;

                    if (null != _Process)
                        VolumeMixer.SetApplicationVolume(_Process.Id, trackBar_sound.Value);
                }

                // MuteKey
                if ((KeyModifiers)(Properties.Settings.Default.MuteKeyModifiers) == modifier && (Keys)(Properties.Settings.Default.MuteKey) == key)
                {
                    if (true == _isMute)
                    {
                        _isMute = false;
                        button_mute.Image = Properties.Resources.Speaker;
                        if (null != _Process)
                            VolumeMixer.SetApplicationMute(_Process.Id, false);
                    }
                    else
                    {
                        _isMute = true;
                        button_mute.Image = Properties.Resources.Mute;
                        if (null != _Process)
                            VolumeMixer.SetApplicationMute(_Process.Id, true);
                    }
                }
            }

            base.WndProc(ref message);
        }

        public TaskManager()
        {
            InitializeComponent();
            InitForm();
        }

        public void InitForm()
        {
            this.Icon = Properties.Resources.taskmanager;

            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            notifyIcon.ContextMenuStrip = contextMenuStrip;

            notifyIcon.ShowBalloonTip(2000);

            if (SearchProcess())
            {
                VolumeMixer.SetApplicationMute(_Process.Id, true);
                VolumeMixer.SetApplicationVolume(_Process.Id, 0f);
            }

            _ListWeapon = new List<Image>();
            InitWeaponList();

            RandomWeapon();

            HotKeyRegister();
        }

        public void RandomWeapon()
        {
            Random r = new Random();
            int weapon = r.Next(0, 33);

            pictureBox.Image = _ListWeapon[weapon];
        }

        public void InitWeaponList()
        {
            _ListWeapon.Add(Properties.Resources.w1);
            _ListWeapon.Add(Properties.Resources.w2);
            _ListWeapon.Add(Properties.Resources.w3);
            _ListWeapon.Add(Properties.Resources.w4);
            _ListWeapon.Add(Properties.Resources.w5);
            _ListWeapon.Add(Properties.Resources.w6);
            _ListWeapon.Add(Properties.Resources.w7);
            _ListWeapon.Add(Properties.Resources.w8);
            _ListWeapon.Add(Properties.Resources.w9);
            _ListWeapon.Add(Properties.Resources.w10);
            _ListWeapon.Add(Properties.Resources.w11);
            _ListWeapon.Add(Properties.Resources.w12);
            _ListWeapon.Add(Properties.Resources.w13);
            _ListWeapon.Add(Properties.Resources.w14);
            _ListWeapon.Add(Properties.Resources.w15);
            _ListWeapon.Add(Properties.Resources.w16);
            _ListWeapon.Add(Properties.Resources.w17);
            _ListWeapon.Add(Properties.Resources.w18);
            _ListWeapon.Add(Properties.Resources.w19);
            _ListWeapon.Add(Properties.Resources.w20);
            _ListWeapon.Add(Properties.Resources.w21);
            _ListWeapon.Add(Properties.Resources.w22);
            _ListWeapon.Add(Properties.Resources.w23);
            _ListWeapon.Add(Properties.Resources.w24);
            _ListWeapon.Add(Properties.Resources.w25);
            _ListWeapon.Add(Properties.Resources.w26);
            _ListWeapon.Add(Properties.Resources.w27);
            _ListWeapon.Add(Properties.Resources.w28);
            _ListWeapon.Add(Properties.Resources.w29);
            _ListWeapon.Add(Properties.Resources.w30);
            _ListWeapon.Add(Properties.Resources.w31);
            _ListWeapon.Add(Properties.Resources.w32);
            _ListWeapon.Add(Properties.Resources.w33);
        }

        public bool SearchProcess()
        {
            Process[] processList = Process.GetProcessesByName("Langrisser");

            if (1 > processList.Length || 1 < processList.Length)
            {
                notifyIcon.Icon = Properties.Resources.Red;
                pictureBox_ProcessStatus.BackColor = Color.Red;
                if (null != _Process)
                {
                    _Process.Dispose();
                    _Process = null;
                }

                return false;
            }

            if (null != _Process)
            {
                _Process.Dispose();
                _Process = null;
            }

            _Process = processList[0];
            notifyIcon.Icon = Properties.Resources.Green;
            pictureBox_ProcessStatus.BackColor = Color.Lime;
            return true;
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            SearchProcess();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                Show();

                HotKeyUnregister();
                HotKeyRegister();
            }
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(null != _Process)
                ShowWindow((int)_Process.MainWindowHandle, SW_SHOW);

            HotKeyUnregister();
            Application.Exit();
        }

        private void 새로고침ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchProcess();
        }

        private void trackBar_sound_Scroll(object sender, EventArgs e)
        {
            if (null == _Process)
                return;

            if (0 == _Process.Id)
                return;

            VolumeMixer.SetApplicationVolume(_Process.Id, trackBar_sound.Value);
        }

        private void HideClient()
        {
            if (null == _Process)
                return;

            IntPtr handle = _Process.MainWindowHandle;

            if (true == _isHide)
            {
                _isHide = false;
                ShowWindow((int)handle, SW_SHOW);
                button_Hide.Text = "클라 숨기기";
                클라숨기기ToolStripMenuItem.Text = "클라 숨기기";
                clientHideToolStripMenuItem.Text = "클라 숨기기";
            }
            else
            {
                _isHide = true;
                ShowWindow((int)handle, SW_HIDE);
                button_Hide.Text = "클라 띄우기";
                클라숨기기ToolStripMenuItem.Text = "클라 띄우기";
                clientHideToolStripMenuItem.Text = "클라 띄우기";

                _isMute = true;
                button_mute.Image = Properties.Resources.Mute;
                VolumeMixer.SetApplicationMute(_Process.Id, true);
            }
        }

        private void button_Hide_Click(object sender, EventArgs e)
        {
            HideClient();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();

                if(Properties.Settings.Default.isBalloon)
                    notifyIcon.ShowBalloonTip(2000);
            }
        }

        public void HotKeyUnregister()
        {
            UnregisterHotKey(this.Handle, BOSSKEY_ID);
            UnregisterHotKey(this.Handle, VOLUMEUPKEY_ID);
            UnregisterHotKey(this.Handle, VOLUMEDOWNKEY_ID);
            UnregisterHotKey(this.Handle, MUTEKEY_ID);
        }

        public void HotKeyRegister()
        {
            KeyModifiers modifier = (KeyModifiers)(Properties.Settings.Default.BossKeyModifiers);
            Keys key = (Keys)(Properties.Settings.Default.BossKey);
            RegisterHotKey(this.Handle, BOSSKEY_ID, modifier, key);

            modifier = (KeyModifiers)(Properties.Settings.Default.VolumeUpModifiers);
            key = (Keys)(Properties.Settings.Default.VolumeUpKey);
            RegisterHotKey(this.Handle, VOLUMEUPKEY_ID, modifier, key);

            modifier = (KeyModifiers)(Properties.Settings.Default.VolumeDownModifiers);
            key = (Keys)(Properties.Settings.Default.VolumeDownKey);
            RegisterHotKey(this.Handle, VOLUMEDOWNKEY_ID, modifier, key);

            modifier = (KeyModifiers)(Properties.Settings.Default.MuteKeyModifiers);
            key = (Keys)(Properties.Settings.Default.MuteKey);
            RegisterHotKey(this.Handle, MUTEKEY_ID, modifier, key);

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null != _Process)
                ShowWindow((int)_Process.MainWindowHandle, SW_SHOW);

            HotKeyUnregister();
            Application.Exit();
        }

        private void button_mute_Click(object sender, EventArgs e)
        {
            if(true == _isMute)
            {
                _isMute = false;
                button_mute.Image = Properties.Resources.Speaker;
                if(null != _Process)
                    VolumeMixer.SetApplicationMute(_Process.Id, false);
            }
            else
            {
                _isMute = true;
                button_mute.Image = Properties.Resources.Mute;
                if (null != _Process)
                    VolumeMixer.SetApplicationMute(_Process.Id, true);
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            RandomWeapon();
        }

        private void 클라숨기기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideClient();
        }

        private void clientHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideClient();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchProcess();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotKeyUnregister();

            Option op = new Option();
            op.InitOption(this);
            op.ShowDialog();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.ShowDialog();
        }
    }
}
