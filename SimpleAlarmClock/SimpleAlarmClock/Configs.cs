using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAlarmClock
{
    public class Configs
    {
        public bool StopShowingExitNotification { get; set; }

        public Configs()
        {
            StopShowingExitNotification = false;
        }
    }
}
