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
    /// Logique d'interaction pour DatabaseConfigWindow.xaml
    /// </summary>
    public partial class DatabaseConfigWindow : Window
    {
        private ushort port;

        public DatabaseConfigWindow()
        {
            InitializeComponent();
            TextBoxIP.Text = Properties.Settings.Default.IPAdress;
            TextBoxListenPort.Text = Properties.Settings.Default.Port.ToString();
            TextBoxUsername.Text = Properties.Settings.Default.Username;
            TextBoxPassword.Password = Properties.Settings.Default.Password;
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.IPAdress = TextBoxIP.Text;
            Properties.Settings.Default.Port = port;
            Properties.Settings.Default.Username = TextBoxUsername.Text;
            Properties.Settings.Default.Password = TextBoxPassword.Password;
            Properties.Settings.Default.Save();
        }

        private void ButtonConnection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                port = Convert.ToUInt16(TextBoxListenPort.Text);
            }
            catch (FormatException)
            {
                new ErrorAlert("Nombre invalide", "Erreur de saisie").Show();
            }
            catch (OverflowException)
            {
                new ErrorAlert("Nombre trop grand  ou trop petit pour un numéro de port.\n" +
                    "Veuillez saisir un nombre entre 0 et 65535", "Erreur de sasie").Show();
                return;
            }

            DialogResult = true;
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
