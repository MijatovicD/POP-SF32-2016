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

            WindowState = WindowState.Maximized;

            this.prodajaNamestaja = prodajaNamestaja;
            this.operacija = operacija;

            //dgNamestajP.ItemsSource = Projekat.Instance.StavkaProdaje;

            dDatumProdaje.DataContext = prodajaNamestaja;
            lbCena.DataContext = prodajaNamestaja;
            tbBrojRacuna.DataContext = prodajaNamestaja;
            tbKupac.DataContext = prodajaNamestaja;
            dgNamestajP.ItemsSource = prodajaNamestaja.StavkaProdaje;
            dgNamestajP.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgUslugaP.ItemsSource = Projekat.Instance.DodatnaUsluga;
        }
        
        private ProdajaNamestaja prodajaNamestaja;
        private Operacija operacija;


        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaProdaje = Projekat.Instance.ProdajaNamestaja;
            var izabranaUsluga = (DodatnaUsluga)dgUslugaP.SelectedItem;
            var izabraniNamestaj = (StavkaProdaje)dgNamestajP.SelectedItem;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                   
                    prodajaNamestaja.Id = listaProdaje.Count + 1;
                    prodajaNamestaja.StavkaProdaje = new ObservableCollection<StavkaProdaje>();
                    prodajaNamestaja.DatumProdaje = dDatumProdaje.SelectedDate.Value;
                    prodajaNamestaja.BrojRacuna = tbBrojRacuna.Text;
                    prodajaNamestaja.Kupac = tbKupac.Text;
                    prodajaNamestaja.DodatnaUslugaId = izabranaUsluga.Id;
                    prodajaNamestaja.UkupanIznos = prodajaNamestaja.PDV * izabranaUsluga.Cena;

                    listaProdaje.Add(prodajaNamestaja);
                    break;
                case Operacija.IZMENA:
                    foreach (var p in listaProdaje)
                    {
                        if (p.Id == prodajaNamestaja.Id)
                        {
                            p.StavkaProdaje = prodajaNamestaja.StavkaProdaje;
                            p.BrojRacuna = prodajaNamestaja.BrojRacuna;
                            p.Kupac = prodajaNamestaja.Kupac;
                            p.DodatnaUslugaId = prodajaNamestaja.DodatnaUslugaId;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }

            GenericSerializer.Serialize("prodajaNamestaja.xml", listaProdaje);


            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var novaProdaje = new StavkaProdaje()
            {
                NamestajId = 0,
                KolicinaNamestaja = 0
            };

            var prozor = new NamestajZaProdaju(novaProdaje, NamestajZaProdaju.Operacija.DODAVANJE);
            prozor.ShowDialog();
            
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
        }
    }
}
