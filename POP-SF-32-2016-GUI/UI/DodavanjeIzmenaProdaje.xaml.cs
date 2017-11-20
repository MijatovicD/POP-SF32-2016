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
    /// Interaction logic for DodavanjeIzmenaProdaje.xaml
    /// </summary>
    public partial class DodavanjeIzmenaProdaje : Window
    {

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        public DodavanjeIzmenaProdaje(ProdajaNamestaja novaProdaja, Operacija operacija)
        {
            InitializeComponent();

            InicijalizujVrednosti(prodajaNamestaja, operacija);
        }

        private void InicijalizujVrednosti(ProdajaNamestaja prodajaNamestaja, Operacija operacija)
        {
            this.prodajaNamestaja = prodajaNamestaja;
            this.operacija = operacija;
            
            //prodajaNamestaja.NamestajZaProdaju = new List<int>();
            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                cbNamestaj.Items.Add(Namestaj.GetById(namestaj.Id));
            }

            foreach (var n in cbNamestaj.Items)
            {
                if (n == n)
                {
                    cbNamestaj.SelectedItem = n;
                    break;
                }
            }
            
            //this.tbBrojRacuna.Text = prodajaNamestaja.BrojRacuna;
            //this.cbKupac.SelectedItem = prodajaNamestaja.Kupac;
            //prodajaNamestaja.DodatnaUsluga = new List<DodatnaUsluga>();
            //foreach (var usluga in Projekat.Instance.DodatnaUsluga)
            //{
            //    cbDodatna.Items.Add(DodatnaUsluga.GetById(usluga.Id));
            //}
            //this.tbCena.Text = System.Convert.ToString(prodajaNamestaja.UkupanIznos);
            
        }
        

        private ProdajaNamestaja prodajaNamestaja;
        private Operacija operacija;


        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            //var listaProdaje = Projekat.Instance.ProdajaNamestaja;

            //switch (operacija)
            //{
            //    case Operacija.DODAVANJE:
            //        var novaProdaja = new ProdajaNamestaja()
            //        {
            //            Id = listaProdaje.Count + 1,
            //            NamestajZaProdaju = new List<Namestaj>(),
            //            DatumProdaje = this.dDatumProdaje.SelectedDate.Value,
            //            BrojRacuna = this.tbBrojRacuna.Text,
            //            Kupac = (String)cbKupac.SelectedItem,
            //            DodatnaUsluga = new List<DodatnaUsluga>()
            //        };
            //        listaProdaje.Add(novaProdaja);
            //        break;
            //    case Operacija.IZMENA:
            //        break;
            //    default:
            //        break;
            //}
        }

    }
}
