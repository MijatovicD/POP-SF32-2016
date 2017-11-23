using POP_SF32_2016.Model;
using POP_SF32_2016.Until;
using System;
using System.Collections.Generic;
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
            tbNamestaj.DataContext = akcijskaProdaja;
        }

        AkcijskaProdaja akcijskaProdaja;
        Operacija operacija;

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaAkcija = Projekat.Instance.AkcijskaProdaja;

            switch (operacija)
            {
                case Operacija.DODAVANJE:

                    akcijskaProdaja.Id = listaAkcija.Count + 1;
                    akcijskaProdaja.DatumPocetka = dpDatumPocetka.SelectedDate.Value;
                    akcijskaProdaja.Popust = decimal.Parse(tbPopust.Text);
                    akcijskaProdaja.DatumZavrsetka = dpDatumZavrsetka.SelectedDate.Value;
                    //akcijskaProdaja.NamestajNaPopustu = tbNamestaj.Text;
                    listaAkcija.Add(akcijskaProdaja);
                    break;

                case Operacija.IZMENA:
                    foreach (var a in listaAkcija)
                    {
                        if (a.Id == akcijskaProdaja.Id)
                        {
                            a.Id = listaAkcija.Count + 1;
                            a.DatumPocetka = akcijskaProdaja.DatumPocetka;
                            a.Popust = akcijskaProdaja.Popust;
                            a.DatumZavrsetka = akcijskaProdaja.DatumZavrsetka;
                            a.NamestajNaPopustu = akcijskaProdaja.NamestajNaPopustu;
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
    }
}
