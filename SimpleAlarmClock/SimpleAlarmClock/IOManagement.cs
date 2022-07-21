using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
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
                GetDefaultSounds(soundsPath);
            }

                string[] SoundMp3Files = System.IO.Directory.GetFiles(soundsPath, "*.mp3");
                string[] SoundWavFiles = System.IO.Directory.GetFiles(soundsPath, "*.wav");

                foreach (string SoundFileNameAndExtension in SoundMp3Files)
                {
                    string completePath = Path.Combine(soundsPath, SoundFileNameAndExtension);
                    Sound tempSound = new Sound(completePath, SoundFileNameAndExtension);
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
        public void RefreshSoundsFromDisk()
        {
            ((App)Application.Current).AppSoundList = ((App)Application.Current).IOManager.LoadSoundsFromDisk(((App)Application.Current).AppSoundsPath, ((App)Application.Current).SoundRepertoryExists);
        }
        public void AddNewSound()
        {
            OpenFileDialog OpenFileDialogInstance = new OpenFileDialog();

            OpenFileDialogInstance.InitialDirectory = "c:\\";
            OpenFileDialogInstance.Filter = "Audio Files (*.mp3, *.wav)|*.mp3;*.wav";
            OpenFileDialogInstance.FilterIndex = 0;
            OpenFileDialogInstance.RestoreDirectory = true;
            OpenFileDialogInstance.ShowDialog();


            string SelectedFilePath = OpenFileDialogInstance.FileName;
            string SelectedFileName = OpenFileDialogInstance.SafeFileName;

            if (OpenFileDialogInstance.FileName != "")
            {


                if(File.Exists(((App)Application.Current).AppSoundsPath + "\\"  + SelectedFileName))
                {
                     MessageBox.Show("The sound you selected already exists. Please choose another one or rename the sound you selected.",
                     "Sound already exists",
                     MessageBoxButton.OK,
                     MessageBoxImage.Information,
                     MessageBoxResult.None,
                     MessageBoxOptions.DefaultDesktopOnly);
                }
                else
                {
                    File.Copy(SelectedFilePath, ((App)Application.Current).AppSoundsPath + "\\" + SelectedFileName);
                }
            }
            //Reloads the Sound List from the files on disk. (The new file will be added to the global AppSoundsList)
            this.RefreshSoundsFromDisk();
        }
        public List<Alarm> LoadAlarmsFromDisk(string alarmsPath, bool alarmFileExists)
        {
            List<Alarm> AppAlarmList = new List<Alarm>();

            if (alarmFileExists == false)
            {
                var json = JsonConvert.SerializeObject(((App)Application.Current).AppAlarmList);
                File.WriteAllText(((App)Application.Current).AppAlarmsPath, json);
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
        public void GetDefaultSounds(string soundsPath)
        {
            File.Copy(Path.Combine("C:\\Windows\\Media", "Alarm01.wav"), Path.Combine(soundsPath, "Chimes.wav"), true);
            File.Copy(Path.Combine("C:\\Windows\\Media", "Alarm02.wav"), Path.Combine(soundsPath, "Xylophone.wav"), true);
            File.Copy(Path.Combine("C:\\Windows\\Media", "Alarm03.wav"), Path.Combine(soundsPath, "Chords.wav"), true);
            File.Copy(Path.Combine("C:\\Windows\\Media", "Alarm04.wav"), Path.Combine(soundsPath, "Tap.wav"), true);
            File.Copy(Path.Combine("C:\\Windows\\Media", "Alarm05.wav"), Path.Combine(soundsPath, "Jingle.wav"), true);
        }


    }
}
