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
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;

namespace AppTrombinoscope
{
    /// <summary>
    /// Logique d'interaction pour GestionPersonnel.xaml
    /// </summary>
    public partial class GestionPersonnel : Window
    {
        public GestionPersonnel(bddpersonnels bdd)
        {
            InitializeComponent();
            LstBoxServices.ItemsSource = bdd.GetServices();
            LstBoxFonctions.ItemsSource = bdd.GetFonctions();
        }

        private void BtnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBoxNom.Text.Length == 0 || 
                TxtBoxPrenom.Text.Length == 0 || 
                TxtBoxTelephone.Text.Length == 0 || 
                LstBoxServices.SelectedIndex == -1 ||
                LstBoxFonctions.SelectedIndex == -1)
            {
                System.Windows.MessageBox.Show("Champ(s) vide(s) !", "Veuille remplir tous les champs !");
                return ;
            }

            System.Windows.MessageBox.Show("Service : " + ((Service)LstBoxServices.SelectedItem).Intitule + 
                " Fonction : " + ((Fonction)LstBoxFonctions.SelectedItem).Intitule + 
                " Nom : " + TxtBoxNom.Text + 
                " Prenom : " + TxtBoxPrenom.Text + 
                " Telephone : " + TxtBoxTelephone.Text);
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnChoisirPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            // fileDialog.Filter = "*.png|*.jpg|*.jpeg";
            fileDialog.RestoreDirectory = true;
            fileDialog.Title = "Choisir une photo de profil";

            DialogResult res = fileDialog.ShowDialog();
            if (res.ToString() == "OK")
            {
                var fileStream = fileDialog.OpenFile();

                BinaryReader binReader = new BinaryReader(fileStream, Encoding.UTF8, false);

                string blob = binReader.ReadString();

                // INSERER DANS LA BDD
            }
            
        }
    }
}
