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
    /// Logique d'interaction pour gestionFonctions.xaml
    /// </summary>
    public partial class GestionFonctions : Window
    {
        private static bddpersonnels bdd;

        public GestionFonctions(bddpersonnels _bdd)
        {
            InitializeComponent();

            bdd = _bdd;
            LstFonction.ItemsSource = bdd.GetFonctions();
        }

        private void AjouterClick(object sender, RoutedEventArgs e)
        {
            LstFonction.SelectedItem = null;

            if (txtNomFonction.Text == "")
            {
                MessageBox.Show("le nom est vide !");
                return;
            }

            foreach (Fonction test in LstFonction.Items)
            {
                if (test.Intitule == txtNomFonction.Text)
                {
                    MessageBox.Show("Il y a deja un Fonction avec ce nom !");
                    return;
                }
            }
            bdd.AddFonctions(txtNomFonction.Text);
            LstFonction.ItemsSource = bdd.GetFonctions();
            txtNomFonction.Text = "";
        }

        private void SupprFonction(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce Fonction ?", "Confirmation", MessageBoxButton.YesNo); ;
            if (result == MessageBoxResult.Yes)
            {
                if (bdd.SupprFonctions((Fonction)LstFonction.SelectedItem) == -1)
                {
                    MessageBox.Show("Des membres du personnel sont affecter à ce Fonction !\nVeuillez  les désafécter de leurs Fonctions avant de le supprimer.");
                }
                else
                {
                    LstFonction.ItemsSource = bdd.GetFonctions();
                }
            }
        }

        private void ModifierFonction(object sender, RoutedEventArgs e)
        {
            txtNouveauNomFonction.Visibility = Visibility.Visible;
            labelNouveauNom.Visibility = Visibility.Visible;
            BtnValider.Visibility = Visibility.Visible;
        }


        private void LstFonction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtNouveauNomFonction.Text = ((Fonction)LstFonction.SelectedItem).Intitule;
            txtNouveauNomFonction.Visibility = Visibility.Hidden;
            labelNouveauNom.Visibility = Visibility.Hidden;
            BtnValider.Visibility = Visibility.Hidden;
        }

        private void ValiderClick(object sender, RoutedEventArgs e)
        {
            if (txtNouveauNomFonction.Text == "")
            {
                MessageBox.Show("le nom est vide !");
                return;
            }

            foreach (Fonction test in LstFonction.Items)
            {
                if (test.Intitule == txtNouveauNomFonction.Text)
                {
                    MessageBox.Show("Il y a deja un Fonction avec ce nom !");
                    return;
                }
            }

            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment modifier cette Fonction ?", "Confirmation", MessageBoxButton.YesNo); ;
            if (result == MessageBoxResult.Yes)
            {
                bdd.UpdateFonctions(txtNouveauNomFonction.Text, (Fonction)LstFonction.SelectedItem);
                txtNouveauNomFonction.Text = ((Fonction)LstFonction.SelectedItem).Intitule;
                txtNouveauNomFonction.Visibility = Visibility.Hidden;
                labelNouveauNom.Visibility = Visibility.Hidden;
                BtnValider.Visibility = Visibility.Hidden;
            }
        }
    }
}
