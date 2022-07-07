using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleAlarmClock
{
    /// <summary>
    /// This is the Alarm Class. Contains a single alarm object values and it's methods.
    /// </summary>
    public class Alarm
    {
        public bool Repeat; //Is the alarm repeating
        public int Hours; //Alarm hour of the day
        public int Minutes; //Alarm minutes of the hour property
        public bool PM; //Defines if the Alarm is in the afternoon
        public string Label; //Name of the Alarm
        public Sound AlarmSound; //Where is the alarm's sound
        public string WhenIndicator; //Is indicating to the user when is the alarm (Tommorow, Every weekday, Every Monday etc)


        public Alarm()
        {
            Repeat = false;
            Hours = 8;
            Minutes = 0;
            PM = false;
            Label = "Alarm";
            AlarmSound = new Sound();
            WhenIndicator = SetAlarmWhenIndicator();
        }


        public Alarm(bool? repeat, int hours, int minutes, bool pm, string label, Sound alarmSound)
        {
            bool newBool = repeat ?? false;
            Repeat = newBool;
            Hours = hours;
            Minutes = minutes;
            PM = pm;
            Label = label;
            AlarmSound = alarmSound;
            WhenIndicator = SetAlarmWhenIndicator();
        }

        public string SetAlarmWhenIndicator()
        {
            if (Repeat)
            {
                return "Every Day";
            }
            else
            {
                return "Tommorow";
            }
            
        }
        public void AddAlarmToList(Alarm newAlarm)
        {
            //Adds the alarm to the current list of alarms loaded in the app
            ((App)Application.Current).AppAlarmList.Add(newAlarm);
            //Calls the Method SaveAlarmsToDisk from IOManagement instance from the current app.
            //This Saves the newly updated list to the disk
            ((App)Application.Current).IOManager.SaveAlarmsToDisk();
            
        }
    }
}
