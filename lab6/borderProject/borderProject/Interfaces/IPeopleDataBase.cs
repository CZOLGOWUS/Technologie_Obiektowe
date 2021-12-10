using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderProject.Interfaces
{
    public interface IPeopleDataBase
    {
        public void AddPerson(string[] name, double latitude, double longitude);
        public IPerson GetPerson(string[] name, double latitude, double longitude);
        public void ShowAllPeople();
    }
}
