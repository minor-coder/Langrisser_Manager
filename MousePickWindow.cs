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
    public partial class MousePickWindow : Form
    {
        private UILocation.Direction _Direction;

        public MousePickWindow()
        {
            InitializeComponent();
            Opacity = 0.5;
            TopMost = true;
        }

        private void MousePickWindow_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioButton_LT.Checked == true ||
                radioButton_CT.Checked == true ||
                radioButton_RT.Checked == true ||
                radioButton_LC.Checked == true ||
                radioButton_CENTER.Checked == true ||
                radioButton_RC.Checked == true ||
                radioButton_LB.Checked == true ||
                radioButton_CB.Checked == true ||
                radioButton_RB.Checked == true)
            {
                Point basePT = new Point(0, 0);

                if (_Direction == UILocation.Direction.CT)
                    basePT = new Point(800, 0);
                else if(_Direction == UILocation.Direction.RT)
                    basePT = new Point(1600, 0);
                else if (_Direction == UILocation.Direction.LC)
                    basePT = new Point(0, 450);
                else if (_Direction == UILocation.Direction.CENTER)
                    basePT = new Point(800, 450);
                else if (_Direction == UILocation.Direction.RC)
                    basePT = new Point(1600, 450);
                else if (_Direction == UILocation.Direction.LB)
                    basePT = new Point(0, 900);
                else if (_Direction == UILocation.Direction.CB)
                    basePT = new Point(800, 900);
                else if (_Direction == UILocation.Direction.RB)
                    basePT = new Point(1600, 900);

                Point mousePT = MousePosition;
                mousePT = PointToClient(mousePT);

                string name = "";
                Keys key = Keys.None;

                MousePickWindowName nameWindow = new MousePickWindowName();
                nameWindow._sendEvent += new MousePickWindowName.SendDataHandler((_name, _key) => { name = _name; key = _key; });

                if (DialogResult.Cancel == nameWindow.ShowDialog())
                {
                    Close();
                    return;
                }
                
                UILocation uiLocation = new UILocation(basePT.X - mousePT.X, basePT.Y - mousePT.Y, _Direction, name, key);
                if (null == Properties.Settings.Default.ManualInagmeShortcutList)
                    Properties.Settings.Default.ManualInagmeShortcutList = new BindingList<UILocation>();

                Properties.Settings.Default.ManualInagmeShortcutList.Add(uiLocation);
                Properties.Settings.Default.Save();
                Close();
            }
        }

        private void BasePointSelect(object sender, EventArgs e)
        {
            BackColor = Color.SeaGreen;

            _Direction = (UILocation.Direction)((RadioButton)sender).TabIndex;
            radioButton_LT.Visible = false;
            radioButton_CT.Visible = false;
            radioButton_RT.Visible = false;
            radioButton_LC.Visible = false;
            radioButton_CENTER.Visible = false;
            radioButton_RC.Visible = false;
            radioButton_LB.Visible = false;
            radioButton_CB.Visible = false;
            radioButton_RB.Visible = false;
        }
    }
}
