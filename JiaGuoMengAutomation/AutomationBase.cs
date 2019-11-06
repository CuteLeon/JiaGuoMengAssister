using System;
using System.Drawing;
using System.Threading;

namespace JiaGuoMengAutomation
{
    public abstract class AutomationBase : IAutomation
    {
        public IntPtr TargetHandle { get; set; }

        public LocationCollection Locations { get; set; }

        public CancellationToken Token { get; set; }

        public virtual void ClickBuildings()
        {
            this.Locations.BuildingsLocations.ForEach((building) =>
            {
                this.MouseClick(building.X, building.Y);
                Thread.Sleep(20);
            });
        }

        public virtual void ClickEmpty()
        {
            this.MouseClick(this.Locations.EmptyLocation.X, this.Locations.EmptyLocation.Y);
        }

        /// <summary>
        /// 火车间隔约20S，火车停留约1:30s，自动执行约 45s
        /// </summary>
        public virtual void DragGifts()
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

        public abstract void MouseClick(int x, int y);

        public abstract void MouseLeftDown(int x, int y);

        public abstract void MouseLeftUp(int x, int y);

        public abstract void MouseMove(int x, int y);
    }
}
