using BddpersonnelContext;
using StaffDatabaseDll;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoChartApp
{
    internal class LoginManager
    {
        private static LoginManager instance;

        private Gestionnaire user;

        public string Username
        {
            get 
            {
                if (user == null)
                {
                    return "";
                }
                return user.Username; 
            }
        }

        public static LoginManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginManager();
                }
                return instance;
            }
        }

        private LoginManager() { }

        public void Login(string username, string password) 
        {
            user = null;

            StaffDatabase database = DatabaseConnector.Instance.GetDatabase();

            if (database == null)
            {
                throw new ArgumentNullException("Database is not connected");
            }

            Gestionnaire gestionnaire = database.DataContext.Gestionnaires.SingleOrDefault(
                g => g.Username == username
            );

            if (gestionnaire == null || gestionnaire.Motdepasse != password)
            {
                throw new ArgumentException("Invalid credentials");
            }

            user = gestionnaire;
        }

        public void Logout()
        {
            user = null;
        }

        public bool IsLoggedIn()
        {
            return user != null;
        }
    }
}
