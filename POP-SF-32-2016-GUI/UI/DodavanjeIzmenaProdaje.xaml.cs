﻿using POP_SF_32_2016_GUI.Model;
using POP_SF32_2016.Model;
using POP_SF32_2016.Until;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DodavanjeIzmenaProdaje.xaml
    /// </summary>
    public partial class DodavanjeIzmenaProdaje : Window
    {

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        public DodavanjeIzmenaProdaje(ProdajaNamestaja prodajaNamestaja, Operacija operacija)
        {
            InitializeComponent();

            WindowState = WindowState.Maximized;

            this.prodajaNamestaja = prodajaNamestaja;
            this.operacija = operacija;

            //dgNamestajP.ItemsSource = Projekat.Instance.StavkaProdaje;

            dDatumProdaje.DataContext = prodajaNamestaja;
            lbCena.DataContext = prodajaNamestaja;
            tbBrojRacuna.DataContext = prodajaNamestaja;
            tbKupac.DataContext = prodajaNamestaja;
            dgNamestajP.ItemsSource = Projekat.Instance.StavkeNamestaja;
            dgNamestajP.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgUslugaP.ItemsSource = Projekat.Instance.StavkeUsluge;
            dgUslugaP.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

        }
        
        private ProdajaNamestaja prodajaNamestaja;
        private Operacija operacija;


        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {

            switch (operacija)
            {
                case Operacija.DODAVANJE:
              
                    ProdajaNamestaja.Create(prodajaNamestaja);


                    //var listaProdaje = Projekat.Instance.ProdajeNamestaja;

                    //CollectionViewSource cvs = new CollectionViewSource();
                    //cvs.Source = listaProdaje;


                    //Binding b1 = new Binding();
                    //b1.Path = new PropertyPath("/UkupanIznos");
                    //lbCena.SetBinding(Label.ContentProperty, b1);
          

                    break;
                case Operacija.IZMENA:
                    //foreach (var p in listaProdaje)
                    //{
                    //    if (p.Id == prodajaNamestaja.Id)
                    //    {
                    //        p.StavkaNamestaja = prodajaNamestaja.StavkaNamestaja;
                    //        p.BrojRacuna = prodajaNamestaja.BrojRacuna;
                    //        p.Kupac = prodajaNamestaja.Kupac;
                    //        p.DodatnaUslugaId = prodajaNamestaja.DodatnaUslugaId;
                    //        break;
                    //    }
                    //}
                    break;
                default:
                    break;
            }


            Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var novaProdaje = new StavkaNamestaja()
            {
                NamestajId = 0,
                KolicinaNamestaja = 0
            };

            NamestajZaProdaju prodaja = new NamestajZaProdaju(novaProdaje, NamestajZaProdaju.Operacija.DODAVANJE);
            prodaja.ShowDialog();

        }

        private void dgNamestajP_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "NamestajId")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "IdProdaje")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "prodajaNamestaja")
            {
                e.Cancel = true;
            }
        }

        private void dgUslugaP_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "UslugaId")
            {
                e.Cancel = true;
            }
            else if ((string)e.Column.Header == "IdProdaje")
            {
                e.Cancel = true;
            }
        }

        private void Dodaj_Uslugu(object sender, RoutedEventArgs e)
        {
            var stavkaUsluge = new StavkaUsluge()
            {
                UslugaId = 0
            };

            UslugaZaProdaju usluga = new UslugaZaProdaju(stavkaUsluge, UslugaZaProdaju.Operacija.DODAVANJE);
            if (usluga.ShowDialog() == true)
            {
                
            }
        }
    }
}
