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
    /// Interaction logic for DodavanjeIzmenaKorisnika.xaml
    /// </summary>
    public partial class DodavanjeIzmenaKorisnika : Window
    {
        public DodavanjeIzmenaKorisnika()
        {
            InitializeComponent();
        }

        public enum Operacija
        {
            DODAVANJE,
            IZMENA,
            IZBRISI
        };

        public DodavanjeIzmenaKorisnika(Korisnik korisnik, Operacija operacija)
        {

            InitializeComponent();

            InicijalizujVrednosti(korisnik, operacija);
        }
        private void InicijalizujVrednosti(Korisnik korisnik, Operacija operacija)
        {
            this.korisnik = korisnik;
            this.operacija = operacija;

            this.tbIme.Text = korisnik.Ime;
            this.tbPrezime.Text = korisnik.Prezime;
            this.tbKoriIme.Text = korisnik.KorisnickoIme;
            this.tbLozinka.Text = korisnik.Lozinka;

            foreach (var tipKorisnika in Projekat.Instance.Korisnik)
            {
                cbTipKorisnika.Items.Add(tipKorisnika);
            }
            /*
            foreach (Korisnik tipKorisnika in cbTipKorisnika.Items)
            {
                if (tipKorisnika.Id == tipKorisnika)
                {
                    cbTipKorisnika.SelectedItem = tipKorisnika;
                    break;
                }
            }
            */
        }

        private Korisnik korisnik;
        private Operacija operacija;

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaKorisnika = Projekat.Instance.Korisnik;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var noviKorisnik = new Korisnik()
                    {
                        Id = listaKorisnika.Count + 1,
                        Ime = this.tbIme.Text,
                        Prezime = this.tbPrezime.Text,
                        KorisnickoIme = this.tbKoriIme.Text,
                        Lozinka = this.tbLozinka.Text,
                        //TipKorisnika = Enum.Parse(tbTipKori.Text)
                    };
                    listaKorisnika.Add(noviKorisnik);
                    break;

                case Operacija.IZMENA:
                    foreach (var k in listaKorisnika)
                    {
                        if (k.Id == korisnik.Id)
                        {
                            k.Ime = this.tbIme.Text;
                            k.Prezime = this.tbPrezime.Text;
                            k.KorisnickoIme = this.tbKoriIme.Text;
                            k.Lozinka = this.tbLozinka.Text;
                            //k.TipKorisnika = this.tbTipKori.Text;
                            break;
                        }
                    }
                    break;
                case Operacija.IZBRISI:
                    break;
                default:
                    break;
            }

            Projekat.Instance.Korisnik = listaKorisnika;

            Close();
        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
