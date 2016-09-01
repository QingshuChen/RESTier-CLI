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
                dbSetting.DBType = DatabaseType.SQLServer;
                dbSetting.Name = "SQLServer";
                dbSetting.ProviderInvariantName = ConfigurationManager.AppSettings["SQLServerProviderInvariantName"];
                dbSetting.ProviderType = ConfigurationManager.AppSettings["SQLServerProviderType"];
                dbSetting.Packages = new System.Collections.ArrayList();
                dbSetting.Packages.Add(new Tuple<string, string, string>("MySql.Data", "7.0.3-DMR", "net452"));
                dbSetting.Packages.Add(new Tuple<string, string, string>("MySql.Data.Entity", "7.0.3-DMR", "net452"));
                dbSetting.Packages.Add(new Tuple<string, string, string>("EntityFramework", "6.1.3", "net452"));
                dbSetting.References = new System.Collections.ArrayList();
                dbSetting.References.Add(new Tuple<string, string, string>(
                    "EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089, processorArchitecture=MSIL",
                    @"..\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.dll",
                    "True"));
                return dbSetting;
            }
            else if (Name.ToUpper().Equals("MYSQL"))
            {
                dbSetting.DBType = DatabaseType.MYSQL;
                dbSetting.Name = "MYSQL";
                dbSetting.ProviderInvariantName = ConfigurationManager.AppSettings["MYSQLProviderInvariantName"];
                dbSetting.ProviderType = ConfigurationManager.AppSettings["MYSQLProviderType"];
                dbSetting.Packages = new System.Collections.ArrayList();
                dbSetting.Packages.Add(new Tuple<string, string, string>("EntityFramework", "6.1.3", "net452"));
                dbSetting.References = new System.Collections.ArrayList();
                dbSetting.References.Add(new Tuple<string, string, string>(
                    "MySql.Data, Version = 7.0.3.0, Culture = neutral, PublicKeyToken = c5687fc88969c44d, processorArchitecture = MSIL",
                    @"..\packages\MySql.Data.7.0.3-DMR\lib\net45\MySql.Data.dll",
                    "True"));
                dbSetting.References.Add(new Tuple<string, string, string>(
                    "MySql.Data.Entity.EF6, Version=7.0.3.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d, processorArchitecture=MSIL",
                    @"..\packages\MySql.Data.Entity.7.0.3-DMR\lib\net45\MySql.Data.Entity.EF6.dll",
                    "True"));
                dbSetting.References.Add(new Tuple<string, string, string>(
                    "EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089, processorArchitecture=MSIL",
                    @"..\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.dll",
                    "True"));
                return dbSetting;
            }
            return null;
        }
    }
}
