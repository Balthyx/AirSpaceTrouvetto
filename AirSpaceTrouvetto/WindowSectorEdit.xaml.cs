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
    /// Interaction logic for WindowSectorEdit.xaml
    /// </summary>
    public partial class WindowSectorEdit : Window
    {
        public Sector sector;
        readonly MainWindow parentWindow;
        public WindowSectorEdit(MainWindow mainWindow, Sector sector = null)
        {
            InitializeComponent();

            if(sector != null)
            {
                this.sector = sector;
                this.parentWindow = mainWindow;
                
                TextBox_name.Text = sector.name;
                TextBox_Class.Text = sector.airClass;
                TextBox_freq.Text = sector.freq.ToString();
                TextBox_minAlt.Text = sector.altMin.ToString();
                TextBox_maxAlt.Text = sector.altMax.ToString();
                TextBox_distMin.Text = sector.distMin.ToString();
                TextBox_DistMax.Text = sector.distMax.ToString();
            }
        }

        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {
            sector.name = TextBox_name.Text;
            sector.airClass = TextBox_Class.Text;
            sector.freq = float.Parse(TextBox_freq.Text);
            sector.altMin = float.Parse(TextBox_minAlt.Text);
            sector.altMax = float.Parse(TextBox_maxAlt.Text);
            sector.distMin = float.Parse(TextBox_distMin.Text);
            sector.distMax = float.Parse(TextBox_DistMax.Text);

            parentWindow.Refresh();

            this.Close();
        }

    }
}
