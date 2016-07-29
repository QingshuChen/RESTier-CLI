// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.RESTier.Cli.EFTools.EntityDesign
{
    using System.Collections.Generic;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Infrastructure;
    using System.Diagnostics;
    using System.Linq;
    using System;

    internal partial class DefaultCSharpEntityTypeGenerator : IEntityTypeGenerator
    {
        public string Generate(EntitySet entitySet, DbModel model, string codeNamespace)
        {
            Debug.Assert(entitySet != null, "entitySet is null.");
            Debug.Assert(model != null, "model is null.");
            Debug.Assert(!string.IsNullOrEmpty(codeNamespace), "codeNamespace is null or empty.");

            Session = new Dictionary<string, object>
                    {
                        { "EntitySet", entitySet },
                        { "Model", model },
                        { "Namespace", codeNamespace }
                    };
            Initialize();

            return TransformText();
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
       
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {

            var code = new CSharpCodeHelper();
            var edm = new EdmHelper(code);

            if (EntitySet == null)
            {
                throw new ArgumentNullException("EntitySet");
            }

            if (Model == null)
            {
                throw new ArgumentNullException("Model");
            }

            var entityType = EntitySet.ElementType;

            this.Write("namespace ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            this.Write("\r\n{\r\n    using System;\r\n    using System.Collections.Generic;\r\n    using System.C" +
                    "omponentModel.DataAnnotations;\r\n    using System.ComponentModel.DataAnnotations." +
                    "Schema;\r\n    using System.Data.Entity.Spatial;\r\n\r\n");

            var typeConfigurations = edm.GetConfigurations(EntitySet, Model).OfType<IAttributeConfiguration>();

            foreach (var typeConfiguration in typeConfigurations)
            {

                this.Write("    ");
                this.Write(this.ToStringHelper.ToStringWithCulture(code.Attribute(typeConfiguration)));
                this.Write("\r\n");

            }

            this.Write("    public partial class ");
            this.Write(this.ToStringHelper.ToStringWithCulture(code.Type(entityType)));
            this.Write("\r\n    {\r\n");

            var collectionProperties = from p in entityType.NavigationProperties
                                        where p.ToEndMember.RelationshipMultiplicity == RelationshipMultiplicity.Many
                                        select p;

            if (collectionProperties.Any())
            {

                this.Write("        [System.Diagnostics.CodeAnalysis.SuppressMessage(\"Microsoft.Usage\", \"CA22" +
                        "14:DoNotCallOverridableMethodsInConstructors\")]\r\n        public ");
                this.Write(this.ToStringHelper.ToStringWithCulture(code.Type(entityType)));
                this.Write("()\r\n        {\r\n");

                foreach (var collectionProperty in collectionProperties)
                {

                    this.Write("            ");
                    this.Write(this.ToStringHelper.ToStringWithCulture(code.Property(collectionProperty)));
                    this.Write(" = new HashSet<");
                    this.Write(this.ToStringHelper.ToStringWithCulture(code.Type(collectionProperty.ToEndMember.GetEntityType())));
                    this.Write(">();\r\n");

                }

                this.Write("        }\r\n\r\n");

            }

            var first = true;

            foreach (var property in entityType.Properties)
            {
                if (!first)
                {
                    WriteLine(string.Empty);
                }
                else
                {
                    first = false;
                }

                var propertyConfigurations = edm.GetConfigurations(property, Model).OfType<IAttributeConfiguration>();

                foreach (var propertyConfiguration in propertyConfigurations)
                {

                    this.Write("        ");
                    this.Write(this.ToStringHelper.ToStringWithCulture(code.Attribute(propertyConfiguration)));
                    this.Write("\r\n");

                }

                this.Write("        public ");
                this.Write(this.ToStringHelper.ToStringWithCulture(code.Type(property)));
                this.Write(" ");
                this.Write(this.ToStringHelper.ToStringWithCulture(code.Property(property)));
                this.Write(" { get; set; }\r\n");

            }

            foreach (var navigationProperty in entityType.NavigationProperties)
            {
                if (!first)
                {
                    WriteLine(string.Empty);
                }
                else
                {
                    first = false;
                }

                if (navigationProperty.ToEndMember.RelationshipMultiplicity == RelationshipMultiplicity.Many)
                {

                    this.Write("        [System.Diagnostics.CodeAnalysis.SuppressMessage(\"Microsoft.Usage\", \"CA22" +
                            "27:CollectionPropertiesShouldBeReadOnly\")]\r\n");

                }

                this.Write("        public virtual ");
                this.Write(this.ToStringHelper.ToStringWithCulture(code.Type(navigationProperty)));
                this.Write(" ");
                this.Write(this.ToStringHelper.ToStringWithCulture(code.Property(navigationProperty)));
                this.Write(" { get; set; }\r\n");

            }

            this.Write("    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }

        private global::System.Data.Entity.Core.Metadata.Edm.EntitySet _EntitySetField;

        /// <summary>
        /// Access the EntitySet parameter of the template.
        /// </summary>
        private global::System.Data.Entity.Core.Metadata.Edm.EntitySet EntitySet
        {
            get
            {
                return this._EntitySetField;
            }
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


        /// <summary>
        /// Initialize the template
        /// </summary>
        public virtual void Initialize()
        {
            if ((this.Errors.HasErrors == false))
            {
                bool EntitySetValueAcquired = false;
                if (this.Session.ContainsKey("EntitySet"))
                {
                    this._EntitySetField = ((global::System.Data.Entity.Core.Metadata.Edm.EntitySet)(this.Session["EntitySet"]));
                    EntitySetValueAcquired = true;
                }
                if ((EntitySetValueAcquired == false))
                {
                    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("EntitySet");
                    if ((data != null))
                    {
                        this._EntitySetField = ((global::System.Data.Entity.Core.Metadata.Edm.EntitySet)(data));
                    }
                }
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


            }
        }
    }
}
