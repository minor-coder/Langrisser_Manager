using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public enum KeyModifiers
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Windows = 8
    }

    public enum MouseMessages
    {
        WM_LBUTTONDOWN = 0x0201,
        WM_LBUTTONUP = 0x0202,
        WM_MOUSEMOVE = 0x0200,
        WM_MOUSEWHEEL = 0x020A,
        WM_RBUTTONDOWN = 0x0204,
        WM_RBUTTONUP = 0x0205
    }

    public struct HotKey
    {
        public Keys modifiers;
        public int key;
    }

    public struct Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public Rect(int _Left, int _Top, int _Right, int _Bottom)
        {
            Left = _Left;
            Top = _Top;
            Right = _Right;
            Bottom = _Bottom;
        }

        public static Rect operator+(Rect rect, int value)
        {
            return new Rect(rect.Left + value, rect.Top + value, rect.Right + value, rect.Bottom + value);
        }
    }

    public struct UILocation
    {
        public enum Direction { LT, CT, RT, LC, CENTER, RC, LB, CB, RB };

        public bool isUsing { get; set; }
        public string name { get; set; }
        public Keys key { get; set; }
        public int x;
        public int y;
        public Direction dir;

        public override string ToString()
        {
            return name;
        }

        public UILocation(int _x, int _y, Direction _dir)
        {
            x = _x;
            y = _y;
            dir = _dir;
            name = "";
            key = Keys.None;
            isUsing = true;
        }

        public UILocation(int _x, int _y, Direction _dir, string _name, Keys _key)
        {
            x = _x;
            y = _y;
            dir = _dir;
            name = _name;
            key = _key;
            isUsing = true;
        }
    }
}
