using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace JiaGuoMengAutomation
{
    internal class MouseEventAutomation : IAutomation
    {
        #region API
        [DllImport("User32")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

        public struct POINT
        {
            public int X;
            public int Y;
        }

        public enum MouseEventFlags
        {
            Move = 0x0001, //移动鼠标
            LeftDown = 0x0002,//模拟鼠标左键按下
            LeftUp = 0x0004,//模拟鼠标左键抬起
            RightDown = 0x0008,//鼠标右键按下
            RightUp = 0x0010,//鼠标右键抬起
            MiddleDown = 0x0020,//鼠标中键按下 
            MiddleUp = 0x0040,//中键抬起
            Wheel = 0x0800,
            Absolute = 0x8000//标示是否采用绝对坐标
        }
        #endregion

        /// <summary>
        /// 需要将游戏窗口最大化，并置顶显示
        /// </summary>
        [Obsolete]
        public MouseEventAutomation()
        {
            this.Locations = new LocationCollection();
            this.Locations.BuildingsLocations = new List<Point>()
            {
                new Point(562, 296),
                new Point(562, 387),
                new Point(562, 476),

                new Point(656, 250),
                new Point(656, 341),
                new Point(656, 436),

                new Point(758, 204),
                new Point(758, 297),
                new Point(758, 390),
            };
            this.Locations.GiftsLocations = new List<Point>()
            {
                new Point(697, 628),
                new Point(752, 602),
                new Point(806, 572),
            };
        }

        public CancellationToken Token { get; set; }

        public IntPtr TargetHandle { get; set; }

        public LocationCollection Locations { get; set; }

        public void ClickBuildings()
        {
            foreach (Point building in this.Locations.BuildingsLocations)
            {
                this.MouseClick(building.X, building.Y);
                Thread.Sleep(20);
            }
        }

        public void ClickEmpty()
        {
            this.MouseClick(663, 100);
            Thread.Sleep(20);
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

        public void MouseClick(int x, int y)
        {
            this.MouseMove(x, y);
            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
        }

        public void MouseMove(int x, int y)
        {
            mouse_event((int)(MouseEventFlags.Move | MouseEventFlags.Absolute), x * 48, y * 85, 0, IntPtr.Zero);
        }

        [Obsolete("无法移动到指定坐标")]
        public void MouseLeftDown(int x, int y)
        {
            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
        }

        [Obsolete("无法移动到指定坐标")]
        public void MouseLeftUp(int x, int y)
        {
            mouse_event((int)(MouseEventFlags.LeftUp | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
        }
    }
}
