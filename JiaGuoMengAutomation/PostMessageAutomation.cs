using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace JiaGuoMengAutomation
{
    public class PostMessageAutomation : IAutomation
    {
        // TODO: 测试 SendMessage 同步效果是否可以去掉 Sleep()
        [DllImport("user32", EntryPoint = "PostMessage", SetLastError = false, CharSet = CharSet.Auto, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int PostMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public IntPtr TargetHandle { get; set; }

        public LocationCollection Locations { get; set; }

        public CancellationToken Token { get; set; }

        public PostMessageAutomation()
        {
            this.TargetHandle = this.GetRenderWindowHandle();

            // TODO: 获取坐标（取金币的中心坐标）
            this.Locations = new LocationCollection();
        }

        private IntPtr GetRenderWindowHandle()
        {
            // TODO: 获取句柄
            return IntPtr.Zero;
        }

        public void ClickBuildings()
        {
            this.Locations.BuildingsLocations.ForEach((building) =>
            {
                this.MouseClick(building.X, building.Y);
                Thread.Sleep(20);
            });
        }

        public void ClickEmpty()
        {
            this.MouseClick(this.Locations.EmptyLocation.X, this.Locations.EmptyLocation.Y);
        }

        public void DragGifts()
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

                    for (int index = 0; index < 3; index++)
                    {
                        this.MouseMove(gift.X, gift.Y);
                        Thread.Sleep(time);
                        this.MouseLeftDown(-1, -1);
                        Thread.Sleep(time);
                        this.MouseMove(building.X, building.Y);
                        Thread.Sleep(time);
                        this.MouseLeftUp(-1, -1);
                        Thread.Sleep(time);
                    }
                }
            }
        }

        public int GetLParam(int x, int y)
            => y << 16 | x;

        public void MouseClick(int x, int y)
        {
            int lparam = this.GetLParam(x, y);
            this.MouseLeftDown(lparam);
            this.MouseLeftUp(lparam);
        }

        public void MouseLeftDown(int x, int y)
        {
            int lparam = this.GetLParam(x, y);
            this.MouseLeftDown(lparam);
        }

        public void MouseLeftDown(int lparam)
        {
            PostMessage(this.TargetHandle, 0x201, 1, lparam);
        }

        public void MouseLeftUp(int x, int y)
        {
            int lparam = this.GetLParam(x, y);
            this.MouseLeftUp(lparam);
        }

        public void MouseLeftUp(int lparam)
        {
            PostMessage(this.TargetHandle, 0x202, 0, lparam);
        }

        public void MouseMove(int x, int y)
        {
            int lparam = this.GetLParam(x, y);
            PostMessage(this.TargetHandle, 0x200, 0, lparam);
        }
    }
}
