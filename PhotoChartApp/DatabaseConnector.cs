using PhotoChartApp.Properties;
using StaffDatabaseDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoChartApp
{
    internal class DatabaseConnector
    {
        private const string DATABASE_NAME = "bddpersonnels";

        private static DatabaseConnector instance = null;

        private string host;
        private ushort port;
        private string username;
        private string password;

        private DatabaseConnector() {
            UpdateDatabaseSettings();
        }

        public static DatabaseConnector Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DatabaseConnector();
                }
                return instance;
            }
        }

        public void UpdateDatabaseSettings()
        {
            host = Properties.Settings.Default.IPAdress;
            port = Properties.Settings.Default.Port;
            username = Properties.Settings.Default.Username;
            password = Properties.Settings.Default.Password;

            string connectionString = 
                "User id=" + username 
                + ";Password=" + password
                + ";Host=" + host
                + ";Port=" + port
                + ";Database=" + DATABASE_NAME
            ;

            StaffDatabase.ConnectionString = connectionString;
        }

        public StaffDatabase GetDatabase()
        {
            try
            { 
                return StaffDatabase.GetInstance();
            }
            catch { throw; }
        }
    }
}
