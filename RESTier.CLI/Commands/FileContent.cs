using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.Commands
{
    class FileContent
    {
        public static string solutionFileContent = @"Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 14
VisualStudioVersion = 14.0.25420.1
MinimumVisualStudioVersion = 10.0.40219.1
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""{0}"", ""{0}\{0}.csproj"", ""{B07B6E14-B039-49B9-8C8C-3F63F3A7F0AE}""
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{B07B6E14-B039-49B9-8C8C-3F63F3A7F0AE}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{B07B6E14-B039-49B9-8C8C-3F63F3A7F0AE}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{B07B6E14-B039-49B9-8C8C-3F63F3A7F0AE}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{B07B6E14-B039-49B9-8C8C-3F63F3A7F0AE}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
EndGlobal
";

        public static string webApiConfigFileContent = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using {0}.Models;
using Microsoft.Restier.Providers.EntityFramework;
using Microsoft.Restier.Publishers.OData;
using Microsoft.Restier.Publishers.OData.Batch;
using Microsoft.Restier.Publishers.OData.Routing;
using Microsoft.OData.Core;
using Microsoft.OData.Edm;
using Microsoft.OData.Core.UriBuilder;
using Microsoft.OData.Core.UriParser;
using Microsoft.OData.Core.Atom;
using System.Web.OData.Extensions;

namespace {0}
{
    public static class WebApiConfig
    {
        public async static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.SetUrlConventions(ODataUrlConventions.ODataSimplified);
            await config.MapRestierRoute<EntityFrameworkApi<{1}DbContext>>(
                ""{1}"",
                """",
                new RestierBatchHandler(GlobalConfiguration.DefaultServer));

        }
}
}
";

        public static string assemblyInfoFileContent = @"using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle(""TempleteProject"")]
[assembly: AssemblyDescription("""")]
[assembly: AssemblyConfiguration("""")]
[assembly: AssemblyCompany("""")]
[assembly: AssemblyProduct(""TempleteProject"")]
[assembly: AssemblyCopyright(""Copyright ©  2016"")]
[assembly: AssemblyTrademark("""")]
[assembly: AssemblyCulture("""")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid(""b07b6e14-b039-49b9-8c8c-3f63f3a7f0ae"")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion(""1.0.0.0"")]
[assembly: AssemblyFileVersion(""1.0.0.0"")]
";

        public static string applicationhostConfigFileContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<!--

    IIS configuration sections.

    For schema documentation, see
    %IIS_BIN%\config\schema\IIS_schema.xml.
    
    Please make a backup of this file before making any changes to it.

    NOTE: The following environment variables are available to be used
          within this file and are understood by the IIS Express.

          %IIS_USER_HOME% - The IIS Express home directory for the user
          %IIS_SITES_HOME% - The default home directory for sites
          %IIS_BIN% - The location of the IIS Express binaries
          %SYSTEMDRIVE% - The drive letter of %IIS_BIN%

-->
<configuration>
  <!--

        The <configSections> section controls the registration of sections.
        Section is the basic unit of deployment, locking, searching and
        containment for configuration settings.
        
        Every section belongs to one section group.
        A section group is a container of logically-related sections.
        
        Sections cannot be nested.
        Section groups may be nested.
        
        <section
            name=""""  [Required, Collection Key] [XML name of the section]
            allowDefinition=""Everywhere"" [MachineOnly|MachineToApplication|AppHostOnly|Everywhere] [Level where it can be set]
            overrideModeDefault=""Allow""  [Allow|Deny] [Default delegation mode]
            allowLocation=""true""  [true|false] [Allowed in location tags]
        />
        
        The recommended way to unlock sections is by using a location tag:
        <location path=""Default Web Site"" overrideMode=""Allow"">
            <system.webServer>
                <asp />
            </system.webServer>
        </location>

    -->
  <configSections>
    <sectionGroup name=""system.applicationHost"">
      <section name=""applicationPools"" allowDefinition=""AppHostOnly"" overrideModeDefault=""Deny"" />
      <section name=""configHistory"" allowDefinition=""AppHostOnly"" overrideModeDefault=""Deny"" />
      <section name=""customMetadata"" allowDefinition=""AppHostOnly"" overrideModeDefault=""Deny"" />
      <section name=""listenerAdapters"" allowDefinition=""AppHostOnly"" overrideModeDefault=""Deny"" />
      <section name=""log"" allowDefinition=""AppHostOnly"" overrideModeDefault=""Deny"" />
      <section name=""serviceAutoStartProviders"" allowDefinition=""AppHostOnly"" overrideModeDefault=""Deny"" />
      <section name=""sites"" allowDefinition=""AppHostOnly"" overrideModeDefault=""Deny"" />
      <section name=""webLimits"" allowDefinition=""AppHostOnly"" overrideModeDefault=""Deny"" />
    </sectionGroup>
    <sectionGroup name=""system.webServer"">
      <section name=""asp"" overrideModeDefault=""Deny"" />
      <section name=""caching"" overrideModeDefault=""Allow"" />
      <section name=""cgi"" overrideModeDefault=""Deny"" />
      <section name=""defaultDocument"" overrideModeDefault=""Allow"" />
      <section name=""directoryBrowse"" overrideModeDefault=""Allow"" />
      <section name=""fastCgi"" allowDefinition=""AppHostOnly"" overrideModeDefault=""Deny"" />
      <section name=""globalModules"" allowDefinition=""AppHostOnly"" overrideModeDefault=""Deny"" />
      <section name=""handlers"" overrideModeDefault=""Deny"" />
      <section name=""httpCompression"" overrideModeDefault=""Allow"" />
      <section name=""httpErrors"" overrideModeDefault=""Allow"" />
      <section name=""httpLogging"" overrideModeDefault=""Deny"" />
      <section name=""httpProtocol"" overrideModeDefault=""Allow"" />
      <section name=""httpRedirect"" overrideModeDefault=""Allow"" />
      <section name=""httpTracing"" overrideModeDefault=""Deny"" />
      <section name=""isapiFilters"" allowDefinition=""MachineToApplication"" overrideModeDefault=""Deny"" />
      <section name=""modules"" allowDefinition=""MachineToApplication"" overrideModeDefault=""Deny"" />
      <section name=""applicationInitialization"" allowDefinition=""MachineToApplication"" overrideModeDefault=""Allow"" />
      <section name=""odbcLogging"" overrideModeDefault=""Deny"" />
      <sectionGroup name=""security"">
        <section name=""access"" overrideModeDefault=""Deny"" />
        <section name=""applicationDependencies"" overrideModeDefault=""Deny"" />
        <sectionGroup name=""authentication"">
          <section name=""anonymousAuthentication"" overrideModeDefault=""Deny"" />
          <section name=""basicAuthentication"" overrideModeDefault=""Deny"" />
          <section name=""clientCertificateMappingAuthentication"" overrideModeDefault=""Deny"" />
          <section name=""digestAuthentication"" overrideModeDefault=""Deny"" />
          <section name=""iisClientCertificateMappingAuthentication"" overrideModeDefault=""Deny"" />
          <section name=""windowsAuthentication"" overrideModeDefault=""Deny"" />
        </sectionGroup>
        <section name=""authorization"" overrideModeDefault=""Allow"" />
        <section name=""ipSecurity"" overrideModeDefault=""Deny"" />
        <section name=""dynamicIpSecurity"" overrideModeDefault=""Deny"" />
        <section name=""isapiCgiRestriction"" allowDefinition=""AppHostOnly"" overrideModeDefault=""Deny"" />
        <section name=""requestFiltering"" overrideModeDefault=""Allow"" />
      </sectionGroup>
      <section name=""serverRuntime"" overrideModeDefault=""Deny"" />
      <section name=""serverSideInclude"" overrideModeDefault=""Deny"" />
      <section name=""staticContent"" overrideModeDefault=""Allow"" />
      <sectionGroup name=""tracing"">
        <section name=""traceFailedRequests"" overrideModeDefault=""Allow"" />
        <section name=""traceProviderDefinitions"" overrideModeDefault=""Deny"" />
      </sectionGroup>
      <section name=""urlCompression"" overrideModeDefault=""Allow"" />
      <section name=""validation"" overrideModeDefault=""Allow"" />
      <sectionGroup name=""webdav"">
        <section name=""globalSettings"" overrideModeDefault=""Deny"" />
        <section name=""authoring"" overrideModeDefault=""Deny"" />
        <section name=""authoringRules"" overrideModeDefault=""Deny"" />
      </sectionGroup>
      <sectionGroup name=""rewrite"">
        <section name=""allowedServerVariables"" overrideModeDefault=""Deny"" />
        <section name=""rules"" overrideModeDefault=""Allow"" />
        <section name=""outboundRules"" overrideModeDefault=""Allow"" />
        <section name=""globalRules"" overrideModeDefault=""Deny"" allowDefinition=""AppHostOnly"" />
        <section name=""providers"" overrideModeDefault=""Allow"" />
        <section name=""rewriteMaps"" overrideModeDefault=""Allow"" />
      </sectionGroup>
      <section name=""webSocket"" overrideModeDefault=""Deny"" />
      <section name=""aspNetCore"" overrideModeDefault=""Allow"" />
    </sectionGroup>
  </configSections>
  <configProtectedData>
    <providers>
      <add name=""IISWASOnlyRsaProvider"" type="""" description=""Uses RsaCryptoServiceProvider to encrypt and decrypt"" keyContainerName=""iisWasKey"" cspProviderName="""" useMachineContainer=""true"" useOAEP=""false"" />
      <add name=""AesProvider"" type=""Microsoft.ApplicationHost.AesProtectedConfigurationProvider"" description=""Uses an AES session key to encrypt and decrypt"" keyContainerName=""iisConfigurationKey"" cspProviderName="""" useOAEP=""false"" useMachineContainer=""true"" sessionKey=""AQIAAA5mAAAApAAAKmFQvWHDEETRz8l2bjZlRxIkwcqTFaCUnCLljn3Q1OkesrhEO9YyLyx4bUhsj1/DyShAv7OAFFhXlrlomaornnk5PLeyO4lIXxaiT33yOFUUgxDx4GSaygkqghVV0tO5yQ/XguUBp2juMfZyztnsNa4pLcz7ZNZQ6p4yn9hxwNs="" />
      <add name=""IISWASOnlyAesProvider"" type=""Microsoft.ApplicationHost.AesProtectedConfigurationProvider"" description=""Uses an AES session key to encrypt and decrypt"" keyContainerName=""iisWasKey"" cspProviderName="""" useOAEP=""false"" useMachineContainer=""true"" sessionKey=""AQIAAA5mAAAApAAA4WoiRJ8KHwzAG8AgejPxEOO4/2Vhkolbwo/8gZeNdUDSD36m55hWv4uC9tr/MlKdnwRLL0NhT50Gccyftqz5xTZ0dg5FtvQhTw/he1NwexTKbV+I4Zrd+sZUqHZTsr7JiEr6OHGXL70qoISW5G2m9U8wKT3caPiDPNj2aAaYPLo="" />
    </providers>
  </configProtectedData>
  <system.applicationHost>
    <applicationPools>
      <add name=""Clr4IntegratedAppPool"" managedRuntimeVersion=""v4.0"" managedPipelineMode=""Integrated"" CLRConfigFile=""%IIS_USER_HOME%\config\aspnet.config"" autoStart=""true"" />
      <add name=""Clr4ClassicAppPool"" managedRuntimeVersion=""v4.0"" managedPipelineMode=""Classic"" CLRConfigFile=""%IIS_USER_HOME%\config\aspnet.config"" autoStart=""true"" />
      <add name=""Clr2IntegratedAppPool"" managedRuntimeVersion=""v2.0"" managedPipelineMode=""Integrated"" CLRConfigFile=""%IIS_USER_HOME%\config\aspnet.config"" autoStart=""true"" />
      <add name=""Clr2ClassicAppPool"" managedRuntimeVersion=""v2.0"" managedPipelineMode=""Classic"" CLRConfigFile=""%IIS_USER_HOME%\config\aspnet.config"" autoStart=""true"" />
      <add name=""UnmanagedClassicAppPool"" managedRuntimeVersion="""" managedPipelineMode=""Classic"" autoStart=""true"" />
      <applicationPoolDefaults managedRuntimeLoader=""v4.0"">
        <processModel />
      </applicationPoolDefaults>
    </applicationPools>
    <!--

          The <listenerAdapters> section defines the protocols with which the
          Windows Process Activation Service (WAS) binds.

        -->
    <listenerAdapters>
      <add name=""http"" />
    </listenerAdapters>
    <sites>
      <site name=""{0}"" id=""2"">
        <application path=""/"" applicationPool=""Clr4IntegratedAppPool"">
          <virtualDirectory path=""/"" physicalPath=""{1}"" />
        </application>
        <bindings>
          <binding protocol=""http"" bindingInformation=""*:3447:localhost"" />
        </bindings>
      </site>
      <siteDefaults>
        <logFile logFormat=""W3C"" directory=""%IIS_USER_HOME%\Logs"" />
        <traceFailedRequestsLogging directory=""%IIS_USER_HOME%\TraceLogFiles"" enabled=""true"" maxLogFileSizeKB=""1024"" />
      </siteDefaults>
      <applicationDefaults applicationPool=""Clr4IntegratedAppPool"" />
      <virtualDirectoryDefaults allowSubDirConfig=""true"" />
    </sites>
    <webLimits />
  </system.applicationHost>
  <system.webServer>
    <serverRuntime />
    <asp scriptErrorSentToBrowser=""true"">
      <cache diskTemplateCacheDirectory=""%TEMP%\iisexpress\ASP Compiled Templates"" />
      <limits />
    </asp>
    <caching enabled=""true"" enableKernelCache=""true"">
    </caching>
    <cgi />
    <defaultDocument enabled=""true"">
      <files>
        <add value=""Default.htm"" />
        <add value=""Default.asp"" />
        <add value=""index.htm"" />
        <add value=""index.html"" />
        <add value=""iisstart.htm"" />
        <add value=""default.aspx"" />
      </files>
    </defaultDocument>
    <directoryBrowse enabled=""false"" />
    <fastCgi />
    <!--

          The <globalModules> section defines all native-code modules.
          To enable a module, specify it in the <modules> section.

        -->
    <globalModules>
      <add name=""HttpLoggingModule"" image=""%IIS_BIN%\loghttp.dll"" />
      <add name=""UriCacheModule"" image=""%IIS_BIN%\cachuri.dll"" />
      <!--            <add name=""FileCacheModule"" image=""%IIS_BIN%\cachfile.dll"" />  -->
      <add name=""TokenCacheModule"" image=""%IIS_BIN%\cachtokn.dll"" />
      <!--            <add name=""HttpCacheModule"" image=""%IIS_BIN%\cachhttp.dll"" /> -->
      <add name=""DynamicCompressionModule"" image=""%IIS_BIN%\compdyn.dll"" />
      <add name=""StaticCompressionModule"" image=""%IIS_BIN%\compstat.dll"" />
      <add name=""DefaultDocumentModule"" image=""%IIS_BIN%\defdoc.dll"" />
      <add name=""DirectoryListingModule"" image=""%IIS_BIN%\dirlist.dll"" />
      <add name=""ProtocolSupportModule"" image=""%IIS_BIN%\protsup.dll"" />
      <add name=""HttpRedirectionModule"" image=""%IIS_BIN%\redirect.dll"" />
      <add name=""ServerSideIncludeModule"" image=""%IIS_BIN%\iis_ssi.dll"" />
      <add name=""StaticFileModule"" image=""%IIS_BIN%\static.dll"" />
      <add name=""AnonymousAuthenticationModule"" image=""%IIS_BIN%\authanon.dll"" />
      <add name=""CertificateMappingAuthenticationModule"" image=""%IIS_BIN%\authcert.dll"" />
      <add name=""UrlAuthorizationModule"" image=""%IIS_BIN%\urlauthz.dll"" />
      <add name=""BasicAuthenticationModule"" image=""%IIS_BIN%\authbas.dll"" />
      <add name=""WindowsAuthenticationModule"" image=""%IIS_BIN%\authsspi.dll"" />
      <!--            <add name=""DigestAuthenticationModule"" image=""%IIS_BIN%\authmd5.dll"" /> -->
      <add name=""IISCertificateMappingAuthenticationModule"" image=""%IIS_BIN%\authmap.dll"" />
      <add name=""IpRestrictionModule"" image=""%IIS_BIN%\iprestr.dll"" />
      <add name=""DynamicIpRestrictionModule"" image=""%IIS_BIN%\diprestr.dll"" />
      <add name=""RequestFilteringModule"" image=""%IIS_BIN%\modrqflt.dll"" />
      <add name=""CustomLoggingModule"" image=""%IIS_BIN%\logcust.dll"" />
      <add name=""CustomErrorModule"" image=""%IIS_BIN%\custerr.dll"" />
      <!--            <add name=""TracingModule"" image=""%IIS_BIN%\iisetw.dll"" /> -->
      <add name=""FailedRequestsTracingModule"" image=""%IIS_BIN%\iisfreb.dll"" />
      <add name=""RequestMonitorModule"" image=""%IIS_BIN%\iisreqs.dll"" />
      <add name=""IsapiModule"" image=""%IIS_BIN%\isapi.dll"" />
      <add name=""IsapiFilterModule"" image=""%IIS_BIN%\filter.dll"" />
      <add name=""CgiModule"" image=""%IIS_BIN%\cgi.dll"" />
      <add name=""FastCgiModule"" image=""%IIS_BIN%\iisfcgi.dll"" />
      <!--            <add name=""WebDAVModule"" image=""%IIS_BIN%\webdav.dll"" /> -->
      <add name=""RewriteModule"" image=""%IIS_BIN%\rewrite.dll"" />
      <add name=""ConfigurationValidationModule"" image=""%IIS_BIN%\validcfg.dll"" />
      <add name=""WebSocketModule"" image=""%IIS_BIN%\iiswsock.dll"" />
      <add name=""WebMatrixSupportModule"" image=""%IIS_BIN%\webmatrixsup.dll"" />
      <add name=""ManagedEngine"" image=""%windir%\Microsoft.NET\Framework\v2.0.50727\webengine.dll"" preCondition=""integratedMode,runtimeVersionv2.0,bitness32"" />
      <add name=""ManagedEngine64"" image=""%windir%\Microsoft.NET\Framework64\v2.0.50727\webengine.dll"" preCondition=""integratedMode,runtimeVersionv2.0,bitness64"" />
      <add name=""ManagedEngineV4.0_32bit"" image=""%windir%\Microsoft.NET\Framework\v4.0.30319\webengine4.dll"" preCondition=""integratedMode,runtimeVersionv4.0,bitness32"" />
      <add name=""ManagedEngineV4.0_64bit"" image=""%windir%\Microsoft.NET\Framework64\v4.0.30319\webengine4.dll"" preCondition=""integratedMode,runtimeVersionv4.0,bitness64"" />
      <add name=""ApplicationInitializationModule"" image=""%IIS_BIN%\warmup.dll"" />
      <add name=""AspNetCoreModule"" image=""%IIS_BIN%\aspnetcore.dll"" />
    </globalModules>
    <httpCompression directory=""%TEMP%\iisexpress\IIS Temporary Compressed Files"">
      <scheme name=""gzip"" dll=""%IIS_BIN%\gzip.dll"" />
      <dynamicTypes>
        <add mimeType=""text/*"" enabled=""true"" />
        <add mimeType=""message/*"" enabled=""true"" />
        <add mimeType=""application/javascript"" enabled=""true"" />
        <add mimeType=""application/atom+xml"" enabled=""true"" />
        <add mimeType=""application/xaml+xml"" enabled=""true"" />
        <add mimeType=""*/*"" enabled=""false"" />
      </dynamicTypes>
      <staticTypes>
        <add mimeType=""text/*"" enabled=""true"" />
        <add mimeType=""message/*"" enabled=""true"" />
        <add mimeType=""image/svg+xml"" enabled=""true"" />
        <add mimeType=""application/javascript"" enabled=""true"" />
        <add mimeType=""application/atom+xml"" enabled=""true"" />
        <add mimeType=""application/xaml+xml"" enabled=""true"" />
        <add mimeType=""*/*"" enabled=""false"" />
      </staticTypes>
    </httpCompression>
    <httpErrors lockAttributes=""allowAbsolutePathsWhenDelegated,defaultPath"">
      <error statusCode=""401"" prefixLanguageFilePath=""%IIS_BIN%\custerr"" path=""401.htm"" />
      <error statusCode=""403"" prefixLanguageFilePath=""%IIS_BIN%\custerr"" path=""403.htm"" />
      <error statusCode=""404"" prefixLanguageFilePath=""%IIS_BIN%\custerr"" path=""404.htm"" />
      <error statusCode=""405"" prefixLanguageFilePath=""%IIS_BIN%\custerr"" path=""405.htm"" />
      <error statusCode=""406"" prefixLanguageFilePath=""%IIS_BIN%\custerr"" path=""406.htm"" />
      <error statusCode=""412"" prefixLanguageFilePath=""%IIS_BIN%\custerr"" path=""412.htm"" />
      <error statusCode=""500"" prefixLanguageFilePath=""%IIS_BIN%\custerr"" path=""500.htm"" />
      <error statusCode=""501"" prefixLanguageFilePath=""%IIS_BIN%\custerr"" path=""501.htm"" />
      <error statusCode=""502"" prefixLanguageFilePath=""%IIS_BIN%\custerr"" path=""502.htm"" />
    </httpErrors>
    <httpLogging dontLog=""false"" />
    <httpProtocol>
      <customHeaders>
        <clear />
        <add name=""X-Powered-By"" value=""ASP.NET"" />
      </customHeaders>
      <redirectHeaders>
        <clear />
      </redirectHeaders>
    </httpProtocol>
    <httpRedirect enabled=""false"" />
    <httpTracing>
    </httpTracing>
    <isapiFilters>
      <filter name=""ASP.Net_2.0.50727-64"" path=""%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_filter.dll"" enableCache=""true"" preCondition=""bitness64,runtimeVersionv2.0"" />
      <filter name=""ASP.Net_2.0.50727.0"" path=""%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_filter.dll"" enableCache=""true"" preCondition=""bitness32,runtimeVersionv2.0"" />
      <filter name=""ASP.Net_2.0_for_v1.1"" path=""%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_filter.dll"" enableCache=""true"" preCondition=""runtimeVersionv1.1"" />
      <filter name=""ASP.Net_4.0_32bit"" path=""%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_filter.dll"" enableCache=""true"" preCondition=""bitness32,runtimeVersionv4.0"" />
      <filter name=""ASP.Net_4.0_64bit"" path=""%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_filter.dll"" enableCache=""true"" preCondition=""bitness64,runtimeVersionv4.0"" />
    </isapiFilters>
    <odbcLogging />
    <security>
      <access sslFlags=""None"" />
      <applicationDependencies>
        <application name=""Active Server Pages"" groupId=""ASP"" />
      </applicationDependencies>
      <authentication>
        <anonymousAuthentication enabled=""true"" userName="""" />
        <basicAuthentication enabled=""false"" />
        <clientCertificateMappingAuthentication enabled=""false"" />
        <digestAuthentication enabled=""false"" />
        <iisClientCertificateMappingAuthentication enabled=""false"">
        </iisClientCertificateMappingAuthentication>
        <windowsAuthentication enabled=""false"">
          <providers>
            <add value=""Negotiate"" />
            <add value=""NTLM"" />
          </providers>
        </windowsAuthentication>
      </authentication>
      <authorization>
        <add accessType=""Allow"" users=""*"" />
      </authorization>
      <ipSecurity allowUnlisted=""true"" />
      <isapiCgiRestriction notListedIsapisAllowed=""true"" notListedCgisAllowed=""true"">
        <add path=""%windir%\Microsoft.NET\Framework64\v4.0.30319\webengine4.dll"" allowed=""true"" groupId=""ASP.NET_v4.0"" description=""ASP.NET_v4.0"" />
        <add path=""%windir%\Microsoft.NET\Framework\v4.0.30319\webengine4.dll"" allowed=""true"" groupId=""ASP.NET_v4.0"" description=""ASP.NET_v4.0"" />
        <add path=""%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll"" allowed=""true"" groupId=""ASP.NET v2.0.50727"" description=""ASP.NET v2.0.50727"" />
        <add path=""%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll"" allowed=""true"" groupId=""ASP.NET v2.0.50727"" description=""ASP.NET v2.0.50727"" />
      </isapiCgiRestriction>
      <requestFiltering>
        <fileExtensions allowUnlisted=""true"" applyToWebDAV=""true"">
          <add fileExtension="".asa"" allowed=""false"" />
          <add fileExtension="".asax"" allowed=""false"" />
          <add fileExtension="".ascx"" allowed=""false"" />
          <add fileExtension="".master"" allowed=""false"" />
          <add fileExtension="".skin"" allowed=""false"" />
          <add fileExtension="".browser"" allowed=""false"" />
          <add fileExtension="".sitemap"" allowed=""false"" />
          <add fileExtension="".config"" allowed=""false"" />
          <add fileExtension="".cs"" allowed=""false"" />
          <add fileExtension="".csproj"" allowed=""false"" />
          <add fileExtension="".vb"" allowed=""false"" />
          <add fileExtension="".vbproj"" allowed=""false"" />
          <add fileExtension="".webinfo"" allowed=""false"" />
          <add fileExtension="".licx"" allowed=""false"" />
          <add fileExtension="".resx"" allowed=""false"" />
          <add fileExtension="".resources"" allowed=""false"" />
          <add fileExtension="".mdb"" allowed=""false"" />
          <add fileExtension="".vjsproj"" allowed=""false"" />
          <add fileExtension="".java"" allowed=""false"" />
          <add fileExtension="".jsl"" allowed=""false"" />
          <add fileExtension="".ldb"" allowed=""false"" />
          <add fileExtension="".dsdgm"" allowed=""false"" />
          <add fileExtension="".ssdgm"" allowed=""false"" />
          <add fileExtension="".lsad"" allowed=""false"" />
          <add fileExtension="".ssmap"" allowed=""false"" />
          <add fileExtension="".cd"" allowed=""false"" />
          <add fileExtension="".dsprototype"" allowed=""false"" />
          <add fileExtension="".lsaprototype"" allowed=""false"" />
          <add fileExtension="".sdm"" allowed=""false"" />
          <add fileExtension="".sdmDocument"" allowed=""false"" />
          <add fileExtension="".mdf"" allowed=""false"" />
          <add fileExtension="".ldf"" allowed=""false"" />
          <add fileExtension="".ad"" allowed=""false"" />
          <add fileExtension="".dd"" allowed=""false"" />
          <add fileExtension="".ldd"" allowed=""false"" />
          <add fileExtension="".sd"" allowed=""false"" />
          <add fileExtension="".adprototype"" allowed=""false"" />
          <add fileExtension="".lddprototype"" allowed=""false"" />
          <add fileExtension="".exclude"" allowed=""false"" />
          <add fileExtension="".refresh"" allowed=""false"" />
          <add fileExtension="".compiled"" allowed=""false"" />
          <add fileExtension="".msgx"" allowed=""false"" />
          <add fileExtension="".vsdisco"" allowed=""false"" />
          <add fileExtension="".rules"" allowed=""false"" />
        </fileExtensions>
        <verbs allowUnlisted=""true"" applyToWebDAV=""true"" />
        <hiddenSegments applyToWebDAV=""true"">
          <add segment=""web.config"" />
          <add segment=""bin"" />
          <add segment=""App_code"" />
          <add segment=""App_GlobalResources"" />
          <add segment=""App_LocalResources"" />
          <add segment=""App_WebReferences"" />
          <add segment=""App_Data"" />
          <add segment=""App_Browsers"" />
        </hiddenSegments>
      </requestFiltering>
    </security>
    <serverSideInclude ssiExecDisable=""false"" />
    <staticContent lockAttributes=""isDocFooterFileName"">
      <mimeMap fileExtension="".323"" mimeType=""text/h323"" />
      <mimeMap fileExtension="".3g2"" mimeType=""video/3gpp2"" />
      <mimeMap fileExtension="".3gp2"" mimeType=""video/3gpp2"" />
      <mimeMap fileExtension="".3gp"" mimeType=""video/3gpp"" />
      <mimeMap fileExtension="".3gpp"" mimeType=""video/3gpp"" />
      <mimeMap fileExtension="".aac"" mimeType=""audio/aac"" />
      <mimeMap fileExtension="".aaf"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".aca"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".accdb"" mimeType=""application/msaccess"" />
      <mimeMap fileExtension="".accde"" mimeType=""application/msaccess"" />
      <mimeMap fileExtension="".accdt"" mimeType=""application/msaccess"" />
      <mimeMap fileExtension="".acx"" mimeType=""application/internet-property-stream"" />
      <mimeMap fileExtension="".adt"" mimeType=""audio/vnd.dlna.adts"" />
      <mimeMap fileExtension="".adts"" mimeType=""audio/vnd.dlna.adts"" />
      <mimeMap fileExtension="".afm"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".ai"" mimeType=""application/postscript"" />
      <mimeMap fileExtension="".aif"" mimeType=""audio/x-aiff"" />
      <mimeMap fileExtension="".aifc"" mimeType=""audio/aiff"" />
      <mimeMap fileExtension="".aiff"" mimeType=""audio/aiff"" />
      <mimeMap fileExtension="".appcache"" mimeType=""text/cache-manifest"" />
      <mimeMap fileExtension="".application"" mimeType=""application/x-ms-application"" />
      <mimeMap fileExtension="".art"" mimeType=""image/x-jg"" />
      <mimeMap fileExtension="".asd"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".asf"" mimeType=""video/x-ms-asf"" />
      <mimeMap fileExtension="".asi"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".asm"" mimeType=""text/plain"" />
      <mimeMap fileExtension="".asr"" mimeType=""video/x-ms-asf"" />
      <mimeMap fileExtension="".asx"" mimeType=""video/x-ms-asf"" />
      <mimeMap fileExtension="".atom"" mimeType=""application/atom+xml"" />
      <mimeMap fileExtension="".au"" mimeType=""audio/basic"" />
      <mimeMap fileExtension="".avi"" mimeType=""video/msvideo"" />
      <mimeMap fileExtension="".axs"" mimeType=""application/olescript"" />
      <mimeMap fileExtension="".bas"" mimeType=""text/plain"" />
      <mimeMap fileExtension="".bcpio"" mimeType=""application/x-bcpio"" />
      <mimeMap fileExtension="".bin"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".bmp"" mimeType=""image/bmp"" />
      <mimeMap fileExtension="".c"" mimeType=""text/plain"" />
      <mimeMap fileExtension="".cab"" mimeType=""application/vnd.ms-cab-compressed"" />
      <mimeMap fileExtension="".calx"" mimeType=""application/vnd.ms-office.calx"" />
      <mimeMap fileExtension="".cat"" mimeType=""application/vnd.ms-pki.seccat"" />
      <mimeMap fileExtension="".cdf"" mimeType=""application/x-cdf"" />
      <mimeMap fileExtension="".chm"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".class"" mimeType=""application/x-java-applet"" />
      <mimeMap fileExtension="".clp"" mimeType=""application/x-msclip"" />
      <mimeMap fileExtension="".cmx"" mimeType=""image/x-cmx"" />
      <mimeMap fileExtension="".cnf"" mimeType=""text/plain"" />
      <mimeMap fileExtension="".cod"" mimeType=""image/cis-cod"" />
      <mimeMap fileExtension="".cpio"" mimeType=""application/x-cpio"" />
      <mimeMap fileExtension="".cpp"" mimeType=""text/plain"" />
      <mimeMap fileExtension="".crd"" mimeType=""application/x-mscardfile"" />
      <mimeMap fileExtension="".crl"" mimeType=""application/pkix-crl"" />
      <mimeMap fileExtension="".crt"" mimeType=""application/x-x509-ca-cert"" />
      <mimeMap fileExtension="".csh"" mimeType=""application/x-csh"" />
      <mimeMap fileExtension="".css"" mimeType=""text/css"" />
      <mimeMap fileExtension="".csv"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".cur"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".dcr"" mimeType=""application/x-director"" />
      <mimeMap fileExtension="".deploy"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".der"" mimeType=""application/x-x509-ca-cert"" />
      <mimeMap fileExtension="".dib"" mimeType=""image/bmp"" />
      <mimeMap fileExtension="".dir"" mimeType=""application/x-director"" />
      <mimeMap fileExtension="".disco"" mimeType=""text/xml"" />
      <mimeMap fileExtension="".dll"" mimeType=""application/x-msdownload"" />
      <mimeMap fileExtension="".dll.config"" mimeType=""text/xml"" />
      <mimeMap fileExtension="".dlm"" mimeType=""text/dlm"" />
      <mimeMap fileExtension="".doc"" mimeType=""application/msword"" />
      <mimeMap fileExtension="".docm"" mimeType=""application/vnd.ms-word.document.macroEnabled.12"" />
      <mimeMap fileExtension="".docx"" mimeType=""application/vnd.openxmlformats-officedocument.wordprocessingml.document"" />
      <mimeMap fileExtension="".dot"" mimeType=""application/msword"" />
      <mimeMap fileExtension="".dotm"" mimeType=""application/vnd.ms-word.template.macroEnabled.12"" />
      <mimeMap fileExtension="".dotx"" mimeType=""application/vnd.openxmlformats-officedocument.wordprocessingml.template"" />
      <mimeMap fileExtension="".dsp"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".dtd"" mimeType=""text/xml"" />
      <mimeMap fileExtension="".dvi"" mimeType=""application/x-dvi"" />
      <mimeMap fileExtension="".dvr-ms"" mimeType=""video/x-ms-dvr"" />
      <mimeMap fileExtension="".dwf"" mimeType=""drawing/x-dwf"" />
      <mimeMap fileExtension="".dwp"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".dxr"" mimeType=""application/x-director"" />
      <mimeMap fileExtension="".eml"" mimeType=""message/rfc822"" />
      <mimeMap fileExtension="".emz"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".eot"" mimeType=""application/vnd.ms-fontobject"" />
      <mimeMap fileExtension="".eps"" mimeType=""application/postscript"" />
      <mimeMap fileExtension="".etx"" mimeType=""text/x-setext"" />
      <mimeMap fileExtension="".evy"" mimeType=""application/envoy"" />
      <mimeMap fileExtension="".exe"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".exe.config"" mimeType=""text/xml"" />
      <mimeMap fileExtension="".fdf"" mimeType=""application/vnd.fdf"" />
      <mimeMap fileExtension="".fif"" mimeType=""application/fractals"" />
      <mimeMap fileExtension="".fla"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".flr"" mimeType=""x-world/x-vrml"" />
      <mimeMap fileExtension="".flv"" mimeType=""video/x-flv"" />
      <mimeMap fileExtension="".gif"" mimeType=""image/gif"" />
      <mimeMap fileExtension="".gtar"" mimeType=""application/x-gtar"" />
      <mimeMap fileExtension="".gz"" mimeType=""application/x-gzip"" />
      <mimeMap fileExtension="".h"" mimeType=""text/plain"" />
      <mimeMap fileExtension="".hdf"" mimeType=""application/x-hdf"" />
      <mimeMap fileExtension="".hdml"" mimeType=""text/x-hdml"" />
      <mimeMap fileExtension="".hhc"" mimeType=""application/x-oleobject"" />
      <mimeMap fileExtension="".hhk"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".hhp"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".hlp"" mimeType=""application/winhlp"" />
      <mimeMap fileExtension="".hqx"" mimeType=""application/mac-binhex40"" />
      <mimeMap fileExtension="".hta"" mimeType=""application/hta"" />
      <mimeMap fileExtension="".htc"" mimeType=""text/x-component"" />
      <mimeMap fileExtension="".htm"" mimeType=""text/html"" />
      <mimeMap fileExtension="".html"" mimeType=""text/html"" />
      <mimeMap fileExtension="".htt"" mimeType=""text/webviewhtml"" />
      <mimeMap fileExtension="".hxt"" mimeType=""text/html"" />
      <mimeMap fileExtension="".ico"" mimeType=""image/x-icon"" />
      <mimeMap fileExtension="".ics"" mimeType=""text/calendar"" />
      <mimeMap fileExtension="".ief"" mimeType=""image/ief"" />
      <mimeMap fileExtension="".iii"" mimeType=""application/x-iphone"" />
      <mimeMap fileExtension="".inf"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".ins"" mimeType=""application/x-internet-signup"" />
      <mimeMap fileExtension="".isp"" mimeType=""application/x-internet-signup"" />
      <mimeMap fileExtension="".IVF"" mimeType=""video/x-ivf"" />
      <mimeMap fileExtension="".jar"" mimeType=""application/java-archive"" />
      <mimeMap fileExtension="".java"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".jck"" mimeType=""application/liquidmotion"" />
      <mimeMap fileExtension="".jcz"" mimeType=""application/liquidmotion"" />
      <mimeMap fileExtension="".jfif"" mimeType=""image/pjpeg"" />
      <mimeMap fileExtension="".jpb"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".jpe"" mimeType=""image/jpeg"" />
      <mimeMap fileExtension="".jpeg"" mimeType=""image/jpeg"" />
      <mimeMap fileExtension="".jpg"" mimeType=""image/jpeg"" />
      <mimeMap fileExtension="".js"" mimeType=""application/javascript"" />
      <mimeMap fileExtension="".json"" mimeType=""application/json"" />
      <mimeMap fileExtension="".jsonld"" mimeType=""application/ld+json"" />
      <mimeMap fileExtension="".jsx"" mimeType=""text/jscript"" />
      <mimeMap fileExtension="".latex"" mimeType=""application/x-latex"" />
      <mimeMap fileExtension="".less"" mimeType=""text/css"" />
      <mimeMap fileExtension="".lit"" mimeType=""application/x-ms-reader"" />
      <mimeMap fileExtension="".lpk"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".lsf"" mimeType=""video/x-la-asf"" />
      <mimeMap fileExtension="".lsx"" mimeType=""video/x-la-asf"" />
      <mimeMap fileExtension="".lzh"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".m13"" mimeType=""application/x-msmediaview"" />
      <mimeMap fileExtension="".m14"" mimeType=""application/x-msmediaview"" />
      <mimeMap fileExtension="".m1v"" mimeType=""video/mpeg"" />
      <mimeMap fileExtension="".m2ts"" mimeType=""video/vnd.dlna.mpeg-tts"" />
      <mimeMap fileExtension="".m3u"" mimeType=""audio/x-mpegurl"" />
      <mimeMap fileExtension="".m4a"" mimeType=""audio/mp4"" />
      <mimeMap fileExtension="".m4v"" mimeType=""video/mp4"" />
      <mimeMap fileExtension="".man"" mimeType=""application/x-troff-man"" />
      <mimeMap fileExtension="".manifest"" mimeType=""application/x-ms-manifest"" />
      <mimeMap fileExtension="".map"" mimeType=""text/plain"" />
      <mimeMap fileExtension="".mdb"" mimeType=""application/x-msaccess"" />
      <mimeMap fileExtension="".mdp"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".me"" mimeType=""application/x-troff-me"" />
      <mimeMap fileExtension="".mht"" mimeType=""message/rfc822"" />
      <mimeMap fileExtension="".mhtml"" mimeType=""message/rfc822"" />
      <mimeMap fileExtension="".mid"" mimeType=""audio/mid"" />
      <mimeMap fileExtension="".midi"" mimeType=""audio/mid"" />
      <mimeMap fileExtension="".mix"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".mmf"" mimeType=""application/x-smaf"" />
      <mimeMap fileExtension="".mno"" mimeType=""text/xml"" />
      <mimeMap fileExtension="".mny"" mimeType=""application/x-msmoney"" />
      <mimeMap fileExtension="".mov"" mimeType=""video/quicktime"" />
      <mimeMap fileExtension="".movie"" mimeType=""video/x-sgi-movie"" />
      <mimeMap fileExtension="".mp2"" mimeType=""video/mpeg"" />
      <mimeMap fileExtension="".mp3"" mimeType=""audio/mpeg"" />
      <mimeMap fileExtension="".mp4"" mimeType=""video/mp4"" />
      <mimeMap fileExtension="".mp4v"" mimeType=""video/mp4"" />
      <mimeMap fileExtension="".mpa"" mimeType=""video/mpeg"" />
      <mimeMap fileExtension="".mpe"" mimeType=""video/mpeg"" />
      <mimeMap fileExtension="".mpeg"" mimeType=""video/mpeg"" />
      <mimeMap fileExtension="".mpg"" mimeType=""video/mpeg"" />
      <mimeMap fileExtension="".mpp"" mimeType=""application/vnd.ms-project"" />
      <mimeMap fileExtension="".mpv2"" mimeType=""video/mpeg"" />
      <mimeMap fileExtension="".ms"" mimeType=""application/x-troff-ms"" />
      <mimeMap fileExtension="".msi"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".mso"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".mvb"" mimeType=""application/x-msmediaview"" />
      <mimeMap fileExtension="".mvc"" mimeType=""application/x-miva-compiled"" />
      <mimeMap fileExtension="".nc"" mimeType=""application/x-netcdf"" />
      <mimeMap fileExtension="".nsc"" mimeType=""video/x-ms-asf"" />
      <mimeMap fileExtension="".nws"" mimeType=""message/rfc822"" />
      <mimeMap fileExtension="".ocx"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".oda"" mimeType=""application/oda"" />
      <mimeMap fileExtension="".odc"" mimeType=""text/x-ms-odc"" />
      <mimeMap fileExtension="".ods"" mimeType=""application/oleobject"" />
      <mimeMap fileExtension="".oga"" mimeType=""audio/ogg"" />
      <mimeMap fileExtension="".ogg"" mimeType=""video/ogg"" />
      <mimeMap fileExtension="".ogv"" mimeType=""video/ogg"" />
      <mimeMap fileExtension="".one"" mimeType=""application/onenote"" />
      <mimeMap fileExtension="".onea"" mimeType=""application/onenote"" />
      <mimeMap fileExtension="".onetoc"" mimeType=""application/onenote"" />
      <mimeMap fileExtension="".onetoc2"" mimeType=""application/onenote"" />
      <mimeMap fileExtension="".onetmp"" mimeType=""application/onenote"" />
      <mimeMap fileExtension="".onepkg"" mimeType=""application/onenote"" />
      <mimeMap fileExtension="".osdx"" mimeType=""application/opensearchdescription+xml"" />
      <mimeMap fileExtension="".otf"" mimeType=""font/otf"" />
      <mimeMap fileExtension="".p10"" mimeType=""application/pkcs10"" />
      <mimeMap fileExtension="".p12"" mimeType=""application/x-pkcs12"" />
      <mimeMap fileExtension="".p7b"" mimeType=""application/x-pkcs7-certificates"" />
      <mimeMap fileExtension="".p7c"" mimeType=""application/pkcs7-mime"" />
      <mimeMap fileExtension="".p7m"" mimeType=""application/pkcs7-mime"" />
      <mimeMap fileExtension="".p7r"" mimeType=""application/x-pkcs7-certreqresp"" />
      <mimeMap fileExtension="".p7s"" mimeType=""application/pkcs7-signature"" />
      <mimeMap fileExtension="".pbm"" mimeType=""image/x-portable-bitmap"" />
      <mimeMap fileExtension="".pcx"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".pcz"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".pdf"" mimeType=""application/pdf"" />
      <mimeMap fileExtension="".pfb"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".pfm"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".pfx"" mimeType=""application/x-pkcs12"" />
      <mimeMap fileExtension="".pgm"" mimeType=""image/x-portable-graymap"" />
      <mimeMap fileExtension="".pko"" mimeType=""application/vnd.ms-pki.pko"" />
      <mimeMap fileExtension="".pma"" mimeType=""application/x-perfmon"" />
      <mimeMap fileExtension="".pmc"" mimeType=""application/x-perfmon"" />
      <mimeMap fileExtension="".pml"" mimeType=""application/x-perfmon"" />
      <mimeMap fileExtension="".pmr"" mimeType=""application/x-perfmon"" />
      <mimeMap fileExtension="".pmw"" mimeType=""application/x-perfmon"" />
      <mimeMap fileExtension="".png"" mimeType=""image/png"" />
      <mimeMap fileExtension="".pnm"" mimeType=""image/x-portable-anymap"" />
      <mimeMap fileExtension="".pnz"" mimeType=""image/png"" />
      <mimeMap fileExtension="".pot"" mimeType=""application/vnd.ms-powerpoint"" />
      <mimeMap fileExtension="".potm"" mimeType=""application/vnd.ms-powerpoint.template.macroEnabled.12"" />
      <mimeMap fileExtension="".potx"" mimeType=""application/vnd.openxmlformats-officedocument.presentationml.template"" />
      <mimeMap fileExtension="".ppam"" mimeType=""application/vnd.ms-powerpoint.addin.macroEnabled.12"" />
      <mimeMap fileExtension="".ppm"" mimeType=""image/x-portable-pixmap"" />
      <mimeMap fileExtension="".pps"" mimeType=""application/vnd.ms-powerpoint"" />
      <mimeMap fileExtension="".ppsm"" mimeType=""application/vnd.ms-powerpoint.slideshow.macroEnabled.12"" />
      <mimeMap fileExtension="".ppsx"" mimeType=""application/vnd.openxmlformats-officedocument.presentationml.slideshow"" />
      <mimeMap fileExtension="".ppt"" mimeType=""application/vnd.ms-powerpoint"" />
      <mimeMap fileExtension="".pptm"" mimeType=""application/vnd.ms-powerpoint.presentation.macroEnabled.12"" />
      <mimeMap fileExtension="".pptx"" mimeType=""application/vnd.openxmlformats-officedocument.presentationml.presentation"" />
      <mimeMap fileExtension="".prf"" mimeType=""application/pics-rules"" />
      <mimeMap fileExtension="".prm"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".prx"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".ps"" mimeType=""application/postscript"" />
      <mimeMap fileExtension="".psd"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".psm"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".psp"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".pub"" mimeType=""application/x-mspublisher"" />
      <mimeMap fileExtension="".qt"" mimeType=""video/quicktime"" />
      <mimeMap fileExtension="".qtl"" mimeType=""application/x-quicktimeplayer"" />
      <mimeMap fileExtension="".qxd"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".ra"" mimeType=""audio/x-pn-realaudio"" />
      <mimeMap fileExtension="".ram"" mimeType=""audio/x-pn-realaudio"" />
      <mimeMap fileExtension="".rar"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".ras"" mimeType=""image/x-cmu-raster"" />
      <mimeMap fileExtension="".rf"" mimeType=""image/vnd.rn-realflash"" />
      <mimeMap fileExtension="".rgb"" mimeType=""image/x-rgb"" />
      <mimeMap fileExtension="".rm"" mimeType=""application/vnd.rn-realmedia"" />
      <mimeMap fileExtension="".rmi"" mimeType=""audio/mid"" />
      <mimeMap fileExtension="".roff"" mimeType=""application/x-troff"" />
      <mimeMap fileExtension="".rpm"" mimeType=""audio/x-pn-realaudio-plugin"" />
      <mimeMap fileExtension="".rtf"" mimeType=""application/rtf"" />
      <mimeMap fileExtension="".rtx"" mimeType=""text/richtext"" />
      <mimeMap fileExtension="".scd"" mimeType=""application/x-msschedule"" />
      <mimeMap fileExtension="".sct"" mimeType=""text/scriptlet"" />
      <mimeMap fileExtension="".sea"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".setpay"" mimeType=""application/set-payment-initiation"" />
      <mimeMap fileExtension="".setreg"" mimeType=""application/set-registration-initiation"" />
      <mimeMap fileExtension="".sgml"" mimeType=""text/sgml"" />
      <mimeMap fileExtension="".sh"" mimeType=""application/x-sh"" />
      <mimeMap fileExtension="".shar"" mimeType=""application/x-shar"" />
      <mimeMap fileExtension="".sit"" mimeType=""application/x-stuffit"" />
      <mimeMap fileExtension="".sldm"" mimeType=""application/vnd.ms-powerpoint.slide.macroEnabled.12"" />
      <mimeMap fileExtension="".sldx"" mimeType=""application/vnd.openxmlformats-officedocument.presentationml.slide"" />
      <mimeMap fileExtension="".smd"" mimeType=""audio/x-smd"" />
      <mimeMap fileExtension="".smi"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".smx"" mimeType=""audio/x-smd"" />
      <mimeMap fileExtension="".smz"" mimeType=""audio/x-smd"" />
      <mimeMap fileExtension="".snd"" mimeType=""audio/basic"" />
      <mimeMap fileExtension="".snp"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".spc"" mimeType=""application/x-pkcs7-certificates"" />
      <mimeMap fileExtension="".spl"" mimeType=""application/futuresplash"" />
      <mimeMap fileExtension="".spx"" mimeType=""audio/ogg"" />
      <mimeMap fileExtension="".src"" mimeType=""application/x-wais-source"" />
      <mimeMap fileExtension="".ssm"" mimeType=""application/streamingmedia"" />
      <mimeMap fileExtension="".sst"" mimeType=""application/vnd.ms-pki.certstore"" />
      <mimeMap fileExtension="".stl"" mimeType=""application/vnd.ms-pki.stl"" />
      <mimeMap fileExtension="".sv4cpio"" mimeType=""application/x-sv4cpio"" />
      <mimeMap fileExtension="".sv4crc"" mimeType=""application/x-sv4crc"" />
      <mimeMap fileExtension="".svg"" mimeType=""image/svg+xml"" />
      <mimeMap fileExtension="".svgz"" mimeType=""image/svg+xml"" />
      <mimeMap fileExtension="".swf"" mimeType=""application/x-shockwave-flash"" />
      <mimeMap fileExtension="".t"" mimeType=""application/x-troff"" />
      <mimeMap fileExtension="".tar"" mimeType=""application/x-tar"" />
      <mimeMap fileExtension="".tcl"" mimeType=""application/x-tcl"" />
      <mimeMap fileExtension="".tex"" mimeType=""application/x-tex"" />
      <mimeMap fileExtension="".texi"" mimeType=""application/x-texinfo"" />
      <mimeMap fileExtension="".texinfo"" mimeType=""application/x-texinfo"" />
      <mimeMap fileExtension="".tgz"" mimeType=""application/x-compressed"" />
      <mimeMap fileExtension="".thmx"" mimeType=""application/vnd.ms-officetheme"" />
      <mimeMap fileExtension="".thn"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".tif"" mimeType=""image/tiff"" />
      <mimeMap fileExtension="".tiff"" mimeType=""image/tiff"" />
      <mimeMap fileExtension="".toc"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".tr"" mimeType=""application/x-troff"" />
      <mimeMap fileExtension="".trm"" mimeType=""application/x-msterminal"" />
      <mimeMap fileExtension="".ts"" mimeType=""video/vnd.dlna.mpeg-tts"" />
      <mimeMap fileExtension="".tsv"" mimeType=""text/tab-separated-values"" />
      <mimeMap fileExtension="".ttf"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".tts"" mimeType=""video/vnd.dlna.mpeg-tts"" />
      <mimeMap fileExtension="".txt"" mimeType=""text/plain"" />
      <mimeMap fileExtension="".u32"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".uls"" mimeType=""text/iuls"" />
      <mimeMap fileExtension="".ustar"" mimeType=""application/x-ustar"" />
      <mimeMap fileExtension="".vbs"" mimeType=""text/vbscript"" />
      <mimeMap fileExtension="".vcf"" mimeType=""text/x-vcard"" />
      <mimeMap fileExtension="".vcs"" mimeType=""text/plain"" />
      <mimeMap fileExtension="".vdx"" mimeType=""application/vnd.ms-visio.viewer"" />
      <mimeMap fileExtension="".vml"" mimeType=""text/xml"" />
      <mimeMap fileExtension="".vsd"" mimeType=""application/vnd.visio"" />
      <mimeMap fileExtension="".vss"" mimeType=""application/vnd.visio"" />
      <mimeMap fileExtension="".vst"" mimeType=""application/vnd.visio"" />
      <mimeMap fileExtension="".vsto"" mimeType=""application/x-ms-vsto"" />
      <mimeMap fileExtension="".vsw"" mimeType=""application/vnd.visio"" />
      <mimeMap fileExtension="".vsx"" mimeType=""application/vnd.visio"" />
      <mimeMap fileExtension="".vtx"" mimeType=""application/vnd.visio"" />
      <mimeMap fileExtension="".wav"" mimeType=""audio/wav"" />
      <mimeMap fileExtension="".wax"" mimeType=""audio/x-ms-wax"" />
      <mimeMap fileExtension="".wbmp"" mimeType=""image/vnd.wap.wbmp"" />
      <mimeMap fileExtension="".wcm"" mimeType=""application/vnd.ms-works"" />
      <mimeMap fileExtension="".wdb"" mimeType=""application/vnd.ms-works"" />
      <mimeMap fileExtension="".webm"" mimeType=""video/webm"" />
      <mimeMap fileExtension="".wks"" mimeType=""application/vnd.ms-works"" />
      <mimeMap fileExtension="".wm"" mimeType=""video/x-ms-wm"" />
      <mimeMap fileExtension="".wma"" mimeType=""audio/x-ms-wma"" />
      <mimeMap fileExtension="".wmd"" mimeType=""application/x-ms-wmd"" />
      <mimeMap fileExtension="".wmf"" mimeType=""application/x-msmetafile"" />
      <mimeMap fileExtension="".wml"" mimeType=""text/vnd.wap.wml"" />
      <mimeMap fileExtension="".wmlc"" mimeType=""application/vnd.wap.wmlc"" />
      <mimeMap fileExtension="".wmls"" mimeType=""text/vnd.wap.wmlscript"" />
      <mimeMap fileExtension="".wmlsc"" mimeType=""application/vnd.wap.wmlscriptc"" />
      <mimeMap fileExtension="".wmp"" mimeType=""video/x-ms-wmp"" />
      <mimeMap fileExtension="".wmv"" mimeType=""video/x-ms-wmv"" />
      <mimeMap fileExtension="".wmx"" mimeType=""video/x-ms-wmx"" />
      <mimeMap fileExtension="".wmz"" mimeType=""application/x-ms-wmz"" />
      <mimeMap fileExtension="".woff"" mimeType=""font/x-woff"" />
      <mimeMap fileExtension="".woff2"" mimeType=""application/font-woff2"" />
      <mimeMap fileExtension="".wps"" mimeType=""application/vnd.ms-works"" />
      <mimeMap fileExtension="".wri"" mimeType=""application/x-mswrite"" />
      <mimeMap fileExtension="".wrl"" mimeType=""x-world/x-vrml"" />
      <mimeMap fileExtension="".wrz"" mimeType=""x-world/x-vrml"" />
      <mimeMap fileExtension="".wsdl"" mimeType=""text/xml"" />
      <mimeMap fileExtension="".wtv"" mimeType=""video/x-ms-wtv"" />
      <mimeMap fileExtension="".wvx"" mimeType=""video/x-ms-wvx"" />
      <mimeMap fileExtension="".x"" mimeType=""application/directx"" />
      <mimeMap fileExtension="".xaf"" mimeType=""x-world/x-vrml"" />
      <mimeMap fileExtension="".xaml"" mimeType=""application/xaml+xml"" />
      <mimeMap fileExtension="".xap"" mimeType=""application/x-silverlight-app"" />
      <mimeMap fileExtension="".xbap"" mimeType=""application/x-ms-xbap"" />
      <mimeMap fileExtension="".xbm"" mimeType=""image/x-xbitmap"" />
      <mimeMap fileExtension="".xdr"" mimeType=""text/plain"" />
      <mimeMap fileExtension="".xht"" mimeType=""application/xhtml+xml"" />
      <mimeMap fileExtension="".xhtml"" mimeType=""application/xhtml+xml"" />
      <mimeMap fileExtension="".xla"" mimeType=""application/vnd.ms-excel"" />
      <mimeMap fileExtension="".xlam"" mimeType=""application/vnd.ms-excel.addin.macroEnabled.12"" />
      <mimeMap fileExtension="".xlc"" mimeType=""application/vnd.ms-excel"" />
      <mimeMap fileExtension="".xlm"" mimeType=""application/vnd.ms-excel"" />
      <mimeMap fileExtension="".xls"" mimeType=""application/vnd.ms-excel"" />
      <mimeMap fileExtension="".xlsb"" mimeType=""application/vnd.ms-excel.sheet.binary.macroEnabled.12"" />
      <mimeMap fileExtension="".xlsm"" mimeType=""application/vnd.ms-excel.sheet.macroEnabled.12"" />
      <mimeMap fileExtension="".xlsx"" mimeType=""application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"" />
      <mimeMap fileExtension="".xlt"" mimeType=""application/vnd.ms-excel"" />
      <mimeMap fileExtension="".xltm"" mimeType=""application/vnd.ms-excel.template.macroEnabled.12"" />
      <mimeMap fileExtension="".xltx"" mimeType=""application/vnd.openxmlformats-officedocument.spreadsheetml.template"" />
      <mimeMap fileExtension="".xlw"" mimeType=""application/vnd.ms-excel"" />
      <mimeMap fileExtension="".xml"" mimeType=""text/xml"" />
      <mimeMap fileExtension="".xof"" mimeType=""x-world/x-vrml"" />
      <mimeMap fileExtension="".xpm"" mimeType=""image/x-xpixmap"" />
      <mimeMap fileExtension="".xps"" mimeType=""application/vnd.ms-xpsdocument"" />
      <mimeMap fileExtension="".xsd"" mimeType=""text/xml"" />
      <mimeMap fileExtension="".xsf"" mimeType=""text/xml"" />
      <mimeMap fileExtension="".xsl"" mimeType=""text/xml"" />
      <mimeMap fileExtension="".xslt"" mimeType=""text/xml"" />
      <mimeMap fileExtension="".xsn"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".xtp"" mimeType=""application/octet-stream"" />
      <mimeMap fileExtension="".xwd"" mimeType=""image/x-xwindowdump"" />
      <mimeMap fileExtension="".z"" mimeType=""application/x-compress"" />
      <mimeMap fileExtension="".zip"" mimeType=""application/x-zip-compressed"" />
    </staticContent>
    <tracing>
      <traceProviderDefinitions>
        <add name=""WWW Server"" guid=""{3a2a4e84-4c21-4981-ae10-3fda0d9b0f83}"">
          <areas>
            <clear />
            <add name=""Authentication"" value=""2"" />
            <add name=""Security"" value=""4"" />
            <add name=""Filter"" value=""8"" />
            <add name=""StaticFile"" value=""16"" />
            <add name=""CGI"" value=""32"" />
            <add name=""Compression"" value=""64"" />
            <add name=""Cache"" value=""128"" />
            <add name=""RequestNotifications"" value=""256"" />
            <add name=""Module"" value=""512"" />
            <add name=""Rewrite"" value=""1024"" />
            <add name=""FastCGI"" value=""4096"" />
            <add name=""WebSocket"" value=""16384"" />
          </areas>
        </add>
        <add name=""ASP"" guid=""{06b94d9a-b15e-456e-a4ef-37c984a2cb4b}"">
          <areas>
            <clear />
          </areas>
        </add>
        <add name=""ISAPI Extension"" guid=""{a1c2040e-8840-4c31-ba11-9871031a19ea}"">
          <areas>
            <clear />
          </areas>
        </add>
        <add name=""ASPNET"" guid=""{AFF081FE-0247-4275-9C4E-021F3DC1DA35}"">
          <areas>
            <add name=""Infrastructure"" value=""1"" />
            <add name=""Module"" value=""2"" />
            <add name=""Page"" value=""4"" />
            <add name=""AppServices"" value=""8"" />
          </areas>
        </add>
      </traceProviderDefinitions>
      <traceFailedRequests>
        <add path=""*"">
          <traceAreas>
            <add provider=""ASP"" verbosity=""Verbose"" />
            <add provider=""ASPNET"" areas=""Infrastructure,Module,Page,AppServices"" verbosity=""Verbose"" />
            <add provider=""ISAPI Extension"" verbosity=""Verbose"" />
            <add provider=""WWW Server"" areas=""Authentication,Security,Filter,StaticFile,CGI,Compression,Cache,RequestNotifications,Module,Rewrite,WebSocket"" verbosity=""Verbose"" />
          </traceAreas>
          <failureDefinitions statusCodes=""200-999"" />
        </add>
      </traceFailedRequests>
    </tracing>
    <urlCompression />
    <validation />
    <webdav>
      <globalSettings>
        <propertyStores>
          <add name=""webdav_simple_prop"" image=""%IIS_BIN%\webdav_simple_prop.dll"" image32=""%IIS_BIN%\webdav_simple_prop.dll"" />
        </propertyStores>
        <lockStores>
          <add name=""webdav_simple_lock"" image=""%IIS_BIN%\webdav_simple_lock.dll"" image32=""%IIS_BIN%\webdav_simple_lock.dll"" />
        </lockStores>
      </globalSettings>
      <authoring>
        <locks enabled=""true"" lockStore=""webdav_simple_lock"" />
      </authoring>
      <authoringRules />
    </webdav>
    <webSocket />
    <applicationInitialization />
  </system.webServer>
  <location path="""" overrideMode=""Allow"">
    <system.webServer>
      <modules>
        <add name=""IsapiFilterModule"" lockItem=""true"" />
        <add name=""BasicAuthenticationModule"" lockItem=""true"" />
        <add name=""IsapiModule"" lockItem=""true"" />
        <add name=""HttpLoggingModule"" lockItem=""true"" />
        <!--
                <add name=""HttpCacheModule"" lockItem=""true"" />
-->
        <add name=""DynamicCompressionModule"" lockItem=""true"" />
        <add name=""StaticCompressionModule"" lockItem=""true"" />
        <add name=""DefaultDocumentModule"" lockItem=""true"" />
        <add name=""DirectoryListingModule"" lockItem=""true"" />
        <add name=""ProtocolSupportModule"" lockItem=""true"" />
        <add name=""HttpRedirectionModule"" lockItem=""true"" />
        <add name=""ServerSideIncludeModule"" lockItem=""true"" />
        <add name=""StaticFileModule"" lockItem=""true"" />
        <add name=""AnonymousAuthenticationModule"" lockItem=""true"" />
        <add name=""CertificateMappingAuthenticationModule"" lockItem=""true"" />
        <add name=""UrlAuthorizationModule"" lockItem=""true"" />
        <add name=""WindowsAuthenticationModule"" lockItem=""true"" />
        <!--
                <add name=""DigestAuthenticationModule"" lockItem=""true"" />
-->
        <add name=""IISCertificateMappingAuthenticationModule"" lockItem=""true"" />
        <add name=""WebMatrixSupportModule"" lockItem=""true"" />
        <add name=""IpRestrictionModule"" lockItem=""true"" />
        <add name=""DynamicIpRestrictionModule"" lockItem=""true"" />
        <add name=""RequestFilteringModule"" lockItem=""true"" />
        <add name=""CustomLoggingModule"" lockItem=""true"" />
        <add name=""CustomErrorModule"" lockItem=""true"" />
        <add name=""FailedRequestsTracingModule"" lockItem=""true"" />
        <add name=""CgiModule"" lockItem=""true"" />
        <add name=""FastCgiModule"" lockItem=""true"" />
        <!--                <add name=""WebDAVModule"" /> -->
        <add name=""RewriteModule"" />
        <add name=""OutputCache"" type=""System.Web.Caching.OutputCacheModule"" preCondition=""managedHandler"" />
        <add name=""Session"" type=""System.Web.SessionState.SessionStateModule"" preCondition=""managedHandler"" />
        <add name=""WindowsAuthentication"" type=""System.Web.Security.WindowsAuthenticationModule"" preCondition=""managedHandler"" />
        <add name=""FormsAuthentication"" type=""System.Web.Security.FormsAuthenticationModule"" preCondition=""managedHandler"" />
        <add name=""DefaultAuthentication"" type=""System.Web.Security.DefaultAuthenticationModule"" preCondition=""managedHandler"" />
        <add name=""RoleManager"" type=""System.Web.Security.RoleManagerModule"" preCondition=""managedHandler"" />
        <add name=""UrlAuthorization"" type=""System.Web.Security.UrlAuthorizationModule"" preCondition=""managedHandler"" />
        <add name=""FileAuthorization"" type=""System.Web.Security.FileAuthorizationModule"" preCondition=""managedHandler"" />
        <add name=""AnonymousIdentification"" type=""System.Web.Security.AnonymousIdentificationModule"" preCondition=""managedHandler"" />
        <add name=""Profile"" type=""System.Web.Profile.ProfileModule"" preCondition=""managedHandler"" />
        <add name=""UrlMappingsModule"" type=""System.Web.UrlMappingsModule"" preCondition=""managedHandler"" />
        <add name=""ConfigurationValidationModule"" lockItem=""true"" />
        <add name=""WebSocketModule"" lockItem=""true"" />
        <add name=""ServiceModel-4.0"" type=""System.ServiceModel.Activation.ServiceHttpModule,System.ServiceModel.Activation,Version=4.0.0.0,Culture=neutral,PublicKeyToken=31bf3856ad364e35"" preCondition=""managedHandler,runtimeVersionv4.0"" />
        <add name=""UrlRoutingModule-4.0"" type=""System.Web.Routing.UrlRoutingModule"" preCondition=""managedHandler,runtimeVersionv4.0"" />
        <add name=""ScriptModule-4.0"" type=""System.Web.Handlers.ScriptModule, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"" preCondition=""managedHandler,runtimeVersionv4.0"" />
        <add name=""ServiceModel"" type=""System.ServiceModel.Activation.HttpModule, System.ServiceModel, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler,runtimeVersionv2.0"" />
        <add name=""ApplicationInitializationModule"" lockItem=""true"" />
        <add name=""AspNetCoreModule"" lockItem=""true"" />
      </modules>
      <handlers accessPolicy=""Read, Script"">
        <!--                <add name=""WebDAV"" path=""*"" verb=""PROPFIND,PROPPATCH,MKCOL,PUT,COPY,DELETE,MOVE,LOCK,UNLOCK"" modules=""WebDAVModule"" resourceType=""Unspecified"" requireAccess=""None"" /> -->
        <add name=""AXD-ISAPI-4.0_64bit"" path=""*.axd"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness64"" responseBufferLimit=""0"" />
        <add name=""PageHandlerFactory-ISAPI-4.0_64bit"" path=""*.aspx"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness64"" responseBufferLimit=""0"" />
        <add name=""SimpleHandlerFactory-ISAPI-4.0_64bit"" path=""*.ashx"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness64"" responseBufferLimit=""0"" />
        <add name=""WebServiceHandlerFactory-ISAPI-4.0_64bit"" path=""*.asmx"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness64"" responseBufferLimit=""0"" />
        <add name=""HttpRemotingHandlerFactory-rem-ISAPI-4.0_64bit"" path=""*.rem"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness64"" responseBufferLimit=""0"" />
        <add name=""HttpRemotingHandlerFactory-soap-ISAPI-4.0_64bit"" path=""*.soap"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness64"" responseBufferLimit=""0"" />
        <add name=""svc-ISAPI-4.0_64bit"" path=""*.svc"" verb=""*"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness64"" />
        <add name=""rules-ISAPI-4.0_64bit"" path=""*.rules"" verb=""*"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness64"" />
        <add name=""xoml-ISAPI-4.0_64bit"" path=""*.xoml"" verb=""*"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness64"" />
        <add name=""xamlx-ISAPI-4.0_64bit"" path=""*.xamlx"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness64"" />
        <add name=""aspq-ISAPI-4.0_64bit"" path=""*.aspq"" verb=""*"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness64"" responseBufferLimit=""0"" />
        <add name=""cshtm-ISAPI-4.0_64bit"" path=""*.cshtm"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness64"" responseBufferLimit=""0"" />
        <add name=""cshtml-ISAPI-4.0_64bit"" path=""*.cshtml"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness64"" responseBufferLimit=""0"" />
        <add name=""vbhtm-ISAPI-4.0_64bit"" path=""*.vbhtm"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness64"" responseBufferLimit=""0"" />
        <add name=""vbhtml-ISAPI-4.0_64bit"" path=""*.vbhtml"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness64"" responseBufferLimit=""0"" />
        <add name=""svc-Integrated"" path=""*.svc"" verb=""*"" type=""System.ServiceModel.Activation.HttpHandler, System.ServiceModel, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""integratedMode,runtimeVersionv2.0"" />
        <add name=""svc-ISAPI-2.0"" path=""*.svc"" verb=""*"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv2.0,bitness32"" />
        <add name=""xoml-Integrated"" path=""*.xoml"" verb=""*"" type=""System.ServiceModel.Activation.HttpHandler, System.ServiceModel, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""integratedMode,runtimeVersionv2.0"" />
        <add name=""xoml-ISAPI-2.0"" path=""*.xoml"" verb=""*"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv2.0,bitness32"" />
        <add name=""rules-Integrated"" path=""*.rules"" verb=""*"" type=""System.ServiceModel.Activation.HttpHandler, System.ServiceModel, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""integratedMode,runtimeVersionv2.0"" />
        <add name=""rules-ISAPI-2.0"" path=""*.rules"" verb=""*"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv2.0,bitness32"" />
        <add name=""AXD-ISAPI-4.0_32bit"" path=""*.axd"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness32"" responseBufferLimit=""0"" />
        <add name=""PageHandlerFactory-ISAPI-4.0_32bit"" path=""*.aspx"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness32"" responseBufferLimit=""0"" />
        <add name=""SimpleHandlerFactory-ISAPI-4.0_32bit"" path=""*.ashx"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness32"" responseBufferLimit=""0"" />
        <add name=""WebServiceHandlerFactory-ISAPI-4.0_32bit"" path=""*.asmx"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness32"" responseBufferLimit=""0"" />
        <add name=""HttpRemotingHandlerFactory-rem-ISAPI-4.0_32bit"" path=""*.rem"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness32"" responseBufferLimit=""0"" />
        <add name=""HttpRemotingHandlerFactory-soap-ISAPI-4.0_32bit"" path=""*.soap"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness32"" responseBufferLimit=""0"" />
        <add name=""svc-ISAPI-4.0_32bit"" path=""*.svc"" verb=""*"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness32"" />
        <add name=""rules-ISAPI-4.0_32bit"" path=""*.rules"" verb=""*"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness32"" />
        <add name=""xoml-ISAPI-4.0_32bit"" path=""*.xoml"" verb=""*"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness32"" />
        <add name=""xamlx-ISAPI-4.0_32bit"" path=""*.xamlx"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness32"" />
        <add name=""aspq-ISAPI-4.0_32bit"" path=""*.aspq"" verb=""*"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness32"" responseBufferLimit=""0"" />
        <add name=""cshtm-ISAPI-4.0_32bit"" path=""*.cshtm"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness32"" responseBufferLimit=""0"" />
        <add name=""cshtml-ISAPI-4.0_32bit"" path=""*.cshtml"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness32"" responseBufferLimit=""0"" />
        <add name=""vbhtm-ISAPI-4.0_32bit"" path=""*.vbhtm"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness32"" responseBufferLimit=""0"" />
        <add name=""vbhtml-ISAPI-4.0_32bit"" path=""*.vbhtml"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness32"" responseBufferLimit=""0"" />
        <add name=""TraceHandler-Integrated-4.0"" path=""trace.axd"" verb=""GET,HEAD,POST,DEBUG"" type=""System.Web.Handlers.TraceHandler"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""WebAdminHandler-Integrated-4.0"" path=""WebAdmin.axd"" verb=""GET,DEBUG"" type=""System.Web.Handlers.WebAdminHandler"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""AssemblyResourceLoader-Integrated-4.0"" path=""WebResource.axd"" verb=""GET,DEBUG"" type=""System.Web.Handlers.AssemblyResourceLoader"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""PageHandlerFactory-Integrated-4.0"" path=""*.aspx"" verb=""GET,HEAD,POST,DEBUG"" type=""System.Web.UI.PageHandlerFactory"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""SimpleHandlerFactory-Integrated-4.0"" path=""*.ashx"" verb=""GET,HEAD,POST,DEBUG"" type=""System.Web.UI.SimpleHandlerFactory"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""WebServiceHandlerFactory-Integrated-4.0"" path=""*.asmx"" verb=""GET,HEAD,POST,DEBUG"" type=""System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""HttpRemotingHandlerFactory-rem-Integrated-4.0"" path=""*.rem"" verb=""GET,HEAD,POST,DEBUG"" type=""System.Runtime.Remoting.Channels.Http.HttpRemotingHandlerFactory, System.Runtime.Remoting, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""HttpRemotingHandlerFactory-soap-Integrated-4.0"" path=""*.soap"" verb=""GET,HEAD,POST,DEBUG"" type=""System.Runtime.Remoting.Channels.Http.HttpRemotingHandlerFactory, System.Runtime.Remoting, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""svc-Integrated-4.0"" path=""*.svc"" verb=""*"" type=""System.ServiceModel.Activation.ServiceHttpHandlerFactory, System.ServiceModel.Activation, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""rules-Integrated-4.0"" path=""*.rules"" verb=""*"" type=""System.ServiceModel.Activation.ServiceHttpHandlerFactory, System.ServiceModel.Activation, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""xoml-Integrated-4.0"" path=""*.xoml"" verb=""*"" type=""System.ServiceModel.Activation.ServiceHttpHandlerFactory, System.ServiceModel.Activation, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""xamlx-Integrated-4.0"" path=""*.xamlx"" verb=""GET,HEAD,POST,DEBUG"" type=""System.Xaml.Hosting.XamlHttpHandlerFactory, System.Xaml.Hosting, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""aspq-Integrated-4.0"" path=""*.aspq"" verb=""GET,HEAD,POST,DEBUG"" type=""System.Web.HttpForbiddenHandler"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""cshtm-Integrated-4.0"" path=""*.cshtm"" verb=""GET,HEAD,POST,DEBUG"" type=""System.Web.HttpForbiddenHandler"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""cshtml-Integrated-4.0"" path=""*.cshtml"" verb=""GET,HEAD,POST,DEBUG"" type=""System.Web.HttpForbiddenHandler"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""vbhtm-Integrated-4.0"" path=""*.vbhtm"" verb=""GET,HEAD,POST,DEBUG"" type=""System.Web.HttpForbiddenHandler"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""vbhtml-Integrated-4.0"" path=""*.vbhtml"" verb=""GET,HEAD,POST,DEBUG"" type=""System.Web.HttpForbiddenHandler"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""ScriptHandlerFactoryAppServices-Integrated-4.0"" path=""*_AppService.axd"" verb=""*"" type=""System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""ScriptResourceIntegrated-4.0"" path=""*ScriptResource.axd"" verb=""GET,HEAD"" type=""System.Web.Handlers.ScriptResourceHandler, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        <add name=""ASPClassic"" path=""*.asp"" verb=""GET,HEAD,POST"" modules=""IsapiModule"" scriptProcessor=""%IIS_BIN%\asp.dll"" resourceType=""File"" />
        <add name=""SecurityCertificate"" path=""*.cer"" verb=""GET,HEAD,POST"" modules=""IsapiModule"" scriptProcessor=""%IIS_BIN%\asp.dll"" resourceType=""File"" />
        <add name=""ISAPI-dll"" path=""*.dll"" verb=""*"" modules=""IsapiModule"" resourceType=""File"" requireAccess=""Execute"" allowPathInfo=""true"" />
        <add name=""TraceHandler-Integrated"" path=""trace.axd"" verb=""GET,HEAD,POST,DEBUG"" type=""System.Web.Handlers.TraceHandler"" preCondition=""integratedMode,runtimeVersionv2.0"" />
        <add name=""WebAdminHandler-Integrated"" path=""WebAdmin.axd"" verb=""GET,DEBUG"" type=""System.Web.Handlers.WebAdminHandler"" preCondition=""integratedMode,runtimeVersionv2.0"" />
        <add name=""AssemblyResourceLoader-Integrated"" path=""WebResource.axd"" verb=""GET,DEBUG"" type=""System.Web.Handlers.AssemblyResourceLoader"" preCondition=""integratedMode,runtimeVersionv2.0"" />
        <add name=""PageHandlerFactory-Integrated"" path=""*.aspx"" verb=""GET,HEAD,POST,DEBUG"" type=""System.Web.UI.PageHandlerFactory"" preCondition=""integratedMode,runtimeVersionv2.0"" />
        <add name=""SimpleHandlerFactory-Integrated"" path=""*.ashx"" verb=""GET,HEAD,POST,DEBUG"" type=""System.Web.UI.SimpleHandlerFactory"" preCondition=""integratedMode,runtimeVersionv2.0"" />
        <add name=""WebServiceHandlerFactory-Integrated"" path=""*.asmx"" verb=""GET,HEAD,POST,DEBUG"" type=""System.Web.Services.Protocols.WebServiceHandlerFactory,System.Web.Services,Version=2.0.0.0,Culture=neutral,PublicKeyToken=b03f5f7f11d50a3a"" preCondition=""integratedMode,runtimeVersionv2.0"" />
        <add name=""HttpRemotingHandlerFactory-rem-Integrated"" path=""*.rem"" verb=""GET,HEAD,POST,DEBUG"" type=""System.Runtime.Remoting.Channels.Http.HttpRemotingHandlerFactory,System.Runtime.Remoting,Version=2.0.0.0,Culture=neutral,PublicKeyToken=b77a5c561934e089"" preCondition=""integratedMode,runtimeVersionv2.0"" />
        <add name=""HttpRemotingHandlerFactory-soap-Integrated"" path=""*.soap"" verb=""GET,HEAD,POST,DEBUG"" type=""System.Runtime.Remoting.Channels.Http.HttpRemotingHandlerFactory,System.Runtime.Remoting,Version=2.0.0.0,Culture=neutral,PublicKeyToken=b77a5c561934e089"" preCondition=""integratedMode,runtimeVersionv2.0"" />
        <add name=""AXD-ISAPI-2.0"" path=""*.axd"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv2.0,bitness32"" responseBufferLimit=""0"" />
        <add name=""PageHandlerFactory-ISAPI-2.0"" path=""*.aspx"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv2.0,bitness32"" responseBufferLimit=""0"" />
        <add name=""SimpleHandlerFactory-ISAPI-2.0"" path=""*.ashx"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv2.0,bitness32"" responseBufferLimit=""0"" />
        <add name=""WebServiceHandlerFactory-ISAPI-2.0"" path=""*.asmx"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv2.0,bitness32"" responseBufferLimit=""0"" />
        <add name=""HttpRemotingHandlerFactory-rem-ISAPI-2.0"" path=""*.rem"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv2.0,bitness32"" responseBufferLimit=""0"" />
        <add name=""HttpRemotingHandlerFactory-soap-ISAPI-2.0"" path=""*.soap"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv2.0,bitness32"" responseBufferLimit=""0"" />
        <add name=""svc-ISAPI-2.0-64"" path=""*.svc"" verb=""*"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv2.0,bitness64"" />
        <add name=""AXD-ISAPI-2.0-64"" path=""*.axd"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv2.0,bitness64"" responseBufferLimit=""0"" />
        <add name=""PageHandlerFactory-ISAPI-2.0-64"" path=""*.aspx"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv2.0,bitness64"" responseBufferLimit=""0"" />
        <add name=""SimpleHandlerFactory-ISAPI-2.0-64"" path=""*.ashx"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv2.0,bitness64"" responseBufferLimit=""0"" />
        <add name=""WebServiceHandlerFactory-ISAPI-2.0-64"" path=""*.asmx"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv2.0,bitness64"" responseBufferLimit=""0"" />
        <add name=""HttpRemotingHandlerFactory-rem-ISAPI-2.0-64"" path=""*.rem"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv2.0,bitness64"" responseBufferLimit=""0"" />
        <add name=""HttpRemotingHandlerFactory-soap-ISAPI-2.0-64"" path=""*.soap"" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv2.0,bitness64"" responseBufferLimit=""0"" />
        <add name=""rules-64-ISAPI-2.0"" path=""*.rules"" verb=""*"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv2.0,bitness64"" />
        <add name=""xoml-64-ISAPI-2.0"" path=""*.xoml"" verb=""*"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv2.0,bitness64"" />
        <add name=""CGI-exe"" path=""*.exe"" verb=""*"" modules=""CgiModule"" resourceType=""File"" requireAccess=""Execute"" allowPathInfo=""true"" />
        <add name=""SSINC-stm"" path=""*.stm"" verb=""GET,HEAD,POST"" modules=""ServerSideIncludeModule"" resourceType=""File"" />
        <add name=""SSINC-shtm"" path=""*.shtm"" verb=""GET,HEAD,POST"" modules=""ServerSideIncludeModule"" resourceType=""File"" />
        <add name=""SSINC-shtml"" path=""*.shtml"" verb=""GET,HEAD,POST"" modules=""ServerSideIncludeModule"" resourceType=""File"" />
        <add name=""TRACEVerbHandler"" path=""*"" verb=""TRACE"" modules=""ProtocolSupportModule"" requireAccess=""None"" />
        <add name=""OPTIONSVerbHandler"" path=""*"" verb=""OPTIONS"" modules=""ProtocolSupportModule"" requireAccess=""None"" />
        <add name=""ExtensionlessUrl-ISAPI-4.0_32bit"" path=""*."" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness32"" responseBufferLimit=""0"" />
        <add name=""ExtensionlessUrlHandler-ISAPI-4.0_64bit"" path=""*."" verb=""GET,HEAD,POST,DEBUG"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness64"" responseBufferLimit=""0"" />
        <add name=""ExtensionlessUrl-Integrated-4.0"" path=""*."" verb=""GET,HEAD,POST,DEBUG"" type=""System.Web.Handlers.TransferRequestHandler"" preCondition=""integratedMode,runtimeVersionv4.0"" responseBufferLimit=""0"" />
        <add name=""StaticFile"" path=""*"" verb=""*"" modules=""StaticFileModule,DefaultDocumentModule,DirectoryListingModule"" resourceType=""Either"" requireAccess=""Read"" />
      </handlers>
    </system.webServer>
  </location>
</configuration>
";

        public static string aiJsFileContent = @"var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        (function (LoggingSeverity) {
            LoggingSeverity[LoggingSeverity[""CRITICAL""] = 0] = ""CRITICAL"";
            LoggingSeverity[LoggingSeverity[""WARNING""] = 1] = ""WARNING"";
        })(ApplicationInsights.LoggingSeverity || (ApplicationInsights.LoggingSeverity = {}));
        var LoggingSeverity = ApplicationInsights.LoggingSeverity;
        (function (_InternalMessageId) {
            _InternalMessageId[_InternalMessageId[""NONUSRACT_BrowserDoesNotSupportLocalStorage""] = 0] = ""NONUSRACT_BrowserDoesNotSupportLocalStorage"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_BrowserCannotReadLocalStorage""] = 1] = ""NONUSRACT_BrowserCannotReadLocalStorage"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_BrowserCannotReadSessionStorage""] = 2] = ""NONUSRACT_BrowserCannotReadSessionStorage"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_BrowserCannotWriteLocalStorage""] = 3] = ""NONUSRACT_BrowserCannotWriteLocalStorage"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_BrowserCannotWriteSessionStorage""] = 4] = ""NONUSRACT_BrowserCannotWriteSessionStorage"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_BrowserFailedRemovalFromLocalStorage""] = 5] = ""NONUSRACT_BrowserFailedRemovalFromLocalStorage"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_BrowserFailedRemovalFromSessionStorage""] = 6] = ""NONUSRACT_BrowserFailedRemovalFromSessionStorage"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_CannotSendEmptyTelemetry""] = 7] = ""NONUSRACT_CannotSendEmptyTelemetry"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_ClientPerformanceMathError""] = 8] = ""NONUSRACT_ClientPerformanceMathError"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_ErrorParsingAISessionCookie""] = 9] = ""NONUSRACT_ErrorParsingAISessionCookie"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_ErrorPVCalc""] = 10] = ""NONUSRACT_ErrorPVCalc"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_ExceptionWhileLoggingError""] = 11] = ""NONUSRACT_ExceptionWhileLoggingError"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_FailedAddingTelemetryToBuffer""] = 12] = ""NONUSRACT_FailedAddingTelemetryToBuffer"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_FailedMonitorAjaxAbort""] = 13] = ""NONUSRACT_FailedMonitorAjaxAbort"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_FailedMonitorAjaxDur""] = 14] = ""NONUSRACT_FailedMonitorAjaxDur"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_FailedMonitorAjaxOpen""] = 15] = ""NONUSRACT_FailedMonitorAjaxOpen"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_FailedMonitorAjaxRSC""] = 16] = ""NONUSRACT_FailedMonitorAjaxRSC"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_FailedMonitorAjaxSend""] = 17] = ""NONUSRACT_FailedMonitorAjaxSend"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_FailedToAddHandlerForOnBeforeUnload""] = 18] = ""NONUSRACT_FailedToAddHandlerForOnBeforeUnload"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_FailedToSendQueuedTelemetry""] = 19] = ""NONUSRACT_FailedToSendQueuedTelemetry"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_FailedToReportDataLoss""] = 20] = ""NONUSRACT_FailedToReportDataLoss"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_FlushFailed""] = 21] = ""NONUSRACT_FlushFailed"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_MessageLimitPerPVExceeded""] = 22] = ""NONUSRACT_MessageLimitPerPVExceeded"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_MissingRequiredFieldSpecification""] = 23] = ""NONUSRACT_MissingRequiredFieldSpecification"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_NavigationTimingNotSupported""] = 24] = ""NONUSRACT_NavigationTimingNotSupported"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_OnError""] = 25] = ""NONUSRACT_OnError"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_SessionRenewalDateIsZero""] = 26] = ""NONUSRACT_SessionRenewalDateIsZero"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_SenderNotInitialized""] = 27] = ""NONUSRACT_SenderNotInitialized"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_StartTrackEventFailed""] = 28] = ""NONUSRACT_StartTrackEventFailed"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_StopTrackEventFailed""] = 29] = ""NONUSRACT_StopTrackEventFailed"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_StartTrackFailed""] = 30] = ""NONUSRACT_StartTrackFailed"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_StopTrackFailed""] = 31] = ""NONUSRACT_StopTrackFailed"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_TelemetrySampledAndNotSent""] = 32] = ""NONUSRACT_TelemetrySampledAndNotSent"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_TrackEventFailed""] = 33] = ""NONUSRACT_TrackEventFailed"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_TrackExceptionFailed""] = 34] = ""NONUSRACT_TrackExceptionFailed"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_TrackMetricFailed""] = 35] = ""NONUSRACT_TrackMetricFailed"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_TrackPVFailed""] = 36] = ""NONUSRACT_TrackPVFailed"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_TrackPVFailedCalc""] = 37] = ""NONUSRACT_TrackPVFailedCalc"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_TrackTraceFailed""] = 38] = ""NONUSRACT_TrackTraceFailed"";
            _InternalMessageId[_InternalMessageId[""NONUSRACT_TransmissionFailed""] = 39] = ""NONUSRACT_TransmissionFailed"";
            _InternalMessageId[_InternalMessageId[""USRACT_CannotSerializeObject""] = 40] = ""USRACT_CannotSerializeObject"";
            _InternalMessageId[_InternalMessageId[""USRACT_CannotSerializeObjectNonSerializable""] = 41] = ""USRACT_CannotSerializeObjectNonSerializable"";
            _InternalMessageId[_InternalMessageId[""USRACT_CircularReferenceDetected""] = 42] = ""USRACT_CircularReferenceDetected"";
            _InternalMessageId[_InternalMessageId[""USRACT_ClearAuthContextFailed""] = 43] = ""USRACT_ClearAuthContextFailed"";
            _InternalMessageId[_InternalMessageId[""USRACT_ExceptionTruncated""] = 44] = ""USRACT_ExceptionTruncated"";
            _InternalMessageId[_InternalMessageId[""USRACT_IllegalCharsInName""] = 45] = ""USRACT_IllegalCharsInName"";
            _InternalMessageId[_InternalMessageId[""USRACT_ItemNotInArray""] = 46] = ""USRACT_ItemNotInArray"";
            _InternalMessageId[_InternalMessageId[""USRACT_MaxAjaxPerPVExceeded""] = 47] = ""USRACT_MaxAjaxPerPVExceeded"";
            _InternalMessageId[_InternalMessageId[""USRACT_MessageTruncated""] = 48] = ""USRACT_MessageTruncated"";
            _InternalMessageId[_InternalMessageId[""USRACT_NameTooLong""] = 49] = ""USRACT_NameTooLong"";
            _InternalMessageId[_InternalMessageId[""USRACT_SampleRateOutOfRange""] = 50] = ""USRACT_SampleRateOutOfRange"";
            _InternalMessageId[_InternalMessageId[""USRACT_SetAuthContextFailed""] = 51] = ""USRACT_SetAuthContextFailed"";
            _InternalMessageId[_InternalMessageId[""USRACT_SetAuthContextFailedAccountName""] = 52] = ""USRACT_SetAuthContextFailedAccountName"";
            _InternalMessageId[_InternalMessageId[""USRACT_StringValueTooLong""] = 53] = ""USRACT_StringValueTooLong"";
            _InternalMessageId[_InternalMessageId[""USRACT_StartCalledMoreThanOnce""] = 54] = ""USRACT_StartCalledMoreThanOnce"";
            _InternalMessageId[_InternalMessageId[""USRACT_StopCalledWithoutStart""] = 55] = ""USRACT_StopCalledWithoutStart"";
            _InternalMessageId[_InternalMessageId[""USRACT_TelemetryInitializerFailed""] = 56] = ""USRACT_TelemetryInitializerFailed"";
            _InternalMessageId[_InternalMessageId[""USRACT_TrackArgumentsNotSpecified""] = 57] = ""USRACT_TrackArgumentsNotSpecified"";
            _InternalMessageId[_InternalMessageId[""USRACT_UrlTooLong""] = 58] = ""USRACT_UrlTooLong"";
        })(ApplicationInsights._InternalMessageId || (ApplicationInsights._InternalMessageId = {}));
        var _InternalMessageId = ApplicationInsights._InternalMessageId;
        var _InternalLogMessage = (function () {
            function _InternalLogMessage(msgId, msg, properties) {
                this.message = _InternalMessageId[msgId].toString();
                this.messageId = msgId;
                var diagnosticText = (msg ? "" message:"" + _InternalLogMessage.sanitizeDiagnosticText(msg) : """") +
                    (properties ? "" props:"" + _InternalLogMessage.sanitizeDiagnosticText(JSON.stringify(properties)) : """");
                this.message += diagnosticText;
            }
            _InternalLogMessage.sanitizeDiagnosticText = function (text) {
                return ""\"""" + text.replace(/\""/g, """") + ""\"""";
            };
            return _InternalLogMessage;
        })();
        ApplicationInsights._InternalLogMessage = _InternalLogMessage;
        var _InternalLogging = (function () {
            function _InternalLogging() {
            }
            _InternalLogging.throwInternalNonUserActionable = function (severity, message) {
                if (this.enableDebugExceptions()) {
                    throw message;
                }
                else {
                    if (typeof (message) !== ""undefined"" && !!message) {
                        if (typeof (message.message) !== ""undefined"") {
                            message.message = this.AiNonUserActionablePrefix + message.message;
                            this.warnToConsole(message.message);
                            this.logInternalMessage(severity, message);
                        }
                    }
                }
            };
            _InternalLogging.throwInternalUserActionable = function (severity, message) {
                if (this.enableDebugExceptions()) {
                    throw message;
                }
                else {
                    if (typeof (message) !== ""undefined"" && !!message) {
                        if (typeof (message.message) !== ""undefined"") {
                            message.message = this.AiUserActionablePrefix + message.message;
                            this.warnToConsole(message.message);
                            this.logInternalMessage(severity, message);
                        }
                    }
                }
            };
            _InternalLogging.warnToConsole = function (message) {
                if (typeof console !== ""undefined"" && !!console) {
                    if (typeof console.warn === ""function"") {
                        console.warn(message);
                    }
                    else if (typeof console.log === ""function"") {
                        console.log(message);
                    }
                }
            };
            _InternalLogging.resetInternalMessageCount = function () {
                this._messageCount = 0;
            };
            _InternalLogging.clearInternalMessageLoggedTypes = function () {
                if (ApplicationInsights.Util.canUseSessionStorage()) {
                    var sessionStorageKeys = ApplicationInsights.Util.getSessionStorageKeys();
                    for (var i = 0; i < sessionStorageKeys.length; i++) {
                        if (sessionStorageKeys[i].indexOf(_InternalLogging.AIInternalMessagePrefix) === 0) {
                            ApplicationInsights.Util.removeSessionStorage(sessionStorageKeys[i]);
                        }
                    }
                }
            };
            _InternalLogging.setMaxInternalMessageLimit = function (limit) {
                if (!limit) {
                    throw new Error('limit cannot be undefined.');
                }
                this.MAX_INTERNAL_MESSAGE_LIMIT = limit;
            };
            _InternalLogging.logInternalMessage = function (severity, message) {
                if (this._areInternalMessagesThrottled()) {
                    return;
                }
                var logMessage = true;
                if (ApplicationInsights.Util.canUseSessionStorage()) {
                    var storageMessageKey = _InternalLogging.AIInternalMessagePrefix + _InternalMessageId[message.messageId];
                    var internalMessageTypeLogRecord = ApplicationInsights.Util.getSessionStorage(storageMessageKey);
                    if (internalMessageTypeLogRecord) {
                        logMessage = false;
                    }
                    else {
                        ApplicationInsights.Util.setSessionStorage(storageMessageKey, ""1"");
                    }
                }
                if (logMessage) {
                    if (this.verboseLogging() || severity === LoggingSeverity.CRITICAL) {
                        this.queue.push(message);
                        this._messageCount++;
                    }
                    if (this._messageCount == this.MAX_INTERNAL_MESSAGE_LIMIT) {
                        var throttleLimitMessage = ""Internal events throttle limit per PageView reached for this app."";
                        var throttleMessage = new _InternalLogMessage(_InternalMessageId.NONUSRACT_MessageLimitPerPVExceeded, throttleLimitMessage);
                        this.queue.push(throttleMessage);
                        this.warnToConsole(throttleLimitMessage);
                    }
                }
            };
            _InternalLogging._areInternalMessagesThrottled = function () {
                return this._messageCount >= this.MAX_INTERNAL_MESSAGE_LIMIT;
            };
            _InternalLogging.AiUserActionablePrefix = ""AI: "";
            _InternalLogging.AIInternalMessagePrefix = ""AITR_"";
            _InternalLogging.AiNonUserActionablePrefix = ""AI (Internal): "";
            _InternalLogging.enableDebugExceptions = function () { return false; };
            _InternalLogging.verboseLogging = function () { return false; };
            _InternalLogging.queue = [];
            _InternalLogging.MAX_INTERNAL_MESSAGE_LIMIT = 25;
            _InternalLogging._messageCount = 0;
            return _InternalLogging;
        })();
        ApplicationInsights._InternalLogging = _InternalLogging;
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""./logging.ts"" />
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var StorageType;
        (function (StorageType) {
            StorageType[StorageType[""LocalStorage""] = 0] = ""LocalStorage"";
            StorageType[StorageType[""SessionStorage""] = 1] = ""SessionStorage"";
        })(StorageType || (StorageType = {}));
        var Util = (function () {
            function Util() {
            }
            Util._getLocalStorageObject = function () {
                return Util._getVerifiedStorageObject(StorageType.LocalStorage);
            };
            Util._getVerifiedStorageObject = function (storageType) {
                var storage = null;
                var fail;
                var uid;
                try {
                    uid = new Date;
                    storage = storageType === StorageType.LocalStorage ? window.localStorage : window.sessionStorage;
                    storage.setItem(uid, uid);
                    fail = storage.getItem(uid) != uid;
                    storage.removeItem(uid);
                    if (fail) {
                        storage = null;
                    }
                }
                catch (exception) {
                    storage = null;
                }
                return storage;
            };
            Util.canUseLocalStorage = function () {
                return !!Util._getLocalStorageObject();
            };
            Util.getStorage = function (name) {
                var storage = Util._getLocalStorageObject();
                if (storage !== null) {
                    try {
                        return storage.getItem(name);
                    }
                    catch (e) {
                        var message = new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_BrowserCannotReadLocalStorage, ""Browser failed read of local storage. "" + Util.getExceptionName(e), { exception: Util.dump(e) });
                        ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.WARNING, message);
                    }
                }
                return null;
            };
            Util.setStorage = function (name, data) {
                var storage = Util._getLocalStorageObject();
                if (storage !== null) {
                    try {
                        storage.setItem(name, data);
                        return true;
                    }
                    catch (e) {
                        var message = new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_BrowserCannotWriteLocalStorage, ""Browser failed write to local storage. "" + Util.getExceptionName(e), { exception: Util.dump(e) });
                        ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.WARNING, message);
                    }
                }
                return false;
            };
            Util.removeStorage = function (name) {
                var storage = Util._getLocalStorageObject();
                if (storage !== null) {
                    try {
                        storage.removeItem(name);
                        return true;
                    }
                    catch (e) {
                        var message = new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_BrowserFailedRemovalFromLocalStorage, ""Browser failed removal of local storage item. "" + Util.getExceptionName(e), { exception: Util.dump(e) });
                        ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.WARNING, message);
                    }
                }
                return false;
            };
            Util._getSessionStorageObject = function () {
                return Util._getVerifiedStorageObject(StorageType.SessionStorage);
            };
            Util.canUseSessionStorage = function () {
                return !!Util._getSessionStorageObject();
            };
            Util.getSessionStorageKeys = function () {
                var keys = [];
                if (Util.canUseSessionStorage()) {
                    for (var key in window.sessionStorage) {
                        keys.push(key);
                    }
                }
                return keys;
            };
            Util.getSessionStorage = function (name) {
                var storage = Util._getSessionStorageObject();
                if (storage !== null) {
                    try {
                        return storage.getItem(name);
                    }
                    catch (e) {
                        var message = new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_BrowserCannotReadSessionStorage, ""Browser failed read of session storage. "" + Util.getExceptionName(e), { exception: Util.dump(e) });
                        ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, message);
                    }
                }
                return null;
            };
            Util.setSessionStorage = function (name, data) {
                var storage = Util._getSessionStorageObject();
                if (storage !== null) {
                    try {
                        storage.setItem(name, data);
                        return true;
                    }
                    catch (e) {
                        var message = new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_BrowserCannotWriteSessionStorage, ""Browser failed write to session storage. "" + Util.getExceptionName(e), { exception: Util.dump(e) });
                        ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, message);
                    }
                }
                return false;
            };
            Util.removeSessionStorage = function (name) {
                var storage = Util._getSessionStorageObject();
                if (storage !== null) {
                    try {
                        storage.removeItem(name);
                        return true;
                    }
                    catch (e) {
                        var message = new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_BrowserFailedRemovalFromSessionStorage, ""Browser failed removal of session storage item. "" + Util.getExceptionName(e), { exception: Util.dump(e) });
                        ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, message);
                    }
                }
                return false;
            };
            Util.setCookie = function (name, value, domain) {
                var domainAttrib = """";
                if (domain) {
                    domainAttrib = "";domain="" + domain;
                }
                Util.document.cookie = name + ""="" + value + domainAttrib + "";path=/"";
            };
            Util.stringToBoolOrDefault = function (str) {
                if (!str) {
                    return false;
                }
                return str.toString().toLowerCase() === ""true"";
            };
            Util.getCookie = function (name) {
                var value = """";
                if (name && name.length) {
                    var cookieName = name + ""="";
                    var cookies = Util.document.cookie.split("";"");
                    for (var i = 0; i < cookies.length; i++) {
                        var cookie = cookies[i];
                        cookie = Util.trim(cookie);
                        if (cookie && cookie.indexOf(cookieName) === 0) {
                            value = cookie.substring(cookieName.length, cookies[i].length);
                            break;
                        }
                    }
                }
                return value;
            };
            Util.deleteCookie = function (name) {
                Util.document.cookie = name + ""=;path=/;expires=Thu, 01 Jan 1970 00:00:01 GMT;"";
            };
            Util.trim = function (str) {
                if (typeof str !== ""string"")
                    return str;
                return str.replace(/^\s+|\s+$/g, """");
            };
            Util.newId = function () {
                var base64chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/';
                var result = """";
                var random = Math.random() * 1073741824;
                while (random > 0) {
                    var char = base64chars.charAt(random % 64);
                    result += char;
                    random = Math.floor(random / 64);
                }
                return result;
            };
            Util.isArray = function (obj) {
                return Object.prototype.toString.call(obj) === ""[object Array]"";
            };
            Util.isError = function (obj) {
                return Object.prototype.toString.call(obj) === ""[object Error]"";
            };
            Util.isDate = function (obj) {
                return Object.prototype.toString.call(obj) === ""[object Date]"";
            };
            Util.toISOStringForIE8 = function (date) {
                if (Util.isDate(date)) {
                    if (Date.prototype.toISOString) {
                        return date.toISOString();
                    }
                    else {
                        function pad(number) {
                            var r = String(number);
                            if (r.length === 1) {
                                r = ""0"" + r;
                            }
                            return r;
                        }
                        return date.getUTCFullYear()
                            + ""-"" + pad(date.getUTCMonth() + 1)
                            + ""-"" + pad(date.getUTCDate())
                            + ""T"" + pad(date.getUTCHours())
                            + "":"" + pad(date.getUTCMinutes())
                            + "":"" + pad(date.getUTCSeconds())
                            + ""."" + String((date.getUTCMilliseconds() / 1000).toFixed(3)).slice(2, 5)
                            + ""Z"";
                    }
                }
            };
            Util.getIEVersion = function (userAgentStr) {
                if (userAgentStr === void 0) { userAgentStr = null; }
                var myNav = userAgentStr ? userAgentStr.toLowerCase() : navigator.userAgent.toLowerCase();
                return (myNav.indexOf('msie') != -1) ? parseInt(myNav.split('msie')[1]) : null;
            };
            Util.msToTimeSpan = function (totalms) {
                if (isNaN(totalms) || totalms < 0) {
                    totalms = 0;
                }
                var ms = """" + totalms % 1000;
                var sec = """" + Math.floor(totalms / 1000) % 60;
                var min = """" + Math.floor(totalms / (1000 * 60)) % 60;
                var hour = """" + Math.floor(totalms / (1000 * 60 * 60)) % 24;
                ms = ms.length === 1 ? ""00"" + ms : ms.length === 2 ? ""0"" + ms : ms;
                sec = sec.length < 2 ? ""0"" + sec : sec;
                min = min.length < 2 ? ""0"" + min : min;
                hour = hour.length < 2 ? ""0"" + hour : hour;
                return hour + "":"" + min + "":"" + sec + ""."" + ms;
            };
            Util.isCrossOriginError = function (message, url, lineNumber, columnNumber, error) {
                return (message === ""Script error."" || message === ""Script error"") && error === null;
            };
            Util.dump = function (object) {
                var objectTypeDump = Object.prototype.toString.call(object);
                var propertyValueDump = JSON.stringify(object);
                if (objectTypeDump === ""[object Error]"") {
                    propertyValueDump = ""{ stack: '"" + object.stack + ""', message: '"" + object.message + ""', name: '"" + object.name + ""'"";
                }
                return objectTypeDump + propertyValueDump;
            };
            Util.getExceptionName = function (object) {
                var objectTypeDump = Object.prototype.toString.call(object);
                if (objectTypeDump === ""[object Error]"") {
                    return object.name;
                }
                return """";
            };
            Util.addEventHandler = function (eventName, callback) {
                if (!window || typeof eventName !== 'string' || typeof callback !== 'function') {
                    return false;
                }
                var verbEventName = 'on' + eventName;
                if (window.addEventListener) {
                    window.addEventListener(eventName, callback, false);
                }
                else if (window[""attachEvent""]) {
                    window[""attachEvent""].call(verbEventName, callback);
                }
                else {
                    return false;
                }
                return true;
            };
            Util.document = typeof document !== ""undefined"" ? document : {};
            Util.NotSpecified = ""not_specified"";
            return Util;
        })();
        ApplicationInsights.Util = Util;
        var UrlHelper = (function () {
            function UrlHelper() {
            }
            UrlHelper.parseUrl = function (url) {
                if (!UrlHelper.htmlAnchorElement) {
                    UrlHelper.htmlAnchorElement = UrlHelper.document.createElement('a');
                }
                UrlHelper.htmlAnchorElement.href = url;
                return UrlHelper.htmlAnchorElement;
            };
            UrlHelper.getAbsoluteUrl = function (url) {
                var result;
                var a = UrlHelper.parseUrl(url);
                if (a) {
                    result = a.href;
                }
                return result;
            };
            UrlHelper.getPathName = function (url) {
                var result;
                var a = UrlHelper.parseUrl(url);
                if (a) {
                    result = a.pathname;
                }
                return result;
            };
            UrlHelper.document = typeof document !== ""undefined"" ? document : {};
            return UrlHelper;
        })();
        ApplicationInsights.UrlHelper = UrlHelper;
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""../logging.ts"" />
/// <reference path=""../util.ts"" />
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        ""use strict"";
        var extensions = (function () {
            function extensions() {
            }
            extensions.IsNullOrUndefined = function (obj) {
                return typeof (obj) === ""undefined"" || obj === null;
            };
            return extensions;
        })();
        ApplicationInsights.extensions = extensions;
        var stringUtils = (function () {
            function stringUtils() {
            }
            stringUtils.GetLength = function (strObject) {
                var res = 0;
                if (!extensions.IsNullOrUndefined(strObject)) {
                    var stringified = """";
                    try {
                        stringified = strObject.toString();
                    }
                    catch (ex) {
                    }
                    res = stringified.length;
                    res = isNaN(res) ? 0 : res;
                }
                return res;
            };
            return stringUtils;
        })();
        ApplicationInsights.stringUtils = stringUtils;
        var dateTime = (function () {
            function dateTime() {
            }
            dateTime.Now = (window.performance && window.performance.now) ?
                function () {
                    return performance.now();
                }
                :
                    function () {
                        return new Date().getTime();
                    };
            dateTime.GetDuration = function (start, end) {
                var result = null;
                if (start !== 0 && end !== 0 && !extensions.IsNullOrUndefined(start) && !extensions.IsNullOrUndefined(end)) {
                    result = end - start;
                }
                return result;
            };
            return dateTime;
        })();
        ApplicationInsights.dateTime = dateTime;
        var EventHelper = (function () {
            function EventHelper() {
            }
            EventHelper.AttachEvent = function (obj, eventNameWithoutOn, handlerRef) {
                var result = false;
                if (!extensions.IsNullOrUndefined(obj)) {
                    if (!extensions.IsNullOrUndefined(obj.attachEvent)) {
                        obj.attachEvent(""on"" + eventNameWithoutOn, handlerRef);
                        result = true;
                    }
                    else {
                        if (!extensions.IsNullOrUndefined(obj.addEventListener)) {
                            obj.addEventListener(eventNameWithoutOn, handlerRef, false);
                            result = true;
                        }
                    }
                }
                return result;
            };
            EventHelper.DetachEvent = function (obj, eventNameWithoutOn, handlerRef) {
                if (!extensions.IsNullOrUndefined(obj)) {
                    if (!extensions.IsNullOrUndefined(obj.detachEvent)) {
                        obj.detachEvent(""on"" + eventNameWithoutOn, handlerRef);
                    }
                    else {
                        if (!extensions.IsNullOrUndefined(obj.removeEventListener)) {
                            obj.removeEventListener(eventNameWithoutOn, handlerRef, false);
                        }
                    }
                }
            };
            return EventHelper;
        })();
        ApplicationInsights.EventHelper = EventHelper;
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""../logging.ts"" />
/// <reference path=""../util.ts"" />
/// <reference path=""./ajaxUtils.ts"" />
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        ""use strict"";
        var XHRMonitoringState = (function () {
            function XHRMonitoringState() {
                this.openDone = false;
                this.setRequestHeaderDone = false;
                this.sendDone = false;
                this.abortDone = false;
                this.onreadystatechangeCallbackAttached = false;
            }
            return XHRMonitoringState;
        })();
        ApplicationInsights.XHRMonitoringState = XHRMonitoringState;
        var ajaxRecord = (function () {
            function ajaxRecord(id) {
                this.completed = false;
                this.requestHeadersSize = null;
                this.ttfb = null;
                this.responseReceivingDuration = null;
                this.callbackDuration = null;
                this.ajaxTotalDuration = null;
                this.aborted = null;
                this.pageUrl = null;
                this.requestUrl = null;
                this.requestSize = 0;
                this.method = null;
                this.status = null;
                this.requestSentTime = null;
                this.responseStartedTime = null;
                this.responseFinishedTime = null;
                this.callbackFinishedTime = null;
                this.endTime = null;
                this.originalOnreadystatechage = null;
                this.xhrMonitoringState = new XHRMonitoringState();
                this.clientFailure = 0;
                this.CalculateMetrics = function () {
                    var self = this;
                    self.ajaxTotalDuration = ApplicationInsights.dateTime.GetDuration(self.requestSentTime, self.responseFinishedTime);
                };
                this.id = id;
            }
            ajaxRecord.prototype.getAbsoluteUrl = function () {
                return this.requestUrl ? ApplicationInsights.UrlHelper.getAbsoluteUrl(this.requestUrl) : null;
            };
            ajaxRecord.prototype.getPathName = function () {
                return this.requestUrl ? ApplicationInsights.UrlHelper.getPathName(this.requestUrl) : null;
            };
            return ajaxRecord;
        })();
        ApplicationInsights.ajaxRecord = ajaxRecord;
        ;
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
;
/// <reference path=""../logging.ts"" />
/// <reference path=""../util.ts"" />
/// <reference path=""./ajaxUtils.ts"" />
/// <reference path=""./ajaxRecord.ts"" />
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        ""use strict"";
        var AjaxMonitor = (function () {
            function AjaxMonitor(appInsights) {
                this.currentWindowHost = window.location.host;
                this.appInsights = appInsights;
                this.initialized = false;
                this.Init();
            }
            AjaxMonitor.prototype.Init = function () {
                if (this.supportsMonitoring()) {
                    this.instrumentOpen();
                    this.instrumentSend();
                    this.instrumentAbort();
                    this.initialized = true;
                }
            };
            AjaxMonitor.prototype.isMonitoredInstance = function (xhr, excludeAjaxDataValidation) {
                return this.initialized
                    && (excludeAjaxDataValidation === true || !ApplicationInsights.extensions.IsNullOrUndefined(xhr.ajaxData))
                    && xhr[AjaxMonitor.DisabledPropertyName] !== true;
            };
            AjaxMonitor.prototype.supportsMonitoring = function () {
                var result = false;
                if (!ApplicationInsights.extensions.IsNullOrUndefined(XMLHttpRequest)) {
                    result = true;
                }
                return result;
            };
            AjaxMonitor.prototype.instrumentOpen = function () {
                var originalOpen = XMLHttpRequest.prototype.open;
                var ajaxMonitorInstance = this;
                XMLHttpRequest.prototype.open = function (method, url, async) {
                    try {
                        if (ajaxMonitorInstance.isMonitoredInstance(this, true) &&
                            (!this.ajaxData ||
                                !this.ajaxData.xhrMonitoringState.openDone)) {
                            ajaxMonitorInstance.openHandler(this, method, url, async);
                        }
                    }
                    catch (e) {
                        ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_FailedMonitorAjaxOpen, ""Failed to monitor XMLHttpRequest.open, monitoring data for this ajax call may be incorrect."", {
                            ajaxDiagnosticsMessage: AjaxMonitor.getFailedAjaxDiagnosticsMessage(this),
                            exception: Microsoft.ApplicationInsights.Util.dump(e)
                        }));
                    }
                    return originalOpen.apply(this, arguments);
                };
            };
            AjaxMonitor.prototype.openHandler = function (xhr, method, url, async) {
                var ajaxData = new ApplicationInsights.ajaxRecord(ApplicationInsights.Util.newId());
                ajaxData.method = method;
                ajaxData.requestUrl = url;
                ajaxData.xhrMonitoringState.openDone = true;
                xhr.ajaxData = ajaxData;
                this.attachToOnReadyStateChange(xhr);
            };
            AjaxMonitor.getFailedAjaxDiagnosticsMessage = function (xhr) {
                var result = """";
                try {
                    if (!ApplicationInsights.extensions.IsNullOrUndefined(xhr) &&
                        !ApplicationInsights.extensions.IsNullOrUndefined(xhr.ajaxData) &&
                        !ApplicationInsights.extensions.IsNullOrUndefined(xhr.ajaxData.requestUrl)) {
                        result += ""(url: '"" + xhr.ajaxData.requestUrl + ""')"";
                    }
                }
                catch (e) { }
                return result;
            };
            AjaxMonitor.prototype.instrumentSend = function () {
                var originalSend = XMLHttpRequest.prototype.send;
                var ajaxMonitorInstance = this;
                XMLHttpRequest.prototype.send = function (content) {
                    try {
                        if (ajaxMonitorInstance.isMonitoredInstance(this) && !this.ajaxData.xhrMonitoringState.sendDone) {
                            ajaxMonitorInstance.sendHandler(this, content);
                        }
                    }
                    catch (e) {
                        ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_FailedMonitorAjaxSend, ""Failed to monitor XMLHttpRequest, monitoring data for this ajax call may be incorrect."", {
                            ajaxDiagnosticsMessage: AjaxMonitor.getFailedAjaxDiagnosticsMessage(this),
                            exception: Microsoft.ApplicationInsights.Util.dump(e)
                        }));
                    }
                    return originalSend.apply(this, arguments);
                };
            };
            AjaxMonitor.prototype.sendHandler = function (xhr, content) {
                xhr.ajaxData.requestSentTime = ApplicationInsights.dateTime.Now();
                if (!this.appInsights.config.disableCorrelationHeaders && (ApplicationInsights.UrlHelper.parseUrl(xhr.ajaxData.getAbsoluteUrl()).host == this.currentWindowHost)) {
                    xhr.setRequestHeader(""x-ms-request-id"", xhr.ajaxData.id);
                }
                xhr.ajaxData.xhrMonitoringState.sendDone = true;
            };
            AjaxMonitor.prototype.instrumentAbort = function () {
                var originalAbort = XMLHttpRequest.prototype.abort;
                var ajaxMonitorInstance = this;
                XMLHttpRequest.prototype.abort = function () {
                    try {
                        if (ajaxMonitorInstance.isMonitoredInstance(this) && !this.ajaxData.xhrMonitoringState.abortDone) {
                            this.ajaxData.aborted = 1;
                            this.ajaxData.xhrMonitoringState.abortDone = true;
                        }
                    }
                    catch (e) {
                        ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_FailedMonitorAjaxAbort, ""Failed to monitor XMLHttpRequest.abort, monitoring data for this ajax call may be incorrect."", {
                            ajaxDiagnosticsMessage: AjaxMonitor.getFailedAjaxDiagnosticsMessage(this),
                            exception: Microsoft.ApplicationInsights.Util.dump(e)
                        }));
                    }
                    return originalAbort.apply(this, arguments);
                };
            };
            AjaxMonitor.prototype.attachToOnReadyStateChange = function (xhr) {
                var ajaxMonitorInstance = this;
                xhr.ajaxData.xhrMonitoringState.onreadystatechangeCallbackAttached = ApplicationInsights.EventHelper.AttachEvent(xhr, ""readystatechange"", function () {
                    try {
                        if (ajaxMonitorInstance.isMonitoredInstance(xhr)) {
                            if (xhr.readyState === 4) {
                                ajaxMonitorInstance.onAjaxComplete(xhr);
                            }
                        }
                    }
                    catch (e) {
                        var exceptionText = Microsoft.ApplicationInsights.Util.dump(e);
                        if (!exceptionText || exceptionText.toLowerCase().indexOf(""c00c023f"") == -1) {
                            ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_FailedMonitorAjaxRSC, ""Failed to monitor XMLHttpRequest 'readystatechange' event handler, monitoring data for this ajax call may be incorrect."", {
                                ajaxDiagnosticsMessage: AjaxMonitor.getFailedAjaxDiagnosticsMessage(xhr),
                                exception: Microsoft.ApplicationInsights.Util.dump(e)
                            }));
                        }
                    }
                });
            };
            AjaxMonitor.prototype.onAjaxComplete = function (xhr) {
                xhr.ajaxData.responseFinishedTime = ApplicationInsights.dateTime.Now();
                xhr.ajaxData.status = xhr.status;
                xhr.ajaxData.CalculateMetrics();
                if (xhr.ajaxData.ajaxTotalDuration < 0) {
                    ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_FailedMonitorAjaxDur, ""Failed to calculate the duration of the ajax call, monitoring data for this ajax call won't be sent."", {
                        ajaxDiagnosticsMessage: AjaxMonitor.getFailedAjaxDiagnosticsMessage(xhr),
                        requestSentTime: xhr.ajaxData.requestSentTime,
                        responseFinishedTime: xhr.ajaxData.responseFinishedTime
                    }));
                }
                else {
                    this.appInsights.trackAjax(xhr.ajaxData.id, xhr.ajaxData.getAbsoluteUrl(), xhr.ajaxData.getPathName(), xhr.ajaxData.ajaxTotalDuration, (+(xhr.ajaxData.status)) >= 200 && (+(xhr.ajaxData.status)) < 400, +xhr.ajaxData.status);
                    xhr.ajaxData = null;
                }
            };
            AjaxMonitor.instrumentedByAppInsightsName = ""InstrumentedByAppInsights"";
            AjaxMonitor.DisabledPropertyName = ""Microsoft_ApplicationInsights_BypassAjaxInstrumentation"";
            return AjaxMonitor;
        })();
        ApplicationInsights.AjaxMonitor = AjaxMonitor;
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var HashCodeScoreGenerator = (function () {
            function HashCodeScoreGenerator() {
            }
            HashCodeScoreGenerator.prototype.getHashCodeScore = function (key) {
                var score = this.getHashCode(key) / HashCodeScoreGenerator.INT_MAX_VALUE;
                return score * 100;
            };
            HashCodeScoreGenerator.prototype.getHashCode = function (input) {
                if (input == """") {
                    return 0;
                }
                while (input.length < HashCodeScoreGenerator.MIN_INPUT_LENGTH) {
                    input = input.concat(input);
                }
                var hash = 5381;
                for (var i = 0; i < input.length; ++i) {
                    hash = ((hash << 5) + hash) + input.charCodeAt(i);
                    hash = hash & hash;
                }
                return Math.abs(hash);
            };
            HashCodeScoreGenerator.INT_MAX_VALUE = 2147483647;
            HashCodeScoreGenerator.MIN_INPUT_LENGTH = 8;
            return HashCodeScoreGenerator;
        })();
        ApplicationInsights.HashCodeScoreGenerator = HashCodeScoreGenerator;
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""logging.ts"" />
/// <reference path=""util.ts"" />
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        ""use strict"";
        (function (FieldType) {
            FieldType[FieldType[""Default""] = 0] = ""Default"";
            FieldType[FieldType[""Required""] = 1] = ""Required"";
            FieldType[FieldType[""Array""] = 2] = ""Array"";
            FieldType[FieldType[""Hidden""] = 4] = ""Hidden"";
        })(ApplicationInsights.FieldType || (ApplicationInsights.FieldType = {}));
        var FieldType = ApplicationInsights.FieldType;
        ;
        var Serializer = (function () {
            function Serializer() {
            }
            Serializer.serialize = function (input) {
                var output = Serializer._serializeObject(input, ""root"");
                return JSON.stringify(output);
            };
            Serializer._serializeObject = function (source, name) {
                var circularReferenceCheck = ""__aiCircularRefCheck"";
                var output = {};
                if (!source) {
                    ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_CannotSerializeObject, ""cannot serialize object because it is null or undefined"", { name: name }));
                    return output;
                }
                if (source[circularReferenceCheck]) {
                    ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_CircularReferenceDetected, ""Circular reference detected while serializing object"", { name: name }));
                    return output;
                }
                if (!source.aiDataContract) {
                    if (name === ""measurements"") {
                        output = Serializer._serializeStringMap(source, ""number"", name);
                    }
                    else if (name === ""properties"") {
                        output = Serializer._serializeStringMap(source, ""string"", name);
                    }
                    else if (name === ""tags"") {
                        output = Serializer._serializeStringMap(source, ""string"", name);
                    }
                    else if (ApplicationInsights.Util.isArray(source)) {
                        output = Serializer._serializeArray(source, name);
                    }
                    else {
                        ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_CannotSerializeObjectNonSerializable, ""Attempting to serialize an object which does not implement ISerializable"", { name: name }));
                        try {
                            JSON.stringify(source);
                            output = source;
                        }
                        catch (e) {
                            ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, e && typeof e.toString === 'function' ? e.toString() : ""Error serializing object"");
                        }
                    }
                    return output;
                }
                source[circularReferenceCheck] = true;
                for (var field in source.aiDataContract) {
                    var contract = source.aiDataContract[field];
                    var isRequired = (typeof contract === ""function"") ? (contract() & FieldType.Required) : (contract & FieldType.Required);
                    var isHidden = (typeof contract === ""function"") ? (contract() & FieldType.Hidden) : (contract & FieldType.Hidden);
                    var isArray = contract & FieldType.Array;
                    var isPresent = source[field] !== undefined;
                    var isObject = typeof source[field] === ""object"" && source[field] !== null;
                    if (isRequired && !isPresent && !isArray) {
                        ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_MissingRequiredFieldSpecification, ""Missing required field specification. The field is required but not present on source"", { field: field, name: name }));
                        continue;
                    }
                    if (isHidden) {
                        continue;
                    }
                    var value;
                    if (isObject) {
                        if (isArray) {
                            value = Serializer._serializeArray(source[field], field);
                        }
                        else {
                            value = Serializer._serializeObject(source[field], field);
                        }
                    }
                    else {
                        value = source[field];
                    }
                    if (value !== undefined) {
                        output[field] = value;
                    }
                }
                delete source[circularReferenceCheck];
                return output;
            };
            Serializer._serializeArray = function (sources, name) {
                var output = undefined;
                if (!!sources) {
                    if (!ApplicationInsights.Util.isArray(sources)) {
                        ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_ItemNotInArray, ""This field was specified as an array in the contract but the item is not an array.\r\n"", { name: name }));
                    }
                    else {
                        output = [];
                        for (var i = 0; i < sources.length; i++) {
                            var source = sources[i];
                            var item = Serializer._serializeObject(source, name + ""["" + i + ""]"");
                            output.push(item);
                        }
                    }
                }
                return output;
            };
            Serializer._serializeStringMap = function (map, expectedType, name) {
                var output = undefined;
                if (map) {
                    output = {};
                    for (var field in map) {
                        var value = map[field];
                        if (expectedType === ""string"") {
                            if (value === undefined) {
                                output[field] = ""undefined"";
                            }
                            else if (value === null) {
                                output[field] = ""null"";
                            }
                            else if (!value.toString) {
                                output[field] = ""invalid field: toString() is not defined."";
                            }
                            else {
                                output[field] = value.toString();
                            }
                        }
                        else if (expectedType === ""number"") {
                            if (value === undefined) {
                                output[field] = ""undefined"";
                            }
                            else if (value === null) {
                                output[field] = ""null"";
                            }
                            else {
                                var num = parseFloat(value);
                                if (isNaN(num)) {
                                    output[field] = ""NaN"";
                                }
                                else {
                                    output[field] = num;
                                }
                            }
                        }
                        else {
                            output[field] = ""invalid field: "" + name + "" is of unknown type."";
                            ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, output[field]);
                        }
                    }
                }
                return output;
            };
            return Serializer;
        })();
        ApplicationInsights.Serializer = Serializer;
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    var Telemetry;
    (function (Telemetry) {
        ""use strict"";
        var Base = (function () {
            function Base() {
            }
            return Base;
        })();
        Telemetry.Base = Base;
    })(Telemetry = Microsoft.Telemetry || (Microsoft.Telemetry = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""Base.ts"" />
var Microsoft;
(function (Microsoft) {
    var Telemetry;
    (function (Telemetry) {
        ""use strict"";
        var Envelope = (function () {
            function Envelope() {
                this.ver = 1;
                this.sampleRate = 100.0;
                this.tags = {};
            }
            return Envelope;
        })();
        Telemetry.Envelope = Envelope;
    })(Telemetry = Microsoft.Telemetry || (Microsoft.Telemetry = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""../../Contracts/Generated/Envelope.ts"" />
/// <reference path=""../../Contracts/Generated/Base.ts"" />
/// <reference path=""../../Util.ts""/>
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Telemetry;
        (function (Telemetry) {
            var Common;
            (function (Common) {
                ""use strict"";
                var Envelope = (function (_super) {
                    __extends(Envelope, _super);
                    function Envelope(data, name) {
                        var _this = this;
                        _super.call(this);
                        this.name = name;
                        this.data = data;
                        this.time = ApplicationInsights.Util.toISOStringForIE8(new Date());
                        this.aiDataContract = {
                            time: ApplicationInsights.FieldType.Required,
                            iKey: ApplicationInsights.FieldType.Required,
                            name: ApplicationInsights.FieldType.Required,
                            sampleRate: function () {
                                return (_this.sampleRate == 100) ? ApplicationInsights.FieldType.Hidden : ApplicationInsights.FieldType.Required;
                            },
                            tags: ApplicationInsights.FieldType.Required,
                            data: ApplicationInsights.FieldType.Required
                        };
                    }
                    return Envelope;
                })(Microsoft.Telemetry.Envelope);
                Common.Envelope = Envelope;
            })(Common = Telemetry.Common || (Telemetry.Common = {}));
        })(Telemetry = ApplicationInsights.Telemetry || (ApplicationInsights.Telemetry = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""../../Contracts/Generated/Base.ts""/>
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Telemetry;
        (function (Telemetry) {
            var Common;
            (function (Common) {
                ""use strict"";
                var Base = (function (_super) {
                    __extends(Base, _super);
                    function Base() {
                        _super.apply(this, arguments);
                        this.aiDataContract = {};
                    }
                    return Base;
                })(Microsoft.Telemetry.Base);
                Common.Base = Base;
            })(Common = Telemetry.Common || (Telemetry.Common = {}));
        })(Telemetry = ApplicationInsights.Telemetry || (ApplicationInsights.Telemetry = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
var AI;
(function (AI) {
    ""use strict"";
    var ContextTagKeys = (function () {
        function ContextTagKeys() {
            this.applicationVersion = ""ai.application.ver"";
            this.applicationBuild = ""ai.application.build"";
            this.applicationTypeId = ""ai.application.typeId"";
            this.applicationId = ""ai.application.applicationId"";
            this.deviceId = ""ai.device.id"";
            this.deviceIp = ""ai.device.ip"";
            this.deviceLanguage = ""ai.device.language"";
            this.deviceLocale = ""ai.device.locale"";
            this.deviceModel = ""ai.device.model"";
            this.deviceNetwork = ""ai.device.network"";
            this.deviceNetworkName = ""ai.device.networkName"";
            this.deviceOEMName = ""ai.device.oemName"";
            this.deviceOS = ""ai.device.os"";
            this.deviceOSVersion = ""ai.device.osVersion"";
            this.deviceRoleInstance = ""ai.device.roleInstance"";
            this.deviceRoleName = ""ai.device.roleName"";
            this.deviceScreenResolution = ""ai.device.screenResolution"";
            this.deviceType = ""ai.device.type"";
            this.deviceMachineName = ""ai.device.machineName"";
            this.deviceVMName = ""ai.device.vmName"";
            this.locationIp = ""ai.location.ip"";
            this.operationId = ""ai.operation.id"";
            this.operationName = ""ai.operation.name"";
            this.operationParentId = ""ai.operation.parentId"";
            this.operationRootId = ""ai.operation.rootId"";
            this.operationSyntheticSource = ""ai.operation.syntheticSource"";
            this.operationIsSynthetic = ""ai.operation.isSynthetic"";
            this.operationCorrelationVector = ""ai.operation.correlationVector"";
            this.sessionId = ""ai.session.id"";
            this.sessionIsFirst = ""ai.session.isFirst"";
            this.sessionIsNew = ""ai.session.isNew"";
            this.userAccountAcquisitionDate = ""ai.user.accountAcquisitionDate"";
            this.userAccountId = ""ai.user.accountId"";
            this.userAgent = ""ai.user.userAgent"";
            this.userId = ""ai.user.id"";
            this.userStoreRegion = ""ai.user.storeRegion"";
            this.userAuthUserId = ""ai.user.authUserId"";
            this.userAnonymousUserAcquisitionDate = ""ai.user.anonUserAcquisitionDate"";
            this.userAuthenticatedUserAcquisitionDate = ""ai.user.authUserAcquisitionDate"";
            this.sampleRate = ""ai.sample.sampleRate"";
            this.cloudName = ""ai.cloud.name"";
            this.cloudRoleVer = ""ai.cloud.roleVer"";
            this.cloudEnvironment = ""ai.cloud.environment"";
            this.cloudLocation = ""ai.cloud.location"";
            this.cloudDeploymentUnit = ""ai.cloud.deploymentUnit"";
            this.serverDeviceOS = ""ai.serverDevice.os"";
            this.serverDeviceOSVer = ""ai.serverDevice.osVer"";
            this.internalSdkVersion = ""ai.internal.sdkVersion"";
            this.internalAgentVersion = ""ai.internal.agentVersion"";
            this.internalDataCollectorReceivedTime = ""ai.internal.dataCollectorReceivedTime"";
            this.internalProfileId = ""ai.internal.profileId"";
            this.internalProfileClassId = ""ai.internal.profileClassId"";
            this.internalAccountId = ""ai.internal.accountId"";
            this.internalApplicationName = ""ai.internal.applicationName"";
            this.internalInstrumentationKey = ""ai.internal.instrumentationKey"";
            this.internalTelemetryItemId = ""ai.internal.telemetryItemId"";
            this.internalApplicationType = ""ai.internal.applicationType"";
            this.internalRequestSource = ""ai.internal.requestSource"";
            this.internalFlowType = ""ai.internal.flowType"";
            this.internalIsAudit = ""ai.internal.isAudit"";
            this.internalTrackingSourceId = ""ai.internal.trackingSourceId"";
            this.internalTrackingType = ""ai.internal.trackingType"";
            this.internalIsDiagnosticExample = ""ai.internal.isDiagnosticExample"";
        }
        return ContextTagKeys;
    })();
    AI.ContextTagKeys = ContextTagKeys;
})(AI || (AI = {}));
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Context;
        (function (Context) {
            ""use strict"";
            var Application = (function () {
                function Application() {
                }
                return Application;
            })();
            Context.Application = Application;
        })(Context = ApplicationInsights.Context || (ApplicationInsights.Context = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Context;
        (function (Context) {
            ""use strict"";
            var Device = (function () {
                function Device() {
                    this.id = ""browser"";
                    this.type = ""Browser"";
                }
                return Device;
            })();
            Context.Device = Device;
        })(Context = ApplicationInsights.Context || (ApplicationInsights.Context = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Context;
        (function (Context) {
            ""use strict"";
            var Internal = (function () {
                function Internal() {
                    this.sdkVersion = ""JavaScript:"" + ApplicationInsights.Version;
                }
                return Internal;
            })();
            Context.Internal = Internal;
        })(Context = ApplicationInsights.Context || (ApplicationInsights.Context = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Context;
        (function (Context) {
            ""use strict"";
            var Location = (function () {
                function Location() {
                }
                return Location;
            })();
            Context.Location = Location;
        })(Context = ApplicationInsights.Context || (ApplicationInsights.Context = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""../util.ts"" />
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Context;
        (function (Context) {
            ""use strict"";
            var Operation = (function () {
                function Operation() {
                    this.id = ApplicationInsights.Util.newId();
                    if (window && window.location && window.location.pathname) {
                        this.name = window.location.pathname;
                    }
                }
                return Operation;
            })();
            Context.Operation = Operation;
        })(Context = ApplicationInsights.Context || (ApplicationInsights.Context = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""./HashCodeScoreGenerator.ts"" />
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var SamplingScoreGenerator = (function () {
            function SamplingScoreGenerator() {
                this.hashCodeGeneragor = new ApplicationInsights.HashCodeScoreGenerator();
            }
            SamplingScoreGenerator.prototype.getSamplingScore = function (envelope) {
                var tagKeys = new AI.ContextTagKeys();
                var score = 0;
                if (envelope.tags[tagKeys.userId]) {
                    score = this.hashCodeGeneragor.getHashCodeScore(envelope.tags[tagKeys.userId]);
                }
                else if (envelope.tags[tagKeys.operationId]) {
                    score = this.hashCodeGeneragor.getHashCodeScore(envelope.tags[tagKeys.operationId]);
                }
                else {
                    score = Math.random();
                }
                return score;
            };
            return SamplingScoreGenerator;
        })();
        ApplicationInsights.SamplingScoreGenerator = SamplingScoreGenerator;
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""../SamplingScoreGenerator.ts"" />
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Context;
        (function (Context) {
            ""use strict"";
            var Sample = (function () {
                function Sample(sampleRate) {
                    this.INT_MAX_VALUE = 2147483647;
                    if (sampleRate > 100 || sampleRate < 0) {
                        ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_SampleRateOutOfRange, ""Sampling rate is out of range (0..100). Sampling will be disabled, you may be sending too much data which may affect your AI service level."", { samplingRate: sampleRate }));
                        this.sampleRate = 100;
                    }
                    this.sampleRate = sampleRate;
                    this.samplingScoreGenerator = new ApplicationInsights.SamplingScoreGenerator();
                }
                Sample.prototype.isSampledIn = function (envelope) {
                    if (this.sampleRate == 100)
                        return true;
                    var score = this.samplingScoreGenerator.getSamplingScore(envelope);
                    return score < this.sampleRate;
                };
                return Sample;
            })();
            Context.Sample = Sample;
        })(Context = ApplicationInsights.Context || (ApplicationInsights.Context = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
var AI;
(function (AI) {
    ""use strict"";
    (function (SessionState) {
        SessionState[SessionState[""Start""] = 0] = ""Start"";
        SessionState[SessionState[""End""] = 1] = ""End"";
    })(AI.SessionState || (AI.SessionState = {}));
    var SessionState = AI.SessionState;
})(AI || (AI = {}));
/// <reference path=""../util.ts"" />
/// <reference path=""../Contracts/Generated/SessionState.ts""/>
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Context;
        (function (Context) {
            ""use strict"";
            var Session = (function () {
                function Session() {
                }
                return Session;
            })();
            Context.Session = Session;
            var _SessionManager = (function () {
                function _SessionManager(config) {
                    if (!config) {
                        config = {};
                    }
                    if (!(typeof config.sessionExpirationMs === ""function"")) {
                        config.sessionExpirationMs = function () { return _SessionManager.acquisitionSpan; };
                    }
                    if (!(typeof config.sessionRenewalMs === ""function"")) {
                        config.sessionRenewalMs = function () { return _SessionManager.renewalSpan; };
                    }
                    this.config = config;
                    this.automaticSession = new Session();
                }
                _SessionManager.prototype.update = function () {
                    if (!this.automaticSession.id) {
                        this.initializeAutomaticSession();
                    }
                    var now = +new Date;
                    var acquisitionExpired = now - this.automaticSession.acquisitionDate > this.config.sessionExpirationMs();
                    var renewalExpired = now - this.automaticSession.renewalDate > this.config.sessionRenewalMs();
                    if (acquisitionExpired || renewalExpired) {
                        this.automaticSession.isFirst = undefined;
                        this.renew();
                    }
                    else {
                        this.automaticSession.renewalDate = +new Date;
                        this.setCookie(this.automaticSession.id, this.automaticSession.acquisitionDate, this.automaticSession.renewalDate);
                    }
                };
                _SessionManager.prototype.backup = function () {
                    this.setStorage(this.automaticSession.id, this.automaticSession.acquisitionDate, this.automaticSession.renewalDate);
                };
                _SessionManager.prototype.initializeAutomaticSession = function () {
                    var cookie = ApplicationInsights.Util.getCookie('ai_session');
                    if (cookie && typeof cookie.split === ""function"") {
                        this.initializeAutomaticSessionWithData(cookie);
                    }
                    else {
                        var storage = ApplicationInsights.Util.getStorage('ai_session');
                        if (storage) {
                            this.initializeAutomaticSessionWithData(storage);
                        }
                    }
                    if (!this.automaticSession.id) {
                        this.automaticSession.isFirst = true;
                        this.renew();
                    }
                };
                _SessionManager.prototype.initializeAutomaticSessionWithData = function (sessionData) {
                    var params = sessionData.split(""|"");
                    if (params.length > 0) {
                        this.automaticSession.id = params[0];
                    }
                    try {
                        if (params.length > 1) {
                            var acq = +params[1];
                            this.automaticSession.acquisitionDate = +new Date(acq);
                            this.automaticSession.acquisitionDate = this.automaticSession.acquisitionDate > 0 ? this.automaticSession.acquisitionDate : 0;
                        }
                        if (params.length > 2) {
                            var renewal = +params[2];
                            this.automaticSession.renewalDate = +new Date(renewal);
                            this.automaticSession.renewalDate = this.automaticSession.renewalDate > 0 ? this.automaticSession.renewalDate : 0;
                        }
                    }
                    catch (e) {
                        ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_ErrorParsingAISessionCookie, ""Error parsing ai_session cookie, session will be reset: "" + ApplicationInsights.Util.getExceptionName(e), { exception: ApplicationInsights.Util.dump(e) }));
                    }
                    if (this.automaticSession.renewalDate == 0) {
                        ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_SessionRenewalDateIsZero, ""AI session renewal date is 0, session will be reset.""));
                    }
                };
                _SessionManager.prototype.renew = function () {
                    var now = +new Date;
                    this.automaticSession.id = ApplicationInsights.Util.newId();
                    this.automaticSession.acquisitionDate = now;
                    this.automaticSession.renewalDate = now;
                    this.setCookie(this.automaticSession.id, this.automaticSession.acquisitionDate, this.automaticSession.renewalDate);
                    if (!ApplicationInsights.Util.canUseLocalStorage()) {
                        ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_BrowserDoesNotSupportLocalStorage, ""Browser does not support local storage. Session durations will be inaccurate.""));
                    }
                };
                _SessionManager.prototype.setCookie = function (guid, acq, renewal) {
                    var acquisitionExpiry = acq + this.config.sessionExpirationMs();
                    var renewalExpiry = renewal + this.config.sessionRenewalMs();
                    var cookieExpiry = new Date();
                    var cookie = [guid, acq, renewal];
                    if (acquisitionExpiry < renewalExpiry) {
                        cookieExpiry.setTime(acquisitionExpiry);
                    }
                    else {
                        cookieExpiry.setTime(renewalExpiry);
                    }
                    var cookieDomnain = this.config.cookieDomain ? this.config.cookieDomain() : null;
                    ApplicationInsights.Util.setCookie('ai_session', cookie.join('|') + ';expires=' + cookieExpiry.toUTCString(), cookieDomnain);
                };
                _SessionManager.prototype.setStorage = function (guid, acq, renewal) {
                    ApplicationInsights.Util.setStorage('ai_session', [guid, acq, renewal].join('|'));
                };
                _SessionManager.acquisitionSpan = 86400000;
                _SessionManager.renewalSpan = 1800000;
                return _SessionManager;
            })();
            Context._SessionManager = _SessionManager;
        })(Context = ApplicationInsights.Context || (ApplicationInsights.Context = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""../util.ts"" />
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Context;
        (function (Context) {
            ""use strict"";
            var User = (function () {
                function User(config) {
                    var cookie = ApplicationInsights.Util.getCookie(User.userCookieName);
                    if (cookie) {
                        var params = cookie.split(User.cookieSeparator);
                        if (params.length > 0) {
                            this.id = params[0];
                        }
                    }
                    this.config = config;
                    if (!this.id) {
                        this.id = ApplicationInsights.Util.newId();
                        var date = new Date();
                        var acqStr = ApplicationInsights.Util.toISOStringForIE8(date);
                        this.accountAcquisitionDate = acqStr;
                        date.setTime(date.getTime() + 31536000000);
                        var newCookie = [this.id, acqStr];
                        var cookieDomain = this.config.cookieDomain ? this.config.cookieDomain() : undefined;
                        ApplicationInsights.Util.setCookie(User.userCookieName, newCookie.join(User.cookieSeparator) + ';expires=' + date.toUTCString(), cookieDomain);
                        ApplicationInsights.Util.removeStorage('ai_session');
                    }
                    this.accountId = config.accountId ? config.accountId() : undefined;
                    var authCookie = ApplicationInsights.Util.getCookie(User.authUserCookieName);
                    if (authCookie) {
                        authCookie = decodeURI(authCookie);
                        var authCookieString = authCookie.split(User.cookieSeparator);
                        if (authCookieString[0]) {
                            this.authenticatedId = authCookieString[0];
                        }
                        if (authCookieString.length > 1 && authCookieString[1]) {
                            this.accountId = authCookieString[1];
                        }
                    }
                }
                User.prototype.setAuthenticatedUserContext = function (authenticatedUserId, accountId) {
                    var isInvalidInput = !this.validateUserInput(authenticatedUserId) || (accountId && !this.validateUserInput(accountId));
                    if (isInvalidInput) {
                        ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_SetAuthContextFailedAccountName, ""Setting auth user context failed. "" +
                            ""User auth/account id should be of type string, and not contain commas, semi-colons, equal signs, spaces, or vertical-bars.""));
                        return;
                    }
                    this.authenticatedId = authenticatedUserId;
                    var authCookie = this.authenticatedId;
                    if (accountId) {
                        this.accountId = accountId;
                        authCookie = [this.authenticatedId, this.accountId].join(User.cookieSeparator);
                    }
                    ApplicationInsights.Util.setCookie(User.authUserCookieName, encodeURI(authCookie), this.config.cookieDomain());
                };
                User.prototype.clearAuthenticatedUserContext = function () {
                    this.authenticatedId = null;
                    this.accountId = null;
                    ApplicationInsights.Util.deleteCookie(User.authUserCookieName);
                };
                User.prototype.validateUserInput = function (id) {
                    if (typeof id !== 'string' ||
                        !id ||
                        id.match(/,|;|=| |\|/)) {
                        return false;
                    }
                    return true;
                };
                User.cookieSeparator = '|';
                User.userCookieName = 'ai_user';
                User.authUserCookieName = 'ai_authUser';
                return User;
            })();
            Context.User = User;
        })(Context = ApplicationInsights.Context || (ApplicationInsights.Context = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        ""use strict"";
        var DataLossAnalyzer = (function () {
            function DataLossAnalyzer() {
            }
            DataLossAnalyzer.reset = function () {
                if (DataLossAnalyzer.isEnabled()) {
                    ApplicationInsights.Util.setSessionStorage(DataLossAnalyzer.ITEMS_QUEUED_KEY, ""0"");
                }
            };
            DataLossAnalyzer.isEnabled = function () {
                return DataLossAnalyzer.enabled &&
                    DataLossAnalyzer.appInsights != null &&
                    ApplicationInsights.Util.canUseSessionStorage();
            };
            DataLossAnalyzer.getIssuesReported = function () {
                var result = (!DataLossAnalyzer.isEnabled() || isNaN(+ApplicationInsights.Util.getSessionStorage(DataLossAnalyzer.ISSUES_REPORTED_KEY))) ?
                    0 :
                    +ApplicationInsights.Util.getSessionStorage(DataLossAnalyzer.ISSUES_REPORTED_KEY);
                return result;
            };
            DataLossAnalyzer.incrementItemsQueued = function () {
                try {
                    if (DataLossAnalyzer.isEnabled()) {
                        var itemsQueued = DataLossAnalyzer.getNumberOfLostItems();
                        ++itemsQueued;
                        ApplicationInsights.Util.setSessionStorage(DataLossAnalyzer.ITEMS_QUEUED_KEY, itemsQueued.toString());
                    }
                }
                catch (e) { }
            };
            DataLossAnalyzer.decrementItemsQueued = function (countOfItemsSentSuccessfully) {
                try {
                    if (DataLossAnalyzer.isEnabled()) {
                        var itemsQueued = DataLossAnalyzer.getNumberOfLostItems();
                        itemsQueued -= countOfItemsSentSuccessfully;
                        if (itemsQueued < 0)
                            itemsQueued = 0;
                        ApplicationInsights.Util.setSessionStorage(DataLossAnalyzer.ITEMS_QUEUED_KEY, itemsQueued.toString());
                    }
                }
                catch (e) { }
            };
            DataLossAnalyzer.getNumberOfLostItems = function () {
                var result = 0;
                try {
                    if (DataLossAnalyzer.isEnabled()) {
                        result = isNaN(+ApplicationInsights.Util.getSessionStorage(DataLossAnalyzer.ITEMS_QUEUED_KEY)) ?
                            0 :
                            +ApplicationInsights.Util.getSessionStorage(DataLossAnalyzer.ITEMS_QUEUED_KEY);
                    }
                }
                catch (e) {
                    result = 0;
                }
                return result;
            };
            DataLossAnalyzer.reportLostItems = function () {
                try {
                    if (DataLossAnalyzer.isEnabled() &&
                        DataLossAnalyzer.getIssuesReported() < DataLossAnalyzer.LIMIT_PER_SESSION &&
                        DataLossAnalyzer.getNumberOfLostItems() > 0) {
                        DataLossAnalyzer.appInsights.trackTrace(""AI (Internal): Internal report DATALOSS: ""
                            + DataLossAnalyzer.getNumberOfLostItems(), null);
                        DataLossAnalyzer.appInsights.flush();
                        var issuesReported = DataLossAnalyzer.getIssuesReported();
                        ++issuesReported;
                        ApplicationInsights.Util.setSessionStorage(DataLossAnalyzer.ISSUES_REPORTED_KEY, issuesReported.toString());
                    }
                }
                catch (e) {
                    ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_FailedToReportDataLoss, ""Failed to report data loss: "" + ApplicationInsights.Util.getExceptionName(e), { exception: ApplicationInsights.Util.dump(e) }));
                }
                finally {
                    try {
                        DataLossAnalyzer.reset();
                    }
                    catch (e) { }
                }
            };
            DataLossAnalyzer.enabled = false;
            DataLossAnalyzer.LIMIT_PER_SESSION = 10;
            DataLossAnalyzer.ITEMS_QUEUED_KEY = ""AI_itemsQueued"";
            DataLossAnalyzer.ISSUES_REPORTED_KEY = ""AI_lossIssuesReported"";
            return DataLossAnalyzer;
        })();
        ApplicationInsights.DataLossAnalyzer = DataLossAnalyzer;
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""serializer.ts"" />
/// <reference path=""Telemetry/Common/Envelope.ts""/>
/// <reference path=""Telemetry/Common/Base.ts"" />
/// <reference path=""Contracts/Generated/ContextTagKeys.ts""/>
/// <reference path=""Context/Application.ts""/>
/// <reference path=""Context/Device.ts""/>
/// <reference path=""Context/Internal.ts""/>
/// <reference path=""Context/Location.ts""/>
/// <reference path=""Context/Operation.ts""/>
/// <reference path=""Context/Sample.ts""/>
/// <reference path=""Context/Session.ts""/>
/// <reference path=""Context/User.ts""/>
/// <reference path=""ajax/ajax.ts""/>
/// <reference path=""./DataLossAnalyzer.ts""/>
;
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        ""use strict"";
        var Sender = (function () {
            function Sender(config) {
                this._buffer = [];
                this._lastSend = 0;
                this._config = config;
                this._sender = null;
                if (typeof XMLHttpRequest != ""undefined"") {
                    var testXhr = new XMLHttpRequest();
                    if (""withCredentials"" in testXhr) {
                        this._sender = this._xhrSender;
                    }
                    else if (typeof XDomainRequest !== ""undefined"") {
                        this._sender = this._xdrSender;
                    }
                }
            }
            Sender.prototype.send = function (envelope) {
                var _this = this;
                try {
                    if (this._config.disableTelemetry()) {
                        return;
                    }
                    if (!envelope) {
                        ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_CannotSendEmptyTelemetry, ""Cannot send empty telemetry""));
                        return;
                    }
                    if (!this._sender) {
                        ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_SenderNotInitialized, ""Sender was not initialized""));
                        return;
                    }
                    var payload = ApplicationInsights.Serializer.serialize(envelope);
                    if (this._getSizeInBytes(this._buffer) + payload.length > this._config.maxBatchSizeInBytes()) {
                        this.triggerSend();
                    }
                    this._buffer.push(payload);
                    if (!this._timeoutHandle) {
                        this._timeoutHandle = setTimeout(function () {
                            _this._timeoutHandle = null;
                            _this.triggerSend();
                        }, this._config.maxBatchInterval());
                    }
                    ApplicationInsights.DataLossAnalyzer.incrementItemsQueued();
                }
                catch (e) {
                    ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_FailedAddingTelemetryToBuffer, ""Failed adding telemetry to the sender's buffer, some telemetry will be lost: "" + ApplicationInsights.Util.getExceptionName(e), { exception: ApplicationInsights.Util.dump(e) }));
                }
            };
            Sender.prototype._getSizeInBytes = function (list) {
                var size = 0;
                if (list && list.length) {
                    for (var i = 0; i < list.length; i++) {
                        var item = list[i];
                        if (item && item.length) {
                            size += item.length;
                        }
                    }
                }
                return size;
            };
            Sender.prototype.triggerSend = function (async) {
                var isAsync = true;
                if (typeof async === 'boolean') {
                    isAsync = async;
                }
                try {
                    if (!this._config.disableTelemetry()) {
                        if (this._buffer.length) {
                            var batch = this._config.emitLineDelimitedJson() ?
                                this._buffer.join(""\n"") :
                                ""["" + this._buffer.join("","") + ""]"";
                            this._sender(batch, isAsync, this._buffer.length);
                        }
                        this._lastSend = +new Date;
                    }
                    this._buffer.length = 0;
                    clearTimeout(this._timeoutHandle);
                    this._timeoutHandle = null;
                }
                catch (e) {
                    if (!ApplicationInsights.Util.getIEVersion() || ApplicationInsights.Util.getIEVersion() > 9) {
                        ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_TransmissionFailed, ""Telemetry transmission failed, some telemetry will be lost: "" + ApplicationInsights.Util.getExceptionName(e), { exception: ApplicationInsights.Util.dump(e) }));
                    }
                }
            };
            Sender.prototype._xhrSender = function (payload, isAsync, countOfItemsInPayload) {
                var xhr = new XMLHttpRequest();
                xhr[ApplicationInsights.AjaxMonitor.DisabledPropertyName] = true;
                xhr.open(""POST"", this._config.endpointUrl(), isAsync);
                xhr.setRequestHeader(""Content-type"", ""application/json"");
                xhr.onreadystatechange = function () { return Sender._xhrReadyStateChange(xhr, payload, countOfItemsInPayload); };
                xhr.onerror = function (event) { return Sender._onError(payload, xhr.responseText || xhr.response || """", event); };
                xhr.send(payload);
            };
            Sender.prototype._xdrSender = function (payload, isAsync) {
                var xdr = new XDomainRequest();
                xdr.onload = function () { return Sender._xdrOnLoad(xdr, payload); };
                xdr.onerror = function (event) { return Sender._onError(payload, xdr.responseText || """", event); };
                xdr.open('POST', this._config.endpointUrl());
                xdr.send(payload);
            };
            Sender._xhrReadyStateChange = function (xhr, payload, countOfItemsInPayload) {
                if (xhr.readyState === 4) {
                    if ((xhr.status < 200 || xhr.status >= 300) && xhr.status !== 0) {
                        Sender._onError(payload, xhr.responseText || xhr.response || """");
                    }
                    else {
                        Sender._onSuccess(payload, countOfItemsInPayload);
                    }
                }
            };
            Sender._xdrOnLoad = function (xdr, payload) {
                if (xdr && (xdr.responseText + """" === ""200"" || xdr.responseText === """")) {
                    Sender._onSuccess(payload, 0);
                }
                else {
                    Sender._onError(payload, xdr && xdr.responseText || """");
                }
            };
            Sender._onError = function (payload, message, event) {
                ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_OnError, ""Failed to send telemetry."", { message: message }));
            };
            Sender._onSuccess = function (payload, countOfItemsInPayload) {
                ApplicationInsights.DataLossAnalyzer.decrementItemsQueued(countOfItemsInPayload);
            };
            return Sender;
        })();
        ApplicationInsights.Sender = Sender;
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""./HashCodeScoreGenerator.ts"" />
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        ""use strict"";
        var SplitTest = (function () {
            function SplitTest() {
                this.hashCodeGeneragor = new ApplicationInsights.HashCodeScoreGenerator();
            }
            SplitTest.prototype.isEnabled = function (key, percentEnabled) {
                return this.hashCodeGeneragor.getHashCodeScore(key) < percentEnabled;
            };
            return SplitTest;
        })();
        ApplicationInsights.SplitTest = SplitTest;
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
var Microsoft;
(function (Microsoft) {
    var Telemetry;
    (function (Telemetry) {
        ""use strict"";
        var Domain = (function () {
            function Domain() {
            }
            return Domain;
        })();
        Telemetry.Domain = Domain;
    })(Telemetry = Microsoft.Telemetry || (Microsoft.Telemetry = {}));
})(Microsoft || (Microsoft = {}));
var AI;
(function (AI) {
    ""use strict"";
    (function (SeverityLevel) {
        SeverityLevel[SeverityLevel[""Verbose""] = 0] = ""Verbose"";
        SeverityLevel[SeverityLevel[""Information""] = 1] = ""Information"";
        SeverityLevel[SeverityLevel[""Warning""] = 2] = ""Warning"";
        SeverityLevel[SeverityLevel[""Error""] = 3] = ""Error"";
        SeverityLevel[SeverityLevel[""Critical""] = 4] = ""Critical"";
    })(AI.SeverityLevel || (AI.SeverityLevel = {}));
    var SeverityLevel = AI.SeverityLevel;
})(AI || (AI = {}));
/// <reference path=""Domain.ts"" />
/// <reference path=""SeverityLevel.ts"" />
var AI;
(function (AI) {
    ""use strict"";
    var MessageData = (function (_super) {
        __extends(MessageData, _super);
        function MessageData() {
            this.ver = 2;
            this.properties = {};
            _super.call(this);
        }
        return MessageData;
    })(Microsoft.Telemetry.Domain);
    AI.MessageData = MessageData;
})(AI || (AI = {}));
/// <reference path=""../../logging.ts"" />
/// <reference path=""../../Util.ts""/>
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Telemetry;
        (function (Telemetry) {
            var Common;
            (function (Common) {
                ""use strict"";
                var DataSanitizer = (function () {
                    function DataSanitizer() {
                    }
                    DataSanitizer.sanitizeKeyAndAddUniqueness = function (key, map) {
                        var origLength = key.length;
                        var field = DataSanitizer.sanitizeKey(key);
                        if (field.length !== origLength) {
                            var i = 0;
                            var uniqueField = field;
                            while (map[uniqueField] !== undefined) {
                                i++;
                                uniqueField = field.substring(0, DataSanitizer.MAX_NAME_LENGTH - 3) + DataSanitizer.padNumber(i);
                            }
                            field = uniqueField;
                        }
                        return field;
                    };
                    DataSanitizer.sanitizeKey = function (name) {
                        if (name) {
                            name = ApplicationInsights.Util.trim(name.toString());
                            if (name.search(/[^0-9a-zA-Z-._()\/ ]/g) >= 0) {
                                name = name.replace(/[^0-9a-zA-Z-._()\/ ]/g, ""_"");
                                ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_IllegalCharsInName, ""name contains illegal characters. Illegal characters have been replaced with '_'."", { newName: name }));
                            }
                            if (name.length > DataSanitizer.MAX_NAME_LENGTH) {
                                name = name.substring(0, DataSanitizer.MAX_NAME_LENGTH);
                                ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_NameTooLong, ""name is too long.  It has been truncated to "" + DataSanitizer.MAX_NAME_LENGTH + "" characters."", { name: name }));
                            }
                        }
                        return name;
                    };
                    DataSanitizer.sanitizeString = function (value) {
                        if (value) {
                            value = ApplicationInsights.Util.trim(value);
                            if (value.toString().length > DataSanitizer.MAX_STRING_LENGTH) {
                                value = value.toString().substring(0, DataSanitizer.MAX_STRING_LENGTH);
                                ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_StringValueTooLong, ""string value is too long. It has been truncated to "" + DataSanitizer.MAX_STRING_LENGTH + "" characters."", { value: value }));
                            }
                        }
                        return value;
                    };
                    DataSanitizer.sanitizeUrl = function (url) {
                        if (url) {
                            if (url.length > DataSanitizer.MAX_URL_LENGTH) {
                                url = url.substring(0, DataSanitizer.MAX_URL_LENGTH);
                                ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_UrlTooLong, ""url is too long, it has been trucated to "" + DataSanitizer.MAX_URL_LENGTH + "" characters."", { url: url }));
                            }
                        }
                        return url;
                    };
                    DataSanitizer.sanitizeMessage = function (message) {
                        if (message) {
                            if (message.length > DataSanitizer.MAX_MESSAGE_LENGTH) {
                                message = message.substring(0, DataSanitizer.MAX_MESSAGE_LENGTH);
                                ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_MessageTruncated, ""message is too long, it has been trucated to "" + DataSanitizer.MAX_MESSAGE_LENGTH + "" characters."", { message: message }));
                            }
                        }
                        return message;
                    };
                    DataSanitizer.sanitizeException = function (exception) {
                        if (exception) {
                            if (exception.length > DataSanitizer.MAX_EXCEPTION_LENGTH) {
                                exception = exception.substring(0, DataSanitizer.MAX_EXCEPTION_LENGTH);
                                ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_ExceptionTruncated, ""exception is too long, it has been trucated to "" + DataSanitizer.MAX_EXCEPTION_LENGTH + "" characters."", { exception: exception }));
                            }
                        }
                        return exception;
                    };
                    DataSanitizer.sanitizeProperties = function (properties) {
                        if (properties) {
                            var tempProps = {};
                            for (var prop in properties) {
                                var value = DataSanitizer.sanitizeString(properties[prop]);
                                prop = DataSanitizer.sanitizeKeyAndAddUniqueness(prop, tempProps);
                                tempProps[prop] = value;
                            }
                            properties = tempProps;
                        }
                        return properties;
                    };
                    DataSanitizer.sanitizeMeasurements = function (measurements) {
                        if (measurements) {
                            var tempMeasurements = {};
                            for (var measure in measurements) {
                                var value = measurements[measure];
                                measure = DataSanitizer.sanitizeKeyAndAddUniqueness(measure, tempMeasurements);
                                tempMeasurements[measure] = value;
                            }
                            measurements = tempMeasurements;
                        }
                        return measurements;
                    };
                    DataSanitizer.padNumber = function (num) {
                        var s = ""00"" + num;
                        return s.substr(s.length - 3);
                    };
                    DataSanitizer.MAX_NAME_LENGTH = 150;
                    DataSanitizer.MAX_STRING_LENGTH = 1024;
                    DataSanitizer.MAX_URL_LENGTH = 2048;
                    DataSanitizer.MAX_MESSAGE_LENGTH = 32768;
                    DataSanitizer.MAX_EXCEPTION_LENGTH = 32768;
                    return DataSanitizer;
                })();
                Common.DataSanitizer = DataSanitizer;
            })(Common = Telemetry.Common || (Telemetry.Common = {}));
        })(Telemetry = ApplicationInsights.Telemetry || (ApplicationInsights.Telemetry = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""../Contracts/Generated/MessageData.ts"" />
/// <reference path=""./Common/DataSanitizer.ts""/>
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Telemetry;
        (function (Telemetry) {
            ""use strict"";
            var Trace = (function (_super) {
                __extends(Trace, _super);
                function Trace(message, properties) {
                    _super.call(this);
                    this.aiDataContract = {
                        ver: ApplicationInsights.FieldType.Required,
                        message: ApplicationInsights.FieldType.Required,
                        severityLevel: ApplicationInsights.FieldType.Default,
                        measurements: ApplicationInsights.FieldType.Default,
                        properties: ApplicationInsights.FieldType.Default
                    };
                    message = message || ApplicationInsights.Util.NotSpecified;
                    this.message = Telemetry.Common.DataSanitizer.sanitizeMessage(message);
                    this.properties = Telemetry.Common.DataSanitizer.sanitizeProperties(properties);
                }
                Trace.envelopeType = ""Microsoft.ApplicationInsights.{0}.Message"";
                Trace.dataType = ""MessageData"";
                return Trace;
            })(AI.MessageData);
            Telemetry.Trace = Trace;
        })(Telemetry = ApplicationInsights.Telemetry || (ApplicationInsights.Telemetry = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""Domain.ts"" />
var AI;
(function (AI) {
    ""use strict"";
    var EventData = (function (_super) {
        __extends(EventData, _super);
        function EventData() {
            this.ver = 2;
            this.properties = {};
            this.measurements = {};
            _super.call(this);
        }
        return EventData;
    })(Microsoft.Telemetry.Domain);
    AI.EventData = EventData;
})(AI || (AI = {}));
/// <reference path=""../Contracts/Generated/EventData.ts"" />
/// <reference path=""./Common/DataSanitizer.ts""/>
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Telemetry;
        (function (Telemetry) {
            ""use strict"";
            var Event = (function (_super) {
                __extends(Event, _super);
                function Event(name, properties, measurements) {
                    _super.call(this);
                    this.aiDataContract = {
                        ver: ApplicationInsights.FieldType.Required,
                        name: ApplicationInsights.FieldType.Required,
                        properties: ApplicationInsights.FieldType.Default,
                        measurements: ApplicationInsights.FieldType.Default
                    };
                    this.name = ApplicationInsights.Telemetry.Common.DataSanitizer.sanitizeString(name);
                    this.properties = ApplicationInsights.Telemetry.Common.DataSanitizer.sanitizeProperties(properties);
                    this.measurements = ApplicationInsights.Telemetry.Common.DataSanitizer.sanitizeMeasurements(measurements);
                }
                Event.envelopeType = ""Microsoft.ApplicationInsights.{0}.Event"";
                Event.dataType = ""EventData"";
                return Event;
            })(AI.EventData);
            Telemetry.Event = Event;
        })(Telemetry = ApplicationInsights.Telemetry || (ApplicationInsights.Telemetry = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
var AI;
(function (AI) {
    ""use strict"";
    var ExceptionDetails = (function () {
        function ExceptionDetails() {
            this.hasFullStack = true;
            this.parsedStack = [];
        }
        return ExceptionDetails;
    })();
    AI.ExceptionDetails = ExceptionDetails;
})(AI || (AI = {}));
/// <reference path=""Domain.ts"" />
/// <reference path=""SeverityLevel.ts"" />
/// <reference path=""ExceptionDetails.ts""/>
var AI;
(function (AI) {
    ""use strict"";
    var ExceptionData = (function (_super) {
        __extends(ExceptionData, _super);
        function ExceptionData() {
            this.ver = 2;
            this.exceptions = [];
            this.properties = {};
            this.measurements = {};
            _super.call(this);
        }
        return ExceptionData;
    })(Microsoft.Telemetry.Domain);
    AI.ExceptionData = ExceptionData;
})(AI || (AI = {}));
var AI;
(function (AI) {
    ""use strict"";
    var StackFrame = (function () {
        function StackFrame() {
        }
        return StackFrame;
    })();
    AI.StackFrame = StackFrame;
})(AI || (AI = {}));
/// <reference path=""../Contracts/Generated/ExceptionData.ts"" />
/// <reference path=""../Contracts/Generated/StackFrame.ts"" />
/// <reference path=""./Common/DataSanitizer.ts""/>
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Telemetry;
        (function (Telemetry) {
            ""use strict"";
            var Exception = (function (_super) {
                __extends(Exception, _super);
                function Exception(exception, handledAt, properties, measurements) {
                    _super.call(this);
                    this.aiDataContract = {
                        ver: ApplicationInsights.FieldType.Required,
                        handledAt: ApplicationInsights.FieldType.Required,
                        exceptions: ApplicationInsights.FieldType.Required,
                        severityLevel: ApplicationInsights.FieldType.Default,
                        properties: ApplicationInsights.FieldType.Default,
                        measurements: ApplicationInsights.FieldType.Default
                    };
                    this.properties = ApplicationInsights.Telemetry.Common.DataSanitizer.sanitizeProperties(properties);
                    this.measurements = ApplicationInsights.Telemetry.Common.DataSanitizer.sanitizeMeasurements(measurements);
                    this.handledAt = handledAt || ""unhandled"";
                    this.exceptions = [new _ExceptionDetails(exception)];
                }
                Exception.CreateSimpleException = function (message, typeName, assembly, fileName, details, line, handledAt) {
                    return {
                        handledAt: handledAt || ""unhandled"",
                        exceptions: [
                            {
                                hasFullStack: true,
                                message: message,
                                stack: details,
                                typeName: typeName,
                                parsedStack: [
                                    {
                                        level: 0,
                                        assembly: assembly,
                                        fileName: fileName,
                                        line: line,
                                        method: ""unknown""
                                    }
                                ]
                            }
                        ]
                    };
                };
                Exception.envelopeType = ""Microsoft.ApplicationInsights.{0}.Exception"";
                Exception.dataType = ""ExceptionData"";
                return Exception;
            })(AI.ExceptionData);
            Telemetry.Exception = Exception;
            var _ExceptionDetails = (function (_super) {
                __extends(_ExceptionDetails, _super);
                function _ExceptionDetails(exception) {
                    _super.call(this);
                    this.aiDataContract = {
                        id: ApplicationInsights.FieldType.Default,
                        outerId: ApplicationInsights.FieldType.Default,
                        typeName: ApplicationInsights.FieldType.Required,
                        message: ApplicationInsights.FieldType.Required,
                        hasFullStack: ApplicationInsights.FieldType.Default,
                        stack: ApplicationInsights.FieldType.Default,
                        parsedStack: ApplicationInsights.FieldType.Array
                    };
                    this.typeName = Telemetry.Common.DataSanitizer.sanitizeString(exception.name || ApplicationInsights.Util.NotSpecified);
                    this.message = Telemetry.Common.DataSanitizer.sanitizeMessage(exception.message || ApplicationInsights.Util.NotSpecified);
                    var stack = exception[""stack""];
                    this.parsedStack = this.parseStack(stack);
                    this.stack = Telemetry.Common.DataSanitizer.sanitizeException(stack);
                    this.hasFullStack = ApplicationInsights.Util.isArray(this.parsedStack) && this.parsedStack.length > 0;
                }
                _ExceptionDetails.prototype.parseStack = function (stack) {
                    var parsedStack = undefined;
                    if (typeof stack === ""string"") {
                        var frames = stack.split('\n');
                        parsedStack = [];
                        var level = 0;
                        var totalSizeInBytes = 0;
                        for (var i = 0; i <= frames.length; i++) {
                            var frame = frames[i];
                            if (_StackFrame.regex.test(frame)) {
                                var parsedFrame = new _StackFrame(frames[i], level++);
                                totalSizeInBytes += parsedFrame.sizeInBytes;
                                parsedStack.push(parsedFrame);
                            }
                        }
                        var exceptionParsedStackThreshold = 32 * 1024;
                        if (totalSizeInBytes > exceptionParsedStackThreshold) {
                            var left = 0;
                            var right = parsedStack.length - 1;
                            var size = 0;
                            var acceptedLeft = left;
                            var acceptedRight = right;
                            while (left < right) {
                                var lSize = parsedStack[left].sizeInBytes;
                                var rSize = parsedStack[right].sizeInBytes;
                                size += lSize + rSize;
                                if (size > exceptionParsedStackThreshold) {
                                    var howMany = acceptedRight - acceptedLeft + 1;
                                    parsedStack.splice(acceptedLeft, howMany);
                                    break;
                                }
                                acceptedLeft = left;
                                acceptedRight = right;
                                left++;
                                right--;
                            }
                        }
                    }
                    return parsedStack;
                };
                return _ExceptionDetails;
            })(AI.ExceptionDetails);
            var _StackFrame = (function (_super) {
                __extends(_StackFrame, _super);
                function _StackFrame(frame, level) {
                    _super.call(this);
                    this.sizeInBytes = 0;
                    this.aiDataContract = {
                        level: ApplicationInsights.FieldType.Required,
                        method: ApplicationInsights.FieldType.Required,
                        assembly: ApplicationInsights.FieldType.Default,
                        fileName: ApplicationInsights.FieldType.Default,
                        line: ApplicationInsights.FieldType.Default
                    };
                    this.level = level;
                    this.method = ""<no_method>"";
                    this.assembly = ApplicationInsights.Util.trim(frame);
                    var matches = frame.match(_StackFrame.regex);
                    if (matches && matches.length >= 5) {
                        this.method = ApplicationInsights.Util.trim(matches[2]) || this.method;
                        this.fileName = ApplicationInsights.Util.trim(matches[4]);
                        this.line = parseInt(matches[5]) || 0;
                    }
                    this.sizeInBytes += this.method.length;
                    this.sizeInBytes += this.fileName.length;
                    this.sizeInBytes += this.assembly.length;
                    this.sizeInBytes += _StackFrame.baseSize;
                    this.sizeInBytes += this.level.toString().length;
                    this.sizeInBytes += this.line.toString().length;
                }
                _StackFrame.regex = /^([\s]+at)?(.*?)(\@|\s\(|\s)([^\(\@\n]+):([0-9]+):([0-9]+)(\)?)$/;
                _StackFrame.baseSize = 58;
                return _StackFrame;
            })(AI.StackFrame);
            Telemetry._StackFrame = _StackFrame;
        })(Telemetry = ApplicationInsights.Telemetry || (ApplicationInsights.Telemetry = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""Domain.ts"" />
var AI;
(function (AI) {
    ""use strict"";
    var MetricData = (function (_super) {
        __extends(MetricData, _super);
        function MetricData() {
            this.ver = 2;
            this.metrics = [];
            this.properties = {};
            _super.call(this);
        }
        return MetricData;
    })(Microsoft.Telemetry.Domain);
    AI.MetricData = MetricData;
})(AI || (AI = {}));
var AI;
(function (AI) {
    ""use strict"";
    (function (DataPointType) {
        DataPointType[DataPointType[""Measurement""] = 0] = ""Measurement"";
        DataPointType[DataPointType[""Aggregation""] = 1] = ""Aggregation"";
    })(AI.DataPointType || (AI.DataPointType = {}));
    var DataPointType = AI.DataPointType;
})(AI || (AI = {}));
/// <reference path=""DataPointType.ts"" />
var AI;
(function (AI) {
    ""use strict"";
    var DataPoint = (function () {
        function DataPoint() {
            this.kind = AI.DataPointType.Measurement;
        }
        return DataPoint;
    })();
    AI.DataPoint = DataPoint;
})(AI || (AI = {}));
/// <reference path=""../../Contracts/Generated/DataPoint.ts""/>
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Telemetry;
        (function (Telemetry) {
            var Common;
            (function (Common) {
                ""use strict"";
                var DataPoint = (function (_super) {
                    __extends(DataPoint, _super);
                    function DataPoint() {
                        _super.apply(this, arguments);
                        this.aiDataContract = {
                            name: ApplicationInsights.FieldType.Required,
                            kind: ApplicationInsights.FieldType.Default,
                            value: ApplicationInsights.FieldType.Required,
                            count: ApplicationInsights.FieldType.Default,
                            min: ApplicationInsights.FieldType.Default,
                            max: ApplicationInsights.FieldType.Default,
                            stdDev: ApplicationInsights.FieldType.Default
                        };
                    }
                    return DataPoint;
                })(AI.DataPoint);
                Common.DataPoint = DataPoint;
            })(Common = Telemetry.Common || (Telemetry.Common = {}));
        })(Telemetry = ApplicationInsights.Telemetry || (ApplicationInsights.Telemetry = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""../Contracts/Generated/MetricData.ts"" />
/// <reference path=""./Common/DataSanitizer.ts"" />
/// <reference path=""./Common/DataPoint.ts"" />
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Telemetry;
        (function (Telemetry) {
            ""use strict"";
            var Metric = (function (_super) {
                __extends(Metric, _super);
                function Metric(name, value, count, min, max, properties) {
                    _super.call(this);
                    this.aiDataContract = {
                        ver: ApplicationInsights.FieldType.Required,
                        metrics: ApplicationInsights.FieldType.Required,
                        properties: ApplicationInsights.FieldType.Default
                    };
                    var dataPoint = new Microsoft.ApplicationInsights.Telemetry.Common.DataPoint();
                    dataPoint.count = count > 0 ? count : undefined;
                    dataPoint.max = isNaN(max) || max === null ? undefined : max;
                    dataPoint.min = isNaN(min) || min === null ? undefined : min;
                    dataPoint.name = Telemetry.Common.DataSanitizer.sanitizeString(name);
                    dataPoint.value = value;
                    this.metrics = [dataPoint];
                    this.properties = ApplicationInsights.Telemetry.Common.DataSanitizer.sanitizeProperties(properties);
                }
                Metric.envelopeType = ""Microsoft.ApplicationInsights.{0}.Metric"";
                Metric.dataType = ""MetricData"";
                return Metric;
            })(AI.MetricData);
            Telemetry.Metric = Metric;
        })(Telemetry = ApplicationInsights.Telemetry || (ApplicationInsights.Telemetry = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""EventData.ts"" />
var AI;
(function (AI) {
    ""use strict"";
    var PageViewData = (function (_super) {
        __extends(PageViewData, _super);
        function PageViewData() {
            this.ver = 2;
            this.properties = {};
            this.measurements = {};
            _super.call(this);
        }
        return PageViewData;
    })(AI.EventData);
    AI.PageViewData = PageViewData;
})(AI || (AI = {}));
/// <reference path=""../Contracts/Generated/PageViewData.ts"" />
/// <reference path=""./Common/DataSanitizer.ts""/>
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Telemetry;
        (function (Telemetry) {
            ""use strict"";
            var PageView = (function (_super) {
                __extends(PageView, _super);
                function PageView(name, url, durationMs, properties, measurements) {
                    _super.call(this);
                    this.aiDataContract = {
                        ver: ApplicationInsights.FieldType.Required,
                        name: ApplicationInsights.FieldType.Default,
                        url: ApplicationInsights.FieldType.Default,
                        duration: ApplicationInsights.FieldType.Default,
                        properties: ApplicationInsights.FieldType.Default,
                        measurements: ApplicationInsights.FieldType.Default
                    };
                    this.url = Telemetry.Common.DataSanitizer.sanitizeUrl(url);
                    this.name = Telemetry.Common.DataSanitizer.sanitizeString(name || ApplicationInsights.Util.NotSpecified);
                    if (!isNaN(durationMs)) {
                        this.duration = ApplicationInsights.Util.msToTimeSpan(durationMs);
                    }
                    this.properties = ApplicationInsights.Telemetry.Common.DataSanitizer.sanitizeProperties(properties);
                    this.measurements = ApplicationInsights.Telemetry.Common.DataSanitizer.sanitizeMeasurements(measurements);
                }
                PageView.envelopeType = ""Microsoft.ApplicationInsights.{0}.Pageview"";
                PageView.dataType = ""PageviewData"";
                return PageView;
            })(AI.PageViewData);
            Telemetry.PageView = PageView;
        })(Telemetry = ApplicationInsights.Telemetry || (ApplicationInsights.Telemetry = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""PageViewData.ts"" />
var AI;
(function (AI) {
    ""use strict"";
    var PageViewPerfData = (function (_super) {
        __extends(PageViewPerfData, _super);
        function PageViewPerfData() {
            this.ver = 2;
            this.properties = {};
            this.measurements = {};
            _super.call(this);
        }
        return PageViewPerfData;
    })(AI.PageViewData);
    AI.PageViewPerfData = PageViewPerfData;
})(AI || (AI = {}));
/// <reference path=""../Contracts/Generated/PageViewPerfData.ts""/>
/// <reference path=""./Common/DataSanitizer.ts""/>
/// <reference path=""../Util.ts""/>
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Telemetry;
        (function (Telemetry) {
            ""use strict"";
            var PageViewPerformance = (function (_super) {
                __extends(PageViewPerformance, _super);
                function PageViewPerformance(name, url, unused, properties, measurements) {
                    _super.call(this);
                    this.aiDataContract = {
                        ver: ApplicationInsights.FieldType.Required,
                        name: ApplicationInsights.FieldType.Default,
                        url: ApplicationInsights.FieldType.Default,
                        duration: ApplicationInsights.FieldType.Default,
                        perfTotal: ApplicationInsights.FieldType.Default,
                        networkConnect: ApplicationInsights.FieldType.Default,
                        sentRequest: ApplicationInsights.FieldType.Default,
                        receivedResponse: ApplicationInsights.FieldType.Default,
                        domProcessing: ApplicationInsights.FieldType.Default,
                        properties: ApplicationInsights.FieldType.Default,
                        measurements: ApplicationInsights.FieldType.Default
                    };
                    this.isValid = false;
                    var timing = PageViewPerformance.getPerformanceTiming();
                    if (timing) {
                        var total = PageViewPerformance.getDuration(timing.navigationStart, timing.loadEventEnd);
                        var network = PageViewPerformance.getDuration(timing.navigationStart, timing.connectEnd);
                        var request = PageViewPerformance.getDuration(timing.requestStart, timing.responseStart);
                        var response = PageViewPerformance.getDuration(timing.responseStart, timing.responseEnd);
                        var dom = PageViewPerformance.getDuration(timing.responseEnd, timing.loadEventEnd);
                        if (total == 0) {
                            ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_ErrorPVCalc, ""error calculating page view performance."", { total: total, network: network, request: request, response: response, dom: dom }));
                        }
                        else if (total < Math.floor(network) + Math.floor(request) + Math.floor(response) + Math.floor(dom)) {
                            ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_ClientPerformanceMathError, ""client performance math error."", { total: total, network: network, request: request, response: response, dom: dom }));
                        }
                        else {
                            this.durationMs = total;
                            this.perfTotal = this.duration = ApplicationInsights.Util.msToTimeSpan(total);
                            this.networkConnect = ApplicationInsights.Util.msToTimeSpan(network);
                            this.sentRequest = ApplicationInsights.Util.msToTimeSpan(request);
                            this.receivedResponse = ApplicationInsights.Util.msToTimeSpan(response);
                            this.domProcessing = ApplicationInsights.Util.msToTimeSpan(dom);
                            this.isValid = true;
                        }
                    }
                    this.url = Telemetry.Common.DataSanitizer.sanitizeUrl(url);
                    this.name = Telemetry.Common.DataSanitizer.sanitizeString(name || ApplicationInsights.Util.NotSpecified);
                    this.properties = ApplicationInsights.Telemetry.Common.DataSanitizer.sanitizeProperties(properties);
                    this.measurements = ApplicationInsights.Telemetry.Common.DataSanitizer.sanitizeMeasurements(measurements);
                }
                PageViewPerformance.prototype.getIsValid = function () {
                    return this.isValid;
                };
                PageViewPerformance.prototype.getDurationMs = function () {
                    return this.durationMs;
                };
                PageViewPerformance.getPerformanceTiming = function () {
                    if (typeof window != ""undefined"" && window.performance && window.performance.timing) {
                        return window.performance.timing;
                    }
                    return null;
                };
                PageViewPerformance.isPerformanceTimingSupported = function () {
                    return typeof window != ""undefined"" && window.performance && window.performance.timing;
                };
                PageViewPerformance.isPerformanceTimingDataReady = function () {
                    var timing = window.performance.timing;
                    return timing.domainLookupStart > 0
                        && timing.navigationStart > 0
                        && timing.responseStart > 0
                        && timing.requestStart > 0
                        && timing.loadEventEnd > 0
                        && timing.responseEnd > 0
                        && timing.connectEnd > 0
                        && timing.domLoading > 0;
                };
                PageViewPerformance.getDuration = function (start, end) {
                    var duration = 0;
                    if (!(isNaN(start) || isNaN(end))) {
                        duration = Math.max(end - start, 0);
                    }
                    return duration;
                };
                PageViewPerformance.envelopeType = ""Microsoft.ApplicationInsights.{0}.PageviewPerformance"";
                PageViewPerformance.dataType = ""PageviewPerformanceData"";
                return PageViewPerformance;
            })(AI.PageViewPerfData);
            Telemetry.PageViewPerformance = PageViewPerformance;
        })(Telemetry = ApplicationInsights.Telemetry || (ApplicationInsights.Telemetry = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""sender.ts""/>
/// <reference path=""telemetry/trace.ts"" />
/// <reference path=""telemetry/event.ts"" />
/// <reference path=""telemetry/exception.ts"" />
/// <reference path=""telemetry/metric.ts"" />
/// <reference path=""telemetry/pageview.ts"" />
/// <reference path=""telemetry/pageviewperformance.ts"" />
/// <reference path=""./Util.ts""/>
/// <reference path=""./Contracts/Generated/SessionState.ts""/>
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        ""use strict"";
        var TelemetryContext = (function () {
            function TelemetryContext(config) {
                this._config = config;
                this._sender = new ApplicationInsights.Sender(config);
                if (typeof window !== 'undefined') {
                    this._sessionManager = new ApplicationInsights.Context._SessionManager(config);
                    this.application = new ApplicationInsights.Context.Application();
                    this.device = new ApplicationInsights.Context.Device();
                    this.internal = new ApplicationInsights.Context.Internal();
                    this.location = new ApplicationInsights.Context.Location();
                    this.user = new ApplicationInsights.Context.User(config);
                    this.operation = new ApplicationInsights.Context.Operation();
                    this.session = new ApplicationInsights.Context.Session();
                    this.sample = new ApplicationInsights.Context.Sample(config.sampleRate());
                }
            }
            TelemetryContext.prototype.addTelemetryInitializer = function (telemetryInitializer) {
                this.telemetryInitializers = this.telemetryInitializers || [];
                this.telemetryInitializers.push(telemetryInitializer);
            };
            TelemetryContext.prototype.track = function (envelope) {
                if (!envelope) {
                    ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_TrackArgumentsNotSpecified, ""cannot call .track() with a null or undefined argument""));
                }
                else {
                    if (envelope.name === ApplicationInsights.Telemetry.PageView.envelopeType) {
                        ApplicationInsights._InternalLogging.resetInternalMessageCount();
                    }
                    if (this.session) {
                        if (typeof this.session.id !== ""string"") {
                            this._sessionManager.update();
                        }
                    }
                    this._track(envelope);
                }
                return envelope;
            };
            TelemetryContext.prototype._track = function (envelope) {
                if (this.session) {
                    if (typeof this.session.id === ""string"") {
                        this._applySessionContext(envelope, this.session);
                    }
                    else {
                        this._applySessionContext(envelope, this._sessionManager.automaticSession);
                    }
                }
                this._applyApplicationContext(envelope, this.application);
                this._applyDeviceContext(envelope, this.device);
                this._applyInternalContext(envelope, this.internal);
                this._applyLocationContext(envelope, this.location);
                this._applySampleContext(envelope, this.sample);
                this._applyUserContext(envelope, this.user);
                this._applyOperationContext(envelope, this.operation);
                envelope.iKey = this._config.instrumentationKey();
                var doNotSendItem = false;
                try {
                    this.telemetryInitializers = this.telemetryInitializers || [];
                    var telemetryInitializersCount = this.telemetryInitializers.length;
                    for (var i = 0; i < telemetryInitializersCount; ++i) {
                        var telemetryInitializer = this.telemetryInitializers[i];
                        if (telemetryInitializer) {
                            if (telemetryInitializer.apply(null, [envelope]) === false) {
                                doNotSendItem = true;
                                break;
                            }
                        }
                    }
                }
                catch (e) {
                    doNotSendItem = true;
                    ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_TelemetryInitializerFailed, ""One of telemetry initializers failed, telemetry item will not be sent: "" + ApplicationInsights.Util.getExceptionName(e), { exception: ApplicationInsights.Util.dump(e) }));
                }
                if (!doNotSendItem) {
                    if (envelope.name === ApplicationInsights.Telemetry.Metric.envelopeType ||
                        this.sample.isSampledIn(envelope)) {
                        var iKeyNoDashes = this._config.instrumentationKey().replace(/-/g, """");
                        envelope.name = envelope.name.replace(""{0}"", iKeyNoDashes);
                        this._sender.send(envelope);
                    }
                    else {
                        ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_TelemetrySampledAndNotSent, ""Telemetry is sampled and not sent to the AI service."", { SampleRate: this.sample.sampleRate }));
                    }
                }
                return envelope;
            };
            TelemetryContext.prototype._applyApplicationContext = function (envelope, appContext) {
                if (appContext) {
                    var tagKeys = new AI.ContextTagKeys();
                    if (typeof appContext.ver === ""string"") {
                        envelope.tags[tagKeys.applicationVersion] = appContext.ver;
                    }
                    if (typeof appContext.build === ""string"") {
                        envelope.tags[tagKeys.applicationBuild] = appContext.build;
                    }
                }
            };
            TelemetryContext.prototype._applyDeviceContext = function (envelope, deviceContext) {
                var tagKeys = new AI.ContextTagKeys();
                if (deviceContext) {
                    if (typeof deviceContext.id === ""string"") {
                        envelope.tags[tagKeys.deviceId] = deviceContext.id;
                    }
                    if (typeof deviceContext.ip === ""string"") {
                        envelope.tags[tagKeys.deviceIp] = deviceContext.ip;
                    }
                    if (typeof deviceContext.language === ""string"") {
                        envelope.tags[tagKeys.deviceLanguage] = deviceContext.language;
                    }
                    if (typeof deviceContext.locale === ""string"") {
                        envelope.tags[tagKeys.deviceLocale] = deviceContext.locale;
                    }
                    if (typeof deviceContext.model === ""string"") {
                        envelope.tags[tagKeys.deviceModel] = deviceContext.model;
                    }
                    if (typeof deviceContext.network !== ""undefined"") {
                        envelope.tags[tagKeys.deviceNetwork] = deviceContext.network;
                    }
                    if (typeof deviceContext.oemName === ""string"") {
                        envelope.tags[tagKeys.deviceOEMName] = deviceContext.oemName;
                    }
                    if (typeof deviceContext.os === ""string"") {
                        envelope.tags[tagKeys.deviceOS] = deviceContext.os;
                    }
                    if (typeof deviceContext.osversion === ""string"") {
                        envelope.tags[tagKeys.deviceOSVersion] = deviceContext.osversion;
                    }
                    if (typeof deviceContext.resolution === ""string"") {
                        envelope.tags[tagKeys.deviceScreenResolution] = deviceContext.resolution;
                    }
                    if (typeof deviceContext.type === ""string"") {
                        envelope.tags[tagKeys.deviceType] = deviceContext.type;
                    }
                }
            };
            TelemetryContext.prototype._applyInternalContext = function (envelope, internalContext) {
                if (internalContext) {
                    var tagKeys = new AI.ContextTagKeys();
                    if (typeof internalContext.agentVersion === ""string"") {
                        envelope.tags[tagKeys.internalAgentVersion] = internalContext.agentVersion;
                    }
                    if (typeof internalContext.sdkVersion === ""string"") {
                        envelope.tags[tagKeys.internalSdkVersion] = internalContext.sdkVersion;
                    }
                }
            };
            TelemetryContext.prototype._applyLocationContext = function (envelope, locationContext) {
                if (locationContext) {
                    var tagKeys = new AI.ContextTagKeys();
                    if (typeof locationContext.ip === ""string"") {
                        envelope.tags[tagKeys.locationIp] = locationContext.ip;
                    }
                }
            };
            TelemetryContext.prototype._applyOperationContext = function (envelope, operationContext) {
                if (operationContext) {
                    var tagKeys = new AI.ContextTagKeys();
                    if (typeof operationContext.id === ""string"") {
                        envelope.tags[tagKeys.operationId] = operationContext.id;
                    }
                    if (typeof operationContext.name === ""string"") {
                        envelope.tags[tagKeys.operationName] = operationContext.name;
                    }
                    if (typeof operationContext.parentId === ""string"") {
                        envelope.tags[tagKeys.operationParentId] = operationContext.parentId;
                    }
                    if (typeof operationContext.rootId === ""string"") {
                        envelope.tags[tagKeys.operationRootId] = operationContext.rootId;
                    }
                    if (typeof operationContext.syntheticSource === ""string"") {
                        envelope.tags[tagKeys.operationSyntheticSource] = operationContext.syntheticSource;
                    }
                }
            };
            TelemetryContext.prototype._applySampleContext = function (envelope, sampleContext) {
                if (sampleContext) {
                    envelope.sampleRate = sampleContext.sampleRate;
                }
            };
            TelemetryContext.prototype._applySessionContext = function (envelope, sessionContext) {
                if (sessionContext) {
                    var tagKeys = new AI.ContextTagKeys();
                    if (typeof sessionContext.id === ""string"") {
                        envelope.tags[tagKeys.sessionId] = sessionContext.id;
                    }
                    if (typeof sessionContext.isFirst !== ""undefined"") {
                        envelope.tags[tagKeys.sessionIsFirst] = sessionContext.isFirst;
                    }
                }
            };
            TelemetryContext.prototype._applyUserContext = function (envelope, userContext) {
                if (userContext) {
                    var tagKeys = new AI.ContextTagKeys();
                    if (typeof userContext.accountId === ""string"") {
                        envelope.tags[tagKeys.userAccountId] = userContext.accountId;
                    }
                    if (typeof userContext.agent === ""string"") {
                        envelope.tags[tagKeys.userAgent] = userContext.agent;
                    }
                    if (typeof userContext.id === ""string"") {
                        envelope.tags[tagKeys.userId] = userContext.id;
                    }
                    if (typeof userContext.authenticatedId === ""string"") {
                        envelope.tags[tagKeys.userAuthUserId] = userContext.authenticatedId;
                    }
                    if (typeof userContext.storeRegion === ""string"") {
                        envelope.tags[tagKeys.userStoreRegion] = userContext.storeRegion;
                    }
                }
            };
            return TelemetryContext;
        })();
        ApplicationInsights.TelemetryContext = TelemetryContext;
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""Base.ts"" />
var Microsoft;
(function (Microsoft) {
    var Telemetry;
    (function (Telemetry) {
        ""use strict"";
        var Data = (function (_super) {
            __extends(Data, _super);
            function Data() {
                _super.call(this);
            }
            return Data;
        })(Microsoft.Telemetry.Base);
        Telemetry.Data = Data;
    })(Telemetry = Microsoft.Telemetry || (Microsoft.Telemetry = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""../../Contracts/Generated/Data.ts""/>
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Telemetry;
        (function (Telemetry) {
            var Common;
            (function (Common) {
                ""use strict"";
                var Data = (function (_super) {
                    __extends(Data, _super);
                    function Data(type, data) {
                        _super.call(this);
                        this.aiDataContract = {
                            baseType: ApplicationInsights.FieldType.Required,
                            baseData: ApplicationInsights.FieldType.Required
                        };
                        this.baseType = type;
                        this.baseData = data;
                    }
                    return Data;
                })(Microsoft.Telemetry.Data);
                Common.Data = Data;
            })(Common = Telemetry.Common || (Telemetry.Common = {}));
        })(Telemetry = ApplicationInsights.Telemetry || (ApplicationInsights.Telemetry = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""../Contracts/Generated/PageViewData.ts"" />
/// <reference path=""./Common/DataSanitizer.ts""/>
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Telemetry;
        (function (Telemetry) {
            ""use strict"";
            var PageViewManager = (function () {
                function PageViewManager(appInsights, overridePageViewDuration) {
                    this.pageViewPerformanceSent = false;
                    this.overridePageViewDuration = false;
                    this.overridePageViewDuration = overridePageViewDuration;
                    this.appInsights = appInsights;
                }
                PageViewManager.prototype.trackPageView = function (name, url, properties, measurements, duration) {
                    var _this = this;
                    if (typeof name !== ""string"") {
                        name = window.document && window.document.title || """";
                    }
                    if (typeof url !== ""string"") {
                        url = window.location && window.location.href || """";
                    }
                    var pageViewSent = false;
                    var customDuration = 0;
                    if (Telemetry.PageViewPerformance.isPerformanceTimingSupported()) {
                        var start = Telemetry.PageViewPerformance.getPerformanceTiming().navigationStart;
                        customDuration = Telemetry.PageViewPerformance.getDuration(start, +new Date);
                    }
                    else {
                        this.appInsights.sendPageViewInternal(name, url, !isNaN(duration) ? duration : 0, properties, measurements);
                        this.appInsights.flush();
                        pageViewSent = true;
                    }
                    if (this.overridePageViewDuration || !isNaN(duration)) {
                        this.appInsights.sendPageViewInternal(name, url, !isNaN(duration) ? duration : customDuration, properties, measurements);
                        this.appInsights.flush();
                        pageViewSent = true;
                    }
                    var maxDurationLimit = 60000;
                    if (!Telemetry.PageViewPerformance.isPerformanceTimingSupported()) {
                        ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_NavigationTimingNotSupported, ""trackPageView: navigation timing API used for calculation of page duration is not supported in this browser. This page view will be collected without duration and timing info.""));
                        return;
                    }
                    var handle = setInterval(function () {
                        try {
                            if (Telemetry.PageViewPerformance.isPerformanceTimingDataReady()) {
                                clearInterval(handle);
                                var pageViewPerformance = new Telemetry.PageViewPerformance(name, url, null, properties, measurements);
                                if (!pageViewPerformance.getIsValid() && !pageViewSent) {
                                    _this.appInsights.sendPageViewInternal(name, url, customDuration, properties, measurements);
                                    _this.appInsights.flush();
                                }
                                else {
                                    if (!pageViewSent) {
                                        _this.appInsights.sendPageViewInternal(name, url, pageViewPerformance.getDurationMs(), properties, measurements);
                                    }
                                    if (!_this.pageViewPerformanceSent) {
                                        _this.appInsights.sendPageViewPerformanceInternal(pageViewPerformance);
                                        _this.pageViewPerformanceSent = true;
                                    }
                                    _this.appInsights.flush();
                                }
                            }
                            else if (Telemetry.PageViewPerformance.getDuration(start, +new Date) > maxDurationLimit) {
                                clearInterval(handle);
                                if (!pageViewSent) {
                                    _this.appInsights.sendPageViewInternal(name, url, maxDurationLimit, properties, measurements);
                                    _this.appInsights.flush();
                                }
                            }
                        }
                        catch (e) {
                            ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_TrackPVFailedCalc, ""trackPageView failed on page load calculation: "" + ApplicationInsights.Util.getExceptionName(e), { exception: ApplicationInsights.Util.dump(e) }));
                        }
                    }, 100);
                };
                return PageViewManager;
            })();
            Telemetry.PageViewManager = PageViewManager;
        })(Telemetry = ApplicationInsights.Telemetry || (ApplicationInsights.Telemetry = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""../AppInsights.ts"" />
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Telemetry;
        (function (Telemetry) {
            ""use strict"";
            var PageVisitTimeManager = (function () {
                function PageVisitTimeManager(pageVisitTimeTrackingHandler) {
                    this.prevPageVisitDataKeyName = ""prevPageVisitData"";
                    this.pageVisitTimeTrackingHandler = pageVisitTimeTrackingHandler;
                }
                PageVisitTimeManager.prototype.trackPreviousPageVisit = function (currentPageName, currentPageUrl) {
                    try {
                        var prevPageVisitTimeData = this.restartPageVisitTimer(currentPageName, currentPageUrl);
                        if (prevPageVisitTimeData) {
                            this.pageVisitTimeTrackingHandler(prevPageVisitTimeData.pageName, prevPageVisitTimeData.pageUrl, prevPageVisitTimeData.pageVisitTime);
                        }
                    }
                    catch (e) {
                        ApplicationInsights._InternalLogging.warnToConsole(""Auto track page visit time failed, metric will not be collected: "" + ApplicationInsights.Util.dump(e));
                    }
                };
                PageVisitTimeManager.prototype.restartPageVisitTimer = function (pageName, pageUrl) {
                    try {
                        var prevPageVisitData = this.stopPageVisitTimer();
                        this.startPageVisitTimer(pageName, pageUrl);
                        return prevPageVisitData;
                    }
                    catch (e) {
                        ApplicationInsights._InternalLogging.warnToConsole(""Call to restart failed: "" + ApplicationInsights.Util.dump(e));
                        return null;
                    }
                };
                PageVisitTimeManager.prototype.startPageVisitTimer = function (pageName, pageUrl) {
                    try {
                        if (ApplicationInsights.Util.canUseSessionStorage()) {
                            if (ApplicationInsights.Util.getSessionStorage(this.prevPageVisitDataKeyName) != null) {
                                throw new Error(""Cannot call startPageVisit consecutively without first calling stopPageVisit"");
                            }
                            var currPageVisitData = new PageVisitData(pageName, pageUrl);
                            var currPageVisitDataStr = JSON.stringify(currPageVisitData);
                            ApplicationInsights.Util.setSessionStorage(this.prevPageVisitDataKeyName, currPageVisitDataStr);
                        }
                    }
                    catch (e) {
                        ApplicationInsights._InternalLogging.warnToConsole(""Call to start failed: "" + ApplicationInsights.Util.dump(e));
                    }
                };
                PageVisitTimeManager.prototype.stopPageVisitTimer = function () {
                    try {
                        if (ApplicationInsights.Util.canUseSessionStorage()) {
                            var pageVisitEndTime = Date.now();
                            var pageVisitDataJsonStr = ApplicationInsights.Util.getSessionStorage(this.prevPageVisitDataKeyName);
                            if (pageVisitDataJsonStr) {
                                var prevPageVisitData = JSON.parse(pageVisitDataJsonStr);
                                prevPageVisitData.pageVisitTime = pageVisitEndTime - prevPageVisitData.pageVisitStartTime;
                                ApplicationInsights.Util.removeSessionStorage(this.prevPageVisitDataKeyName);
                                return prevPageVisitData;
                            }
                            else {
                                return null;
                            }
                        }
                        return null;
                    }
                    catch (e) {
                        ApplicationInsights._InternalLogging.warnToConsole(""Stop page visit timer failed: "" + ApplicationInsights.Util.dump(e));
                        return null;
                    }
                };
                return PageVisitTimeManager;
            })();
            Telemetry.PageVisitTimeManager = PageVisitTimeManager;
            var PageVisitData = (function () {
                function PageVisitData(pageName, pageUrl) {
                    this.pageVisitStartTime = Date.now();
                    this.pageName = pageName;
                    this.pageUrl = pageUrl;
                }
                return PageVisitData;
            })();
            Telemetry.PageVisitData = PageVisitData;
        })(Telemetry = ApplicationInsights.Telemetry || (ApplicationInsights.Telemetry = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
var AI;
(function (AI) {
    ""use strict"";
    (function (DependencyKind) {
        DependencyKind[DependencyKind[""SQL""] = 0] = ""SQL"";
        DependencyKind[DependencyKind[""Http""] = 1] = ""Http"";
        DependencyKind[DependencyKind[""Other""] = 2] = ""Other"";
    })(AI.DependencyKind || (AI.DependencyKind = {}));
    var DependencyKind = AI.DependencyKind;
})(AI || (AI = {}));
var AI;
(function (AI) {
    ""use strict"";
    (function (DependencySourceType) {
        DependencySourceType[DependencySourceType[""Undefined""] = 0] = ""Undefined"";
        DependencySourceType[DependencySourceType[""Aic""] = 1] = ""Aic"";
        DependencySourceType[DependencySourceType[""Apmc""] = 2] = ""Apmc"";
    })(AI.DependencySourceType || (AI.DependencySourceType = {}));
    var DependencySourceType = AI.DependencySourceType;
})(AI || (AI = {}));
/// <reference path=""Domain.ts"" />
/// <reference path=""DataPointType.ts"" />
/// <reference path=""DependencyKind.ts"" />
/// <reference path=""DependencySourceType.ts"" />
var AI;
(function (AI) {
    ""use strict"";
    var RemoteDependencyData = (function (_super) {
        __extends(RemoteDependencyData, _super);
        function RemoteDependencyData() {
            this.ver = 2;
            this.kind = AI.DataPointType.Aggregation;
            this.dependencyKind = AI.DependencyKind.Other;
            this.success = true;
            this.dependencySource = AI.DependencySourceType.Apmc;
            this.properties = {};
            _super.call(this);
        }
        return RemoteDependencyData;
    })(Microsoft.Telemetry.Domain);
    AI.RemoteDependencyData = RemoteDependencyData;
})(AI || (AI = {}));
/// <reference path=""../Contracts/Generated/PageViewData.ts"" />
/// <reference path=""./Common/DataSanitizer.ts""/>
/// <reference path=""../Contracts/Generated/RemoteDependencyData.ts""/>
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        var Telemetry;
        (function (Telemetry) {
            ""use strict"";
            var RemoteDependencyData = (function (_super) {
                __extends(RemoteDependencyData, _super);
                function RemoteDependencyData(id, name, commandName, value, success, resultCode) {
                    _super.call(this);
                    this.aiDataContract = {
                        id: ApplicationInsights.FieldType.Required,
                        ver: ApplicationInsights.FieldType.Required,
                        name: ApplicationInsights.FieldType.Default,
                        kind: ApplicationInsights.FieldType.Required,
                        value: ApplicationInsights.FieldType.Default,
                        count: ApplicationInsights.FieldType.Default,
                        min: ApplicationInsights.FieldType.Default,
                        max: ApplicationInsights.FieldType.Default,
                        stdDev: ApplicationInsights.FieldType.Default,
                        dependencyKind: ApplicationInsights.FieldType.Default,
                        success: ApplicationInsights.FieldType.Default,
                        async: ApplicationInsights.FieldType.Default,
                        dependencySource: ApplicationInsights.FieldType.Default,
                        commandName: ApplicationInsights.FieldType.Default,
                        dependencyTypeName: ApplicationInsights.FieldType.Default,
                        properties: ApplicationInsights.FieldType.Default,
                        resultCode: ApplicationInsights.FieldType.Default
                    };
                    this.id = id;
                    this.name = name;
                    this.commandName = commandName;
                    this.value = value;
                    this.success = success;
                    this.resultCode = resultCode + """";
                    this.dependencyKind = AI.DependencyKind.Http;
                    this.dependencyTypeName = ""Ajax"";
                }
                RemoteDependencyData.envelopeType = ""Microsoft.ApplicationInsights.{0}.RemoteDependency"";
                RemoteDependencyData.dataType = ""RemoteDependencyData"";
                return RemoteDependencyData;
            })(AI.RemoteDependencyData);
            Telemetry.RemoteDependencyData = RemoteDependencyData;
        })(Telemetry = ApplicationInsights.Telemetry || (ApplicationInsights.Telemetry = {}));
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""telemetrycontext.ts"" />
/// <reference path=""./Telemetry/Common/Data.ts""/>
/// <reference path=""./Util.ts""/>
/// <reference path=""./Contracts/Generated/SessionState.ts""/>
/// <reference path=""./Telemetry/PageViewManager.ts""/>
/// <reference path=""./Telemetry/PageVisitTimeManager.ts""/>
/// <reference path=""./Telemetry/RemoteDependencyData.ts""/>
/// <reference path=""./ajax/ajax.ts""/>
/// <reference path=""./DataLossAnalyzer.ts""/>
/// <reference path=""./SplitTest.ts""/>
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        ""use strict"";
        ApplicationInsights.Version = ""0.22.9"";
        var AppInsights = (function () {
            function AppInsights(config) {
                var _this = this;
                this._trackAjaxAttempts = 0;
                this.config = config || {};
                var defaults = AppInsights.defaultConfig;
                if (defaults !== undefined) {
                    for (var field in defaults) {
                        if (this.config[field] === undefined) {
                            this.config[field] = defaults[field];
                        }
                    }
                }
                ApplicationInsights._InternalLogging.verboseLogging = function () { return _this.config.verboseLogging; };
                ApplicationInsights._InternalLogging.enableDebugExceptions = function () { return _this.config.enableDebug; };
                var configGetters = {
                    instrumentationKey: function () { return _this.config.instrumentationKey; },
                    accountId: function () { return _this.config.accountId; },
                    sessionRenewalMs: function () { return _this.config.sessionRenewalMs; },
                    sessionExpirationMs: function () { return _this.config.sessionExpirationMs; },
                    endpointUrl: function () { return _this.config.endpointUrl; },
                    emitLineDelimitedJson: function () { return _this.config.emitLineDelimitedJson; },
                    maxBatchSizeInBytes: function () { return _this.config.maxBatchSizeInBytes; },
                    maxBatchInterval: function () { return _this.config.maxBatchInterval; },
                    disableTelemetry: function () { return _this.config.disableTelemetry; },
                    sampleRate: function () { return _this.config.samplingPercentage; },
                    cookieDomain: function () { return _this.config.cookieDomain; }
                };
                this.context = new ApplicationInsights.TelemetryContext(configGetters);
                this._pageViewManager = new Microsoft.ApplicationInsights.Telemetry.PageViewManager(this, this.config.overridePageViewDuration);
                this._eventTracking = new Timing(""trackEvent"");
                this._eventTracking.action = function (name, url, duration, properties, measurements) {
                    if (!measurements) {
                        measurements = { duration: duration };
                    }
                    else {
                        if (isNaN(measurements[""duration""])) {
                            measurements[""duration""] = duration;
                        }
                    }
                    var event = new ApplicationInsights.Telemetry.Event(name, properties, measurements);
                    var data = new ApplicationInsights.Telemetry.Common.Data(ApplicationInsights.Telemetry.Event.dataType, event);
                    var envelope = new ApplicationInsights.Telemetry.Common.Envelope(data, ApplicationInsights.Telemetry.Event.envelopeType);
                    _this.context.track(envelope);
                };
                this._pageTracking = new Timing(""trackPageView"");
                this._pageTracking.action = function (name, url, duration, properties, measurements) {
                    _this.sendPageViewInternal(name, url, duration, properties, measurements);
                };
                this._pageVisitTimeManager = new ApplicationInsights.Telemetry.PageVisitTimeManager(function (pageName, pageUrl, pageVisitTime) { return _this.trackPageVisitTime(pageName, pageUrl, pageVisitTime); });
                if (!this.config.disableAjaxTracking) {
                    new Microsoft.ApplicationInsights.AjaxMonitor(this);
                }
            }
            AppInsights.prototype.sendPageViewInternal = function (name, url, duration, properties, measurements) {
                var pageView = new ApplicationInsights.Telemetry.PageView(name, url, duration, properties, measurements);
                var data = new ApplicationInsights.Telemetry.Common.Data(ApplicationInsights.Telemetry.PageView.dataType, pageView);
                var envelope = new ApplicationInsights.Telemetry.Common.Envelope(data, ApplicationInsights.Telemetry.PageView.envelopeType);
                this.context.track(envelope);
                this._trackAjaxAttempts = 0;
            };
            AppInsights.prototype.sendPageViewPerformanceInternal = function (pageViewPerformance) {
                var pageViewPerformanceData = new ApplicationInsights.Telemetry.Common.Data(ApplicationInsights.Telemetry.PageViewPerformance.dataType, pageViewPerformance);
                var pageViewPerformanceEnvelope = new ApplicationInsights.Telemetry.Common.Envelope(pageViewPerformanceData, ApplicationInsights.Telemetry.PageViewPerformance.envelopeType);
                this.context.track(pageViewPerformanceEnvelope);
            };
            AppInsights.prototype.startTrackPage = function (name) {
                try {
                    if (typeof name !== ""string"") {
                        name = window.document && window.document.title || """";
                    }
                    this._pageTracking.start(name);
                }
                catch (e) {
                    ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_StartTrackFailed, ""startTrackPage failed, page view may not be collected: "" + ApplicationInsights.Util.getExceptionName(e), { exception: ApplicationInsights.Util.dump(e) }));
                }
            };
            AppInsights.prototype.stopTrackPage = function (name, url, properties, measurements) {
                try {
                    if (typeof name !== ""string"") {
                        name = window.document && window.document.title || """";
                    }
                    if (typeof url !== ""string"") {
                        url = window.location && window.location.href || """";
                    }
                    this._pageTracking.stop(name, url, properties, measurements);
                    if (this.config.autoTrackPageVisitTime) {
                        this._pageVisitTimeManager.trackPreviousPageVisit(name, url);
                    }
                }
                catch (e) {
                    ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_StopTrackFailed, ""stopTrackPage failed, page view will not be collected: "" + ApplicationInsights.Util.getExceptionName(e), { exception: ApplicationInsights.Util.dump(e) }));
                }
            };
            AppInsights.prototype.trackPageView = function (name, url, properties, measurements, duration) {
                try {
                    this._pageViewManager.trackPageView(name, url, properties, measurements, duration);
                    if (this.config.autoTrackPageVisitTime) {
                        this._pageVisitTimeManager.trackPreviousPageVisit(name, url);
                    }
                }
                catch (e) {
                    ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_TrackPVFailed, ""trackPageView failed, page view will not be collected: "" + ApplicationInsights.Util.getExceptionName(e), { exception: ApplicationInsights.Util.dump(e) }));
                }
            };
            AppInsights.prototype.startTrackEvent = function (name) {
                try {
                    this._eventTracking.start(name);
                }
                catch (e) {
                    ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_StartTrackEventFailed, ""startTrackEvent failed, event will not be collected: "" + ApplicationInsights.Util.getExceptionName(e), { exception: ApplicationInsights.Util.dump(e) }));
                }
            };
            AppInsights.prototype.stopTrackEvent = function (name, properties, measurements) {
                try {
                    this._eventTracking.stop(name, undefined, properties, measurements);
                }
                catch (e) {
                    ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_StopTrackEventFailed, ""stopTrackEvent failed, event will not be collected: "" + ApplicationInsights.Util.getExceptionName(e), { exception: ApplicationInsights.Util.dump(e) }));
                }
            };
            AppInsights.prototype.trackEvent = function (name, properties, measurements) {
                try {
                    var eventTelemetry = new ApplicationInsights.Telemetry.Event(name, properties, measurements);
                    var data = new ApplicationInsights.Telemetry.Common.Data(ApplicationInsights.Telemetry.Event.dataType, eventTelemetry);
                    var envelope = new ApplicationInsights.Telemetry.Common.Envelope(data, ApplicationInsights.Telemetry.Event.envelopeType);
                    this.context.track(envelope);
                }
                catch (e) {
                    ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_TrackEventFailed, ""trackEvent failed, event will not be collected: "" + ApplicationInsights.Util.getExceptionName(e), { exception: ApplicationInsights.Util.dump(e) }));
                }
            };
            AppInsights.prototype.trackAjax = function (id, absoluteUrl, pathName, totalTime, success, resultCode) {
                if (this.config.maxAjaxCallsPerView === -1 ||
                    this._trackAjaxAttempts < this.config.maxAjaxCallsPerView) {
                    var dependency = new ApplicationInsights.Telemetry.RemoteDependencyData(id, absoluteUrl, pathName, totalTime, success, resultCode);
                    var dependencyData = new ApplicationInsights.Telemetry.Common.Data(ApplicationInsights.Telemetry.RemoteDependencyData.dataType, dependency);
                    var envelope = new ApplicationInsights.Telemetry.Common.Envelope(dependencyData, ApplicationInsights.Telemetry.RemoteDependencyData.envelopeType);
                    this.context.track(envelope);
                }
                else if (this._trackAjaxAttempts === this.config.maxAjaxCallsPerView) {
                    ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_MaxAjaxPerPVExceeded, ""Maximum ajax per page view limit reached, ajax monitoring is paused until the next trackPageView(). In order to increase the limit set the maxAjaxCallsPerView configuration parameter.""));
                }
                ++this._trackAjaxAttempts;
            };
            AppInsights.prototype.trackException = function (exception, handledAt, properties, measurements) {
                try {
                    if (!ApplicationInsights.Util.isError(exception)) {
                        try {
                            throw new Error(exception);
                        }
                        catch (error) {
                            exception = error;
                        }
                    }
                    var exceptionTelemetry = new ApplicationInsights.Telemetry.Exception(exception, handledAt, properties, measurements);
                    var data = new ApplicationInsights.Telemetry.Common.Data(ApplicationInsights.Telemetry.Exception.dataType, exceptionTelemetry);
                    var envelope = new ApplicationInsights.Telemetry.Common.Envelope(data, ApplicationInsights.Telemetry.Exception.envelopeType);
                    this.context.track(envelope);
                }
                catch (e) {
                    ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_TrackExceptionFailed, ""trackException failed, exception will not be collected: "" + ApplicationInsights.Util.getExceptionName(e), { exception: ApplicationInsights.Util.dump(e) }));
                }
            };
            AppInsights.prototype.trackMetric = function (name, average, sampleCount, min, max, properties) {
                try {
                    var telemetry = new ApplicationInsights.Telemetry.Metric(name, average, sampleCount, min, max, properties);
                    var data = new ApplicationInsights.Telemetry.Common.Data(ApplicationInsights.Telemetry.Metric.dataType, telemetry);
                    var envelope = new ApplicationInsights.Telemetry.Common.Envelope(data, ApplicationInsights.Telemetry.Metric.envelopeType);
                    this.context.track(envelope);
                }
                catch (e) {
                    ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_TrackMetricFailed, ""trackMetric failed, metric will not be collected: "" + ApplicationInsights.Util.getExceptionName(e), { exception: ApplicationInsights.Util.dump(e) }));
                }
            };
            AppInsights.prototype.trackTrace = function (message, properties) {
                try {
                    var telemetry = new ApplicationInsights.Telemetry.Trace(message, properties);
                    var data = new ApplicationInsights.Telemetry.Common.Data(ApplicationInsights.Telemetry.Trace.dataType, telemetry);
                    var envelope = new ApplicationInsights.Telemetry.Common.Envelope(data, ApplicationInsights.Telemetry.Trace.envelopeType);
                    this.context.track(envelope);
                }
                catch (e) {
                    ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_TrackTraceFailed, ""trackTrace failed, trace will not be collected: "" + ApplicationInsights.Util.getExceptionName(e), { exception: ApplicationInsights.Util.dump(e) }));
                }
            };
            AppInsights.prototype.trackPageVisitTime = function (pageName, pageUrl, pageVisitTime) {
                var properties = { PageName: pageName, PageUrl: pageUrl };
                this.trackMetric(""PageVisitTime"", pageVisitTime, 1, pageVisitTime, pageVisitTime, properties);
            };
            AppInsights.prototype.flush = function () {
                try {
                    this.context._sender.triggerSend();
                }
                catch (e) {
                    ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_FlushFailed, ""flush failed, telemetry will not be collected: "" + ApplicationInsights.Util.getExceptionName(e), { exception: ApplicationInsights.Util.dump(e) }));
                }
            };
            AppInsights.prototype.setAuthenticatedUserContext = function (authenticatedUserId, accountId) {
                try {
                    this.context.user.setAuthenticatedUserContext(authenticatedUserId, accountId);
                }
                catch (e) {
                    ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_SetAuthContextFailed, ""Setting auth user context failed. "" + ApplicationInsights.Util.getExceptionName(e), { exception: ApplicationInsights.Util.dump(e) }));
                }
            };
            AppInsights.prototype.clearAuthenticatedUserContext = function () {
                try {
                    this.context.user.clearAuthenticatedUserContext();
                }
                catch (e) {
                    ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_SetAuthContextFailed, ""Clearing auth user context failed. "" + ApplicationInsights.Util.getExceptionName(e), { exception: ApplicationInsights.Util.dump(e) }));
                }
            };
            AppInsights.prototype.SendCORSException = function (properties) {
                var exceptionData = Microsoft.ApplicationInsights.Telemetry.Exception.CreateSimpleException(""Script error."", ""Error"", ""unknown"", ""unknown"", ""The browser’s same-origin policy prevents us from getting the details of this exception.The exception occurred in a script loaded from an origin different than the web page.For cross- domain error reporting you can use crossorigin attribute together with appropriate CORS HTTP headers.For more information please see http://www.w3.org/TR/cors/."", 0, null);
                exceptionData.properties = properties;
                var data = new ApplicationInsights.Telemetry.Common.Data(ApplicationInsights.Telemetry.Exception.dataType, exceptionData);
                var envelope = new ApplicationInsights.Telemetry.Common.Envelope(data, ApplicationInsights.Telemetry.Exception.envelopeType);
                this.context.track(envelope);
            };
            AppInsights.prototype._onerror = function (message, url, lineNumber, columnNumber, error) {
                try {
                    var properties = { url: url ? url : document.URL };
                    if (ApplicationInsights.Util.isCrossOriginError(message, url, lineNumber, columnNumber, error)) {
                        this.SendCORSException(properties);
                    }
                    else {
                        if (!ApplicationInsights.Util.isError(error)) {
                            var stack = ""window.onerror@"" + properties.url + "":"" + lineNumber + "":"" + (columnNumber || 0);
                            error = new Error(message);
                            error[""stack""] = stack;
                        }
                        this.trackException(error, null, properties);
                    }
                }
                catch (exception) {
                    var errorString = error ? (error.name + "", "" + error.message) : ""null"";
                    var exceptionDump = ApplicationInsights.Util.dump(exception);
                    ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_ExceptionWhileLoggingError, ""_onerror threw exception while logging error, error will not be collected: "" + ApplicationInsights.Util.getExceptionName(exception), { exception: exceptionDump, errorString: errorString }));
                }
            };
            return AppInsights;
        })();
        ApplicationInsights.AppInsights = AppInsights;
        var Timing = (function () {
            function Timing(name) {
                this._name = name;
                this._events = {};
            }
            Timing.prototype.start = function (name) {
                if (typeof this._events[name] !== ""undefined"") {
                    ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_StartCalledMoreThanOnce, ""start was called more than once for this event without calling stop."", { name: this._name, key: name }));
                }
                this._events[name] = +new Date;
            };
            Timing.prototype.stop = function (name, url, properties, measurements) {
                var start = this._events[name];
                if (isNaN(start)) {
                    ApplicationInsights._InternalLogging.throwInternalUserActionable(ApplicationInsights.LoggingSeverity.WARNING, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.USRACT_StopCalledWithoutStart, ""stop was called without a corresponding start."", { name: this._name, key: name }));
                }
                else {
                    var end = +new Date;
                    var duration = ApplicationInsights.Telemetry.PageViewPerformance.getDuration(start, end);
                    this.action(name, url, duration, properties, measurements);
                }
                delete this._events[name];
                this._events[name] = undefined;
            };
            return Timing;
        })();
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""PageViewData.ts"" />
var AI;
(function (AI) {
    ""use strict"";
    var AjaxCallData = (function (_super) {
        __extends(AjaxCallData, _super);
        function AjaxCallData() {
            this.ver = 2;
            this.properties = {};
            this.measurements = {};
            _super.call(this);
        }
        return AjaxCallData;
    })(AI.PageViewData);
    AI.AjaxCallData = AjaxCallData;
})(AI || (AI = {}));
/// <reference path=""Domain.ts"" />
var AI;
(function (AI) {
    ""use strict"";
    var RequestData = (function (_super) {
        __extends(RequestData, _super);
        function RequestData() {
            this.ver = 2;
            this.properties = {};
            this.measurements = {};
            _super.call(this);
        }
        return RequestData;
    })(Microsoft.Telemetry.Domain);
    AI.RequestData = RequestData;
})(AI || (AI = {}));
/// <reference path=""Domain.ts"" />
/// <reference path=""SessionState.ts"" />
var AI;
(function (AI) {
    ""use strict"";
    var SessionStateData = (function (_super) {
        __extends(SessionStateData, _super);
        function SessionStateData() {
            this.ver = 2;
            this.state = AI.SessionState.Start;
            _super.call(this);
        }
        return SessionStateData;
    })(Microsoft.Telemetry.Domain);
    AI.SessionStateData = SessionStateData;
})(AI || (AI = {}));
/// <reference path=""appinsights.ts"" />
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        ""use strict"";
        var Initialization = (function () {
            function Initialization(snippet) {
                snippet.queue = snippet.queue || [];
                var config = snippet.config || {};
                if (config && !config.instrumentationKey) {
                    config = snippet;
                    if (config[""iKey""]) {
                        Microsoft.ApplicationInsights.Version = ""0.10.0.0"";
                        config.instrumentationKey = config[""iKey""];
                    }
                    else if (config[""applicationInsightsId""]) {
                        Microsoft.ApplicationInsights.Version = ""0.7.2.0"";
                        config.instrumentationKey = config[""applicationInsightsId""];
                    }
                    else {
                        throw new Error(""Cannot load Application Insights SDK, no instrumentationKey was provided."");
                    }
                }
                config = Initialization.getDefaultConfig(config);
                this.snippet = snippet;
                this.config = config;
            }
            Initialization.prototype.loadAppInsights = function () {
                var appInsights = new Microsoft.ApplicationInsights.AppInsights(this.config);
                if (this.config[""iKey""]) {
                    var originalTrackPageView = appInsights.trackPageView;
                    appInsights.trackPageView = function (pagePath, properties, measurements) {
                        originalTrackPageView.apply(appInsights, [null, pagePath, properties, measurements]);
                    };
                }
                var legacyPageView = ""logPageView"";
                if (typeof this.snippet[legacyPageView] === ""function"") {
                    appInsights[legacyPageView] = function (pagePath, properties, measurements) {
                        appInsights.trackPageView(null, pagePath, properties, measurements);
                    };
                }
                var legacyEvent = ""logEvent"";
                if (typeof this.snippet[legacyEvent] === ""function"") {
                    appInsights[legacyEvent] = function (name, properties, measurements) {
                        appInsights.trackEvent(name, properties, measurements);
                    };
                }
                return appInsights;
            };
            Initialization.prototype.emptyQueue = function () {
                try {
                    if (Microsoft.ApplicationInsights.Util.isArray(this.snippet.queue)) {
                        var length = this.snippet.queue.length;
                        for (var i = 0; i < length; i++) {
                            var call = this.snippet.queue[i];
                            call();
                        }
                        this.snippet.queue = undefined;
                        delete this.snippet.queue;
                    }
                }
                catch (exception) {
                    var properties = {};
                    if (exception && typeof exception.toString === ""function"") {
                        properties.exception = exception.toString();
                    }
                    var message = new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_FailedToSendQueuedTelemetry, ""Failed to send queued telemetry"", properties);
                    Microsoft.ApplicationInsights._InternalLogging.throwInternalNonUserActionable(ApplicationInsights.LoggingSeverity.WARNING, message);
                }
            };
            Initialization.prototype.pollInteralLogs = function (appInsightsInstance) {
                return setInterval(function () {
                    var queue = Microsoft.ApplicationInsights._InternalLogging.queue;
                    var length = queue.length;
                    for (var i = 0; i < length; i++) {
                        appInsightsInstance.trackTrace(queue[i].message);
                    }
                    queue.length = 0;
                }, this.config.diagnosticLogInterval);
            };
            Initialization.prototype.addHousekeepingBeforeUnload = function (appInsightsInstance) {
                // Add callback to push events when the user navigates away
                if (!appInsightsInstance.config.disableFlushOnBeforeUnload && ('onbeforeunload' in window)) {
                    var performHousekeeping = function () {
                        appInsightsInstance.context._sender.triggerSend();
                        appInsightsInstance.context._sessionManager.backup();
                    };
                    if (!Microsoft.ApplicationInsights.Util.addEventHandler('beforeunload', performHousekeeping)) {
                        Microsoft.ApplicationInsights._InternalLogging.throwInternalNonUserActionable(Microsoft.ApplicationInsights.LoggingSeverity.CRITICAL, new ApplicationInsights._InternalLogMessage(ApplicationInsights._InternalMessageId.NONUSRACT_FailedToAddHandlerForOnBeforeUnload, 'Could not add handler for beforeunload'));
                    }
                }
            };
            Initialization.getDefaultConfig = function (config) {
                if (!config) {
                    config = {};
                }
                config.endpointUrl = config.endpointUrl || ""//dc.services.visualstudio.com/v2/track"";
                config.sessionRenewalMs = 30 * 60 * 1000;
                config.sessionExpirationMs = 24 * 60 * 60 * 1000;
                config.maxBatchSizeInBytes = config.maxBatchSizeInBytes > 0 ? config.maxBatchSizeInBytes : 1000000;
                config.maxBatchInterval = !isNaN(config.maxBatchInterval) ? config.maxBatchInterval : 15000;
                config.enableDebug = ApplicationInsights.Util.stringToBoolOrDefault(config.enableDebug);
                config.disableExceptionTracking = (config.disableExceptionTracking !== undefined && config.disableExceptionTracking !== null) ?
                    ApplicationInsights.Util.stringToBoolOrDefault(config.disableExceptionTracking) :
                    false;
                config.disableTelemetry = ApplicationInsights.Util.stringToBoolOrDefault(config.disableTelemetry);
                config.verboseLogging = ApplicationInsights.Util.stringToBoolOrDefault(config.verboseLogging);
                config.emitLineDelimitedJson = ApplicationInsights.Util.stringToBoolOrDefault(config.emitLineDelimitedJson);
                config.diagnosticLogInterval = config.diagnosticLogInterval || 10000;
                config.autoTrackPageVisitTime = ApplicationInsights.Util.stringToBoolOrDefault(config.autoTrackPageVisitTime);
                if (isNaN(config.samplingPercentage) || config.samplingPercentage <= 0 || config.samplingPercentage >= 100) {
                    config.samplingPercentage = 100;
                }
                config.disableAjaxTracking = (config.disableAjaxTracking !== undefined && config.disableAjaxTracking !== null) ?
                    ApplicationInsights.Util.stringToBoolOrDefault(config.disableAjaxTracking) :
                    false;
                config.maxAjaxCallsPerView = !isNaN(config.maxAjaxCallsPerView) ? config.maxAjaxCallsPerView : 500;
                config.disableCorrelationHeaders = (config.disableCorrelationHeaders !== undefined && config.disableCorrelationHeaders !== null) ?
                    ApplicationInsights.Util.stringToBoolOrDefault(config.disableCorrelationHeaders) :
                    true;
                config.disableFlushOnBeforeUnload = (config.disableFlushOnBeforeUnload !== undefined && config.disableFlushOnBeforeUnload !== null) ?
                    ApplicationInsights.Util.stringToBoolOrDefault(config.disableFlushOnBeforeUnload) :
                    false;
                return config;
            };
            return Initialization;
        })();
        ApplicationInsights.Initialization = Initialization;
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));
/// <reference path=""initialization.ts"" />
var Microsoft;
(function (Microsoft) {
    var ApplicationInsights;
    (function (ApplicationInsights) {
        ""use strict"";
        try {
            if (typeof window !== ""undefined"" && typeof JSON !== ""undefined"") {
                var aiName = ""appInsights"";
                if (window[aiName] === undefined) {
                    Microsoft.ApplicationInsights.AppInsights.defaultConfig = Microsoft.ApplicationInsights.Initialization.getDefaultConfig();
                }
                else {
                    var snippet = window[aiName] || {};
                    var init = new Microsoft.ApplicationInsights.Initialization(snippet);
                    var appInsightsLocal = init.loadAppInsights();
                    for (var field in appInsightsLocal) {
                        snippet[field] = appInsightsLocal[field];
                    }
                    init.emptyQueue();
                    init.pollInteralLogs(appInsightsLocal);
                    init.addHousekeepingBeforeUnload(appInsightsLocal);
                }
            }
        }
        catch (e) {
            Microsoft.ApplicationInsights._InternalLogging.warnToConsole('Failed to initialize AppInsights JS SDK: ' + e.message);
        }
    })(ApplicationInsights = Microsoft.ApplicationInsights || (Microsoft.ApplicationInsights = {}));
})(Microsoft || (Microsoft = {}));

";

        public static string aiJSMinFileContent = @"var __extends,AI,Microsoft;(function(n){var t;(function(n){var r,t,i,u;(function(n){n[n.CRITICAL=0]=""CRITICAL"";n[n.WARNING=1]=""WARNING""})(n.LoggingSeverity||(n.LoggingSeverity={}));r=n.LoggingSeverity,function(n){n[n.NONUSRACT_BrowserDoesNotSupportLocalStorage=0]=""NONUSRACT_BrowserDoesNotSupportLocalStorage"";n[n.NONUSRACT_BrowserCannotReadLocalStorage=1]=""NONUSRACT_BrowserCannotReadLocalStorage"";n[n.NONUSRACT_BrowserCannotReadSessionStorage=2]=""NONUSRACT_BrowserCannotReadSessionStorage"";n[n.NONUSRACT_BrowserCannotWriteLocalStorage=3]=""NONUSRACT_BrowserCannotWriteLocalStorage"";n[n.NONUSRACT_BrowserCannotWriteSessionStorage=4]=""NONUSRACT_BrowserCannotWriteSessionStorage"";n[n.NONUSRACT_BrowserFailedRemovalFromLocalStorage=5]=""NONUSRACT_BrowserFailedRemovalFromLocalStorage"";n[n.NONUSRACT_BrowserFailedRemovalFromSessionStorage=6]=""NONUSRACT_BrowserFailedRemovalFromSessionStorage"";n[n.NONUSRACT_CannotSendEmptyTelemetry=7]=""NONUSRACT_CannotSendEmptyTelemetry"";n[n.NONUSRACT_ClientPerformanceMathError=8]=""NONUSRACT_ClientPerformanceMathError"";n[n.NONUSRACT_ErrorParsingAISessionCookie=9]=""NONUSRACT_ErrorParsingAISessionCookie"";n[n.NONUSRACT_ErrorPVCalc=10]=""NONUSRACT_ErrorPVCalc"";n[n.NONUSRACT_ExceptionWhileLoggingError=11]=""NONUSRACT_ExceptionWhileLoggingError"";n[n.NONUSRACT_FailedAddingTelemetryToBuffer=12]=""NONUSRACT_FailedAddingTelemetryToBuffer"";n[n.NONUSRACT_FailedMonitorAjaxAbort=13]=""NONUSRACT_FailedMonitorAjaxAbort"";n[n.NONUSRACT_FailedMonitorAjaxDur=14]=""NONUSRACT_FailedMonitorAjaxDur"";n[n.NONUSRACT_FailedMonitorAjaxOpen=15]=""NONUSRACT_FailedMonitorAjaxOpen"";n[n.NONUSRACT_FailedMonitorAjaxRSC=16]=""NONUSRACT_FailedMonitorAjaxRSC"";n[n.NONUSRACT_FailedMonitorAjaxSend=17]=""NONUSRACT_FailedMonitorAjaxSend"";n[n.NONUSRACT_FailedToAddHandlerForOnBeforeUnload=18]=""NONUSRACT_FailedToAddHandlerForOnBeforeUnload"";n[n.NONUSRACT_FailedToSendQueuedTelemetry=19]=""NONUSRACT_FailedToSendQueuedTelemetry"";n[n.NONUSRACT_FailedToReportDataLoss=20]=""NONUSRACT_FailedToReportDataLoss"";n[n.NONUSRACT_FlushFailed=21]=""NONUSRACT_FlushFailed"";n[n.NONUSRACT_MessageLimitPerPVExceeded=22]=""NONUSRACT_MessageLimitPerPVExceeded"";n[n.NONUSRACT_MissingRequiredFieldSpecification=23]=""NONUSRACT_MissingRequiredFieldSpecification"";n[n.NONUSRACT_NavigationTimingNotSupported=24]=""NONUSRACT_NavigationTimingNotSupported"";n[n.NONUSRACT_OnError=25]=""NONUSRACT_OnError"";n[n.NONUSRACT_SessionRenewalDateIsZero=26]=""NONUSRACT_SessionRenewalDateIsZero"";n[n.NONUSRACT_SenderNotInitialized=27]=""NONUSRACT_SenderNotInitialized"";n[n.NONUSRACT_StartTrackEventFailed=28]=""NONUSRACT_StartTrackEventFailed"";n[n.NONUSRACT_StopTrackEventFailed=29]=""NONUSRACT_StopTrackEventFailed"";n[n.NONUSRACT_StartTrackFailed=30]=""NONUSRACT_StartTrackFailed"";n[n.NONUSRACT_StopTrackFailed=31]=""NONUSRACT_StopTrackFailed"";n[n.NONUSRACT_TelemetrySampledAndNotSent=32]=""NONUSRACT_TelemetrySampledAndNotSent"";n[n.NONUSRACT_TrackEventFailed=33]=""NONUSRACT_TrackEventFailed"";n[n.NONUSRACT_TrackExceptionFailed=34]=""NONUSRACT_TrackExceptionFailed"";n[n.NONUSRACT_TrackMetricFailed=35]=""NONUSRACT_TrackMetricFailed"";n[n.NONUSRACT_TrackPVFailed=36]=""NONUSRACT_TrackPVFailed"";n[n.NONUSRACT_TrackPVFailedCalc=37]=""NONUSRACT_TrackPVFailedCalc"";n[n.NONUSRACT_TrackTraceFailed=38]=""NONUSRACT_TrackTraceFailed"";n[n.NONUSRACT_TransmissionFailed=39]=""NONUSRACT_TransmissionFailed"";n[n.USRACT_CannotSerializeObject=40]=""USRACT_CannotSerializeObject"";n[n.USRACT_CannotSerializeObjectNonSerializable=41]=""USRACT_CannotSerializeObjectNonSerializable"";n[n.USRACT_CircularReferenceDetected=42]=""USRACT_CircularReferenceDetected"";n[n.USRACT_ClearAuthContextFailed=43]=""USRACT_ClearAuthContextFailed"";n[n.USRACT_ExceptionTruncated=44]=""USRACT_ExceptionTruncated"";n[n.USRACT_IllegalCharsInName=45]=""USRACT_IllegalCharsInName"";n[n.USRACT_ItemNotInArray=46]=""USRACT_ItemNotInArray"";n[n.USRACT_MaxAjaxPerPVExceeded=47]=""USRACT_MaxAjaxPerPVExceeded"";n[n.USRACT_MessageTruncated=48]=""USRACT_MessageTruncated"";n[n.USRACT_NameTooLong=49]=""USRACT_NameTooLong"";n[n.USRACT_SampleRateOutOfRange=50]=""USRACT_SampleRateOutOfRange"";n[n.USRACT_SetAuthContextFailed=51]=""USRACT_SetAuthContextFailed"";n[n.USRACT_SetAuthContextFailedAccountName=52]=""USRACT_SetAuthContextFailedAccountName"";n[n.USRACT_StringValueTooLong=53]=""USRACT_StringValueTooLong"";n[n.USRACT_StartCalledMoreThanOnce=54]=""USRACT_StartCalledMoreThanOnce"";n[n.USRACT_StopCalledWithoutStart=55]=""USRACT_StopCalledWithoutStart"";n[n.USRACT_TelemetryInitializerFailed=56]=""USRACT_TelemetryInitializerFailed"";n[n.USRACT_TrackArgumentsNotSpecified=57]=""USRACT_TrackArgumentsNotSpecified"";n[n.USRACT_UrlTooLong=58]=""USRACT_UrlTooLong""}(n._InternalMessageId||(n._InternalMessageId={}));t=n._InternalMessageId;i=function(){function n(i,r,u){this.message=t[i].toString();this.messageId=i;var f=(r?"" message:""+n.sanitizeDiagnosticText(r):"""")+(u?"" props:""+n.sanitizeDiagnosticText(JSON.stringify(u)):"""");this.message+=f}return n.sanitizeDiagnosticText=function(n){return'""'+n.replace(/\""/g,"""")+'""'},n}();n._InternalLogMessage=i;u=function(){function u(){}return u.throwInternalNonUserActionable=function(n,t){if(this.enableDebugExceptions())throw t;else typeof t==""undefined""||!t||typeof t.message!=""undefined""&&(t.message=this.AiNonUserActionablePrefix+t.message,this.warnToConsole(t.message),this.logInternalMessage(n,t))},u.throwInternalUserActionable=function(n,t){if(this.enableDebugExceptions())throw t;else typeof t==""undefined""||!t||typeof t.message!=""undefined""&&(t.message=this.AiUserActionablePrefix+t.message,this.warnToConsole(t.message),this.logInternalMessage(n,t))},u.warnToConsole=function(n){typeof console==""undefined""||!console||(typeof console.warn==""function""?console.warn(n):typeof console.log==""function""&&console.log(n))},u.resetInternalMessageCount=function(){this._messageCount=0},u.clearInternalMessageLoggedTypes=function(){var i,t;if(n.Util.canUseSessionStorage())for(i=n.Util.getSessionStorageKeys(),t=0;t<i.length;t++)i[t].indexOf(u.AIInternalMessagePrefix)===0&&n.Util.removeSessionStorage(i[t])},u.setMaxInternalMessageLimit=function(n){if(!n)throw new Error(""limit cannot be undefined."");this.MAX_INTERNAL_MESSAGE_LIMIT=n},u.logInternalMessage=function(f,e){var o,s,c,h,l;this._areInternalMessagesThrottled()||(o=!0,n.Util.canUseSessionStorage()&&(s=u.AIInternalMessagePrefix+t[e.messageId],c=n.Util.getSessionStorage(s),c?o=!1:n.Util.setSessionStorage(s,""1"")),o&&((this.verboseLogging()||f===r.CRITICAL)&&(this.queue.push(e),this._messageCount++),this._messageCount==this.MAX_INTERNAL_MESSAGE_LIMIT&&(h=""Internal events throttle limit per PageView reached for this app."",l=new i(t.NONUSRACT_MessageLimitPerPVExceeded,h),this.queue.push(l),this.warnToConsole(h))))},u._areInternalMessagesThrottled=function(){return this._messageCount>=this.MAX_INTERNAL_MESSAGE_LIMIT},u.AiUserActionablePrefix=""AI: "",u.AIInternalMessagePrefix=""AITR_"",u.AiNonUserActionablePrefix=""AI (Internal): "",u.enableDebugExceptions=function(){return!1},u.verboseLogging=function(){return!1},u.queue=[],u.MAX_INTERNAL_MESSAGE_LIMIT=25,u._messageCount=0,u}();n._InternalLogging=u})(t=n.ApplicationInsights||(n.ApplicationInsights={}))})(Microsoft||(Microsoft={})),function(n){var t;(function(n){var t,i,r;(function(n){n[n.LocalStorage=0]=""LocalStorage"";n[n.SessionStorage=1]=""SessionStorage""})(t||(t={}));i=function(){function i(){}return i._getLocalStorageObject=function(){return i._getVerifiedStorageObject(t.LocalStorage)},i._getVerifiedStorageObject=function(n){var i=null,u,r;try{r=new Date;i=n===t.LocalStorage?window.localStorage:window.sessionStorage;i.setItem(r,r);u=i.getItem(r)!=r;i.removeItem(r);u&&(i=null)}catch(f){i=null}return i},i.canUseLocalStorage=function(){return!!i._getLocalStorageObject()},i.getStorage=function(t){var r=i._getLocalStorageObject(),f;if(r!==null)try{return r.getItem(t)}catch(u){f=new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_BrowserCannotReadLocalStorage,""Browser failed read of local storage. ""+i.getExceptionName(u),{exception:i.dump(u)});n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.WARNING,f)}return null},i.setStorage=function(t,r){var u=i._getLocalStorageObject(),e;if(u!==null)try{return u.setItem(t,r),!0}catch(f){e=new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_BrowserCannotWriteLocalStorage,""Browser failed write to local storage. ""+i.getExceptionName(f),{exception:i.dump(f)});n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.WARNING,e)}return!1},i.removeStorage=function(t){var r=i._getLocalStorageObject(),f;if(r!==null)try{return r.removeItem(t),!0}catch(u){f=new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_BrowserFailedRemovalFromLocalStorage,""Browser failed removal of local storage item. ""+i.getExceptionName(u),{exception:i.dump(u)});n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.WARNING,f)}return!1},i._getSessionStorageObject=function(){return i._getVerifiedStorageObject(t.SessionStorage)},i.canUseSessionStorage=function(){return!!i._getSessionStorageObject()},i.getSessionStorageKeys=function(){var n=[],t;if(i.canUseSessionStorage())for(t in window.sessionStorage)n.push(t);return n},i.getSessionStorage=function(t){var r=i._getSessionStorageObject(),f;if(r!==null)try{return r.getItem(t)}catch(u){f=new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_BrowserCannotReadSessionStorage,""Browser failed read of session storage. ""+i.getExceptionName(u),{exception:i.dump(u)});n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.CRITICAL,f)}return null},i.setSessionStorage=function(t,r){var u=i._getSessionStorageObject(),e;if(u!==null)try{return u.setItem(t,r),!0}catch(f){e=new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_BrowserCannotWriteSessionStorage,""Browser failed write to session storage. ""+i.getExceptionName(f),{exception:i.dump(f)});n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.CRITICAL,e)}return!1},i.removeSessionStorage=function(t){var r=i._getSessionStorageObject(),f;if(r!==null)try{return r.removeItem(t),!0}catch(u){f=new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_BrowserFailedRemovalFromSessionStorage,""Browser failed removal of session storage item. ""+i.getExceptionName(u),{exception:i.dump(u)});n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.CRITICAL,f)}return!1},i.setCookie=function(n,t,r){var u="""";r&&(u="";domain=""+r);i.document.cookie=n+""=""+t+u+"";path=/""},i.stringToBoolOrDefault=function(n){return n?n.toString().toLowerCase()===""true"":!1},i.getCookie=function(n){var e="""",f,u,r,t;if(n&&n.length)for(f=n+""="",u=i.document.cookie.split("";""),r=0;r<u.length;r++)if(t=u[r],t=i.trim(t),t&&t.indexOf(f)===0){e=t.substring(f.length,u[r].length);break}return e},i.deleteCookie=function(n){i.document.cookie=n+""=;path=/;expires=Thu, 01 Jan 1970 00:00:01 GMT;""},i.trim=function(n){return typeof n!=""string""?n:n.replace(/^\s+|\s+$/g,"""")},i.newId=function(){for(var t="""",n=Math.random()*1073741824,i;n>0;)i=""ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"".charAt(n%64),t+=i,n=Math.floor(n/64);return t},i.isArray=function(n){return Object.prototype.toString.call(n)===""[object Array]""},i.isError=function(n){return Object.prototype.toString.call(n)===""[object Error]""},i.isDate=function(n){return Object.prototype.toString.call(n)===""[object Date]""},i.toISOStringForIE8=function(n){if(i.isDate(n)){function t(n){var t=String(n);return t.length===1&&(t=""0""+t),t}return Date.prototype.toISOString?n.toISOString():n.getUTCFullYear()+""-""+t(n.getUTCMonth()+1)+""-""+t(n.getUTCDate())+""T""+t(n.getUTCHours())+"":""+t(n.getUTCMinutes())+"":""+t(n.getUTCSeconds())+"".""+String((n.getUTCMilliseconds()/1e3).toFixed(3)).slice(2,5)+""Z""}},i.getIEVersion=function(n){n===void 0&&(n=null);var t=n?n.toLowerCase():navigator.userAgent.toLowerCase();return t.indexOf(""msie"")!=-1?parseInt(t.split(""msie"")[1]):null},i.msToTimeSpan=function(n){(isNaN(n)||n<0)&&(n=0);var t=""""+n%1e3,i=""""+Math.floor(n/1e3)%60,r=""""+Math.floor(n/6e4)%60,u=""""+Math.floor(n/36e5)%24;return t=t.length===1?""00""+t:t.length===2?""0""+t:t,i=i.length<2?""0""+i:i,r=r.length<2?""0""+r:r,u=u.length<2?""0""+u:u,u+"":""+r+"":""+i+"".""+t},i.isCrossOriginError=function(n,t,i,r,u){return(n===""Script error.""||n===""Script error"")&&u===null},i.dump=function(n){var t=Object.prototype.toString.call(n),i=JSON.stringify(n);return t===""[object Error]""&&(i=""{ stack: '""+n.stack+""', message: '""+n.message+""', name: '""+n.name+""'""),t+i},i.getExceptionName=function(n){var t=Object.prototype.toString.call(n);return t===""[object Error]""?n.name:""""},i.addEventHandler=function(n,t){if(!window||typeof n!=""string""||typeof t!=""function"")return!1;var i=""on""+n;if(window.addEventListener)window.addEventListener(n,t,!1);else if(window.attachEvent)window.attachEvent.call(i,t);else return!1;return!0},i.document=typeof document!=""undefined""?document:{},i.NotSpecified=""not_specified"",i}();n.Util=i;r=function(){function n(){}return n.parseUrl=function(t){return n.htmlAnchorElement||(n.htmlAnchorElement=n.document.createElement(""a"")),n.htmlAnchorElement.href=t,n.htmlAnchorElement},n.getAbsoluteUrl=function(t){var i,r=n.parseUrl(t);return r&&(i=r.href),i},n.getPathName=function(t){var i,r=n.parseUrl(t);return r&&(i=r.pathname),i},n.document=typeof document!=""undefined""?document:{},n}();n.UrlHelper=r})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){""use strict"";var t=function(){function n(){}return n.IsNullOrUndefined=function(n){return typeof n==""undefined""||n===null},n}(),i,r,u;n.extensions=t;i=function(){function n(){}return n.GetLength=function(n){var i=0,r;if(!t.IsNullOrUndefined(n)){r="""";try{r=n.toString()}catch(u){}i=r.length;i=isNaN(i)?0:i}return i},n}();n.stringUtils=i;r=function(){function n(){}return n.Now=window.performance&&window.performance.now?function(){return performance.now()}:function(){return(new Date).getTime()},n.GetDuration=function(n,i){var r=null;return n===0||i===0||t.IsNullOrUndefined(n)||t.IsNullOrUndefined(i)||(r=i-n),r},n}();n.dateTime=r;u=function(){function n(){}return n.AttachEvent=function(n,i,r){var u=!1;return t.IsNullOrUndefined(n)||(t.IsNullOrUndefined(n.attachEvent)?t.IsNullOrUndefined(n.addEventListener)||(n.addEventListener(i,r,!1),u=!0):(n.attachEvent(""on""+i,r),u=!0)),u},n.DetachEvent=function(n,i,r){t.IsNullOrUndefined(n)||(t.IsNullOrUndefined(n.detachEvent)?t.IsNullOrUndefined(n.removeEventListener)||n.removeEventListener(i,r,!1):n.detachEvent(""on""+i,r))},n}();n.EventHelper=u})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){""use strict"";var t=function(){function n(){this.openDone=!1;this.setRequestHeaderDone=!1;this.sendDone=!1;this.abortDone=!1;this.onreadystatechangeCallbackAttached=!1}return n}(),i;n.XHRMonitoringState=t;i=function(){function i(i){this.completed=!1;this.requestHeadersSize=null;this.ttfb=null;this.responseReceivingDuration=null;this.callbackDuration=null;this.ajaxTotalDuration=null;this.aborted=null;this.pageUrl=null;this.requestUrl=null;this.requestSize=0;this.method=null;this.status=null;this.requestSentTime=null;this.responseStartedTime=null;this.responseFinishedTime=null;this.callbackFinishedTime=null;this.endTime=null;this.originalOnreadystatechage=null;this.xhrMonitoringState=new t;this.clientFailure=0;this.CalculateMetrics=function(){var t=this;t.ajaxTotalDuration=n.dateTime.GetDuration(t.requestSentTime,t.responseFinishedTime)};this.id=i}return i.prototype.getAbsoluteUrl=function(){return this.requestUrl?n.UrlHelper.getAbsoluteUrl(this.requestUrl):null},i.prototype.getPathName=function(){return this.requestUrl?n.UrlHelper.getPathName(this.requestUrl):null},i}();n.ajaxRecord=i})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(t){""use strict"";var i=function(){function i(n){this.currentWindowHost=window.location.host;this.appInsights=n;this.initialized=!1;this.Init()}return i.prototype.Init=function(){this.supportsMonitoring()&&(this.instrumentOpen(),this.instrumentSend(),this.instrumentAbort(),this.initialized=!0)},i.prototype.isMonitoredInstance=function(n,r){return this.initialized&&(r===!0||!t.extensions.IsNullOrUndefined(n.ajaxData))&&n[i.DisabledPropertyName]!==!0},i.prototype.supportsMonitoring=function(){var n=!1;return t.extensions.IsNullOrUndefined(XMLHttpRequest)||(n=!0),n},i.prototype.instrumentOpen=function(){var u=XMLHttpRequest.prototype.open,r=this;XMLHttpRequest.prototype.open=function(f,e,o){try{!r.isMonitoredInstance(this,!0)||this.ajaxData&&this.ajaxData.xhrMonitoringState.openDone||r.openHandler(this,f,e,o)}catch(s){t._InternalLogging.throwInternalNonUserActionable(t.LoggingSeverity.CRITICAL,new t._InternalLogMessage(t._InternalMessageId.NONUSRACT_FailedMonitorAjaxOpen,""Failed to monitor XMLHttpRequest.open, monitoring data for this ajax call may be incorrect."",{ajaxDiagnosticsMessage:i.getFailedAjaxDiagnosticsMessage(this),exception:n.ApplicationInsights.Util.dump(s)}))}return u.apply(this,arguments)}},i.prototype.openHandler=function(n,i,r){var u=new t.ajaxRecord(t.Util.newId());u.method=i;u.requestUrl=r;u.xhrMonitoringState.openDone=!0;n.ajaxData=u;this.attachToOnReadyStateChange(n)},i.getFailedAjaxDiagnosticsMessage=function(n){var i="""";try{t.extensions.IsNullOrUndefined(n)||t.extensions.IsNullOrUndefined(n.ajaxData)||t.extensions.IsNullOrUndefined(n.ajaxData.requestUrl)||(i+=""(url: '""+n.ajaxData.requestUrl+""')"")}catch(r){}return i},i.prototype.instrumentSend=function(){var u=XMLHttpRequest.prototype.send,r=this;XMLHttpRequest.prototype.send=function(f){try{r.isMonitoredInstance(this)&&!this.ajaxData.xhrMonitoringState.sendDone&&r.sendHandler(this,f)}catch(e){t._InternalLogging.throwInternalNonUserActionable(t.LoggingSeverity.CRITICAL,new t._InternalLogMessage(t._InternalMessageId.NONUSRACT_FailedMonitorAjaxSend,""Failed to monitor XMLHttpRequest, monitoring data for this ajax call may be incorrect."",{ajaxDiagnosticsMessage:i.getFailedAjaxDiagnosticsMessage(this),exception:n.ApplicationInsights.Util.dump(e)}))}return u.apply(this,arguments)}},i.prototype.sendHandler=function(n){n.ajaxData.requestSentTime=t.dateTime.Now();this.appInsights.config.disableCorrelationHeaders||t.UrlHelper.parseUrl(n.ajaxData.getAbsoluteUrl()).host!=this.currentWindowHost||n.setRequestHeader(""x-ms-request-id"",n.ajaxData.id);n.ajaxData.xhrMonitoringState.sendDone=!0},i.prototype.instrumentAbort=function(){var r=XMLHttpRequest.prototype.abort,u=this;XMLHttpRequest.prototype.abort=function(){try{u.isMonitoredInstance(this)&&!this.ajaxData.xhrMonitoringState.abortDone&&(this.ajaxData.aborted=1,this.ajaxData.xhrMonitoringState.abortDone=!0)}catch(f){t._InternalLogging.throwInternalNonUserActionable(t.LoggingSeverity.CRITICAL,new t._InternalLogMessage(t._InternalMessageId.NONUSRACT_FailedMonitorAjaxAbort,""Failed to monitor XMLHttpRequest.abort, monitoring data for this ajax call may be incorrect."",{ajaxDiagnosticsMessage:i.getFailedAjaxDiagnosticsMessage(this),exception:n.ApplicationInsights.Util.dump(f)}))}return r.apply(this,arguments)}},i.prototype.attachToOnReadyStateChange=function(r){var u=this;r.ajaxData.xhrMonitoringState.onreadystatechangeCallbackAttached=t.EventHelper.AttachEvent(r,""readystatechange"",function(){try{if(u.isMonitoredInstance(r)&&r.readyState===4)u.onAjaxComplete(r)}catch(f){var e=n.ApplicationInsights.Util.dump(f);e&&e.toLowerCase().indexOf(""c00c023f"")!=-1||t._InternalLogging.throwInternalNonUserActionable(t.LoggingSeverity.CRITICAL,new t._InternalLogMessage(t._InternalMessageId.NONUSRACT_FailedMonitorAjaxRSC,""Failed to monitor XMLHttpRequest 'readystatechange' event handler, monitoring data for this ajax call may be incorrect."",{ajaxDiagnosticsMessage:i.getFailedAjaxDiagnosticsMessage(r),exception:n.ApplicationInsights.Util.dump(f)}))}})},i.prototype.onAjaxComplete=function(n){n.ajaxData.responseFinishedTime=t.dateTime.Now();n.ajaxData.status=n.status;n.ajaxData.CalculateMetrics();n.ajaxData.ajaxTotalDuration<0?t._InternalLogging.throwInternalNonUserActionable(t.LoggingSeverity.WARNING,new t._InternalLogMessage(t._InternalMessageId.NONUSRACT_FailedMonitorAjaxDur,""Failed to calculate the duration of the ajax call, monitoring data for this ajax call won't be sent."",{ajaxDiagnosticsMessage:i.getFailedAjaxDiagnosticsMessage(n),requestSentTime:n.ajaxData.requestSentTime,responseFinishedTime:n.ajaxData.responseFinishedTime})):(this.appInsights.trackAjax(n.ajaxData.id,n.ajaxData.getAbsoluteUrl(),n.ajaxData.getPathName(),n.ajaxData.ajaxTotalDuration,+n.ajaxData.status>=200&&+n.ajaxData.status<400,+n.ajaxData.status),n.ajaxData=null)},i.instrumentedByAppInsightsName=""InstrumentedByAppInsights"",i.DisabledPropertyName=""Microsoft_ApplicationInsights_BypassAjaxInstrumentation"",i}();t.AjaxMonitor=i})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){var t=function(){function n(){}return n.prototype.getHashCodeScore=function(t){var i=this.getHashCode(t)/n.INT_MAX_VALUE;return i*100},n.prototype.getHashCode=function(t){var i,r;if(t=="""")return 0;while(t.length<n.MIN_INPUT_LENGTH)t=t.concat(t);for(i=5381,r=0;r<t.length;++r)i=(i<<5)+i+t.charCodeAt(r),i=i&i;return Math.abs(i)},n.INT_MAX_VALUE=2147483647,n.MIN_INPUT_LENGTH=8,n}();n.HashCodeScoreGenerator=t})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){""use strict"";(function(n){n[n.Default=0]=""Default"";n[n.Required=1]=""Required"";n[n.Array=2]=""Array"";n[n.Hidden=4]=""Hidden""})(n.FieldType||(n.FieldType={}));var t=n.FieldType,i=function(){function i(){}return i.serialize=function(n){var t=i._serializeObject(n,""root"");return JSON.stringify(t)},i._serializeObject=function(r,u){var s=""__aiCircularRefCheck"",e={},f,c;if(!r)return n._InternalLogging.throwInternalUserActionable(n.LoggingSeverity.CRITICAL,new n._InternalLogMessage(n._InternalMessageId.USRACT_CannotSerializeObject,""cannot serialize object because it is null or undefined"",{name:u})),e;if(r[s])return n._InternalLogging.throwInternalUserActionable(n.LoggingSeverity.WARNING,new n._InternalLogMessage(n._InternalMessageId.USRACT_CircularReferenceDetected,""Circular reference detected while serializing object"",{name:u})),e;if(!r.aiDataContract){if(u===""measurements"")e=i._serializeStringMap(r,""number"",u);else if(u===""properties"")e=i._serializeStringMap(r,""string"",u);else if(u===""tags"")e=i._serializeStringMap(r,""string"",u);else if(n.Util.isArray(r))e=i._serializeArray(r,u);else{n._InternalLogging.throwInternalUserActionable(n.LoggingSeverity.WARNING,new n._InternalLogMessage(n._InternalMessageId.USRACT_CannotSerializeObjectNonSerializable,""Attempting to serialize an object which does not implement ISerializable"",{name:u}));try{JSON.stringify(r);e=r}catch(h){n._InternalLogging.throwInternalUserActionable(n.LoggingSeverity.CRITICAL,h&&typeof h.toString==""function""?h.toString():""Error serializing object"")}}return e}r[s]=!0;for(f in r.aiDataContract){var o=r.aiDataContract[f],a=typeof o==""function""?o()&t.Required:o&t.Required,v=typeof o==""function""?o()&t.Hidden:o&t.Hidden,l=o&t.Array,y=r[f]!==undefined,p=typeof r[f]==""object""&&r[f]!==null;if(a&&!y&&!l){n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.CRITICAL,new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_MissingRequiredFieldSpecification,""Missing required field specification. The field is required but not present on source"",{field:f,name:u}));continue}v||(c=p?l?i._serializeArray(r[f],f):i._serializeObject(r[f],f):r[f],c!==undefined&&(e[f]=c))}return delete r[s],e},i._serializeArray=function(t,r){var f=undefined,u,e,o;if(!!t)if(n.Util.isArray(t))for(f=[],u=0;u<t.length;u++)e=t[u],o=i._serializeObject(e,r+""[""+u+""]""),f.push(o);else n._InternalLogging.throwInternalUserActionable(n.LoggingSeverity.CRITICAL,new n._InternalLogMessage(n._InternalMessageId.USRACT_ItemNotInArray,""This field was specified as an array in the contract but the item is not an array.\r\n"",{name:r}));return f},i._serializeStringMap=function(t,i,r){var u=undefined,f,e,o;if(t){u={};for(f in t)e=t[f],i===""string""?u[f]=e===undefined?""undefined"":e===null?""null"":e.toString?e.toString():""invalid field: toString() is not defined."":i===""number""?e===undefined?u[f]=""undefined"":e===null?u[f]=""null"":(o=parseFloat(e),u[f]=isNaN(o)?""NaN"":o):(u[f]=""invalid field: ""+r+"" is of unknown type."",n._InternalLogging.throwInternalUserActionable(n.LoggingSeverity.CRITICAL,u[f]))}return u},i}();n.Serializer=i})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){""use strict"";var t=function(){function n(){}return n}();n.Base=t})(t=n.Telemetry||(n.Telemetry={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){""use strict"";var t=function(){function n(){this.ver=1;this.sampleRate=100;this.tags={}}return n}();n.Envelope=t})(t=n.Telemetry||(n.Telemetry={}))}(Microsoft||(Microsoft={}));__extends=this&&this.__extends||function(n,t){function r(){this.constructor=n}for(var i in t)t.hasOwnProperty(i)&&(n[i]=t[i]);r.prototype=t.prototype;n.prototype=new r},function(n){var t;(function(t){var i;(function(i){var r;(function(i){""use strict"";var r=function(n){function i(i,r){var u=this;n.call(this);this.name=r;this.data=i;this.time=t.Util.toISOStringForIE8(new Date);this.aiDataContract={time:t.FieldType.Required,iKey:t.FieldType.Required,name:t.FieldType.Required,sampleRate:function(){return u.sampleRate==100?t.FieldType.Hidden:t.FieldType.Required},tags:t.FieldType.Required,data:t.FieldType.Required}}return __extends(i,n),i}(n.Telemetry.Envelope);i.Envelope=r})(r=i.Common||(i.Common={}))})(i=t.Telemetry||(t.Telemetry={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(t){var i;(function(t){var i;(function(t){""use strict"";var i=function(n){function t(){n.apply(this,arguments);this.aiDataContract={}}return __extends(t,n),t}(n.Telemetry.Base);t.Base=i})(i=t.Common||(t.Common={}))})(i=t.Telemetry||(t.Telemetry={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){""use strict"";var t=function(){function n(){this.applicationVersion=""ai.application.ver"";this.applicationBuild=""ai.application.build"";this.applicationTypeId=""ai.application.typeId"";this.applicationId=""ai.application.applicationId"";this.deviceId=""ai.device.id"";this.deviceIp=""ai.device.ip"";this.deviceLanguage=""ai.device.language"";this.deviceLocale=""ai.device.locale"";this.deviceModel=""ai.device.model"";this.deviceNetwork=""ai.device.network"";this.deviceNetworkName=""ai.device.networkName"";this.deviceOEMName=""ai.device.oemName"";this.deviceOS=""ai.device.os"";this.deviceOSVersion=""ai.device.osVersion"";this.deviceRoleInstance=""ai.device.roleInstance"";this.deviceRoleName=""ai.device.roleName"";this.deviceScreenResolution=""ai.device.screenResolution"";this.deviceType=""ai.device.type"";this.deviceMachineName=""ai.device.machineName"";this.deviceVMName=""ai.device.vmName"";this.locationIp=""ai.location.ip"";this.operationId=""ai.operation.id"";this.operationName=""ai.operation.name"";this.operationParentId=""ai.operation.parentId"";this.operationRootId=""ai.operation.rootId"";this.operationSyntheticSource=""ai.operation.syntheticSource"";this.operationIsSynthetic=""ai.operation.isSynthetic"";this.operationCorrelationVector=""ai.operation.correlationVector"";this.sessionId=""ai.session.id"";this.sessionIsFirst=""ai.session.isFirst"";this.sessionIsNew=""ai.session.isNew"";this.userAccountAcquisitionDate=""ai.user.accountAcquisitionDate"";this.userAccountId=""ai.user.accountId"";this.userAgent=""ai.user.userAgent"";this.userId=""ai.user.id"";this.userStoreRegion=""ai.user.storeRegion"";this.userAuthUserId=""ai.user.authUserId"";this.userAnonymousUserAcquisitionDate=""ai.user.anonUserAcquisitionDate"";this.userAuthenticatedUserAcquisitionDate=""ai.user.authUserAcquisitionDate"";this.sampleRate=""ai.sample.sampleRate"";this.cloudName=""ai.cloud.name"";this.cloudRoleVer=""ai.cloud.roleVer"";this.cloudEnvironment=""ai.cloud.environment"";this.cloudLocation=""ai.cloud.location"";this.cloudDeploymentUnit=""ai.cloud.deploymentUnit"";this.serverDeviceOS=""ai.serverDevice.os"";this.serverDeviceOSVer=""ai.serverDevice.osVer"";this.internalSdkVersion=""ai.internal.sdkVersion"";this.internalAgentVersion=""ai.internal.agentVersion"";this.internalDataCollectorReceivedTime=""ai.internal.dataCollectorReceivedTime"";this.internalProfileId=""ai.internal.profileId"";this.internalProfileClassId=""ai.internal.profileClassId"";this.internalAccountId=""ai.internal.accountId"";this.internalApplicationName=""ai.internal.applicationName"";this.internalInstrumentationKey=""ai.internal.instrumentationKey"";this.internalTelemetryItemId=""ai.internal.telemetryItemId"";this.internalApplicationType=""ai.internal.applicationType"";this.internalRequestSource=""ai.internal.requestSource"";this.internalFlowType=""ai.internal.flowType"";this.internalIsAudit=""ai.internal.isAudit"";this.internalTrackingSourceId=""ai.internal.trackingSourceId"";this.internalTrackingType=""ai.internal.trackingType"";this.internalIsDiagnosticExample=""ai.internal.isDiagnosticExample""}return n}();n.ContextTagKeys=t}(AI||(AI={})),function(n){var t;(function(n){var t;(function(n){""use strict"";var t=function(){function n(){}return n}();n.Application=t})(t=n.Context||(n.Context={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){var t;(function(n){""use strict"";var t=function(){function n(){this.id=""browser"";this.type=""Browser""}return n}();n.Device=t})(t=n.Context||(n.Context={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){var t;(function(t){""use strict"";var i=function(){function t(){this.sdkVersion=""JavaScript:""+n.Version}return t}();t.Internal=i})(t=n.Context||(n.Context={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){var t;(function(n){""use strict"";var t=function(){function n(){}return n}();n.Location=t})(t=n.Context||(n.Context={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){var t;(function(t){""use strict"";var i=function(){function t(){this.id=n.Util.newId();window&&window.location&&window.location.pathname&&(this.name=window.location.pathname)}return t}();t.Operation=i})(t=n.Context||(n.Context={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){var t=function(){function t(){this.hashCodeGeneragor=new n.HashCodeScoreGenerator}return t.prototype.getSamplingScore=function(n){var t=new AI.ContextTagKeys;return n.tags[t.userId]?this.hashCodeGeneragor.getHashCodeScore(n.tags[t.userId]):n.tags[t.operationId]?this.hashCodeGeneragor.getHashCodeScore(n.tags[t.operationId]):Math.random()},t}();n.SamplingScoreGenerator=t})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){var t;(function(t){""use strict"";var i=function(){function t(t){this.INT_MAX_VALUE=2147483647;(t>100||t<0)&&(n._InternalLogging.throwInternalUserActionable(n.LoggingSeverity.WARNING,new n._InternalLogMessage(n._InternalMessageId.USRACT_SampleRateOutOfRange,""Sampling rate is out of range (0..100). Sampling will be disabled, you may be sending too much data which may affect your AI service level."",{samplingRate:t})),this.sampleRate=100);this.sampleRate=t;this.samplingScoreGenerator=new n.SamplingScoreGenerator}return t.prototype.isSampledIn=function(n){if(this.sampleRate==100)return!0;var t=this.samplingScoreGenerator.getSamplingScore(n);return t<this.sampleRate},t}();t.Sample=i})(t=n.Context||(n.Context={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){""use strict"";(function(n){n[n.Start=0]=""Start"";n[n.End=1]=""End""})(n.SessionState||(n.SessionState={}));var t=n.SessionState}(AI||(AI={})),function(n){var t;(function(n){var t;(function(t){""use strict"";var i=function(){function n(){}return n}(),r;t.Session=i;r=function(){function t(n){n||(n={});typeof n.sessionExpirationMs==""function""||(n.sessionExpirationMs=function(){return t.acquisitionSpan});typeof n.sessionRenewalMs==""function""||(n.sessionRenewalMs=function(){return t.renewalSpan});this.config=n;this.automaticSession=new i}return t.prototype.update=function(){this.automaticSession.id||this.initializeAutomaticSession();var n=+new Date,t=n-this.automaticSession.acquisitionDate>this.config.sessionExpirationMs(),i=n-this.automaticSession.renewalDate>this.config.sessionRenewalMs();t||i?(this.automaticSession.isFirst=undefined,this.renew()):(this.automaticSession.renewalDate=+new Date,this.setCookie(this.automaticSession.id,this.automaticSession.acquisitionDate,this.automaticSession.renewalDate))},t.prototype.backup=function(){this.setStorage(this.automaticSession.id,this.automaticSession.acquisitionDate,this.automaticSession.renewalDate)},t.prototype.initializeAutomaticSession=function(){var t=n.Util.getCookie(""ai_session""),i;t&&typeof t.split==""function""?this.initializeAutomaticSessionWithData(t):(i=n.Util.getStorage(""ai_session""),i&&this.initializeAutomaticSessionWithData(i));this.automaticSession.id||(this.automaticSession.isFirst=!0,this.renew())},t.prototype.initializeAutomaticSessionWithData=function(t){var i=t.split(""|""),r,u;i.length>0&&(this.automaticSession.id=i[0]);try{i.length>1&&(r=+i[1],this.automaticSession.acquisitionDate=+new Date(r),this.automaticSession.acquisitionDate=this.automaticSession.acquisitionDate>0?this.automaticSession.acquisitionDate:0);i.length>2&&(u=+i[2],this.automaticSession.renewalDate=+new Date(u),this.automaticSession.renewalDate=this.automaticSession.renewalDate>0?this.automaticSession.renewalDate:0)}catch(f){n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.CRITICAL,new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_ErrorParsingAISessionCookie,""Error parsing ai_session cookie, session will be reset: ""+n.Util.getExceptionName(f),{exception:n.Util.dump(f)}))}this.automaticSession.renewalDate==0&&n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.WARNING,new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_SessionRenewalDateIsZero,""AI session renewal date is 0, session will be reset.""))},t.prototype.renew=function(){var t=+new Date;this.automaticSession.id=n.Util.newId();this.automaticSession.acquisitionDate=t;this.automaticSession.renewalDate=t;this.setCookie(this.automaticSession.id,this.automaticSession.acquisitionDate,this.automaticSession.renewalDate);n.Util.canUseLocalStorage()||n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.WARNING,new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_BrowserDoesNotSupportLocalStorage,""Browser does not support local storage. Session durations will be inaccurate.""))},t.prototype.setCookie=function(t,i,r){var f=i+this.config.sessionExpirationMs(),e=r+this.config.sessionRenewalMs(),u=new Date,s=[t,i,r],o;f<e?u.setTime(f):u.setTime(e);o=this.config.cookieDomain?this.config.cookieDomain():null;n.Util.setCookie(""ai_session"",s.join(""|"")+"";expires=""+u.toUTCString(),o)},t.prototype.setStorage=function(t,i,r){n.Util.setStorage(""ai_session"",[t,i,r].join(""|""))},t.acquisitionSpan=864e5,t.renewalSpan=18e5,t}();t._SessionManager=r})(t=n.Context||(n.Context={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){var t;(function(t){""use strict"";var i=function(){function t(i){var s=n.Util.getCookie(t.userCookieName),e,u,o,h,c,f,r;s&&(e=s.split(t.cookieSeparator),e.length>0&&(this.id=e[0]));this.config=i;this.id||(this.id=n.Util.newId(),u=new Date,o=n.Util.toISOStringForIE8(u),this.accountAcquisitionDate=o,u.setTime(u.getTime()+31536e6),h=[this.id,o],c=this.config.cookieDomain?this.config.cookieDomain():undefined,n.Util.setCookie(t.userCookieName,h.join(t.cookieSeparator)+"";expires=""+u.toUTCString(),c),n.Util.removeStorage(""ai_session""));this.accountId=i.accountId?i.accountId():undefined;f=n.Util.getCookie(t.authUserCookieName);f&&(f=decodeURI(f),r=f.split(t.cookieSeparator),r[0]&&(this.authenticatedId=r[0]),r.length>1&&r[1]&&(this.accountId=r[1]))}return t.prototype.setAuthenticatedUserContext=function(i,r){var f=!this.validateUserInput(i)||r&&!this.validateUserInput(r),u;if(f){n._InternalLogging.throwInternalUserActionable(n.LoggingSeverity.WARNING,new n._InternalLogMessage(n._InternalMessageId.USRACT_SetAuthContextFailedAccountName,""Setting auth user context failed. User auth/account id should be of type string, and not contain commas, semi-colons, equal signs, spaces, or vertical-bars.""));return}this.authenticatedId=i;u=this.authenticatedId;r&&(this.accountId=r,u=[this.authenticatedId,this.accountId].join(t.cookieSeparator));n.Util.setCookie(t.authUserCookieName,encodeURI(u),this.config.cookieDomain())},t.prototype.clearAuthenticatedUserContext=function(){this.authenticatedId=null;this.accountId=null;n.Util.deleteCookie(t.authUserCookieName)},t.prototype.validateUserInput=function(n){return typeof n!=""string""||!n||n.match(/,|;|=| |\|/)?!1:!0},t.cookieSeparator=""|"",t.userCookieName=""ai_user"",t.authUserCookieName=""ai_authUser"",t}();t.User=i})(t=n.Context||(n.Context={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){""use strict"";var t=function(){function t(){}return t.reset=function(){t.isEnabled()&&n.Util.setSessionStorage(t.ITEMS_QUEUED_KEY,""0"")},t.isEnabled=function(){return t.enabled&&t.appInsights!=null&&n.Util.canUseSessionStorage()},t.getIssuesReported=function(){return!t.isEnabled()||isNaN(+n.Util.getSessionStorage(t.ISSUES_REPORTED_KEY))?0:+n.Util.getSessionStorage(t.ISSUES_REPORTED_KEY)},t.incrementItemsQueued=function(){try{if(t.isEnabled()){var i=t.getNumberOfLostItems();++i;n.Util.setSessionStorage(t.ITEMS_QUEUED_KEY,i.toString())}}catch(r){}},t.decrementItemsQueued=function(i){try{if(t.isEnabled()){var r=t.getNumberOfLostItems();r-=i;r<0&&(r=0);n.Util.setSessionStorage(t.ITEMS_QUEUED_KEY,r.toString())}}catch(u){}},t.getNumberOfLostItems=function(){var i=0;try{t.isEnabled()&&(i=isNaN(+n.Util.getSessionStorage(t.ITEMS_QUEUED_KEY))?0:+n.Util.getSessionStorage(t.ITEMS_QUEUED_KEY))}catch(r){i=0}return i},t.reportLostItems=function(){try{if(t.isEnabled()&&t.getIssuesReported()<t.LIMIT_PER_SESSION&&t.getNumberOfLostItems()>0){t.appInsights.trackTrace(""AI (Internal): Internal report DATALOSS: ""+t.getNumberOfLostItems(),null);t.appInsights.flush();var i=t.getIssuesReported();++i;n.Util.setSessionStorage(t.ISSUES_REPORTED_KEY,i.toString())}}catch(r){n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.CRITICAL,new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_FailedToReportDataLoss,""Failed to report data loss: ""+n.Util.getExceptionName(r),{exception:n.Util.dump(r)}))}finally{try{t.reset()}catch(r){}}},t.enabled=!1,t.LIMIT_PER_SESSION=10,t.ITEMS_QUEUED_KEY=""AI_itemsQueued"",t.ISSUES_REPORTED_KEY=""AI_lossIssuesReported"",t}();n.DataLossAnalyzer=t})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){""use strict"";var t=function(){function t(n){if(this._buffer=[],this._lastSend=0,this._config=n,this._sender=null,typeof XMLHttpRequest!=""undefined""){var t=new XMLHttpRequest;""withCredentials""in t?this._sender=this._xhrSender:typeof XDomainRequest!=""undefined""&&(this._sender=this._xdrSender)}}return t.prototype.send=function(t){var r=this,i;try{if(this._config.disableTelemetry())return;if(!t){n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.CRITICAL,new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_CannotSendEmptyTelemetry,""Cannot send empty telemetry""));return}if(!this._sender){n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.CRITICAL,new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_SenderNotInitialized,""Sender was not initialized""));return}i=n.Serializer.serialize(t);this._getSizeInBytes(this._buffer)+i.length>this._config.maxBatchSizeInBytes()&&this.triggerSend();this._buffer.push(i);this._timeoutHandle||(this._timeoutHandle=setTimeout(function(){r._timeoutHandle=null;r.triggerSend()},this._config.maxBatchInterval()));n.DataLossAnalyzer.incrementItemsQueued()}catch(u){n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.CRITICAL,new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_FailedAddingTelemetryToBuffer,""Failed adding telemetry to the sender's buffer, some telemetry will be lost: ""+n.Util.getExceptionName(u),{exception:n.Util.dump(u)}))}},t.prototype._getSizeInBytes=function(n){var r=0,t,i;if(n&&n.length)for(t=0;t<n.length;t++)i=n[t],i&&i.length&&(r+=i.length);return r},t.prototype.triggerSend=function(t){var i=!0,r;typeof t==""boolean""&&(i=t);try{this._config.disableTelemetry()||(this._buffer.length&&(r=this._config.emitLineDelimitedJson()?this._buffer.join(""\n""):""[""+this._buffer.join("","")+""]"",this._sender(r,i,this._buffer.length)),this._lastSend=+new Date);this._buffer.length=0;clearTimeout(this._timeoutHandle);this._timeoutHandle=null}catch(u){(!n.Util.getIEVersion()||n.Util.getIEVersion()>9)&&n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.CRITICAL,new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_TransmissionFailed,""Telemetry transmission failed, some telemetry will be lost: ""+n.Util.getExceptionName(u),{exception:n.Util.dump(u)}))}},t.prototype._xhrSender=function(i,r,u){var f=new XMLHttpRequest;f[n.AjaxMonitor.DisabledPropertyName]=!0;f.open(""POST"",this._config.endpointUrl(),r);f.setRequestHeader(""Content-type"",""application/json"");f.onreadystatechange=function(){return t._xhrReadyStateChange(f,i,u)};f.onerror=function(n){return t._onError(i,f.responseText||f.response||"""",n)};f.send(i)},t.prototype._xdrSender=function(n){var i=new XDomainRequest;i.onload=function(){return t._xdrOnLoad(i,n)};i.onerror=function(r){return t._onError(n,i.responseText||"""",r)};i.open(""POST"",this._config.endpointUrl());i.send(n)},t._xhrReadyStateChange=function(n,i,r){n.readyState===4&&((n.status<200||n.status>=300)&&n.status!==0?t._onError(i,n.responseText||n.response||""""):t._onSuccess(i,r))},t._xdrOnLoad=function(n,i){n&&(n.responseText+""""==""200""||n.responseText==="""")?t._onSuccess(i,0):t._onError(i,n&&n.responseText||"""")},t._onError=function(t,i){n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.WARNING,new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_OnError,""Failed to send telemetry."",{message:i}))},t._onSuccess=function(t,i){n.DataLossAnalyzer.decrementItemsQueued(i)},t}();n.Sender=t})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){""use strict"";var t=function(){function t(){this.hashCodeGeneragor=new n.HashCodeScoreGenerator}return t.prototype.isEnabled=function(n,t){return this.hashCodeGeneragor.getHashCodeScore(n)<t},t}();n.SplitTest=t})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){""use strict"";var t=function(){function n(){}return n}();n.Domain=t})(t=n.Telemetry||(n.Telemetry={}))}(Microsoft||(Microsoft={})),function(n){""use strict"";(function(n){n[n.Verbose=0]=""Verbose"";n[n.Information=1]=""Information"";n[n.Warning=2]=""Warning"";n[n.Error=3]=""Error"";n[n.Critical=4]=""Critical""})(n.SeverityLevel||(n.SeverityLevel={}));var t=n.SeverityLevel}(AI||(AI={})),function(n){""use strict"";var t=function(n){function t(){this.ver=2;this.properties={};n.call(this)}return __extends(t,n),t}(Microsoft.Telemetry.Domain);n.MessageData=t}(AI||(AI={})),function(n){var t;(function(n){var t;(function(t){var i;(function(t){""use strict"";var i=function(){function t(){}return t.sanitizeKeyAndAddUniqueness=function(n,i){var e=n.length,r=t.sanitizeKey(n),f,u;if(r.length!==e){for(f=0,u=r;i[u]!==undefined;)f++,u=r.substring(0,t.MAX_NAME_LENGTH-3)+t.padNumber(f);r=u}return r},t.sanitizeKey=function(i){return i&&(i=n.Util.trim(i.toString()),i.search(/[^0-9a-zA-Z-._()\/ ]/g)>=0&&(i=i.replace(/[^0-9a-zA-Z-._()\/ ]/g,""_""),n._InternalLogging.throwInternalUserActionable(n.LoggingSeverity.WARNING,new n._InternalLogMessage(n._InternalMessageId.USRACT_IllegalCharsInName,""name contains illegal characters. Illegal characters have been replaced with '_'."",{newName:i}))),i.length>t.MAX_NAME_LENGTH&&(i=i.substring(0,t.MAX_NAME_LENGTH),n._InternalLogging.throwInternalUserActionable(n.LoggingSeverity.WARNING,new n._InternalLogMessage(n._InternalMessageId.USRACT_NameTooLong,""name is too long.  It has been truncated to ""+t.MAX_NAME_LENGTH+"" characters."",{name:i})))),i},t.sanitizeString=function(i){return i&&(i=n.Util.trim(i),i.toString().length>t.MAX_STRING_LENGTH&&(i=i.toString().substring(0,t.MAX_STRING_LENGTH),n._InternalLogging.throwInternalUserActionable(n.LoggingSeverity.WARNING,new n._InternalLogMessage(n._InternalMessageId.USRACT_StringValueTooLong,""string value is too long. It has been truncated to ""+t.MAX_STRING_LENGTH+"" characters."",{value:i})))),i},t.sanitizeUrl=function(i){return i&&i.length>t.MAX_URL_LENGTH&&(i=i.substring(0,t.MAX_URL_LENGTH),n._InternalLogging.throwInternalUserActionable(n.LoggingSeverity.WARNING,new n._InternalLogMessage(n._InternalMessageId.USRACT_UrlTooLong,""url is too long, it has been trucated to ""+t.MAX_URL_LENGTH+"" characters."",{url:i}))),i},t.sanitizeMessage=function(i){return i&&i.length>t.MAX_MESSAGE_LENGTH&&(i=i.substring(0,t.MAX_MESSAGE_LENGTH),n._InternalLogging.throwInternalUserActionable(n.LoggingSeverity.WARNING,new n._InternalLogMessage(n._InternalMessageId.USRACT_MessageTruncated,""message is too long, it has been trucated to ""+t.MAX_MESSAGE_LENGTH+"" characters."",{message:i}))),i},t.sanitizeException=function(i){return i&&i.length>t.MAX_EXCEPTION_LENGTH&&(i=i.substring(0,t.MAX_EXCEPTION_LENGTH),n._InternalLogging.throwInternalUserActionable(n.LoggingSeverity.WARNING,new n._InternalLogMessage(n._InternalMessageId.USRACT_ExceptionTruncated,""exception is too long, it has been trucated to ""+t.MAX_EXCEPTION_LENGTH+"" characters."",{exception:i}))),i},t.sanitizeProperties=function(n){var r,i,u;if(n){r={};for(i in n)u=t.sanitizeString(n[i]),i=t.sanitizeKeyAndAddUniqueness(i,r),r[i]=u;n=r}return n},t.sanitizeMeasurements=function(n){var r,i,u;if(n){r={};for(i in n)u=n[i],i=t.sanitizeKeyAndAddUniqueness(i,r),r[i]=u;n=r}return n},t.padNumber=function(n){var t=""00""+n;return t.substr(t.length-3)},t.MAX_NAME_LENGTH=150,t.MAX_STRING_LENGTH=1024,t.MAX_URL_LENGTH=2048,t.MAX_MESSAGE_LENGTH=32768,t.MAX_EXCEPTION_LENGTH=32768,t}();t.DataSanitizer=i})(i=t.Common||(t.Common={}))})(t=n.Telemetry||(n.Telemetry={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){var t;(function(t){""use strict"";var i=function(i){function r(r,u){i.call(this);this.aiDataContract={ver:n.FieldType.Required,message:n.FieldType.Required,severityLevel:n.FieldType.Default,measurements:n.FieldType.Default,properties:n.FieldType.Default};r=r||n.Util.NotSpecified;this.message=t.Common.DataSanitizer.sanitizeMessage(r);this.properties=t.Common.DataSanitizer.sanitizeProperties(u)}return __extends(r,i),r.envelopeType=""Microsoft.ApplicationInsights.{0}.Message"",r.dataType=""MessageData"",r}(AI.MessageData);t.Trace=i})(t=n.Telemetry||(n.Telemetry={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){""use strict"";var t=function(n){function t(){this.ver=2;this.properties={};this.measurements={};n.call(this)}return __extends(t,n),t}(Microsoft.Telemetry.Domain);n.EventData=t}(AI||(AI={})),function(n){var t;(function(n){var t;(function(t){""use strict"";var i=function(t){function i(i,r,u){t.call(this);this.aiDataContract={ver:n.FieldType.Required,name:n.FieldType.Required,properties:n.FieldType.Default,measurements:n.FieldType.Default};this.name=n.Telemetry.Common.DataSanitizer.sanitizeString(i);this.properties=n.Telemetry.Common.DataSanitizer.sanitizeProperties(r);this.measurements=n.Telemetry.Common.DataSanitizer.sanitizeMeasurements(u)}return __extends(i,t),i.envelopeType=""Microsoft.ApplicationInsights.{0}.Event"",i.dataType=""EventData"",i}(AI.EventData);t.Event=i})(t=n.Telemetry||(n.Telemetry={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){""use strict"";var t=function(){function n(){this.hasFullStack=!0;this.parsedStack=[]}return n}();n.ExceptionDetails=t}(AI||(AI={})),function(n){""use strict"";var t=function(n){function t(){this.ver=2;this.exceptions=[];this.properties={};this.measurements={};n.call(this)}return __extends(t,n),t}(Microsoft.Telemetry.Domain);n.ExceptionData=t}(AI||(AI={})),function(n){""use strict"";var t=function(){function n(){}return n}();n.StackFrame=t}(AI||(AI={})),function(n){var t;(function(n){var t;(function(t){""use strict"";var u=function(t){function i(i,u,f,e){t.call(this);this.aiDataContract={ver:n.FieldType.Required,handledAt:n.FieldType.Required,exceptions:n.FieldType.Required,severityLevel:n.FieldType.Default,properties:n.FieldType.Default,measurements:n.FieldType.Default};this.properties=n.Telemetry.Common.DataSanitizer.sanitizeProperties(f);this.measurements=n.Telemetry.Common.DataSanitizer.sanitizeMeasurements(e);this.handledAt=u||""unhandled"";this.exceptions=[new r(i)]}return __extends(i,t),i.CreateSimpleException=function(n,t,i,r,u,f,e){return{handledAt:e||""unhandled"",exceptions:[{hasFullStack:!0,message:n,stack:u,typeName:t,parsedStack:[{level:0,assembly:i,fileName:r,line:f,method:""unknown""}]}]}},i.envelopeType=""Microsoft.ApplicationInsights.{0}.Exception"",i.dataType=""ExceptionData"",i}(AI.ExceptionData),r,i;t.Exception=u;r=function(r){function u(i){r.call(this);this.aiDataContract={id:n.FieldType.Default,outerId:n.FieldType.Default,typeName:n.FieldType.Required,message:n.FieldType.Required,hasFullStack:n.FieldType.Default,stack:n.FieldType.Default,parsedStack:n.FieldType.Array};this.typeName=t.Common.DataSanitizer.sanitizeString(i.name||n.Util.NotSpecified);this.message=t.Common.DataSanitizer.sanitizeMessage(i.message||n.Util.NotSpecified);var u=i.stack;this.parsedStack=this.parseStack(u);this.stack=t.Common.DataSanitizer.sanitizeException(u);this.hasFullStack=n.Util.isArray(this.parsedStack)&&this.parsedStack.length>0}return __extends(u,r),u.prototype.parseStack=function(n){var t=undefined,e,l,o,r,a,s,h,p,w,b;if(typeof n==""string""){for(e=n.split(""\n""),t=[],l=0,o=0,r=0;r<=e.length;r++)a=e[r],i.regex.test(a)&&(s=new i(e[r],l++),o+=s.sizeInBytes,t.push(s));if(h=32768,o>h)for(var u=0,f=t.length-1,v=0,c=u,y=f;u<f;){if(p=t[u].sizeInBytes,w=t[f].sizeInBytes,v+=p+w,v>h){b=y-c+1;t.splice(c,b);break}c=u;y=f;u++;f--}}return t},u}(AI.ExceptionDetails);i=function(t){function i(r,u){t.call(this);this.sizeInBytes=0;this.aiDataContract={level:n.FieldType.Required,method:n.FieldType.Required,assembly:n.FieldType.Default,fileName:n.FieldType.Default,line:n.FieldType.Default};this.level=u;this.method=""<no_method>"";this.assembly=n.Util.trim(r);var f=r.match(i.regex);f&&f.length>=5&&(this.method=n.Util.trim(f[2])||this.method,this.fileName=n.Util.trim(f[4]),this.line=parseInt(f[5])||0);this.sizeInBytes+=this.method.length;this.sizeInBytes+=this.fileName.length;this.sizeInBytes+=this.assembly.length;this.sizeInBytes+=i.baseSize;this.sizeInBytes+=this.level.toString().length;this.sizeInBytes+=this.line.toString().length}return __extends(i,t),i.regex=/^([\s]+at)?(.*?)(\@|\s\(|\s)([^\(\@\n]+):([0-9]+):([0-9]+)(\)?)$/,i.baseSize=58,i}(AI.StackFrame);t._StackFrame=i})(t=n.Telemetry||(n.Telemetry={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){""use strict"";var t=function(n){function t(){this.ver=2;this.metrics=[];this.properties={};n.call(this)}return __extends(t,n),t}(Microsoft.Telemetry.Domain);n.MetricData=t}(AI||(AI={})),function(n){""use strict"";(function(n){n[n.Measurement=0]=""Measurement"";n[n.Aggregation=1]=""Aggregation""})(n.DataPointType||(n.DataPointType={}));var t=n.DataPointType}(AI||(AI={})),function(n){""use strict"";var t=function(){function t(){this.kind=n.DataPointType.Measurement}return t}();n.DataPoint=t}(AI||(AI={})),function(n){var t;(function(n){var t;(function(t){var i;(function(t){""use strict"";var i=function(t){function i(){t.apply(this,arguments);this.aiDataContract={name:n.FieldType.Required,kind:n.FieldType.Default,value:n.FieldType.Required,count:n.FieldType.Default,min:n.FieldType.Default,max:n.FieldType.Default,stdDev:n.FieldType.Default}}return __extends(i,t),i}(AI.DataPoint);t.DataPoint=i})(i=t.Common||(t.Common={}))})(t=n.Telemetry||(n.Telemetry={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(t){var i;(function(i){""use strict"";var r=function(r){function u(u,f,e,o,s,h){r.call(this);this.aiDataContract={ver:t.FieldType.Required,metrics:t.FieldType.Required,properties:t.FieldType.Default};var c=new n.ApplicationInsights.Telemetry.Common.DataPoint;c.count=e>0?e:undefined;c.max=isNaN(s)||s===null?undefined:s;c.min=isNaN(o)||o===null?undefined:o;c.name=i.Common.DataSanitizer.sanitizeString(u);c.value=f;this.metrics=[c];this.properties=t.Telemetry.Common.DataSanitizer.sanitizeProperties(h)}return __extends(u,r),u.envelopeType=""Microsoft.ApplicationInsights.{0}.Metric"",u.dataType=""MetricData"",u}(AI.MetricData);i.Metric=r})(i=t.Telemetry||(t.Telemetry={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){""use strict"";var t=function(n){function t(){this.ver=2;this.properties={};this.measurements={};n.call(this)}return __extends(t,n),t}(n.EventData);n.PageViewData=t}(AI||(AI={})),function(n){var t;(function(n){var t;(function(t){""use strict"";var i=function(i){function r(r,u,f,e,o){i.call(this);this.aiDataContract={ver:n.FieldType.Required,name:n.FieldType.Default,url:n.FieldType.Default,duration:n.FieldType.Default,properties:n.FieldType.Default,measurements:n.FieldType.Default};this.url=t.Common.DataSanitizer.sanitizeUrl(u);this.name=t.Common.DataSanitizer.sanitizeString(r||n.Util.NotSpecified);isNaN(f)||(this.duration=n.Util.msToTimeSpan(f));this.properties=n.Telemetry.Common.DataSanitizer.sanitizeProperties(e);this.measurements=n.Telemetry.Common.DataSanitizer.sanitizeMeasurements(o)}return __extends(r,i),r.envelopeType=""Microsoft.ApplicationInsights.{0}.Pageview"",r.dataType=""PageviewData"",r}(AI.PageViewData);t.PageView=i})(t=n.Telemetry||(n.Telemetry={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){""use strict"";var t=function(n){function t(){this.ver=2;this.properties={};this.measurements={};n.call(this)}return __extends(t,n),t}(n.PageViewData);n.PageViewPerfData=t}(AI||(AI={})),function(n){var t;(function(n){var t;(function(t){""use strict"";var i=function(i){function r(u,f,e,o,s){var h;if(i.call(this),this.aiDataContract={ver:n.FieldType.Required,name:n.FieldType.Default,url:n.FieldType.Default,duration:n.FieldType.Default,perfTotal:n.FieldType.Default,networkConnect:n.FieldType.Default,sentRequest:n.FieldType.Default,receivedResponse:n.FieldType.Default,domProcessing:n.FieldType.Default,properties:n.FieldType.Default,measurements:n.FieldType.Default},this.isValid=!1,h=r.getPerformanceTiming(),h){var c=r.getDuration(h.navigationStart,h.loadEventEnd),l=r.getDuration(h.navigationStart,h.connectEnd),a=r.getDuration(h.requestStart,h.responseStart),v=r.getDuration(h.responseStart,h.responseEnd),y=r.getDuration(h.responseEnd,h.loadEventEnd);c==0?n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.WARNING,new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_ErrorPVCalc,""error calculating page view performance."",{total:c,network:l,request:a,response:v,dom:y})):c<Math.floor(l)+Math.floor(a)+Math.floor(v)+Math.floor(y)?n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.WARNING,new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_ClientPerformanceMathError,""client performance math error."",{total:c,network:l,request:a,response:v,dom:y})):(this.durationMs=c,this.perfTotal=this.duration=n.Util.msToTimeSpan(c),this.networkConnect=n.Util.msToTimeSpan(l),this.sentRequest=n.Util.msToTimeSpan(a),this.receivedResponse=n.Util.msToTimeSpan(v),this.domProcessing=n.Util.msToTimeSpan(y),this.isValid=!0)}this.url=t.Common.DataSanitizer.sanitizeUrl(f);this.name=t.Common.DataSanitizer.sanitizeString(u||n.Util.NotSpecified);this.properties=n.Telemetry.Common.DataSanitizer.sanitizeProperties(o);this.measurements=n.Telemetry.Common.DataSanitizer.sanitizeMeasurements(s)}return __extends(r,i),r.prototype.getIsValid=function(){return this.isValid},r.prototype.getDurationMs=function(){return this.durationMs},r.getPerformanceTiming=function(){return typeof window!=""undefined""&&window.performance&&window.performance.timing?window.performance.timing:null},r.isPerformanceTimingSupported=function(){return typeof window!=""undefined""&&window.performance&&window.performance.timing},r.isPerformanceTimingDataReady=function(){var n=window.performance.timing;return n.domainLookupStart>0&&n.navigationStart>0&&n.responseStart>0&&n.requestStart>0&&n.loadEventEnd>0&&n.responseEnd>0&&n.connectEnd>0&&n.domLoading>0},r.getDuration=function(n,t){var i=0;return isNaN(n)||isNaN(t)||(i=Math.max(t-n,0)),i},r.envelopeType=""Microsoft.ApplicationInsights.{0}.PageviewPerformance"",r.dataType=""PageviewPerformanceData"",r}(AI.PageViewPerfData);t.PageViewPerformance=i})(t=n.Telemetry||(n.Telemetry={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){""use strict"";var t=function(){function t(t){this._config=t;this._sender=new n.Sender(t);typeof window!=""undefined""&&(this._sessionManager=new n.Context._SessionManager(t),this.application=new n.Context.Application,this.device=new n.Context.Device,this.internal=new n.Context.Internal,this.location=new n.Context.Location,this.user=new n.Context.User(t),this.operation=new n.Context.Operation,this.session=new n.Context.Session,this.sample=new n.Context.Sample(t.sampleRate()))}return t.prototype.addTelemetryInitializer=function(n){this.telemetryInitializers=this.telemetryInitializers||[];this.telemetryInitializers.push(n)},t.prototype.track=function(t){return t?(t.name===n.Telemetry.PageView.envelopeType&&n._InternalLogging.resetInternalMessageCount(),this.session&&typeof this.session.id!=""string""&&this._sessionManager.update(),this._track(t)):n._InternalLogging.throwInternalUserActionable(n.LoggingSeverity.CRITICAL,new n._InternalLogMessage(n._InternalMessageId.USRACT_TrackArgumentsNotSpecified,""cannot call .track() with a null or undefined argument"")),t},t.prototype._track=function(t){var i,f,r,u,o;this.session&&(typeof this.session.id==""string""?this._applySessionContext(t,this.session):this._applySessionContext(t,this._sessionManager.automaticSession));this._applyApplicationContext(t,this.application);this._applyDeviceContext(t,this.device);this._applyInternalContext(t,this.internal);this._applyLocationContext(t,this.location);this._applySampleContext(t,this.sample);this._applyUserContext(t,this.user);this._applyOperationContext(t,this.operation);t.iKey=this._config.instrumentationKey();i=!1;try{for(this.telemetryInitializers=this.telemetryInitializers||[],f=this.telemetryInitializers.length,r=0;r<f;++r)if(u=this.telemetryInitializers[r],u&&u.apply(null,[t])===!1){i=!0;break}}catch(e){i=!0;n._InternalLogging.throwInternalUserActionable(n.LoggingSeverity.CRITICAL,new n._InternalLogMessage(n._InternalMessageId.USRACT_TelemetryInitializerFailed,""One of telemetry initializers failed, telemetry item will not be sent: ""+n.Util.getExceptionName(e),{exception:n.Util.dump(e)}))}return i||(t.name===n.Telemetry.Metric.envelopeType||this.sample.isSampledIn(t)?(o=this._config.instrumentationKey().replace(/-/g,""""),t.name=t.name.replace(""{0}"",o),this._sender.send(t)):n._InternalLogging.throwInternalUserActionable(n.LoggingSeverity.WARNING,new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_TelemetrySampledAndNotSent,""Telemetry is sampled and not sent to the AI service."",{SampleRate:this.sample.sampleRate}))),t},t.prototype._applyApplicationContext=function(n,t){if(t){var i=new AI.ContextTagKeys;typeof t.ver==""string""&&(n.tags[i.applicationVersion]=t.ver);typeof t.build==""string""&&(n.tags[i.applicationBuild]=t.build)}},t.prototype._applyDeviceContext=function(n,t){var i=new AI.ContextTagKeys;t&&(typeof t.id==""string""&&(n.tags[i.deviceId]=t.id),typeof t.ip==""string""&&(n.tags[i.deviceIp]=t.ip),typeof t.language==""string""&&(n.tags[i.deviceLanguage]=t.language),typeof t.locale==""string""&&(n.tags[i.deviceLocale]=t.locale),typeof t.model==""string""&&(n.tags[i.deviceModel]=t.model),typeof t.network!=""undefined""&&(n.tags[i.deviceNetwork]=t.network),typeof t.oemName==""string""&&(n.tags[i.deviceOEMName]=t.oemName),typeof t.os==""string""&&(n.tags[i.deviceOS]=t.os),typeof t.osversion==""string""&&(n.tags[i.deviceOSVersion]=t.osversion),typeof t.resolution==""string""&&(n.tags[i.deviceScreenResolution]=t.resolution),typeof t.type==""string""&&(n.tags[i.deviceType]=t.type))},t.prototype._applyInternalContext=function(n,t){if(t){var i=new AI.ContextTagKeys;typeof t.agentVersion==""string""&&(n.tags[i.internalAgentVersion]=t.agentVersion);typeof t.sdkVersion==""string""&&(n.tags[i.internalSdkVersion]=t.sdkVersion)}},t.prototype._applyLocationContext=function(n,t){if(t){var i=new AI.ContextTagKeys;typeof t.ip==""string""&&(n.tags[i.locationIp]=t.ip)}},t.prototype._applyOperationContext=function(n,t){if(t){var i=new AI.ContextTagKeys;typeof t.id==""string""&&(n.tags[i.operationId]=t.id);typeof t.name==""string""&&(n.tags[i.operationName]=t.name);typeof t.parentId==""string""&&(n.tags[i.operationParentId]=t.parentId);typeof t.rootId==""string""&&(n.tags[i.operationRootId]=t.rootId);typeof t.syntheticSource==""string""&&(n.tags[i.operationSyntheticSource]=t.syntheticSource)}},t.prototype._applySampleContext=function(n,t){t&&(n.sampleRate=t.sampleRate)},t.prototype._applySessionContext=function(n,t){if(t){var i=new AI.ContextTagKeys;typeof t.id==""string""&&(n.tags[i.sessionId]=t.id);typeof t.isFirst!=""undefined""&&(n.tags[i.sessionIsFirst]=t.isFirst)}},t.prototype._applyUserContext=function(n,t){if(t){var i=new AI.ContextTagKeys;typeof t.accountId==""string""&&(n.tags[i.userAccountId]=t.accountId);typeof t.agent==""string""&&(n.tags[i.userAgent]=t.agent);typeof t.id==""string""&&(n.tags[i.userId]=t.id);typeof t.authenticatedId==""string""&&(n.tags[i.userAuthUserId]=t.authenticatedId);typeof t.storeRegion==""string""&&(n.tags[i.userStoreRegion]=t.storeRegion)}},t}();n.TelemetryContext=t})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(t){""use strict"";var i=function(n){function t(){n.call(this)}return __extends(t,n),t}(n.Telemetry.Base);t.Data=i})(t=n.Telemetry||(n.Telemetry={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(t){var i;(function(i){var r;(function(i){""use strict"";var r=function(n){function i(i,r){n.call(this);this.aiDataContract={baseType:t.FieldType.Required,baseData:t.FieldType.Required};this.baseType=i;this.baseData=r}return __extends(i,n),i}(n.Telemetry.Data);i.Data=r})(r=i.Common||(i.Common={}))})(i=t.Telemetry||(t.Telemetry={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){var t;(function(t){""use strict"";var i=function(){function i(n,t){this.pageViewPerformanceSent=!1;this.overridePageViewDuration=!1;this.overridePageViewDuration=t;this.appInsights=n}return i.prototype.trackPageView=function(i,r,u,f,e){var o=this,s,h,c,l,a;if(typeof i!=""string""&&(i=window.document&&window.document.title||""""),typeof r!=""string""&&(r=window.location&&window.location.href||""""),s=!1,h=0,t.PageViewPerformance.isPerformanceTimingSupported()?(c=t.PageViewPerformance.getPerformanceTiming().navigationStart,h=t.PageViewPerformance.getDuration(c,+new Date)):(this.appInsights.sendPageViewInternal(i,r,isNaN(e)?0:e,u,f),this.appInsights.flush(),s=!0),(this.overridePageViewDuration||!isNaN(e))&&(this.appInsights.sendPageViewInternal(i,r,isNaN(e)?h:e,u,f),this.appInsights.flush(),s=!0),l=6e4,!t.PageViewPerformance.isPerformanceTimingSupported()){n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.WARNING,new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_NavigationTimingNotSupported,""trackPageView: navigation timing API used for calculation of page duration is not supported in this browser. This page view will be collected without duration and timing info.""));return}a=setInterval(function(){try{if(t.PageViewPerformance.isPerformanceTimingDataReady()){clearInterval(a);var e=new t.PageViewPerformance(i,r,null,u,f);e.getIsValid()||s?(s||o.appInsights.sendPageViewInternal(i,r,e.getDurationMs(),u,f),o.pageViewPerformanceSent||(o.appInsights.sendPageViewPerformanceInternal(e),o.pageViewPerformanceSent=!0),o.appInsights.flush()):(o.appInsights.sendPageViewInternal(i,r,h,u,f),o.appInsights.flush())}else t.PageViewPerformance.getDuration(c,+new Date)>l&&(clearInterval(a),s||(o.appInsights.sendPageViewInternal(i,r,l,u,f),o.appInsights.flush()))}catch(v){n._InternalLogging.throwInternalNonUserActionable(n.LoggingSeverity.CRITICAL,new n._InternalLogMessage(n._InternalMessageId.NONUSRACT_TrackPVFailedCalc,""trackPageView failed on page load calculation: ""+n.Util.getExceptionName(v),{exception:n.Util.dump(v)}))}},100)},i}();t.PageViewManager=i})(t=n.Telemetry||(n.Telemetry={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(n){var t;(function(t){""use strict"";var r=function(){function t(n){this.prevPageVisitDataKeyName=""prevPageVisitData"";this.pageVisitTimeTrackingHandler=n}return t.prototype.trackPreviousPageVisit=function(t,i){try{var r=this.restartPageVisitTimer(t,i);r&&this.pageVisitTimeTrackingHandler(r.pageName,r.pageUrl,r.pageVisitTime)}catch(u){n._InternalLogging.warnToConsole(""Auto track page visit time failed, metric will not be collected: ""+n.Util.dump(u))}},t.prototype.restartPageVisitTimer=function(t,i){try{var r=this.stopPageVisitTimer();return this.startPageVisitTimer(t,i),r}catch(u){return n._InternalLogging.warnToConsole(""Call to restart failed: ""+n.Util.dump(u)),null}},t.prototype.startPageVisitTimer=function(t,r){try{if(n.Util.canUseSessionStorage()){if(n.Util.getSessionStorage(this.prevPageVisitDataKeyName)!=null)throw new Error(""Cannot call startPageVisit consecutively without first calling stopPageVisit"");var u=new i(t,r),f=JSON.stringify(u);n.Util.setSessionStorage(this.prevPageVisitDataKeyName,f)}}catch(e){n._InternalLogging.warnToConsole(""Call to start failed: ""+n.Util.dump(e))}},t.prototype.stopPageVisitTimer=function(){var r,i,t;try{return n.Util.canUseSessionStorage()?(r=Date.now(),i=n.Util.getSessionStorage(this.prevPageVisitDataKeyName),i?(t=JSON.parse(i),t.pageVisitTime=r-t.pageVisitStartTime,n.Util.removeSessionStorage(this.prevPageVisitDataKeyName),t):null):null}catch(u){return n._InternalLogging.warnToConsole(""Stop page visit timer failed: ""+n.Util.dump(u)),null}},t}(),i;t.PageVisitTimeManager=r;i=function(){function n(n,t){this.pageVisitStartTime=Date.now();this.pageName=n;this.pageUrl=t}return n}();t.PageVisitData=i})(t=n.Telemetry||(n.Telemetry={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){""use strict"";(function(n){n[n.SQL=0]=""SQL"";n[n.Http=1]=""Http"";n[n.Other=2]=""Other""})(n.DependencyKind||(n.DependencyKind={}));var t=n.DependencyKind}(AI||(AI={})),function(n){""use strict"";(function(n){n[n.Undefined=0]=""Undefined"";n[n.Aic=1]=""Aic"";n[n.Apmc=2]=""Apmc""})(n.DependencySourceType||(n.DependencySourceType={}));var t=n.DependencySourceType}(AI||(AI={})),function(n){""use strict"";var t=function(t){function i(){this.ver=2;this.kind=n.DataPointType.Aggregation;this.dependencyKind=n.DependencyKind.Other;this.success=!0;this.dependencySource=n.DependencySourceType.Apmc;this.properties={};t.call(this)}return __extends(i,t),i}(Microsoft.Telemetry.Domain);n.RemoteDependencyData=t}(AI||(AI={})),function(n){var t;(function(n){var t;(function(t){""use strict"";var i=function(t){function i(i,r,u,f,e,o){t.call(this);this.aiDataContract={id:n.FieldType.Required,ver:n.FieldType.Required,name:n.FieldType.Default,kind:n.FieldType.Required,value:n.FieldType.Default,count:n.FieldType.Default,min:n.FieldType.Default,max:n.FieldType.Default,stdDev:n.FieldType.Default,dependencyKind:n.FieldType.Default,success:n.FieldType.Default,async:n.FieldType.Default,dependencySource:n.FieldType.Default,commandName:n.FieldType.Default,dependencyTypeName:n.FieldType.Default,properties:n.FieldType.Default,resultCode:n.FieldType.Default};this.id=i;this.name=r;this.commandName=u;this.value=f;this.success=e;this.resultCode=o+"""";this.dependencyKind=AI.DependencyKind.Http;this.dependencyTypeName=""Ajax""}return __extends(i,t),i.envelopeType=""Microsoft.ApplicationInsights.{0}.RemoteDependency"",i.dataType=""RemoteDependencyData"",i}(AI.RemoteDependencyData);t.RemoteDependencyData=i})(t=n.Telemetry||(n.Telemetry={}))})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(t){""use strict"";var r,i;t.Version=""0.22.9"";r=function(){function r(u){var f=this,e,o,s;if(this._trackAjaxAttempts=0,this.config=u||{},e=r.defaultConfig,e!==undefined)for(o in e)this.config[o]===undefined&&(this.config[o]=e[o]);t._InternalLogging.verboseLogging=function(){return f.config.verboseLogging};t._InternalLogging.enableDebugExceptions=function(){return f.config.enableDebug};s={instrumentationKey:function(){return f.config.instrumentationKey},accountId:function(){return f.config.accountId},sessionRenewalMs:function(){return f.config.sessionRenewalMs},sessionExpirationMs:function(){return f.config.sessionExpirationMs},endpointUrl:function(){return f.config.endpointUrl},emitLineDelimitedJson:function(){return f.config.emitLineDelimitedJson},maxBatchSizeInBytes:function(){return f.config.maxBatchSizeInBytes},maxBatchInterval:function(){return f.config.maxBatchInterval},disableTelemetry:function(){return f.config.disableTelemetry},sampleRate:function(){return f.config.samplingPercentage},cookieDomain:function(){return f.config.cookieDomain}};this.context=new t.TelemetryContext(s);this._pageViewManager=new n.ApplicationInsights.Telemetry.PageViewManager(this,this.config.overridePageViewDuration);this._eventTracking=new i(""trackEvent"");this._eventTracking.action=function(n,i,r,u,e){e?isNaN(e.duration)&&(e.duration=r):e={duration:r};var o=new t.Telemetry.Event(n,u,e),s=new t.Telemetry.Common.Data(t.Telemetry.Event.dataType,o),h=new t.Telemetry.Common.Envelope(s,t.Telemetry.Event.envelopeType);f.context.track(h)};this._pageTracking=new i(""trackPageView"");this._pageTracking.action=function(n,t,i,r,u){f.sendPageViewInternal(n,t,i,r,u)};this._pageVisitTimeManager=new t.Telemetry.PageVisitTimeManager(function(n,t,i){return f.trackPageVisitTime(n,t,i)});this.config.disableAjaxTracking||new n.ApplicationInsights.AjaxMonitor(this)}return r.prototype.sendPageViewInternal=function(n,i,r,u,f){var e=new t.Telemetry.PageView(n,i,r,u,f),o=new t.Telemetry.Common.Data(t.Telemetry.PageView.dataType,e),s=new t.Telemetry.Common.Envelope(o,t.Telemetry.PageView.envelopeType);this.context.track(s);this._trackAjaxAttempts=0},r.prototype.sendPageViewPerformanceInternal=function(n){var i=new t.Telemetry.Common.Data(t.Telemetry.PageViewPerformance.dataType,n),r=new t.Telemetry.Common.Envelope(i,t.Telemetry.PageViewPerformance.envelopeType);this.context.track(r)},r.prototype.startTrackPage=function(n){try{typeof n!=""string""&&(n=window.document&&window.document.title||"""");this._pageTracking.start(n)}catch(i){t._InternalLogging.throwInternalNonUserActionable(t.LoggingSeverity.CRITICAL,new t._InternalLogMessage(t._InternalMessageId.NONUSRACT_StartTrackFailed,""startTrackPage failed, page view may not be collected: ""+t.Util.getExceptionName(i),{exception:t.Util.dump(i)}))}},r.prototype.stopTrackPage=function(n,i,r,u){try{typeof n!=""string""&&(n=window.document&&window.document.title||"""");typeof i!=""string""&&(i=window.location&&window.location.href||"""");this._pageTracking.stop(n,i,r,u);this.config.autoTrackPageVisitTime&&this._pageVisitTimeManager.trackPreviousPageVisit(n,i)}catch(f){t._InternalLogging.throwInternalNonUserActionable(t.LoggingSeverity.CRITICAL,new t._InternalLogMessage(t._InternalMessageId.NONUSRACT_StopTrackFailed,""stopTrackPage failed, page view will not be collected: ""+t.Util.getExceptionName(f),{exception:t.Util.dump(f)}))}},r.prototype.trackPageView=function(n,i,r,u,f){try{this._pageViewManager.trackPageView(n,i,r,u,f);this.config.autoTrackPageVisitTime&&this._pageVisitTimeManager.trackPreviousPageVisit(n,i)}catch(e){t._InternalLogging.throwInternalNonUserActionable(t.LoggingSeverity.CRITICAL,new t._InternalLogMessage(t._InternalMessageId.NONUSRACT_TrackPVFailed,""trackPageView failed, page view will not be collected: ""+t.Util.getExceptionName(e),{exception:t.Util.dump(e)}))}},r.prototype.startTrackEvent=function(n){try{this._eventTracking.start(n)}catch(i){t._InternalLogging.throwInternalNonUserActionable(t.LoggingSeverity.CRITICAL,new t._InternalLogMessage(t._InternalMessageId.NONUSRACT_StartTrackEventFailed,""startTrackEvent failed, event will not be collected: ""+t.Util.getExceptionName(i),{exception:t.Util.dump(i)}))}},r.prototype.stopTrackEvent=function(n,i,r){try{this._eventTracking.stop(n,undefined,i,r)}catch(u){t._InternalLogging.throwInternalNonUserActionable(t.LoggingSeverity.CRITICAL,new t._InternalLogMessage(t._InternalMessageId.NONUSRACT_StopTrackEventFailed,""stopTrackEvent failed, event will not be collected: ""+t.Util.getExceptionName(u),{exception:t.Util.dump(u)}))}},r.prototype.trackEvent=function(n,i,r){try{var f=new t.Telemetry.Event(n,i,r),e=new t.Telemetry.Common.Data(t.Telemetry.Event.dataType,f),o=new t.Telemetry.Common.Envelope(e,t.Telemetry.Event.envelopeType);this.context.track(o)}catch(u){t._InternalLogging.throwInternalNonUserActionable(t.LoggingSeverity.CRITICAL,new t._InternalLogMessage(t._InternalMessageId.NONUSRACT_TrackEventFailed,""trackEvent failed, event will not be collected: ""+t.Util.getExceptionName(u),{exception:t.Util.dump(u)}))}},r.prototype.trackAjax=function(n,i,r,u,f,e){if(this.config.maxAjaxCallsPerView===-1||this._trackAjaxAttempts<this.config.maxAjaxCallsPerView){var o=new t.Telemetry.RemoteDependencyData(n,i,r,u,f,e),s=new t.Telemetry.Common.Data(t.Telemetry.RemoteDependencyData.dataType,o),h=new t.Telemetry.Common.Envelope(s,t.Telemetry.RemoteDependencyData.envelopeType);this.context.track(h)}else this._trackAjaxAttempts===this.config.maxAjaxCallsPerView&&t._InternalLogging.throwInternalUserActionable(t.LoggingSeverity.CRITICAL,new t._InternalLogMessage(t._InternalMessageId.USRACT_MaxAjaxPerPVExceeded,""Maximum ajax per page view limit reached, ajax monitoring is paused until the next trackPageView(). In order to increase the limit set the maxAjaxCallsPerView configuration parameter.""));++this._trackAjaxAttempts},r.prototype.trackException=function(n,i,r,u){try{if(!t.Util.isError(n))try{throw new Error(n);}catch(e){n=e}var o=new t.Telemetry.Exception(n,i,r,u),s=new t.Telemetry.Common.Data(t.Telemetry.Exception.dataType,o),h=new t.Telemetry.Common.Envelope(s,t.Telemetry.Exception.envelopeType);this.context.track(h)}catch(f){t._InternalLogging.throwInternalNonUserActionable(t.LoggingSeverity.CRITICAL,new t._InternalLogMessage(t._InternalMessageId.NONUSRACT_TrackExceptionFailed,""trackException failed, exception will not be collected: ""+t.Util.getExceptionName(f),{exception:t.Util.dump(f)}))}},r.prototype.trackMetric=function(n,i,r,u,f,e){try{var s=new t.Telemetry.Metric(n,i,r,u,f,e),h=new t.Telemetry.Common.Data(t.Telemetry.Metric.dataType,s),c=new t.Telemetry.Common.Envelope(h,t.Telemetry.Metric.envelopeType);this.context.track(c)}catch(o){t._InternalLogging.throwInternalNonUserActionable(t.LoggingSeverity.CRITICAL,new t._InternalLogMessage(t._InternalMessageId.NONUSRACT_TrackMetricFailed,""trackMetric failed, metric will not be collected: ""+t.Util.getExceptionName(o),{exception:t.Util.dump(o)}))}},r.prototype.trackTrace=function(n,i){try{var u=new t.Telemetry.Trace(n,i),f=new t.Telemetry.Common.Data(t.Telemetry.Trace.dataType,u),e=new t.Telemetry.Common.Envelope(f,t.Telemetry.Trace.envelopeType);this.context.track(e)}catch(r){t._InternalLogging.throwInternalNonUserActionable(t.LoggingSeverity.WARNING,new t._InternalLogMessage(t._InternalMessageId.NONUSRACT_TrackTraceFailed,""trackTrace failed, trace will not be collected: ""+t.Util.getExceptionName(r),{exception:t.Util.dump(r)}))}},r.prototype.trackPageVisitTime=function(n,t,i){var r={PageName:n,PageUrl:t};this.trackMetric(""PageVisitTime"",i,1,i,i,r)},r.prototype.flush=function(){try{this.context._sender.triggerSend()}catch(n){t._InternalLogging.throwInternalNonUserActionable(t.LoggingSeverity.CRITICAL,new t._InternalLogMessage(t._InternalMessageId.NONUSRACT_FlushFailed,""flush failed, telemetry will not be collected: ""+t.Util.getExceptionName(n),{exception:t.Util.dump(n)}))}},r.prototype.setAuthenticatedUserContext=function(n,i){try{this.context.user.setAuthenticatedUserContext(n,i)}catch(r){t._InternalLogging.throwInternalUserActionable(t.LoggingSeverity.WARNING,new t._InternalLogMessage(t._InternalMessageId.USRACT_SetAuthContextFailed,""Setting auth user context failed. ""+t.Util.getExceptionName(r),{exception:t.Util.dump(r)}))}},r.prototype.clearAuthenticatedUserContext=function(){try{this.context.user.clearAuthenticatedUserContext()}catch(n){t._InternalLogging.throwInternalUserActionable(t.LoggingSeverity.WARNING,new t._InternalLogMessage(t._InternalMessageId.USRACT_SetAuthContextFailed,""Clearing auth user context failed. ""+t.Util.getExceptionName(n),{exception:t.Util.dump(n)}))}},r.prototype.SendCORSException=function(i){var r=n.ApplicationInsights.Telemetry.Exception.CreateSimpleException(""Script error."",""Error"",""unknown"",""unknown"",""The browser’s same-origin policy prevents us from getting the details of this exception.The exception occurred in a script loaded from an origin different than the web page.For cross- domain error reporting you can use crossorigin attribute together with appropriate CORS HTTP headers.For more information please see http://www.w3.org/TR/cors/."",0,null),u,f;r.properties=i;u=new t.Telemetry.Common.Data(t.Telemetry.Exception.dataType,r);f=new t.Telemetry.Common.Envelope(u,t.Telemetry.Exception.envelopeType);this.context.track(f)},r.prototype._onerror=function(n,i,r,u,f){var e,o,h,c;try{e={url:i?i:document.URL};t.Util.isCrossOriginError(n,i,r,u,f)?this.SendCORSException(e):(t.Util.isError(f)||(o=""window.onerror@""+e.url+"":""+r+"":""+(u||0),f=new Error(n),f.stack=o),this.trackException(f,null,e))}catch(s){h=f?f.name+"", ""+f.message:""null"";c=t.Util.dump(s);t._InternalLogging.throwInternalNonUserActionable(t.LoggingSeverity.CRITICAL,new t._InternalLogMessage(t._InternalMessageId.NONUSRACT_ExceptionWhileLoggingError,""_onerror threw exception while logging error, error will not be collected: ""+t.Util.getExceptionName(s),{exception:c,errorString:h}))}},r}();t.AppInsights=r;i=function(){function n(n){this._name=n;this._events={}}return n.prototype.start=function(n){typeof this._events[n]!=""undefined""&&t._InternalLogging.throwInternalUserActionable(t.LoggingSeverity.WARNING,new t._InternalLogMessage(t._InternalMessageId.USRACT_StartCalledMoreThanOnce,""start was called more than once for this event without calling stop."",{name:this._name,key:n}));this._events[n]=+new Date},n.prototype.stop=function(n,i,r,u){var f=this._events[n],e,o;isNaN(f)?t._InternalLogging.throwInternalUserActionable(t.LoggingSeverity.WARNING,new t._InternalLogMessage(t._InternalMessageId.USRACT_StopCalledWithoutStart,""stop was called without a corresponding start."",{name:this._name,key:n})):(e=+new Date,o=t.Telemetry.PageViewPerformance.getDuration(f,e),this.action(n,i,o,r,u));delete this._events[n];this._events[n]=undefined},n}()})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){""use strict"";var t=function(n){function t(){this.ver=2;this.properties={};this.measurements={};n.call(this)}return __extends(t,n),t}(n.PageViewData);n.AjaxCallData=t}(AI||(AI={})),function(n){""use strict"";var t=function(n){function t(){this.ver=2;this.properties={};this.measurements={};n.call(this)}return __extends(t,n),t}(Microsoft.Telemetry.Domain);n.RequestData=t}(AI||(AI={})),function(n){""use strict"";var t=function(t){function i(){this.ver=2;this.state=n.SessionState.Start;t.call(this)}return __extends(i,t),i}(Microsoft.Telemetry.Domain);n.SessionStateData=t}(AI||(AI={})),function(n){var t;(function(t){""use strict"";var i=function(){function i(t){t.queue=t.queue||[];var r=t.config||{};if(r&&!r.instrumentationKey)if(r=t,r.iKey)n.ApplicationInsights.Version=""0.10.0.0"",r.instrumentationKey=r.iKey;else if(r.applicationInsightsId)n.ApplicationInsights.Version=""0.7.2.0"",r.instrumentationKey=r.applicationInsightsId;else throw new Error(""Cannot load Application Insights SDK, no instrumentationKey was provided."");r=i.getDefaultConfig(r);this.snippet=t;this.config=r}return i.prototype.loadAppInsights=function(){var t=new n.ApplicationInsights.AppInsights(this.config),u,i,r;return this.config.iKey&&(u=t.trackPageView,t.trackPageView=function(n,i,r){u.apply(t,[null,n,i,r])}),i=""logPageView"",typeof this.snippet[i]==""function""&&(t[i]=function(n,i,r){t.trackPageView(null,n,i,r)}),r=""logEvent"",typeof this.snippet[r]==""function""&&(t[r]=function(n,i,r){t.trackEvent(n,i,r)}),t},i.prototype.emptyQueue=function(){var f,i,e,u,o;try{if(n.ApplicationInsights.Util.isArray(this.snippet.queue)){for(f=this.snippet.queue.length,i=0;i<f;i++)e=this.snippet.queue[i],e();this.snippet.queue=undefined;delete this.snippet.queue}}catch(r){u={};r&&typeof r.toString==""function""&&(u.exception=r.toString());o=new t._InternalLogMessage(t._InternalMessageId.NONUSRACT_FailedToSendQueuedTelemetry,""Failed to send queued telemetry"",u);n.ApplicationInsights._InternalLogging.throwInternalNonUserActionable(t.LoggingSeverity.WARNING,o)}},i.prototype.pollInteralLogs=function(t){return setInterval(function(){for(var i=n.ApplicationInsights._InternalLogging.queue,u=i.length,r=0;r<u;r++)t.trackTrace(i[r].message);i.length=0},this.config.diagnosticLogInterval)},i.prototype.addHousekeepingBeforeUnload=function(i){if(!i.config.disableFlushOnBeforeUnload&&""onbeforeunload""in window){var r=function(){i.context._sender.triggerSend();i.context._sessionManager.backup()};n.ApplicationInsights.Util.addEventHandler(""beforeunload"",r)||n.ApplicationInsights._InternalLogging.throwInternalNonUserActionable(n.ApplicationInsights.LoggingSeverity.CRITICAL,new t._InternalLogMessage(t._InternalMessageId.NONUSRACT_FailedToAddHandlerForOnBeforeUnload,""Could not add handler for beforeunload""))}},i.getDefaultConfig=function(n){return n||(n={}),n.endpointUrl=n.endpointUrl||""//dc.services.visualstudio.com/v2/track"",n.sessionRenewalMs=18e5,n.sessionExpirationMs=864e5,n.maxBatchSizeInBytes=n.maxBatchSizeInBytes>0?n.maxBatchSizeInBytes:1e6,n.maxBatchInterval=isNaN(n.maxBatchInterval)?15e3:n.maxBatchInterval,n.enableDebug=t.Util.stringToBoolOrDefault(n.enableDebug),n.disableExceptionTracking=n.disableExceptionTracking!==undefined&&n.disableExceptionTracking!==null?t.Util.stringToBoolOrDefault(n.disableExceptionTracking):!1,n.disableTelemetry=t.Util.stringToBoolOrDefault(n.disableTelemetry),n.verboseLogging=t.Util.stringToBoolOrDefault(n.verboseLogging),n.emitLineDelimitedJson=t.Util.stringToBoolOrDefault(n.emitLineDelimitedJson),n.diagnosticLogInterval=n.diagnosticLogInterval||1e4,n.autoTrackPageVisitTime=t.Util.stringToBoolOrDefault(n.autoTrackPageVisitTime),(isNaN(n.samplingPercentage)||n.samplingPercentage<=0||n.samplingPercentage>=100)&&(n.samplingPercentage=100),n.disableAjaxTracking=n.disableAjaxTracking!==undefined&&n.disableAjaxTracking!==null?t.Util.stringToBoolOrDefault(n.disableAjaxTracking):!1,n.maxAjaxCallsPerView=isNaN(n.maxAjaxCallsPerView)?500:n.maxAjaxCallsPerView,n.disableCorrelationHeaders=n.disableCorrelationHeaders!==undefined&&n.disableCorrelationHeaders!==null?t.Util.stringToBoolOrDefault(n.disableCorrelationHeaders):!0,n.disableFlushOnBeforeUnload=n.disableFlushOnBeforeUnload!==undefined&&n.disableFlushOnBeforeUnload!==null?t.Util.stringToBoolOrDefault(n.disableFlushOnBeforeUnload):!1,n},i}();t.Initialization=i})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={})),function(n){var t;(function(){""use strict"";var r,u;try{if(typeof window!=""undefined""&&typeof JSON!=""undefined"")if(r=""appInsights"",window[r]===undefined)n.ApplicationInsights.AppInsights.defaultConfig=n.ApplicationInsights.Initialization.getDefaultConfig();else{var f=window[r]||{},t=new n.ApplicationInsights.Initialization(f),i=t.loadAppInsights();for(u in i)f[u]=i[u];t.emptyQueue();t.pollInteralLogs(i);t.addHousekeepingBeforeUnload(i)}}catch(e){n.ApplicationInsights._InternalLogging.warnToConsole(""Failed to initialize AppInsights JS SDK: ""+e.message)}})(t=n.ApplicationInsights||(n.ApplicationInsights={}))}(Microsoft||(Microsoft={}))";
        public static string applicationInsightsConfigFileContent = @"<?xml version=""1.0"" encoding=""utf-8""?>
<ApplicationInsights xmlns=""http://schemas.microsoft.com/ApplicationInsights/2013/Settings"">
	<TelemetryModules>
		<Add Type=""Microsoft.ApplicationInsights.DependencyCollector.DependencyTrackingTelemetryModule, Microsoft.AI.DependencyCollector""/>
		<Add Type=""Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.PerformanceCollectorModule, Microsoft.AI.PerfCounterCollector"">
			<!--
      Use the following syntax here to collect additional performance counters:
      
      <Counters>
        <Add PerformanceCounter=""\Process(??APP_WIN32_PROC??)\Handle Count"" ReportAs=""Process handle count"" />
        ...
      </Counters>
      
      PerformanceCounter must be either \CategoryName(InstanceName)\CounterName or \CategoryName\CounterName
      
      Counter names may only contain letters, round brackets, forward slashes, hyphens, underscores, spaces and dots.
      You may provide an optional ReportAs attribute which will be used as the metric name when reporting counter data.
      For the purposes of reporting, metric names will be sanitized by removing all invalid characters from the resulting metric name.
      
      NOTE: performance counters configuration will be lost upon NuGet upgrade.
      
      The following placeholders are supported as InstanceName:
        ??APP_WIN32_PROC?? - instance name of the application process  for Win32 counters.
        ??APP_W3SVC_PROC?? - instance name of the application IIS worker process for IIS/ASP.NET counters.
        ??APP_CLR_PROC?? - instance name of the application CLR process for .NET counters.
      -->
		</Add>
		<Add Type=""Microsoft.ApplicationInsights.WindowsServer.DeveloperModeWithDebuggerAttachedTelemetryModule, Microsoft.AI.WindowsServer""/>
		<Add Type=""Microsoft.ApplicationInsights.WindowsServer.UnhandledExceptionTelemetryModule, Microsoft.AI.WindowsServer""/>
		<Add Type=""Microsoft.ApplicationInsights.WindowsServer.UnobservedExceptionTelemetryModule, Microsoft.AI.WindowsServer""/>
		<Add Type=""Microsoft.ApplicationInsights.Web.RequestTrackingTelemetryModule, Microsoft.AI.Web"">
			<Handlers>
				<!-- 
        Add entries here to filter out additional handlers: 
        
        NOTE: handler configuration will be lost upon NuGet upgrade.
        -->
				<Add>System.Web.Handlers.TransferRequestHandler</Add>
				<Add>Microsoft.VisualStudio.Web.PageInspector.Runtime.Tracing.RequestDataHttpHandler</Add>
				<Add>System.Web.StaticFileHandler</Add>
				<Add>System.Web.Handlers.AssemblyResourceLoader</Add>
				<Add>System.Web.Optimization.BundleHandler</Add>
				<Add>System.Web.Script.Services.ScriptHandlerFactory</Add>
				<Add>System.Web.Handlers.TraceHandler</Add>
				<Add>System.Web.Services.Discovery.DiscoveryRequestHandler</Add>
				<Add>System.Web.HttpDebugHandler</Add>
			</Handlers>
		</Add>
		<Add Type=""Microsoft.ApplicationInsights.Web.ExceptionTrackingTelemetryModule, Microsoft.AI.Web""/>
	</TelemetryModules>
	<TelemetryChannel Type=""Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel.ServerTelemetryChannel, Microsoft.AI.ServerTelemetryChannel""/>
	<TelemetryProcessors>
		<Add Type=""Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel.AdaptiveSamplingTelemetryProcessor, Microsoft.AI.ServerTelemetryChannel"">
			<MaxTelemetryItemsPerSecond>5</MaxTelemetryItemsPerSecond>
		</Add>
	</TelemetryProcessors>
<!-- 
    Learn more about Application Insights configuration with ApplicationInsights.config here: 
    http://go.microsoft.com/fwlink/?LinkID=513840
    
    Note: If not present, please add <InstrumentationKey>Your Key</InstrumentationKey> to the top of this file.
  -->
<TelemetryInitializers>
<Add Type=""Microsoft.ApplicationInsights.WindowsServer.AzureRoleEnvironmentTelemetryInitializer, Microsoft.AI.WindowsServer""/>
<Add Type=""Microsoft.ApplicationInsights.WindowsServer.DomainNameRoleInstanceTelemetryInitializer, Microsoft.AI.WindowsServer""/>
<Add Type=""Microsoft.ApplicationInsights.WindowsServer.BuildInfoConfigComponentVersionTelemetryInitializer, Microsoft.AI.WindowsServer""/>
<Add Type=""Microsoft.ApplicationInsights.Web.WebTestTelemetryInitializer, Microsoft.AI.Web""/>
<Add Type=""Microsoft.ApplicationInsights.Web.SyntheticUserAgentTelemetryInitializer, Microsoft.AI.Web"">
<Filters>
<Add Pattern=""(YottaaMonitor|BrowserMob|HttpMonitor|YandexBot|BingPreview|PagePeeker|ThumbShotsBot|WebThumb|URL2PNG|ZooShot|GomezA|Catchpoint bot|Willow Internet Crawler|Google SketchUp|Read%20Later|KTXN|Pingdom|AlwaysOn)""/>
<Add Pattern=""Slurp"" SourceName=""Yahoo Bot""/>
<Add Pattern=""(bot|zao|borg|Bot|oegp|silk|Xenu|zeal|^NING|crawl|Crawl|htdig|lycos|slurp|teoma|voila|yahoo|Sogou|CiBra|Nutch|^Java/|^JNLP/|Daumoa|Genieo|ichiro|larbin|pompos|Scrapy|snappy|speedy|spider|Spider|vortex|favicon|indexer|Riddler|scooter|scraper|scrubby|WhatWeb|WinHTTP|^voyager|archiver|Icarus6j|mogimogi|Netvibes|altavista|charlotte|findlinks|Retreiver|TLSProber|WordPress|wsr\-agent|Squrl Java|A6\-Indexer|netresearch|searchsight|http%20client|Python-urllib|dataparksearch|Screaming Frog|AppEngine-Google|YahooCacheSystem|semanticdiscovery|facebookexternalhit|Google.*/\+/web/snippet|Google-HTTP-Java-Client)""
SourceName=""Spider""/>
</Filters>
</Add>
<Add Type=""Microsoft.ApplicationInsights.Web.ClientIpHeaderTelemetryInitializer, Microsoft.AI.Web""/>
<Add Type=""Microsoft.ApplicationInsights.Web.OperationNameTelemetryInitializer, Microsoft.AI.Web""/>
<Add Type=""Microsoft.ApplicationInsights.Web.OperationCorrelationTelemetryInitializer, Microsoft.AI.Web""/>
<Add Type=""Microsoft.ApplicationInsights.Web.UserTelemetryInitializer, Microsoft.AI.Web""/>
<Add Type=""Microsoft.ApplicationInsights.Web.AuthenticatedUserIdTelemetryInitializer, Microsoft.AI.Web""/>
<Add Type=""Microsoft.ApplicationInsights.Web.AccountIdTelemetryInitializer, Microsoft.AI.Web""/>
<Add Type=""Microsoft.ApplicationInsights.Web.SessionTelemetryInitializer, Microsoft.AI.Web""/>
</TelemetryInitializers>
</ApplicationInsights>
";
        public static string globalAsaxFileContent = @"<%@ Application Codebehind=""Global.asax.cs"" Inherits=""{0}.WebApiApplication"" Language=""C#"" %>";
        public static string globalAsaxCSFileContent = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace {0}
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}


";
        public static string packagesConfigFileContent = @"<?xml version=""1.0"" encoding=""utf-8""?>
<packages>
  <package id=""EntityFramework"" version=""6.1.3"" targetFramework=""net452"" />
  <package id=""Microsoft.ApplicationInsights"" version=""2.0.0"" targetFramework=""net452"" />
  <package id=""Microsoft.ApplicationInsights.Agent.Intercept"" version=""1.2.1"" targetFramework=""net452"" />
  <package id=""Microsoft.ApplicationInsights.DependencyCollector"" version=""2.0.0"" targetFramework=""net452"" />
  <package id=""Microsoft.ApplicationInsights.JavaScript"" version=""0.22.9-build00167"" targetFramework=""net452"" />
  <package id=""Microsoft.ApplicationInsights.PerfCounterCollector"" version=""2.0.0"" targetFramework=""net452"" />
  <package id=""Microsoft.ApplicationInsights.Web"" version=""2.0.0"" targetFramework=""net452"" />
  <package id=""Microsoft.ApplicationInsights.WindowsServer"" version=""2.0.0"" targetFramework=""net452"" />
  <package id=""Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel"" version=""2.0.0"" targetFramework=""net452"" />
  <package id=""Microsoft.AspNet.OData"" version=""5.9.0"" targetFramework=""net452"" />
  <package id=""Microsoft.AspNet.WebApi"" version=""5.2.3"" targetFramework=""net452"" />
  <package id=""Microsoft.AspNet.WebApi.Client"" version=""5.2.3"" targetFramework=""net452"" />
  <package id=""Microsoft.AspNet.WebApi.Core"" version=""5.2.3"" targetFramework=""net452"" />
  <package id=""Microsoft.AspNet.WebApi.WebHost"" version=""5.2.3"" targetFramework=""net452"" />
  <package id=""Microsoft.CodeDom.Providers.DotNetCompilerPlatform"" version=""1.0.0"" targetFramework=""net452"" />
  <package id=""Microsoft.Extensions.DependencyInjection"" version=""1.0.0-rc2-final"" targetFramework=""net452"" />
  <package id=""Microsoft.Extensions.DependencyInjection.Abstractions"" version=""1.0.0-rc2-final"" targetFramework=""net452"" />
  <package id=""Microsoft.Net.Compilers"" version=""1.0.0"" targetFramework=""net452"" developmentDependency=""true"" />
  <package id=""Microsoft.OData.Core"" version=""6.15.0"" targetFramework=""net452"" />
  <package id=""Microsoft.OData.Edm"" version=""6.15.0"" targetFramework=""net452"" />
  <package id=""Microsoft.Restier"" version=""0.5.0-beta"" targetFramework=""net452"" />
  <package id=""Microsoft.Restier.Core"" version=""0.5.0-beta"" targetFramework=""net452"" />
  <package id=""Microsoft.Restier.Providers.EntityFramework"" version=""0.5.0-beta"" targetFramework=""net452"" />
  <package id=""Microsoft.Restier.Publishers.OData"" version=""0.5.0-beta"" targetFramework=""net452"" />
  <package id=""Microsoft.Spatial"" version=""6.15.0"" targetFramework=""net452"" />
  <package id=""Newtonsoft.Json"" version=""6.0.4"" targetFramework=""net452"" />
  <package id=""System.Collections"" version=""4.0.11-rc2-24027"" targetFramework=""net452"" />
  <package id=""System.Collections.Concurrent"" version=""4.0.12-rc2-24027"" targetFramework=""net452"" />
  <package id=""System.ComponentModel"" version=""4.0.1-rc2-24027"" targetFramework=""net452"" />
  <package id=""System.Diagnostics.Debug"" version=""4.0.11-rc2-24027"" targetFramework=""net452"" />
  <package id=""System.Globalization"" version=""4.0.11-rc2-24027"" targetFramework=""net452"" />
  <package id=""System.Linq"" version=""4.1.0-rc2-24027"" targetFramework=""net452"" />
  <package id=""System.Linq.Expressions"" version=""4.0.11-rc2-24027"" targetFramework=""net452"" />
  <package id=""System.Reflection"" version=""4.1.0-rc2-24027"" targetFramework=""net452"" />
  <package id=""System.Resources.ResourceManager"" version=""4.0.1-rc2-24027"" targetFramework=""net452"" />
  <package id=""System.Runtime.Extensions"" version=""4.1.0-rc2-24027"" targetFramework=""net452"" />
  <package id=""System.Threading"" version=""4.0.11-rc2-24027"" targetFramework=""net452"" />
  <package id=""System.Threading.Tasks"" version=""4.0.11-rc2-24027"" targetFramework=""net452"" />
</packages>
";
        public static string CSPROJFileContent = @"<?xml version=""1.0"" encoding=""utf-8""?>
<Project ToolsVersion=""12.0"" DefaultTargets=""Build"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">
  <Import Project=""..\packages\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.1.0.0\build\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.props"" Condition=""Exists('..\packages\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.1.0.0\build\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.props')"" />
  <Import Project=""..\packages\Microsoft.Net.Compilers.1.0.0\build\Microsoft.Net.Compilers.props"" Condition=""Exists('..\packages\Microsoft.Net.Compilers.1.0.0\build\Microsoft.Net.Compilers.props')"" />
  <Import Project=""$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props"" Condition=""Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')"" />
  <PropertyGroup>
    <Configuration Condition="" '$(Configuration)' == '' "">Debug</Configuration>
    <Platform Condition="" '$(Platform)' == '' "">AnyCPU</Platform>
    <ProductVersion>
    </ProductVersion>
    <SchemaVersion>2.0</SchemaVersion>
    <ProjectGuid>{B07B6E14-B039-49B9-8C8C-3F63F3A7F0AE}</ProjectGuid>
    <ProjectTypeGuids>{349c5851-65df-11da-9384-00065b846f21};{fae04ec0-301f-11d3-bf4b-00c04f79efbc}</ProjectTypeGuids>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>{0}</RootNamespace>
    <AssemblyName>{0}</AssemblyName>
    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>
    <UseIISExpress>true</UseIISExpress>
    <IISExpressSSLPort />
    <IISExpressAnonymousAuthentication />
    <IISExpressWindowsAuthentication />
    <IISExpressUseClassicPipelineMode />
    <UseGlobalApplicationHostFile />
    <NuGetPackageImportStamp>
    </NuGetPackageImportStamp>
  </PropertyGroup>
  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' "">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' "">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include=""EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089, processorArchitecture=MSIL"">
      <HintPath>..\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""EntityFramework.SqlServer, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089, processorArchitecture=MSIL"">
      <HintPath>..\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.SqlServer.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""Microsoft.AI.Agent.Intercept, Version=1.2.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL"">
      <HintPath>..\packages\Microsoft.ApplicationInsights.Agent.Intercept.1.2.1\lib\net45\Microsoft.AI.Agent.Intercept.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""Microsoft.AI.DependencyCollector, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL"">
      <HintPath>..\packages\Microsoft.ApplicationInsights.DependencyCollector.2.0.0\lib\net45\Microsoft.AI.DependencyCollector.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""Microsoft.AI.PerfCounterCollector, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL"">
      <HintPath>..\packages\Microsoft.ApplicationInsights.PerfCounterCollector.2.0.0\lib\net45\Microsoft.AI.PerfCounterCollector.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""Microsoft.AI.ServerTelemetryChannel, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL"">
      <HintPath>..\packages\Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel.2.0.0\lib\net45\Microsoft.AI.ServerTelemetryChannel.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""Microsoft.AI.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL"">
      <HintPath>..\packages\Microsoft.ApplicationInsights.Web.2.0.0\lib\net45\Microsoft.AI.Web.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""Microsoft.AI.WindowsServer, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL"">
      <HintPath>..\packages\Microsoft.ApplicationInsights.WindowsServer.2.0.0\lib\net45\Microsoft.AI.WindowsServer.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""Microsoft.ApplicationInsights, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL"">
      <HintPath>..\packages\Microsoft.ApplicationInsights.2.0.0\lib\net45\Microsoft.ApplicationInsights.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL"">
      <HintPath>..\packages\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.1.0.0\lib\net45\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""Microsoft.CSharp"" />
    <Reference Include=""Microsoft.Extensions.DependencyInjection, Version=1.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60, processorArchitecture=MSIL"">
      <HintPath>..\packages\Microsoft.Extensions.DependencyInjection.1.0.0-rc2-final\lib\netstandard1.1\Microsoft.Extensions.DependencyInjection.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""Microsoft.Extensions.DependencyInjection.Abstractions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60, processorArchitecture=MSIL"">
      <HintPath>..\packages\Microsoft.Extensions.DependencyInjection.Abstractions.1.0.0-rc2-final\lib\netstandard1.0\Microsoft.Extensions.DependencyInjection.Abstractions.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""Microsoft.OData.Core, Version=6.15.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL"">
      <HintPath>..\packages\Microsoft.OData.Core.6.15.0\lib\portable-net45+win+wpa81\Microsoft.OData.Core.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""Microsoft.OData.Edm, Version=6.15.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL"">
      <HintPath>..\packages\Microsoft.OData.Edm.6.15.0\lib\portable-net45+win+wpa81\Microsoft.OData.Edm.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""Microsoft.Restier.Core, Version=0.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL"">
      <HintPath>..\packages\Microsoft.Restier.Core.0.5.0-beta\lib\net45\Microsoft.Restier.Core.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""Microsoft.Restier.Providers.EntityFramework, Version=0.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL"">
      <HintPath>..\packages\Microsoft.Restier.Providers.EntityFramework.0.5.0-beta\lib\net45\Microsoft.Restier.Providers.EntityFramework.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""Microsoft.Restier.Publishers.OData, Version=0.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL"">
      <HintPath>..\packages\Microsoft.Restier.Publishers.OData.0.5.0-beta\lib\net45\Microsoft.Restier.Publishers.OData.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""Microsoft.Spatial, Version=6.15.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL"">
      <HintPath>..\packages\Microsoft.Spatial.6.15.0\lib\portable-net45+win+wpa81\Microsoft.Spatial.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""System.Net.Http"" />
    <Reference Include=""System.Web.DynamicData"" />
    <Reference Include=""System.Web.Entity"" />
    <Reference Include=""System.Web.ApplicationServices"" />
    <Reference Include=""System.ComponentModel.DataAnnotations"" />
    <Reference Include=""System"" />
    <Reference Include=""System.Data"" />
    <Reference Include=""System.Core"" />
    <Reference Include=""System.Data.DataSetExtensions"" />
    <Reference Include=""System.Web.Extensions"" />
    <Reference Include=""System.Web.OData, Version=5.9.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL"">
      <HintPath>..\packages\Microsoft.AspNet.OData.5.9.0\lib\net45\System.Web.OData.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include=""System.Xml.Linq"" />
    <Reference Include=""System.Drawing"" />
    <Reference Include=""System.Web"" />
    <Reference Include=""System.Xml"" />
    <Reference Include=""System.Configuration"" />
    <Reference Include=""System.Web.Services"" />
    <Reference Include=""System.EnterpriseServices"" />
  </ItemGroup>
  <ItemGroup>
    <Reference Include=""Newtonsoft.Json"">
      <HintPath>..\packages\Newtonsoft.Json.6.0.4\lib\net45\Newtonsoft.Json.dll</HintPath>
    </Reference>
    <Reference Include=""System.Net.Http.Formatting"">
      <HintPath>..\packages\Microsoft.AspNet.WebApi.Client.5.2.3\lib\net45\System.Net.Http.Formatting.dll</HintPath>
    </Reference>
    <Reference Include=""System.Web.Http"">
      <HintPath>..\packages\Microsoft.AspNet.WebApi.Core.5.2.3\lib\net45\System.Web.Http.dll</HintPath>
    </Reference>
    <Reference Include=""System.Web.Http.WebHost"">
      <HintPath>..\packages\Microsoft.AspNet.WebApi.WebHost.5.2.3\lib\net45\System.Web.Http.WebHost.dll</HintPath>
    </Reference>
  </ItemGroup>
  <ItemGroup>
    <Content Include=""Global.asax"" />
    <Content Include=""scripts\ai.0.22.9-build00167.js"" />
    <Content Include=""scripts\ai.0.22.9-build00167.min.js"" />
    <Content Include=""Web.config"" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include=""App_Start\WebApiConfig.cs"" />
    <Compile Include=""Global.asax.cs"">
      <DependentUpon>Global.asax</DependentUpon>
    </Compile>
    <Compile Include=""Properties\AssemblyInfo.cs"" />
  </ItemGroup>
  <ItemGroup>
    <Content Include=""packages.config"" />
    <Content Include=""ApplicationInsights.config"">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
    <None Include=""Web.Debug.config"">
      <DependentUpon>Web.config</DependentUpon>
    </None>
    <None Include=""Web.Release.config"">
      <DependentUpon>Web.config</DependentUpon>
    </None>
  </ItemGroup>
  <ItemGroup>
    <Folder Include=""App_Data\"" />
    <Folder Include=""Controllers\"" />
    <Folder Include=""Models\"" />
  </ItemGroup>
  <PropertyGroup>
    <VisualStudioVersion Condition=""'$(VisualStudioVersion)' == ''"">10.0</VisualStudioVersion>
    <VSToolsPath Condition=""'$(VSToolsPath)' == ''"">$(MSBuildExtensionsPath32)\Microsoft\VisualStudio\v$(VisualStudioVersion)</VSToolsPath>
  </PropertyGroup>
  <Import Project=""$(MSBuildBinPath)\Microsoft.CSharp.targets"" />
  <Import Project=""$(VSToolsPath)\WebApplications\Microsoft.WebApplication.targets"" Condition=""'$(VSToolsPath)' != ''"" />
  <Import Project=""$(MSBuildExtensionsPath32)\Microsoft\VisualStudio\v10.0\WebApplications\Microsoft.WebApplication.targets"" Condition=""false"" />
  <ProjectExtensions>
    <VisualStudio>
      <FlavorProperties GUID=""{349c5851-65df-11da-9384-00065b846f21}"">
        <WebProjectProperties>
          <UseIIS>True</UseIIS>
          <AutoAssignPort>True</AutoAssignPort>
          <DevelopmentServerPort>3447</DevelopmentServerPort>
          <DevelopmentServerVPath>/</DevelopmentServerVPath>
          <IISUrl>http://localhost:3447/</IISUrl>
          <NTLMAuthentication>False</NTLMAuthentication>
          <UseCustomServer>False</UseCustomServer>
          <CustomServerUrl>
          </CustomServerUrl>
          <SaveServerSettingsInUserFile>False</SaveServerSettingsInUserFile>
        </WebProjectProperties>
      </FlavorProperties>
    </VisualStudio>
  </ProjectExtensions>
  <Target Name=""EnsureNuGetPackageBuildImports"" BeforeTargets=""PrepareForBuild"">
    <PropertyGroup>
      <ErrorText>This project references NuGet package(s) that are missing on this computer. Use NuGet Package Restore to download them.  For more information, see http://go.microsoft.com/fwlink/?LinkID=322105. The missing file is {0}.</ErrorText>
    </PropertyGroup>
    <Error Condition=""!Exists('..\packages\Microsoft.Net.Compilers.1.0.0\build\Microsoft.Net.Compilers.props')"" Text=""$([System.String]::Format('$(ErrorText)', '..\packages\Microsoft.Net.Compilers.1.0.0\build\Microsoft.Net.Compilers.props'))"" />
    <Error Condition=""!Exists('..\packages\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.1.0.0\build\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.props')"" Text=""$([System.String]::Format('$(ErrorText)', '..\packages\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.1.0.0\build\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.props'))"" />
  </Target>
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name=""BeforeBuild"">
  </Target>
  <Target Name=""AfterBuild"">
  </Target>
  -->
</Project>
";
        public static string CSPROJUserFileContent = @"<?xml version=""1.0"" encoding=""utf-8""?>
<Project ToolsVersion=""14.0"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">
  <PropertyGroup>
    <UseIISExpress>true</UseIISExpress>
  </PropertyGroup>
  <ProjectExtensions>
    <VisualStudio>
      <FlavorProperties GUID=""{349c5851-65df-11da-9384-00065b846f21}"">
        <WebProjectProperties>
          <StartPageUrl>
          </StartPageUrl>
          <StartAction>CurrentPage</StartAction>
          <AspNetDebugging>True</AspNetDebugging>
          <SilverlightDebugging>False</SilverlightDebugging>
          <NativeDebugging>False</NativeDebugging>
          <SQLDebugging>False</SQLDebugging>
          <ExternalProgram>
          </ExternalProgram>
          <StartExternalURL>
          </StartExternalURL>
          <StartCmdLineArguments>
          </StartCmdLineArguments>
          <StartWorkingDirectory>
          </StartWorkingDirectory>
          <EnableENC>True</EnableENC>
          <AlwaysStartWebServerOnDebug>True</AlwaysStartWebServerOnDebug>
        </WebProjectProperties>
      </FlavorProperties>
    </VisualStudio>
  </ProjectExtensions>
</Project>
";
        public static string webConfigFileContent = @"<?xml version=""1.0"" encoding=""utf-8""?>
<!--
  For more information on how to configure your ASP.NET application, please visit
  http://go.microsoft.com/fwlink/?LinkId=301879
  -->
<configuration>
  <configSections>
    <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
    <section name=""entityFramework"" type=""System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" requirePermission=""false"" />
  </configSections>
  <appSettings>
  </appSettings>
  <system.web>
    <compilation debug=""true"" targetFramework=""4.5.2"" />
    <httpRuntime targetFramework=""4.5.2"" />
    <httpModules>
      <add name=""ApplicationInsightsWebTracking"" type=""Microsoft.ApplicationInsights.Web.ApplicationInsightsHttpModule, Microsoft.AI.Web"" />
    </httpModules>
  </system.web>
  <system.webServer>
    <handlers>
      <remove name=""ExtensionlessUrlHandler-Integrated-4.0"" />
      <remove name=""OPTIONSVerbHandler"" />
      <remove name=""TRACEVerbHandler"" />
      <add name=""ExtensionlessUrlHandler-Integrated-4.0"" path=""*."" verb=""*"" type=""System.Web.Handlers.TransferRequestHandler"" preCondition=""integratedMode,runtimeVersionv4.0"" />
    </handlers>
    <validation validateIntegratedModeConfiguration=""false"" />
    <modules>
      <remove name=""ApplicationInsightsWebTracking"" />
      <add name=""ApplicationInsightsWebTracking"" type=""Microsoft.ApplicationInsights.Web.ApplicationInsightsHttpModule, Microsoft.AI.Web"" preCondition=""managedHandler"" />
    </modules>
  </system.webServer>
  <runtime>
    <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
      <dependentAssembly>
        <assemblyIdentity name=""System.Web.Helpers"" publicKeyToken=""31bf3856ad364e35"" />
        <bindingRedirect oldVersion=""1.0.0.0-3.0.0.0"" newVersion=""3.0.0.0"" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name=""System.Web.Mvc"" publicKeyToken=""31bf3856ad364e35"" />
        <bindingRedirect oldVersion=""1.0.0.0-5.2.3.0"" newVersion=""5.2.3.0"" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name=""System.Web.WebPages"" publicKeyToken=""31bf3856ad364e35"" />
        <bindingRedirect oldVersion=""1.0.0.0-3.0.0.0"" newVersion=""3.0.0.0"" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name=""System.Web.Http"" publicKeyToken=""31bf3856ad364e35"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-5.2.3.0"" newVersion=""5.2.3.0"" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name=""System.Net.Http.Formatting"" publicKeyToken=""31bf3856ad364e35"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-5.2.3.0"" newVersion=""5.2.3.0"" />
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
  <system.codedom>
    <compilers>
      <compiler language=""c#;cs;csharp"" extension="".cs"" type=""Microsoft.CodeDom.Providers.DotNetCompilerPlatform.CSharpCodeProvider, Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"" warningLevel=""4"" compilerOptions=""/langversion:6 /nowarn:1659;1699;1701"" />
      <compiler language=""vb;vbs;visualbasic;vbscript"" extension="".vb"" type=""Microsoft.CodeDom.Providers.DotNetCompilerPlatform.VBCodeProvider, Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"" warningLevel=""4"" compilerOptions=""/langversion:14 /nowarn:41008 /define:_MYTYPE=\&quot;Web\&quot; /optionInfer+"" />
    </compilers>
  </system.codedom>
  <entityFramework>
    <defaultConnectionFactory type=""System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework"" />
    <providers>
      <provider invariantName=""System.Data.SqlClient"" type=""System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer"" />
    </providers>
  </entityFramework>
  <connectionStrings>
    <add name=""{0}"" connectionString=""{1}"" providerName=""System.Data.SqlClient"" />
  </connectionStrings>
</configuration>
";
        public static string webDebugConfigFileContent = @"<?xml version=""1.0"" encoding=""utf-8""?>

<!-- For more information on using web.config transformation visit http://go.microsoft.com/fwlink/?LinkId=125889 -->

<configuration xmlns:xdt=""http://schemas.microsoft.com/XML-Document-Transform"">
  <!--
    In the example below, the ""SetAttributes"" transform will change the value of 
    ""connectionString"" to use ""ReleaseSQLServer"" only when the ""Match"" locator 
    finds an attribute ""name"" that has a value of ""MyDB"".
    
    <connectionStrings>
      <add name=""MyDB"" 
        connectionString=""Data Source=ReleaseSQLServer;Initial Catalog=MyReleaseDB;Integrated Security=True"" 
        xdt:Transform=""SetAttributes"" xdt:Locator=""Match(name)""/>
    </connectionStrings>
  -->
  <system.web>
    <!--
      In the example below, the ""Replace"" transform will replace the entire 
      <customErrors> section of your web.config file.
      Note that because there is only one customErrors section under the 
      <system.web> node, there is no need to use the ""xdt:Locator"" attribute.
      
      <customErrors defaultRedirect=""GenericError.htm""
        mode=""RemoteOnly"" xdt:Transform=""Replace"">
        <error statusCode=""500"" redirect=""InternalError.htm""/>
      </customErrors>
    -->
  </system.web>
</configuration>
";
        public static string webReleaseConfigFileContent = @"<?xml version=""1.0"" encoding=""utf-8""?>

<!-- For more information on using web.config transformation visit http://go.microsoft.com/fwlink/?LinkId=125889 -->

<configuration xmlns:xdt=""http://schemas.microsoft.com/XML-Document-Transform"">
  <!--
    In the example below, the ""SetAttributes"" transform will change the value of 
    ""connectionString"" to use ""ReleaseSQLServer"" only when the ""Match"" locator 
    finds an attribute ""name"" that has a value of ""MyDB"".
    
    <connectionStrings>
      <add name=""MyDB"" 
        connectionString=""Data Source=ReleaseSQLServer;Initial Catalog=MyReleaseDB;Integrated Security=True"" 
        xdt:Transform=""SetAttributes"" xdt:Locator=""Match(name)""/>
    </connectionStrings>
  -->
  <system.web>
    <compilation xdt:Transform=""RemoveAttributes(debug)"" />
    <!--
      In the example below, the ""Replace"" transform will replace the entire 
      <customErrors> section of your web.config file.
      Note that because there is only one customErrors section under the 
      <system.web> node, there is no need to use the ""xdt:Locator"" attribute.
      
      <customErrors defaultRedirect=""GenericError.htm""
        mode=""RemoteOnly"" xdt:Transform=""Replace"">
        <error statusCode=""500"" redirect=""InternalError.htm""/>
      </customErrors>
    -->
  </system.web>
</configuration>
";
    }
}
