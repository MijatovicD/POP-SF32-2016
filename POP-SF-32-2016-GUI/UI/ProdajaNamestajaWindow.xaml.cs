﻿using POP_SF_32_2016_GUI.Model;
using POP_SF32_2016.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for ProdajaNamestajaWindow.xaml
    /// </summary>
    public partial class ProdajaNamestajaWindow : Window
    {
        ICollectionView vieew;
        public ProdajaNamestaja IzabranaProdaja { get; set; }
        public ProdajaNamestajaWindow()
        {
            InitializeComponent();
            vieew = CollectionViewSource.GetDefaultView(Projekat.Instance.ProdajeNamestaja);
            dgProdaja.IsSynchronizedWithCurrentItem = true;
            dgProdaja.DataContext = this;
            dgProdaja.ItemsSource = vieew;
           

            dgProdaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            cbSortiraj.Items.Add("DatumProdaje");
            cbSortiraj.Items.Add("BrojuRacuna");
            cbSortiraj.Items.Add("Kupac");

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgProdaja.ItemsSource);
            view.Filter = Pretraga;
        }

        private void DodajProdaju_Click(object sender, RoutedEventArgs e)
        {
            var novaProdaja = new ProdajaNamestaja()
            {

                DatumProdaje = DateTime.Today,
                BrojRacuna = 0,
                Kupac = "",
                UkupanIznos = 0,
                StavkaNamestaja = new ObservableCollection<StavkaNamestaja>()
            };

            var prodajaNamestajaProzor = new DodavanjeIzmenaProdaje(novaProdaja, DodavanjeIzmenaProdaje.Operacija.DODAVANJE);
            prodajaNamestajaProzor.ShowDialog();
            

        }

        private void IzmeniProdaju_Click(object sender, RoutedEventArgs e)
        {
            ProdajaNamestaja kopija = (ProdajaNamestaja)IzabranaProdaja.Clone();
            
            var prodajaProzor = new DodavanjeIzmenaProdaje(kopija, DodavanjeIzmenaProdaje.Operacija.IZMENA);
            prodajaProzor.ShowDialog();

        }


        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool Pretraga(object item)
        {

            if (String.IsNullOrEmpty(tbPretraga.Text))
            {
                return true;
            }

            else
            {
                return ((item as ProdajaNamestaja).Kupac.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgProdaja.ItemsSource).Refresh();
        }

        private void cbSortiraj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cbSortiraj.SelectedIndex == 0)
            {
                dgProdaja.Items.SortDescriptions.Clear();
                dgProdaja.Items.SortDescriptions.Add(new SortDescription("DatumProdaje", ListSortDirection.Descending));
            }

            else if (cbSortiraj.SelectedIndex == 1)
            {
                dgProdaja.Items.SortDescriptions.Clear();
                dgProdaja.Items.SortDescriptions.Add(new SortDescription("BrojRacuna", ListSortDirection.Descending));
            }

            else if (cbSortiraj.SelectedIndex == 2)
            {
                dgProdaja.Items.SortDescriptions.Clear();
                dgProdaja.Items.SortDescriptions.Add(new SortDescription("Kupac", ListSortDirection.Descending));
            }
        }

        private void dgProdaja_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "NamestajId")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "DodatnaUslugaId")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "StavkaNamestaja")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "StavkaUsluge")
            {
                e.Cancel = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Racun racun = new Racun();
            racun.ShowDialog();
        }
    }
}
