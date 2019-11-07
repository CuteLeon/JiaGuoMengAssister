using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace JiaGuoMengAutomation
{
    public class BlueStacksAutomation : AutomationBase
    {
        [DllImport("user32", EntryPoint = "SendMessage", SetLastError = false, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("user32", EntryPoint = "FindWindowEx", SetLastError = false, CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindWindowEx(int hWnd1, int hWnd2, string lpsz1, string lpsz2);

        public BlueStacksAutomation()
        {
            this.TargetHandle = this.GetWindowHandle();

            // TODO: 读取分辨率，以 360x640 为准
            this.Locations = new LocationCollection
            {
                BuildingsLocations = new List<Point>()
                {
                },
                GiftsLocations = new List<Point>()
                {
                },
                EmptyLocation = new Point()
            };
        }

        private IntPtr GetWindowHandle()
        {
            int handle = 0;
            int hostHandle;

            do
            {
                handle = FindWindowEx(0, handle, "BS2CHINAUI", "BlueStacks App Player");
                hostHandle = FindWindowEx(handle, 0, "BS2CHINAUI", "HOSTWND");
            }
            while (handle != 0 && hostHandle == 0);

            return new IntPtr(hostHandle);
        }

        public override void MouseClick(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override void MouseLeftDown(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override void MouseLeftUp(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override void MouseMove(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
