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
    /// Interaction logic for TipNamestajaWindow.xaml
    /// </summary>
    public partial class TipNamestajaWindow : Window
    {
        public TipNamestaja IzabraniTip { get; set; }
        public TipNamestajaWindow()
        {
            InitializeComponent();
            dgTipNamestaja.IsSynchronizedWithCurrentItem = true;
            dgTipNamestaja.DataContext = this;
            dgTipNamestaja.ItemsSource = Projekat.Instance.TipNamestaja;

        }


        private void DodajTip_Click(object sender, RoutedEventArgs e)
        {
            var noviTip = new TipNamestaja()
            {
                Naziv = ""
            };

            var tipProzor = new DodavanjeIzmenaTipaNamestaja(noviTip, DodavanjeIzmenaTipaNamestaja.Operacija.DODAVANJE);
            tipProzor.ShowDialog();

        }

        private void IzmeniTip_Click(object sender, RoutedEventArgs e)
        {
            TipNamestaja kopija = (TipNamestaja)IzabraniTip.Clone();

            var tipProzor = new DodavanjeIzmenaTipaNamestaja(kopija, DodavanjeIzmenaTipaNamestaja.Operacija.IZMENA);
            tipProzor.ShowDialog();

        }


        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Izbrisi_Clik(object sender, RoutedEventArgs e)
        {
            var izabraniTip = (TipNamestaja)dgTipNamestaja.SelectedItem;
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

                GenericSerializer.Serialize("tipoviNamestaja.xml", listaTipa);
            }
        }
    }
}
