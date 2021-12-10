using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderProject.Interfaces
{
    public interface IPerson
    {
        public double latitud { get; set; }
        public double longitud { get; set; }
        public List<Name> names { get; set; }
    }
}
