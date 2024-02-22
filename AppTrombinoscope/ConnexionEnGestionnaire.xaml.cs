using BddpersonnelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        private bddpersonnels bdd;
        public bddpersonnels Bdd
        {
            get => bdd;
        }

        private bool estAuthentifie;
        public bool EstAuthentifie
        {
            get => estAuthentifie;
        }

        public ConnexionEnGestionnaire(bddpersonnels bdd)
        {
            InitializeComponent();
            this.bdd = bdd;
        }

        private void BtnConnexion_Click(object sender, RoutedEventArgs e)
        {
            estAuthentifie = bdd.GestionnaireExiste(TxtBoxUtilisateur.Text, PasswordBoxMDP.Password);

            string addrIP = Properties.Settings.Default.AdresseIP;
            int port = Properties.Settings.Default.Port;
            string utilisateur = "GestionnaireBDD";
            string mdp = "Password1234@but";

            bdd = new bddpersonnels(addrIP, utilisateur, mdp, port.ToString());
            if (!estAuthentifie)
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe faux !", "Erreur lors de la connexion");
                return;
            }
            Close();
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
