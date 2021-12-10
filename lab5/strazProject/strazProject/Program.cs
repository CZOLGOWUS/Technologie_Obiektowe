using System;
using System.Collections.Generic;
using System.Windows;

using strazProject.Classes;
using strazProject.Interfaces;

internal class Program
{
    static void Main(string[] args)
    {
        //initialize map
        Map.topLeft = new BasicVector.Vector(19.688292482742394, 50.154564013341734);
        Map.topRight = new BasicVector.Vector(20.02470275868903, 50.154564013341734);
        Map.bottomLeft = new BasicVector.Vector(19.688292482742394, 49.95855025648944);
        Map.bottomRight = new BasicVector.Vector(20.02470275868903, 49.95855025648944);

        #region setup

        FireStationCenter fireStationCenter = new FireStationCenter(
            new List<FireStation>() {
                new FireStation("JRG 1", new BasicVector.Vector( 19.941007344353647, 50.06723246707029), 5),
                new FireStation("JRG 2", new BasicVector.Vector(19.936887471270342 , 50.040780194910774), 5),
                new FireStation("JRG 3", new BasicVector.Vector(19.88538905772902, 50.08089376130773), 5),
                new FireStation("JRG 4", new BasicVector.Vector(20.008813688854186, 50.0463859509817), 5),
                new FireStation("JRG 5", new BasicVector.Vector(19.922982999618668,50.09706740915194), 5),
                new FireStation("JRG 6", new BasicVector.Vector(20.01636678950691,50.022128056338424), 5),
                new FireStation("JRG 7", new BasicVector.Vector(9.9779146407294,50.10059108325477), 5),
                new FireStation("Aspiranci", new BasicVector.Vector(20.035592863895666,50.08517309563034), 5),
                new FireStation("Lotnisko", new BasicVector.Vector(19.78634054235572,50.08076704512346), 5),
                new FireStation("Skawina", new BasicVector.Vector(19.80282003468894,49.97710824718122), 5) 
            }
            );


        
        IncidentManager incidentManager = new IncidentManager( new RandomIncidentCreator());

        incidentManager.AddIncidentToList(new MZIncident());
        incidentManager.AddIncidentToList(new PZIncident());

        incidentManager.AddObserver(fireStationCenter);
        #endregion

        float simulationTime = 200f;
        float timeCount = 0f;
        Random random = new Random();
        DateTime start = DateTime.UtcNow;


                incidentManager.CreateNewIncident();
        while (timeCount < simulationTime)
        {
            //invoke incident
            if (random.NextDouble() > 0.99)
                incidentManager.CreateNewIncident();

            fireStationCenter.UpdateFireStationsState();

            //sleep for 1/25s
            System.Threading.Thread.Sleep(40);
            DateTime end = DateTime.UtcNow;
            timeCount = (end - start).Seconds;
        }

    }
}
