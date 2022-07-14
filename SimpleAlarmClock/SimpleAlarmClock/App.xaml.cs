using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleAlarmClock
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IOManagement IOManager;
        public string AppConfigsPath;
        public string AppSoundsPath;
        public string AppAlarmsPath;
        public bool SoundRepertoryExists;
        public bool ConfigsRepertoryExists;
        public bool AlarmFileExists;
        public List<Sound> AppSoundList;
        public List<Alarm> AppAlarmList;

        public App()
        {
            IOManager = new IOManagement();
            AppSoundList = new List<Sound>();
            AppAlarmList = new List<Alarm>();
            AppConfigsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SimpleAlarmClock";
            AppSoundsPath = AppConfigsPath + "\\Sounds";
            AppAlarmsPath = AppConfigsPath + "\\Alarms.json";
            SoundRepertoryExists = System.IO.Directory.Exists(AppSoundsPath);
            ConfigsRepertoryExists = System.IO.Directory.Exists(AppConfigsPath);
            AlarmFileExists = System.IO.File.Exists(AppAlarmsPath);
            InitializeComponent();


            AppSoundList = IOManager.LoadSoundsFromDisk(AppSoundsPath,SoundRepertoryExists);
            AppAlarmList = IOManager.LoadAlarmsFromDisk(AppAlarmsPath, AlarmFileExists);
            
            
        }
    }
}
