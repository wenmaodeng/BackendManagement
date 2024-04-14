using BackendManagement.MessageEvent;
using Prism.Events;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BackendManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IEventAggregator aggregator)
        {
            InitializeComponent();
            aggregator.GetEvent<WindowManagerEvent>().Subscribe(handleWindowManagerEvent);
            colorZone.MouseMove += ColorZone_MouseMove;
        }

        private void ColorZone_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton== MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        private void handleWindowManagerEvent(string message)
        {
            if (string.IsNullOrEmpty(message))
                return;
            if(message== "WindowMaximize")
            {
                if(this.WindowState== WindowState.Normal)
                {
                    this.WindowState = WindowState.Maximized;
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                }
            }
            else if (message == "WindowMinimize")
            {
                this.WindowState = WindowState.Minimized;
            }
            else if(message == "WindowClose")
            {
                Application.Current.Shutdown();
            }
        }
    }
}