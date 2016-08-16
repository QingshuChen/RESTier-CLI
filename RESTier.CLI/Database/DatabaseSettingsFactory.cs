using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.Database
{
    public class DatabaseSettingsFactory
    {
        public static DatabaseSetting Create(String Name)
        {
            DatabaseSetting dbSetting = new DatabaseSetting();
            if (Name.ToUpper().Equals("SQLSERVER"))
            {
                dbSetting.Name = "SQLServer";
                dbSetting.ProviderInvariantName = ConfigurationManager.AppSettings["SQLServerProviderInvariantName"];
                dbSetting.ProviderType = ConfigurationManager.AppSettings["SQLServerProviderType"];
                return dbSetting;
            }
            else if (Name.ToUpper().Equals("MYSQL"))
            {
                dbSetting.Name = "MYSQL";
                dbSetting.ProviderInvariantName = ConfigurationManager.AppSettings["MYSQLProviderInvariantName"];
                dbSetting.ProviderType = ConfigurationManager.AppSettings["MYSQLProviderType"];
                return dbSetting;
            }
            return null;
        }
    }
}
