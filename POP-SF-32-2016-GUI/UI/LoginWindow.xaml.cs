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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        public enum TipKorisnika
        {
            Administrator,
            Prodavac
        }

        private TipKorisnika tipKorisnika;

        private void btPrijava_Click(object sender, RoutedEventArgs e)
        {
            var listaKorisnika = Projekat.Instance.Korisnici;
                    
            foreach (var korisnik in listaKorisnika)
            {
                if (tbKoriIme.Text.Equals(korisnik.KorisnickoIme) && tbLozinka.Password.Equals(korisnik.Lozinka))
                {
                    tipKorisnika = (TipKorisnika)korisnik.TipKorisnika;

                    switch (tipKorisnika)
                    {
                        case TipKorisnika.Administrator:
                            MainWindow mw = new MainWindow();
                            mw.Show();
                            this.Close();
                            break;
                        case TipKorisnika.Prodavac:
                            ProdajaNamestajaWindow pn = new ProdajaNamestajaWindow();
                            pn.Show();
                            this.Close();
                            break;
                        default:
                            break;
                    }
                }
                if (tbKoriIme.Text.Equals("") || tbLozinka.Password.Equals(""))
                {
                    MessageBox.Show("Morate uneti sva polja", "Greska");
                }
        
            }
           
        }
    }
}