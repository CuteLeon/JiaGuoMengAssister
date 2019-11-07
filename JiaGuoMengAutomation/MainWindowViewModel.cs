using System;
using System.ComponentModel;

namespace JiaGuoMengAutomation
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private IntPtr renderHandle;
        private bool collectBuliding = true;
        private bool collectGift = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public IntPtr RenderHandle
        {
            get => this.renderHandle;
            set
            {
                System.Diagnostics.Debug.Print($"渲染句柄：0x{value.ToString("X")}");
                this.renderHandle = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.RenderHandle)));
            }
        }

        public bool CollectBuliding
        {
            get => this.collectBuliding;
            set
            {
                System.Diagnostics.Debug.Print($"收集建筑：{value}");
                this.collectBuliding = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CollectBuliding)));
            }
        }

        public bool CollectGift
        {
            get => this.collectGift;
            set
            {
                System.Diagnostics.Debug.Print($"收集供货：{value}");
                this.collectGift = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CollectGift)));
            }
        }
    }
}
