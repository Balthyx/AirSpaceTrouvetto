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
using System.Windows.Shapes;

namespace AirSpaceTrouvetto
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WindowFlpQE : Window
    {
        readonly MainWindow parentWindow;
        readonly PlaneTrajectory planeTrajectory;
        public WindowFlpQE(MainWindow mainWindow, PlaneTrajectory planeTrajectory)
        {
            InitializeComponent();

            this.parentWindow = mainWindow;
            this.planeTrajectory = planeTrajectory;

            UpdateTextBoxes();
        }

        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {
            //
            planeTrajectory.GenerateTrajectory(float.Parse(TextBox_FlightLength.Text), float.Parse(TextBox_CruiseAlt.Text), float.Parse(TextBox_TOALT.Text), float.Parse(TextBox_landingAlt.Text));
            parentWindow.DrawRefresh();
            this.Close();
        }

        void UpdateTextBoxes()
        {
            
        }
    }
}
