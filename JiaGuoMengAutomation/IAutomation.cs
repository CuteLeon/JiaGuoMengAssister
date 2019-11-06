using System;
using System.Threading;

namespace JiaGuoMengAutomation
{
    public interface IAutomation
    {
        IntPtr TargetHandle { get; set; }

        LocationCollection Locations { get; set; }

        CancellationToken Token { get; set; }

        void MouseClick(int x, int y);

        void MouseMove(int x, int y);

        void MouseLeftDown(int x, int y);

        void MouseLeftUp(int x, int y);

        void ClickBuildings();

        void ClickEmpty();

        void DragGifts();
    }
}
