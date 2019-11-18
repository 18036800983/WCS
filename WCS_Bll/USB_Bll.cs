using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WCS_Bll
{
    public class USB_Bll
    {
        public delegate void ScanerDelegate(ScanerCodes codes);
        public event ScanerDelegate ScanerEvent;
        delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        private int hKeyboardHook = 0;
        private ScanerCodes codes = new ScanerCodes();
        private HookProc hookproc;
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(int idHook);
        [DllImport("user32", EntryPoint = "GetKeyNameText")]
        private static extern int GetKeyNameText(int IParam, StringBuilder lpBuffer, int nSize);
        [DllImport("user32", EntryPoint = "GetKeyboardState")]
        private static extern int GetKeyboardState(byte[] pbKeyState);
        [DllImport("user32", EntryPoint = "ToAscii")]
        private static extern bool ToAscii(int VirtualKey, int ScanCode, byte[] lpKeySate, ref uint lpChar, int uFlags);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);
        public USB_Bll()
        {
        }
        public bool Start()
        {
            if (hKeyboardHook == 0)
            {
                hookproc = new HookProc(KeyboardHookProc);
                //GetModuleHandle 函数 替代 Marshal.GetHINSTANCE
                //防止在 framework4.0中 注册钩子不成功
                IntPtr modulePtr = GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);
                //WH_KEYBOARD_LL=13
                //全局钩子 WH_KEYBOARD_LL
                //  hKeyboardHook = SetWindowsHookEx(13, hookproc, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
                hKeyboardHook = SetWindowsHookEx(13, hookproc, modulePtr, 0);
            }
            return (hKeyboardHook != 0);
        }
        public bool Stop()
        {
            if (hKeyboardHook != 0)
            {
                return UnhookWindowsHookEx(hKeyboardHook);
            }
            return true;
        }
        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            EventMsg msg = (EventMsg)Marshal.PtrToStructure(lParam, typeof(EventMsg));
            codes.Add(msg);
            if (ScanerEvent != null && msg.message == 13 && msg.paramH > 0 && !string.IsNullOrEmpty(codes.Result))
            {
                ScanerEvent(codes);
            }
            return 0;
        }
        public class ScanerCodes
        {
            private int ts = 300; // 指定输入间隔为300毫秒以内时为连续输入
            private List<List<EventMsg>> _keys = new List<List<EventMsg>>();
            private List<int> _keydown = new List<int>();   // 保存组合键状态
            private List<string> _result = new List<string>();  // 返回结果集
            private DateTime _last = DateTime.Now;
            private byte[] _state = new byte[256];
            private string _key = string.Empty;
            private string _cur = string.Empty;
            public EventMsg Event
            {
                get
                {
                    if (_keys.Count == 0)
                    {
                        return new EventMsg();
                    }
                    else
                    {
                        return _keys[_keys.Count - 1][_keys[_keys.Count - 1].Count - 1];
                    }
                }
            }
            public List<int> KeyDowns
            {
                get
                {
                    return _keydown;
                }
            }
            public DateTime LastInput
            {
                get
                {
                    return _last;
                }
            }
            public byte[] KeyboardState
            {
                get
                {
                    return _state;
                }
            }
            public int KeyDownCount
            {
                get
                {
                    return _keydown.Count;
                }
            }
            public string Result
            {
                get
                {
                    if (_result.Count > 0)
                    {
                        return _result[_result.Count - 1].Trim();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            public string CurrentKey
            {
                get
                {
                    return _key;
                }
            }
            public string CurrentChar
            {
                get
                {
                    return _cur;
                }
            }
            public bool isShift
            {
                get
                {
                    return _keydown.Contains(160);
                }
            }
            public void Add(EventMsg msg)
            {
                #region 记录按键信息
                // 首次按下按键
                if (_keys.Count == 0)
                {
                    _keys.Add(new List<EventMsg>());
                    _keys[0].Add(msg);
                    _result.Add(string.Empty);
                }
                // 未释放其他按键时按下按键
                else if (_keydown.Count > 0)
                {
                    _keys[_keys.Count - 1].Add(msg);
                }
                // 单位时间内按下按键
                else if (((TimeSpan)(DateTime.Now - _last)).TotalMilliseconds < ts)
                {
                    _keys[_keys.Count - 1].Add(msg);
                }
                // 从新记录输入内容
                else
                {
                    _keys.Add(new List<EventMsg>());
                    _keys[_keys.Count - 1].Add(msg);
                    _result.Add(string.Empty);
                }
                #endregion
                _last = DateTime.Now;
                #region 获取键盘状态
                // 记录正在按下的按键
                if (msg.paramH == 0 && !_keydown.Contains(msg.message))
                {
                    _keydown.Add(msg.message);
                }
                // 清除已松开的按键
                if (msg.paramH > 0 && _keydown.Contains(msg.message))
                {
                    _keydown.Remove(msg.message);
                }
                #endregion
                #region 计算按键信息
                int v = msg.message & 0xff;
                int c = msg.paramL & 0xff;
                StringBuilder strKeyName = new StringBuilder(500);
                if (GetKeyNameText(c * 65536, strKeyName, 255) > 0)
                {
                    _key = strKeyName.ToString().Trim(new char[] { ' ', '\0' });
                    GetKeyboardState(_state);
                    if (_key.Length == 1 && msg.paramH == 0)
                    {
                        // 根据键盘状态和shift缓存判断输出字符
                        _cur = ShiftChar(_key, isShift, _state).ToString();
                        _result[_result.Count - 1] += _cur;
                    }
                    else
                    {
                        _cur = string.Empty;
                    }
                }
                #endregion
            }
            private char ShiftChar(string k, bool isShiftDown, byte[] state)
            {
                bool capslock = state[0x14] == 1;
                bool numlock = state[0x90] == 1;
                bool scrolllock = state[0x91] == 1;
                bool shiftdown = state[0xa0] == 1;
                char chr = (capslock ? k.ToUpper() : k.ToLower()).ToCharArray()[0];
                if (isShiftDown)
                {
                    if (chr >= 'a' && chr <= 'z')
                    {
                        chr = (char)((int)chr - 32);
                    }
                    else if (chr >= 'A' && chr <= 'Z')
                    {
                        chr = (char)((int)chr + 32);
                    }
                    else
                    {
                        string s = "`1234567890-=[];',./";
                        string u = "~!@#$%^&*()_+{}:\"<>?";
                        if (s.IndexOf(chr) >= 0)
                        {
                            return (u.ToCharArray())[s.IndexOf(chr)];
                        }
                    }
                }
                return chr;
            }
        }
        public struct EventMsg
        {
            public int message;
            public int paramL;
            public int paramH;
            public int Time;
            public int hwnd;
        }
    }
}
