using Microsoft.RESTier.Cli.Database;
using Microsoft.RESTier.Cli.ProjectBuilder.VisualStudio.DatabaseConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.ProjectBuilder.VisualStudio
{
    internal class DatabaseModelProjectBuilder : IProjectBuilder
    {
        private string _path;
        private IProjectBuilder _projectBuilder;
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

        public DatabaseModelProjectBuilder(IProjectBuilder projectBuilder, DatabaseSetting dbSetting, String connectionString)
        {
            this._projectBuilder = projectBuilder;
            this._dbSetting = dbSetting;
            this._dbRelatedConfiguration = DatabaseRelatedConfigurationFactory.Create(dbSetting.DBType);
            this._dbRelatedConfiguration.ProjectBuilder = this;
            this._dbRelatedConfiguration.ConnectionString = connectionString;
            this.Name = projectBuilder.Name;
            this.Namespace = projectBuilder.Namespace;
            this._path = projectBuilder.Path;
        }

        public bool Create()
        {
            _projectBuilder.Create();
            this._dbRelatedConfiguration.AddDatabaseRelatedPackages();
            this._dbRelatedConfiguration.AddDatabaseProvider();
            this._dbRelatedConfiguration.AddDatabaseModles();
            this._dbRelatedConfiguration.AddDatabaseRelatedCode();
            this._dbRelatedConfiguration.AddDatabaseConnectionString();
            return true;
        }
    }
}
