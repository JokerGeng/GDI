using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicsCanvas
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Threading.DispatcherTimer time;
        public MainWindow()
        {
            InitializeComponent();
            InitTime();
        }

        void InitTime()
        {
            if(time==null)
            {
                time = new System.Windows.Threading.DispatcherTimer();
                time.Tick += Time_Tick;
                time.Interval = new TimeSpan(3 * TimeSpan.TicksPerMillisecond);
                time.IsEnabled = true;
            }
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            drawingBoard.OnRefresh();
        }
    }
}
