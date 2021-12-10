using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BorderProject.Interfaces;

namespace BorderProject
{
    public class PeopleDataBase : IPeopleDataBase
    {

        private List<IPerson> personList = new List<IPerson>();
        private INameFactory namesFactory;





        public PeopleDataBase(INameFactory namesFactory)
        {
            this.namesFactory = namesFactory;
        }


        public void AddPerson(string[] names, double latitude, double longitude)
        {
            List<Name> listOfNames = new List<Name>();
            foreach (string name in names)
            {
                listOfNames.Add(namesFactory.GetName(name));
            }

            IPerson person = new Person(listOfNames, latitude, longitude, namesFactory);
            personList.Add(person);
        }


        public IPerson? GetPerson(string[] names, double latitude, double longitude)
        {
            List<Name> tempList = new List<Name>();

            foreach (string n in names)
            {
                tempList.Add(new Name(n, namesFactory));
            }


            return personList.Find(person =>
            {
                return tempList.SequenceEqual(person.names) && person.latitud == latitude && person.longitud == longitude;
            });

        }

        public void ShowAllPeople()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (IPerson person in personList)
            {
                for (int i = 0; i < person.names.Count; i++)
                {
                    stringBuilder.Append(person.names[i].str + " ");
                }

                Console.WriteLine("name: " + stringBuilder.ToString().Trim() + " Latitude: " + person.latitud + " Longtutude: " + person.longitud);

                stringBuilder.Clear();
            }
        }

    }
}
