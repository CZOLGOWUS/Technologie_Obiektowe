using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderProject
{
    public class NamesFactory : BorderProject.Interfaces.INameFactory
    {
        private List<Name> _names = new List<Name>();


        public Name GetName(string name)
        {
            Name foundName = _names.Find(n => n.str == name);

            if (foundName == null)
            {
                foundName = new Name(name, this);
                _names.Add(foundName);
            }

            return foundName;
        }

        public void ShowAllNames()
        {
            foreach (Name name in _names)
            {
                Console.WriteLine(name.str);
            }
        }

    }
}
