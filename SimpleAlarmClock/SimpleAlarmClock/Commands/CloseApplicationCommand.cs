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
            if (MessageBox.Show("Are you sure you want to quit SimpleAlarmClock ? \r\nYour alarms won't be ringning anymore",
                    "Closing the Application",
                    MessageBoxButton.YesNo, 
                    MessageBoxImage.Question,
                    MessageBoxResult.None,
                    MessageBoxOptions.DefaultDesktopOnly) == MessageBoxResult.Yes)
            {
                Application.Current.MainWindow.Close();
            }
            
        }
    }
}
