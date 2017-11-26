using POP_SF32_2016.Model;
using POP_SF32_2016.Until;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public Korisnik IzabraniKorisnik { get; set; }
        public KorisnikWindow()
        {
            InitializeComponent();
            dgKorisnik.IsSynchronizedWithCurrentItem = true;
            dgKorisnik.DataContext = this;
            dgKorisnik.ItemsSource = Projekat.Instance.Korisnik;

            cbSortiraj.Items.Add("Ime");
            cbSortiraj.Items.Add("Prezime");
            cbSortiraj.Items.Add("KorisnickoIme");



            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgKorisnik.ItemsSource);
            view.Filter = Pretraga;
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

        }

        private void IzmeniKorisnika(object sender, RoutedEventArgs e)
        {
            Korisnik kopija = (Korisnik)IzabraniKorisnik.Clone();

            var korisnikProzor = new DodavanjeIzmenaKorisnika(kopija, DodavanjeIzmenaKorisnika.Operacija.IZMENA);
            korisnikProzor.ShowDialog();


        }



        private void Izbrisi(object sender, RoutedEventArgs e)
        {
            var izabraniKorisnik = (Korisnik)dgKorisnik.SelectedItem;
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

                GenericSerializer.Serialize("korisnik.xml", listaKorisnika);

            }
        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private bool Pretraga(object item)
        {

            if (String.IsNullOrEmpty(tbPretraga.Text))
            {
                return true;
            }

            else
            {
                return ((item as Korisnik).Ime.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0 || (item as Korisnik).Prezime.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0 || (item as Korisnik).KorisnickoIme.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgKorisnik.ItemsSource).Refresh();
        }

        private void cbSortiraj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cbSortiraj.SelectedIndex == 0)
            {
                dgKorisnik.Items.SortDescriptions.Clear();
                dgKorisnik.Items.SortDescriptions.Add(new SortDescription("Ime", ListSortDirection.Descending));
            }

            else if (cbSortiraj.SelectedIndex == 1)
            {
                dgKorisnik.Items.SortDescriptions.Clear();
                dgKorisnik.Items.SortDescriptions.Add(new SortDescription("Prezime", ListSortDirection.Descending));
            }

            else if (cbSortiraj.SelectedIndex == 2)
            {
                dgKorisnik.Items.SortDescriptions.Clear();
                dgKorisnik.Items.SortDescriptions.Add(new SortDescription("KorisnickoIme", ListSortDirection.Descending));
            }
        }
    }
}
