using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class Option : Form
    {
        public TaskManager _tm = null;

        public HotKey _BossKey;
        public HotKey _VolumeUp;
        public HotKey _VolumeDown;
        public HotKey _MuteKey;
        public HotKey _ScreenshotKey;

        public Option()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.taskmanager;
            this.MaximizeBox = false;
        }

        public void InitOption(TaskManager tm)
        {
            _tm = tm;

            checkBox_Tooltip.Checked = Properties.Settings.Default.isBalloon;
            checkBox_RefreshMute.Checked = Properties.Settings.Default.isRefreshMute;

            _BossKey.modifiers = ModifiersCalcRerv(Properties.Settings.Default.BossKeyModifiers);
            _BossKey.key = Properties.Settings.Default.BossKey;
            ShowHotKey(textBox_BossKey, _BossKey);

            _VolumeUp.modifiers = ModifiersCalcRerv(Properties.Settings.Default.VolumeUpModifiers);
            _VolumeUp.key = Properties.Settings.Default.VolumeUpKey;
            ShowHotKey(textBox_VolumeUp, _VolumeUp);

            _VolumeDown.modifiers = ModifiersCalcRerv(Properties.Settings.Default.VolumeDownModifiers);
            _VolumeDown.key = Properties.Settings.Default.VolumeDownKey;
            ShowHotKey(textBox_VolumeDown, _VolumeDown);

            _MuteKey.modifiers = ModifiersCalcRerv(Properties.Settings.Default.MuteKeyModifiers);
            _MuteKey.key = Properties.Settings.Default.MuteKey;
            ShowHotKey(textBox_MuteKey, _MuteKey);

            _ScreenshotKey.modifiers = ModifiersCalcRerv(Properties.Settings.Default.ScreenshotModifier);
            _ScreenshotKey.key = Properties.Settings.Default.ScreenshotKey;
            ShowHotKey(textBox_Screenshot, _ScreenshotKey);
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.isBalloon = checkBox_Tooltip.Checked;
            Properties.Settings.Default.isRefreshMute = checkBox_RefreshMute.Checked;

            Properties.Settings.Default.BossKeyModifiers = ModifiersCalc(_BossKey);
            Properties.Settings.Default.BossKey = _BossKey.key;

            Properties.Settings.Default.VolumeUpModifiers = ModifiersCalc(_VolumeUp);
            Properties.Settings.Default.VolumeUpKey = _VolumeUp.key;

            Properties.Settings.Default.VolumeDownModifiers = ModifiersCalc(_VolumeDown);
            Properties.Settings.Default.VolumeDownKey = _VolumeDown.key;

            Properties.Settings.Default.MuteKeyModifiers = ModifiersCalc(_MuteKey);
            Properties.Settings.Default.MuteKey = _MuteKey.key;

            Properties.Settings.Default.ScreenshotModifier = ModifiersCalc(_ScreenshotKey);
            Properties.Settings.Default.ScreenshotKey = _ScreenshotKey.key;

            Properties.Settings.Default.Save();

            _tm.HotKeyRegister();
            this.Close();
        }

        private Keys ModifiersCalcRerv(int modifiers)
        {
            Keys mod = Keys.None;

            if (((KeyModifiers)modifiers & KeyModifiers.Alt) == KeyModifiers.Alt)
                mod |= Keys.Alt;
            if (((KeyModifiers)modifiers & KeyModifiers.Control) == KeyModifiers.Control)
                mod |= Keys.Control;
            if (((KeyModifiers)modifiers & KeyModifiers.Shift) == KeyModifiers.Shift)
                mod |= Keys.Shift;

            return mod;
        }

        private int ModifiersCalc(HotKey hotKey)
        {
            int mod = 0;
            if ((hotKey.modifiers & Keys.Alt) == Keys.Alt)
                mod += 1;
            if ((hotKey.modifiers & Keys.Control) == Keys.Control)
                mod += 2;
            if ((hotKey.modifiers & Keys.Shift) == Keys.Shift)
                mod += 4;

            return mod;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _tm.HotKeyRegister();
            this.Close();
        }

        private void textBox_BossKey_KeyUp(object sender, KeyEventArgs e)
        {
            ShowHotKey(sender, e, ref _BossKey);
        }

        private void textBox_VolumeUp_KeyUp(object sender, KeyEventArgs e)
        {
            ShowHotKey(sender, e, ref _VolumeUp);
        }

        private void textBox_VolumeDown_KeyUp(object sender, KeyEventArgs e)
        {
            ShowHotKey(sender, e, ref _VolumeDown);
        }

        private void textBox_MuteKey_KeyUp(object sender, KeyEventArgs e)
        {
            ShowHotKey(sender, e, ref _MuteKey);
        }

        private void textBox_Screenshot_KeyUp(object sender, KeyEventArgs e)
        {
            ShowHotKey(sender, e, ref _ScreenshotKey);
        }

        private void ShowHotKey(object sender, HotKey hotKey)
        {
            TextBox textBox = (TextBox)sender;
            string text = "";

            if ((hotKey.modifiers & Keys.Control) == Keys.Control)
            {
                text += "Ctrl + ";
            }

            if ((hotKey.modifiers & Keys.Alt) == Keys.Alt)
            {
                text += "Alt + ";
            }

            if ((hotKey.modifiers & Keys.Shift) == Keys.Shift)
            {
                text += "Shift + ";
            }

            if ((hotKey.modifiers & Keys.LWin) == Keys.LWin)
            {
                text += "Windows + ";
            }

            if (65 <= hotKey.key && 90 >= hotKey.key)
                text += (char)hotKey.key;
            else if (37 == hotKey.key)
                text += "←";
            else if (38 == hotKey.key)
                text += "↑";
            else if (39 == hotKey.key)
                text += "→";
            else if (40 == hotKey.key)
                text += "↓";
            else if (112 <= hotKey.key && 123 >= hotKey.key)
            {
                text += "F" + (hotKey.key - 111).ToString();
            }

            textBox.Text = text;
        }

        private void ShowHotKey(object sender, KeyEventArgs e, ref HotKey hotKey)
        {
            TextBox textBox = (TextBox)sender;

            Keys modifiers = e.Modifiers;
            int key = e.KeyValue;

            //Left = 37,
            //Up = 38
            //Right = 39
            //Down = 40,

            //FuncKey 112 ~ 123

            if ((65 > key || 90 < key) && (37 > key || 40 < key) && (112 > key || 123 < key))
                return;

            if (modifiers == Keys.None)
                return;

            string text = "";

            if ((modifiers & Keys.Control) == Keys.Control)
            {
                text += "Ctrl + ";
            }

            if ((modifiers & Keys.Alt) == Keys.Alt)
            {
                text += "Alt + ";
            }

            if ((modifiers & Keys.Shift) == Keys.Shift)
            {
                text += "Shift + ";
            }

            if ((modifiers & Keys.LWin) == Keys.LWin)
            {
                text += "Windows + ";
            }

            if (65 <= key && 90 >= key)
                text += (char)key;
            else if (37 == key)
                text += "←";
            else if (38 == key)
                text += "↑";
            else if (39 == key)
                text += "→";
            else if (40 == key)
                text += "↓";
            else if (112 <= key && 123 >= key)
            {
                text += "F" + (key - 111).ToString();
            }

            textBox.Text = text;

            hotKey.modifiers = modifiers;
            hotKey.key = key;
        }
    }
}
