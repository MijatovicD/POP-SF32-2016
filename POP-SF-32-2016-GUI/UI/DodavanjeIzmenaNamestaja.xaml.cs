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

                InicijalizujVrednosti(namestaj, operacija);
        }
        private void InicijalizujVrednosti(Namestaj namestaj, Operacija operacija)
        {
                this.namestaj = namestaj;
                this.operacija = operacija;

            this.tbNaziv.Text = namestaj.Naziv;
            this.tbSifra.Text = namestaj.Sifra;
            this.tbCena.Text = System.Convert.ToString(namestaj.JedinicnaCena);
            this.tbKolicina.Text = System.Convert.ToString(namestaj.KolicinaUMagacinu);

            foreach (var akcija in Projekat.Instance.AkcijskaProdaja)
            {
                cbAkcija.Items.Add(akcija);
            }
            foreach (AkcijskaProdaja akcija in cbAkcija.Items)
            {
                if (akcija.Id == akcija.Id)
                {
                    cbAkcija.SelectedItem = akcija;
                    break;
                }
            }


            foreach (var tipNamestaja in Projekat.Instance.TipNamestaja)
            {
                cbTip.Items.Add(tipNamestaja);
            }
            foreach (TipNamestaja tipNamestaja in cbTip.Items)
            {
                if (tipNamestaja.Id == namestaj.TipNamestajaId)
                {
                    cbTip.SelectedItem = tipNamestaja;
                    break;
                }
            }
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
                    var noviNamestaj = new Namestaj()
                    {
                        Id = listaNamestaja.Count + 1,
                        Naziv = this.tbNaziv.Text,
                        Sifra = this.tbSifra.Text,
                        JedinicnaCena = double.Parse(tbCena.Text),
                        KolicinaUMagacinu = int.Parse(tbKolicina.Text),
                        AkcijaId = izabranaAkcija.Id,
                        TipNamestajaId = izabraniTipNamestaja.Id
                    };
                    listaNamestaja.Add(noviNamestaj);
                    break;

                case Operacija.IZMENA:
                    foreach (var n in listaNamestaja)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.Naziv = this.tbNaziv.Text;
                            n.Sifra = this.tbSifra.Text;
                            n.JedinicnaCena = double.Parse(tbCena.Text);
                            n.KolicinaUMagacinu = int.Parse(tbKolicina.Text);
                            n.AkcijaId = izabranaAkcija.Id;
                            n.TipNamestajaId = izabraniTipNamestaja.Id;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }

            Projekat.Instance.Namestaj = listaNamestaja;

            Close();
        }

        /*
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(TipKorisnika)))
            {
                cbTip.Items.Add(item);
            }
        }
        */

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
