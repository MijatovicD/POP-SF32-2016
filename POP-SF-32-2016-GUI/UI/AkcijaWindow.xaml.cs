using POP_SF32_2016.Model;
using POP_SF32_2016.Until;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        ICollectionView vieew;
        public AkcijskaProdaja IzabranaAkcija { get; set; }
        public AkcijaWindow()
        {
            InitializeComponent();
            vieew = CollectionViewSource.GetDefaultView(Projekat.Instance.AkcijskeProdaje);
            dgAkcija.IsSynchronizedWithCurrentItem = true;
            dgAkcija.DataContext = this;
            dgAkcija.ItemsSource = vieew;

            dgAkcija.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            cbSortiraj.Items.Add("DatumPocetka");
            cbSortiraj.Items.Add("Popust");
            cbSortiraj.Items.Add("DatumZavrsetka");

            vieew.Filter = AkcijaFilter;
        }

        
        private bool AkcijaFilter(object obj)
        {
            var listaAkcija = Projekat.Instance.AkcijskeProdaje;
            foreach (var akcija in listaAkcija)
            {
                if (akcija.DatumPocetka < DateTime.Today && akcija.DatumZavrsetka < DateTime.Today)
                {
                    akcija.Obrisan = true;

                }
            }
            return ((AkcijskaProdaja)obj).Obrisan == false;
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
                DatumZavrsetka = DateTime.Today,
                Naziv = "",
                NamestajId = 0
            };

            var akcijaProzor = new DodavanjeIzmenaAkcije(novaAkcija, DodavanjeIzmenaAkcije.Operacija.DODAVANJE);
            akcijaProzor.ShowDialog();
       
        }

        private void IzmeniAkciju_Click(object sender, RoutedEventArgs e)
        {
            AkcijskaProdaja kopija = (AkcijskaProdaja)IzabranaAkcija.Clone();

            var akcijaProzor = new DodavanjeIzmenaAkcije(kopija, DodavanjeIzmenaAkcije.Operacija.IZMENA);
            akcijaProzor.ShowDialog();
       
        }

        private void ObrsiAkciju_Click(object sender, RoutedEventArgs e)
        {
            var izabranaAkcija = (AkcijskaProdaja)dgAkcija.SelectedItem;
            var listaAkcija = Projekat.Instance.AkcijskeProdaje;
            var listaNamestaja = Projekat.Instance.Namestaji;
            if (MessageBox.Show($"Da li zelite da obrisete: {izabranaAkcija.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var akcija in listaAkcija)
                {
                    if (akcija.Id == izabranaAkcija.Id)
                    {
                        AkcijskaProdaja.Delete(izabranaAkcija);
                        vieew.Filter = AkcijaFilter;
                       
                          foreach (var namestaj in listaNamestaja)
                          {
                               if (izabranaAkcija.Id == namestaj.AkcijaId)
                               {
                                    namestaj.AkcijaId = 1;
                                    Namestaj.Update(namestaj);
                               }
                          }
                           
                    }
                }

          
            }
        }

        private void cbSortiraj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cbSortiraj.SelectedIndex == 0)
            {
                dgAkcija.Items.SortDescriptions.Clear();
                dgAkcija.Items.SortDescriptions.Add(new SortDescription("DatumPocetka", ListSortDirection.Descending));
            }

            else if (cbSortiraj.SelectedIndex == 1)
            {
                dgAkcija.Items.SortDescriptions.Clear();
                dgAkcija.Items.SortDescriptions.Add(new SortDescription("Popust", ListSortDirection.Descending));
            }

            else if (cbSortiraj.SelectedIndex == 2)
            {
                dgAkcija.Items.SortDescriptions.Clear();
                dgAkcija.Items.SortDescriptions.Add(new SortDescription("DatumZavrsetka", ListSortDirection.Descending));
            }
        }

        private void dgAkcija_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "NamestajId")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "Error")
            {
                e.Cancel = true;
            }
        }

        private void Akcija_broj(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();


                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = ("SELECT * FROM AkcijskaProdaja WHERE Obrisan=0 AND DatumPocetka LIKE'" + tbPretraga.Text + "%'" + "OR Naziv LIKE'" + tbPretraga.Text + "%'");
                da.SelectCommand = cmd;
                da.Fill(ds, "AkcijskaProdaja");

                dgAkcija.ItemsSource = ds.Tables[0].DefaultView;
            }
        }
    }
}
