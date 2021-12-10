using System;
using System.Collections.Generic;

namespace BorderProject
{
    public class Program
    {


        static void Main(string[] args)
        {
            double lat;
            double lon;


            NamesFactory namesFactory = new NamesFactory();

            PeopleDataBase peopleDataBase = new PeopleDataBase(namesFactory);
            PeopleDataBaseProxy peopleDataBaseProxy = new PeopleDataBaseProxy(peopleDataBase);


            Console.WriteLine("write see-all to see all the people in data base");

            #region main loop
            while (true)
            {
                Console.WriteLine("Enter new name first, second,..., last name all after Enter (at the end enter empty input)");


                bool skip = false;
                bool isFirstNameLoop = true;
                List<string> fullNameList = new List<string>();

                while (true)
                {
                    string name = Console.ReadLine().Trim();

                    if (name == "")
                    {
                        if(!isFirstNameLoop)
                        {
                            break;
                        }
                        else
                        {

                        }
                    }


                    if (name == "see-all")
                    {
                        skip = true;
                        peopleDataBase.ShowAllPeople();
                    }

                    string[] inputedNames = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    foreach (string n in inputedNames)
                        fullNameList.Add(n);

                    isFirstNameLoop = false;
                }

                if (skip)
                    continue;

                string tempLong;
                while (true)
                {
                    Console.WriteLine("floating points with \',\' \nEnter Longtidue");
                    tempLong = Console.ReadLine().Trim();

                    if(double.TryParse(tempLong, out lon))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("bad input");
                    }
                }


                string tempLat;
                while (true)
                {
                    Console.WriteLine("Enter Latitude");
                    tempLat = Console.ReadLine().Trim();

                    if (double.TryParse(tempLat, out lat))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("bad input");
                    }
                }

                peopleDataBaseProxy.AddPerson(fullNameList.ToArray(), lat, lon);

            }
            #endregion
        }
    }
}
