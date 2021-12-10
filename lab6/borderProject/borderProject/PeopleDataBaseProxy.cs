using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using BorderProject.Interfaces;

namespace BorderProject
{
    public class PeopleDataBaseProxy : IPeopleDataBase
    {
        private IPeopleDataBase realPeopleDataBase;

        public PeopleDataBaseProxy(IPeopleDataBase realDataBase)
        {
            realPeopleDataBase = realDataBase;
        }


        public void AddPerson(string[] names, double latitude, double longitude)
        {
            FormatInputNames(names);

            realPeopleDataBase.AddPerson(names, latitude, longitude);
        }

        public IPerson GetPerson(string[] names, double latitude, double longitude)
        {
            return realPeopleDataBase.GetPerson(names, latitude, longitude);
        }


        private static void FormatInputNames(string[] names)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < names.Length; i++)
            {
                sb.Append(names[i].ToLower() + " ");
                sb[0] = Char.ToUpper(sb[0]);

                names[i] = sb.ToString().Trim();

                sb.Clear();
            }
        }

        public void ShowAllPeople()
        {
            realPeopleDataBase.ShowAllPeople();
        }
    }
}
