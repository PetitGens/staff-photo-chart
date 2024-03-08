using BddpersonnelContext;
using StaffDatabaseDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace PhotoChartApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*DatabaseConnector.Instance.UpdateDatabaseSettings();
            DatabaseConnector.Instance.GetDatabase().GetStaffList();*/

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
        }

        private void MenuItemDBSettings_Click(object sender, RoutedEventArgs e)
        {
            DatabaseConfigWindow databaseConfigWindow = new DatabaseConfigWindow();

            if (databaseConfigWindow.ShowDialog() == false)
            {
                return;
            }

            databaseConfigWindow.SaveSettings();
            try
            {
                DatabaseConnector.Instance.UpdateDatabaseSettings();
                DatabaseConnector.Instance.GetDatabase().GetStaffList();
            }
            catch (Exception ex)
            {
                new ErrorAlert("Erreur de connexion à la base de données :\n" + ex.Message,
                    "Erreur base de données").Show();
                return;
            }
        }
    }
}
