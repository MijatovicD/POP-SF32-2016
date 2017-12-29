using POP_SF_32_2016_GUI.Model;
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
    /// Interaction logic for UslugaZaProdaju.xaml
    /// </summary>
    public partial class UslugaZaProdaju : Window
    {
        public StavkaUsluge StavkaUsluge { get; set; }
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        public UslugaZaProdaju(StavkaUsluge stavkaUsluge, Operacija operacija)
        {
            InitializeComponent();

            this.stavkaUsluge = stavkaUsluge;
            this.operacija = operacija;

            dgUsluga.ItemsSource = Projekat.Instance.DodatnaUsluge;
            dgUsluga.DataContext = stavkaUsluge;

            this.DataContext = StavkaUsluge;
        }

        private StavkaUsluge stavkaUsluge;
        private Operacija operacija;

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    
                    StavkaUsluge.Create(stavkaUsluge);
                    break;
                case Operacija.IZMENA:
                    break;
                default:
                    break;
            }

            Close();
        }

        private void dgUsluga_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }
    }
}
