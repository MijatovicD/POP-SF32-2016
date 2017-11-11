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


        private void DodajTip(object sender, RoutedEventArgs e)
        {
            var noviTip = new TipNamestaja()
            {
                Naziv = ""
            };

            var tipProzor = new DodavanjeIzmenaTipaNamestaja(noviTip, DodavanjeIzmenaTipaNamestaja.Operacija.DODAVANJE);
            tipProzor.Show();
        }

        private void IzmeniTip(object sender, RoutedEventArgs e)
        {
            var izabraniTip = (TipNamestaja)lbTipNamestaja.SelectedItem;

            var tipProzor = new DodavanjeIzmenaTipaNamestaja(izabraniTip, DodavanjeIzmenaTipaNamestaja.Operacija.IZMENA);
            tipProzor.Show();

        }

        private void OsveziPrikaz()
        {
            lbTipNamestaja.Items.Clear();

            foreach (var t in Projekat.Instance.TipNamestaja)
            {
                lbTipNamestaja.Items.Add(t);
            }

            lbTipNamestaja.SelectedIndex = 0;
        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            OsveziPrikaz();
        }
    }
}
