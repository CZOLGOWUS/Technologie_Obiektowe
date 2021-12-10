using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using strazProject.Classes;

namespace strazProject.Interfaces
{
    public interface IFireTruckeState
    {
        public bool IsReady(FireTruck fireTruck);
        public void Update(FireTruck fireTruck);
    }
}
