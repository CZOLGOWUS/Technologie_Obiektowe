using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BorderProject.Interfaces;

namespace BorderProject
{
    public class Name 
    {
        private INameFactory _namesFactory;

        public string str { get; set; }

        public Name(  string name, INameFactory namesFactory)
        {
            str = name;
            _namesFactory = namesFactory;
        }

    }
}
