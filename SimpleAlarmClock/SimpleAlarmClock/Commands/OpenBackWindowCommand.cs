using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Hardcodet.Wpf.TaskbarNotification;


namespace SimpleAlarmClock.Commands
{
    internal class OpenBackWindowCommand : ICommand
    {
        private TaskbarIcon tb;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Application.Current.MainWindow.Visibility = Visibility.Visible;
            tb = (TaskbarIcon)Application.Current.Resources["NotifyIcon"];
            tb.Visibility = Visibility.Hidden;
        }

    }
}
