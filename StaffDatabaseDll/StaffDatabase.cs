using BddpersonnelContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffDatabaseDll
{
    public class StaffDatabase
    {
        private BddpersonnelDataContext dataContext;
        private ObservableCollection<Personnel> personnels;
        private ObservableCollection<Service> services;
        private ObservableCollection<Fonction> functions;

        private static StaffDatabase instance = null;
        private static string connectionString = "";

        public BddpersonnelDataContext DataContext
        {
            get { return dataContext; }
        }

        public ObservableCollection<Personnel> Personnels
        {
            get
            {
                if(personnels == null)
                {
                    personnels = new ObservableCollection<Personnel>(dataContext.Personnels);
                }
                return personnels;
            }
        }

        public ObservableCollection<Service> Services
        {
            get
            {
                if (services == null)
                {
                    services = new ObservableCollection<Service>(dataContext.Services);
                }
                return services;
            }
        }

        public ObservableCollection<Fonction> Fonctions
        {
            get
            {
                if (functions == null)
                {
                    functions = new ObservableCollection<Fonction>(dataContext.Fonctions);
                }
                return functions;
            }
        }

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

        public void InsertService(Service service)
        {
            int id = dataContext.Services.Max(s => s.Id) + 1;
            service.Id = id;

            dataContext.Services.InsertOnSubmit(service);
            dataContext.SubmitChanges();

            services.Add(service);
        }

        public void InsertFunction(Fonction function)
        {
            int id = dataContext.Fonctions.Max(s => s.Id) + 1;
            function.Id = id;

            dataContext.Fonctions.InsertOnSubmit(function);
            dataContext.SubmitChanges();

            functions.Add(function);
        }
    }
}
