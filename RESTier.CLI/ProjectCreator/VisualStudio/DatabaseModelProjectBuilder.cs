using Microsoft.RESTier.Cli.Database;
using Microsoft.RESTier.Cli.ProjectCreator.VisualStudio.DatabaseConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.ProjectCreator.VisualStudio
{
    internal class DatabaseModelProjectCreator : IProjectCreator
    {
        private string _path;
        private IProjectCreator _projectCreator;
        private DatabaseSetting _dbSetting;
        private IDatabaseRelatedConfiguration _dbRelatedConfiguration;
        public string Name { get; set; }
        public string Namespace { get; set; }
        public string Path
        {
            get
            {
                return this._path;
            }
            set
            {
                this._path = System.IO.Path.Combine(value, this.Name);
            }
        }

        public DatabaseModelProjectCreator(IProjectCreator projectCreator, DatabaseSetting dbSetting, String connectionString)
        {
            this._projectCreator = projectCreator;
            this._dbSetting = dbSetting;
            this._dbRelatedConfiguration = DatabaseRelatedConfigurationFactory.Create(dbSetting.DBType);
            this._dbRelatedConfiguration.ProjectCreator = this;
            this._dbRelatedConfiguration.ConnectionString = connectionString;
            this.Name = projectCreator.Name;
            this.Namespace = projectCreator.Namespace;
            this._path = projectCreator.Path;
        }

        public bool Create()
        {
            if(!_projectCreator.Create())
                return false;
            if (!this._dbRelatedConfiguration.AddDatabaseRelatedPackages())
                return false;
            if (!this._dbRelatedConfiguration.AddDatabaseProvider())
                return false;
            if (!this._dbRelatedConfiguration.AddDatabaseModles())
                return false;
            if (!this._dbRelatedConfiguration.AddDatabaseRelatedCode())
                return false;
            if (!this._dbRelatedConfiguration.AddDatabaseConnectionString())
                return false;
            return true;
        }
    }
}
