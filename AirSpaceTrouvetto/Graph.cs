using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows;

namespace AirSpaceTrouvetto
{
    class Graph
    {
        readonly FlightPlan flp;
        public float margin;
        public float leftMargin;
        public float bottMargin;
        public Canvas canvas;
        readonly AirBrushes airBrushes;

        public float maxLenght, maxAlt;

        public double pxX;// px density
        public double pxY;

        public Graph(Canvas canvas, FlightPlan flp, float margin = 10)
        {
            this.canvas = canvas;
            this.flp = flp;
            this.margin = margin;
            this.leftMargin = 40;
            this.bottMargin = 20;

            airBrushes = new AirBrushes();

            UpdateLenghtAlt();
        }

        //UPDATES
        void UpdatePxPy()
        {
            if (this.canvas.ActualWidth != 0)//Si le canvas est affiché
            {
                pxX = (canvas.ActualWidth - (margin + leftMargin)) / maxLenght;// px density
                pxY = (canvas.ActualHeight - (margin + bottMargin)) / maxAlt;
            }
            else
            {
                pxX = (canvas.Width - (margin + leftMargin)) / maxLenght;// px density
                pxY = (canvas.Height - (margin + bottMargin)) / maxAlt;
            }
        }

        public void UpdateLenghtAlt()
        {
            maxLenght = Math.Max(flp.GetLenght(), flp.PlaneTrajectory.GetLenght());
            maxAlt = Math.Max(flp.GetMaxAlt(), flp.PlaneTrajectory.GetMaxAlt());

            maxLenght = Math.Max(maxLenght, 5);
            maxAlt = Math.Max(maxAlt, 2000);
        }

        //PAINT
        public void PaintAll()
        {
            PaintScales();
            PaintAllSectors();
            PaintPlaneTrajectory();
        }

        public void PaintScales()
        {
            UpdatePxPy();

            ClearAllLines();

            double verticalStep = 500;// in ft

            verticalStep = maxAlt > 3000 ? 1000 : verticalStep;
            verticalStep = maxAlt > 15000 ? 2000 : verticalStep;
            verticalStep = maxAlt > 30000 ? 5000 : verticalStep;

            canvas.Children.Add(LineGenerator(leftMargin, leftMargin, margin, canvas.ActualHeight - bottMargin));//vertical scale

            //vertical graduation
            double pxStep = (canvas.ActualHeight - (margin + bottMargin)) / maxAlt;
            double h;
            for (double i = 0; i <= maxAlt; i += verticalStep)
            {
                h = (i * pxStep) + margin;
                canvas.Children.Add(LineGenerator(leftMargin, canvas.ActualWidth - margin, h, h, System.Windows.Media.Brushes.Gray));

                //LABELS
                Label label = new Label
                {
                    Content = maxAlt - i
                };
                Canvas.SetLeft(label, 0); Canvas.SetTop(label, h - 12);
                canvas.Children.Add(label);
                //TODO : Add labels
            }

            Label hLabel = new Label
            {
                Content = maxLenght
            };
            //Canvas.SetLeft(hLabel, canvas.ActualWidth - margin - 12);
            Canvas.SetRight(hLabel, 0);
            Canvas.SetTop(hLabel, canvas.ActualHeight - margin - 12);
            canvas.Children.Add(hLabel);
        }

        void ClearAllLines()
        {
            canvas.Children.Clear();
        }

        public void PaintAllSectors()
        {
            foreach(Sector sector in flp.sectorList)
            {
                PaintSector(sector);
            }
        }

        void PaintSector(Sector sector)
        {
            double x = sector.distMin * pxX + leftMargin;
            double y = canvas.ActualHeight - (sector.altMax * pxY) - margin*2;
            double width = (sector.distMax - sector.distMin) * pxX;
            double height = (sector.altMax - sector.altMin) * pxY;

            Rectangle rect = new Rectangle();
            canvas.Children.Add(rect);

            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);
            rect.Width = width;
            rect.Height = height;

            //Choice of brush
            rect.StrokeThickness = 2;

            switch (sector.airClass)
            {
                case "A":
                    rect.Stroke = airBrushes.ClassA;
                    break;
                case "B":
                    rect.Stroke = airBrushes.ClassBCD;
                    break;
                case "C":
                    rect.Stroke = airBrushes.ClassBCD;
                    rect.StrokeDashArray = new DoubleCollection { 2 };
                    break;
                case "D":
                    rect.Stroke = airBrushes.ClassBCD;
                    break;
                case "E":
                    rect.Stroke = airBrushes.ClassE;
                    break;
                case "SIV":
                    rect.Stroke = airBrushes.SIV;
                    rect.StrokeDashArray = new DoubleCollection { 1 };
                    break;
                case "P":
                    rect.Stroke = airBrushes.Prohibited;
                    rect.StrokeDashArray = new DoubleCollection { 2 };
                    break;

                default:
                    rect.Stroke = System.Windows.Media.Brushes.Black;
                    rect.StrokeThickness = 1;
                    break;
            }


            //TEXT

            //CLASS
            Label airClass = new Label
            {
                Content = sector.airClass
            };
            Canvas.SetLeft(airClass,x+width*0.4); Canvas.SetTop(airClass, y + height * 0.5 + 12);
            airClass.Foreground = rect.Stroke;
            canvas.Children.Add(airClass);

            //NAME
            Label name = new Label
            {
                Content = sector.name
            };
            Canvas.SetLeft(name, x + width * 0.4); Canvas.SetTop(name, y + height * 0.5);
            name.Foreground = rect.Stroke;
            canvas.Children.Add(name);

            //FREQUENCY
            if (sector.freq != 0)
            {
                Label freq = new Label
                {
                    Content = sector.freq
                };
                Canvas.SetLeft(freq, x + width * 0.4); Canvas.SetTop(freq, y + height * 0.5 - 12);
                freq.Foreground = rect.Stroke;
                canvas.Children.Add(freq);
            }
            
        }

        public void PaintPlaneTrajectory()
        {
            PlaneTrajectoryPoint lastPoint = null;
            foreach (PlaneTrajectoryPoint point in flp.PlaneTrajectory.planeTrajectoryPoints)
            {
                //Point
                Rectangle pts = new Rectangle
                {
                    Width = 4,
                    Height = 4
                };

                canvas.Children.Add(pts);
                Canvas.SetLeft(pts, pxX * point.Distance + leftMargin-2);
                Canvas.SetBottom(pts, pxY * point.Altitude + bottMargin-2);
                pts.Stroke = System.Windows.Media.Brushes.Black;
                pts.Fill = System.Windows.Media.Brushes.Black;

                //Line
                if (lastPoint != null)
                {
                    double X1 = pxX * point.Distance + leftMargin;
                    double X2 = pxX * lastPoint.Distance + leftMargin;
                    double Y1 = canvas.ActualHeight - (pxY * point.Altitude + bottMargin);
                    double Y2 = canvas.ActualHeight - (pxY * lastPoint.Altitude + bottMargin);
                    Line line = LineGenerator(X1, X2, Y1, Y2);
                    canvas.Children.Add(line);
                }
                lastPoint = point;

            }
            

        }

        Line LineGenerator(double x1, double x2, double y1, double y2, Brush stroke = null)
        {
            Line line = new Line
            {
                X1 = x1,
                X2 = x2,
                Y1 = y1,
                Y2 = y2
            };

            if (stroke == null)
            {
                line.Stroke = System.Windows.Media.Brushes.Black;
            }
            else
            {
                line.Stroke = stroke;
            }
                
            
            return line;
        }

        public void CreatePNG(Canvas canvas, string path)
        {
            Rect rect;

            if (canvas.RenderSize != new Size(0,0))
            {
                rect = new Rect(canvas.RenderSize);
            }
            else
            {
                rect = new Rect(new Size(canvas.Width, canvas.Height));
            }

            
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)rect.Right, (int)rect.Bottom, 96d, 96d, PixelFormats.Default);
            rtb.Render(canvas);
            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            pngEncoder.Save(ms);
            ms.Close();

            

            System.IO.File.WriteAllBytes(path, ms.ToArray());
        }
    }
}
