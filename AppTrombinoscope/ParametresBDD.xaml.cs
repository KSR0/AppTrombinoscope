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
    public partial class ParametresBDD : Window
    {
        
        public ParametresBDD()
        {
            InitializeComponent();
            TxtBoxAddrIP.Text = Properties.Settings.Default.AdresseIP;
            TxtBoxPort.Text = Properties.Settings.Default.Port;
            TxtBoxUtilisateur.Text = Properties.Settings.Default.Username;
            TxtBoxMDP.Password = Properties.Settings.Default.Password;
        }

        private void BtnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.AdresseIP = TxtBoxAddrIP.Text;
            Properties.Settings.Default.Port = TxtBoxPort.Text;
            Properties.Settings.Default.Username = TxtBoxUtilisateur.Text;
            Properties.Settings.Default.Password = TxtBoxMDP.Password;
            Properties.Settings.Default.Save();
            Close();
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
