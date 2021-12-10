using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using strazProject.Interfaces;

namespace strazProject.Classes
{
    public class FireStationCenter : IMyObserver
    {

        List<FireStation> fireStations = new List<FireStation> ();


        public FireStationCenter(List<FireStation> fireStations)
        {
           this.fireStations = fireStations;
        }

        public void UpdateFireStationsState()
        {
            foreach (FireStation station in fireStations)
            {
                station.UpdateFireTrucksStates();
            }
        }

        public void Update(IIncident incidnet)
        {
            FireStation nearestFireStation = fireStations[0];


            foreach(FireStation station in fireStations)
            {
                if((incidnet.position - station.position).Length < (incidnet.position - nearestFireStation.position).Length || nearestFireStation.Count() < 2)
                {
                    MZIncident mz = incidnet as MZIncident;
                    if( mz != null && station.Count() >= 2)
                    {
                        nearestFireStation = station;
                    }

                    PZIncident pz = incidnet as PZIncident;
                    if(pz != null && station.Count() >= 3)
                    {
                        nearestFireStation = station;
                    }

                }
            }


            MZIncident m = incidnet as MZIncident;
            if (m != null && nearestFireStation.numberOfTrucksInBase < 2)
            {
                Console.WriteLine("No trucks avilable");
                return;
            }

            PZIncident p = incidnet as PZIncident;
            if (p != null && nearestFireStation.numberOfTrucksInBase < 3)
            {
                Console.WriteLine("No trucks avilable");
                return;
            }


            nearestFireStation.SendTrucks(incidnet);

        }
    }
}
