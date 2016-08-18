using Microsoft.RESTier.Cli.Database;
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

        public DatabaseModelProjectBuilder(IProjectBuilder projectBuilder, DatabaseSetting dbSetting)
        {
            this._projectBuilder = projectBuilder;
            this._dbSetting = dbSetting;
           
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }
    }
}
