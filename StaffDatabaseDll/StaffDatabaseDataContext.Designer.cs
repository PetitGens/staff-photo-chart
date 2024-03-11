﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using LinqConnect template.
// Code is generated on: 11/03/2024 08:43:56
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using Devart.Data.Linq;
using Devart.Data.Linq.Mapping;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;

namespace BddpersonnelContext
{

    [DatabaseAttribute(Name = "bddpersonnels")]
    [ProviderAttribute(typeof(Devart.Data.MySql.Linq.Provider.MySqlDataProvider))]
    public partial class BddpersonnelDataContext : Devart.Data.Linq.DataContext
    {
        public static CompiledQueryCache compiledQueryCache = CompiledQueryCache.RegisterDataContext(typeof(BddpersonnelDataContext));
        private static MappingSource mappingSource = new Devart.Data.Linq.Mapping.AttributeMappingSource();

        #region Extensibility Method Definitions
    
        partial void OnCreated();
        partial void OnSubmitError(Devart.Data.Linq.SubmitErrorEventArgs args);
        partial void InsertFonction(Fonction instance);
        partial void UpdateFonction(Fonction instance);
        partial void DeleteFonction(Fonction instance);
        partial void InsertPersonnel(Personnel instance);
        partial void UpdatePersonnel(Personnel instance);
        partial void DeletePersonnel(Personnel instance);
        partial void InsertService(Service instance);
        partial void UpdateService(Service instance);
        partial void DeleteService(Service instance);
        partial void InsertGestionnaire(Gestionnaire instance);
        partial void UpdateGestionnaire(Gestionnaire instance);
        partial void DeleteGestionnaire(Gestionnaire instance);

        #endregion

        public BddpersonnelDataContext() :
        base(GetConnectionString("BddpersonnelDataContextConnectionString"), mappingSource)
        {
            OnCreated();
        }

        public BddpersonnelDataContext(MappingSource mappingSource) :
        base(GetConnectionString("BddpersonnelDataContextConnectionString"), mappingSource)
        {
            OnCreated();
        }

        private static string GetConnectionString(string connectionStringName)
        {
            System.Configuration.ConnectionStringSettings connectionStringSettings = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName];
            if (connectionStringSettings == null)
                throw new InvalidOperationException("Connection string \"" + connectionStringName +"\" could not be found in the configuration file.");
            return connectionStringSettings.ConnectionString;
        }

        public BddpersonnelDataContext(string connection) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public BddpersonnelDataContext(System.Data.IDbConnection connection) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public BddpersonnelDataContext(string connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public BddpersonnelDataContext(System.Data.IDbConnection connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public Devart.Data.Linq.Table<Fonction> Fonctions
        {
            get
            {
                return this.GetTable<Fonction>();
            }
        }

        public Devart.Data.Linq.Table<Personnel> Personnels
        {
            get
            {
                return this.GetTable<Personnel>();
            }
        }

        public Devart.Data.Linq.Table<Service> Services
        {
            get
            {
                return this.GetTable<Service>();
            }
        }

        public Devart.Data.Linq.Table<Gestionnaire> Gestionnaires
        {
            get
            {
                return this.GetTable<Gestionnaire>();
            }
        }
    }
}

namespace BddpersonnelContext
{

    /// <summary>
    /// There are no comments for BddpersonnelContext.Fonction in the schema.
    /// </summary>
    [Table(Name = @"bddpersonnels.fonctions")]
    public partial class Fonction : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _Id;

        private string _Intitule;
        #pragma warning restore 0649

        private EntitySet<Personnel> _Personnels;

        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnIntituleChanging(string value);
        partial void OnIntituleChanged();
        #endregion

        public Fonction()
        {
            this._Personnels = new EntitySet<Personnel>(new Action<Personnel>(this.attach_Personnels), new Action<Personnel>(this.detach_Personnels));
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        [Column(Name = @"id", Storage = "_Id", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "INT(11) NOT NULL AUTO_INCREMENT", IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if (this._Id != value)
                {
                    this.OnIdChanging(value);
                    this.SendPropertyChanging("Id");
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Intitule in the schema.
        /// </summary>
        [Column(Name = @"intitule", Storage = "_Intitule", CanBeNull = false, DbType = "TEXT NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Intitule
        {
            get
            {
                return this._Intitule;
            }
            set
            {
                if (this._Intitule != value)
                {
                    this.OnIntituleChanging(value);
                    this.SendPropertyChanging("Intitule");
                    this._Intitule = value;
                    this.SendPropertyChanged("Intitule");
                    this.OnIntituleChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Personnels in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Fonction_Personnel", Storage="_Personnels", ThisKey="Id", OtherKey="IdFonction", DeleteRule="RESTRICT")]
        public EntitySet<Personnel> Personnels
        {
            get
            {
                return this._Personnels;
            }
            set
            {
                this._Personnels.Assign(value);
            }
        }
   
        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName) 
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void attach_Personnels(Personnel entity)
        {
            this.SendPropertyChanging("Personnels");
            entity.Fonction = this;
        }
    
        private void detach_Personnels(Personnel entity)
        {
            this.SendPropertyChanging("Personnels");
            entity.Fonction = null;
        }
    }

    /// <summary>
    /// There are no comments for BddpersonnelContext.Personnel in the schema.
    /// </summary>
    [Table(Name = @"bddpersonnels.personnels")]
    public partial class Personnel : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _Id;

        private string _Prenom;

        private string _Nom;

        private int _IdService;

        private int _IdFonction;

        private string _Telephone;

        private byte[] _Photo;
        #pragma warning restore 0649

        private EntityRef<Fonction> _Fonction;

        private EntityRef<Service> _Service;

        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnPrenomChanging(string value);
        partial void OnPrenomChanged();
        partial void OnNomChanging(string value);
        partial void OnNomChanged();
        partial void OnIdServiceChanging(int value);
        partial void OnIdServiceChanged();
        partial void OnIdFonctionChanging(int value);
        partial void OnIdFonctionChanged();
        partial void OnTelephoneChanging(string value);
        partial void OnTelephoneChanged();
        partial void OnPhotoChanging(byte[] value);
        partial void OnPhotoChanged();
        #endregion

        public Personnel()
        {
            this._Fonction  = default(EntityRef<Fonction>);
            this._Service  = default(EntityRef<Service>);
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        [Column(Name = @"id", Storage = "_Id", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "INT(11) NOT NULL AUTO_INCREMENT", IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if (this._Id != value)
                {
                    this.OnIdChanging(value);
                    this.SendPropertyChanging("Id");
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Prenom in the schema.
        /// </summary>
        [Column(Name = @"prenom", Storage = "_Prenom", CanBeNull = false, DbType = "TEXT NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Prenom
        {
            get
            {
                return this._Prenom;
            }
            set
            {
                if (this._Prenom != value)
                {
                    this.OnPrenomChanging(value);
                    this.SendPropertyChanging("Prenom");
                    this._Prenom = value;
                    this.SendPropertyChanged("Prenom");
                    this.OnPrenomChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Nom in the schema.
        /// </summary>
        [Column(Name = @"nom", Storage = "_Nom", CanBeNull = false, DbType = "TEXT NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Nom
        {
            get
            {
                return this._Nom;
            }
            set
            {
                if (this._Nom != value)
                {
                    this.OnNomChanging(value);
                    this.SendPropertyChanging("Nom");
                    this._Nom = value;
                    this.SendPropertyChanged("Nom");
                    this.OnNomChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for IdService in the schema.
        /// </summary>
        [Column(Name = @"idService", Storage = "_IdService", CanBeNull = false, DbType = "INT(11) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public int IdService
        {
            get
            {
                return this._IdService;
            }
            set
            {
                if (this._IdService != value)
                {
                    if (this._Service.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }

                    this.OnIdServiceChanging(value);
                    this.SendPropertyChanging("IdService");
                    this._IdService = value;
                    this.SendPropertyChanged("IdService");
                    this.OnIdServiceChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for IdFonction in the schema.
        /// </summary>
        [Column(Name = @"idFonction", Storage = "_IdFonction", CanBeNull = false, DbType = "INT(11) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public int IdFonction
        {
            get
            {
                return this._IdFonction;
            }
            set
            {
                if (this._IdFonction != value)
                {
                    if (this._Fonction.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }

                    this.OnIdFonctionChanging(value);
                    this.SendPropertyChanging("IdFonction");
                    this._IdFonction = value;
                    this.SendPropertyChanged("IdFonction");
                    this.OnIdFonctionChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Telephone in the schema.
        /// </summary>
        [Column(Name = @"telephone", Storage = "_Telephone", DbType = "TEXT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Telephone
        {
            get
            {
                return this._Telephone;
            }
            set
            {
                if (this._Telephone != value)
                {
                    this.OnTelephoneChanging(value);
                    this.SendPropertyChanging("Telephone");
                    this._Telephone = value;
                    this.SendPropertyChanged("Telephone");
                    this.OnTelephoneChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Photo in the schema.
        /// </summary>
        [Column(Name = @"photo", Storage = "_Photo", DbType = "BLOB NULL", UpdateCheck = UpdateCheck.Never)]
        public byte[] Photo
        {
            get
            {
                return this._Photo;
            }
            set
            {
                if (this._Photo != value)
                {
                    this.OnPhotoChanging(value);
                    this.SendPropertyChanging("Photo");
                    this._Photo = value;
                    this.SendPropertyChanged("Photo");
                    this.OnPhotoChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Fonction in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Fonction_Personnel", Storage="_Fonction", ThisKey="IdFonction", OtherKey="Id", IsForeignKey=true)]
        public Fonction Fonction
        {
            get
            {
                return this._Fonction.Entity;
            }
            set
            {
                Fonction previousValue = this._Fonction.Entity;
                if ((previousValue != value) || (this._Fonction.HasLoadedOrAssignedValue == false))
                {
                    this.SendPropertyChanging("Fonction");
                    if (previousValue != null)
                    {
                        this._Fonction.Entity = null;
                        previousValue.Personnels.Remove(this);
                    }
                    this._Fonction.Entity = value;
                    if (value != null)
                    {
                        this._IdFonction = value.Id;
                        value.Personnels.Add(this);
                    }
                    else
                    {
                        this._IdFonction = default(int);
                    }
                    this.SendPropertyChanged("Fonction");
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Service in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Service_Personnel", Storage="_Service", ThisKey="IdService", OtherKey="Id", IsForeignKey=true)]
        public Service Service
        {
            get
            {
                return this._Service.Entity;
            }
            set
            {
                Service previousValue = this._Service.Entity;
                if ((previousValue != value) || (this._Service.HasLoadedOrAssignedValue == false))
                {
                    this.SendPropertyChanging("Service");
                    if (previousValue != null)
                    {
                        this._Service.Entity = null;
                        previousValue.Personnels.Remove(this);
                    }
                    this._Service.Entity = value;
                    if (value != null)
                    {
                        this._IdService = value.Id;
                        value.Personnels.Add(this);
                    }
                    else
                    {
                        this._IdService = default(int);
                    }
                    this.SendPropertyChanged("Service");
                }
            }
        }
   
        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName) 
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// There are no comments for BddpersonnelContext.Service in the schema.
    /// </summary>
    [Table(Name = @"bddpersonnels.services")]
    public partial class Service : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _Id;

        private string _Intitule;
        #pragma warning restore 0649

        private EntitySet<Personnel> _Personnels;

        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnIntituleChanging(string value);
        partial void OnIntituleChanged();
        #endregion

        public Service()
        {
            this._Personnels = new EntitySet<Personnel>(new Action<Personnel>(this.attach_Personnels), new Action<Personnel>(this.detach_Personnels));
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        [Column(Name = @"id", Storage = "_Id", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "INT(11) NOT NULL AUTO_INCREMENT", IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if (this._Id != value)
                {
                    this.OnIdChanging(value);
                    this.SendPropertyChanging("Id");
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Intitule in the schema.
        /// </summary>
        [Column(Name = @"intitule", Storage = "_Intitule", CanBeNull = false, DbType = "TEXT NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Intitule
        {
            get
            {
                return this._Intitule;
            }
            set
            {
                if (this._Intitule != value)
                {
                    this.OnIntituleChanging(value);
                    this.SendPropertyChanging("Intitule");
                    this._Intitule = value;
                    this.SendPropertyChanged("Intitule");
                    this.OnIntituleChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Personnels in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Service_Personnel", Storage="_Personnels", ThisKey="Id", OtherKey="IdService", DeleteRule="RESTRICT")]
        public EntitySet<Personnel> Personnels
        {
            get
            {
                return this._Personnels;
            }
            set
            {
                this._Personnels.Assign(value);
            }
        }
   
        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName) 
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void attach_Personnels(Personnel entity)
        {
            this.SendPropertyChanging("Personnels");
            entity.Service = this;
        }
    
        private void detach_Personnels(Personnel entity)
        {
            this.SendPropertyChanging("Personnels");
            entity.Service = null;
        }
    }

    /// <summary>
    /// There are no comments for BddpersonnelContext.Gestionnaire in the schema.
    /// </summary>
    [Table(Name = @"bddpersonnels.gestionnaires")]
    public partial class Gestionnaire : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private string _Username;

        private string _Motdepasse;
        #pragma warning restore 0649

        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnUsernameChanging(string value);
        partial void OnUsernameChanged();
        partial void OnMotdepasseChanging(string value);
        partial void OnMotdepasseChanged();
        #endregion

        public Gestionnaire()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for Username in the schema.
        /// </summary>
        [Column(Name = @"username", Storage = "_Username", CanBeNull = false, DbType = "CHAR(32) NOT NULL", IsPrimaryKey = true)]
        public string Username
        {
            get
            {
                return this._Username;
            }
            set
            {
                if (this._Username != value)
                {
                    this.OnUsernameChanging(value);
                    this.SendPropertyChanging("Username");
                    this._Username = value;
                    this.SendPropertyChanged("Username");
                    this.OnUsernameChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Motdepasse in the schema.
        /// </summary>
        [Column(Name = @"motdepasse", Storage = "_Motdepasse", CanBeNull = false, DbType = "TEXT NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Motdepasse
        {
            get
            {
                return this._Motdepasse;
            }
            set
            {
                if (this._Motdepasse != value)
                {
                    this.OnMotdepasseChanging(value);
                    this.SendPropertyChanging("Motdepasse");
                    this._Motdepasse = value;
                    this.SendPropertyChanged("Motdepasse");
                    this.OnMotdepasseChanged();
                }
            }
        }
   
        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName) 
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
