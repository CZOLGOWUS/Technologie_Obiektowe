using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using strazProject.Interfaces;

namespace strazProject.Classes
{
    public class IncidentManager : IMyObservable
    {
        private List<IMyObserver> observers = new List<IMyObserver>();

        private List<IIncident> incidentIncluded = new List<IIncident>(); 
        private List<IIncident> incidentCreated = new List<IIncident>(); 

        private IIncidentCreationBehaviour incidentCreationBehaviour;



        public IncidentManager(IIncidentCreationBehaviour incidentCreationBehaviour)
        {
            this.incidentCreationBehaviour = incidentCreationBehaviour;
        }



        public void CreateNewIncident()
        {
            incidentCreated.Add(incidentCreationBehaviour.CreateIncident());
            Console.WriteLine("[" + DateTime.Now + "]" + " Incident Created at " + incidentCreated.Last().position );
            NotifyAll(incidentCreated[incidentCreated.Count - 1]);
        }



        public void AddIncidentToList(IIncident incident)
        {
            incidentIncluded.Add(incident);
        }

        public void RemoveIncidentFromList(IIncident incident)
        {
            incidentIncluded.Remove(incident);
        }



        public void AddObserver(IMyObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IMyObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObserver(IMyObserver observer, IIncident incidnet)
        {
            observers.Find( x => x.Equals(observer) ).Update(incidnet);
        }

        public void NotifyAll(IIncident incidnet)
        {
            foreach (IMyObserver o in observers)
                o.Update(incidnet);
        }
    }
}
