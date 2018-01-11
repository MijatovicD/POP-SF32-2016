using POP_SF_32_2016_GUI.Model;
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
    /// Interaction logic for NamestajZaProdaju.xaml
    /// </summary>
    public partial class NamestajZaProdaju : Window
    {

        public ObservableCollection<Namestaj> IzabraniNamestaj { get; set; }
        public StavkaNamestaja StavkaNamestaja { get; set; }
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };
        public NamestajZaProdaju(StavkaNamestaja stavkaNamestaja, Operacija operacija)
        {

            InitializeComponent();
          
            this.stavkaNamestaja = stavkaNamestaja;
            this.operacija = operacija;

            StavkaNamestaja = stavkaNamestaja;
            tbKolicina.DataContext = stavkaNamestaja;
            dgNamestajProdaja.ItemsSource = Projekat.Instance.Namestaji;
            dgNamestajProdaja.DataContext = StavkaNamestaja;

            dgNamestajProdaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

        }

        private StavkaNamestaja stavkaNamestaja;
        private Operacija operacija;

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaNamestaja = Projekat.Instance.Namestaji;
            var izabraniNamestaj = (Namestaj)dgNamestajProdaja.SelectedItem;

            switch (operacija)
            {
                case Operacija.DODAVANJE:

                  
                        StavkaNamestaja.Namestaj = dgNamestajProdaja.SelectedItem as Namestaj;


                    break;

                default:
                    break;
            }


            Close();
        }


        private void dgNamestajProdaja_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "NamestajId")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "TipNamestajaId")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "AkcijaId")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }

    }
}
