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






        public string test
        {
            get { return (string)GetValue(testProperty); }
            set { SetValue(testProperty, value); }
        }

        // Using a DependencyProperty as the backing store for test.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty testProperty =
            DependencyProperty.Register("test", typeof(string), typeof(AlarmControl), new PropertyMetadata(""));







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
            test = "Sheesh";
            InitializeComponent();
            
        }
        public AlarmControl(Alarm alarm)
        {

            AlarmObject = alarm;
            InitializeComponent();

        }
    }
}
