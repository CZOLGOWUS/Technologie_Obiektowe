using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using strazProject.Interfaces;

namespace strazProject.Classes
{
    public class MZIncident : IIncident
    {
        public float maxResolveTime { get; set; }
        public float minResolveTime { get; set; }
        public BasicVector.Vector position { get; set; }
        public bool isReal { get; set; }


        public MZIncident(BasicVector.Vector position, float minResolveTime, float maxResolveTime, bool isReal)
        {
            this.position = position;
            this.maxResolveTime = maxResolveTime;
            this.minResolveTime = minResolveTime;
            this.isReal = isReal;
        }


        public MZIncident()
        {
            this.position = new BasicVector.Vector(-1, -1);
            this.maxResolveTime = -1f;
            this.minResolveTime = -1f;
            this.isReal = false;
        }



    }

}
