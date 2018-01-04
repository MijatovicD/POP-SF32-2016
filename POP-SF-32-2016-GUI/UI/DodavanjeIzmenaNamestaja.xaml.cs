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
    /// Interaction logic for DodavanjeIzmenaNamestaja.xaml
    /// </summary>
    public partial class DodavanjeIzmenaNamestaja : Window
    {


        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        public DodavanjeIzmenaNamestaja(Namestaj namestaj, Operacija operacija)
        {

            InitializeComponent();

            this.namestaj = namestaj;
            this.operacija = operacija;

            cbTip.ItemsSource = Projekat.Instance.TipoviNamestaja;
            cbAkcija.ItemsSource = Projekat.Instance.AkcijskeProdaje;

            tbNaziv.DataContext = namestaj;
            tbCena.DataContext = namestaj;
            tbKolicina.DataContext = namestaj;
            cbTip.DataContext = namestaj;
            cbAkcija.DataContext = namestaj;
        }

        private Namestaj namestaj;
        private Operacija operacija;

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaNamestaja = Projekat.Instance.Namestaji;
            var listaAkcija = Projekat.Instance.AkcijskeProdaje;
            var izabraniTipNamestaja = (TipNamestaja)cbTip.SelectedItem;
            var izabranaAkcija = (AkcijskaProdaja)cbAkcija.SelectedItem;

            switch (operacija)
            {
                case Operacija.DODAVANJE:

                    Namestaj.Create(namestaj);

                    break;

                case Operacija.IZMENA:

                    Namestaj.Update(namestaj);

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

    }
}
