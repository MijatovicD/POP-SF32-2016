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
    /// Interaction logic for TipNamestajaWindow.xaml
    /// </summary>
    public partial class TipNamestajaWindow : Window
    {
        ICollectionView vieew;
        public TipNamestaja IzabraniTip { get; set; }
        public TipNamestajaWindow()
        {
            InitializeComponent();
            vieew = CollectionViewSource.GetDefaultView(Projekat.Instance.TipNamestaja);
            dgTipNamestaja.IsSynchronizedWithCurrentItem = true;
            dgTipNamestaja.DataContext = this;
            dgTipNamestaja.ItemsSource = vieew;

            dgTipNamestaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            cbSortiraj.Items.Add("Naziv");

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgTipNamestaja.ItemsSource);
            view.Filter = Pretraga;
            vieew.Filter = FilterTipNamestaja;

        }

        private bool FilterTipNamestaja(object obj)
        {
            return ((TipNamestaja)obj).Obrisan == false;
        }

        private void DodajTip_Click(object sender, RoutedEventArgs e)
        {
            var noviTip = new TipNamestaja()
            {
                Naziv = ""
            };

            var tipProzor = new DodavanjeIzmenaTipaNamestaja(noviTip, DodavanjeIzmenaTipaNamestaja.Operacija.DODAVANJE);
            tipProzor.ShowDialog();

        }

        private void IzmeniTip_Click(object sender, RoutedEventArgs e)
        {
            TipNamestaja kopija = (TipNamestaja)IzabraniTip.Clone();

            var tipProzor = new DodavanjeIzmenaTipaNamestaja(kopija, DodavanjeIzmenaTipaNamestaja.Operacija.IZMENA);
            tipProzor.ShowDialog();

        }


        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Izbrisi_Clik(object sender, RoutedEventArgs e)
        {
            var izabraniTip = (TipNamestaja)dgTipNamestaja.SelectedItem;
            var listaTipa = Projekat.Instance.TipNamestaja;
            if (MessageBox.Show($"Da li zelite da obrisete: {izabraniTip.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var tip in listaTipa)
                {
                    if (tip.Id == izabraniTip.Id)
                    {
                        tip.Obrisan = true;
                        vieew.Refresh();
                    }
                }

                GenericSerializer.Serialize("tipoviNamestaja.xml", listaTipa);
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
                return ((item as TipNamestaja).Naziv.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgTipNamestaja.ItemsSource).Refresh();
        }

        private void cbSortiraj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cbSortiraj.SelectedIndex == 0)
            {
                dgTipNamestaja.Items.SortDescriptions.Clear();
                dgTipNamestaja.Items.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Descending));
            }

        }

        private void dgTipNamestaja_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }
    }
}
