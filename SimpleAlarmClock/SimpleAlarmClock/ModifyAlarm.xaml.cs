using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public Alarm ModifiedObject { get; set; }   
        public string FixedMinutes { get; set; }
        public string AMPM { get; set; }


        public ModifyAlarm()
        {
            AlarmObject = new Alarm();
            InitializeComponent();
        }

        public ModifyAlarm(Alarm AlarmToModify)
        {
            AlarmObject = AlarmToModify;
            FixMinutes();
            SetAMPMString();
            InitializeComponent();

            foreach (Sound i in ((App)Application.Current).AppSoundList)
            {
                ComboBoxSound.Items.Add(i.Name);
            }
            ComboBoxSound.SelectedItem = AlarmObject.AlarmSound.Name;
        }

        public void FixMinutes()
        {
            if (this.AlarmObject.Minutes < 10)
            {
                this.FixedMinutes = "0" + this.AlarmObject.Minutes.ToString();
            }
            else
            {
                this.FixedMinutes = this.AlarmObject.Minutes.ToString();
            }    
        }
        public void SetAMPMString()
        {
            if(this.AlarmObject.PM == true)
            {
                this.AMPM = "PM";
            }
            else
            {
                this.AMPM = "AM";
            }
        }
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
                StringToInt = 1;
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

            if (StringToInt > 1)
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
            if (LabelAMPM.Text == "AM")
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


        private void CancelAddAlarmButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            Sound selectedSound = ((App)Application.Current).AppSoundList.Find(o => o.Name == ComboBoxSound.SelectedItem.ToString());
            if (selectedSound != null)
            {
                selectedSound.Play();
            }

        }

        private void DeleteAlarmButton_Click(object sender, RoutedEventArgs e)
        {
            
            ((App)Application.Current).AppAlarmList.Remove(this.AlarmObject);
            ((App)Application.Current).IOManager.SaveAlarmsToDisk();
            ((MainWindow)this.Owner).UpdateStackPanelAlarms();
            this.Close();
        }

        private void CancelUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UpdateAlarmButton_Click(object sender, RoutedEventArgs e)
        {
            bool IsPM = false;
            if (LabelAMPM.Text == "PM")
            {
                IsPM = true;
            }



            
            foreach (Alarm obj in ((App)Application.Current).AppAlarmList)
            {
                if (obj.CreationDateTime == AlarmObject.CreationDateTime)
                {
                    if (TextBoxLabel.Text == "")
                    {
                        TextBoxLabel.Text = "Alarm";
                    }
                    obj.ModifyObject(CheckBoxRepeat.IsChecked, Int32.Parse(LabelHours.Text), Int32.Parse(LabelMinutes.Text), IsPM, CheckBoxSnooze.IsChecked, TextBoxLabel.Text, ((App)Application.Current).AppSoundList.Find(o => o.Name == ComboBoxSound.SelectedValue.ToString()));
                    obj.Enabled= true; //Sets the Alarm's Enabled value to true. When the property is enabled, it triggers the scheduling of the alarm. No need to schedule from here
                    AlarmObject.ScheduleAndRunAlarms();

                }
            }
            
            (Application.Current.MainWindow as MainWindow).UpdateStackPanelAlarms();
            ((App)Application.Current).IOManager.SaveAlarmsToDisk();
            this.Close();
            


        }
    }
}
