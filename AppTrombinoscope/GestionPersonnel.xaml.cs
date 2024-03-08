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
using MessageBox = System.Windows.MessageBox;

namespace AppTrombinoscope
{
    /// <summary>
    /// Logique d'interaction pour GestionPersonnel.xaml
    /// </summary>
    public partial class GestionPersonnel : Window
    {
        private string blob = string.Empty;
        private bddpersonnels bdd;
        public GestionPersonnel(bddpersonnels bdd)
        {
            InitializeComponent();
            this.bdd = bdd;
            LstBoxServices.ItemsSource = bdd.GetServices();
            LstBoxFonctions.ItemsSource = bdd.GetFonctions();
        }

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBoxNom.Text.Length == 0 || 
                TxtBoxPrenom.Text.Length == 0 || 
                TxtBoxTelephone.Text.Length == 0 || 
                LstBoxServices.SelectedIndex == -1 ||
                LstBoxFonctions.SelectedIndex == -1 ||
                blob.Length == 0)
            {
                MessageBox.Show("Veuillez remplir tous les champs !", "Champ(s) vide(s) !");
                return ;
            }


            this.bdd.AddPersonnel(
                TxtBoxNom.Text, 
                TxtBoxPrenom.Text, 
                TxtBoxTelephone.Text, 
                blob, 
                (Service) LstBoxServices.SelectedItem, 
                (Fonction) LstBoxFonctions.SelectedItem);

            MessageBox.Show("Cette personne a bien été ajouté à la base de données !", "Succès !");

            TxtBoxNom.Text = string.Empty;
            TxtBoxPrenom.Text = string.Empty;
            TxtBoxTelephone.Text = string.Empty;
            LstBoxServices.SelectedIndex = -1;
            LstBoxFonctions.SelectedIndex = -1;
            blob = string.Empty;
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnChoisirPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpg; *.jpeg)|*.jpg;*.jpeg";
            fileDialog.RestoreDirectory = true;
            fileDialog.Title = "Choisir une photo de profil";

            DialogResult res = fileDialog.ShowDialog();
            if (res.ToString() == "OK")
            {
                string selectedFileName = fileDialog.FileName;
                var fileStream = fileDialog.OpenFile();

                BinaryReader binReader = new BinaryReader(fileStream, Encoding.UTF8, false);

                try
                {
                    this.blob = binReader.ReadString();
                    LabelNomPhoto.Content = selectedFileName.Split('\\').Last();
                } catch (EndOfStreamException ex) 
                {
                    MessageBox.Show("Fichier non valide\nErreur : " + ex.Message, "Erreur");
                }
                
            }
            
        }
    }
}
