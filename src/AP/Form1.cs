using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace AP
{
    public partial class AP : Form
    {
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "keybd_event", ExactSpelling = true, SetLastError = true)]
        public static extern void KEYB_Event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        [DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern Keys GetAsyncKeyState(Keys Tecla);

        [DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "GetAsyncKeyState", ExactSpelling = true, SetLastError = true)]
        private static extern int GetKeyPress(int key);
        public AP()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GetKeyPress(113) != 0)
            {
                this.label1.Text = "AutoPotion - ON";
                this.timer2.Start();
            }
            else if (GetKeyPress(114) != 0)
            {
                this.label1.Text = "AutoPotion - OFF";
                this.timer2.Stop();
            }

            if (GetKeyPress(163) != 0)
            {
                this.Opacity = 100;
                this.ShowInTaskbar = true;
            }
            else if (GetKeyPress(161) != 0)
            {
                this.Opacity = 0;
                this.ShowInTaskbar = false;
            }

        }

        private const byte VK_CONTROL = 17;
        private const byte VK_KEY_Q = 81;
        private const byte VK_KEY_W = 87;
        private const byte VK_KEY_E = 69;
        private const byte KEYEVENTF_KEYUP = 2;
        private const byte VK_KEY_1 = 49;
        private const byte VK_KEY_2 = 50;
        private const byte VK_KEY_3 = 51;

        private void timer2_Tick(object sender, EventArgs e)
        {
            AP.KEYB_Event(81, 0, 0, 0);
            AP.KEYB_Event(81, 0, 2, 0);
            AP.KEYB_Event(87, 0, 0, 0);
            AP.KEYB_Event(87, 0, 2, 0);
            AP.KEYB_Event(69, 0, 0, 0);
            AP.KEYB_Event(69, 0, 2, 0);

            Thread.Sleep(70);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
            this.label1.Text = "AutoPotion - ON";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.label1.Text = "AutoPotion - OFF";
        }
    }
}
