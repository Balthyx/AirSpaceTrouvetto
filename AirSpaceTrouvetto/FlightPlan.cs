using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirSpaceTrouvetto
{
    class FlightPlan
    {
        public List<Sector> sectorList;
        public PlaneTrajectory PlaneTrajectory;

        public FlightPlan(List<Sector> sectorList, PlaneTrajectory planeTrajectory)
        {
            this.sectorList = sectorList;
            this.PlaneTrajectory = planeTrajectory;
        }

        public float GetLenght()
        {
            float resLenght = 0;
            foreach (Sector sector in sectorList)
            {
                resLenght = resLenght < sector.distMax ? sector.distMax : resLenght;
            }
            return resLenght;

        }

        public float GetMaxAlt()
        {
            float maxAlt = 0;
            foreach(Sector sector in sectorList)
            {
                maxAlt = maxAlt < sector.altMax ? sector.altMax : maxAlt;
            }
            return maxAlt;
        }
        
    }
}
