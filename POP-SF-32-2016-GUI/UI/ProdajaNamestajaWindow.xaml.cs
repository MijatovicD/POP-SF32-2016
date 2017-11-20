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
    /// Interaction logic for ProdajaNamestajaWindow.xaml
    /// </summary>
    public partial class ProdajaNamestajaWindow : Window
    {
        public ProdajaNamestajaWindow()
        {
            InitializeComponent();

            OsveziPrikaz();
        }


        private void OsveziPrikaz()
        {
            lbProdaja.Items.Clear();

            foreach (var prodaja in Projekat.Instance.ProdajaNamestaja)
            {
                    lbProdaja.Items.Add(prodaja);

            }            

            lbProdaja.SelectedIndex = 0;
        }

        private void DodajProdaju_Click(object sender, RoutedEventArgs e)
        {
            var novaProdaja = new ProdajaNamestaja()
            {
                NamestajZaProdaju = new List<Namestaj>(),
                DatumProdaje = DateTime.Today,
                BrojRacuna = "",
                Kupac = "",
                DodatnaUsluga = new List<DodatnaUsluga>(),
                UkupanIznos = 0
            };

            var prodajaNamestajaProzor = new DodavanjeIzmenaProdaje(novaProdaja, DodavanjeIzmenaProdaje.Operacija.DODAVANJE);
            prodajaNamestajaProzor.ShowDialog();

            OsveziPrikaz();
        }

        private void IzmeniProdaju_Click(object sender, RoutedEventArgs e)
        {
            var izabranaProdaja = (ProdajaNamestaja)lbProdaja.SelectedItem;

            var prodajaProzor = new DodavanjeIzmenaProdaje(izabranaProdaja, DodavanjeIzmenaProdaje.Operacija.IZMENA);
            prodajaProzor.ShowDialog();

            OsveziPrikaz();
        }


        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
