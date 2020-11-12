using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirSpaceTrouvetto
{
    public class PlaneTrajectory
    {
        public List<PlaneTrajectoryPoint> planeTrajectoryPoints;

        readonly float climbPerf, descPerf = 0.001F; //TODO TO GET FROM THE PLANE CLASS

        public PlaneTrajectory()
        {
            this.planeTrajectoryPoints = new List<PlaneTrajectoryPoint>();
            climbPerf = descPerf; //TODO
        }

        public void GenerateTrajectory(float lenght, float cruiseAlt, float startAlt, float arrivalAlt)
        {
            planeTrajectoryPoints.Clear();

            PlaneTrajectoryPoint takeOff, tOC, tOD, landing;

            takeOff = new PlaneTrajectoryPoint(startAlt, 0);
            tOC = new PlaneTrajectoryPoint(cruiseAlt, cruiseAlt * climbPerf);
            tOD = new PlaneTrajectoryPoint(cruiseAlt, lenght - cruiseAlt * descPerf);
            landing = new PlaneTrajectoryPoint(arrivalAlt, lenght);

            planeTrajectoryPoints.Add(takeOff);
            planeTrajectoryPoints.Add(tOC);
            planeTrajectoryPoints.Add(tOD);
            planeTrajectoryPoints.Add(landing);
        }

        public float GetLenght()
        {
            float resLenght = 0;
            foreach(PlaneTrajectoryPoint point in planeTrajectoryPoints)
            {
                resLenght = resLenght < point.Distance ? point.Distance : resLenght;
            }
            return resLenght;
        }

        public float GetMaxAlt()
        {
            float resAlt = 0;
            foreach (PlaneTrajectoryPoint point in planeTrajectoryPoints)
            {
                resAlt = resAlt < point.Altitude ? point.Altitude : resAlt;
            }
            return resAlt;
        }
    }

    public class PlaneTrajectoryPoint
    {
        public float Altitude;
        public float Distance;

        public PlaneTrajectoryPoint(float altitude, float distance)
        {
            this.Altitude = altitude;
            this.Distance = distance;
        }
    }
}
