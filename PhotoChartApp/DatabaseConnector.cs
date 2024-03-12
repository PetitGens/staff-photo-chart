using PhotoChartApp.Properties;
using StaffDatabaseDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoChartApp
{
    /// <summary>
    /// An intermediary class for database connection.
    /// It is used to build the connection string with the settings.
    /// </summary>
    internal class DatabaseConnector
    {
        private const string DATABASE_NAME = "bddpersonnels";

        private static DatabaseConnector instance = null;

        private string host;
        private ushort port;
        private string username;
        private string password;

        private StaffDatabase database;

        public StaffDatabase Database
        {
            get { return database; }
        }

        /// <summary>
        /// Calls an update to retrieve database settings.
        /// </summary>
        private DatabaseConnector() {
            UpdateDatabaseSettings();
        }

        /// <value>
        /// The connector instance (singleton).
        /// </value>
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

        /// <summary>
        /// Retrieves the database settings and updates the connection string.
        /// </summary>
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
                + ";CharSet=UTF8"
            ;

            StaffDatabase.ConnectionString = connectionString;
        }

        public void ConnectToDatabase()
        {
            UpdateDatabaseSettings();

            database = StaffDatabase.GetInstance();
            

            try
            {
                database.TestConnection();
            }
            catch
            {
                database = null;
                throw new Exception("Aucune connexion n'a pu être ouverte.\n" +
                    "Veuillez vérifier les paramètres de bases de données et que celle ci est active.");
            }
        }
    }
}
