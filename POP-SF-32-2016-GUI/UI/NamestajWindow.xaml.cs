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
       ICollectionView vieew;
       public TipNamestaja tipNamestaja;
       
        public Namestaj IzabraniNamestaj { get; set; }

        public NamestajWindow()
        {
            InitializeComponent();
            vieew = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaji);
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
            dgNamestaj.ItemsSource = vieew;
       

            cbSortiraj.Items.Add("");
            cbSortiraj.Items.Add("Naziv");
            cbSortiraj.Items.Add("Sifra");
            cbSortiraj.Items.Add("Cena");
            cbSortiraj.Items.Add("Kolcina u Magacinu");
            cbSortiraj.Items.Add("Akciji");
            cbSortiraj.Items.Add("Tipu namestaja");

            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
      
            vieew.Filter = NamestajFilter;
            
        }

        private bool NamestajFilter(object obj)
        {
            var listaAkcija = Projekat.Instance.AkcijskaProdaja;
            var listaNamestaja = Projekat.Instance.Namestaji;
            foreach (var akcija in listaAkcija)
            {
                if (akcija.DatumPocetka < DateTime.Today && akcija.DatumZavrsetka < DateTime.Today)
                {
                    foreach (var namestaj in listaNamestaja)
                    {
                        if (namestaj.AkcijaId == akcija.Id)
                        {
                            if (akcija.Obrisan == true)
                            {
                                namestaj.AkcijaId = 0;
                            }
                        }
                       
                    }
                }
            }
            return ((Namestaj)obj).Obrisan == false;
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
            var listaNamestaj = Projekat.Instance.Namestaji;
            var listaAkcija = Projekat.Instance.AkcijskaProdaja;
            if (MessageBox.Show($"Da li zelite da obrisete: {izabranNamestaj.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var n in listaNamestaj)
                {
                    if (n.Id == izabranNamestaj.Id)
                    {
                        n.Obrisan = true;
                        vieew.Filter = NamestajFilter;

                        foreach (var namestaj in listaNamestaj)
                        {
                            if (namestaj.Obrisan == true)
                            {
                                foreach (var akcija in listaAkcija)
                                {
                                    if (namestaj.AkcijaId == akcija.Id)
                                    {
                                        akcija.Obrisan = true;
                                    }
                                }
                            }
                        }
                    }
                }

                GenericSerializer.Serialize("namestaj.xml", listaNamestaj);
                GenericSerializer.Serialize("akcijskaProdaja.xml", listaAkcija);
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
                return ((item as Namestaj).Naziv.StartsWith(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) || (item as Namestaj).Sifra.StartsWith(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) || (item as Namestaj).TipNamestaja.Naziv.StartsWith(tbPretraga.Text, StringComparison.OrdinalIgnoreCase));
            }

        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgNamestaj.ItemsSource);
            view.Filter = Pretraga;
            CollectionViewSource.GetDefaultView(dgNamestaj.ItemsSource).Refresh();
        }

        private void cbSortiraj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cbSortiraj.SelectedIndex == 0)
            {
                dgNamestaj.Items.SortDescriptions.Clear();

            }

            else if (cbSortiraj.SelectedIndex == 1)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Descending));
            }

            else if (cbSortiraj.SelectedIndex == 2)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("Sifra", ListSortDirection.Descending));
            }

            else if(cbSortiraj.SelectedIndex == 3)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("JedinicnaCena", ListSortDirection.Descending));
            }

            else if (cbSortiraj.SelectedIndex == 4)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("KolicinaUMagacinu", ListSortDirection.Descending));
            }

            else if (cbSortiraj.SelectedIndex == 5)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("AkcijaId", ListSortDirection.Descending));
            }

            else if (cbSortiraj.SelectedIndex == 6)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("TipNamestajaId", ListSortDirection.Descending));
            }
        }

        private void dgNamestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "TipNamestajaId")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "AkcijaId")
            {
                e.Cancel = true;
            }
        }
    }
}
