using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BorderProject.Interfaces;

namespace BorderProject
{
    public class Person : BorderProject.Interfaces.IPerson
    {
        private INameFactory factory;

        public double latitud { get; set; }
        public double longitud { get; set;}
        public List<Name> names { get; set; }

        public Person(List<Name> names, double latitud, double longitud, INameFactory factory )
        {
            this.names = names;
            this.latitud = latitud;
            this.longitud = longitud;
            this.factory = factory;
        }

    }
}
