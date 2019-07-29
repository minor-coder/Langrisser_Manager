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
    public partial class MousePickWindowName : Form
    {
        public delegate void SendDataHandler(string sendstring, Keys key);
        public event SendDataHandler _sendEvent;

        public List<int> _allowKeyList;

        public Keys _key;

        public MousePickWindowName()
        {
            InitializeComponent();
            AddAllowedKey();
            _key = Keys.None;

            TopMost = true;
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
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if(textBox_name.Text == "" && Keys.None == _key)
            {
                MessageBox.Show("키와 이름을 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(Keys.None == _key)
            {
                MessageBox.Show("키를 입력하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (textBox_name.Text == "")
            {
                MessageBox.Show("이름을 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _sendEvent(textBox_name.Text, _key);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_key_KeyUp(object sender, KeyEventArgs e)
        {
            int key = e.KeyValue;

            //Left = 37,
            //Up = 38
            //Right = 39
            //Down = 40,

            //FuncKey 112 ~ 123

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

            _key = (Keys)key;
            textBox_key.Text = _key.ToString();
        }
    }
}
