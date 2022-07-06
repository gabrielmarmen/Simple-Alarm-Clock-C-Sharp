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
using Hardcodet.Wpf.TaskbarNotification;


namespace SimpleAlarmClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TaskbarIcon tb;
        private bool NotificationFlag;

        public MainWindow()
        {
           InitializeComponent();

           tb = (TaskbarIcon)FindResource("NotifyIcon");//Gets the TaskBarIcon from the ressources of the Application and puts its reference into tb
           NotificationFlag = false; // Flag that indicates if the Taskbar notification has already been triggered. 

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
            //Hides the Window and S
            this.Hide();
            this.tb.Visibility = Visibility.Visible;

            //Checks if Notification was already triggered once and if not, it triggers it.
            if(NotificationFlag!=true)
            {
                this.tb.ShowBalloonTip("Hey", "SimpleAlarmClock has been reduced to the System Tray. You can open it back up by double clicking on the icon.", BalloonIcon.Info);
                this.NotificationFlag = true;
            }
            
            
        }
    }
}
