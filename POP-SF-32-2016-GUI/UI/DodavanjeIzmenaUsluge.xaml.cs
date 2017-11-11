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
    /// Interaction logic for DodavanjeIzmenaUsluge.xaml
    /// </summary>
    public partial class DodavanjeIzmenaUsluge : Window
    {
        public DodavanjeIzmenaUsluge()
        {
            InitializeComponent();
        }


        public enum Operacija
        {
            DODAVANJE,
            IZMENA,
            IZBRISI
        };

        public DodavanjeIzmenaUsluge(DodatnaUsluga dodatnaUsluga, Operacija operacija)
        {
            InitializeComponent();

            InicijalizujVrednosti(dodatnaUsluga, operacija);
        }
        private void InicijalizujVrednosti(DodatnaUsluga dodatnaUsluga, Operacija operacija)
        {
            this.dodatnaUsluga = dodatnaUsluga;
            this.operacija = operacija;

            this.tbNaziv.Text = dodatnaUsluga.Naziv;
            this.tbCena.Text = System.Convert.ToString(dodatnaUsluga.Cena);
        }

        private DodatnaUsluga dodatnaUsluga;
        private Operacija operacija;

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listausluge = Projekat.Instance.DodatnaUsluga;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var novaUsluge = new DodatnaUsluga()
                    {
                        Id = listausluge.Count + 1,
                        Naziv = this.tbNaziv.Text,
                        Cena = double.Parse(tbCena.Text)

                    };
                    listausluge.Add(novaUsluge);
                    break;

                case Operacija.IZMENA:
                    foreach (var usluga in listausluge)
                    {
                        if (usluga.Id == dodatnaUsluga.Id)
                        {
                            usluga.Naziv = this.tbNaziv.Text;
                            usluga.Cena = double.Parse(tbCena.Text);
                            break;
                        }
                    }
                    break;
                case Operacija.IZBRISI:
                    break;
                default:
                    break;
            }

            Projekat.Instance.DodatnaUsluga = listausluge;
            Close();
        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
