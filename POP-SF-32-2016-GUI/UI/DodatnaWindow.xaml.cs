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
    /// Interaction logic for DodatnaWindow.xaml
    /// </summary>
    public partial class DodatnaWindow : Window
    {
        public DodatnaWindow()
        {
            InitializeComponent();

            OsveziPrikaz();
        }

        private void DodajUslugu(object sender, RoutedEventArgs e)
        {
            var novaUsluga = new DodatnaUsluga()
            {
                Naziv = "",
                Cena = 0
            };

            var uslugaProzor = new DodavanjeIzmenaUsluge(novaUsluga, DodavanjeIzmenaUsluge.Operacija.DODAVANJE);
            uslugaProzor.Show();
        }

        private void IzmeniUslugu(object sender, RoutedEventArgs e)
        {
            var izabranaUsluga = (DodatnaUsluga)lbUsluga.SelectedItem;

            var uslugaProzor = new DodavanjeIzmenaUsluge(izabranaUsluga, DodavanjeIzmenaUsluge.Operacija.IZMENA);
            uslugaProzor.Show();

        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OsveziPrikaz()
        {
            lbUsluga.Items.Clear();

            foreach (var usluga in Projekat.Instance.DodatnaUsluga)
            {
                lbUsluga.Items.Add(usluga);
            }

            lbUsluga.SelectedIndex = 0;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            OsveziPrikaz();
        }
    }
}
