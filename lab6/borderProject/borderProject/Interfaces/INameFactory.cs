using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderProject.Interfaces
{
    public interface INameFactory
    {
        public Name GetName(string name);
        public void ShowAllNames();
    }
}
