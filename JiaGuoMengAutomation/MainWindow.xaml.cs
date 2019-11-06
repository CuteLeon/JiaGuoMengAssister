using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace JiaGuoMengAutomation
{
    // TODO: 热键开关
    // TODO: 测试 Debug附加调试器|Debug未附加调试器|Release 模式下能否自动收集供货
    // TODO: 优化收集供货的效率

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region API
        [DllImport("User32")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

        [DllImport("User32")]
        public static extern void SetCursorPos(int x, int y);

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

        #region 坐标
        private static readonly List<Point> BuildingLocations = new List<Point>()
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
        private static readonly List<Point> giftLocations = new List<Point>()
        {
            new Point(697, 628),
            new Point(752, 602),
            new Point(806, 572),
        };
        #endregion

        private long counter = 0;
        private CancellationTokenSource source;
        private CancellationToken token;
        private enum States
        {
            Idle = 0,
            Execute = 1,
            Wait = 2,
        }
        private States state;
        private States State
        {
            get => this.state;
            set
            {
                if (this.state == value)
                {
                    return;
                }

                this.state = value;
                switch (this.state)
                {
                    case States.Idle:
                        {
                            this.Print($"空闲");
                            break;
                        }
                    case States.Execute:
                        {
                            this.Print($"开始 {++this.counter}");
                            break;
                        }
                    case States.Wait:
                        {
                            this.Print($"正在等待 ...");
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void ClickBuildings()
        {
            foreach (Point building in BuildingLocations)
            {
                mouse_event((int)(MouseEventFlags.Move | MouseEventFlags.Absolute), (int)(building.X * 48), (int)(building.Y * 85), 0, IntPtr.Zero);
                mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
                Thread.Sleep(20);
            }
        }

        private void ClickGifts()
        {
            const int time = 100;
            foreach (Point gift in giftLocations)
            {
                foreach (Point building in BuildingLocations)
                {
                    // 及时退出
                    if (this.token.IsCancellationRequested)
                    {
                        return;
                    }

                    for (int index = 0; index < 3; index++)
                    {
                        mouse_event((int)(MouseEventFlags.Move | MouseEventFlags.Absolute), (int)(gift.X * 48), (int)(gift.Y * 85), 0, IntPtr.Zero);
                        Thread.Sleep(time);
                        mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
                        Thread.Sleep(time);
                        mouse_event((int)(MouseEventFlags.Move | MouseEventFlags.Absolute), (int)(building.X * 48), (int)(building.Y * 85), 0, IntPtr.Zero);
                        Thread.Sleep(time);
                        mouse_event((int)(MouseEventFlags.LeftUp | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private static void ClickEmpty()
        {
            mouse_event((int)(MouseEventFlags.Move | MouseEventFlags.Absolute), 663 * 48, 100 * 85, 0, IntPtr.Zero);
            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
            Thread.Sleep(20);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.source != null)
            {
                this.source.Cancel();
            }
            else
            {
                this.source = new CancellationTokenSource();
                this.token = this.source.Token;
                Task.Factory.StartNew(new Action(() =>
                {
#if DEBUG
                    this.TestAction();
#else
                    this.TaskAction();
#endif

                    this.State = States.Idle;
                    this.source = null;
                }), this.token);
            }
        }

        private void Print(string message)
        {
            this.Dispatcher.Invoke(() => this.MainButton.Content = message);
        }

        private void TaskAction()
        {
            while (true)
            {
                this.State = States.Execute;

                ClickEmpty();
                this.ClickBuildings();
                this.ClickGifts();

                if (this.token.IsCancellationRequested)
                {
                    return;
                }

                this.State = States.Wait;
                Thread.Sleep(10000);

                if (this.token.IsCancellationRequested)
                {
                    break;
                }
            }
        }

        private void TestAction()
        {
            const int time = 100;
            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
            Thread.Sleep(time);
            mouse_event((int)(MouseEventFlags.Move), 600, 600, 0, IntPtr.Zero);
            Thread.Sleep(time);
            mouse_event((int)(MouseEventFlags.LeftUp | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
        }
    }
}
