using POP_SF32_2016.Model;
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

            InicijalizujVrednosti(akcijskaProdaja, operacija);
        }

        private void InicijalizujVrednosti(AkcijskaProdaja akcijskaProdaja, Operacija operacija)
        {
            this.akcijskaProdaja = akcijskaProdaja;
            this.operacija = operacija;

            this.tbPopust.Text = System.Convert.ToString(akcijskaProdaja.Popust);
            //this.tbNamestaj.Text = akcijskaProdaja.NamestajNaPopustu;
            
        }

        AkcijskaProdaja akcijskaProdaja;
        Operacija operacija;

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaAkcija = Projekat.Instance.AkcijskaProdaja;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var novaAkcija = new AkcijskaProdaja()
                    {
                        Id = listaAkcija.Count + 1,
                        DatumPocetka = this.dpDatumPocetka.SelectedDate.Value,
                        Popust = decimal.Parse(tbPopust.Text),
                        DatumZavrsetka = this.dpDatumZavrsetka.SelectedDate.Value
                    };
                    listaAkcija.Add(novaAkcija);
                    break;

                case Operacija.IZMENA:
                    foreach (var a in listaAkcija)
                    {
                        if (a.Id == akcijskaProdaja.Id)
                        {
                            a.Id = listaAkcija.Count + 1;
                            a.DatumPocetka = this.dpDatumPocetka.SelectedDate.Value;
                            a.Popust = decimal.Parse(tbPopust.Text);
                            a.DatumZavrsetka = this.dpDatumZavrsetka.SelectedDate.Value;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }

            Projekat.Instance.AkcijskaProdaja = listaAkcija;

            Close();
        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
