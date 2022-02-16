using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Proc
    {
        public int procTime { get; set; }
        public int idleTime { get; set; }
        public int ready { get; set; }
        public int timeLeft { get; set; }
        public int prior { get; set; }

        public void InProcess() {
            procTime++;
            timeLeft--;
        }

        public void Idle()
        {
            procTime++;
            idleTime++;
            ready--;
        }
    }
}
