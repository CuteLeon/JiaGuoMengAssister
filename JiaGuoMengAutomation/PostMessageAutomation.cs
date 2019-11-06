using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace JiaGuoMengAutomation
{
    public class PostMessageAutomation : AutomationBase
    {
        // TODO: 测试 SendMessage 同步效果是否可以去掉 Sleep()
        [DllImport("user32", EntryPoint = "PostMessage", SetLastError = false, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int PostMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("user32", EntryPoint = "FindWindow", SetLastError = false, CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32", EntryPoint = "FindWindowEx", SetLastError = false, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindWindowEx(int hWnd1, int hWnd2, string lpsz1, string lpsz2);

        public PostMessageAutomation()
        {
            this.TargetHandle = this.GetRenderWindowHandle();

            // TODO: 获取坐标（取金币的中心坐标）
            this.Locations = new LocationCollection();
            this.Locations.BuildingsLocations = new List<Point>()
            {
                new Point(108, 273),
                new Point(108, 363),
                new Point(108, 455),

                new Point(200, 227),
                new Point(200, 319),
                new Point(200, 408),

                new Point(290, 182),
                new Point(290, 272),
                new Point(290, 364),
            };
            this.Locations.GiftsLocations = new List<Point>()
            {
                new Point(240, 590),
                new Point(295, 565),
                new Point(350, 535),
            };
        }

        private IntPtr GetRenderWindowHandle()
        {
            int handle = 0;
            int renderHandle;

            do
            {
                handle = FindWindowEx(0, handle, "TXGuiFoundation", null);
                renderHandle = FindWindowEx(handle, 0, "AEngineRenderWindowClass", null);
            }
            while (handle != 0 && renderHandle == 0);

            return new IntPtr(renderHandle);
        }

        public int GetLParam(int x, int y)
        {
            return y << 16 | x;
        }

        public override void MouseClick(int x, int y)
        {
            int lparam = this.GetLParam(x, y);
            this.MouseLeftDown(lparam);
            this.MouseLeftUp(lparam);
        }

        public override void MouseLeftDown(int x, int y)
        {
            int lparam = this.GetLParam(x, y);
            this.MouseLeftDown(lparam);
        }

        public void MouseLeftDown(int lparam)
        {
            PostMessage(this.TargetHandle, 0x201, 1, lparam);
        }

        public override void MouseLeftUp(int x, int y)
        {
            int lparam = this.GetLParam(x, y);
            this.MouseLeftUp(lparam);
        }

        public void MouseLeftUp(int lparam)
        {
            PostMessage(this.TargetHandle, 0x202, 0, lparam);
        }

        public override void MouseMove(int x, int y)
        {
            int lparam = this.GetLParam(x, y);
            PostMessage(this.TargetHandle, 0x200, 0, lparam);
        }
    }
}
