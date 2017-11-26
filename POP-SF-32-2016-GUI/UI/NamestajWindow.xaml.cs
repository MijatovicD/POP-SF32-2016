using POP_SF32_2016.Model;
using POP_SF32_2016.Until;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {

        public Namestaj IzabraniNamestaj { get; set; }

        public NamestajWindow()
        {
            InitializeComponent();
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
            dgNamestaj.ItemsSource = Projekat.Instance.Namestaj;

            cbSortiraj.Items.Add("Naziv");
            cbSortiraj.Items.Add("JedinicnaCena");
            cbSortiraj.Items.Add("Tipu namestaja");

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgNamestaj.ItemsSource);
            view.Filter = Pretraga;
            
        }

        private void DodajNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = "",
                Sifra = "",
                JedinicnaCena = 0,
                KolicinaUMagacinu = 0,
                AkcijaId = 0,
                TipNamestajaId = 0
            };

            var namestajProzor = new DodavanjeIzmenaNamestaja(noviNamestaj, DodavanjeIzmenaNamestaja.Operacija.DODAVANJE);
            namestajProzor.ShowDialog();
        }

        private void IzmeniNamestaj_Click(object sender, RoutedEventArgs e)
        {
            Namestaj kopija = (Namestaj)IzabraniNamestaj.Clone();
            var namestajProzor = new DodavanjeIzmenaNamestaja(kopija, DodavanjeIzmenaNamestaja.Operacija.IZMENA);
            namestajProzor.ShowDialog();

        }



        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ObrsiNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var izabranNamestaj = (Namestaj)dgNamestaj.SelectedItem;
            var listaNamestaj = Projekat.Instance.Namestaj;
            if (MessageBox.Show($"Da li zelite da obrisete: {izabranNamestaj.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var n in listaNamestaj)
                {
                    if (n.Id == izabranNamestaj.Id)
                    {
                        n.Obrisan = true;
                        break;
                    }
                }

                GenericSerializer.Serialize("namestaj.xml", listaNamestaj);

            }
        }

        private bool Pretraga(object item)
        {

            if (String.IsNullOrEmpty(tbPretraga.Text))
            {
                return true;
            }

            else
            {
                return ((item as Namestaj).Naziv.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0 || (item as Namestaj).Sifra.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0 || (item as Namestaj).TipNamestaja.Naziv.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgNamestaj.ItemsSource).Refresh();
        }

        private void cbSortiraj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cbSortiraj.SelectedIndex == 0)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Descending));
            }

            else if(cbSortiraj.SelectedIndex == 1)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("JedinicnaCena", ListSortDirection.Descending));
            }

            else if (cbSortiraj.SelectedIndex == 2)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("TipNamestajaId", ListSortDirection.Descending));
            }
        }
    }
}
