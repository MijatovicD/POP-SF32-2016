using POP_SF_32_2016_GUI.Model;
using POP_SF32_2016.Model;
using POP_SF32_2016.Until;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DodavanjeIzmenaAkcije.xaml
    /// </summary>
    public partial class DodavanjeIzmenaAkcije : Window
    {

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        public DodavanjeIzmenaAkcije(AkcijskaProdaja akcijskaProdaja, Operacija operacija)
        {

            InitializeComponent();

            this.akcijskaProdaja = akcijskaProdaja;
            this.operacija = operacija;


            dpDatumPocetka.DataContext = akcijskaProdaja;
            tbPopust.DataContext = akcijskaProdaja;
            tbNaziv.DataContext = akcijskaProdaja;
            dgNametajLista.DataContext = akcijskaProdaja;
            dpDatumZavrsetka.DataContext = akcijskaProdaja;

            dgNametajLista.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgNametajLista.ItemsSource = Projekat.Instance.Namestaji;

        }

        AkcijskaProdaja akcijskaProdaja;
        Operacija operacija;

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaAkcija = Projekat.Instance.AkcijskeProdaje;
            var listaNamestaja = Projekat.Instance.Namestaji;
            var dgNamestaj = (Namestaj)dgNametajLista.SelectedItem;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    
                    AkcijskaProdaja.Create(akcijskaProdaja);


                    break;

                case Operacija.IZMENA:

                    AkcijskaProdaja.Update(akcijskaProdaja);

                    foreach (var akcija in listaAkcija)
                    {
                        foreach (var namestaj in listaNamestaja)
                        {
                            if (namestaj.AkcijaId == akcija.Id)
                            {
                                namestaj.AkcijaId = akcija.Id;
                                Namestaj.Update(namestaj);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }


            Close();
        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgNametajLista_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "AkcijskaProdaja")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "AkcijaId")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "TipNamestajaId")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "Error")
            {
                e.Cancel = true;
            }
        }
    }
}
