using BddpersonnelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffDatabaseDll
{
    public class StaffDatabase
    {
        private BddpersonnelDataContext dataContext;

        private static StaffDatabase instance = null;
        private static string connectionString = "";

        public static string ConnectionString
        {
            get { return connectionString; }
            set
            {
                connectionString = value;
                instance = null;
            }
        }

        private StaffDatabase(string connectionString)
        {
            if (connectionString == null || connectionString == "")
            {
                throw new ArgumentNullException("The connection string is empty or null !");
            }
            dataContext = new BddpersonnelDataContext(connectionString);
        }

        public static StaffDatabase GetInstance()
        {
            if (instance == null)
            {
                instance = new StaffDatabase(connectionString);
            }

            return instance;
        }

        public List<Personnel> GetStaffList()
        {
            try
            {
                return dataContext.Personnels.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
