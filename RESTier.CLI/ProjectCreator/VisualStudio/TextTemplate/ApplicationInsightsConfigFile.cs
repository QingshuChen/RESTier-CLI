﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Microsoft.RESTier.Cli.ProjectCreator.VisualStudio.TextTemplate
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\t-qiche\Documents\RESTier-CLI\RESTier.CLI\ProjectCreator\VisualStudio\TextTemplate\ApplicationInsightsConfigFile.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class ApplicationInsightsConfigFile : ApplicationInsightsConfigFileBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<ApplicationInsights xmlns=\"http://schema" +
                    "s.microsoft.com/ApplicationInsights/2013/Settings\">\r\n\t<TelemetryModules>\r\n\t\t<Add" +
                    " Type=\"Microsoft.ApplicationInsights.DependencyCollector.DependencyTrackingTelem" +
                    "etryModule, Microsoft.AI.DependencyCollector\"/>\r\n\t\t<Add Type=\"Microsoft.Applicat" +
                    "ionInsights.Extensibility.PerfCounterCollector.PerformanceCollectorModule, Micro" +
                    "soft.AI.PerfCounterCollector\">\r\n\t\t\t<!--\r\n      Use the following syntax here to " +
                    "collect additional performance counters:\r\n      \r\n      <Counters>\r\n        <Add" +
                    " PerformanceCounter=\"\\Process(??APP_WIN32_PROC??)\\Handle Count\" ReportAs=\"Proces" +
                    "s handle count\" />\r\n        ...\r\n      </Counters>\r\n      \r\n      PerformanceCou" +
                    "nter must be either \\CategoryName(InstanceName)\\CounterName or \\CategoryName\\Cou" +
                    "nterName\r\n      \r\n      Counter names may only contain letters, round brackets, " +
                    "forward slashes, hyphens, underscores, spaces and dots.\r\n      You may provide a" +
                    "n optional ReportAs attribute which will be used as the metric name when reporti" +
                    "ng counter data.\r\n      For the purposes of reporting, metric names will be sani" +
                    "tized by removing all invalid characters from the resulting metric name.\r\n      " +
                    "\r\n      NOTE: performance counters configuration will be lost upon NuGet upgrade" +
                    ".\r\n      \r\n      The following placeholders are supported as InstanceName:\r\n    " +
                    "    ??APP_WIN32_PROC?? - instance name of the application process  for Win32 cou" +
                    "nters.\r\n        ??APP_W3SVC_PROC?? - instance name of the application IIS worker" +
                    " process for IIS/ASP.NET counters.\r\n        ??APP_CLR_PROC?? - instance name of " +
                    "the application CLR process for .NET counters.\r\n      -->\r\n\t\t</Add>\r\n\t\t<Add Type" +
                    "=\"Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.QuickPulse.Qu" +
                    "ickPulseTelemetryModule, Microsoft.AI.PerfCounterCollector\"/>\r\n\t\t<Add Type=\"Micr" +
                    "osoft.ApplicationInsights.WindowsServer.DeveloperModeWithDebuggerAttachedTelemet" +
                    "ryModule, Microsoft.AI.WindowsServer\"/>\r\n\t\t<Add Type=\"Microsoft.ApplicationInsig" +
                    "hts.WindowsServer.UnhandledExceptionTelemetryModule, Microsoft.AI.WindowsServer\"" +
                    "/>\r\n\t\t<Add Type=\"Microsoft.ApplicationInsights.WindowsServer.UnobservedException" +
                    "TelemetryModule, Microsoft.AI.WindowsServer\"/>\r\n\t\t<Add Type=\"Microsoft.Applicati" +
                    "onInsights.Web.RequestTrackingTelemetryModule, Microsoft.AI.Web\">\r\n\t\t\t<Handlers>" +
                    "\r\n\t\t\t\t<!-- \r\n        Add entries here to filter out additional handlers: \r\n     " +
                    "   \r\n        NOTE: handler configuration will be lost upon NuGet upgrade.\r\n     " +
                    "   -->\r\n\t\t\t\t<Add>System.Web.Handlers.TransferRequestHandler</Add>\r\n\t\t\t\t<Add>Micr" +
                    "osoft.VisualStudio.Web.PageInspector.Runtime.Tracing.RequestDataHttpHandler</Add" +
                    ">\r\n\t\t\t\t<Add>System.Web.StaticFileHandler</Add>\r\n\t\t\t\t<Add>System.Web.Handlers.Ass" +
                    "emblyResourceLoader</Add>\r\n\t\t\t\t<Add>System.Web.Optimization.BundleHandler</Add>\r" +
                    "\n\t\t\t\t<Add>System.Web.Script.Services.ScriptHandlerFactory</Add>\r\n\t\t\t\t<Add>System" +
                    ".Web.Handlers.TraceHandler</Add>\r\n\t\t\t\t<Add>System.Web.Services.Discovery.Discove" +
                    "ryRequestHandler</Add>\r\n\t\t\t\t<Add>System.Web.HttpDebugHandler</Add>\r\n\t\t\t</Handler" +
                    "s>\r\n\t\t</Add>\r\n\t\t<Add Type=\"Microsoft.ApplicationInsights.Web.ExceptionTrackingTe" +
                    "lemetryModule, Microsoft.AI.Web\"/>\r\n\t</TelemetryModules>\r\n\t<TelemetryProcessors>" +
                    "\r\n\t\t<Add Type=\"Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector." +
                    "QuickPulse.QuickPulseTelemetryProcessor, Microsoft.AI.PerfCounterCollector\"/>\r\n\t" +
                    "\t<Add Type=\"Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel.Adaptiv" +
                    "eSamplingTelemetryProcessor, Microsoft.AI.ServerTelemetryChannel\">\r\n\t\t\t<MaxTelem" +
                    "etryItemsPerSecond>5</MaxTelemetryItemsPerSecond>\r\n\t\t</Add>\r\n\t</TelemetryProcess" +
                    "ors>\r\n\t<TelemetryChannel Type=\"Microsoft.ApplicationInsights.WindowsServer.Telem" +
                    "etryChannel.ServerTelemetryChannel, Microsoft.AI.ServerTelemetryChannel\"/>\r\n<!--" +
                    " \r\n    Learn more about Application Insights configuration with ApplicationInsig" +
                    "hts.config here: \r\n    http://go.microsoft.com/fwlink/?LinkID=513840\r\n    \r\n    " +
                    "Note: If not present, please add <InstrumentationKey>Your Key</InstrumentationKe" +
                    "y> to the top of this file.\r\n  -->\r\n<TelemetryInitializers>\r\n<Add Type=\"Microsof" +
                    "t.ApplicationInsights.WindowsServer.AzureRoleEnvironmentTelemetryInitializer, Mi" +
                    "crosoft.AI.WindowsServer\"/>\r\n<Add Type=\"Microsoft.ApplicationInsights.WindowsSer" +
                    "ver.DomainNameRoleInstanceTelemetryInitializer, Microsoft.AI.WindowsServer\"/>\r\n<" +
                    "Add Type=\"Microsoft.ApplicationInsights.WindowsServer.BuildInfoConfigComponentVe" +
                    "rsionTelemetryInitializer, Microsoft.AI.WindowsServer\"/>\r\n<Add Type=\"Microsoft.A" +
                    "pplicationInsights.Web.WebTestTelemetryInitializer, Microsoft.AI.Web\"/>\r\n<Add Ty" +
                    "pe=\"Microsoft.ApplicationInsights.Web.SyntheticUserAgentTelemetryInitializer, Mi" +
                    "crosoft.AI.Web\">\r\n<Filters>\r\n<Add Pattern=\"(YottaaMonitor|BrowserMob|HttpMonitor" +
                    "|YandexBot|BingPreview|PagePeeker|ThumbShotsBot|WebThumb|URL2PNG|ZooShot|GomezA|" +
                    "Catchpoint bot|Willow Internet Crawler|Google SketchUp|Read%20Later|KTXN|Pingdom" +
                    "|AlwaysOn)\"/>\r\n<Add Pattern=\"Slurp\" SourceName=\"Yahoo Bot\"/>\r\n<Add Pattern=\"(bot" +
                    "|zao|borg|Bot|oegp|silk|Xenu|zeal|^NING|crawl|Crawl|htdig|lycos|slurp|teoma|voil" +
                    "a|yahoo|Sogou|CiBra|Nutch|^Java/|^JNLP/|Daumoa|Genieo|ichiro|larbin|pompos|Scrap" +
                    "y|snappy|speedy|spider|Spider|vortex|favicon|indexer|Riddler|scooter|scraper|scr" +
                    "ubby|WhatWeb|WinHTTP|^voyager|archiver|Icarus6j|mogimogi|Netvibes|altavista|char" +
                    "lotte|findlinks|Retreiver|TLSProber|WordPress|wsr\\-agent|Squrl Java|A6\\-Indexer|" +
                    "netresearch|searchsight|http%20client|Python-urllib|dataparksearch|Screaming Fro" +
                    "g|AppEngine-Google|YahooCacheSystem|semanticdiscovery|facebookexternalhit|Google" +
                    ".*/\\+/web/snippet|Google-HTTP-Java-Client)\"\r\nSourceName=\"Spider\"/>\r\n</Filters>\r\n" +
                    "</Add>\r\n<Add Type=\"Microsoft.ApplicationInsights.Web.ClientIpHeaderTelemetryInit" +
                    "ializer, Microsoft.AI.Web\"/>\r\n<Add Type=\"Microsoft.ApplicationInsights.Web.Opera" +
                    "tionNameTelemetryInitializer, Microsoft.AI.Web\"/>\r\n<Add Type=\"Microsoft.Applicat" +
                    "ionInsights.Web.OperationCorrelationTelemetryInitializer, Microsoft.AI.Web\"/>\r\n<" +
                    "Add Type=\"Microsoft.ApplicationInsights.Web.UserTelemetryInitializer, Microsoft." +
                    "AI.Web\"/>\r\n<Add Type=\"Microsoft.ApplicationInsights.Web.AuthenticatedUserIdTelem" +
                    "etryInitializer, Microsoft.AI.Web\"/>\r\n<Add Type=\"Microsoft.ApplicationInsights.W" +
                    "eb.AccountIdTelemetryInitializer, Microsoft.AI.Web\"/>\r\n<Add Type=\"Microsoft.Appl" +
                    "icationInsights.Web.SessionTelemetryInitializer, Microsoft.AI.Web\"/>\r\n</Telemetr" +
                    "yInitializers>\r\n</ApplicationInsights>");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public class ApplicationInsightsConfigFileBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
