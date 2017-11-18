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
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijaWindow : Window
    {
        public AkcijaWindow()
        {
            InitializeComponent();
            OsveziPrikaz();
        }

        private void OsveziPrikaz()
        {
            lbAkcija.Items.Clear();

            foreach (var akcija in Projekat.Instance.AkcijskaProdaja)
            {
                if (akcija.Obrisan == false)
                {
                    lbAkcija.Items.Add(akcija);
                }
            }

            lbAkcija.SelectedIndex = 0;
        }

        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DodajAkciju_Click(object sender, RoutedEventArgs e)
        {
            var novaAkcija = new AkcijskaProdaja()
            {
                DatumPocetka = DateTime.Today,
                Popust = 0,
                DatumZavrsetka = DateTime.Today
            };

            var akcijaProzor = new DodavanjeIzmenaAkcije(novaAkcija, DodavanjeIzmenaAkcije.Operacija.DODAVANJE);
            akcijaProzor.ShowDialog();
            OsveziPrikaz();
        }

        private void IzmeniAkciju_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ObrsiAkciju_Click(object sender, RoutedEventArgs e)
        {
            var izabranaAkcija = (AkcijskaProdaja)lbAkcija.SelectedItem;
            var listaAkcija = Projekat.Instance.AkcijskaProdaja;
            if (MessageBox.Show($"Da li zelite da obrisete: {izabranaAkcija.Id}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var akcija in listaAkcija)
                {
                    if (akcija.Id == izabranaAkcija.Id)
                    {
                        akcija.Obrisan = true;
                    }
                }

                Projekat.Instance.AkcijskaProdaja = listaAkcija;

                OsveziPrikaz();
            }
        }
    }
}
