using POP_SF32_2016.Model;
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

namespace POP_SF_32_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for SalonWindow.xaml
    /// </summary>
    public partial class SalonWindow : Window
    {
        public SalonWindow()
        {
            InitializeComponent();
            OsveziPrikaz();
        }

        private void OsveziPrikaz()
        {
            lbSalon.Items.Clear();

            foreach (var salon in Projekat.Instance.Salon)
            {
                lbSalon.Items.Add(salon);
            }

            lbSalon.SelectedIndex = 0;
        }
        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
