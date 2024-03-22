﻿using BddpersonnelContext;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppTrombinoscope
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static bddpersonnels bdd;
        private bool connexionValide = false;

        public static bddpersonnels Bdd
        {
            get => bdd;
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new BddpersonnelDataContext();
            BtnListePersonnel.IsEnabled = false;
            BtnGestionServices.IsEnabled = false;
            BtnGestionFonctions.IsEnabled = false;
            BtnGestionPersonnels.IsEnabled = false;
            EssayerConnexion();

            // POUR TESTER EN TANT QUE GESTIONNAIRE

            // bdd = new bddpersonnels("localhost", "GestionnaireBDD", "Password1234@but", "3306");
            // ListePersonnel listePersonnel = new ListePersonnel(bdd);
            // listePersonnel.ShowDialog();
            // Close();

            //
        }


        private void BtnParametresBDD_Click(object sender, RoutedEventArgs e)
        {
            ParametresBDD parametresBDD = new ParametresBDD();
            parametresBDD.ShowDialog();
        }

        private void BtnConnexionBDD_Click(object sender, RoutedEventArgs e)
        {
            EssayerConnexion();
        }

        private void EssayerConnexion()
        {
            string addrIP = Properties.Settings.Default.AdresseIP;
            int port = Properties.Settings.Default.Port;
            string utilisateur = Properties.Settings.Default.Username;
            string mdp = Properties.Settings.Default.Password;

            try
            {
                bdd = new bddpersonnels(addrIP, utilisateur, mdp, port.ToString());
                bdd.testerConnexion();
                ChargerDonneesLorsConnexion();
                connexionValide = true;
                this.Title = "Trombinoscope (Connecté en tant que : Utilisateur)";
                BtnListePersonnel.IsEnabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Erreur de connexion à la base :\n" + exception.Message, "Erreur: " + exception);
                connexionValide = false;
                BtnListePersonnel.IsEnabled = false;
                BtnGestionServices.IsEnabled = false;
                BtnGestionFonctions.IsEnabled = false;
                BtnGestionPersonnels.IsEnabled = false;
            }
        }

        private void ChargerDonneesLorsConnexion()
        {
            LstService.ItemsSource = bdd.GetServices();
            LstFonctions.ItemsSource = bdd.GetFonctions();
        }

        private void BtnGestionnaire_Click(object sender, RoutedEventArgs e)
        {
            if (!connexionValide)
            {
                MessageBox.Show("Veuillez vous connecter !", "Erreur de connexion");
                return;
            }

            ConnexionEnGestionnaire connexionEnGestionnaire = new ConnexionEnGestionnaire(bdd);
            connexionEnGestionnaire.ShowDialog();
            if (connexionEnGestionnaire.EstAuthentifie)
            {
                bdd = connexionEnGestionnaire.Bdd;
                this.Title = "Trombinoscope (Connecté en tant que : Gestionnaire)";
                BtnGestionServices.IsEnabled = true;
                BtnGestionFonctions.IsEnabled = true;
                BtnGestionPersonnels.IsEnabled = true;
            }
        }

        private void BtnGestionPersonnels_Click(object sender, RoutedEventArgs e)
        {
            GestionPersonnel gestionPersonnel = new GestionPersonnel(bdd);
            gestionPersonnel.ShowDialog();
        }

        private void BtnListePersonnel_Click(object sender, RoutedEventArgs e)
        {
            ListePersonnel listePersonnel = new ListePersonnel(bdd);
            listePersonnel.ShowDialog();
        }

        private void BtnGestionServices_Click(object sender, RoutedEventArgs e)
        {
            GestionServices gestionServices = new GestionServices(bdd);
            gestionServices.ShowDialog();
        }

        private void BtnGestionFonctions_Click(object sender, RoutedEventArgs e)
        {
            GestionFonctions gestionFonctions = new GestionFonctions(bdd);
            gestionFonctions.ShowDialog();
        }
    }
}
