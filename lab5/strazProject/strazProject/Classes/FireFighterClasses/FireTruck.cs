using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using strazProject.Interfaces;

namespace strazProject.Classes
{
    public class FireTruck
    {
        public bool isBusy { get; set; }
        public float timeCount { get; set; }
        public float assignedTime { get; set; }

        public void Send(float assigneTime)
        {
            isBusy = true;
            assignedTime = assigneTime;
        }

        public void Reset()
        {
            isBusy = false;
            assignedTime = 0;
        }

        public float GetTime(bool isReal)
        {
            Random random = new Random();
            if(isReal)
                return (float)(random.NextDouble() * 3 * 2 + 5 +random.NextDouble() * 20 );
            else
                return (float)(random.NextDouble() * 3 * 2 + random.NextDouble() * 3 );
        }
    }
}
