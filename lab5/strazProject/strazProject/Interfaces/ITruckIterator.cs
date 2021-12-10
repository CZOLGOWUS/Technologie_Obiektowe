using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strazProject.Interfaces
{
    public interface ITruckIterator
    {
        public bool HasNext();
        public object Next();
    }
}
