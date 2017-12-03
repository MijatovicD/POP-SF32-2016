﻿using POP_SF_32_2016_GUI.Model;
using POP_SF32_2016.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for NamestajZaProdaju.xaml
    /// </summary>
    public partial class NamestajZaProdaju : Window
    {
        ICollectionView vieew;
        public StavkaProdaje StavkaProdaje { get; set; }
        public NamestajZaProdaju()
        {
            InitializeComponent();

            Namestaj namestaj = new Namestaj();
            //vieew = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
            //dgNamestajProdaja.IsSynchronizedWithCurrentItem = true;
            //dgNamestajProdaja.DataContext = this;
            //dgNamestajProdaja.ItemsSource = vieew;
            this.DataContext = StavkaProdaje;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}