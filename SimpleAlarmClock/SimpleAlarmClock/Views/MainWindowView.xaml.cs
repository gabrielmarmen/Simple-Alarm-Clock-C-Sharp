using Hardcodet.Wpf.TaskbarNotification;
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
using System.Windows.Shapes;

namespace SimpleAlarmClock.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        private TaskbarIcon tb;

        public MainWindowView()
        {
            InitializeComponent();
            tb = (TaskbarIcon)FindResource("NotifyIcon");

        }

        private void titleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window1();

            window.Owner = this;
            window.ShowDialog();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.tb.Visibility = Visibility.Visible;
            this.tb.ShowBalloonTip("Hey", "SimpleAlarmClock has been reduced to the System Tray. You can open it back up by double clicking on the icon.", BalloonIcon.Info);

        }
    }
}
