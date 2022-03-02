﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace Clip2Key.Net
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private static Keys _shortcutkey = Keys.RControlKey;
        private delegate IntPtr LowLevelKeyboardProc(
        int nCode, IntPtr wParam, IntPtr lParam);
        private static int _keyStrokeDelay = 0;

        //Set the hook to catch keyboard keypresses - used to catch the bound keyboard shortcut to type out the clipboard
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            {
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
                }
            }
        }
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                System.Diagnostics.Debug.WriteLine((Keys)vkCode);
                if ((Keys)vkCode == _shortcutkey)
                {
                    Send2Keyboard(Clipboard.GetText(), _keyStrokeDelay);
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void cmdSend_Click(object sender, EventArgs e)
        {
            try
            {
                Send2Keyboard(this.txtClip.Text, int.Parse(txtDelay.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message} \n {ex.StackTrace}");
                UnhookWindowsHookEx(_hookID);
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //setup the hook
                _hookID = SetHook(_proc);

                //populate the keys cbo
                foreach (Keys k in Enum.GetValues(typeof(Keys)))
                {
                    this.cboKey.Items.Add(k);
                }

                this.label1.Text = $"Types the contents of the clipboard when {_shortcutkey} is pressed";
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message} \n {ex.StackTrace}");
                UnhookWindowsHookEx(_hookID);
                return;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //remove the hook when the app is closed
            UnhookWindowsHookEx(_hookID);
        }

        private static void Send2Keyboard(string data, int delay)
        {
            SendKeys(data, delay);
        }

        public static void SendKeys(string data, int delay)
        {
            InputSimulator sim = new InputSimulator();
            int blockCounter = 0;
            foreach (char c in data)
            {
                sim.Keyboard.TextEntry(c);
                System.Threading.Thread.Sleep(delay);
                blockCounter++;
                if (blockCounter >= 100)
                {
                    //wait 100ms every 1000 chars
                    System.Threading.Thread.Sleep(100);
                    blockCounter = 0;
                }
            }

        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtClip.Text = Clipboard.GetText();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message} \n {ex.StackTrace}");
                return;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    Hide();
                    notifyIcon1.Visible = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message} \n {ex.StackTrace}");
                return;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Show();
                this.WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message} \n {ex.StackTrace}");
                return;
            }
        }

        private void cboKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            Keys k = (Keys)this.cboKey.SelectedItem;
            _shortcutkey = k;
            this.label1.Text = $"Types the contents of the clipboard when {_shortcutkey} is pressed";
        }

        private void chkAddDelay_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkAddDelay.Checked)
                    _keyStrokeDelay = int.Parse(txtDelay.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message} \n {ex.StackTrace}");
                return;
            }
        }
    }
}