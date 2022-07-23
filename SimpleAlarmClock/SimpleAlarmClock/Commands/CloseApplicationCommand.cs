
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SimpleAlarmClock.Commands
{
    internal class CloseApplicationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
            if (!((App)Application.Current).AppConfigs.StopShowingExitNotification)
            {
                ExitDialog window = new ExitDialog();
                bool value = window.ShowDialog() ?? false;
                bool StopShowing = window.StopShowing;
                if (value)
                {
                    if (StopShowing)
                    {
                        ((App)Application.Current).AppConfigs.StopShowingExitNotification = true;
                        ((App)Application.Current).IOManager.SaveConfigsToDisk();
                    }
                    ((App)Application.Current).MainWindow.Close();
                    foreach (var item in ((App)Application.Current).AppAlarmList)
                    {
                        if (item.t != null)
                        {
                            item.t.Abort();
                        }
                    }
                    
                }
                if (StopShowing)
                {
                    ((App)Application.Current).AppConfigs.StopShowingExitNotification = true;
                    ((App)Application.Current).IOManager.SaveConfigsToDisk();
                }

            }
            else
            {
                ((App)Application.Current).MainWindow.Close();
                foreach (var item in ((App)Application.Current).AppAlarmList)
                {
                    if (item.t != null)
                    {
                        item.t.Abort();
                    }
                }
            }

        


        //if (MessageBox.Show("Are you sure you want to quit SimpleAlarmClock ? \r\nIf you quit, your alarms won't be ringing anymore.\r\n\r\nIf you want it to run in the background, click the hide button in the main window.",
        //        "Closing the Application",
        //        MessageBoxButton.YesNo, 
        //        MessageBoxImage.Warning,
        //        MessageBoxResult.None,
        //        MessageBoxOptions.DefaultDesktopOnly) == MessageBoxResult.Yes)
        //{ 



    }
    }
}
