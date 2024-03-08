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
            StaffDatabase database = DatabaseConnector.Instance.GetDatabase();
            List<Personnel> personnels = database.GetStaffList();

            Console.WriteLine("AFFICHAGE DU PERSONNEL");
            Console.WriteLine("----------------------");

            foreach (Personnel personnel in personnels)
            {
                Console.WriteLine(personnel.Prenom + ' ' + personnel.Nom);
            }

            Console.WriteLine("----------------------");
        }
    }
}
