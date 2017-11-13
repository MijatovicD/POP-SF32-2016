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
    /// Interaction logic for KorisnikWindow.xaml
    /// </summary>
    public partial class KorisnikWindow : Window
    {
        public KorisnikWindow()
        {
            InitializeComponent();
            OsveziPrikaz();
        }

        private void DodajKorisnika(object sender, RoutedEventArgs e)
        {
            var noviKorisnik = new Korisnik()
            {
                Ime = "",
                Prezime = "",
                KorisnickoIme = "",
                Lozinka = "",
                TipKorisnika = 0
            };

            var korisnikProzor = new DodavanjeIzmenaKorisnika(noviKorisnik, DodavanjeIzmenaKorisnika.Operacija.DODAVANJE);
            korisnikProzor.Show();
        }

        private void IzmeniKorisnika(object sender, RoutedEventArgs e)
        {
            var izabraniKorisnik = (Korisnik)lbKorisnik.SelectedItem;

            var korisnikProzor = new DodavanjeIzmenaKorisnika(izabraniKorisnik, DodavanjeIzmenaKorisnika.Operacija.IZMENA);
            korisnikProzor.Show();

        }



        private void OsveziPrikaz()
        {
            lbKorisnik.Items.Clear();

            foreach (var korisnik in Projekat.Instance.Korisnik)
            {
                lbKorisnik.Items.Add(korisnik);
            }

            lbKorisnik.SelectedIndex = 0;
        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            OsveziPrikaz();
        }
    }
}
