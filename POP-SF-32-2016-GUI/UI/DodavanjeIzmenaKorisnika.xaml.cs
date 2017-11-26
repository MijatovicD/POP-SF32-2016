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
    /// Interaction logic for DodavanjeIzmenaKorisnika.xaml
    /// </summary>
    public partial class DodavanjeIzmenaKorisnika : Window
    {

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        public DodavanjeIzmenaKorisnika(Korisnik korisnik, Operacija operacija)
        {

            InitializeComponent();

            this.korisnik = korisnik;
            this.operacija = operacija;

            cbTipKorisnika.Items.Add("Administrator");
            cbTipKorisnika.Items.Add("Prodavac");

            tbIme.DataContext = korisnik;
            tbPrezime.DataContext = korisnik;
            tbKoriIme.DataContext = korisnik;
            tbLozinka.DataContext = korisnik;
            cbTipKorisnika.DataContext = korisnik;
        }

        private Korisnik korisnik;
        private Operacija operacija;

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaKorisnika = Projekat.Instance.Korisnik;
            var izabraniTip = (TipKorisnika)cbTipKorisnika.SelectedItem;

            switch (operacija)
            {
                case Operacija.DODAVANJE:

                    korisnik.Id = listaKorisnika.Count + 1;
                    korisnik.Ime = tbIme.Text;
                    korisnik.Prezime = tbPrezime.Text;
                    korisnik.KorisnickoIme = tbKoriIme.Text;
                    korisnik.Lozinka = tbLozinka.Password;
                    korisnik.TipKorisnika = izabraniTip;
                    
                    listaKorisnika.Add(korisnik);
                    break;

                case Operacija.IZMENA:
                    foreach (var k in listaKorisnika)
                    {
                        if (k.Id == korisnik.Id)
                        {
                            k.Ime = this.tbIme.Text;
                            k.Prezime = this.tbPrezime.Text;
                            k.KorisnickoIme = this.tbKoriIme.Text;
                            k.Lozinka = this.tbLozinka.Password;
                            k.TipKorisnika = korisnik.TipKorisnika;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }

            GenericSerializer.Serialize("korisnik.xml", listaKorisnika);

            Close();
        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
