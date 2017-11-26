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
    /// Interaction logic for DodatnaWindow.xaml
    /// </summary>
    public partial class DodatnaWindow : Window
    {
        public DodatnaUsluga IzabranaUsluga { get; set; }
        public DodatnaWindow()
        {
            InitializeComponent();
            dgUsluga.IsSynchronizedWithCurrentItem = true;
            dgUsluga.DataContext = this;
            dgUsluga.ItemsSource = Projekat.Instance.DodatnaUsluga;

            cbSortiraj.Items.Add("Naziv");
            cbSortiraj.Items.Add("Cena");

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgUsluga.ItemsSource);
            view.Filter = Pretraga;

        }

        private void DodajUslugu_Click(object sender, RoutedEventArgs e)
        {
            var novaUsluga = new DodatnaUsluga()
            {
                Naziv = "",
                Cena = 0
            };

            var uslugaProzor = new DodavanjeIzmenaUsluge(novaUsluga, DodavanjeIzmenaUsluge.Operacija.DODAVANJE);
            uslugaProzor.ShowDialog();

        }

        private void IzmeniUslugu_Click(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga kopija = (DodatnaUsluga)IzabranaUsluga.Clone();

            var uslugaProzor = new DodavanjeIzmenaUsluge(kopija, DodavanjeIzmenaUsluge.Operacija.IZMENA);
            uslugaProzor.ShowDialog();

        
        }

        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Izbrsi_Click(object sender, RoutedEventArgs e)
        {

            var izabranaUsluga = (DodatnaUsluga)dgUsluga.SelectedItem;
            var listaUsluga = Projekat.Instance.DodatnaUsluga;
            if (MessageBox.Show($"Da li zelite da obrisete: {izabranaUsluga.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var usluga in listaUsluga)
                {
                    if (usluga.Id == izabranaUsluga.Id)
                    {
                        usluga.Obrisan = true;
                    }
                }

                GenericSerializer.Serialize("dodatnaUsluga.xml", listaUsluga);

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
                return ((item as DodatnaUsluga).Naziv.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0 );
            }

        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgUsluga.ItemsSource).Refresh();
        }

        private void cbSortiraj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cbSortiraj.SelectedIndex == 0)
            {
                dgUsluga.Items.SortDescriptions.Clear();
                dgUsluga.Items.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Descending));
            }

            else if (cbSortiraj.SelectedIndex == 1)
            {
                dgUsluga.Items.SortDescriptions.Clear();
                dgUsluga.Items.SortDescriptions.Add(new SortDescription("Cena", ListSortDirection.Descending));
            }
        }
    }
}
