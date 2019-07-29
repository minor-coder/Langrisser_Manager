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

        public List<int> _allowKeyList;

        public HotKey _BossKey;
        public HotKey _VolumeUp;
        public HotKey _VolumeDown;
        public HotKey _MuteKey;
        public HotKey _ScreenshotKey;
        public HotKey _IngameShortcut;

        public HotKey _Skill1Key;
        public HotKey _Skill2Key;
        public HotKey _Skill3Key;
        public HotKey _WaitKey;
        public HotKey _OKKey;
        public HotKey _CancelKey;

        public Graphics _graphics;
        public Brush _brush;
        public Pen _pen;

        public Option()
        {
            InitializeComponent();
            AddAllowedKey();

            this.Icon = Properties.Resources.taskmanager;
            this.MaximizeBox = false;

            Size = new Size(844, 300);

            _graphics = pictureBox_preview.CreateGraphics();
            _graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            _brush = new SolidBrush(Color.White);
            _pen = new Pen(Color.FromArgb(255, 120, 8, 8), 3f);

            comboBox_preview.Items.Add("전투 화면");
            comboBox_preview.Items.Add("스킬 화면");
            comboBox_preview.Items.Add("공격 화면");
            comboBox_preview.Items.Add("마을 화면");
            comboBox_preview.Items.Add("스토리 화면");

            comboBox_preview.SelectedIndex = 0;

            RefreshDataGridView();
        }

        private void AddAllowedKey()
        {
            _allowKeyList = new List<int>();

            // Alphabet
            for (int i = 65; i < 91; ++i)
                _allowKeyList.Add(i);

            // Arrow
            for (int i = 37; i < 41; ++i)
                _allowKeyList.Add(i);

            // Funckey
            for (int i = 112; i < 124; ++i)
                _allowKeyList.Add(i);

            // Number
            for (int i = 48; i < 58; ++i)
                _allowKeyList.Add(i);

            // Numpad number
            for (int i = 96; i < 106; ++i)
                _allowKeyList.Add(i);

            // ~
            _allowKeyList.Add(192);

            // -
            _allowKeyList.Add(189);

            // +
            _allowKeyList.Add(187);

            // [
            _allowKeyList.Add(219);

            // ]
            _allowKeyList.Add(221);

            // \
            _allowKeyList.Add(210);

            // ;
            _allowKeyList.Add(186);

            // '
            _allowKeyList.Add(222);

            // ,
            _allowKeyList.Add(188);

            // .
            _allowKeyList.Add(190);

            // /
            _allowKeyList.Add(191);

            // Num*
            _allowKeyList.Add(106);

            // Num+
            _allowKeyList.Add(107);

            // Num-
            _allowKeyList.Add(109);

            // Num.
            _allowKeyList.Add(110);

            // Num/
            _allowKeyList.Add(111);

            // Space
            _allowKeyList.Add(32);
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

            _ScreenshotKey.modifiers = ModifiersCalcRerv(Properties.Settings.Default.ScreenshotModifiers);
            _ScreenshotKey.key = Properties.Settings.Default.ScreenshotKey;
            ShowHotKey(textBox_Screenshot, _ScreenshotKey);


            _IngameShortcut.modifiers = ModifiersCalcRerv(Properties.Settings.Default.IngameShortcutModifiers);
            _IngameShortcut.key = Properties.Settings.Default.IngameShortcutKey;
            ShowHotKey(textBox_ingameShortcut, _IngameShortcut);

            _Skill1Key.modifiers = 0;
            _Skill1Key.key = Properties.Settings.Default.Skill1Key;
            ShowOnlyHotKey(textBox_skill1, _Skill1Key);

            _Skill2Key.modifiers = 0;
            _Skill2Key.key = Properties.Settings.Default.Skill2Key;
            ShowOnlyHotKey(textBox_skill2, _Skill2Key);

            _Skill3Key.modifiers = 0;
            _Skill3Key.key = Properties.Settings.Default.Skill3Key;
            ShowOnlyHotKey(textBox_skill3, _Skill3Key);

            _WaitKey.modifiers = 0;
            _WaitKey.key = Properties.Settings.Default.WaitKey;
            ShowOnlyHotKey(textBox_wait, _WaitKey);

            //_OKKey.modifiers = 0;
            //_OKKey.key = Properties.Settings.Default.OKKey;
            ShowOnlyHotKey(textBox_ok, _WaitKey);

            _CancelKey.modifiers = 0;
            _CancelKey.key = Properties.Settings.Default.CancelKey;
            ShowOnlyHotKey(textBox_cancel, _CancelKey);
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

            Properties.Settings.Default.ScreenshotModifiers = ModifiersCalc(_ScreenshotKey);
            Properties.Settings.Default.ScreenshotKey = _ScreenshotKey.key;

            Properties.Settings.Default.IngameShortcutModifiers = ModifiersCalc(_IngameShortcut);
            Properties.Settings.Default.IngameShortcutKey = _IngameShortcut.key;
            
            Properties.Settings.Default.Skill1Key = _Skill1Key.key;
            Properties.Settings.Default.Skill2Key = _Skill2Key.key;
            Properties.Settings.Default.Skill3Key = _Skill3Key.key;
            Properties.Settings.Default.WaitKey = _WaitKey.key;
            //Properties.Settings.Default.OKKey = _OKKey.key;
            Properties.Settings.Default.CancelKey = _CancelKey.key;

      
            Properties.Settings.Default.Save();

            _tm.HotKeyRegister();

            if (true == _tm.checkBox_IngameShortcut.Checked)
            {
                _tm.IngameShortCutKeyRegister();
                TaskManager.HookRegister();
            }

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
            if(true == _tm.checkBox_IngameShortcut.Checked)
            {
                _tm.IngameShortCutKeyRegister();
                TaskManager.HookRegister();
            }

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

        private void textBox_ingameShortcut_KeyUp(object sender, KeyEventArgs e)
        {
            ShowHotKey(sender, e, ref _IngameShortcut);
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

        private void ShowOnlyHotKey(object sender, HotKey hotKey)
        {
            TextBox textBox = (TextBox)sender;

            textBox.Text = ((Keys)hotKey.key).ToString();
        }

        private void ShowOnlyHotKey(object sender, KeyEventArgs e, ref HotKey hotKey)
        {
            TextBox textBox = (TextBox)sender;
            
            int key = e.KeyValue;

            bool isContain = false;
            foreach (int num in _allowKeyList)
            {
                if (num == key)
                {
                    isContain = true;
                    break;
                }
            }

            if (false == isContain)
                return;

            textBox.Text = ((Keys)key).ToString();

            hotKey.modifiers = 0;
            hotKey.key = key;
        }

        private void textBox_cancel_KeyUp(object sender, KeyEventArgs e)
        {
            ShowOnlyHotKey(sender, e, ref _CancelKey);
        }

        private void textBox_ok_KeyUp(object sender, KeyEventArgs e)
        {
            ShowOnlyHotKey(sender, e, ref _WaitKey);
            ShowOnlyHotKey(textBox_wait, e, ref _WaitKey);
        }

        private void textBox_skill1_KeyUp(object sender, KeyEventArgs e)
        {
            ShowOnlyHotKey(sender, e, ref _Skill1Key);
        }

        private void textBox_skill2_KeyUp(object sender, KeyEventArgs e)
        {
            ShowOnlyHotKey(sender, e, ref _Skill2Key);
        }

        private void textBox_skill3_KeyUp(object sender, KeyEventArgs e)
        {
            ShowOnlyHotKey(sender, e, ref _Skill3Key);
        }

        private void textBox_wait_KeyUp(object sender, KeyEventArgs e)
        {
            ShowOnlyHotKey(sender, e, ref _WaitKey);
            ShowOnlyHotKey(textBox_ok, e, ref _WaitKey);
        }

        private void button_manualAdd_Click(object sender, EventArgs e)
        {
            if (null == _tm._Process)
                return;

            Rect rect = new Rect(0, 0, 1600, 900);
            Win32.ShowWindow((int)_tm._Process.MainWindowHandle, Win32.SW_SHOWNORMAL);

            Win32.AdjustWindowRectEx(ref rect, Win32.WS_OVERLAPPEDWINDOW, false, 0);

            rect = rect + 100;
            Win32.SetWindowPos(_tm._Process.MainWindowHandle, -1, rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top, Win32.SWP_SHOWWINDOW);

            Point ptLT = _tm.PointToResponsiveWindow(new UILocation(0, 0, UILocation.Direction.LT));

            MousePickWindow mousePick = new MousePickWindow();
            mousePick.StartPosition = FormStartPosition.Manual;
            mousePick.Location = ptLT;
            mousePick.ShowDialog();

            
            RefreshDataGridView();
            
            Win32.SetWindowPos(_tm._Process.MainWindowHandle, -2, rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top, Win32.SWP_SHOWWINDOW);
            BringToFront();
        }

        private void checkBox_advanced_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_advanced.Checked == true)
            {
                Size = new Size(844, 583);
            }
            else
            {
                Size = new Size(844, 300);
            }
        }

        private void button_shortcutDelete_Click(object sender, EventArgs e)
        {
            if (null == dataGridView_manual.SelectedRows)
                return;

            int idx = dataGridView_manual.CurrentRow.Index;

            Properties.Settings.Default.ManualInagmeShortcutList.RemoveAt(idx);
            Properties.Settings.Default.Save();

            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            dataGridView_manual.DataSource = null;

            dataGridView_manual.RowHeadersVisible = false;
            dataGridView_manual.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            DataGridViewCheckBoxColumn useCol = new DataGridViewCheckBoxColumn();
            useCol.DataPropertyName = "isUsing";
            useCol.HeaderText = "사용여부";
            useCol.Width = 70;
            useCol.ReadOnly = false;

            dataGridView_manual.Columns.Add(useCol);

            DataGridViewTextBoxColumn nameCol = new DataGridViewTextBoxColumn();
            nameCol.DataPropertyName = "name";
            nameCol.HeaderText = "단축키 이름";
            nameCol.Width = 200;
            nameCol.ReadOnly = true;
            dataGridView_manual.Columns.Add(nameCol);

            DataGridViewTextBoxColumn keyCol = new DataGridViewTextBoxColumn();
            keyCol.DataPropertyName = "key";
            keyCol.HeaderText = "할당 키";
            keyCol.Width = 70;
            keyCol.ReadOnly = true;
            dataGridView_manual.Columns.Add(keyCol);

            dataGridView_manual.DataSource = Properties.Settings.Default.ManualInagmeShortcutList;
            dataGridView_manual.Refresh();
        }

        private void dataGridView_manual_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (-1 == e.RowIndex)
                return;

            UILocation uiLocation = Properties.Settings.Default.ManualInagmeShortcutList[e.RowIndex];

            if (e.ColumnIndex == 0)
            {
                if (true == uiLocation.isUsing)
                    uiLocation.isUsing = false;
                else
                    uiLocation.isUsing = true;

                Properties.Settings.Default.ManualInagmeShortcutList[e.RowIndex] = uiLocation;
                Properties.Settings.Default.Save();
                RefreshDataGridView();
            }
        }

        private void comboBox_preview_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = comboBox_preview.SelectedIndex;

            if (idx == 0)
                pictureBox_preview.BackgroundImage = Properties.Resources.Langrisser_Battle;
            else if (idx == 1)
                pictureBox_preview.BackgroundImage = Properties.Resources.Langrisser_Skill;
            else if (idx == 2)
                pictureBox_preview.BackgroundImage = Properties.Resources.Langrisser_Attack;
            else if (idx == 3)
                pictureBox_preview.BackgroundImage = Properties.Resources.Langrisser_Village;
            else if (idx == 4)
                pictureBox_preview.BackgroundImage = Properties.Resources.Langrisser_skip;
        }

        private void dataGridView_manual_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (-1 == e.RowIndex)
                return;

            UILocation uiLocation = Properties.Settings.Default.ManualInagmeShortcutList[e.RowIndex];

            //Rect rect = new Rect(pictureBox_preview.Left, pictureBox_preview.Top, pictureBox_preview.Right, pictureBox_preview.Bottom);
            Rect rect = new Rect(0, 0, 384, 216);

            Point ptBasePoint = new Point();
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
            
            float magnification = ((float)rect.Right / TaskManager.MAX_CLIENT_SIZE_X);
            Point ScreenLocation = new Point((int)(uiLocation.x * magnification), (int)(uiLocation.y * magnification));
            
            int x = ptBasePoint.X - ScreenLocation.X;
            int y = ptBasePoint.Y - ScreenLocation.Y;

            pictureBox_preview.Refresh();

            Rectangle ellipse = new Rectangle(x - 7, y - 7, 14, 14);
            _graphics.FillEllipse(_brush, ellipse);
            _graphics.DrawEllipse(_pen, ellipse);
        }
    }
}
