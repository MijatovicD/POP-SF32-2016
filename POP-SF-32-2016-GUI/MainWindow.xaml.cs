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

            this.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/pocetna.jpg")));
        }
       

        private void Namestaji(object sender, RoutedEventArgs e)
        {

            var namestajProzor = new NamestajWindow();
            namestajProzor.Show();            

        }

        private void TipNamestaja(object sender, RoutedEventArgs e)
        {

            var tipNamestajaProzor = new TipNamestajaWindow();
            tipNamestajaProzor.Show();

        }

        private void DodatnaUsluga(object sender, RoutedEventArgs e)
        {
            var dodatnaProzor = new DodatnaWindow();
            dodatnaProzor.Show();
        }

        private void Salon(object sender, RoutedEventArgs e)
        {
            var salonProzor = new SalonWindow();
            salonProzor.Show();
        }

        private void Korisnik(object sender, RoutedEventArgs e)
        {
            var korisnikProzor = new KorisnikWindow();
            korisnikProzor.Show();
        }

        private void AkcijskaProdaja(object sender, RoutedEventArgs e)
        {
            var akcijaProzor = new AkcijaWindow();
            akcijaProzor.Show();
        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
