using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleAlarmClock
{
    public class Sound
    {
        public string Name; //Name of the Sound
        public string SoundPath; //Path of the Sound File
        public string Type; //What type of audio file is it
        System.Media.SoundPlayer WavPlayer = new System.Media.SoundPlayer(); // SoundPlayer for playing the wav sounds

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Sound()
        {
            Name = "";
            SoundPath = "";
            Type = "";
        }

        /// <summary>
        /// Overloaded Constructor with the Sound Path of a Sound. Name will be generated automatically
        /// </summary>
        /// <param name="soundPath"></param>
        public Sound(string soundPath, string FileNameAndExtension)
        {
            SoundPath = soundPath;
            Name = System.IO.Path.GetFileNameWithoutExtension(FileNameAndExtension);
            Type = System.IO.Path.GetExtension(FileNameAndExtension);
        }

        public void Play()
        {
            if(Type == ".mp3")
            {
                MessageBox.Show("The file format " + Type + " is not yet supported by this software.", "Unsupported Format", MessageBoxButton.OK, MessageBoxImage.Error); 
            }
            else if(Type == ".wav")
            {
                WavPlayer.SoundLocation = this.SoundPath;
                WavPlayer.Play();
            }
            else
            {
                MessageBox.Show("The file format " + Type + "is not yet supported by this software.", "Unsupported Format", MessageBoxButton.OK, MessageBoxImage.Error); ;
            }
        }



    }
}
