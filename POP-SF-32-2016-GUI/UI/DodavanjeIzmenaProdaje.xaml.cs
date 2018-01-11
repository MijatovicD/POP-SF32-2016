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


            dDatumProdaje.DataContext = prodajaNamestaja;
            tbKupac.DataContext = prodajaNamestaja;
            dgNamestajP.ItemsSource = prodajaNamestaja.StavkaNamestaja;
            dgNamestajP.DataContext = prodajaNamestaja.StavkaNamestaja;
            dgNamestajP.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgUslugaP.ItemsSource = prodajaNamestaja.StavkaUsluge;
            dgUslugaP.DataContext = prodajaNamestaja.StavkaNamestaja;
            dgUslugaP.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            lbCena.DataContext = prodajaNamestaja.UkupanIznos;
        }

        private ProdajaNamestaja prodajaNamestaja;
        private Operacija operacija;

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaProdaje = Projekat.Instance.ProdajeNamestaja;
             
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    prodajaNamestaja.BrojRacuna = listaProdaje.Count + 1;
                    ProdajaNamestaja.Create(prodajaNamestaja);

                    break;
                case Operacija.IZMENA:

                    ProdajaNamestaja.Update(prodajaNamestaja);

                    break;
                default:
                    break;
            }


            Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var novaProdaje = new StavkaNamestaja()
            {
                NamestajId = 0,
                KolicinaNamestaja = 0
            };

            NamestajZaProdaju prodaja = new NamestajZaProdaju(novaProdaje, NamestajZaProdaju.Operacija.DODAVANJE);
            prodaja.Show();
            prodaja.Closed += NamestajDodaj; 
        }

        private void NamestajDodaj(object sender, EventArgs e)
        {
            var namestaj = sender as NamestajZaProdaju;
            
            prodajaNamestaja.StavkaNamestaja.Add((namestaj).StavkaNamestaja);
        }

        private void IzbrisiNamestaj(object sender, RoutedEventArgs e)
        {
            prodajaNamestaja.StavkaNamestaja.Remove(dgNamestajP.SelectedItem as StavkaNamestaja);
        }

        private void Dodaj_Uslugu(object sender, RoutedEventArgs e)
        {
            var stavkaUsluge = new StavkaUsluge()
            {
                UslugaId = 0
            };

            UslugaZaProdaju usluga = new UslugaZaProdaju(stavkaUsluge, UslugaZaProdaju.Operacija.DODAVANJE);
            usluga.Show();
            usluga.Closed += DodajUslugu; 
        }

        private void DodajUslugu(object sender, EventArgs e)
        {
            var usluga = sender as UslugaZaProdaju;

            prodajaNamestaja.StavkaUsluge.Add((usluga).StavkaUsluge);
        }

        private void IzbrisiUslugu(object sender, RoutedEventArgs e)
        {
            prodajaNamestaja.StavkaUsluge.Remove(dgUslugaP.SelectedItem as StavkaUsluge);
        }

        private void dgNamestajP_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "NamestajId")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "IdProdaje")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "prodajaNamestaja")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "Error")
            {
                e.Cancel = true;
            }
        }

        private void dgUslugaP_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "UslugaId")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "IdProdaje")
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
