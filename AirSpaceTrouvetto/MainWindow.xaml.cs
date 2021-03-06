using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace AirSpaceTrouvetto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Graph graph;
        readonly SaveManager save;
        FlightPlan flp;

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                save = new SaveManager();

                Menu_New_Click(null,null);
            }
            catch (Exception e)
            {
                MessageBox.Show($"OH NO ! : {e.Message}");
            }
        }



        void OnLoad(object sender, RoutedEventArgs e)
        {
            
        }

        void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            DrawRefresh();
        }

        //Refreshs
        public void Refresh()
        {
            DrawRefresh();
            ListPanelRefresh();
        }
        public void DrawRefresh()
        {
            if (graph != null)
            {
                graph.PaintScales();
                graph.PaintAllSectors();
                graph.PaintPlaneTrajectory();
            }
        }
        void ListPanelRefresh()
        {
            ListView_SectorList.Items.Clear();

            TextBox_AltMax.Text = graph.maxAlt.ToString();
            TextBox_DistMax.Text = graph.maxLenght.ToString();

            foreach (Sector sector in flp.sectorList)
            {
                
                ListView_SectorList.Items.Add(sector.name);
            }
        }
        
        private void TextBox_AltMax_LostFocus(object sender, RoutedEventArgs e)
        {
            try {graph.maxAlt = float.Parse(TextBox_AltMax.Text);}
            catch (Exception) { }
            DrawRefresh();
        }

        private void TextBox_DistMax_LostFocus(object sender, RoutedEventArgs e)
        {
            try { graph.maxLenght = float.Parse(TextBox_DistMax.Text); }
            catch (Exception) { }
            DrawRefresh();
        }

        private void ListView_SectorList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Sector modifiedSector = flp.sectorList[ListView_SectorList.SelectedIndex];
            LaunchWindowSectorEdit(modifiedSector);
        }

        void LaunchWindowSectorEdit(Sector sector)
        {
            WindowSectorEdit windowSectorEdit = new WindowSectorEdit(this, sector);
            windowSectorEdit.Show();
        }
        // MENU FILES
        private void Menu_New_Click(object sender, RoutedEventArgs e)
        {
            flp = new FlightPlan(new List<Sector>(), new PlaneTrajectory());
            graph = new Graph(Canvas_graph, flp);
            Refresh();
        }
        void OpenFile(object sender, RoutedEventArgs rea)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    flp = save.LoadFlp(openFileDialog.FileName);
                    graph = new Graph(Canvas_graph, flp);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Fichier xml illisible : {e.Message}");
                }
                graph.UpdateLenghtAlt();
                Refresh();
            }
        }
        private void Menu_SaveAs_Click(object sender, RoutedEventArgs rea)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    save.SaveFlp(saveFileDialog.FileName, flp);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Unable to save : {e.Message}");
                }

            }
        }

        private void Menu_Flp_QuickEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowFlpQE windowFlpQE = new WindowFlpQE(this, flp.PlaneTrajectory);
            windowFlpQE.Show();
        }
        private void Canevas_graph_MouseMove(object sender, MouseEventArgs e)
        {
            double distance;
            double altitude;
            if(graph != null)
            {
                Point mousePosition = Mouse.GetPosition(Canvas_graph);

                distance = (mousePosition.X - graph.leftMargin) / graph.pxX;
                altitude = ((graph.canvas.ActualHeight - graph.bottMargin) - mousePosition.Y) / graph.pxY;

                distance = Math.Max( Math.Round(distance, 1), 0);
                altitude = Math.Max( Math.Round(altitude), 0);

                Label_CursorDistance.Content = "Distance : " + distance.ToString() + " NM";
                Label_CursorAltitude.Content = "Altitude : " + altitude.ToString() + " ft";
            }
            
        }

        // ADD REMOVE
        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            WindowSectorEdit windowSectorEdit = new WindowSectorEdit(this, new Sector("New sector", "D", 0, 0, 10000, 0, 10));
            windowSectorEdit.Show();
            flp.sectorList.Add(windowSectorEdit.sector);
        }
        private void Button_Remove_Click(object sender, RoutedEventArgs e)
        {
            if(flp.sectorList.Count > 0)
            {
                flp.sectorList.RemoveAt(ListView_SectorList.SelectedIndex);
                Refresh();
            }
            
        }

        private void Menu_Print_Click(object sender, RoutedEventArgs e)
        {

            PrintPreview printPreview = new PrintPreview();
            printPreview.Show();
            

            Graph exportGraph = new Graph(printPreview.Canvas_Preview, flp);
            exportGraph.fontSize = 24;
            exportGraph.PaintAll();


            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "png files (*.png)|*.png|All files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    graph.CreatePNG(printPreview.Canvas_Preview, saveFileDialog.FileName);
                }
                catch (Exception es)
                {
                    MessageBox.Show($"Unable to save : {es.Message}");
                }

            }
            printPreview.Close();

        }

        private void DockPanel_Main_Drop(object sender, DragEventArgs e)
        {
            try
            {
                string[] urls = (string[])e.Data.GetData(DataFormats.FileDrop);

                flp = save.LoadFlp(urls[0]);
                graph = new Graph(Canvas_graph, flp);
            }
            catch (Exception er)
            {
                MessageBox.Show($"Fichier xml illisible : {er.Message}");
            }
            DrawRefresh();
            ListPanelRefresh();
        }

        
    }

}
