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
    /// Interaction logic for IzmenaSalona.xaml
    /// </summary>
    public partial class IzmenaSalona : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        public IzmenaSalona(Salon salon, Operacija operacija)
        {
            InitializeComponent();

            this.salon = salon;
            this.operacija = operacija;

            tbNaziv.DataContext = salon;
            tbAdresa.DataContext = salon;
            tbTelefon.DataContext = salon;
            tbEmail.DataContext = salon;
            tbInternet.DataContext = salon;
            tbPib.DataContext = salon;
            tbMaticni.DataContext = salon;
            tbRacun.DataContext = salon;
        }

        private Salon salon;
        private Operacija operacija;

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaSalon = Projekat.Instance.Salon;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    break;

                case Operacija.IZMENA:
                    foreach (var s in listaSalon)
                    {
                        if (s.Id == salon.Id)
                        {
                            s.Naziv = salon.Naziv;
                            s.Adresa = salon.Adresa;
                            s.Telefon = salon.Telefon;
                            s.Email = salon.Email;
                            s.InternetAdresa = salon.InternetAdresa;
                            s.PIB = salon.PIB;
                            s.MaticniBroj = salon.MaticniBroj;
                            s.ZiroRacun = salon.ZiroRacun;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }

            GenericSerializer.Serialize("salon.xml", listaSalon);

            Close();
        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}