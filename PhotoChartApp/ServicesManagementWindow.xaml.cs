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
    public partial class ServicesManagementWindow : Window
    {
        private StaffDatabase Database
        {
            get
            {
                return DatabaseConnector.Instance.Database;
            }
        }

        public ServicesManagementWindow()
        {
            InitializeComponent();
            
            DataContext = Database.Services;
        }

        private void TextBoxAddService_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonAddService.IsEnabled = TextBoxAddService.Text != "";
        }

        private void ButtonAddService_Click(object sender, RoutedEventArgs e)
        {
            Service newService = new Service
            {
                Intitule = TextBoxAddService.Text
            };
            
            Database.InsertService(newService);

            TextBoxAddService.Text = "";
        }

        private void ButtonModifyService_Click(object sender, RoutedEventArgs e)
        {
            Service modified = (Service)ListViewServices.SelectedItem;
            modified.Intitule = TextBoxEditService.Text;
            Database.SubmitChanges();
        }
    }
}
