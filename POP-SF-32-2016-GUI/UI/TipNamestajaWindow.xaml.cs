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
    /// Interaction logic for TipNamestajaWindow.xaml
    /// </summary>
    public partial class TipNamestajaWindow : Window
    {
        public TipNamestajaWindow()
        {
            InitializeComponent();

            OsveziPrikaz();

        }


        private void DodajTip_Click(object sender, RoutedEventArgs e)
        {
            var noviTip = new TipNamestaja()
            {
                Naziv = ""
            };

            var tipProzor = new DodavanjeIzmenaTipaNamestaja(noviTip, DodavanjeIzmenaTipaNamestaja.Operacija.DODAVANJE);
            tipProzor.ShowDialog();

            OsveziPrikaz();
        }

        private void IzmeniTip_Click(object sender, RoutedEventArgs e)
        {
            var izabraniTip = (TipNamestaja)lbTipNamestaja.SelectedItem;

            var tipProzor = new DodavanjeIzmenaTipaNamestaja(izabraniTip, DodavanjeIzmenaTipaNamestaja.Operacija.IZMENA);
            tipProzor.ShowDialog();

            OsveziPrikaz();

        }

        private void OsveziPrikaz()
        {
            lbTipNamestaja.Items.Clear();

            foreach (var tip in Projekat.Instance.TipNamestaja)
            {
                if (tip.Obrisan == false)
                {
                    lbTipNamestaja.Items.Add(tip);
                }
            }

            lbTipNamestaja.SelectedIndex = 0;
        }

        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Izbrisi_Clik(object sender, RoutedEventArgs e)
        {
            var izabraniTip = (TipNamestaja)lbTipNamestaja.SelectedItem;
            var listaTipa = Projekat.Instance.TipNamestaja;
            if (MessageBox.Show($"Da li zelite da obrisete: {izabraniTip.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var tip in listaTipa)
                {
                    if (tip.Id == izabraniTip.Id)
                    {
                        tip.Obrisan = true;
                    }
                }

                Projekat.Instance.TipNamestaja = listaTipa;

                OsveziPrikaz();
            }
        }
    }
}
