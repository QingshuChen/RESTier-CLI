namespace Microsoft.RESTier.Cli
{
    internal class DatabaseTableOrView
    {
        public DatabaseTableOrView(string catalogName, string schemaName, string name)
        {
            this.CatalogName = catalogName;
            this.SchemaName = schemaName;
            TableOrViewName = name;
        }

        public string CatalogName { get; set; }
        public string SchemaName { get; set; }
        public string TableOrViewName { get; set; }
    }
}