using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using Microsoft.Data.Entity.Design.VersioningFacade;
using Microsoft.Data.Entity.Design.VersioningFacade.ReverseEngineerDb;
using Microsoft.RESTier.Cli.Database;

namespace Microsoft.RESTier.Cli.ProjectBuilder.CodeGeneration.EFCodeGeneration
{
    /// <summary>
    ///     Management for the SQLServer database
    /// </summary>
    internal class DatabaseManager
    {
        private const string SelectTablesESqlQuery = @"
            SELECT 
                t.CatalogName
            ,   t.SchemaName                    
            ,   t.Name
            FROM
                SchemaInformation.Tables as t
            ORDER BY
                t.SchemaName
            ,   t.Name
            ";

        private const string SelectViewESqlQuery = @"
            SELECT 
                t.CatalogName
            ,   t.SchemaName
            ,   t.Name
            FROM
                SchemaInformation.Views as t
            ORDER BY
                t.SchemaName
            ,   t.Name
            ";
        // the connection string of the SQLServer database
        private readonly string connectionString;

        // the latest EntityFramework version in EntityFrameworkVersion class
        private readonly Version maxVersion = new Version(3, 0, 0, 0);
        private EntityConnection ec;
        private DatabaseSetting _dbSetting;

        public DatabaseManager(string connectionString, DatabaseSetting dbSetting)
        {
            this.connectionString = connectionString;
            this._dbSetting = dbSetting;
        }


        /// <summary>
        ///     Connect to the database figured out by the connection string
        /// </summary>
        /// <returns>true for success and false for failure</returns>
        public bool connect()
        {
            try
            {
                Version actualEntityFrameworkConnectionVersion;
                ec = new StoreSchemaConnectionFactory().Create(
                    DependencyResolver.Instance,
                    _dbSetting.ProviderInvariantName,
                    connectionString,
                    maxVersion,
                    out actualEntityFrameworkConnectionVersion);
                ec.Open();
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteLine(ConsoleColor.Red, "Can't connect to the database with the connection string: '{0}'", connectionString);
                if (ex.InnerException != null)
                    ConsoleHelper.WriteLine(ConsoleColor.Red, ex.InnerException.Message);
                else
                    ConsoleHelper.WriteLine(ConsoleColor.Red, ex.Message);
                return false;
            }
            return true;
        }


        /// <summary>
        ///     Get the name of the database figured out by the connection string
        /// </summary>
        /// <returns>
        ///     return the name of the database figured out by the connection string,
        ///     return null if the database can not be connected by the connection string
        /// </returns>
        public string GetDatabaseName()
        {
            if (!string.IsNullOrEmpty(ec.Database))
                return ignorePrefixPathAndSuffix(ec.Database);
            if (ec.StoreConnection != null && !string.IsNullOrEmpty(ec.StoreConnection.Database))
                return ignorePrefixPathAndSuffix(ec.StoreConnection.Database);
            return null;
        }

        /// <summary>
        ///     get all tables in the database
        /// </summary>
        /// <returns>return all tables in the database</returns>
        public ArrayList GetDatabaseTables()
        {
            return GetTablesOrViews(SelectTablesESqlQuery);
        }

        /// <summary>
        ///     get all views in the database
        /// </summary>
        /// <returns>return all views in the database</returns>
        public ArrayList GetDatabaseViews()
        {
            return GetTablesOrViews(SelectViewESqlQuery);
        }

        private ArrayList GetTablesOrViews(string sqlStr)
        {
            var items = new ArrayList();

            using (var command = new EntityCommand(null, ec, DependencyResolver.Instance))
            {
                command.CommandType = CommandType.Text;
                command.CommandText = sqlStr;
                DbDataReader reader = null;
                try
                {
                    reader = command.ExecuteReader(CommandBehavior.SequentialAccess);
                    while (reader.Read())
                    {
                        if (reader.FieldCount == 3)
                        {
                            // the types coming back through the reader may not be a string 
                            // (eg, SqlCE returns System.DbNull for catalogName & schemaName), so cast carefully
                            var catalogName = reader.GetValue(0) as string;
                            var schemaName = reader.GetValue(1) as string;
                            var name = reader.GetValue(2) as string;

                            if (string.IsNullOrEmpty(name) == false)
                            {
                                items.Add(new Tuple<string, string, string>(catalogName, schemaName, name));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (reader != null)
                    {
                        try
                        {
                            reader.Close();
                            reader.Dispose();
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            return items;
        }


        // Get the file name from a path by ignoring the prefix directory and suffix file type
        private string ignorePrefixPathAndSuffix(string path)
        {
            if (string.IsNullOrEmpty(path))
                return path;
            var lastSlashIndex = path.LastIndexOf('\\');
            var lastDotIndex = path.LastIndexOf('.');
            if (lastDotIndex == -1)
                lastDotIndex = path.Length;
            lastSlashIndex++;
            if (lastSlashIndex > lastDotIndex)
                return path.Substring(lastSlashIndex);
            if (lastSlashIndex == lastDotIndex)
                return "";
            return path.Substring(lastSlashIndex, lastDotIndex - lastSlashIndex);
        }
    }
}