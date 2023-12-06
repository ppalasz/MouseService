using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace MouseService
{
    public partial class MouseMoveService : ServiceBase
    {
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSE_TIME = 500;
        private Timer timer;

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);


        public MouseMoveService()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            timer = new Timer();
            timer.Interval = MOUSE_TIME; // Ustaw interwał na 1 minutę
            timer.Elapsed += new ElapsedEventHandler(OnTimer);
            timer.Start();
        }

        private void OnTimer(object sender, ElapsedEventArgs args)
        {
            // Symulacja ruchu myszy
            MoveMouse();
        }

        protected override void OnStop()
        {
            timer.Stop();
        }

        private void MoveMouse()
        {
            mouse_event(MOUSEEVENTF_MOVE, 0, 1, 0, 0);
            Thread.Sleep(MOUSE_TIME); 
            mouse_event(MOUSEEVENTF_MOVE, 0, -1, 0, 0);
        }
    }
}
