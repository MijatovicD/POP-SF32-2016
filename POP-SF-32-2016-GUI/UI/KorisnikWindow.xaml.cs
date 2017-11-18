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
            korisnikProzor.ShowDialog();

            OsveziPrikaz();
        }

        private void IzmeniKorisnika(object sender, RoutedEventArgs e)
        {
            var izabraniKorisnik = (Korisnik)lbKorisnik.SelectedItem;

            var korisnikProzor = new DodavanjeIzmenaKorisnika(izabraniKorisnik, DodavanjeIzmenaKorisnika.Operacija.IZMENA);
            korisnikProzor.ShowDialog();

            OsveziPrikaz();

        }



        private void OsveziPrikaz()
        {
            lbKorisnik.Items.Clear();

            foreach (var korisnik in Projekat.Instance.Korisnik)
            {
                if (korisnik.Obrisan == false)
                {
                    lbKorisnik.Items.Add(korisnik);
                }
            }

            lbKorisnik.SelectedIndex = 0;
        }

        private void Izbrisi(object sender, RoutedEventArgs e)
        {
            var izabraniKorisnik = (Korisnik)lbKorisnik.SelectedItem;
            var listaKorisnika = Projekat.Instance.Korisnik;
            if (MessageBox.Show($"Da li zelite da obrisete: {izabraniKorisnik.KorisnickoIme}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var korisnik in listaKorisnika)
                {
                    if (korisnik.Id == izabraniKorisnik.Id)
                    {
                        korisnik.Obrisan = true;
                    }
                }

                Projekat.Instance.Korisnik = listaKorisnika;

                OsveziPrikaz();
            }
        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
