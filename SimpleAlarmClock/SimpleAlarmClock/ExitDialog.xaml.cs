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

namespace SimpleAlarmClock
{
    /// <summary>
    /// Interaction logic for ExitDialog.xaml
    /// </summary>
    public partial class ExitDialog : Window
    {
        public bool StopShowing { get; set; }  
        public ExitDialog()
        {
            InitializeComponent();
            Owner = ((App)Application.Current).MainWindow;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxStopShowingExitNotification.IsChecked == true)
            {
                StopShowing = true; 
                DialogResult = true;
            }
            else
            {
                StopShowing = false;
                DialogResult = true;
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxStopShowingExitNotification.IsChecked == true)
            {
                StopShowing = true;
                DialogResult = false;
            }
            else
            {
                StopShowing = false;
                DialogResult = false;
            }
        }
    }
}
