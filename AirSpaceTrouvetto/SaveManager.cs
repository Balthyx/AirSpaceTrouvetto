using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace AirSpaceTrouvetto
{
    class SaveManager
    {
        public char DSepC = System.IO.Path.DirectorySeparatorChar;

        public SaveManager()
        {
            SetSeparatorToPoint();
        }

        public FlightPlan LoadFlp(string path)//TODO: Delete lenght, maxALt
        {
            XmlDocument doc = new XmlDocument();
            try { 
                doc.Load(path);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Damaged xml file : {e.Message}");
            }



            string name, sectorClass;
            float freq, altMin, altMax, distMin, distMax;

            List<Sector> sectors = new List<Sector>();


            XmlNode SectorsNode = doc.SelectSingleNode("/ FlightPlan / Sectors");

            foreach(XmlNode node in SectorsNode.ChildNodes)
            {
                try
                {
                    name = node.SelectSingleNode("name").InnerText;
                    sectorClass = node.SelectSingleNode("class").InnerText;

                    freq = float.Parse(node.SelectSingleNode("freq").InnerText);
                    altMin = float.Parse(node.SelectSingleNode("altMin").InnerText);
                    altMax = float.Parse(node.SelectSingleNode("altMax").InnerText);
                    distMin = float.Parse(node.SelectSingleNode("distMin").InnerText);
                    distMax = float.Parse(node.SelectSingleNode("distMax").InnerText);

                    Sector sector = new Sector(name, sectorClass, freq, altMin, altMax, distMin, distMax);
                    sectors.Add(sector);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show($"Un secteur est illisible : {node.InnerText}");
                }
                
            }

            
            XmlNode TrajectoryNode = doc.SelectSingleNode("/ FlightPlan / PlaneTrajectory");

            PlaneTrajectory planeTrajectory = new PlaneTrajectory();

            float trajDist;
            float trajAlt;

            foreach (XmlNode node in TrajectoryNode)
            {
                try
                {
                    trajDist = float.Parse(node.SelectSingleNode("distance").InnerText);
                    trajAlt = float.Parse(node.SelectSingleNode("altitude").InnerText);

                    planeTrajectory.planeTrajectoryPoints.Add(new PlaneTrajectoryPoint(trajAlt, trajDist));
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show($"Plane trajectory unreadable : {node.InnerText}");
                }
            }

            return new FlightPlan(sectors, planeTrajectory);
        }

        public void SaveFlp(string path, FlightPlan flp)
        {
            XmlDocument doc = new XmlDocument();

            //(1) the xml declaration is recommended, but not mandatory
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //Racine
            XmlElement xFlightPlan = doc.CreateElement(string.Empty, "FlightPlan", string.Empty);
            doc.AppendChild(xFlightPlan);

            //PlaneTrajectory
            XmlElement xTrajectory = doc.CreateElement(string.Empty, "PlaneTrajectory", string.Empty);
            xFlightPlan.AppendChild(xTrajectory);
            //Sectors
            XmlElement xSectors = doc.CreateElement(string.Empty, "Sectors", string.Empty);
            xFlightPlan.AppendChild(xSectors);

            foreach (PlaneTrajectoryPoint point in flp.PlaneTrajectory.planeTrajectoryPoints)
            {
                XmlElement xPoint = doc.CreateElement(string.Empty, "point", string.Empty);
                xTrajectory.AppendChild(xPoint);

                XmlElement xDist = doc.CreateElement(string.Empty, "distance", string.Empty);
                XmlElement xAlt = doc.CreateElement(string.Empty, "altitude", string.Empty);

                xDist.InnerText = point.Distance.ToString();
                xAlt.InnerText = point.Altitude.ToString();

                xPoint.AppendChild(xDist);
                xPoint.AppendChild(xAlt);
            }
            

            foreach(Sector sector in flp.sectorList)
            {
                XmlElement xSector = doc.CreateElement(string.Empty, "Sector", string.Empty);
                xSectors.AppendChild(xSector);

                XmlElement xName = doc.CreateElement(string.Empty, "name", string.Empty);
                XmlElement xClass = doc.CreateElement(string.Empty, "class", string.Empty);
                XmlElement xfreq = doc.CreateElement(string.Empty, "freq", string.Empty);
                XmlElement xAltMin = doc.CreateElement(string.Empty, "altMin", string.Empty);
                XmlElement xAltMax = doc.CreateElement(string.Empty, "altMax", string.Empty);
                XmlElement xDistMin = doc.CreateElement(string.Empty, "distMin", string.Empty);
                XmlElement xDistMax = doc.CreateElement(string.Empty, "distMax", string.Empty);

                xName.InnerText = sector.name;
                xClass.InnerText = sector.airClass;
                xfreq.InnerText = sector.freq.ToString();
                xAltMin.InnerText = sector.altMin.ToString();
                xAltMax.InnerText = sector.altMax.ToString();
                xDistMin.InnerText = sector.distMin.ToString();
                xDistMax.InnerText = sector.distMax.ToString();

                xSector.AppendChild(xName);
                xSector.AppendChild(xClass);
                xSector.AppendChild(xfreq);
                xSector.AppendChild(xAltMin);
                xSector.AppendChild(xAltMax);
                xSector.AppendChild(xDistMin);
                xSector.AppendChild(xDistMax);
            }

            doc.Save(path);
        }

        private void SetSeparatorToPoint()
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }

       
    }
}
