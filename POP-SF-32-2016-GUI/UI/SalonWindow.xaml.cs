﻿using POP_SF32_2016.Model;
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
    /// Interaction logic for SalonWindow.xaml
    /// </summary>
    public partial class SalonWindow : Window
    {

        public Salon IzabraniSalon { get; set; }
        public SalonWindow()
        {
            InitializeComponent();
            dgSalon.IsSynchronizedWithCurrentItem = true;
            dgSalon.DataContext = this;
            dgSalon.ItemsSource = Projekat.Instance.Saloni;

        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgSalon_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            Salon kopija = (Salon)IzabraniSalon.Clone();
            var salonProzor = new IzmenaSalona(kopija, IzmenaSalona.Operacija.IZMENA);
            salonProzor.ShowDialog();
        }
    }
}
