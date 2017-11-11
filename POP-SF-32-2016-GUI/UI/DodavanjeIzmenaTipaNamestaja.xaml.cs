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
    /// Interaction logic for DodavanjeIzmenaTipaNamestaja.xaml
    /// </summary>
    public partial class DodavanjeIzmenaTipaNamestaja : Window
    {
        public DodavanjeIzmenaTipaNamestaja()
        {
            InitializeComponent();
        }

        public enum Operacija
        {
            DODAVANJE,
            IZMENA,
            IZBRISI
        };

        public DodavanjeIzmenaTipaNamestaja(TipNamestaja tipNamestaja, Operacija operacija)
        {

            InitializeComponent();

            InicijalizujVrednosti(tipNamestaja, operacija);
        }
        private void InicijalizujVrednosti(TipNamestaja tipNamestaja, Operacija operacija)
        {
            this.tipNamestaja = tipNamestaja;
            this.operacija = operacija;

            this.tbNaziv.Text = tipNamestaja.Naziv;
        }

        private TipNamestaja tipNamestaja;
        private Operacija operacija;

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaTipa = Projekat.Instance.TipNamestaja;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var noviTip = new TipNamestaja()
                    {
                        Id = listaTipa.Count + 1,
                        Naziv = this.tbNaziv.Text

                    };
                    listaTipa.Add(noviTip);
                    break;

                case Operacija.IZMENA:
                    foreach (var t in listaTipa)
                    {
                        if (t.Id == tipNamestaja.Id)
                        {
                            t.Naziv = this.tbNaziv.Text;
                            break;
                        }
                    }

                    break;
                case Operacija.IZBRISI:
                    break;
                default:
                    break;
            }

            Projekat.Instance.TipNamestaja = listaTipa;

            Close();
        }

        
        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
