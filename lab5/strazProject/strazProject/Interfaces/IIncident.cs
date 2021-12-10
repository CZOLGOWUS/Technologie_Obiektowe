using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strazProject.Interfaces
{
    public interface IIncident
    {
        public BasicVector.Vector position { get; set; }
        public bool isReal { get; set; }


    }
}
