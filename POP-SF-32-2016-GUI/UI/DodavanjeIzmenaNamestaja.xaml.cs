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

            cbTip.ItemsSource = Projekat.Instance.TipNamestaja;
            cbAkcija.ItemsSource = Projekat.Instance.AkcijskaProdaja;

            tbNaziv.DataContext = namestaj;
            cbTip.DataContext = namestaj;
            cbAkcija.DataContext = namestaj;
        }

        private Namestaj namestaj;
        private Operacija operacija;

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaNamestaja = Projekat.Instance.Namestaj;
            var izabraniTipNamestaja = (TipNamestaja)cbTip.SelectedItem;
            var izabranaAkcija = (AkcijskaProdaja)cbAkcija.SelectedItem;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    namestaj.Id = listaNamestaja.Count + 1;
                   
                        //Id = listaNamestaja.Count + 1,
                        //Naziv = this.tbNaziv.Text,
                        //Sifra = this.tbSifra.Text,
                        //JedinicnaCena = double.Parse(tbCena.Text),
                        //KolicinaUMagacinu = int.Parse(tbKolicina.Text),
                        //AkcijaId = izabranaAkcija.Id,
                        //TipNamestajaId = izabraniTipNamestaja.Id
                    
                    listaNamestaja.Add(namestaj);
                    break;

                case Operacija.IZMENA:
                    foreach (var n in listaNamestaja)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.Naziv = namestaj.Naziv;
                            n.Sifra = namestaj.Sifra;
                            n.JedinicnaCena = namestaj.JedinicnaCena;
                            n.KolicinaUMagacinu = namestaj.KolicinaUMagacinu;
                            n.AkcijaId = namestaj.AkcijaId;
                            n.TipNamestajaId = namestaj.TipNamestajaId;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }

            GenericSerializer.Serialize("namestaj.xml", listaNamestaja);
                
            Close();
        }
 

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
