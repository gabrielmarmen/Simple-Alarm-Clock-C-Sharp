using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAlarmClock
{
    public class Sound
    {
        public string Name;
        public string SoundPath;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Sound()
        {
            Name = "";
            SoundPath = "";
        }
        public Sound(string soundPath)
        {
            SoundPath = soundPath;
            Name = GenerateName();
        }

        /// <summary>
        /// Overloaded Constructor with the Name and the Sound Path of a Sound.
        /// </summary>
        /// <param name="name">Display name of the sound</param>
        /// <param name="soundPath">Path where the sound is located</param>
        public Sound(string name, string soundPath)
        {
            Name = name;
            SoundPath = soundPath;
        }

        public string GenerateName()
        {

            ///////////////////////////PUT CODE HERE THAT GENERATES A NAME FROM A FILE NAME (GET TEXT JUST BEFORE LAST DOT)
            string generatedName = "";
            return  generatedName
        }



    }
}
