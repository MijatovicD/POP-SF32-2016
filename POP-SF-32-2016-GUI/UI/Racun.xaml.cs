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
    /// Interaction logic for Racun.xaml
    /// </summary>
    public partial class Racun : Window
    {
        public Racun()
        {
            InitializeComponent();

            lbStavke.ItemsSource = Projekat.Instance.StavkeNamestaja;
            lbUsluge.ItemsSource = Projekat.Instance.StavkeUsluge;
        }
    }
}
