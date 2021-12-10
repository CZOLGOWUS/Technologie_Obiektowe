using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using strazProject.Interfaces;

namespace strazProject.Classes
{
    public class RandomIncidentCreator : IIncidentCreationBehaviour
    {
        public IIncident CreateIncident()
        {
            Random rand = new Random();

            if(rand.NextDouble() <= 0.3)
            {

                if(rand.NextDouble() < 0.05)
                {
                    return new PZIncident(Map.RandomPoint(),0,3,false);
                }


                return new PZIncident(Map.RandomPoint(),5,25,true);
            }
            else
            {
                if (rand.NextDouble() < 0.05)
                {
                    return new MZIncident(Map.RandomPoint(),0,3,false);
                }

                return new MZIncident(Map.RandomPoint(),5,25,true);
            }
        }
    }
}
