using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace SimpleAlarmClock
{
    /// <summary>
    /// This is the Alarm Class. Contains a single alarm object's properties and it's methods.
    /// </summary>
    public class Alarm : INotifyPropertyChanged
    {
       

        public bool Repeat { get; set; } //Is the alarm repeating
        public int Hours { get; set; } //Hour of the alarm
        public int Minutes { get; set; } //Minutes of the alarm
        public string HoursAndMinutes { get; set; } //UI uses this property to show the time of the alarm
        public string AMPMString { get; set; } //UI uses this property to show AM or PM
        public bool PM { get; set; } //Defines if the Alarm is in the afternoon
        public bool Snooze { get; set; } //Defines if the alarm is allowed to snooze
        public string Label { get; set; } //Name of the Alarm
        public Sound AlarmSound { get; set; } //Where is the alarm's sound
        public DateTime CreationDateTime { get; set; } //Mainly used as unique identificator
        public DateTime AlarmDateTime { get; set; } //Dynamicaly set Alarm DateTime

        private bool _enabled;
        public bool Enabled  //Indicates if the Alarm is Enabled or not.
        {
            get { return _enabled; }

            set
            {
                _enabled = value;
                OnPropertyRaised("Enabled");
            }
        }
        private string _whenIndicator;
        public string WhenIndicator  //Is indicating to the user when is the alarm (Tommorow, Every weekday, Every Monday etc)
        {
            get { return _whenIndicator; }

            set
            {
                _whenIndicator = value;
                OnPropertyRaised("WhenIndicator");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public Alarm()
        {
            Repeat = false;
            Hours = 8;
            Minutes = 0;
            HoursAndMinutes = GetHoursAndMinutes();
            PM = false;
            AMPMString = GetAMPMString();
            Label = "Alarm";
            AlarmSound = new Sound();
            WhenIndicator = SetAlarmWhenIndicator();
            Enabled = true;
            CreationDateTime = DateTime.Now;
            AlarmDateTime = new DateTime(DateTime.Now.Year,DateTime.Now.Month, DateTime.Now.Day, Hours, Minutes, 0);

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
            AMPMString= GetAMPMString();
            Snooze = newBoolSnooze;
            Label = label;
            AlarmSound = alarmSound;
            WhenIndicator = SetAlarmWhenIndicator();
            Enabled = true;
            CreationDateTime = DateTime.Now;
            AlarmDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Hours, Minutes, 0);
        }

        

        public void RingAlarm()
        {
            this.AlarmSound.Play();
        }

        public void ScheduleAndRunAlarms()
        {
            Thread t = new Thread(RunAlarm); 
            UpdateAlarmFields();
            if (IsNeededToSchedule())
            {
                t.Start();
            }

        }

        public void RunAlarm()
        {
            bool rang = false;
            do
            {
                Thread.Sleep(4000);
                if (DateTime.Now > AlarmDateTime)
                {
                    this.RingAlarm();

                    rang = true;
                }
            } while (rang != true);
            UpdateAlarmAfterRing();

        }

        public void UpdateAlarmFields()
        {
            SetAlarmDateTime();
            this.WhenIndicator = SetAlarmWhenIndicator();
        }
        public void UpdateAlarmAfterRing()
        {
            if(this.Repeat == false)
            {
                this.Enabled= false;
            }
            UpdateAlarmFields();
            ((App)Application.Current).IOManager.SaveAlarmsToDisk();
        }
        public void SetAlarmDateTime()
        {
            if(this.PM == true)
            {
                this.AlarmDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Hours + 12, Minutes, 0);
            }
            else
            {
                this.AlarmDateTime =  new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Hours, Minutes, 0);
            }
        }
        public bool IsNeededToSchedule()
        {
            if (Enabled)
            {
                if(IsPassed())
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            else
            {
                return false;
            }
        }
        public bool IsPassed()
        {
            if (AlarmDateTime < DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public string SetAlarmWhenIndicator()
        {
            if (Repeat)
            {
                return "Every Day";
            }
            else if (DateTime.Now < this.AlarmDateTime)
            {
                return "Today";
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
            //Schedules the alarm with a new thread if needed 
            this.ScheduleAndRunAlarms();
            
        }
        public string GetHoursAndMinutes()
        {
            if(this.Minutes<10)
            {
                return this.Hours.ToString() + ":0" + this.Minutes.ToString();
            }
            else
            {
                return this.Hours.ToString() + ":" + this.Minutes.ToString();     
            }


        }
        public string GetAMPMString()
        {
            if(PM == true)
            {
                return " PM";
            }
            else
            {
                return " AM";
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
            this.AMPMString = GetAMPMString();
            this.Label = label;
            this.AlarmSound = alarmSound;
            this.WhenIndicator = SetAlarmWhenIndicator();
        }
    }
}
