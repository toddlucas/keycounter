/*
   Copyright (C) 2007 OBACHT & UNCLE JAMAL

   This program is free software; you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation; either version 2 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.
*/

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace KeyCounter.WinHook
{
  public class UniversalHook : IDisposable
  {
    //Variables used in the call to SetWindowsHookEx
    protected HookHandlerDelegate proc;
    protected IntPtr hookID = IntPtr.Zero;
    protected delegate IntPtr HookHandlerDelegate(int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);

    // Structure returned by the hook
    protected struct KBDLLHOOKSTRUCT
    {
      public int vkCode;
      public int scanCode;
      public int flags;
      public int time;
      public int dwExtraInfo;
    }

    #region DllImports
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    protected static extern IntPtr SetWindowsHookEx(int idHook, HookHandlerDelegate lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    protected static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    protected static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    protected static extern IntPtr GetModuleHandle(string lpModuleName);
    #endregion

    public UniversalHook()
    {
      // set up desired hook using SetWindowsHookEx
    }

    // Release the hook
    public void Dispose()
    {
      UnhookWindowsHookEx(hookID);
    }

    // Processes the event captured by the hook
    protected virtual IntPtr HookCallback(int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam)
    {
      return (System.IntPtr)1;
    }

    #region Event stuff

    // Delegate for Hook event handling
    public delegate void HookEventHandler(HookEventArgs e);

    // Event triggered when a keystroke is intercepted by the low-level hook
    public event HookEventHandler KeyIntercepted;

    // Raises the KeyIntercepted event.
    public void OnKeyIntercepted(HookEventArgs e)
    {
      if (KeyIntercepted != null)
        KeyIntercepted(e);
    }

    // Event arguments for the KeyIntercepted event
    public class HookEventArgs : EventArgs
    {
      public int vkCode;
      public int scanCode;
      public int flags;
      public int time;
      public int dwExtraInfo;

      public HookEventArgs(int vkc, int sc, int f, int t, int dwei)
      {
        vkCode = vkc;
        scanCode = sc;
        flags = f;
        time = t;
        dwExtraInfo = dwei;
      }
    }
    #endregion
  }

  public class KeyboardHook : UniversalHook
  {
    //API constants
    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYUP = 0x0101;
    private const int WM_SYSKEYUP = 0x0105;

    // Constructor: set up a keyboard hook to trap all keystrokes
    public KeyboardHook()
    {
      proc = new HookHandlerDelegate(HookCallback);
      using (Process curProcess = Process.GetCurrentProcess())
      using (ProcessModule curModule = curProcess.MainModule)
      {
        hookID = SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
      }
    }

    // Processes the key event captured by the hook
    protected override IntPtr HookCallback(int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam)
    {
      //Filter wParam for KeyUp events only
      if (nCode >= 0 && (wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP))
        OnKeyIntercepted(new HookEventArgs(lParam.vkCode, lParam.scanCode, lParam.flags, lParam.time, lParam.dwExtraInfo));

      //Pass key to next application
      return CallNextHookEx(hookID, nCode, wParam, ref lParam);
    }
  }

  public class MouseHook : UniversalHook
  {
    // API constants
    private const int WH_MOUSE_LL = 14;
    private const int WM_LBUTTONDOWN = 0x0201;
    private const int WM_RBUTTONDOWN = 0x0204;

    // Constructor: set up a mouse hook
    public MouseHook()
    {
      proc = new HookHandlerDelegate(HookCallback);
      using (Process curProcess = Process.GetCurrentProcess())
      using (ProcessModule curModule = curProcess.MainModule)
      {
        hookID = SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
      }
    }

    // Processes the key event captured by the hook
    protected override IntPtr HookCallback(int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam)
    {
      //Filter wParam for KeyUp events only
      if (nCode >= 0 && wParam == (IntPtr)WM_LBUTTONDOWN)
        OnKeyIntercepted(new HookEventArgs(1, 0, 0, 0, 0));
      else if (nCode >= 0 && wParam == (IntPtr)WM_RBUTTONDOWN)
        OnKeyIntercepted(new HookEventArgs(2, 0, 0, 0, 0));

      //Pass key to next application
      return CallNextHookEx(hookID, nCode, wParam, ref lParam);
    }
  }
}