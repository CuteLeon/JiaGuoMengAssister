using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace JiaGuoMengAutomation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private long counter = 0;
        private CancellationTokenSource source;
        private CancellationToken token;
        private MainWindowViewModel viewModel;
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

        IAutomation automation { get; set; }

        public MainWindow()
        {
            this.InitializeComponent();

            this.automation = new TXGameAutomation();

            this.viewModel = new MainWindowViewModel();
            this.viewModel.RenderHandle = this.automation.TargetHandle;
            this.DataContext = this.viewModel;
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
                    this.automation.Token = this.token;

                    this.TaskAction();

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

                this.automation.ClickEmpty();
                Thread.Sleep(1000);

                if (this.viewModel.CollectBuliding)
                {
                    this.automation.ClickBuildings();
                }

                if (this.viewModel.CollectGift)
                {
                    this.automation.DragGifts();
                }

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
    }
}
