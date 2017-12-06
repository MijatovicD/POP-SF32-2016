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
            dpDatumZavrsetka.DataContext = akcijskaProdaja;
            dgNametajLista.ItemsSource = Projekat.Instance.Namestaj;
        }

        AkcijskaProdaja akcijskaProdaja;
        Operacija operacija;

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaAkcija = Projekat.Instance.AkcijskaProdaja;
            var listaNamestaja = Projekat.Instance.Namestaj;
            var dgNamestaj = (Namestaj)dgNametajLista.SelectedItem;

            switch (operacija)
            {
                case Operacija.DODAVANJE:

                    akcijskaProdaja.Id = listaAkcija.Count + 1;
                    akcijskaProdaja.DatumPocetka = dpDatumPocetka.SelectedDate.Value;
                    akcijskaProdaja.Popust = decimal.Parse(tbPopust.Text);
                    akcijskaProdaja.DatumZavrsetka = dpDatumZavrsetka.SelectedDate.Value;
                    akcijskaProdaja.NamestajId = dgNamestaj.Id;
                    listaAkcija.Add(akcijskaProdaja);
                    break;

                case Operacija.IZMENA:
                    foreach (var a in listaAkcija)
                    {
                        if (a.Id == akcijskaProdaja.Id)
                        {

                            a.DatumPocetka = this.dpDatumPocetka.SelectedDate.Value;
                            a.Popust = akcijskaProdaja.Popust;
                            a.DatumZavrsetka = this.dpDatumZavrsetka.SelectedDate.Value;
                            a.Namestaj = akcijskaProdaja.Namestaj;
                            a.NamestajId = dgNamestaj.Id;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }

            GenericSerializer.Serialize("akcijskaProdaja.xml", listaAkcija);

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
