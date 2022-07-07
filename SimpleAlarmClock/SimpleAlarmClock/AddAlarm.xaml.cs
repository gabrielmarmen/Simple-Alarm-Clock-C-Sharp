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
using WpfExtendedControls;

namespace SimpleAlarmClock
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            //Adding all the existing sounds in the ComboBox and sets the first one as selected
            foreach(Sound i in ((App)Application.Current).AppSoundList)
            {
                ComboBoxSound.Items.Add(i.Name);
            }
            ComboBoxSound.SelectedIndex = 0;

        }
        /// <summary>
        /// Enables dragging of the Window by the title section
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAlarmTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        /// <summary>
        /// Move the hours by one up. Resets to 0 when it reaches 12.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHourUp_Click(object sender, RoutedEventArgs e)
        {
            int StringToInt = Int32.Parse(LabelHours.Text);
            
            if (StringToInt < 12)
            {
                StringToInt++;
            }
            else
            {
                StringToInt = 0;
            }
            LabelHours.Text = StringToInt.ToString();
        }
        /// <summary>
        /// Move the hours by one down. Resets to 12 when it reaches 0.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHoursDown_Click(object sender, RoutedEventArgs e)
        {
            int StringToInt = Int32.Parse(LabelHours.Text);
            
            if (StringToInt > 0)
            {
                StringToInt--;
            }
            else
            {
                StringToInt = 12;
            }
            LabelHours.Text = StringToInt.ToString();

        }
        /// <summary>
        /// Move the hours by one up. Resets to 0 when it reaches 59.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMinutesUp_Click(object sender, RoutedEventArgs e)
        {

            int StringToInt = Int32.Parse(LabelMinutes.Text);

            if (StringToInt < 59)
            {
                StringToInt++;
            }
            else
            {
                StringToInt = 0;
            }

            
            //Checks if smaller than 10. If true adds a 0 in front of the string
            if (StringToInt < 10)
            {
                LabelMinutes.Text = "0" + StringToInt.ToString();

            }
            else
            {
                LabelMinutes.Text = StringToInt.ToString();
            }
            
        }
        /// <summary>
        /// Move the hours by one up. Resets to 59 when it reaches 0.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMinutesDown_Click(object sender, RoutedEventArgs e)
        {

            int StringToInt = Int32.Parse(LabelMinutes.Text);

            if (StringToInt > 0)
            {
                StringToInt--;
            }
            else
            {
                StringToInt = 59;
            }


            //Checks if smaller than 10. If true adds a 0 in front of the string
            if (StringToInt < 10)
            {
                LabelMinutes.Text = "0" + StringToInt.ToString();

            }
            else
            {
                LabelMinutes.Text = StringToInt.ToString();
            }
        }
        /// <summary>
        /// Changes the AM/PM Indicator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAMPMUp_Click(object sender, RoutedEventArgs e)
        {
            if(LabelAMPM.Text == "AM")
            {
                LabelAMPM.Text = "PM";
            }
            else
            {
                LabelAMPM.Text = "AM";
            }
        }
        /// <summary>
        /// Changes the AM/PM Indicator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAMPMDown_Click(object sender, RoutedEventArgs e)
        {
            if (LabelAMPM.Text == "AM")
            {
                LabelAMPM.Text = "PM";
            }
            else
            {
                LabelAMPM.Text = "AM";
            }
        }

        private void AddAlarmButton_Click(object sender, RoutedEventArgs e)
        {

            bool IsPM = false;
            if(LabelAMPM.Text == "PM")
            {
                IsPM = true;
            }

            Alarm newAlarm = new Alarm(CheckBoxRepeat.IsChecked, Int32.Parse(LabelHours.Text), Int32.Parse(LabelMinutes.Text), IsPM, TextBoxLabel.Text,((App)Application.Current).AppSoundList.Find(o => o.Name == ComboBoxSound.SelectedValue.ToString()));
            newAlarm.AddAlarmToList(newAlarm);
            this.Close();
        }
    }
}
