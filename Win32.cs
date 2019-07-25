using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace TaskManager
{
    class Win32
    {
        [DllImport("user32.dll")]
        public static extern int ShowWindow(int hwnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rectangle rect);

        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out Rect rect);

        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, out Point lpPoint);

        [DllImport("user32.dll")]
        public static extern int GetWindowRgn(IntPtr hWnd, IntPtr hRgn);

        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte vk, byte scan, int flags, ref int extrainfo);

        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        public const uint MOUSEMOVE = 0x0001;      // 마우스 이동
        public const uint ABSOLUTEMOVE = 0x8000;   // 전역 위치
        public const uint LBUTTONDOWN = 0x0002;    // 왼쪽 마우스 버튼 눌림
        public const uint LBUTTONUP = 0x0004;      // 왼쪽 마우스 버튼 떼어짐
        public const uint RBUTTONDOWN = 0x0008;    // 오른쪽 마우스 버튼 눌림
        public const uint RBUTTONUP = 0x00010;      // 오른쪽 마우스 버튼 떼어짐

        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;

        public const int WH_MOUSE_LL = 14;
        public const int WM_HOTKEY = 0x0312;

        public const int VK_ESCAPE = 0x001B;

        public const int KE_DOWN = 0;
        public const int KE_EXTENDEDKEY = 1;
        public const int KE_UP = 2;
    }
}
