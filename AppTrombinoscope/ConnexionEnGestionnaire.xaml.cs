﻿using System;
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

namespace AppTrombinoscope
{
    /// <summary>
    /// Logique d'interaction pour ConnexionEnGestionnaire.xaml
    /// </summary>
    public partial class ConnexionEnGestionnaire : Window
    {
        public ConnexionEnGestionnaire()
        {
            InitializeComponent();
        }

        private void BtnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("test");
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
