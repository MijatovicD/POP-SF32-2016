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


            //dgNametajLista.ItemsSource = Projekat.Instance.Namestaj;
            dpDatumPocetka.DataContext = akcijskaProdaja;
            tbPopust.DataContext = akcijskaProdaja;
            dgNametajLista.DataContext = akcijskaProdaja;
            dpDatumZavrsetka.DataContext = akcijskaProdaja;

            var listaNamestaja = Projekat.Instance.Namestaji;
            var listaAkcija = Projekat.Instance.AkcijskeProdaje;

            foreach (var akcija in listaAkcija)
            {
                    foreach (var namestaj in listaNamestaja)
                    {
                        if (akcija.Id != namestaj.AkcijaId)
                        {
                            if (namestaj.Obrisan == false)
                            {
                                dgNametajLista.ItemsSource = listaNamestaja;
                            }
                        }
                    
                    }
            }

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
                    break;
                default:
                    break;
            }

            //GenericSerializer.Serialize("akcijskaProdaja.xml", listaAkcija);

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
        }
    }
}
