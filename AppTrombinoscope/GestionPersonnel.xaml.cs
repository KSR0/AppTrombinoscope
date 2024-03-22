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
        private byte[] blob = new byte[0];
        private bddpersonnels bdd;
        private string basicPhotoName = "account-25-256.png";
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
            LabelNomPhoto.Content = string.Empty;

            // Reinitialiser l'image
            ImagePreAjout.Source = null;

            blob = new byte[0];
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

                try
                {
                    // Read the binary data of the image file
                    byte[] imageData;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        fileStream.CopyTo(ms);
                        imageData = ms.ToArray();
                        this.blob = imageData;
                    }

                    // Convertir en image
                    BitmapImage bitmapImage = ConvertToBitmapImage(imageData);
                    ImagePreAjout.Source = bitmapImage;
                    LabelNomPhoto.Content = selectedFileName.Split('\\').Last();

                } catch (EndOfStreamException ex) 
                {
                    MessageBox.Show("Fichier non valide\nErreur : " + ex.Message, "Erreur");
                }
                
            }
        }

        private BitmapImage ConvertToBitmapImage(byte[] imageData)
        {
            BitmapImage bitmapImage = new BitmapImage();

            try
            {
                // Create a memory stream from the byte array
                using (MemoryStream memoryStream = new MemoryStream(imageData))
                {
                    // Set the memory stream as the source for the BitmapImage
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memoryStream;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Erreur lors de la conversion de l'image : " + ex.Message, "Erreur");
            }

            return bitmapImage;
        }
    }
}
