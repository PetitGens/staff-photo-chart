﻿using BddpersonnelContext;
using Devart.Data.Linq;
using StaffDatabaseDll;
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

namespace PhotoChartApp
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class FunctionsManagementWindow : Window
    {
        private StaffDatabase Database
        {
            get
            {
                return DatabaseConnector.Instance.Database;
            }
        }

        public FunctionsManagementWindow()
        {
            InitializeComponent();
            DataContext = Database.Fonctions;
        }

        private void TextBoxAddFunction_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonAddFunction.IsEnabled = TextBoxAddFunction.Text != "";
        }

        private void ButtonAddFunction_Click(object sender, RoutedEventArgs e)
        {
            Fonction newFunction = new Fonction
            {
                Intitule = TextBoxAddFunction.Text
            };

            Database.InsertFunction(newFunction);

            TextBoxAddFunction.Text = "";
        }

        private void ButtonEditFunction_Click(object sender, RoutedEventArgs e)
        {
            Fonction modified = (Fonction)ListViewFunctions.SelectedItem;
            modified.Intitule = TextBoxEditFunction.Text;
            Database.SubmitChanges();
        }

        private void MenuItemDeleteFunction_Click(object sender, RoutedEventArgs e)
        {
            Fonction selected = (Fonction)ListViewFunctions.SelectedItem;
            ConfirmationDialog dialog = new ConfirmationDialog(
                "Voulez-vous vraiment supprimer la fonction " + selected.Intitule + " ?", 
                "Confirmation de suppresion");
            
            if(dialog.Show() != MessageBoxResult.Yes)
            {
                return;
            }

            try
            {
                Database.DeleteFunction(selected);
            }
            catch (LinqCommandExecutionException)
            {
                new ErrorAlert(
                    "La suppresion est impossible car du personnel est affecté à cette fonction.\n" +
                    "Réaffecter ou supprimer la ou les personnes concernée(s) et réessayer.",
                    "Échec de le suppresion."
                ).Show();
            }
        }
    }
}
