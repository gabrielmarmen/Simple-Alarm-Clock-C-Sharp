using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAlarmClock
{
    public class IOManagement
    {



        public IOManagement()
        {
            


        }


        public List<Sound> LoadSoundsFromDisk(string SoundsPath, bool SoundRepertoryExists)
        {
            List<Sound> AppSoundList = new List<Sound>(); 

            if (SoundRepertoryExists == false)
            {
                System.IO.Directory.CreateDirectory(SoundsPath);
                return AppSoundList;
            }
            else
            {
                string[] SoundMp3Files = System.IO.Directory.GetFiles(SoundsPath, "*.mp3");
                string[] SoundWavFiles = System.IO.Directory.GetFiles(SoundsPath, "*.wav");

                foreach(string SoundFileNameAndExtension in SoundMp3Files)
                {
                    Sound tempSound = new Sound(SoundsPath + "\\" + SoundFileNameAndExtension,SoundFileNameAndExtension);
                    AppSoundList.Add(tempSound);
                }
                foreach (string SoundFileNameAndExtension in SoundWavFiles)
                {
                    Sound tempSound = new Sound(SoundsPath+"\\"+SoundFileNameAndExtension, SoundFileNameAndExtension);
                    AppSoundList.Add(tempSound);
                }
                return AppSoundList;
            }

        }
        
    }
}
