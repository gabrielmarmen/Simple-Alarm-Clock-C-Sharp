using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleAlarmClock
{
    /// <summary>
    /// This is the Alarm Class. Contains a single alarm object's properties and it's methods.
    /// </summary>
    public class Alarm
    {

        public bool Repeat { get; set; } //Is the alarm repeating
        public int Hours { get; set; } //Alarm hour of the day
        public int Minutes { get; set; } //Alarm minutes of the hour property
        public string HoursAndMinutes { get; set; } //UI uses this property to show the time of the alarm
        public bool PM { get; set; } //Defines if the Alarm is in the afternoon
        public bool Snooze { get; set; } //Defines if the alarm is allowed to snooze
        public string Label { get; set; } //Name of the Alarm
        public Sound AlarmSound { get; set; } //Where is the alarm's sound
        public string WhenIndicator { get; set; } //Is indicating to the user when is the alarm (Tommorow, Every weekday, Every Monday etc)
        public bool Enabled { get; set; } //Indicates if the Alarm is Enabled or not.
        public DateTime CreationDateTime { get; set; } //Mainly used as unique identificator


        public Alarm()
        {
            Repeat = false;
            Hours = 8;
            Minutes = 0;
            HoursAndMinutes = GetHoursAndMinutes();
            PM = false;
            Label = "Alarm";
            AlarmSound = new Sound();
            WhenIndicator = SetAlarmWhenIndicator();
            Enabled = true;
            CreationDateTime = DateTime.Now;
        }


        public Alarm(bool? repeat, int hours, int minutes, bool pm, bool? snooze, string label, Sound alarmSound)
        {
            bool newBoolRepeat = repeat ?? false;
            bool newBoolSnooze = snooze ?? false;
            Repeat = newBoolRepeat;
            Hours = hours;
            Minutes = minutes;
            PM = pm;
            HoursAndMinutes = GetHoursAndMinutes();
            Snooze = newBoolSnooze;
            Label = label;
            AlarmSound = alarmSound;
            WhenIndicator = SetAlarmWhenIndicator();
            Enabled = true;
            CreationDateTime = DateTime.Now;

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
        public string GetHoursAndMinutes()
        {
            if(this.Minutes<10)
            {
                if(PM == true)
                {
                    return this.Hours.ToString() + ":0" + this.Minutes.ToString() + " PM";
                }
                else
                {
                    return this.Hours.ToString() + ":0" + this.Minutes.ToString() + " AM";
                }
                
            }
            else
            {
                if (PM == true)
                {
                    return this.Hours.ToString() + ":" + this.Minutes.ToString() + " PM";
                }
                else
                {
                    return this.Hours.ToString() + ":" + this.Minutes.ToString() + " AM";
                }
                
            }


        }

        public void ModifyObject(bool? repeat, int hours, int minutes, bool pm, bool? snooze, string label, Sound alarmSound)
        {
            this.Repeat = repeat ?? false;
            this.Snooze = snooze ?? false;
            this.Hours = hours;
            this.Minutes = minutes;
            this.PM = pm;
            this.HoursAndMinutes = GetHoursAndMinutes();
            this.Label = label;
            this.AlarmSound = alarmSound;
            this.WhenIndicator = SetAlarmWhenIndicator();
        }
    }
}
