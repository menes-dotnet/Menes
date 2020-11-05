// <copyright file="ObjectTypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    /// <summary>
    /// Type declaration for a complex object.
    /// </summary>
    public class ObjectTypeDeclaration : TypeDeclaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectTypeDeclaration"/> class.
        /// </summary>
        /// <param name="name">The name of the type.</param>
        /// <param name="additionalPropertiesType">The type of any additional properties.</param>
        public ObjectTypeDeclaration(string name, ITypeDeclaration? additionalPropertiesType = null)
            : base(name)
        {
            this.AdditionalPropertiesType = additionalPropertiesType;
        }

        /// <summary>
        /// Gets or sets the type of any additional properties.
        /// </summary>
        public ITypeDeclaration? AdditionalPropertiesType { get; set; }

        /// <summary>
        /// Gets or sets the type of any unevaluated properties.
        /// </summary>
        public ITypeDeclaration? UnevaluatedPropertiesType { get; set; }

        /// <summary>
        /// Gets or sets the max properties validation.
        /// </summary>
        public int? MaxPropertiesValidation { get; set; }

        /// <summary>
        /// Gets or sets the min properties validation.
        /// </summary>
        public int? MinPropertiesValidation { get; set; }

        /// <summary>
        /// Gets or sets the required properties validation.
        /// </summary>
        /// <remarks>
        /// This is used to provide required properties that are not
        /// exposed as properties on the object itself.
        /// </remarks>
        public List<string>? RequiredPropertiesValidation { get; set; }

        /// <summary>
        /// Gets or sets the type of the not validation.
        /// </summary>
        public ITypeDeclaration? NotTypeValidation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to explicitly
        /// validate this as an object.
        /// </summary>
        public bool ValidateAsObject { get; set; }

        /// <summary>
        /// Gets or sets the allOf type validation.
        /// </summary>
        public List<ITypeDeclaration>? AllOfTypeValidation { get; set; }

        /// <summary>
        /// Gets or sets the JSON array of objects for the enum validation.
        /// </summary>
        public string? EnumValidation { get; set; }

        /// <summary>
        /// Gets or sets the JSON object for the const validation.
        /// </summary>
        public string? ConstValidation { get; set; }

        /// <summary>
        /// Gets or sets the property patterns validation.
        /// </summary>
        public List<(string regex, ITypeDeclaration typeDeclaration)>? PatternPropertiesValidation { get; set; }

        /// <inheritdoc/>
        public override TypeDeclarationSyntax GenerateType()
        {
            return
                SF.StructDeclaration(this.Name)
                    .AddModifiers(SF.Token(SyntaxKind.PublicKeyword), SF.Token(SyntaxKind.ReadOnlyKeyword))
                    .AddBaseListTypes(this.BuildBaseListTypes())
                    .AddMembers(this.BuildMembers());
        }

        /// <inheritdoc/>
        public override bool IsSpecializedBy(ITypeDeclaration type)
        {
            return false;
        }

        /// <inheritdoc/>
        public override bool ContainsReference(ITypeDeclaration typeDeclaration, IList<ITypeDeclaration> visitedDeclarations)
        {
            if (this.AdditionalPropertiesType is ITypeDeclaration itemType && CheckType(typeDeclaration, visitedDeclarations, itemType))
            {
                return true;
            }

            return base.ContainsReference(typeDeclaration, visitedDeclarations);
        }

        /// <summary>
        /// Add an allOf type to the collection.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration to add.</param>
        public void AddAllOfType(ITypeDeclaration typeDeclaration)
        {
            if (!(this.AllOfTypeValidation is List<ITypeDeclaration> aot))
            {
                this.AllOfTypeValidation = aot = new List<ITypeDeclaration>();
            }

            aot.Add(typeDeclaration);
        }

        private BaseTypeSyntax[] BuildBaseListTypes()
        {
            var bases = new List<BaseTypeSyntax> { SF.SimpleBaseType(SF.ParseTypeName(typeof(IJsonObject).FullName)), SF.SimpleBaseType(SF.ParseTypeName($"System.IEquatable<{this.GetFullyQualifiedName()}>")) };

            if (this.AdditionalPropertiesType is ITypeDeclaration additionalProperties)
            {
                bases.Add(SF.SimpleBaseType(SF.ParseTypeName($"Menes.IJsonAdditionalProperties<{additionalProperties.GetFullyQualifiedName()}>")));
            }

            return bases.ToArray();
        }

        private MemberDeclarationSyntax[] BuildMembers()
        {
            var members = new List<MemberDeclarationSyntax>();
            List<NamedPropertyDeclaration> properties = this.BuildNamedPropertyDeclarations();

            //// Public static readonly fields

            this.BuildNullAccessor(members);
            this.BuildJsonElementFactory(members);
            this.BuildConstValue(members);
            this.BuildEnumValues(properties, members);

            //// private const, private static, private readonly (we may need to split these up)

            this.BuildPropertyBackings(properties, members);
            this.BuildAdditionalPropertiesBacking(members);
            this.BuildValidatePatternPropertyRegularExpressions(members);

            //// Constructors (public then private)

            this.BuildConstructors(properties, members);

            //// Public properties
            this.BuildIsNullAccessor(properties, members);
            this.BuildAsOptionalAccessor(members);
            this.BuildPropertyAccessors(properties, members);
            this.BuildPropertyCountAccessors(members);
            this.BuildJsonElementAccessors(members);
            this.BuildAdditionalPropertiesAccessor(members);

            //// Public static methods
            this.BuildIsConvertibleFrom(members);
            this.BuildFromOptionalFactories(members);

            //// Public methods
            this.BuildWithPropertyFactories(properties, members);
            this.BuildWriteTo(properties, members);
            this.BuildEquals(properties, members);
            this.BuildValidate(properties, members);
            this.BuildTryGetAdditionalProperties(members);
            this.BuildToString(members);
            this.BuildMethods(members);

            //// Private static methods
            this.BuildConstValueFactory(members);
            this.BuildEnumValuesFactory(members);

            //// Private methods
            this.BuildJsonReferenceAccessors(properties, members);
            this.BuildJsonPropertiesAccessor(members);
            this.BuildValidatePatternProperty(members);

            this.BuildNestedTypes(members);

            return members.ToArray();
        }

        private void BuildToString(List<MemberDeclarationSyntax> members)
        {
            var builder = new StringBuilder();
            builder.AppendLine("public override string ToString()");
            builder.AppendLine("{");
            builder.AppendLine("    return Menes.JsonAny.From(this).ToString();");
            builder.AppendLine("}");
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildConstValue(List<MemberDeclarationSyntax> members)
        {
            if (this.ConstValidation is string)
            {
                members.Add(SF.ParseMemberDeclaration("private static readonly Menes.JsonReference ConstValue = BuildConstValue();" + Environment.NewLine));
            }
        }

        private void BuildConstValueFactory(List<MemberDeclarationSyntax> members)
        {
            if (this.ConstValidation is string constValue)
            {
                var builder = new StringBuilder();
                builder.AppendLine("private static Menes.JsonReference BuildConstValue()");
                builder.AppendLine("{");
                builder.AppendLine($"    using var document = System.Text.Json.JsonDocument.Parse({StringFormatter.EscapeForCSharpString(constValue, true)});");
                builder.AppendLine("    return new Menes.JsonReference(document.RootElement.Clone());");
                builder.AppendLine("}");

                members.Add(SF.ParseMemberDeclaration(builder.ToString()));
            }
        }

        private void BuildEnumValues(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            if (this.EnumValidation is string enumValidation)
            {
                members.Add(SF.ParseMemberDeclaration("public static readonly Menes.JsonReference EnumValues = BuildEnumValues();" + Environment.NewLine));
                int enumIndex = 0;
                using var document = JsonDocument.Parse(enumValidation);
                JsonElement.ArrayEnumerator enumerator = document.RootElement.EnumerateArray();
                string name = this.Name;
                while (enumerator.MoveNext())
                {
                    string baseEnumPropertyName = StringFormatter.ToPascalCaseWithReservedWords(enumerator.Current.GetRawText());
                    string enumPropertyName = baseEnumPropertyName;
                    int enumNameIndex = 1;

                    while (enumPropertyName == "Null" || properties.Any(p => p.PropertyName == enumPropertyName))
                    {
                        enumPropertyName = baseEnumPropertyName + enumNameIndex;
                        enumNameIndex++;
                    }

                    members.Add(SF.ParseMemberDeclaration($"    public static readonly {name} {enumPropertyName} = new {name}(EnumValues[{enumIndex}]);"));
                    enumIndex++;
                }
            }
        }

        private void BuildEnumValuesFactory(List<MemberDeclarationSyntax> members)
        {
            if (this.EnumValidation is string enumValidation)
            {
                var builder = new StringBuilder();
                builder.AppendLine("private static Menes.JsonReference BuildEnumValues()");
                builder.AppendLine("{");
                builder.AppendLine($"    using var document = System.Text.Json.JsonDocument.Parse({StringFormatter.EscapeForCSharpString(enumValidation, true)});");
                builder.AppendLine("    return new Menes.JsonReference(document.RootElement.Clone());");
                builder.AppendLine("}");

                members.Add(SF.ParseMemberDeclaration(builder.ToString()));
            }
        }

        private void BuildMethods(List<MemberDeclarationSyntax> members)
        {
            foreach (MethodDeclaration method in this.Methods)
            {
                members.Add(method.GenerateMethod());
            }
        }

        private void BuildNestedTypes(List<MemberDeclarationSyntax> members)
        {
            foreach (ITypeDeclaration declaration in this.TypeDeclarations)
            {
                members.Add(declaration.GenerateType());
            }
        }

        private void BuildTryGetAdditionalProperties(List<MemberDeclarationSyntax> members)
        {
            if (!(this.AdditionalPropertiesType is ITypeDeclaration additionalProperties))
            {
                return;
            }

            var builder = new StringBuilder();
            string typename = additionalProperties.GetFullyQualifiedName();

            builder.AppendLine($"public bool TryGet(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out {typename} value)");
            builder.AppendLine("{");
            builder.AppendLine("    return this.TryGet(System.MemoryExtensions.AsSpan(propertyName), out value);");
            builder.AppendLine("}");
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
            builder.Clear();

            builder.AppendLine($"public bool TryGet(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out {typename} value)");
            builder.AppendLine("{");
            builder.AppendLine($"    foreach (Menes.JsonPropertyReference<{typename}> property in this.JsonAdditionalProperties)");
            builder.AppendLine("    {");
            builder.AppendLine("        if (property.NameEquals(utf8PropertyName))");
            builder.AppendLine("        {");
            builder.AppendLine($"            value = property.AsValue();");
            builder.AppendLine("            return true;");
            builder.AppendLine("        }");
            builder.AppendLine("    }");
            builder.AppendLine("    value = default;");
            builder.AppendLine("    return false;");
            builder.AppendLine("}");
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
            builder.Clear();

            builder.AppendLine($"public bool TryGet(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out {typename} value)");
            builder.AppendLine("{");
            builder.AppendLine("    System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];");
            builder.AppendLine("    int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);");
            builder.AppendLine("    return this.TryGet(bytes.Slice(0, written), out value);");
            builder.AppendLine("}");
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildValidate(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            bool hasPatternProperties = this.PatternPropertiesValidation is List<(string pattern, ITypeDeclaration declaration)>;

            var builder = new StringBuilder();
            builder.AppendLine("public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)");
            builder.AppendLine("{");

            builder.AppendLine("if (this.IsNull)");
            builder.AppendLine("{");
            builder.AppendLine("    return validationContext.WithError($\"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}\");");
            builder.AppendLine("}");

            if (this.ValidateAsObject)
            {
                builder.AppendLine("if (this.HasJsonElement && !IsConvertibleFrom(this.JsonElement))");
                builder.AppendLine("{");
                builder.AppendLine("    return validationContext.WithError($\"6.1.1. type: the element with type {this.JsonElement.ValueKind} is not convertible to {System.Text.Json.JsonValueKind.Object}\");");
                builder.AppendLine("}");
            }

            builder.AppendLine("    Menes.ValidationContext context = validationContext;");

            if (!this.ValidateAsObject)
            {
                builder.AppendLine("if (!this.HasJsonElement || IsConvertibleFrom(this.JsonElement))");
                builder.AppendLine("{");
            }

            if (hasPatternProperties)
            {
                builder.AppendLine($"    System.Collections.Generic.HashSet<string> matchedProperties = new System.Collections.Generic.HashSet<string>(this.PropertiesCount);");
            }

            foreach (NamedPropertyDeclaration property in properties)
            {
                if (property.Type is OptionalTypeDeclaration)
                {
                    builder.AppendLine($"    if (this.{property.PropertyName} is {property.Type.GetFullyQualifiedName()} {property.FieldName})");
                    builder.AppendLine("    {");

                    builder.AppendLine($"        context = Menes.Validation.ValidateProperty(context, {property.FieldName}, {property.PathPropertyName});");

                    builder.AppendLine("    }");
                }
                else
                {
                    builder.AppendLine($"    context = Menes.Validation.ValidateRequiredProperty(context, this.{property.PropertyName}, {property.PathPropertyName});");
                }
            }

            if (this.AdditionalPropertiesType is ITypeDeclaration additionalProperties)
            {
                builder.AppendLine($"foreach (Menes.JsonPropertyReference<{additionalProperties.GetFullyQualifiedName()}> property in this.JsonAdditionalProperties)");
                builder.AppendLine("{");
                builder.AppendLine("string propertyName = property.Name;");

                if (hasPatternProperties)
                {
                    builder.AppendLine($"       var patternContext = this.ValidatePatternProperty(Menes.ValidationContext.Root, property.Name, property.AsValue(), \".\" + property.Name);");
                    builder.AppendLine("        if (patternContext.LastWasValid)");
                    builder.AppendLine("        {");
                    builder.AppendLine("            continue;");
                    builder.AppendLine("        }");
                }

                builder.AppendLine($"    context = Menes.Validation.ValidateProperty(context, property.AsValue(), \".\" + property.Name);");
                builder.AppendLine("}");
            }
            else
            {
                builder.AppendLine("if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)");
                builder.AppendLine("{");
                builder.AppendLine("int propCount = 0;");

                builder.AppendLine("var additionalPropertyEnumerator = this.JsonElement.EnumerateObject();");
                builder.AppendLine("while (additionalPropertyEnumerator.MoveNext())");
                builder.AppendLine("{");

                if (hasPatternProperties)
                {
                    builder.AppendLine($"       var patternContext = this.ValidatePatternProperty(Menes.ValidationContext.Root, additionalPropertyEnumerator.Current.Name, Menes.JsonAny.FromJsonElement(additionalPropertyEnumerator.Current.Value), \".\" + additionalPropertyEnumerator.Current.Name);");
                    builder.AppendLine("        if (patternContext.LastWasValid)");
                    builder.AppendLine("        {");
                    builder.AppendLine("            continue;");
                    builder.AppendLine("        }");
                }

                builder.AppendLine("    int increment = 1;");
                builder.AppendLine("    for (int i = 0; i < KnownProperties.Length; ++i)");
                builder.AppendLine("    {");
                builder.AppendLine("        if (additionalPropertyEnumerator.Current.NameEquals(KnownProperties[i].Span))");
                builder.AppendLine("        {");
                builder.AppendLine("            increment = 0;");
                builder.AppendLine("            break;");
                builder.AppendLine("        }");
                builder.AppendLine("    }");

                builder.AppendLine("    propCount += increment;");
                builder.AppendLine("    if (propCount > 0)");
                builder.AppendLine("    {");
                builder.AppendLine("        context = context.WithError(\"core 9.3.2.3. No additional properties were expected.\");");
                builder.AppendLine("        break;");
                builder.AppendLine("    }");
                builder.AppendLine("}");
                builder.AppendLine("}");
            }

            if (this.MinPropertiesValidation is int || this.MaxPropertiesValidation is int)
            {
                builder.AppendLine($"context = Menes.Validation.ValidateObject(context, this, {this.MaxPropertiesValidation?.ToString() ?? "null"}, {this.MinPropertiesValidation?.ToString() ?? "null"});");
            }

            if (this.RequiredPropertiesValidation is List<string> requiredPropertiesValidation)
            {
                builder.AppendLine("if (!this.HasJsonElement || IsConvertibleFrom(this.JsonElement))");
                builder.AppendLine("{");

                foreach (string requiredProperty in requiredPropertiesValidation)
                {
                    builder.AppendLine($"if(!this.TryGet({StringFormatter.EscapeForCSharpString(requiredProperty, true)}, out var _))");
                    builder.AppendLine("{");
                    builder.AppendLine("    context = context.WithError(\"6.5.3.required: The property was not present.\");");
                    builder.AppendLine("}");
                }

                builder.AppendLine("}");
            }

            if (!this.ValidateAsObject)
            {
                builder.AppendLine("}");
            }

            if (this.NotTypeValidation is ITypeDeclaration notType)
            {
                builder.AppendLine($"context = Menes.Validation.ValidateNot<{this.GetFullyQualifiedName()}, {notType.GetFullyQualifiedName()}>(context, this);");
            }

            if (this.AllOfTypeValidation is List<ITypeDeclaration> allOf)
            {
                for (int i = 0; i < allOf.Count; ++i)
                {
                    builder.AppendLine($"        Menes.ValidationContext allOfValidationContext{i + 1} = Menes.ValidationContext.Root.WithPath(context.Path);");
                }

                int index = 0;
                if (allOf.Count > 0)
                {
                    builder.AppendLine($"Menes.JsonAny thisAsAny = Menes.JsonAny.From(this);");
                }

                foreach (ITypeDeclaration allOfType in allOf)
                {
                    string allOfFullyQualifiedName = allOfType.GetFullyQualifiedName();
                    string allOfTypeNameCamelCase = StringFormatter.ToCamelCaseWithReservedWords(allOfType.Name);
                    builder.AppendLine($"{allOfFullyQualifiedName} {allOfTypeNameCamelCase}AllOfValue{index} = thisAsAny.As<{allOfFullyQualifiedName}>();");
                    builder.AppendLine($"            allOfValidationContext{index + 1} = {allOfTypeNameCamelCase}AllOfValue{index}.Validate(allOfValidationContext{index + 1});");
                    index++;
                }

                builder.Append("        context = Menes.Validation.ValidateAllOf(context");

                index = 0;
                foreach (ITypeDeclaration allOfType in allOf)
                {
                    builder.Append(", ");
                    builder.Append($"allOfValidationContext{index + 1}");
                    index++;
                }

                builder.AppendLine(");");
            }

            // If we have specified an explicit type for additional properties (including "JsonAny") then we must have visited all
            // of our properties already, so there won't be any unevaluated properties.
            // Further, if we don't have a JsonElement, there won't be any unevaluated properties.
            if ((this.UnevaluatedPropertiesType is ITypeDeclaration unevaluatedProperties) && (this.AdditionalPropertiesType is null || this.AdditionalPropertiesType is AnyTypeDeclaration || this.AdditionalPropertiesType == JsonValueTypeDeclaration.Any))
            {
                string unevaluatedFullyQualifiedName = unevaluatedProperties.GetFullyQualifiedName();

                builder.AppendLine("if (this.HasJsonElement)");
                builder.AppendLine("{");
                builder.AppendLine("    var unevaluatedPropertyEnumerator = this.JsonElement.EnumerateObject();");
                builder.AppendLine("    while (unevaluatedPropertyEnumerator.MoveNext())");
                builder.AppendLine("    {");
                builder.AppendLine("        string unevaluatedPropertyName = unevaluatedPropertyEnumerator.Current.Name;");

                if (hasPatternProperties)
                {
                    builder.AppendLine("        if (matchedProperties.Contains(unevaluatedPropertyName))");
                    builder.AppendLine("        {");
                    builder.AppendLine("            continue;");
                    builder.AppendLine("        }");
                }

                builder.AppendLine("    bool isKnown = false;");
                builder.AppendLine("    for (int i = 0; i < KnownProperties.Length; ++i)");
                builder.AppendLine("    {");
                builder.AppendLine("        if (unevaluatedPropertyEnumerator.Current.NameEquals(KnownProperties[i].Span))");
                builder.AppendLine("        {");
                builder.AppendLine("            isKnown = true;");
                builder.AppendLine("            break;");
                builder.AppendLine("        }");
                builder.AppendLine("    }");
                builder.AppendLine("    if (isKnown)");
                builder.AppendLine("    {");
                builder.AppendLine("        continue;");
                builder.AppendLine("    }");

                builder.AppendLine($"        if (!{unevaluatedFullyQualifiedName}.FromJsonElement(unevaluatedPropertyEnumerator.Current.Value).Validate(Menes.ValidationContext.Root).IsValid)");
                builder.AppendLine("        {");
                builder.AppendLine("            context = context.WithPath($\".{unevaluatedPropertyName}\").WithError(\"core 9.3.2.4.unevaluatedProperties: Property does not match unevaluated property validation\");");
                builder.AppendLine("        }");
                builder.AppendLine("    }");
                builder.AppendLine("}");
            }

            if (this.ConstValidation is string)
            {
                builder.AppendLine($"context = Menes.Validation.ValidateConst(context, this, this.ConstValue.AsValue<{this.GetFullyQualifiedName()}>());");
            }

            if (this.EnumValidation is string)
            {
                builder.AppendLine($"context = Menes.Validation.ValidateEnum(context, this, this.EnumValues.AsValue<Menes.JsonArray<{this.GetFullyQualifiedName()}>>());");
            }

            builder.AppendLine("    return context;");
            builder.AppendLine("}");
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildEquals(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"public bool Equals({this.GetFullyQualifiedName()} other)");
            builder.AppendLine("{");
            builder.AppendLine("    if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))");
            builder.AppendLine("    {");
            builder.AppendLine("        return false;");
            builder.AppendLine("    }");
            builder.AppendLine("    if (this.HasJsonElement && other.HasJsonElement)");
            builder.AppendLine("    {");
            builder.AppendLine("        return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));");
            builder.AppendLine("    }");
            builder.AppendLine($"    return {this.BuildEqualsForProperties(properties)};");
            builder.AppendLine("}");

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private string BuildEqualsForProperties(List<NamedPropertyDeclaration> properties)
        {
            var builder = new StringBuilder();

            foreach (NamedPropertyDeclaration property in properties)
            {
                if (builder.Length > 0)
                {
                    builder.Append(" && ");
                }

                builder.Append($"this.{property.PropertyName}.Equals(other.{property.PropertyName})");
            }

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                if (builder.Length > 0)
                {
                    builder.Append(" && ");
                }

                builder.Append("System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties)");
            }

            if (builder.Length == 0)
            {
                // There are no properties, so just compare true.
                builder.Append("true");
            }

            return builder.ToString();
        }

        private void BuildWriteTo(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            var builder = new StringBuilder("public void WriteTo(System.Text.Json.Utf8JsonWriter writer)");
            builder.AppendLine("{");
            builder.AppendLine("if (this.HasJsonElement)");
            builder.AppendLine("{");
            builder.AppendLine("this.JsonElement.WriteTo(writer);");
            builder.AppendLine("}");
            builder.AppendLine("else");
            builder.AppendLine("{");
            builder.AppendLine("writer.WriteStartObject();");

            foreach (NamedPropertyDeclaration property in properties)
            {
                string typename = property.Type.ContainsReference(this, new List<ITypeDeclaration>()) || property.Type.IsCompoundType ? "Menes.JsonReference" : property.Type.GetFullyQualifiedName();

                builder.AppendLine($"if (this.{property.FieldName} is {typename} {property.FieldName})");
                builder.AppendLine("{");
                builder.AppendLine($"    writer.WritePropertyName({property.EncodedPropertyName});");
                builder.AppendLine($"    {property.FieldName}.WriteTo(writer);");
                builder.AppendLine("}");
            }

            if (this.AdditionalPropertiesType is ITypeDeclaration additionalProperties)
            {
                builder.AppendLine($"Menes.JsonProperties<{additionalProperties.GetFullyQualifiedName()}>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;");
                builder.AppendLine("while (enumerator.MoveNext())");
                builder.AppendLine("{");
                builder.AppendLine("enumerator.Current.Write(writer);");
                builder.AppendLine("}");
            }

            builder.AppendLine("writer.WriteEndObject();");
            builder.AppendLine("}");
            builder.AppendLine("}");
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildFromOptionalFactories(List<MemberDeclarationSyntax> members)
        {
            string fullyQualifiedTypeName = this.GetFullyQualifiedName();

            var builder = new StringBuilder();

            builder.AppendLine($"public static {fullyQualifiedTypeName} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>");
            builder.AppendLine($"   parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?");
            builder.AppendLine("        (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? new {fullyQualifiedTypeName}(property)");
            builder.AppendLine("            : Null)");
            builder.AppendLine("        : Null;");
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
            builder.Clear();

            builder.AppendLine($"public static {fullyQualifiedTypeName} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>");
            builder.AppendLine($"   parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?");
            builder.AppendLine("        (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? new {fullyQualifiedTypeName}(property)");
            builder.AppendLine("            : Null)");
            builder.AppendLine("        : Null;");
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
            builder.Clear();

            builder.AppendLine($"public static {fullyQualifiedTypeName} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>");
            builder.AppendLine($"   parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?");
            builder.AppendLine("        (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? new {fullyQualifiedTypeName}(property)");
            builder.AppendLine("            : Null)");
            builder.AppendLine("    : Null;");
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildIsConvertibleFrom(List<MemberDeclarationSyntax> members)
        {
            var builder = new StringBuilder();
            builder.AppendLine("public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)");
            builder.AppendLine("{");
            builder.AppendLine("    return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;");
            builder.AppendLine("}");

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildAdditionalPropertiesAccessor(List<MemberDeclarationSyntax> members)
        {
            if (!(this.AdditionalPropertiesType is ITypeDeclaration additionalProperties))
            {
                return;
            }

            string declaration =
                $"public Menes.JsonProperties<{additionalProperties.GetFullyQualifiedName()}>.JsonPropertyEnumerator JsonAdditionalProperties" + Environment.NewLine +
                "{" + Environment.NewLine +
                "    get" + Environment.NewLine +
                "    {" + Environment.NewLine +
                $"        if (this.additionalPropertiesBacking is Menes.JsonProperties<{additionalProperties.GetFullyQualifiedName()}> ap)" + Environment.NewLine +
                "        {" + Environment.NewLine +
                $"            return new Menes.JsonProperties<{additionalProperties.GetFullyQualifiedName()}>.JsonPropertyEnumerator(ap, KnownProperties);" + Environment.NewLine +
                "        }" + Environment.NewLine +
                Environment.NewLine +
                "        if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)" + Environment.NewLine +
                "        {" + Environment.NewLine +
                $"            return new Menes.JsonProperties<{additionalProperties.GetFullyQualifiedName()}>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);" + Environment.NewLine +
                "        }" + Environment.NewLine +
                Environment.NewLine +
                $"        return new Menes.JsonProperties<{additionalProperties.GetFullyQualifiedName()}>.JsonPropertyEnumerator(Menes.JsonProperties<{additionalProperties.GetFullyQualifiedName()}>.Empty, KnownProperties);" + Environment.NewLine +
                "    }" + Environment.NewLine +
                "}" + Environment.NewLine;

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private void BuildJsonElementAccessors(List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration("public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;" + Environment.NewLine));
            members.Add(SF.ParseMemberDeclaration("public System.Text.Json.JsonElement JsonElement { get; }" + Environment.NewLine));
        }

        private void BuildPropertyCountAccessors(List<MemberDeclarationSyntax> members)
        {
            if (this.AdditionalPropertiesType is ITypeDeclaration additionalProperties)
            {
                members.Add(SF.ParseMemberDeclaration("public int PropertiesCount => KnownProperties.Length + this.JsonAdditionalPropertiesCount;" + Environment.NewLine));

                string declaration =
                    "public int JsonAdditionalPropertiesCount" + Environment.NewLine +
                    "{" + Environment.NewLine +
                    "    get" + Environment.NewLine +
                    "    {" + Environment.NewLine +
                    $"        Menes.JsonProperties<{additionalProperties.GetFullyQualifiedName()}>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;" + Environment.NewLine +
                    "        int count = 0;" + Environment.NewLine +
                    Environment.NewLine +
                    "        while (enumerator.MoveNext())" + Environment.NewLine +
                    "        {" + Environment.NewLine +
                    "            count++;" + Environment.NewLine +
                    "        }" + Environment.NewLine +
                    Environment.NewLine +
                    "        return count;" + Environment.NewLine +
                    "    }" + Environment.NewLine +
                    "}" + Environment.NewLine;

                members.Add(SF.ParseMemberDeclaration(declaration));
            }
            else
            {
                members.Add(SF.ParseMemberDeclaration("public int PropertiesCount => KnownProperties.Length;" + Environment.NewLine));
            }
        }

        private void BuildAsOptionalAccessor(List<MemberDeclarationSyntax> members)
        {
            string? typeName = this.GetFullyQualifiedName();
            members.Add(SF.ParseMemberDeclaration($"public {typeName}? AsOptional => this.IsNull ? default({typeName}?) : this;" + Environment.NewLine));
        }

        private void BuildIsNullAccessor(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            var builder = new StringBuilder("public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null)");
            foreach (NamedPropertyDeclaration property in properties)
            {
                builder.Append(" && ");
                builder.Append($"(this.{property.FieldName} is null || this.{property.FieldName}.Value.IsNull)");
            }

            builder.Append(";" + Environment.NewLine);
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildAdditionalPropertiesBacking(List<MemberDeclarationSyntax> members)
        {
            if (!(this.AdditionalPropertiesType is ITypeDeclaration additionalProperties))
            {
                return;
            }

            members.Add(SF.ParseMemberDeclaration($"private readonly Menes.JsonProperties<{additionalProperties.GetFullyQualifiedName()}>? additionalPropertiesBacking;" + Environment.NewLine));
        }

        private void BuildConstructors(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            // public
            this.BuildJsonElementConstructor(properties, members);

            this.BuildPropertiesConstructors(properties, members);

            // private
            this.BuildCloningConstructor(properties, members);
        }

        private void BuildPropertiesConstructors(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            this.BuildPropertiesConstructor(properties, members, null, true);

            if (this.AdditionalPropertiesType is null)
            {
                this.BuildPropertiesConstructor(properties, members, null);
            }
            else
            {
                // Build all the variants.
                this.BuildPropertiesConstructor(properties, members, null);
                this.BuildPropertiesConstructor(properties, members, -1);
                this.BuildPropertiesConstructor(properties, members, 0);
                this.BuildPropertiesConstructor(properties, members, 1);
                this.BuildPropertiesConstructor(properties, members, 2);
                this.BuildPropertiesConstructor(properties, members, 3);
                this.BuildPropertiesConstructor(properties, members, 4);
            }
        }

        private void BuildCloningConstructor(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            if (properties.Any(p => p.Type.ContainsReference(this, new List<ITypeDeclaration>()) || p.Type.IsCompoundType) || (this.AdditionalPropertiesType is ITypeDeclaration t))
            {
                string declaration =
                $"private {this.Name}({this.BuildCloningConstructorParameterList(properties)})" + Environment.NewLine +
                "{" + Environment.NewLine +
                this.BuildCloningConstructorParameterSetters(properties) +
                " }" + Environment.NewLine;

                members.Add(SF.ParseMemberDeclaration(declaration));
            }
        }

        private string BuildCloningConstructorParameterSetters(List<NamedPropertyDeclaration> properties)
        {
            var builder = new StringBuilder();
            int index = 1;
            foreach (NamedPropertyDeclaration property in properties)
            {
                if (property.Type.ContainsReference(this, new List<ITypeDeclaration>()) || property.Type.IsCompoundType)
                {
                    builder.AppendLine($"if ({property.FieldName} is Menes.JsonReference item{index})");
                    builder.AppendLine("{");
                    builder.AppendLine($"this.{property.FieldName} = item{index};");
                    builder.AppendLine("}");
                    builder.AppendLine("else");
                    builder.AppendLine("{");
                    builder.AppendLine($"this.{property.FieldName} = null;");
                    builder.AppendLine("}");
                    index++;
                }
                else
                {
                    builder.AppendLine($"this.{property.FieldName} = {property.FieldName};");
                }
            }

            builder.AppendLine("this.JsonElement = default;");

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                builder.AppendLine("this.additionalPropertiesBacking = additionalPropertiesBacking;");
            }

            return builder.ToString();
        }

        private string BuildCloningConstructorParameterList(List<NamedPropertyDeclaration> properties)
        {
            var builder = new StringBuilder();

            var optionalProperties = new List<NamedPropertyDeclaration>();
            var requiredProperties = new List<NamedPropertyDeclaration>();
            foreach (NamedPropertyDeclaration property in properties)
            {
                if (property.Type is OptionalTypeDeclaration)
                {
                    optionalProperties.Add(property);
                }
                else
                {
                    requiredProperties.Add(property);
                }
            }

            foreach (NamedPropertyDeclaration property in requiredProperties)
            {
                this.BuildCloningConstructorParameter(property, builder, false);
            }

            foreach (NamedPropertyDeclaration property in optionalProperties)
            {
                this.BuildCloningConstructorParameter(property, builder, true);
            }

            if (this.AdditionalPropertiesType is ITypeDeclaration additionalProperties)
            {
                if (builder.Length > 0)
                {
                    builder.Append(", ");
                }

                builder.Append($"Menes.JsonProperties<{additionalProperties.GetFullyQualifiedName()}>? additionalPropertiesBacking");
            }

            return builder.ToString();
        }

        private void BuildPropertiesConstructor(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members, int? additionalPropertiesCount, bool requiredOnly = false)
        {
            bool hasAdditionalProperties = !(this.AdditionalPropertiesType is null);
            if (properties.Count == 0)
            {
                if (!hasAdditionalProperties || (additionalPropertiesCount is int apc && apc == 0) || additionalPropertiesCount is null)
                {
                    return;
                }
            }

            var optionalProperties = new List<NamedPropertyDeclaration>();
            var requiredProperties = new List<NamedPropertyDeclaration>();

            this.BuildOptionalAndRequiredProperties(properties, optionalProperties, requiredProperties);

            if (requiredOnly && requiredProperties.Count == 0)
            {
                if (!hasAdditionalProperties || (additionalPropertiesCount is int apc && apc == 0) || additionalPropertiesCount is null)
                {
                    return;
                }
            }

            if (!requiredOnly && optionalProperties.Count == 0)
            {
                if (!hasAdditionalProperties || (additionalPropertiesCount is int apc && apc == 0) || additionalPropertiesCount is null)
                {
                    return;
                }
            }

            var builder = new StringBuilder();
            builder.AppendLine($"public {this.Name}({this.BuildPropertiesConstructorParameterList(optionalProperties, requiredProperties, additionalPropertiesCount, requiredOnly)})");
            builder.AppendLine("{");
            builder.Append(this.BuildPropertiesConstructorParameterSetters(properties, additionalPropertiesCount, requiredOnly));
            builder.AppendLine("}");

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private string BuildPropertiesConstructorParameterSetters(List<NamedPropertyDeclaration> properties, int? additionalPropertiesCount, bool requiredOnly = false)
        {
            var builder = new StringBuilder();
            int index = 1;
            foreach (NamedPropertyDeclaration property in properties)
            {
                if (property.Type is OptionalTypeDeclaration && requiredOnly)
                {
                    builder.AppendLine($"this.{property.FieldName} = null;");
                }
                else if (property.Type.ContainsReference(this, new List<ITypeDeclaration>()) || property.Type.IsCompoundType)
                {
                    string fullyQualifiedTypeName = property.Type.GetFullyQualifiedName();
                    builder.AppendLine($"if ({property.FieldName} is {fullyQualifiedTypeName} item{index})");
                    builder.AppendLine("{");
                    builder.AppendLine($"this.{property.FieldName} = Menes.JsonReference.FromValue(item{index});");
                    builder.AppendLine("}");
                    builder.AppendLine("else");
                    builder.AppendLine("{");
                    builder.AppendLine($"this.{property.FieldName} = null;");
                    builder.AppendLine("}");
                    index++;
                }
                else
                {
                    builder.AppendLine($"this.{property.FieldName} = {property.FieldName};");
                }
            }

            builder.AppendLine("this.JsonElement = default;");

            if (this.AdditionalPropertiesType is ITypeDeclaration additionalProperties)
            {
                if (requiredOnly)
                {
                    builder.AppendLine("this.additionalPropertiesBacking = null;");
                }
                else if (additionalPropertiesCount is null)
                {
                    builder.AppendLine("this.additionalPropertiesBacking = additionalPropertiesBacking;");
                }
                else if (additionalPropertiesCount == -1)
                {
                    builder.AppendLine($"this.additionalPropertiesBacking = Menes.JsonProperties<{additionalProperties.GetFullyQualifiedName()}>.FromValues(additionalPropertiesBacking);");
                }
                else if (additionalPropertiesCount == 0)
                {
                    builder.AppendLine("this.additionalPropertiesBacking = null;");
                }
                else
                {
                    builder.Append($"this.additionalPropertiesBacking = Menes.JsonProperties<{additionalProperties.GetFullyQualifiedName()}>.FromValues(");
                    for (int i = 0; i < additionalPropertiesCount; ++i)
                    {
                        if (i > 0)
                        {
                            builder.Append(", ");
                        }

                        builder.Append($"additionalProperty{i + 1}");
                    }

                    builder.AppendLine(");");
                }
            }

            return builder.ToString();
        }

        private string BuildPropertiesConstructorParameterList(IList<NamedPropertyDeclaration> optionalProperties, IList<NamedPropertyDeclaration> requiredProperties, int? additionalPropertiesCount, bool requiredOnly = false)
        {
            var builder = new StringBuilder();

            foreach (NamedPropertyDeclaration property in requiredProperties)
            {
                this.BuildPropertiesConstructorParameter(property, builder, false, false);
            }

            if (!requiredOnly)
            {
                bool allowDefaultNull = false;

                if (this.AdditionalPropertiesType is null || (additionalPropertiesCount.HasValue && additionalPropertiesCount.Value == 0))
                {
                    allowDefaultNull = true;
                }

                foreach (NamedPropertyDeclaration property in optionalProperties)
                {
                    this.BuildPropertiesConstructorParameter(property, builder, true, allowDefaultNull);
                }

                if (this.AdditionalPropertiesType is ITypeDeclaration additionalPropertiesType)
                {
                    this.BuildPropertiesConstructorAdditionalPropertiesParameter(additionalPropertiesType, builder, additionalPropertiesCount);
                }
            }

            return builder.ToString();
        }

        private void BuildOptionalAndRequiredProperties(List<NamedPropertyDeclaration> properties, List<NamedPropertyDeclaration> optionalProperties, List<NamedPropertyDeclaration> requiredProperties)
        {
            foreach (NamedPropertyDeclaration property in properties)
            {
                if (property.Type is OptionalTypeDeclaration)
                {
                    optionalProperties.Add(property);
                }
                else
                {
                    requiredProperties.Add(property);
                }
            }
        }

        private void BuildPropertiesConstructorAdditionalPropertiesParameter(ITypeDeclaration additionalPropertiesType, StringBuilder builder, int? additionalPropertiesCount)
        {
            if (additionalPropertiesCount is null)
            {
                if (builder.Length > 0)
                {
                    builder.Append(", ");
                }

                builder.Append($"Menes.JsonProperties<{additionalPropertiesType.GetFullyQualifiedName()}> additionalPropertiesBacking");
            }
            else if (additionalPropertiesCount == -1)
            {
                if (builder.Length > 0)
                {
                    builder.Append(", ");
                }

                builder.Append($"params (string, {additionalPropertiesType.GetFullyQualifiedName()})[] additionalPropertiesBacking");
            }
            else
            {
                for (int i = 0; i < additionalPropertiesCount; ++i)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append(", ");
                    }

                    builder.Append($"(string, {additionalPropertiesType.GetFullyQualifiedName()}) additionalProperty{i + 1}");
                }
            }
        }

        private void BuildPropertiesConstructorParameter(NamedPropertyDeclaration property, StringBuilder builder, bool isOptional, bool allowDefaultNull)
        {
            if (builder.Length > 0)
            {
                builder.Append(", ");
            }

            builder.Append(property.Type.GetFullyQualifiedName());

            if (isOptional)
            {
                builder.Append("?");
            }

            builder.Append(" ");
            builder.Append(property.FieldName);
            if (isOptional)
            {
                if (allowDefaultNull)
                {
                    builder.Append(" = null");
                }
            }
        }

        private void BuildCloningConstructorParameter(NamedPropertyDeclaration property, StringBuilder builder, bool isOptional)
        {
            if (builder.Length > 0)
            {
                builder.Append(", ");
            }

            if (property.Type.ContainsReference(this, new List<ITypeDeclaration>()) || property.Type.IsCompoundType)
            {
                builder.Append("Menes.JsonReference");
            }
            else
            {
                builder.Append(property.Type.GetFullyQualifiedName());
            }

            if (isOptional)
            {
                builder.Append("?");
            }

            builder.Append(" ");
            builder.Append(property.FieldName);
        }

        private void BuildJsonElementConstructor(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"public {this.Name}(System.Text.Json.JsonElement jsonElement)");
            builder.AppendLine("{");
            builder.AppendLine("    this.JsonElement = jsonElement;");
            builder.Append(this.BuildNullFieldAssignments(properties));
            builder.AppendLine("}");

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private string BuildNullFieldAssignments(List<NamedPropertyDeclaration> properties)
        {
            var builder = new StringBuilder();

            foreach (NamedPropertyDeclaration property in properties)
            {
                builder.AppendLine($"this.{property.FieldName} = null;");
            }

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                builder.AppendLine("this.additionalPropertiesBacking = null;");
            }

            return builder.ToString();
        }

        private void BuildJsonReferenceAccessors(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            foreach (NamedPropertyDeclaration property in properties)
            {
                this.BuildJsonReferenceAccessor(property, members);
            }
        }

        private void BuildWithPropertyFactories(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            foreach (NamedPropertyDeclaration property in properties)
            {
                this.BuildWithPropertyFactory(properties, property, members);
            }

            this.BuildReplaceAllAdditionalPropertiesFactories(properties, members);
            this.BuildAddAdditionalPropertiesFactories(properties, members);
            this.BuildRemoveAdditionalPropertiesFactories(properties, members);
        }

        private void BuildReplaceAllAdditionalPropertiesFactories(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            if (this.AdditionalPropertiesType is ITypeDeclaration additionalPropertiesType)
            {
                string fullyQualifiedAdditionalPropertiesName = additionalPropertiesType.GetFullyQualifiedName();
                string fullyQualifiedName = this.GetFullyQualifiedName();
                this.BuildReplaceAllAdditionalPropertiesFactory(properties, fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, null);
                this.BuildReplaceAllAdditionalPropertiesFactory(properties, fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, -1);
                this.BuildReplaceAllAdditionalPropertiesFactory(properties, fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 1);
                this.BuildReplaceAllAdditionalPropertiesFactory(properties, fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 2);
                this.BuildReplaceAllAdditionalPropertiesFactory(properties, fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 3);
                this.BuildReplaceAllAdditionalPropertiesFactory(properties, fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 4);
            }
        }

        private void BuildAddAdditionalPropertiesFactories(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            if (this.AdditionalPropertiesType is ITypeDeclaration additionalPropertiesType)
            {
                string fullyQualifiedAdditionalPropertiesName = additionalPropertiesType.GetFullyQualifiedName();
                string fullyQualifiedName = this.GetFullyQualifiedName();
                this.BuildAddAdditionalPropertiesFactory(properties, fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, -1);
                this.BuildAddAdditionalPropertiesFactory(properties, fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 1);
                this.BuildAddAdditionalPropertiesFactory(properties, fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 2);
                this.BuildAddAdditionalPropertiesFactory(properties, fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 3);
                this.BuildAddAdditionalPropertiesFactory(properties, fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 4);
            }
        }

        private void BuildRemoveAdditionalPropertiesFactories(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            if (this.AdditionalPropertiesType is ITypeDeclaration additionalPropertiesType)
            {
                string fullyQualifiedAdditionalPropertiesName = additionalPropertiesType.GetFullyQualifiedName();
                string fullyQualifiedName = this.GetFullyQualifiedName();
                this.BuildRemoveAdditionalPropertiesFactory(properties, fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, -1);
                this.BuildRemoveAdditionalPropertiesFactory(properties, fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 1);
                this.BuildRemoveAdditionalPropertiesFactory(properties, fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 2);
                this.BuildRemoveAdditionalPropertiesFactory(properties, fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 3);
                this.BuildRemoveAdditionalPropertiesFactory(properties, fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 4);
                this.BuildRemoveIfAdditionalPropertiesFactory(properties, fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members);
            }
        }

        private void BuildReplaceAllAdditionalPropertiesFactory(List<NamedPropertyDeclaration> properties, string fullyQualifiedName, string fullyQualifiedAdditionalPropertiesName, List<MemberDeclarationSyntax> members, int? additionalPropertiesCount)
        {
            var builder = new StringBuilder($"public {fullyQualifiedName} ReplaceAll(");
            if (additionalPropertiesCount is null)
            {
                builder.AppendLine($"Menes.JsonProperties<{fullyQualifiedAdditionalPropertiesName}> newAdditional)");
                builder.AppendLine("{");
                builder.Append($"return new {fullyQualifiedName}( ");
                this.AppendWithParametersCoreForAdditionalProperties(properties, builder);
                builder.AppendLine("newAdditional);");
                builder.AppendLine("}");
            }
            else if (additionalPropertiesCount == -1)
            {
                builder.AppendLine($"params (string, {fullyQualifiedAdditionalPropertiesName})[] newAdditional)");
                builder.AppendLine("{");
                builder.Append($"return new {fullyQualifiedName}( ");
                this.AppendWithParametersCoreForAdditionalProperties(properties, builder);
                builder.AppendLine($"Menes.JsonProperties<{fullyQualifiedAdditionalPropertiesName}>.FromValues(newAdditional));");
                builder.AppendLine("}");
            }
            else
            {
                for (int i = 0; i < additionalPropertiesCount; ++i)
                {
                    if (i > 0)
                    {
                        builder.Append(", ");
                    }

                    builder.Append($"(string, {fullyQualifiedAdditionalPropertiesName}) newAdditional{i + 1}");
                }

                builder.AppendLine($")");
                builder.AppendLine("{");
                builder.Append($"return new {fullyQualifiedName}( ");
                this.AppendWithParametersCoreForAdditionalProperties(properties, builder);
                builder.Append($"Menes.JsonProperties<{fullyQualifiedAdditionalPropertiesName}>.FromValues(");
                for (int i = 0; i < additionalPropertiesCount; ++i)
                {
                    if (i > 0)
                    {
                        builder.Append(", ");
                    }

                    builder.Append($"newAdditional{i + 1}");
                }

                builder.AppendLine("));");
                builder.AppendLine("}");
            }

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildRemoveIfAdditionalPropertiesFactory(List<NamedPropertyDeclaration> properties, string fullyQualifiedName, string fullyQualifiedAdditionalPropertiesName, List<MemberDeclarationSyntax> members)
        {
            var builder = new StringBuilder($"public {fullyQualifiedName} Remove(");
            builder.AppendLine($"System.Predicate<Menes.JsonPropertyReference<{fullyQualifiedAdditionalPropertiesName}>> removeIfTrue)");
            builder.AppendLine("{");
            builder.AppendLine($"System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<{fullyQualifiedAdditionalPropertiesName}>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<{fullyQualifiedAdditionalPropertiesName}>>();");
            builder.AppendLine($"foreach (Menes.JsonPropertyReference<{fullyQualifiedAdditionalPropertiesName}> property in this.JsonAdditionalProperties)");
            builder.AppendLine("{");
            builder.AppendLine($"   if (!removeIfTrue(property))");
            builder.AppendLine("    {");
            builder.AppendLine($"       arrayBuilder.Add(property);");
            builder.AppendLine("    }");
            builder.AppendLine("}");

            builder.Append($"return new {fullyQualifiedName}( ");
            this.AppendWithParametersCoreForAdditionalProperties(properties, builder);
            builder.AppendLine($"new Menes.JsonProperties<{fullyQualifiedAdditionalPropertiesName}>(arrayBuilder.ToImmutable()));");
            builder.AppendLine("}");
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildRemoveAdditionalPropertiesFactory(List<NamedPropertyDeclaration> properties, string fullyQualifiedName, string fullyQualifiedAdditionalPropertiesName, List<MemberDeclarationSyntax> members, int additionalPropertiesCount)
        {
            var builder = new StringBuilder($"public {fullyQualifiedName} Remove(");
            if (additionalPropertiesCount == -1)
            {
                builder.AppendLine($"params string[] namesToRemove)");
                builder.AppendLine("{");
                builder.AppendLine("System.Collections.Immutable.ImmutableHashSet<string> ihs = System.Collections.Immutable.ImmutableHashSet.Create<string>(namesToRemove);");
                builder.AppendLine($"System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<{fullyQualifiedAdditionalPropertiesName}>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<{fullyQualifiedAdditionalPropertiesName}>>();");
                builder.AppendLine($"foreach (Menes.JsonPropertyReference<{fullyQualifiedAdditionalPropertiesName}> property in this.JsonAdditionalProperties)");
                builder.AppendLine("{");
                builder.AppendLine($"   if (!ihs.Contains(property.Name))");
                builder.AppendLine("    {");
                builder.AppendLine($"       arrayBuilder.Add(property);");
                builder.AppendLine("    }");
                builder.AppendLine("}");

                builder.Append($"return new {fullyQualifiedName}( ");
                this.AppendWithParametersCoreForAdditionalProperties(properties, builder);
                builder.AppendLine($"new Menes.JsonProperties<{fullyQualifiedAdditionalPropertiesName}>(arrayBuilder.ToImmutable()));");
                builder.AppendLine("}");
            }
            else
            {
                for (int i = 0; i < additionalPropertiesCount; ++i)
                {
                    if (i > 0)
                    {
                        builder.Append(", ");
                    }

                    builder.Append($"string itemToRemove{i + 1}");
                }

                builder.AppendLine($")");
                builder.AppendLine("{");

                builder.AppendLine("System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();");

                for (int i = 0; i < additionalPropertiesCount; ++i)
                {
                    builder.Append($"ihsBuilder.Add(itemToRemove{i + 1});");
                }

                builder.AppendLine("System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();");

                builder.AppendLine($"System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<{fullyQualifiedAdditionalPropertiesName}>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<{fullyQualifiedAdditionalPropertiesName}>>();");
                builder.AppendLine($"foreach (Menes.JsonPropertyReference<{fullyQualifiedAdditionalPropertiesName}> property in this.JsonAdditionalProperties)");
                builder.AppendLine("{");
                builder.AppendLine($"   if (!ihs.Contains(property.Name))");
                builder.AppendLine("    {");
                builder.AppendLine($"       arrayBuilder.Add(property);");
                builder.AppendLine("    }");
                builder.AppendLine("}");

                builder.Append($"return new {fullyQualifiedName}( ");
                this.AppendWithParametersCoreForAdditionalProperties(properties, builder);
                builder.AppendLine($"new Menes.JsonProperties<{fullyQualifiedAdditionalPropertiesName}>(arrayBuilder.ToImmutable()));");
                builder.AppendLine("}");
            }

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildAddAdditionalPropertiesFactory(List<NamedPropertyDeclaration> properties, string fullyQualifiedName, string fullyQualifiedAdditionalPropertiesName, List<MemberDeclarationSyntax> members, int additionalPropertiesCount)
        {
            var builder = new StringBuilder($"public {fullyQualifiedName} Add(");
            if (additionalPropertiesCount == -1)
            {
                builder.AppendLine($"params (string, {fullyQualifiedAdditionalPropertiesName})[] newAdditional)");
                builder.AppendLine("{");

                builder.AppendLine($"System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<{fullyQualifiedAdditionalPropertiesName}>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<{fullyQualifiedAdditionalPropertiesName}>>();");
                builder.AppendLine($"foreach (Menes.JsonPropertyReference<{fullyQualifiedAdditionalPropertiesName}> property in this.JsonAdditionalProperties)");
                builder.AppendLine("{");
                builder.AppendLine($"   arrayBuilder.Add(property);");
                builder.AppendLine("}");
                builder.AppendLine($"foreach ((string name, {fullyQualifiedAdditionalPropertiesName} value) in newAdditional)");
                builder.AppendLine("{");
                builder.AppendLine($"   arrayBuilder.Add(Menes.JsonPropertyReference<{fullyQualifiedAdditionalPropertiesName}>.From(name, value));");
                builder.AppendLine("}");

                builder.Append($"return new {fullyQualifiedName}( ");
                this.AppendWithParametersCoreForAdditionalProperties(properties, builder);
                builder.AppendLine($"new Menes.JsonProperties<{fullyQualifiedAdditionalPropertiesName}>(arrayBuilder.ToImmutable()));");
                builder.AppendLine("}");
            }
            else
            {
                for (int i = 0; i < additionalPropertiesCount; ++i)
                {
                    if (i > 0)
                    {
                        builder.Append(", ");
                    }

                    builder.Append($"(string name, {fullyQualifiedAdditionalPropertiesName} value) newAdditional{i + 1}");
                }

                builder.AppendLine($")");
                builder.AppendLine("{");

                builder.AppendLine($"System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<{fullyQualifiedAdditionalPropertiesName}>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<{fullyQualifiedAdditionalPropertiesName}>>();");
                builder.AppendLine($"foreach (Menes.JsonPropertyReference<{fullyQualifiedAdditionalPropertiesName}> property in this.JsonAdditionalProperties)");
                builder.AppendLine("{");
                builder.AppendLine($"   arrayBuilder.Add(property);");
                builder.AppendLine("}");

                for (int i = 0; i < additionalPropertiesCount; ++i)
                {
                    builder.Append($"arrayBuilder.Add(Menes.JsonPropertyReference<{fullyQualifiedAdditionalPropertiesName}>.From(newAdditional{i + 1}.name, newAdditional{i + 1}.value));");
                }

                builder.Append($"return new {fullyQualifiedName}( ");
                this.AppendWithParametersCoreForAdditionalProperties(properties, builder);
                builder.AppendLine($"new Menes.JsonProperties<{fullyQualifiedAdditionalPropertiesName}>(arrayBuilder.ToImmutable()));");
                builder.AppendLine("}");
            }

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void AppendWithParametersCoreForAdditionalProperties(List<NamedPropertyDeclaration> properties, StringBuilder builder)
        {
            string core = this.BuildWithParametersCore(properties, null);
            builder.Append(core);
            if (core.Length > 0)
            {
                builder.Append(", ");
            }
        }

        private void BuildPropertyAccessors(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            foreach (NamedPropertyDeclaration property in properties)
            {
                this.BuildPropertyAccessor(property, members);
            }
        }

        private void BuildJsonElementFactory(List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration($"public static readonly System.Func<System.Text.Json.JsonElement, {this.GetFullyQualifiedName()}> FromJsonElement = e => new {this.GetFullyQualifiedName()}(e);" + Environment.NewLine));
        }

        private void BuildNullAccessor(List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration($"public static readonly {this.GetFullyQualifiedName()} Null = new {this.GetFullyQualifiedName()}(default(System.Text.Json.JsonElement));" + Environment.NewLine));
        }

        private List<NamedPropertyDeclaration> BuildNamedPropertyDeclarations()
        {
            var result = new List<NamedPropertyDeclaration>();
            var propertyNames = new HashSet<string>();

            foreach (PropertyDeclaration property in this.Properties)
            {
                string basePropertyName = StringFormatter.ToPascalCaseWithReservedWords(property.JsonPropertyName);
                string propertyName = basePropertyName;
                int index = 1;
                while (propertyNames.Contains(propertyName) || propertyName == this.Name)
                {
                    propertyName = basePropertyName + index;
                    ++index;
                }

                propertyNames.Add(propertyName);
                result.Add(new NamedPropertyDeclaration(propertyName, property));
            }

            return result;
        }

        private void BuildPropertyBackings(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            this.BuildPropertyNamePathDeclarations(properties, members);
            this.BuildPropertyNameBytesDeclarations(properties, members);
            this.BuildEncodedPropertyNameDeclarations(properties, members);

            this.AddKnownProperties(properties, members);

            this.BuildPropertyBackingDeclarations(properties, members);
        }

        private void BuildPropertyBackingDeclarations(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            foreach (NamedPropertyDeclaration property in properties)
            {
                this.BuildPropertyBackingDeclaration(property, members);
            }
        }

        private void BuildPropertyNamePathDeclarations(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            foreach (NamedPropertyDeclaration property in properties)
            {
                this.BuildPropertyNamePathDeclaration(property, members);
            }
        }

        private void BuildEncodedPropertyNameDeclarations(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            foreach (NamedPropertyDeclaration property in properties)
            {
                this.BuildEncodedPropertyNameDeclaration(property, members);
            }
        }

        private void BuildPropertyNameBytesDeclarations(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            foreach (NamedPropertyDeclaration property in properties)
            {
                this.BuildPropertyNameBytesDeclaration(property, members);
            }
        }

        private void AddKnownProperties(List<NamedPropertyDeclaration> properties, List<MemberDeclarationSyntax> members)
        {
            if (properties.Count > 0)
            {
                string knownPropertiesList = string.Join(", ", properties.Select(n => n.BytesPropertyName));
                members.Add(SF.ParseMemberDeclaration($"private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create({knownPropertiesList});" + Environment.NewLine));
            }
            else
            {
                members.Add(SF.ParseMemberDeclaration($"private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>>.Empty;" + Environment.NewLine));
            }
        }

        private void BuildJsonReferenceAccessor(NamedPropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            if (!(property.Type.ContainsReference(this, new List<ITypeDeclaration>()) || property.Type.IsCompoundType))
            {
                return;
            }

            var builder = new StringBuilder();

            if (property.Type is OptionalTypeDeclaration)
            {
                builder.AppendLine($"private Menes.JsonReference? Get{property.PropertyName}()");
            }
            else
            {
                builder.AppendLine($"private Menes.JsonReference Get{property.PropertyName}()");
            }

            builder.AppendLine("{");
            builder.AppendLine($"    if (this.{property.FieldName} is Menes.JsonReference reference)");
            builder.AppendLine("    {");
            builder.AppendLine($"        return reference;");
            builder.AppendLine("    }");
            builder.AppendLine($"    if (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object && this.JsonElement.TryGetProperty({property.BytesPropertyName}.Span, out System.Text.Json.JsonElement value))");
            builder.AppendLine("    {");
            builder.AppendLine("        return new Menes.JsonReference(value);");
            builder.AppendLine("    }");
            builder.AppendLine("    return default;");
            builder.AppendLine("}");

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildJsonPropertiesAccessor(List<MemberDeclarationSyntax> members)
        {
            if (!(this.AdditionalPropertiesType is ITypeDeclaration additionalProperties))
            {
                return;
            }

            var builder = new StringBuilder();
            builder.AppendLine($"private Menes.JsonProperties<{additionalProperties.GetFullyQualifiedName()}> GetJsonProperties()");
            builder.AppendLine("{");
            builder.AppendLine($"    if (this.additionalPropertiesBacking is Menes.JsonProperties<{additionalProperties.GetFullyQualifiedName()}> props)");
            builder.AppendLine("    {");
            builder.AppendLine("        return props;");
            builder.AppendLine("    }");
            builder.AppendLine($"    return new Menes.JsonProperties<{additionalProperties.GetFullyQualifiedName()}>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));");
            builder.AppendLine("}");

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildValidatePatternPropertyRegularExpressions(List<MemberDeclarationSyntax> members)
        {
            if (!(this.PatternPropertiesValidation is List<(string regex, ITypeDeclaration typeDeclaration)> patternProperties))
            {
                return;
            }

            int patternIndex = 0;
            foreach ((string regex, ITypeDeclaration typeDeclaration) in patternProperties)
            {
                var builder = new StringBuilder();
                builder.AppendLine($"private static readonly System.Text.RegularExpressions.Regex PatternPropertyRegex{patternIndex} = new System.Text.RegularExpressions.Regex({StringFormatter.EscapeForCSharpString(regex, true)}, System.Text.RegularExpressions.RegexOptions.Compiled);");
                patternIndex++;
                members.Add(SF.ParseMemberDeclaration(builder.ToString()));
            }
        }

        private void BuildValidatePatternProperty(List<MemberDeclarationSyntax> members)
        {
            if (!(this.PatternPropertiesValidation is List<(string regex, ITypeDeclaration typeDeclaration)> patternProperties))
            {
                return;
            }

            var builder = new StringBuilder();
            builder.AppendLine($"private Menes.ValidationContext ValidatePatternProperty<TItem>(in Menes.ValidationContext validationContext, string propertyName, in TItem value, string propertyPathToAppend)");
            builder.AppendLine($"   where TItem : struct, IJsonValue");
            builder.AppendLine("{");
            builder.AppendLine("    var anyValue = Menes.JsonAny.From(value);");

            int patternIndex = 0;
            foreach ((string _, ITypeDeclaration typeDeclaration) in patternProperties)
            {
                builder.AppendLine($"if (PatternPropertyRegex{patternIndex}.IsMatch(propertyName) && anyValue.As<{typeDeclaration.GetFullyQualifiedName()}>().Validate(Menes.ValidationContext.Root).IsValid)");
                builder.AppendLine("{");
                builder.AppendLine("    return validationContext;");
                builder.AppendLine("}");
            }

            builder.AppendLine("return validationContext.WithError(\"core 9.3.2.2. patternProperties: Unable to match any of the provided patternProperties.\");");

            builder.AppendLine("}");

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildWithPropertyFactory(List<NamedPropertyDeclaration> properties, NamedPropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            string optionalQualifier = property.Type is OptionalTypeDeclaration ? "?" : string.Empty;
            string fullyQualifiedName = this.GetFullyQualifiedName();
            var builder = new StringBuilder();
            builder.AppendLine($" public {fullyQualifiedName} With{property.PropertyName}({property.Type.GetFullyQualifiedName()}{optionalQualifier} value)");
            builder.AppendLine("{");
            builder.AppendLine($"    return new {fullyQualifiedName}(" + this.BuildWithParameters(properties, property) + ");");
            builder.AppendLine("}");
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private string BuildWithParameters(List<NamedPropertyDeclaration> properties, NamedPropertyDeclaration property)
        {
            var builder = new StringBuilder();

            builder.Append(this.BuildWithParametersCore(properties, property));

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                if (builder.Length > 0)
                {
                    builder.Append(", ");
                }

                builder.Append("this.GetJsonProperties()");
            }

            return builder.ToString();
        }

        private string BuildWithParametersCore(List<NamedPropertyDeclaration> properties, NamedPropertyDeclaration? property)
        {
            var builder = new StringBuilder();

            var requiredProperties = new List<NamedPropertyDeclaration>();
            var optionalProperties = new List<NamedPropertyDeclaration>();

            this.BuildOptionalAndRequiredProperties(properties, optionalProperties, requiredProperties);

            foreach (NamedPropertyDeclaration current in requiredProperties)
            {
                this.BuildWithParameter(property, builder, current);
            }

            foreach (NamedPropertyDeclaration current in optionalProperties)
            {
                this.BuildWithParameter(property, builder, current);
            }

            return builder.ToString();
        }

        private void BuildWithParameter(NamedPropertyDeclaration? property, StringBuilder builder, NamedPropertyDeclaration current)
        {
            if (builder.Length > 0)
            {
                builder.Append(", ");
            }

            if (property is NamedPropertyDeclaration prop && prop.PropertyDeclaration == current.PropertyDeclaration)
            {
                if (current.Type.ContainsReference(this, new List<ITypeDeclaration>()) || current.Type.IsCompoundType)
                {
                    builder.Append("Menes.JsonReference.FromValue(value)");
                }
                else
                {
                    builder.Append("value");
                }
            }
            else if (current.Type.ContainsReference(this, new List<ITypeDeclaration>()) || current.Type.IsCompoundType)
            {
                builder.Append($"this.Get{current.PropertyName}()");
            }
            else
            {
                builder.Append($"this.{current.PropertyName}");
            }
        }

        private void BuildPropertyAccessor(NamedPropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            string typeName = property.Type.GetFullyQualifiedName();

            string fieldNameAccessor = (property.Type.ContainsReference(this, new List<ITypeDeclaration>()) || property.Type.IsCompoundType) ? $"this.{property.FieldName}?.AsValue<{typeName}>()" : $"this.{property.FieldName}";

            if (property.Type is OptionalTypeDeclaration)
            {
                members.Add(SF.ParseMemberDeclaration($"public {typeName}? {property.PropertyName} => {fieldNameAccessor} ?? {typeName}.FromOptionalProperty(this.JsonElement, {property.BytesPropertyName}.Span).AsOptional;" + Environment.NewLine));
            }
            else
            {
                members.Add(SF.ParseMemberDeclaration($"public {typeName} {property.PropertyName} => {fieldNameAccessor} ?? {typeName}.FromOptionalProperty(this.JsonElement, {property.BytesPropertyName}.Span);" + Environment.NewLine));
            }
        }

        private void BuildPropertyBackingDeclaration(NamedPropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            if (property.Type.ContainsReference(this, new List<ITypeDeclaration>()) || property.Type.IsCompoundType)
            {
                members.Add(SF.ParseMemberDeclaration($"private readonly Menes.JsonReference? {property.FieldName};" + Environment.NewLine));
            }
            else
            {
                members.Add(SF.ParseMemberDeclaration($"private readonly {property.Type.GetFullyQualifiedName()}? {property.FieldName};" + Environment.NewLine));
            }
        }

        private void BuildPropertyNamePathDeclaration(NamedPropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration($"private const string {property.PathPropertyName} = {StringFormatter.EscapeForCSharpString("." + property.JsonPropertyName, true)};" + Environment.NewLine));
        }

        private void BuildEncodedPropertyNameDeclaration(NamedPropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration($"private static readonly System.Text.Json.JsonEncodedText {property.EncodedPropertyName} = System.Text.Json.JsonEncodedText.Encode({property.BytesPropertyName}.Span);" + Environment.NewLine));
        }

        private void BuildPropertyNameBytesDeclaration(NamedPropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            // The C# compiler handles constant byte array initialization like this by embedding the binary
            // data directly into the compiled assembly, and uses that to initialize the array directly.
            // This results in better startup times than putting the call to Encoding.UTF8.GetBytes into the
            // generated code itself. It means that we do the string processing here at code-gen time, instead
            // of during static initialization.
            // It's possible we could go a step further, because most of places that use this data obtain a
            // ReadOnlySpan<T>, and it turns out that the compiler can optimize the initialization of a span
            // with a constant binary array even further: it doesn't need to allocate an array at all because
            // it can produce a span that wraps the compiled byte stream directly. (Moreover, the code it
            // generates to produce this span makes it possible for the JIT compiler to determine the span length,
            // and there are scenarios where this can go on to improve performance by enabling the JIT to omit
            // compile-time bounds checks. However, because of the limitations on span usage (it's a ref struct)
            // we can't just make these properties return a ReadOnlySpan<byte>. In any case, there's currently one
            // use of these properties that depends on hangs onto the Memory object: the list of all properties.
            // It might be possible to create a more efficient formulation in which we have one great big binary
            // array that contains all of the UTF8 data, but we'd need careful benchmarking to work out whether
            // it did in fact produce an improvement.
            members.Add(SF.ParseMemberDeclaration($"private static readonly System.ReadOnlyMemory<byte> {property.BytesPropertyName} = new byte[] {{ {string.Join(", ", System.Text.Encoding.UTF8.GetBytes(property.JsonPropertyName).Select(b => b.ToString()))} }};" + Environment.NewLine));
        }

        private readonly struct NamedPropertyDeclaration
        {
            public NamedPropertyDeclaration(string propertyName, PropertyDeclaration propertyDeclaration)
            {
                this.PropertyDeclaration = propertyDeclaration;
                string fieldName = StringFormatter.ToCamelCaseWithReservedWords(propertyName);
                this.FieldName = fieldName;
                this.PropertyName = propertyName;
                this.BytesPropertyName = propertyName + "PropertyNameBytes";
                this.EncodedPropertyName = "Encoded" + propertyName + "PropertyName";
                this.PathPropertyName = propertyName + "PropertyNamePath";
            }

            public string FieldName { get; }

            public PropertyDeclaration PropertyDeclaration { get; }

            public ITypeDeclaration Type => this.PropertyDeclaration.Type;

            public string JsonPropertyName => this.PropertyDeclaration.JsonPropertyName;

            public string PropertyName { get; }

            public string BytesPropertyName { get; }

            public string EncodedPropertyName { get; }

            public string PathPropertyName { get; }
        }
    }
}
