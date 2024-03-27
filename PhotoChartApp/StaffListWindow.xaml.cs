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
    public partial class StaffListWindow : Window
    {

        private StaffDatabase Database
        {
            get
            {
                return DatabaseConnector.Instance.Database;
            }
        }
        public StaffListWindow()
        {
            InitializeComponent();
            DataContext = Database.Personnels;
            DataGridStaffList.ItemsSource = Database.Personnels;
            
        }

        




        private void TextBoxStaffName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxStaffFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
