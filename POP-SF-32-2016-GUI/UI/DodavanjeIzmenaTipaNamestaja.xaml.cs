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
    /// Interaction logic for DodavanjeIzmenaTipaNamestaja.xaml
    /// </summary>
    public partial class DodavanjeIzmenaTipaNamestaja : Window
    {

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        public DodavanjeIzmenaTipaNamestaja(TipNamestaja tipNamestaja, Operacija operacija)
        {

            InitializeComponent();

            this.tipNamestaja = tipNamestaja;
            this.operacija = operacija;

            tbNaziv.DataContext = tipNamestaja;
        }
  
        private TipNamestaja tipNamestaja;
        private Operacija operacija;

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaTipa = Projekat.Instance.TipoviNamestaja;

            switch (operacija)
            {
                case Operacija.DODAVANJE:

                    //tipNamestaja.Id = listaTipa.Count + 1;
                    //tipNamestaja.Naziv = tbNaziv.Text;

                    TipNamestaja.Create(tipNamestaja);
                    break;

                case Operacija.IZMENA:

                    TipNamestaja.Update(tipNamestaja);
                    break;
                default:
                    break;
            }

            //GenericSerializer.Serialize("tipoviNamestaja.xml", listaTipa);

            Close();
        }

        
        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
