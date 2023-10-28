// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// ダイアログのフッククラス
    /// MessageBoxを画面の中央に表示するためのフック処理を提供する
    /// </summary>
    public class AbDialogHook
    {
        private delegate IntPtr HOOKPROC(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetCurrentThreadId();

        [DllImport("user32.dll")]
        private static extern IntPtr GetParent(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hHook);
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, HOOKPROC lpfn, IntPtr hInstance, IntPtr threadId);
        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hHook, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        private const int WH_CBT = 5;
        private const int HCBT_ACTIVATE = 5;

        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_NOACTIVATE = 0x0010;


        /// <summary>フックオブジェクト</summary>
        private static IntPtr hHook;

        /// <summary>
        /// ウィンドウサイズ構造体
        /// フィールドはこの定義順でなければならない
        /// </summary>
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        /// <summary>
        /// ダイアログフック処理
        /// </summary>
        public static void Hook()
        {
            hHook = SetWindowsHookEx(WH_CBT, CBTProc, IntPtr.Zero, GetCurrentThreadId());
        }

        /// <summary>
        /// ダイアログフック後の挿入処理
        /// </summary>
        public static IntPtr CBTProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode == HCBT_ACTIVATE)
            {
                // フックの解除
                AbDialogHook.UnhookWindowsHookEx(hHook);

                // ダイアログとウィンドウの取得
                var hMessageBox = wParam;
                var hParentWindow = GetParent(hMessageBox);

                // それぞれのウィンドウサイズを取得
                RECT rcDialog, rcParent;
                GetWindowRect(hMessageBox, out rcDialog);
                GetWindowRect(hParentWindow, out rcParent);

                // ダイアログをウィンドウの中央に表示するように設定
                SetWindowPos(
                    hMessageBox,
                    hParentWindow,
                    (rcParent.left + (rcParent.right  - rcParent.left) / 2) - ((rcDialog.right  - rcDialog.left) / 2),
                    (rcParent.top  + (rcParent.bottom - rcParent.top ) / 2) - ((rcDialog.bottom - rcDialog.top ) / 2),
                    0, 0, SWP_NOSIZE | SWP_NOZORDER | SWP_NOACTIVATE
                );
            }
            return CallNextHookEx(hHook, nCode, wParam, lParam);
        }
    }
}
