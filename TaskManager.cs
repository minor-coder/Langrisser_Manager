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
using System.Drawing.Imaging;

namespace TaskManager
{
    public partial class TaskManager : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT point;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        public Process _Process = null;
        public bool _isMute = true;
        public bool _isSkillPush = false;
        public bool _isUsingChat = false;

        public static TaskManager _this;
        private static Win32.HookProc MouseHookProcedure;

        public List<Image> _ListWeapon = null;
        
        public UILocation _LocSkill1 = new UILocation(312, 90, UILocation.Direction.RB);
        public UILocation _LocSkill2 = new UILocation(222, 218, UILocation.Direction.RB);
        public UILocation _LocSkill3 = new UILocation(90, 302, UILocation.Direction.RB);
        public UILocation _LocOK = new UILocation(105, 105, UILocation.Direction.RB);
        public UILocation _LocCancel = new UILocation(267, 105, UILocation.Direction.RB);
        public UILocation _LocWait = new UILocation(105, 103, UILocation.Direction.RB);
        public UILocation _LocChatLT = new UILocation(-25, 271, UILocation.Direction.LB);
        public UILocation _LocChatRB = new UILocation(-99, 197, UILocation.Direction.LB);
        public UILocation _LocChatXLT = new UILocation(-775, 0, UILocation.Direction.LT);
        public UILocation _LocChatXRB = new UILocation(-848, -73, UILocation.Direction.LT);

        private const int BOSSKEY_ID = 0;
        private const int VOLUMEUPKEY_ID = 1;
        private const int VOLUMEDOWNKEY_ID = 2;
        private const int MUTEKEY_ID = 3;
        private const int SCREENSHOT_ID = 4;
        
        private const int SKILL1_ID = 5;
        private const int SKILL2_ID = 6;
        private const int SKILL3_ID = 7;
        private const int OK_ID = 8;
        private const int CANCEL_ID = 9;
        private const int WAIT_ID = 10;
        private const int INGAMESHORTCUT_ID = 11;

        private const int MANUALSHORTCUTSTART_ID = 50;

        private const int ESC_ID = 12;

        public const int MAX_CLIENT_SIZE_X = 1600;
        public const int MAX_CLIENT_SIZE_Y = 900;

        private static int c_hook = 0;

        public const float MAX_CLIENT_ASPECT_RATIO = 1600f / 900f;

        public TaskManager()
        {
            InitializeComponent();
            InitForm();
        }

        public void InitForm()
        {
            _this = this;
            this.Icon = Properties.Resources.taskmanager;

            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            notifyIcon.ContextMenuStrip = contextMenuStrip;

            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.BalloonTipTitle = "작업 관리자";
            notifyIcon.BalloonTipText = "프로그램이 실행 중 입니다.";
            notifyIcon.ShowBalloonTip(2000);

            SearchProcess();

            _ListWeapon = new List<Image>();

            HotKeyRegister();
        }

        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }

        // Windows Message Catcher
        protected override void WndProc(ref Message message)
        {
            if (message.Msg == Win32.WM_HOTKEY)
            {
                Keys key = (Keys)(((int)message.LParam >> 16) & 0xFFFF);
                KeyModifiers modifier = (KeyModifiers)((int)message.LParam & 0xFFFF);
                
                // BossKey
                if ((KeyModifiers)(Properties.Settings.Default.BossKeyModifiers) == modifier && (Keys)(Properties.Settings.Default.BossKey) == key)
                {
                    if(null != _Process)
                    {
                        if (true == checkBox_Hide.Checked)
                            checkBox_Hide.Checked = false;
                        else
                            checkBox_Hide.Checked = true;
                    }
                }

                // Volume Up
                else if ((KeyModifiers)(Properties.Settings.Default.VolumeUpModifiers) == modifier && (Keys)(Properties.Settings.Default.VolumeUpKey) == key)
                {
                    if (100 - 5 < trackBar_sound.Value)
                        trackBar_sound.Value = 100;
                    else
                        trackBar_sound.Value += 5;

                    if(null != _Process)
                        VolumeMixer.SetApplicationVolume(_Process.Id, trackBar_sound.Value);
                }

                // Volume Down
                else if ((KeyModifiers)(Properties.Settings.Default.VolumeDownModifiers) == modifier && (Keys)(Properties.Settings.Default.VolumeDownKey) == key)
                {
                    if (5 > trackBar_sound.Value)
                        trackBar_sound.Value = 0;
                    else
                        trackBar_sound.Value -= 5;

                    if (null != _Process)
                        VolumeMixer.SetApplicationVolume(_Process.Id, trackBar_sound.Value);
                }

                // MuteKey
                else if ((KeyModifiers)(Properties.Settings.Default.MuteKeyModifiers) == modifier && (Keys)(Properties.Settings.Default.MuteKey) == key)
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

                // Screenshot
                else if ((KeyModifiers)(Properties.Settings.Default.ScreenshotModifiers) == modifier && (Keys)(Properties.Settings.Default.ScreenshotKey) == key)
                {
                    Screenshot();
                }

                // IngameShortcut
                else if ((KeyModifiers)(Properties.Settings.Default.IngameShortcutModifiers) == modifier && (Keys)(Properties.Settings.Default.IngameShortcutKey) == key)
                {
                    if(null != _Process)
                    {
                        if (true == checkBox_IngameShortcut.Checked)
                            checkBox_IngameShortcut.Checked = false;
                        else
                            checkBox_IngameShortcut.Checked = true;
                    }
                }

                // Skill1
                else if (KeyModifiers.None == modifier && (Keys)(Properties.Settings.Default.Skill1Key) == key)
                {
                    IngameHotKey(_LocSkill1);
                    _isSkillPush = true;
                }

                // Skill2
                else if (KeyModifiers.None == modifier && (Keys)(Properties.Settings.Default.Skill2Key) == key)
                {
                    IngameHotKey(_LocSkill2);
                    _isSkillPush = true;
                }

                // Skill3
                else if (KeyModifiers.None == modifier && (Keys)(Properties.Settings.Default.Skill3Key) == key)
                {
                    IngameHotKey(_LocSkill3);
                    _isSkillPush = true;
                }

                // OK
                else if (KeyModifiers.None == modifier && (Keys)(Properties.Settings.Default.OKKey) == key)
                {
                    IngameHotKey(_LocOK);
                }

                // CANCEL
                else if (KeyModifiers.None == modifier && (Keys)(Properties.Settings.Default.CancelKey) == key)
                {
                    IngameHotKey(_LocCancel);
                }

                // WAIT
                else if (KeyModifiers.None == modifier && (Keys)(Properties.Settings.Default.WaitKey) == key)
                {
                    IngameHotKey(_LocWait);
                }

                // ESC
                else if (KeyModifiers.None == modifier && Keys.Escape == key)
                {
                    if (null != _Process)
                    {
                        if(true == _isUsingChat)
                        {
                            _isUsingChat = false;

                            if (true == Properties.Settings.Default.isBalloon)
                            {
                                _this.notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                                _this.notifyIcon.BalloonTipTitle = "작업 관리자";
                                _this.notifyIcon.BalloonTipText = "인게임 채팅모드 종료.";
                                _this.notifyIcon.ShowBalloonTip(2000);
                            }

                            _this.IngameShortCutKeyRegister();
                            Win32.UnregisterHotKey(_this.Handle, ESC_ID);
                        }
                    }

                    int info = 0;
                    Win32.keybd_event(Win32.VK_ESCAPE, 0, Win32.KE_DOWN, ref info);
                    Win32.keybd_event(Win32.VK_ESCAPE, 0, Win32.KE_UP, ref info);
                }
                else
                {
                    foreach (UILocation uiLocation in Properties.Settings.Default.ManualInagmeShortcutList)
                    {
                        if (KeyModifiers.None == modifier && uiLocation.key == key)
                        {
                            if (false == uiLocation.isUsing)
                            {
                                break;
                            }

                            IngameHotKey(uiLocation);
                            break;
                        }
                    }
                }
                
            }

            base.WndProc(ref message);
        }


        // Win32 Hooking
        // ===================================================================================

        public static void HookRegister()
        {
            if(c_hook == 0)
            {
                MouseHookProcedure = new Win32.HookProc(HookCallBack);
                c_hook = Win32.SetWindowsHookEx(Win32.WH_MOUSE_LL, MouseHookProcedure, IntPtr.Zero, 0);
            }
        }

        private static void HookUnregister()
        {
            Win32.UnhookWindowsHookEx(c_hook);
            c_hook = 0;
            MouseHookProcedure = null;
        }

        public static int HookCallBack(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if(null == _this._Process)
                return Win32.CallNextHookEx(c_hook, nCode, wParam, lParam);

            if (nCode >= 0 && MouseMessages.WM_LBUTTONUP == (MouseMessages)wParam)
            {
                MouseHookStruct mouseInput = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));

                if(false == _this._isUsingChat)
                {
                    Point LT = _this.PointToResponsiveWindow(_this._LocChatLT);
                    Point RB = _this.PointToResponsiveWindow(_this._LocChatRB);
                    Rectangle chatRect = new Rectangle(LT.X, LT.Y, RB.X - LT.X, RB.Y - LT.Y);

                    //Point center = _this.PointToResponsiveWindow(_this._LocSkill1);
                    //Rectangle skill1Rect = new Rectangle(center.X - 77, center.Y - 77, 155, 155);

                    //center = _this.PointToResponsiveWindow(_this._LocSkill2);
                    //Rectangle skill2Rect = new Rectangle(center.X - 77, center.Y - 77, 155, 155);

                    //center = _this.PointToResponsiveWindow(_this._LocSkill3);
                    //Rectangle skill3Rect = new Rectangle(center.X - 77, center.Y - 77, 155, 155);

                    if (chatRect.Contains(mouseInput.point.x, mouseInput.point.y))
                    {
                        _this._isUsingChat = true;

                        if(true == Properties.Settings.Default.isBalloon)
                        {
                            _this.notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                            _this.notifyIcon.BalloonTipTitle = "작업 관리자";
                            _this.notifyIcon.BalloonTipText = "인게임 채팅모드 시작.";
                            _this.notifyIcon.ShowBalloonTip(2000);
                        }

                        Win32.RegisterHotKey(_this.Handle, ESC_ID, KeyModifiers.None, Keys.Escape);

                        _this.IngameShortCutKeyUnregister();
                    }
                }
                else
                {
                    Point LT = _this.PointToResponsiveWindow(_this._LocChatXLT);
                    Point RB = _this.PointToResponsiveWindow(_this._LocChatXRB);
                    Rectangle chatXRect = new Rectangle(LT.X, LT.Y, RB.X - LT.X, RB.Y - LT.Y);

                    if (chatXRect.Contains(mouseInput.point.x, mouseInput.point.y))
                    {
                        _this._isUsingChat = false;

                        if (true == Properties.Settings.Default.isBalloon)
                        {
                            _this.notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                            _this.notifyIcon.BalloonTipTitle = "작업 관리자";
                            _this.notifyIcon.BalloonTipText = "인게임 채팅모드 종료.";
                            _this.notifyIcon.ShowBalloonTip(2000);
                        }

                        Win32.UnregisterHotKey(_this.Handle, ESC_ID);

                        _this.IngameShortCutKeyRegister();
                    }
                }
            }

            return Win32.CallNextHookEx(c_hook, nCode, wParam, lParam);
        }

        // ===================================================================================


        // HotKey
        // ===================================================================================

        public void HotKeyUnregister()
        {
            Win32.UnregisterHotKey(this.Handle, BOSSKEY_ID);
            Win32.UnregisterHotKey(this.Handle, VOLUMEUPKEY_ID);
            Win32.UnregisterHotKey(this.Handle, VOLUMEDOWNKEY_ID);
            Win32.UnregisterHotKey(this.Handle, MUTEKEY_ID);
            Win32.UnregisterHotKey(this.Handle, SCREENSHOT_ID);
            Win32.UnregisterHotKey(this.Handle, INGAMESHORTCUT_ID);
        }

        public void HotKeyRegister()
        {
            KeyModifiers modifier = (KeyModifiers)(Properties.Settings.Default.BossKeyModifiers);
            Keys key = (Keys)(Properties.Settings.Default.BossKey);
            Win32.RegisterHotKey(this.Handle, BOSSKEY_ID, modifier, key);

            modifier = (KeyModifiers)(Properties.Settings.Default.VolumeUpModifiers);
            key = (Keys)(Properties.Settings.Default.VolumeUpKey);
            Win32.RegisterHotKey(this.Handle, VOLUMEUPKEY_ID, modifier, key);

            modifier = (KeyModifiers)(Properties.Settings.Default.VolumeDownModifiers);
            key = (Keys)(Properties.Settings.Default.VolumeDownKey);
            Win32.RegisterHotKey(this.Handle, VOLUMEDOWNKEY_ID, modifier, key);

            modifier = (KeyModifiers)(Properties.Settings.Default.MuteKeyModifiers);
            key = (Keys)(Properties.Settings.Default.MuteKey);
            Win32.RegisterHotKey(this.Handle, MUTEKEY_ID, modifier, key);

            modifier = (KeyModifiers)(Properties.Settings.Default.ScreenshotModifiers);
            key = (Keys)(Properties.Settings.Default.ScreenshotKey);
            Win32.RegisterHotKey(this.Handle, SCREENSHOT_ID, modifier, key);

            modifier = (KeyModifiers)(Properties.Settings.Default.IngameShortcutModifiers);
            key = (Keys)(Properties.Settings.Default.IngameShortcutKey);
            Win32.RegisterHotKey(this.Handle, INGAMESHORTCUT_ID, modifier, key);
        }

        // ===================================================================================


        // Ingame HotKey
        // ===================================================================================

        public Point PointToResponsiveWindow(UILocation uiLocation)
        {
            if (null == _Process)
                return new Point(0, 0);

            Rect rect;
            Win32.GetClientRect(_Process.MainWindowHandle, out rect);

            Point ptBasePoint;
            switch (uiLocation.dir)
            {
                case UILocation.Direction.LT:
                    ptBasePoint = new Point(rect.Left, rect.Top);
                    break;
                case UILocation.Direction.CT:
                    ptBasePoint = new Point((rect.Right - rect.Left) / 2 + rect.Left, rect.Top);
                    break;
                case UILocation.Direction.RT:
                    ptBasePoint = new Point(rect.Right, rect.Top);
                    break;
                case UILocation.Direction.LC:
                    ptBasePoint = new Point(rect.Left, (rect.Bottom - rect.Top) / 2 + rect.Top);
                    break;
                case UILocation.Direction.CENTER:
                    ptBasePoint = new Point((rect.Right - rect.Left) / 2 + rect.Left, (rect.Bottom - rect.Top) / 2 + rect.Top);
                    break;
                case UILocation.Direction.RC:
                    ptBasePoint = new Point(rect.Right, (rect.Bottom - rect.Top) / 2 + rect.Top);
                    break;
                case UILocation.Direction.LB:
                    ptBasePoint = new Point(rect.Left, rect.Bottom);
                    break;
                case UILocation.Direction.CB:
                    ptBasePoint = new Point((rect.Right - rect.Left) / 2 + rect.Left, rect.Bottom);
                    break;
                case UILocation.Direction.RB:
                    ptBasePoint = new Point(rect.Right, rect.Bottom);
                    break;
            }

            Win32.ClientToScreen(_Process.MainWindowHandle, out ptBasePoint);

            float aspectRatio = (float)rect.Right / rect.Bottom;
            float magnification;

            if (MAX_CLIENT_ASPECT_RATIO < aspectRatio)
            {
                magnification = ((float)MAX_CLIENT_SIZE_X * rect.Bottom) / ((float)rect.Right * MAX_CLIENT_SIZE_Y) * ((float)rect.Right / MAX_CLIENT_SIZE_X);
            }
            else if (MAX_CLIENT_ASPECT_RATIO > aspectRatio)
            {
                magnification = ((float)rect.Right * MAX_CLIENT_SIZE_Y) / ((float)MAX_CLIENT_SIZE_X * rect.Bottom) * ((float)rect.Bottom / MAX_CLIENT_SIZE_Y);
            }
            else
            {
                magnification = ((float)rect.Right / MAX_CLIENT_SIZE_X);
            }

            Point ScreenLocation = new Point((int)(uiLocation.x * magnification), (int)(uiLocation.y * magnification));

            return new Point(ptBasePoint.X - ScreenLocation.X, ptBasePoint.Y - ScreenLocation.Y);
        }

        private void IngameHotKey(UILocation uiLocation)
        {
            if (null == _Process)
                return;

            if (true == checkBox_Hide.Checked)
                return;

            Point Result = PointToResponsiveWindow(uiLocation);

            Mouseclick(Result);
        }

        public void IngameShortCutKeyUnregister()
        {
            Win32.UnregisterHotKey(this.Handle, SKILL1_ID);
            Win32.UnregisterHotKey(this.Handle, SKILL2_ID);
            Win32.UnregisterHotKey(this.Handle, SKILL3_ID);
            //Win32.UnregisterHotKey(this.Handle, OK_ID);
            Win32.UnregisterHotKey(this.Handle, CANCEL_ID);
            Win32.UnregisterHotKey(this.Handle, WAIT_ID);

            for(int i = 0; i < Properties.Settings.Default.ManualInagmeShortcutList.Count; ++i)
            {
                if (false == Properties.Settings.Default.ManualInagmeShortcutList[i].isUsing)
                    continue;

                Win32.UnregisterHotKey(this.Handle, MANUALSHORTCUTSTART_ID + i);
            }
        }

        public void IngameShortCutKeyRegister()
        {
            KeyModifiers modifier = KeyModifiers.None;

            Keys key = (Keys)(Properties.Settings.Default.Skill1Key);
            Win32.RegisterHotKey(this.Handle, SKILL1_ID, modifier, key);

            key = (Keys)(Properties.Settings.Default.Skill2Key);
            Win32.RegisterHotKey(this.Handle, SKILL2_ID, modifier, key);

            key = (Keys)(Properties.Settings.Default.Skill3Key);
            Win32.RegisterHotKey(this.Handle, SKILL3_ID, modifier, key);

            //key = (Keys)(Properties.Settings.Default.OKKey);
            //Win32.RegisterHotKey(this.Handle, OK_ID, modifier, key);

            key = (Keys)(Properties.Settings.Default.CancelKey);
            Win32.RegisterHotKey(this.Handle, CANCEL_ID, modifier, key);

            key = (Keys)(Properties.Settings.Default.WaitKey);
            Win32.RegisterHotKey(this.Handle, WAIT_ID, modifier, key);

            for (int i = 0; i < Properties.Settings.Default.ManualInagmeShortcutList.Count; ++i)
            {
                if (false == Properties.Settings.Default.ManualInagmeShortcutList[i].isUsing)
                    continue;

                key = Properties.Settings.Default.ManualInagmeShortcutList[i].key;
                Win32.RegisterHotKey(this.Handle, MANUALSHORTCUTSTART_ID + i, modifier, key);
            }
        }

        private void IngameShortcut()
        {
            if (true == checkBox_IngameShortcut.Checked)
            {
                if (true == Properties.Settings.Default.isBalloon)
                {
                    notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon.BalloonTipTitle = "작업 관리자";
                    notifyIcon.BalloonTipText = "인게임 단축키 시작.";
                    notifyIcon.ShowBalloonTip(2000);
                }

                IngameShortCutKeyRegister();
                HookRegister();
            }
            else
            {
                if (true == Properties.Settings.Default.isBalloon)
                {
                    notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon.BalloonTipTitle = "작업 관리자";
                    notifyIcon.BalloonTipText = "인게임 단축키 종료.";
                    notifyIcon.ShowBalloonTip(2000);
                }

                _isUsingChat = false;
                Win32.UnregisterHotKey(_this.Handle, ESC_ID);

                IngameShortCutKeyUnregister();
                HookUnregister();
            }
        }

        private void Mouseclick(Point pt)
        {
            Point prevCursor = Cursor.Position;

            Cursor.Position = pt;
            Win32.mouse_event(Win32.LBUTTONDOWN | Win32.LBUTTONUP, 0, 0, 0, 0);
            Delay(20);

            Cursor.Position = prevCursor;
        }
        
        // ===================================================================================
        

        // Event
        // ===================================================================================

        private void _Process_Exited(object sender, EventArgs e)
        {
            this.Invoke(new Action(delegate ()
            {
                _Process = null;

                notifyIcon.Icon = Properties.Resources.Red;
                pictureBox_ProcessStatus.BackColor = Color.Red;

                button_Screenshot.Enabled = false;
                checkBox_Hide.Enabled = false;
                checkBox_IngameShortcut.Enabled = false;
                clientHideToolStripMenuItem.Enabled = false;
                클라숨기기ToolStripMenuItem.Enabled = false;

                if (true == checkBox_IngameShortcut.Checked)
                {
                    checkBox_IngameShortcut.Checked = false;

                    _isUsingChat = false;
                    Win32.UnregisterHotKey(_this.Handle, ESC_ID);

                    IngameShortCutKeyUnregister();
                    HookUnregister();
                }

                checkBox_Hide.Checked = false;
            }));
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
                Win32.ShowWindow((int)_Process.MainWindowHandle, Win32.SW_SHOW);

            HotKeyUnregister();
            
            if(true == _this.checkBox_IngameShortcut.Checked)
            {
                IngameShortCutKeyUnregister();
                HookUnregister();
            }

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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();

                if(Properties.Settings.Default.isBalloon)
                {
                    notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon.BalloonTipTitle = "작업 관리자";
                    notifyIcon.BalloonTipText = "프로그램이 실행 중 입니다.";
                    notifyIcon.ShowBalloonTip(2000);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null != _Process)
                Win32.ShowWindow((int)_Process.MainWindowHandle, Win32.SW_SHOW);

            HotKeyUnregister();

            if (true == _this.checkBox_IngameShortcut.Checked)
            {
                IngameShortCutKeyUnregister();
                HookUnregister();
            }

            Application.Exit();
        }

        private void button_mute_Click(object sender, EventArgs e)
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

        private void 클라숨기기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (true == checkBox_Hide.Checked)
                checkBox_Hide.Checked = false;
            else
                checkBox_Hide.Checked = true;
        }

        private void clientHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (true == checkBox_Hide.Checked)
                checkBox_Hide.Checked = false;
            else
                checkBox_Hide.Checked = true;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchProcess();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotKeyUnregister();

            if (true == checkBox_IngameShortcut.Checked)
            {
                if(true == _isUsingChat)
                {
                    MessageBox.Show("대화창 종료 후 옵션 창을 열어주세요.");
                    return;
                }

                IngameShortCutKeyUnregister();
                HookUnregister();
            }

            Option op = new Option();
            op.InitOption(this);
            op.ShowDialog();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.ShowDialog();
        }

        private void button_Screenshot_Click(object sender, EventArgs e)
        {
            Screenshot();
        }

        private void checkBox_Hide_CheckedChanged(object sender, EventArgs e)
        {
            HideClient();
        }

        private void checkBox_IngameShortcut_CheckedChanged(object sender, EventArgs e)
        {
            IngameShortcut();
        }

        // ===================================================================================

        private void HideClient()
        {
            if (null == _Process)
                return;

            IntPtr handle = _Process.MainWindowHandle;

            if (false == checkBox_Hide.Checked)
            {

                Win32.ShowWindow((int)handle, Win32.SW_SHOW);
                checkBox_Hide.Text = "클라 숨기기";
                클라숨기기ToolStripMenuItem.Text = "클라 숨기기";
                clientHideToolStripMenuItem.Text = "클라 숨기기";
            }
            else
            {
                Win32.ShowWindow((int)handle, Win32.SW_HIDE);
                checkBox_Hide.Text = "클라 띄우기";
                클라숨기기ToolStripMenuItem.Text = "클라 띄우기";
                clientHideToolStripMenuItem.Text = "클라 띄우기";

                _isMute = true;
                button_mute.Image = Properties.Resources.Mute;
                VolumeMixer.SetApplicationMute(_Process.Id, true);
            }
        }

        private void Screenshot()
        {
            if (null == _Process)
                return;

            if (true == checkBox_Hide.Checked)
                return;

            Rectangle rect = Rectangle.Empty;

            Graphics gfxWin = Graphics.FromHwnd(_Process.MainWindowHandle);
            rect = Rectangle.Round(gfxWin.VisibleClipBounds);

            if (0 >= rect.Width || 0 >= rect.Width)
            {
                gfxWin.Dispose();
                return;
            }

            Bitmap bmp = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();
            bool succeeded = Win32.PrintWindow(_Process.MainWindowHandle, hdcBitmap, 3);

            gfxBmp.ReleaseHdc(hdcBitmap);
            if (false == succeeded)
            {
                gfxBmp.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(System.Drawing.Point.Empty, bmp.Size));
            }

            IntPtr hRgn = Win32.CreateRectRgn(0, 0, 0, 0);
            Win32.GetWindowRgn(_Process.MainWindowHandle, hRgn);
            Region region = Region.FromHrgn(hRgn);
            if (!region.IsEmpty(gfxBmp))
            {
                gfxBmp.ExcludeClip(region);
                gfxBmp.Clear(Color.Transparent);
            }

            gfxBmp.Dispose();
            bmp.Save(Application.StartupPath + "\\Langrisser" + DateTime.Now.ToString("_MM-dd_hh-mm-ss") + ".png", System.Drawing.Imaging.ImageFormat.Png);


            //Rect windowRect;
            //Win32.GetWindowRect(_Process.MainWindowHandle, out windowRect);

            //int width = windowRect.Right - windowRect.Left;
            //int height = windowRect.Bottom - windowRect.Top;

            //if (0 >= width || 0 >= height)
            //    return;

            //IntPtr hdcSrc = Win32.GetWindowDC(_Process.MainWindowHandle);
            //IntPtr hdcDest = Win32.CreateCompatibleDC(hdcSrc);
            //IntPtr hBitmap = Win32.CreateCompatibleBitmap(hdcSrc, width, height);
            //IntPtr hOld = Win32.SelectObject(hdcDest, hBitmap);

            //Win32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, Win32.SRCCOPY);
            //Win32.SelectObject(hdcDest, hOld);
            //Win32.DeleteDC(hdcDest);
            //Win32.ReleaseDC(_Process.MainWindowHandle, hdcSrc);

            //Bitmap bitmap = Image.FromHbitmap(hBitmap);
            //Win32.DeleteObject(hBitmap);

            //bitmap.Save(Application.StartupPath + "\\Langrisser" + DateTime.Now.ToString("_MM-dd_hh-mm-ss") + ".png", System.Drawing.Imaging.ImageFormat.Png);
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

                button_Screenshot.Enabled = false;
                checkBox_Hide.Enabled = false;
                checkBox_IngameShortcut.Enabled = false;
                clientHideToolStripMenuItem.Enabled = false;
                클라숨기기ToolStripMenuItem.Enabled = false;

                return false;
            }

            if (null != _Process)
            {
                _Process.Dispose();
                _Process = null;
            }

            _Process = processList[0];
            _Process.EnableRaisingEvents = true;
            _Process.Exited += _Process_Exited;

            notifyIcon.Icon = Properties.Resources.Green;
            pictureBox_ProcessStatus.BackColor = Color.Lime;

            button_Screenshot.Enabled = true;
            checkBox_Hide.Enabled = true;
            checkBox_IngameShortcut.Enabled = true;
            clientHideToolStripMenuItem.Enabled = true;
            클라숨기기ToolStripMenuItem.Enabled = true;

            if (Properties.Settings.Default.isRefreshMute)
            {
                trackBar_sound.Value = 0;
                button_mute.Image = Properties.Resources.Mute;
                _isMute = true;

                VolumeMixer.SetApplicationMute(_Process.Id, true);
                VolumeMixer.SetApplicationVolume(_Process.Id, 0f);
            }
            else
            {
                VolumeMixer.SetApplicationMute(_Process.Id, _isMute);
                VolumeMixer.SetApplicationVolume(_Process.Id, trackBar_sound.Value);
            }

            return true;
        }
    }
}
