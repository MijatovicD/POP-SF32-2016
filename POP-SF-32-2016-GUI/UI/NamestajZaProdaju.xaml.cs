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
    /// Interaction logic for NamestajZaProdaju.xaml
    /// </summary>
    public partial class NamestajZaProdaju : Window
    {

        public ObservableCollection<Namestaj> IzabraniNamestaj { get; set; }
        public StavkaNamestaja StavkaNamestaja { get; set; }
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };
        public NamestajZaProdaju(StavkaNamestaja stavkaNamestaja, Operacija operacija)
        {

            InitializeComponent();
          
            this.stavkaNamestaja = stavkaNamestaja;
            this.operacija = operacija;

            dgNamestajProdaja.ItemsSource = Projekat.Instance.Namestaji;
            tbKolicina.DataContext = stavkaNamestaja;
            dgNamestajProdaja.DataContext = stavkaNamestaja;

            dgNamestajProdaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            this.DataContext = StavkaNamestaja;
        }

        private StavkaNamestaja stavkaNamestaja;
        private Operacija operacija;

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaNamestaja = Projekat.Instance.Namestaji;
            var izabraniNamestaj = (Namestaj)dgNamestajProdaja.SelectedItem;

            switch (operacija)
            {
                case Operacija.DODAVANJE:


                    if (int.Parse(tbKolicina.Text) > izabraniNamestaj.KolicinaUMagacinu || int.Parse(tbKolicina.Text) == 0 || int.Parse(tbKolicina.Text) < 0)
                    {
                        MessageBox.Show("Kolicina mora biti manja", "Greska");
                    }
                    else
                    {
                        izabraniNamestaj.KolicinaUMagacinu = izabraniNamestaj.KolicinaUMagacinu - int.Parse(tbKolicina.Text);
                        StavkaNamestaja.Create(stavkaNamestaja);
                        Namestaj.Update(izabraniNamestaj);
                    }

                    
                    break;

                //case Operacija.IZMENA:
                //    foreach (var s in listastavki)
                //    {
                //        if (s.Id == stavkaProdaje.Id)
                //        {
                //            s.NamestajId = stavkaProdaje.NamestajId;
                //            break;
                //        }
                //    }

                //break;
                default:
                    break;
            }

            //GenericSerializer.Serialize("stavkaProdaje.xml", listastavki);

            Close();
        }


        private void dgNamestajProdaja_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "NamestajId")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "TipNamestajaId")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "AkcijaId")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }

 

        //private void tbKolicina_TextInput(object sender, TextCompositionEventArgs e)
        //{
        //    var listaNamestaja = Projekat.Instance.Namestaji;
        //    var izabraniNamestaj = (Namestaj)dgNamestajProdaja.SelectedItem;


            


        //        if (int.Parse(tbKolicina.Text) < izabraniNamestaj.KolicinaUMagacinu)
        //        {
        //            izabraniNamestaj.KolicinaUMagacinu = izabraniNamestaj.KolicinaUMagacinu - int.Parse(tbKolicina.Text);
        //        }

        //        Namestaj.Update(izabraniNamestaj);
        //        //if (int.Parse(tbKolicina.Text) < namestaj.KolicinaUMagacinu)
        //        //{
        //        //    namestaj.KolicinaUMagacinu = namestaj.KolicinaUMagacinu - int.Parse(tbKolicina.Text);
        //        //}
            
        //}
    }
}
