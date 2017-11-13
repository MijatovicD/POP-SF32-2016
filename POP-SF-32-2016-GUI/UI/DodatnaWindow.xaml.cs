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

        private void DodajUslugu_Click(object sender, RoutedEventArgs e)
        {
            var novaUsluga = new DodatnaUsluga()
            {
                Naziv = "",
                Cena = 0
            };

            var uslugaProzor = new DodavanjeIzmenaUsluge(novaUsluga, DodavanjeIzmenaUsluge.Operacija.DODAVANJE);
            uslugaProzor.ShowDialog();

            OsveziPrikaz();
        }

        private void IzmeniUslugu_Click(object sender, RoutedEventArgs e)
        {
            var izabranaUsluga = (DodatnaUsluga)lbUsluga.SelectedItem;

            var uslugaProzor = new DodavanjeIzmenaUsluge(izabranaUsluga, DodavanjeIzmenaUsluge.Operacija.IZMENA);
            uslugaProzor.ShowDialog();

            OsveziPrikaz();

        }

        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OsveziPrikaz()
        {
            lbUsluga.Items.Clear();

            foreach (var usluga in Projekat.Instance.DodatnaUsluga)
            {
                if (usluga.Obrisan == false)
                {
                    lbUsluga.Items.Add(usluga);
                }
            }

            lbUsluga.SelectedIndex = 0;
        }

        private void Izbrsi_Click(object sender, RoutedEventArgs e)
        {

            var izabranaUsluga = (DodatnaUsluga)lbUsluga.SelectedItem;
            var listaUsluga = Projekat.Instance.DodatnaUsluga;
            if (MessageBox.Show($"Da li zelite da obrisete: {izabranaUsluga.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var usluga in listaUsluga)
                {
                    if (usluga.Id == izabranaUsluga.Id)
                    {
                        usluga.Obrisan = true;
                    }
                }

                Projekat.Instance.DodatnaUsluga = listaUsluga;

                OsveziPrikaz();
            }
        }
    }
}
