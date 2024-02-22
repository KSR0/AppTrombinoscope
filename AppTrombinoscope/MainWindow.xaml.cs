using BddpersonnelContext;
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

        public static bddpersonnels Bdd
        {
            get => bdd;
        }

        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void BtnParametresBDD_Click(object sender, RoutedEventArgs e)
        {
            ParametresBDD parametresBDD = new ParametresBDD();
            parametresBDD.ShowDialog();
        }

        private void BtnConnexionBDD_Click(object sender, RoutedEventArgs e)
        {
            string addrIP = Properties.Settings.Default.AdresseIP;
            string port = Properties.Settings.Default.Port;
            string utilisateur = Properties.Settings.Default.Username;
            string mdp = Properties.Settings.Default.Password;
            
            try
            {
                bdd = new bddpersonnels(addrIP, utilisateur, mdp, port);
                bdd.testerConnexion();
                chargerDonneesLorsConnexion();
            } catch (Exception exception)
            {
                MessageBox.Show("Erreur de connexion à la base :\n" + exception.Message, "Erreur de connexion");
            }
            
            
        }

        private void chargerDonneesLorsConnexion()
        {
            throw new NotImplementedException();
        }
    }
}
