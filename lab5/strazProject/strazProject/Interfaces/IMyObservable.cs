using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strazProject.Interfaces
{
    public interface IMyObservable
    {
        public void AddObserver(IMyObserver observer);
        public void RemoveObserver(IMyObserver observer);
        public void NotifyObserver(IMyObserver observer, IIncident incident);
        public void NotifyAll(IIncident incident);
    }
}
