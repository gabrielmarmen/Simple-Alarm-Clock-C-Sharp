using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using SimpleAlarmClock.Commands;
using SimpleAlarmClock.Components;

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
           UpdateStackPanelAlarms(); // Adds the alarms to the stackpanel of the main window

        }

        public void UpdateStackPanelAlarms()
        {
            StackPanelAlarms.Children.Clear();
            if (((App)Application.Current).AppAlarmList.Count != 0)
            {
                foreach (Alarm alarm in ((App)Application.Current).AppAlarmList)
                {
                    StackPanelAlarms.Children.Add(new AlarmControl(alarm));
                }
            }
        }

        private void titleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        /// <summary>
        /// Shows context menu on left click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, RoutedEventArgs e)
        {

            addButton.ContextMenu.PlacementTarget = addButton;
            addButton.ContextMenu.IsOpen = true;
            e.Handled = true;
        }
        /// <summary>
        /// When the close button is clicked, we execute the CloseApplicationCommand. ICommand needs an object as a parameter but we pass it as null because
        /// the method does not need any data from it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            
            CloseApplicationCommand command = (CloseApplicationCommand)FindResource("CloseApplication");
            command.Execute(null);
            
        }

        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            //Hides the Window and shows the TaskbarIcon
            this.Hide();
            this.tb.Visibility = Visibility.Visible;

            //Checks if Notification was already triggered once and if not, it triggers it.
            if (NotificationFlag != true)
            {
                this.tb.ShowBalloonTip("Hey", "SimpleAlarmClock has been reduced to the System Tray. You can open it back up by double clicking on the icon.", BalloonIcon.Info);
                this.NotificationFlag = true;
            }
        }

        private void AddAnAlarmMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window1();

            window.Owner = this;
            window.ShowDialog();
            UpdateStackPanelAlarms();

        }

        private void AddASoundMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).IOManager.AddNewSound();
        }
    }
}
