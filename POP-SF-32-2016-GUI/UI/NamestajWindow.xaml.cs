using POP_SF32_2016.Model;
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
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        public NamestajWindow()
        {
            InitializeComponent();

            OsveziPrikaz();

        }

        private void DodajNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = "",
                Sifra = "",
                JedinicnaCena = 0,
                KolicinaUMagacinu = 0,
                AkcijaId = 0,
                TipNamestajaId = 0
            };

            var namestajProzor = new DodavanjeIzmenaNamestaja(noviNamestaj, DodavanjeIzmenaNamestaja.Operacija.DODAVANJE);
            namestajProzor.ShowDialog();
            OsveziPrikaz();
        }

        private void IzmeniNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var izabraniNamestaj = (Namestaj)lbNamestaj.SelectedItem;

            var namestajProzor = new DodavanjeIzmenaNamestaja(izabraniNamestaj, DodavanjeIzmenaNamestaja.Operacija.IZMENA);
            namestajProzor.ShowDialog();
            OsveziPrikaz();

        }


        private void OsveziPrikaz()
        {
            lbNamestaj.Items.Clear();

            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if(namestaj.Obrisan == false)
                {
                    lbNamestaj.Items.Add(namestaj);
                }
            }

            lbNamestaj.SelectedIndex = 0;
        }

        
        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ObrsiNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var izabranNamestaj = (Namestaj)lbNamestaj.SelectedItem;
            var listaNamestaj = Projekat.Instance.Namestaj;
            if (MessageBox.Show($"Da li zelite da obrisete: {izabranNamestaj.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var n in listaNamestaj)
                {
                    if (n.Id == izabranNamestaj.Id)
                    {
                        n.Obrisan = true;
                    }
                }

                Projekat.Instance.Namestaj = listaNamestaj;

                OsveziPrikaz();
            }
        }

    }
}
