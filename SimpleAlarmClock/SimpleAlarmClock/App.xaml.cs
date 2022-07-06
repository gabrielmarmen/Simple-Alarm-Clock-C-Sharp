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
        IOManagement IOManager;
        public string AppConfigsPath;
        public string AppSoundsPath;
        public bool SoundRepertoryExists;
        public bool ConfigsRepertoryExists;
        public List<Sound> AppSoundList;

        public App()
        {
            IOManager = new IOManagement();
            AppSoundList = new List<Sound>();
            AppConfigsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SimpleAlarmClock";
            AppSoundsPath = AppConfigsPath + "\\Sounds";
            SoundRepertoryExists = System.IO.Directory.Exists(AppSoundsPath);
            ConfigsRepertoryExists = System.IO.Directory.Exists(AppConfigsPath);
            InitializeComponent();



            AppSoundList = IOManager.LoadSoundsFromDisk(AppSoundsPath,SoundRepertoryExists);
            
            
        }
    }
}
