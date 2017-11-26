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
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijaWindow : Window
    {
        public AkcijskaProdaja IzabranaAkcija { get; set; }
        public AkcijaWindow()
        {
            InitializeComponent();
            dgAkcija.IsSynchronizedWithCurrentItem = true;
            dgAkcija.DataContext = this;
            dgAkcija.ItemsSource = Projekat.Instance.AkcijskaProdaja;

            cbSortiraj.Items.Add("DatumPocetka");
            cbSortiraj.Items.Add("Popust");
            cbSortiraj.Items.Add("DatumZavrsetka");

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgAkcija.ItemsSource);
            //view.Filter = Pretraga;
        }


        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DodajAkciju_Click(object sender, RoutedEventArgs e)
        {
            var novaAkcija = new AkcijskaProdaja()
            {
                DatumPocetka = DateTime.Today,
                Popust = 0,
                DatumZavrsetka = DateTime.Today
            };

            var akcijaProzor = new DodavanjeIzmenaAkcije(novaAkcija, DodavanjeIzmenaAkcije.Operacija.DODAVANJE);
            akcijaProzor.ShowDialog();
       
        }

        private void IzmeniAkciju_Click(object sender, RoutedEventArgs e)
        {
            AkcijskaProdaja kopija = (AkcijskaProdaja)IzabranaAkcija.Clone();

            var akcijaProzor = new DodavanjeIzmenaAkcije(kopija, DodavanjeIzmenaAkcije.Operacija.IZMENA);
            akcijaProzor.ShowDialog();
       
        }

        private void ObrsiAkciju_Click(object sender, RoutedEventArgs e)
        {
            var izabranaAkcija = (AkcijskaProdaja)dgAkcija.SelectedItem;
            var listaAkcija = Projekat.Instance.AkcijskaProdaja;
            if (MessageBox.Show($"Da li zelite da obrisete: {izabranaAkcija.Id}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var akcija in listaAkcija)
                {
                    if (akcija.Id == izabranaAkcija.Id)
                    {
                        akcija.Obrisan = true;
                    }
                }

                GenericSerializer.Serialize("akcijskaProdaja.xml", listaAkcija);
          
            }
        }
        //private bool Pretraga(object item)
        //{

        //    if (String.IsNullOrEmpty(tbPretraga.Text))
        //    {
        //        return true;
        //    }

        //    else
        //    {
        //        return ((item as AkcijskaProdaja).DatumPocetka.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0 || (item as AkcijskaProdaja).Popust.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0 || (item as AkcijskaProdaja).DatumZavrsetka.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        //    }

        //}

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgAkcija.ItemsSource).Refresh();
        }

        private void cbSortiraj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cbSortiraj.SelectedIndex == 0)
            {
                dgAkcija.Items.SortDescriptions.Clear();
                dgAkcija.Items.SortDescriptions.Add(new SortDescription("DatumPocetka", ListSortDirection.Descending));
            }

            else if (cbSortiraj.SelectedIndex == 1)
            {
                dgAkcija.Items.SortDescriptions.Clear();
                dgAkcija.Items.SortDescriptions.Add(new SortDescription("Popust", ListSortDirection.Descending));
            }

            else if (cbSortiraj.SelectedIndex == 2)
            {
                dgAkcija.Items.SortDescriptions.Clear();
                dgAkcija.Items.SortDescriptions.Add(new SortDescription("DatumZavrsetka", ListSortDirection.Descending));
            }
        }

    }
}
