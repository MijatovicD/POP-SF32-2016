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

        public ObservableCollection<StavkaProdaje> IzabranaStavka { get; set; }
        public StavkaProdaje StavkaProdaje { get; set; }
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };
        public NamestajZaProdaju(StavkaProdaje stavkaProdaje, Operacija operacija)
        {

            InitializeComponent();

            this.stavkaProdaje = stavkaProdaje;
            this.operacija = operacija;

            dgNamestajProdaja.ItemsSource = Projekat.Instance.Namestaj;
            tbKolicina.DataContext = stavkaProdaje;
            dgNamestajProdaja.DataContext = stavkaProdaje;

            
        }
    
        private StavkaProdaje stavkaProdaje;
        private Operacija operacija;

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listastavki = Projekat.Instance.StavkaProdaje;
            var izabraniNamestaj = (Namestaj)dgNamestajProdaja.SelectedItem;
            switch (operacija)
            {
                case Operacija.DODAVANJE:

                    stavkaProdaje.Id = listastavki.Count + 1;
                    stavkaProdaje.NamestajId = izabraniNamestaj.Id;
                    stavkaProdaje.KolicinaNamestaja = int.Parse(tbKolicina.Text);


                    listastavki.Add(stavkaProdaje);
                    break;

                case Operacija.IZMENA:
                    foreach (var s in listastavki)
                    {
                        if (s.Id == stavkaProdaje.Id)
                        {
                            s.NamestajId = stavkaProdaje.NamestajId;
                            break;
                        }
                    }

                    break;
                default:
                    break;
            }

            GenericSerializer.Serialize("stavkaProdaje.xml", listastavki);

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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var listaStavke = Projekat.Instance.StavkaProdaje;
            var listaNamestaja = Projekat.Instance.Namestaj;
            var izabraniNamestaj = (Namestaj)dgNamestajProdaja.SelectedItem;

            
                foreach (var namestaj in listaNamestaja)
                {
                    if (int.Parse(tbKolicina.Text) < namestaj.KolicinaUMagacinu)
                    {
                        namestaj.KolicinaUMagacinu = namestaj.KolicinaUMagacinu - int.Parse(tbKolicina.Text);
                    }
                }  
                

            GenericSerializer.Serialize("namestaj.xml", listaNamestaja);
        }
    }
}
