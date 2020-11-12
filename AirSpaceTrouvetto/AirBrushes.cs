using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AirSpaceTrouvetto
{
    class AirBrushes
    {
        public SolidColorBrush ClassA;
        public SolidColorBrush ClassBCD;
        public SolidColorBrush ClassE;
        public SolidColorBrush SIV;
        public SolidColorBrush Prohibited;

        public AirBrushes()
        {
            Color AColor = new Color
            {
                A = 255,
                R = (byte)253,
                G = (byte)33,
                B = (byte)43
            };

            Color BCDColor = new Color
            {
                A = 255,
                R = (byte)0,
                G = (byte)75,
                B = (byte)157
            };

            Color EColor = new Color
            {
                A = 255,
                R = (byte)0,
                G = (byte)75,
                B = (byte)157
            };

            Color SIVColor = new Color
            {
                A = 255,
                R = (byte)0,
                G = (byte)122,
                B = (byte)75
            };

            Color PColor = new Color
            {
                A = 255,
                R = (byte)253,
                G = (byte)33,
                B = (byte)43
            };

            ClassA = new SolidColorBrush(AColor);
            ClassBCD = new SolidColorBrush(BCDColor);
            ClassE = new SolidColorBrush(EColor);
            SIV = new SolidColorBrush(SIVColor);
            Prohibited = new SolidColorBrush(PColor);

        }
        
    }
}
