// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.RESTier.Cli.EFTools.EntityDesign
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Diagnostics;
    using System.Linq;

    internal class DefaultCSharpContextGenerator : IContextGenerator
    {
        public string Generate(DbModel model, string codeNamespace, string contextClassName, string connectionStringName)
        {
            Debug.Assert(model != null, "model is null.");
            Debug.Assert(!string.IsNullOrEmpty(codeNamespace), "codeNamespace is null or empty.");
            Debug.Assert(!string.IsNullOrEmpty(contextClassName), "contextClassName is null or empty.");
            Debug.Assert(!string.IsNullOrEmpty(connectionStringName), "connectionStringName is null or empty.");

            Session = new Dictionary<string, object>
                    {
                        { "Model", model },
                        { "Namespace", codeNamespace },
                        { "ContextClassName", contextClassName },
                        { "ConnectionStringName", connectionStringName }
                    };
            Initialize();

            return TransformText();
        }

        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {

            var code = new CSharpCodeHelper();
            var edm = new EdmHelper(code);

            if (Model == null)
            {
                throw new ArgumentNullException("Model");
            }

            if (Namespace == null)
            {
                throw new ArgumentNullException("Namespace");
            }

            if (ContextClassName == null)
            {
                throw new ArgumentNullException("ContextClassName");
            }

            if (ConnectionStringName == null)
            {
                throw new ArgumentNullException("ConnectionStringName");
            }

            this.Write("namespace ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            this.Write("\r\n{\r\n    using System;\r\n    using System.Data.Entity;\r\n    using System.Component" +
                    "Model.DataAnnotations.Schema;\r\n    using System.Linq;\r\n\r\n    public partial clas" +
                    "s ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ContextClassName));
            this.Write(" : DbContext\r\n    {\r\n        public ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ContextClassName));
            this.Write("()\r\n            : base(\"name=");
            this.Write(this.ToStringHelper.ToStringWithCulture(ConnectionStringName));
            this.Write("\")\r\n        {\r\n        }\r\n\r\n");

            foreach (var entitySet in Model.ConceptualModel.Container.EntitySets)
            {

                this.Write("        public virtual DbSet<");
                this.Write(this.ToStringHelper.ToStringWithCulture(code.Type(entitySet.ElementType)));
                this.Write("> ");
                this.Write(this.ToStringHelper.ToStringWithCulture(code.Property(entitySet)));
                this.Write(" { get; set; }\r\n");

            }

            this.Write("\r\n        protected override void OnModelCreating(DbModelBuilder modelBuilder)\r\n " +
                    "       {\r\n");

            var anyConfiguration = false;

            foreach (var entitySet in Model.ConceptualModel.Container.EntitySets)
            {
                var typeConfigurations = edm.GetConfigurations(entitySet, Model).OfType<IFluentConfiguration>()
                    .Where(c => !(c is IAttributeConfiguration || c is KeyConfiguration));

                var firstTypeConfiguration = true;
                foreach (var typeConfiguration in typeConfigurations)
                {
                    if (firstTypeConfiguration)
                    {
                        firstTypeConfiguration = false;

                        if (anyConfiguration)
                        {
                            WriteLine(string.Empty);
                        }
                        else
                        {
                            anyConfiguration = true;
                        }


                        this.Write("            modelBuilder.Entity<");
                        this.Write(this.ToStringHelper.ToStringWithCulture(code.Type(entitySet.ElementType)));
                        this.Write(">()\r\n");

                    }
                    else
                    {
                        WriteLine(string.Empty);
                    }

                    Write("                " + code.MethodChain(typeConfiguration));
                }

                if (!firstTypeConfiguration)
                {
                    WriteLine(";");
                }

                foreach (var property in entitySet.ElementType.Properties)
                {
                    var propertyConfigurations = edm.GetConfigurations(property, Model).OfType<IFluentConfiguration>()
                        .Where(c => !(c is IAttributeConfiguration));

                    var firstPropertyConfiguration = true;
                    foreach (var propertyConfiguration in propertyConfigurations)
                    {
                        var columnConfiguration = propertyConfiguration as ColumnConfiguration;
                        if (columnConfiguration != null)
                        {
                            // Unset this since it is implied in the key configuration calls themselves
                            columnConfiguration.Order = null;

                            if (columnConfiguration.Name == null && columnConfiguration.TypeName == null)
                            {
                                // Nothing left to configure
                                continue;
                            }
                        }

                        if (firstPropertyConfiguration)
                        {
                            firstPropertyConfiguration = false;

                            if (anyConfiguration)
                            {
                                WriteLine(string.Empty);
                            }
                            else
                            {
                                anyConfiguration = true;
                            }


                            this.Write("            modelBuilder.Entity<");
                            this.Write(this.ToStringHelper.ToStringWithCulture(code.Type(entitySet.ElementType)));
                            this.Write(">()\r\n                .Property(e => e.");
                            this.Write(this.ToStringHelper.ToStringWithCulture(code.Property(property)));
                            this.Write(")\r\n");

                        }
                        else
                        {
                            WriteLine(string.Empty);
                        }

                        Write("                " + code.MethodChain(propertyConfiguration));
                    }

                    if (!firstPropertyConfiguration)
                    {
                        WriteLine(";");
                    }
                }

                foreach (var navigationProperty in entitySet.ElementType.NavigationProperties)
                {
                    // Only configure relationships from one end
                    if (navigationProperty.RelationshipType.RelationshipEndMembers.First() != navigationProperty.FromEndMember)
                    {
                        continue;
                    }

                    bool isDefaultMultiplicity;
                    var navigationPropertyMultiplicityConfiguration = edm.GetMultiplicityConfiguration(navigationProperty, out isDefaultMultiplicity);
                    var navigationPropertyConfigurations = edm.GetConfigurations(navigationProperty, Model);

                    var firstNavigationPropertyConfiguration = true;
                    foreach (var navigationPropertyConfiguration in navigationPropertyConfigurations)
                    {
                        if (firstNavigationPropertyConfiguration)
                        {
                            firstNavigationPropertyConfiguration = false;

                            if (anyConfiguration)
                            {
                                WriteLine(string.Empty);
                            }
                            else
                            {
                                anyConfiguration = true;
                            }


                            this.Write("            modelBuilder");
                            this.Write(this.ToStringHelper.ToStringWithCulture(code.MethodChain(navigationPropertyMultiplicityConfiguration)));
                            this.Write("\r\n");

                        }
                        else
                        {
                            WriteLine(string.Empty);
                        }

                        Write("                " + code.MethodChain(navigationPropertyConfiguration));
                    }

                    if (!firstNavigationPropertyConfiguration)
                    {
                        WriteLine(";");
                    }
                    else if (!isDefaultMultiplicity)
                    {
                        if (anyConfiguration)
                        {
                            WriteLine(string.Empty);
                        }
                        else
                        {
                            anyConfiguration = true;
                        }

                        this.Write("            modelBuilder");
                        this.Write(this.ToStringHelper.ToStringWithCulture(code.MethodChain(navigationPropertyMultiplicityConfiguration)));
                        this.Write(";\r\n");

                    }
                }
            }

            this.Write("        }\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }

        private global::System.Data.Entity.Infrastructure.DbModel _ModelField;

        /// <summary>
        /// Access the Model parameter of the template.
        /// </summary>
        private global::System.Data.Entity.Infrastructure.DbModel Model
        {
            get
            {
                return this._ModelField;
            }
        }

        private string _NamespaceField;

        /// <summary>
        /// Access the Namespace parameter of the template.
        /// </summary>
        private string Namespace
        {
            get
            {
                return this._NamespaceField;
            }
        }

        private string _ContextClassNameField;

        /// <summary>
        /// Access the ContextClassName parameter of the template.
        /// </summary>
        private string ContextClassName
        {
            get
            {
                return this._ContextClassNameField;
            }
        }

        private string _ConnectionStringNameField;

        /// <summary>
        /// Access the ConnectionStringName parameter of the template.
        /// </summary>
        private string ConnectionStringName
        {
            get
            {
                return this._ConnectionStringNameField;
            }
        }


        /// <summary>
        /// Initialize the template
        /// </summary>
        public virtual void Initialize()
        {
            if ((this.Errors.HasErrors == false))
            {
                bool ModelValueAcquired = false;
                if (this.Session.ContainsKey("Model"))
                {
                    this._ModelField = ((global::System.Data.Entity.Infrastructure.DbModel)(this.Session["Model"]));
                    ModelValueAcquired = true;
                }
                if ((ModelValueAcquired == false))
                {
                    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Model");
                    if ((data != null))
                    {
                        this._ModelField = ((global::System.Data.Entity.Infrastructure.DbModel)(data));
                    }
                }
                bool NamespaceValueAcquired = false;
                if (this.Session.ContainsKey("Namespace"))
                {
                    this._NamespaceField = ((string)(this.Session["Namespace"]));
                    NamespaceValueAcquired = true;
                }
                if ((NamespaceValueAcquired == false))
                {
                    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Namespace");
                    if ((data != null))
                    {
                        this._NamespaceField = ((string)(data));
                    }
                }
                bool ContextClassNameValueAcquired = false;
                if (this.Session.ContainsKey("ContextClassName"))
                {
                    this._ContextClassNameField = ((string)(this.Session["ContextClassName"]));
                    ContextClassNameValueAcquired = true;
                }
                if ((ContextClassNameValueAcquired == false))
                {
                    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("ContextClassName");
                    if ((data != null))
                    {
                        this._ContextClassNameField = ((string)(data));
                    }
                }
                bool ConnectionStringNameValueAcquired = false;
                if (this.Session.ContainsKey("ConnectionStringName"))
                {
                    this._ConnectionStringNameField = ((string)(this.Session["ConnectionStringName"]));
                    ConnectionStringNameValueAcquired = true;
                }
                if ((ConnectionStringNameValueAcquired == false))
                {
                    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("ConnectionStringName");
                    if ((data != null))
                    {
                        this._ConnectionStringNameField = ((string)(data));
                    }
                }


            }
        }

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
            private System.IFormatProvider formatProviderField = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField = value;
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
}
