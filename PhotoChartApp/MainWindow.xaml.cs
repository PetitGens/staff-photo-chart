using BddpersonnelContext;
using StaffDatabaseDll;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private StaffDatabase database;

        /// <value>
        /// The database object (or null if not connected).
        /// It permits to manage staff, services and functions.
        /// <br/>
        /// Its setter also manage the title Window and updates DataContexts.
        /// </value>
        private StaffDatabase Database
        {
            get { return database;}
            set
            {
                database = value;
                if(value == null)
                {
                    MenuItemManagement.IsEnabled = false;
                    SetManagementMenusState(false);
                }
                UpdateDataContexts();
                UpdateWindowTitle();
            }
        }

        /// <value>
        /// An observable list of services. Null if no database connection.
        /// </value>
        private object Services
        {
            get
            {
                if(database == null)
                {
                    return null;
                }

                return database.DataContext.Services;
            }
        }

        /// <value>
        /// An observable list of functions. Null if no database connection.
        /// </value>
        private object Functions
        {
            get
            {
                if (database == null)
                {
                    return null;
                }

                return database.DataContext.Fonctions;
            }
        }

        /// <summary>
        /// Initialize the window's components and the Database property.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Database = null;
            
           /* LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();

            ServicesManagementWindow servicesManagementWindow = new ServicesManagementWindow();
            servicesManagementWindow.Show();

            FunctionsManagementWindow functionsManagementWindow = new FunctionsManagementWindow();
            functionsManagementWindow.Show();*/
        }

        /// <summary>
        /// Update the data contexts for the three ListBox.
        /// <br/>
        /// Must be called when the database connection is updated.
        /// </summary>
        private void UpdateDataContexts()
        {
            ListBoxServices.DataContext = Services;
            ListBoxFunctions.DataContext = Functions;
            ListBoxMembers.DataContext = null;
        }

        /// <summary>
        /// Opens the database configuration window as a dialog.
        /// <br/>
        /// If the user choose to confirm settings (true result),
        /// saves them and tries to connect to the database.
        /// </summary>
        private void MenuItemDBSettings_Click(object sender, RoutedEventArgs e)
        {
            DatabaseConfigWindow databaseConfigWindow = new DatabaseConfigWindow();

            if (databaseConfigWindow.ShowDialog() == false)
            {
                return;
            }

            databaseConfigWindow.SaveSettings();
            ConnectToDatabase();
        }

        /// <summary>
        /// Tries to connect to the database.
        /// </summary>
        private void MenuItemDBConnect_Click(object sender, RoutedEventArgs e)
        {
            ConnectToDatabase();
        }

        /// <summary>
        /// Tries to connect to the database 
        /// with the info in the application settings.
        /// If successful, the window's title is also updated.
        /// <br/>
        /// If an error occurs, sets the database to null (which updates the window's title and the list boxes)
        /// and displays an error alert.
        /// </summary>
        private void ConnectToDatabase()
        {
            try
            {
                DatabaseConnector.Instance.UpdateDatabaseSettings();
                Database = DatabaseConnector.Instance.GetDatabase();
                if(Database == null)
                {
                    throw new Exception("Aucune connexion n'a pu être ouverte.\n" +
                        "Veuillez vérifier les paramètres de bases de données et que celle ci est active.");
                }
                Database.GetStaffList();
            }
            catch (Exception ex)
            {
                new ErrorAlert("Erreur de connexion à la base de données :\n" + ex.Message,
                    "Erreur base de données").Show();
                Database = null;
                return;
            }

            Title = "TROMBINOSCOPE - CONNECTÉ";
            MenuItemManagement.IsEnabled = true;
        }

        /// <summary>
        /// Remove the selection of the functions list box
        /// and fill the staff list box with the members of the selected service.
        /// </summary>
        private void ListBoxServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ListBoxServices.SelectedItem == null)
            {
                return;
            }
            ListBoxFunctions.SelectedItem = null;
            ListBoxMembers.DataContext = ((Service)ListBoxServices.SelectedItem).Personnels;
        }

        /// <summary>
        /// Remove the selection of the services list box
        /// and fill the staff list box with the members of the selected function.
        /// </summary>
        private void ListBoxFunctions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ListBoxFunctions.SelectedItem == null)
            {
                return;
            }

            ListBoxServices.SelectedItem = null;
            ListBoxMembers.DataContext = ((Fonction) ListBoxFunctions.SelectedItem).Personnels.ToList();
        }

        private void MenuItemManagement_Click(object sender, RoutedEventArgs e)
        {
            SetManagementMenusState(false);

            if(Database == null)
            {
                return;
            }

            LoginManager loginManager = LoginManager.Instance;

            if((new LoginWindow()).ShowDialog() == true || loginManager.IsLoggedIn())
            {
                SetManagementMenusState(true);
            }

            UpdateWindowTitle();
        }

        private void SetManagementMenusState(bool enabled)
        {
            MenuItemStaffList.IsEnabled = enabled;
            MenuItemServiceManagement.IsEnabled = enabled;
            MenuItemFunctionManagement.IsEnabled = enabled;
            MenuItemStaffManagement.IsEnabled = enabled;
        }

        private void UpdateWindowTitle()
        {
            if(Database == null)
            {
                Title = "TROMBINOSCOPE - NON CONNECTÉ";
            }
            else
            {
                Title = "TROMBINOSCOPE - CONNECTÉ";
                if (LoginManager.Instance.IsLoggedIn())
                {
                    Title += " EN TANT QUE " + LoginManager.Instance.Username;
                }
            }
        }
    }
}
