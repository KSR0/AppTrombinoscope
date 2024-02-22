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
    /// Logique d'interaction pour ConnexionBDD.xaml
    /// </summary>
    public partial class ConnexionBDD : Window
    {
        private static bddpersonnels bdd;

        public static bddpersonnels Bdd
        {
            get => bdd;
        }

        public ConnexionBDD()
        {
            InitializeComponent();
        }

        private void BtnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bdd = new bddpersonnels(TxtBoxAddrIP.Text, TxtBoxUtilisateur.Text, TxtBoxMDP.Text, TxtBoxPort.Text);
            } catch (Exception exception)
            {
                MessageBox.Show("Erreur de connexion à la base :\n" + exception.Message, "Erreur de connexion");
            }
            MessageBox.Show("Connexion réussie", "Succès");
        }
    }
}
