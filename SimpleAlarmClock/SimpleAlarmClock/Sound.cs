using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAlarmClock
{
    public class Sound
    {
        public string Name; //Name of the Sound
        public string SoundPath; //Path of the Sound File
        public string type; //What type of audio file is it

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Sound()
        {
            Name = "";
            SoundPath = "";
            type = "";
        }

        /// <summary>
        /// Overloaded Constructor with the Sound Path of a Sound. Name will be generated automatically
        /// </summary>
        /// <param name="soundPath"></param>
        public Sound(string soundPath, string FileNameAndExtension)
        {
            SoundPath = soundPath;
            Name = System.IO.Path.GetFileNameWithoutExtension(FileNameAndExtension);
            type = System.IO.Path.GetExtension(FileNameAndExtension);
        }



    }
}
