using BddpersonnelContext;
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
    }
}
