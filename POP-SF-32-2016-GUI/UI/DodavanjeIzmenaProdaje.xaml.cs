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
    /// Interaction logic for DodavanjeIzmenaProdaje.xaml
    /// </summary>
    public partial class DodavanjeIzmenaProdaje : Window
    {

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        public DodavanjeIzmenaProdaje(ProdajaNamestaja prodajaNamestaja, Operacija operacija)
        {
            InitializeComponent();

            this.prodajaNamestaja = prodajaNamestaja;
            this.operacija = operacija;


            cbNamestaj.ItemsSource = Projekat.Instance.Namestaj;
            cbDodatna.ItemsSource = Projekat.Instance.DodatnaUsluga;

            cbNamestaj.DataContext = prodajaNamestaja;
            cbDodatna.DataContext = prodajaNamestaja;
            dDatumProdaje.DataContext = prodajaNamestaja;
            lbCena.DataContext = prodajaNamestaja;
            tbBrojRacuna.DataContext = prodajaNamestaja;
        }
        
        private ProdajaNamestaja prodajaNamestaja;
        private Operacija operacija;


        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaProdaje = Projekat.Instance.ProdajaNamestaja;
            var izabraniNamestaj = (Namestaj)cbNamestaj.SelectedItem;
            var izabranaUsluga = (DodatnaUsluga)cbDodatna.SelectedItem;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    prodajaNamestaja.Id = listaProdaje.Count + 1;
                    prodajaNamestaja.NamestajZaProdaju = new List<Namestaj>(izabraniNamestaj.Id);
                    prodajaNamestaja.DatumProdaje = dDatumProdaje.SelectedDate.Value;
                    prodajaNamestaja.BrojRacuna = tbBrojRacuna.Text;
                    prodajaNamestaja.Kupac = tbKupac.Text;
                    prodajaNamestaja.DodatnaUsluga = new List<DodatnaUsluga>().ToList();
                    prodajaNamestaja.UkupanIznos = prodajaNamestaja.PDV * (izabraniNamestaj.JedinicnaCena + izabranaUsluga.Cena);

                    listaProdaje.Add(prodajaNamestaja);
                    break;
                case Operacija.IZMENA:
                    break;
                default:
                    break;
            }

            GenericSerializer.Serialize("prodajaNamestaja.xml", listaProdaje);

            Close();
        }

    }
}
