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

namespace SimpleAlarmClock.Components
{

    
    /// <summary>
    /// Interaction logic for AlarmControl.xaml
    /// </summary>
    public partial class AlarmControl : UserControl
    {



        public Alarm AlarmObject
        {
            get { return (Alarm)GetValue(AlarmObjectProperty); }
            set { SetValue(AlarmObjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AlarmObject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AlarmObjectProperty =
            DependencyProperty.Register("AlarmObject", typeof(Alarm), typeof(AlarmControl), new PropertyMetadata(new Alarm()));


        public AlarmControl()
        {
            
            AlarmObject = new Alarm();
            AlarmObject.HoursAndMinutes = "Sheesh";
            InitializeComponent();
            
        }
        public AlarmControl(Alarm alarm)
        {

            AlarmObject = alarm;
            InitializeComponent();

        }

        private void EnabledCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            AlarmObject.Enabled = false;
            if(AlarmObject != null)
            {
                AlarmObject.t.Abort();
            }
            ((App)Application.Current).IOManager.SaveAlarmsToDisk();
        }

        private void EnabledCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            AlarmObject.Enabled = true;
            AlarmObject.ScheduleAndRunAlarms();
            ((App)Application.Current).IOManager.SaveAlarmsToDisk();
        }

        private void AlarmInfoGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2f3032"));
        }

        private void AlarmInfoGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00FFFFFF"));
        }

        private void AlarmInfoGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var window = new ModifyAlarm(AlarmObject);
            window.Owner = ((App)Application.Current).MainWindow;
            window.ShowDialog();
        }

        //private void BorderAlarm_MouseEnter(object sender, MouseEventArgs e)
        //{
        //
        //    this.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2f3032"));
        //}

    }
}
