namespace Microsoft.RESTier.Cli
{
    internal class Dependency
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string DownloadInstructionsUri { get; set; }
        public string DownloadInstallerUri { get; set; }
        public string InstallerExe { get; set; }
        public string InstallerArgs { get; set; }
    }
}