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
    /// Interaction logic for ModifyAlarm.xaml
    /// </summary>
    public partial class ModifyAlarm : Window
    {
        public Alarm AlarmObject { get; set; } 


        public ModifyAlarm()
        {
            AlarmObject = new Alarm();
            InitializeComponent();
        }

        public ModifyAlarm(Alarm AlarmToModify)
        {
            AlarmObject = AlarmToModify;
            InitializeComponent();
        }
    }
}
