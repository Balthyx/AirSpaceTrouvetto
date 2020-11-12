using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirSpaceTrouvetto
{
    public class Sector
    {
        public float altMax, altMin, distMax, distMin, freq;
        public string airClass, name;

        public Sector(string name, string airClass, float freq, float altMin, float altMax, float distMin, float distMax)
        {
            this.name = name;
            this.airClass = airClass;
            this.altMax = altMax;
            this.altMin = altMin;
            this.distMax = distMax;
            this.distMin = distMin;
            this.freq = freq;
        }
    }
}
