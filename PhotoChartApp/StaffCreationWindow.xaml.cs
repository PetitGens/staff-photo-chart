using BddpersonnelContext;
using Microsoft.Win32;
using StaffDatabaseDll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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

namespace PhotoChartApp
{
    /// <summary>
    /// Logique d'interaction pour StaffCreationWindow.xaml
    /// </summary>
    public partial class StaffCreationWindow : Window
    {
        private string imagePath = "";

        private StaffDatabase Database
        {
            get
            {
                return DatabaseConnector.Instance.Database;
            }
        }

        public StaffCreationWindow()
        {
            InitializeComponent();
            ListBoxServices.DataContext = Database.Services;
            ListBoxFunctions.DataContext = Database.Fonctions;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if(
                TextBoxName.Text == ""
                || TextBoxLastName.Text == ""
                || ListBoxServices.SelectedItem == null
                || ListBoxFunctions.SelectedItem == null
            ){
                return;
            }

            Personnel personnel = new Personnel
            {
                Nom = TextBoxName.Text,
                Prenom = TextBoxLastName.Text,
                Telephone = TextBoxPhoneNumber.Text,
                Service = (Service)ListBoxServices.SelectedItem,
                Fonction = (Fonction)ListBoxFunctions.SelectedItem
            };

            if(imagePath != "")
            {
                try
                {
                    personnel.Photo = ImageHandler.ResizeBlobImage(imagePath, StaffDatabase.MAX_IMAGE_SIZE);
                }
                catch
                {
                    new ErrorAlert(
                        "Impossible de trouver la photo. A-t-elle été déplacée ou supprimée ?",
                        "Échec de l'ajout de personnel"
                    ).Show();
                    imagePath = "";
                    UpdateShownImage();
                    return;
                }
            }

            try
            {
                Database.InsertPersonnel(personnel);
                Close();
            }
            catch (Exception ex)
            {
                new ErrorAlert(
                    "L'ajout a échoué. Raison :\n" + ex.Message, 
                    "Échec de l'ajout de personnel"
                ).Show();
            }
        }

        private void ButtonOpenPhoto_Click(object sender, RoutedEventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            imagePath = fileDialog.FileName;
            UpdateShownImage();
        }

        private void UpdateShownImage()
        {
            if (imagePath != "")
            {
                ImagePhoto.Source = new BitmapImage(new Uri(imagePath));
            }
            else
            {
                ImagePhoto.Source = null;
            }
        }

        private void UpdateSaveButtonState()
        {
            ButtonSave.IsEnabled = 
                TextBoxName.Text != "" 
                && TextBoxLastName.Text != "" 
                && ListBoxServices.SelectedItem != null 
                && ListBoxFunctions.SelectedItem != null;
        }

        private void TextBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSaveButtonState();
        }

        private void TextBoxLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSaveButtonState();
        }

        private void TextBoxPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSaveButtonState();
        }

        private void ListBoxServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSaveButtonState();
        }

        private void ListBoxFunctions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSaveButtonState();
        }
    }
}
