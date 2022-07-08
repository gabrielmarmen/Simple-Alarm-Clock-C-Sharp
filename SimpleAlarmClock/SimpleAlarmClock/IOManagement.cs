using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace SimpleAlarmClock
{
    public class IOManagement
    {

        

        public IOManagement()
        {
            


        }


        public List<Sound> LoadSoundsFromDisk(string soundsPath, bool soundRepertoryExists)
        {
            List<Sound> AppSoundList = new List<Sound>(); 

            if (soundRepertoryExists == false)
            {
                System.IO.Directory.CreateDirectory(soundsPath);
                return AppSoundList;
            }
            else
            {
                string[] SoundMp3Files = System.IO.Directory.GetFiles(soundsPath, "*.mp3");
                string[] SoundWavFiles = System.IO.Directory.GetFiles(soundsPath, "*.wav");

                foreach(string SoundFileNameAndExtension in SoundMp3Files)
                {
                    string completePath = Path.Combine(soundsPath, SoundFileNameAndExtension);
                    Sound tempSound = new Sound(completePath,SoundFileNameAndExtension);
                    AppSoundList.Add(tempSound);
                }
                foreach (string SoundFileNameAndExtension in SoundWavFiles)
                {
                    string completePath = Path.Combine(soundsPath, SoundFileNameAndExtension);
                    Sound tempSound = new Sound(completePath, SoundFileNameAndExtension);
                    AppSoundList.Add(tempSound);
                }
                return AppSoundList;
            }

        }

        public List<Alarm> LoadAlarmsFromDisk(string alarmsPath, bool alarmFileExists)
        {
            List<Alarm> AppAlarmList = new List<Alarm>();

            if (alarmFileExists == false)
            {
                this.SaveAlarmsToDisk();
                return AppAlarmList;
            }
            else
            {
                string json = File.ReadAllText(alarmsPath);
                AppAlarmList = JsonConvert.DeserializeObject<List<Alarm>>(json);

                return AppAlarmList;
            }

        }


        public void SaveAlarmsToDisk()
        {
            var json = JsonConvert.SerializeObject(((App)Application.Current).AppAlarmList);
            File.WriteAllText(((App)Application.Current).AppAlarmsPath, json);
        }

    }
}
