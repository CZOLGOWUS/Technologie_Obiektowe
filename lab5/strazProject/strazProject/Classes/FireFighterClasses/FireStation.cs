using System;
using System.Collections;
using System.Collections.Generic;


using strazProject.Interfaces;

namespace strazProject.Classes
{
    public class FireStation : IEnumerable<FireTruck>
    {
        private List<FireTruck> fireTruckList = new List<FireTruck>();


        public string name { get; set; }
        public BasicVector.Vector position { get; set; }

        public int numberOfTrucksInBase { get { return fireTruckList.FindAll(x => !x.isBusy).Count; } } 

        public FireStation(string name, double posX, double posY, int numberOfTrucks)
        {
            this.name = name;
            position = new BasicVector.Vector(posX, posY);
            for (int i = 0; i < numberOfTrucks; i++)
            {
                fireTruckList.Add(new FireTruck());
            }
        }

        public FireStation(string name, BasicVector.Vector position, int numberOfTrucks)
        {
            this.name = name;
            this.position = position;
            for (int i = 0; i < numberOfTrucks; i++)
            {
                fireTruckList.Add(new FireTruck());
            }
        }



        #region enumarator stuff
        public IEnumerator<FireTruck> GetEnumerator()
        {
            return new FireStationEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        public void UpdateFireTrucksStates()
        {
            foreach(FireTruck truck in fireTruckList)
            {
                if(truck.isBusy)
                {
                    truck.timeCount += 1f / 25f;

                    if(truck.timeCount >= truck.assignedTime)
                    {
                        truck.isBusy = false;
                        truck.timeCount = 0;
                        truck.assignedTime = 0;
                        Console.WriteLine("[" + DateTime.Now + "]" + " 1 truck returned to " + name + " fire station");
                    }
                }
            }
        }

        public void SendTrucks(IIncident incident)
        {

            MZIncident mz = incident as MZIncident;
            if(mz != null)
            {
                float time = fireTruckList[0].GetTime(incident.isReal);
                int trucksToSend = 2;
                foreach(FireTruck truck in fireTruckList)
                {
                    if(!truck.isBusy && trucksToSend > 0)
                    {
                        trucksToSend--;
                        truck.Send(time);
                    }
                }

                Console.WriteLine("[" + DateTime.Now + "]" + " 2 trucks have been send from " + name + " station");
                return;
            }

            PZIncident pz = incident as PZIncident;
            if (pz != null)
            {
                float time = fireTruckList[0].GetTime(incident.isReal);
                int trucksToSend = 3;
                foreach (FireTruck truck in fireTruckList)
                {
                    if (!truck.isBusy && trucksToSend > 0)
                    {
                        trucksToSend--;
                        truck.Send(time);
                    }
                }

                Console.WriteLine("3 trucks have been send from " + name + " station");
                return;
            }

            
        }

        public void Add(FireTruck fireTruck)
        {
            fireTruckList.Add(fireTruck);
        }

        public FireTruck GetFireTruck(int idx)
        {
            return fireTruckList[idx];
        }

        public int Count()
        {
            return numberOfTrucksInBase;
        }

    }
}
