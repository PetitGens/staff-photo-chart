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
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonConnection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginManager.Instance.Login(TextBoxUsername.Text, TextBoxPassword.Password);
                Close();
            }
            catch (ArgumentNullException)
            {
                (new ErrorAlert("La base de données n'est pas connectée.", "Erreur connexion")).Show();
                Close();
            }
            catch (ArgumentException)
            {
                (new ErrorAlert("Mot de passe ou nom d'utilisateur incorrect !", "Échec de la connection")).Show();
            }
            catch(Exception ex)
            {
                (new ErrorAlert("Erreur pendant la connexion :\n" + ex.Message, "Erreur connexion")).Show();
            }
        }

        private void Credentials_Changed(object sender, RoutedEventArgs e)
        {
            if(TextBoxUsername.Text == "" || TextBoxPassword.Password == "")
            {
                ButtonConnection.IsEnabled = false;
            }
            else
            {
                ButtonConnection.IsEnabled = true;
            }
        }
    }
}
