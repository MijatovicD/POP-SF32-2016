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
    /// Interaction logic for DodavanjeIzmenaUsluge.xaml
    /// </summary>
    public partial class DodavanjeIzmenaUsluge : Window
    {
 
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        public DodavanjeIzmenaUsluge(DodatnaUsluga dodatnaUsluga, Operacija operacija)
        {
            InitializeComponent();

            this.dodatnaUsluga = dodatnaUsluga;
            this.operacija = operacija;

            tbNaziv.DataContext = dodatnaUsluga;
            tbCena.DataContext = dodatnaUsluga;
        }


        private DodatnaUsluga dodatnaUsluga;
        private Operacija operacija;

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listausluge = Projekat.Instance.DodatnaUsluge;

            switch (operacija)
            {
                case Operacija.DODAVANJE:

                    DodatnaUsluga.Create(dodatnaUsluga);
                    break;

                case Operacija.IZMENA:

                    DodatnaUsluga.Update(dodatnaUsluga);
                    break;
                default:
                    break;
            }

            //GenericSerializer.Serialize("dodatnaUslga.xml", listausluge);
            Close();
        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
