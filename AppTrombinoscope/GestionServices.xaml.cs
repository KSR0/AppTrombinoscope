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
using BddpersonnelContext;

namespace AppTrombinoscope
{
    /// <summary>
    /// Logique d'interaction pour gestionServices.xaml
    /// </summary>
    public partial class GestionServices : Window
    {
        private static bddpersonnels bdd;

        public GestionServices(bddpersonnels _bdd)
        {
            InitializeComponent();

            bdd = _bdd;
            LstService.ItemsSource = bdd.GetServices();
        }

        private void AjouterClick(object sender, RoutedEventArgs e)
        {
            LstService.SelectedItem = null;

            if (txtNomService.Text == "")
            {
                MessageBox.Show("le nom est vide !");
                return;
            }

            foreach (Service test in LstService.Items)
            {
                if (test.Intitule == txtNomService.Text)
                {
                    MessageBox.Show("Il y a deja un service avec ce nom !");
                    return;
                }
            }
            bdd.AddServices(txtNomService.Text);
            LstService.ItemsSource = bdd.GetServices();
            txtNomService.Text = "";
        }

        private void modifierClick(object sender, RoutedEventArgs e)
        {
            if (txtNouveauNomService.Text == "")
            {
                MessageBox.Show("le nom est vide !");
                return;
            }

            foreach (Service test in LstService.Items)
            {
                if (test.Intitule == txtNouveauNomService.Text)
                {
                    MessageBox.Show("Il y a deja un service avec ce nom !");
                    return;
                }
            }

            bdd.UpdateServices(txtNouveauNomService.Text, (Service)LstService.SelectedItem);
            txtNouveauNomService.Text = "";
        }

        private void SupprimerClick(object sender, RoutedEventArgs e)
        {
            if (bdd.SupprServices((Service)LstService.SelectedItem) == -1)
            {
                MessageBox.Show("Des membres du personnel sont affecter à ce service !\nVeuillez  les désafécter de leurs services avant de le supprimer.");
            } else
            {
                LstService.ItemsSource = bdd.GetServices();
            }
        }

        private void LstService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstService.SelectedIndex.ToString() != "-1")
            {
                BtnSupprimer.IsEnabled = true;
                BtnModifier.IsEnabled = true;
            } else
            {
                BtnSupprimer.IsEnabled = false;
                BtnModifier.IsEnabled = false;
            }
        }
    }
}
