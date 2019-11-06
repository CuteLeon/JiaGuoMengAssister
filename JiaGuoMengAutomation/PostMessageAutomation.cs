using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace JiaGuoMengAutomation
{
    public class PostMessageAutomation : AutomationBase
    {
        [DllImport("user32", EntryPoint = "SendMessage", SetLastError = false, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("user32", EntryPoint = "FindWindow", SetLastError = false, CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32", EntryPoint = "FindWindowEx", SetLastError = false, CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindWindowEx(int hWnd1, int hWnd2, string lpsz1, string lpsz2);

        public PostMessageAutomation()
        {
            this.TargetHandle = this.GetRenderWindowHandle();

            // TODO: 获取坐标（取金币的中心坐标）
            this.Locations = new LocationCollection();
            this.Locations.BuildingsLocations = new List<Point>()
            {
                new Point(108, 262),
                new Point(108, 352),
                new Point(108, 440),

                new Point(200, 216),
                new Point(200, 305),
                new Point(200, 395),

                new Point(290, 170),
                new Point(290, 260),
                new Point(290, 350),
            };
            this.Locations.GiftsLocations = new List<Point>()
            {
                new Point(240, 590),
                new Point(295, 565),
                new Point(350, 535),
            };
            this.Locations.EmptyLocation = new Point(190, 75);
        }

        public override void DragGifts()
        {
            const int time = 100;
            foreach (Point gift in this.Locations.GiftsLocations)
            {
                foreach (Point building in this.Locations.BuildingsLocations)
                {
                    // 及时退出
                    if (this.Token.IsCancellationRequested)
                    {
                        return;
                    }

                    for (int index = 0; index < 4; index++)
                    {
                        this.MouseMove(gift.X, gift.Y);
                        Thread.Sleep(time);
                        this.MouseLeftDown(gift.X, gift.Y);
                        Thread.Sleep(time);
                        this.MouseMove(building.X, building.Y);
                        Thread.Sleep(time);
                        this.MouseLeftUp(building.X, building.Y);
                        Thread.Sleep(time);
                    }
                }
            }
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
            SendMessage(this.TargetHandle, 0x201, 1, lparam);
        }

        public override void MouseLeftUp(int x, int y)
        {
            int lparam = this.GetLParam(x, y);
            this.MouseLeftUp(lparam);
        }

        public void MouseLeftUp(int lparam)
        {
            SendMessage(this.TargetHandle, 0x202, 0, lparam);
        }

        public override void MouseMove(int x, int y)
        {
            int lparam = this.GetLParam(x, y);
            SendMessage(this.TargetHandle, 0x200, 0, lparam);
        }
    }
}
