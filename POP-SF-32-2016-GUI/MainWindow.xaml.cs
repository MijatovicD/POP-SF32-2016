using POP_SF_32_2016_GUI.UI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POP_SF_32_2016_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OsveziPrikaz();
        }

        private void OsveziPrikaz()
        {
            lbNamestaj.Items.Clear();

            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                lbNamestaj.Items.Add(namestaj);
            }

            lbNamestaj.SelectedIndex = 0;
        }


        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = ""
            };
            
            var namestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.DODAVANJE);
            namestajProzor.Show();

            
        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void IzmeniNamestaj(object sender, RoutedEventArgs e)
        {

            var izabraniNamestaj = (Namestaj)lbNamestaj.SelectedItem;

            var namestajProzor = new NamestajWindow(izabraniNamestaj, NamestajWindow.Operacija.IZMENA);
            namestajProzor.Show();

            
        }

        private void Izmeni(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("=== Osvezio se prozor ===");
            OsveziPrikaz();
        }
    }
}
