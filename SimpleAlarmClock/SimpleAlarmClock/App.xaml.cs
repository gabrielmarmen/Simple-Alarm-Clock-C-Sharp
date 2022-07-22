using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace SimpleAlarmClock
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


        public IOManagement IOManager;
        public string AppDocumentsPath;
        public string AppSoundsPath;
        public string AppAlarmsPath;
        public string AppConfigsPath;
        public bool SoundRepertoryExists;
        public bool ConfigsRepertoryExists;
        public bool AlarmFileExists;
        public bool ConfigsFileExists;
        public List<Sound> AppSoundList;
        public List<Alarm> AppAlarmList;
        public Configs AppConfigs;

        public App()
        {
            IOManager = new IOManagement();
            AppSoundList = new List<Sound>();
            AppAlarmList = new List<Alarm>();
            AppDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SimpleAlarmClock";
            AppSoundsPath = AppDocumentsPath + "\\Sounds";
            AppAlarmsPath = AppDocumentsPath + "\\Alarms.json";
            AppConfigsPath = AppDocumentsPath + "\\Configs.json";
            SoundRepertoryExists = System.IO.Directory.Exists(AppSoundsPath);
            ConfigsRepertoryExists = System.IO.Directory.Exists(AppConfigsPath);
            AlarmFileExists = System.IO.File.Exists(AppAlarmsPath);
            ConfigsFileExists = System.IO.File.Exists(AppConfigsPath);
            InitializeComponent();


            AppSoundList = IOManager.LoadSoundsFromDisk(AppSoundsPath,SoundRepertoryExists);
            AppAlarmList = IOManager.LoadAlarmsFromDisk(AppAlarmsPath, AlarmFileExists);
            AppConfigs = IOManager.LoadConfigsFromDisk(AppConfigsPath, ConfigsFileExists);
            
            ScheduleAlarms();
            

        }
        public void ScheduleAlarms()
        {
            foreach (Alarm alarm in AppAlarmList)
            {
                alarm.ScheduleAndRunAlarms();
            }
        }

    }
}
