﻿// <copyright file="ObjectTypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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
        /// Gets or sets the max properties validation.
        /// </summary>
        public int? MaxPropertiesValidation { get; set; }

        /// <summary>
        /// Gets or sets the min properties validation.
        /// </summary>
        public int? MinPropertiesValidation { get; set; }

        /// <summary>
        /// Gets or sets the type of the not validation.
        /// </summary>
        public ITypeDeclaration? NotTypeValidation { get; set; }

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

        private static string GetPropertyNameFieldName(PropertyDeclaration property)
        {
            return $"{StringFormatter.ToPascalCaseWithReservedWords(property.JsonPropertyName)}PropertyName";
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

            //// Public static readonly fields

            this.BuildNullAccessor(members);
            this.BuildJsonElementFactory(members);
            this.BuildConstValue(members);
            this.BuildEnumValues(members);

            //// private const, private static, private readonly (we may need to split these up)

            this.BuildPropertyBackings(members);
            this.BuildAdditionalPropertiesBacking(members);

            //// Constructors (public then private)

            this.BuildConstructors(members);

            //// Public properties
            this.BuildIsNullAccessor(members);
            this.BuildAsOptionalAccessor(members);
            this.BuildPropertyAccessors(members);
            this.BuildPropertyCountAccessors(members);
            this.BuildJsonElementAccessors(members);
            this.BuildAdditionalPropertiesAccessor(members);

            //// Public static methods
            this.BuildIsConvertibleFrom(members);
            this.BuildFromOptionalFactories(members);

            //// Public methods
            this.BuildWithPropertyFactories(members);
            this.BuildWriteTo(members);
            this.BuildEquals(members);
            this.BuildValidate(members);
            this.BuildTryGetAdditionalProperties(members);
            this.BuildToString(members);
            this.BuildMethods(members);

            //// Private static methods
            this.BuildConstValueFactory(members);
            this.BuildEnumValuesFactory(members);

            //// Private methods
            this.BuildJsonReferenceAccessors(members);
            this.BuildJsonPropertiesAccessor(members);

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
                members.Add(SF.ParseMemberDeclaration("private static readonly Menes.JsonReference? ConstValue = BuildConstValue();" + Environment.NewLine));
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

        private void BuildEnumValues(List<MemberDeclarationSyntax> members)
        {
            if (this.ConstValidation is string)
            {
                members.Add(SF.ParseMemberDeclaration("private static readonly Menes.JsonReference? EnumValues = BuildEnumValues();" + Environment.NewLine));
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

        private void BuildValidate(List<MemberDeclarationSyntax> members)
        {
            var builder = new StringBuilder();
            builder.AppendLine("public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)");
            builder.AppendLine("{");
            builder.AppendLine("    Menes.ValidationContext context = validationContext;");
            foreach (PropertyDeclaration property in this.Properties)
            {
                string propertyName = StringFormatter.ToPascalCaseWithReservedWords(property.JsonPropertyName);

                if (property.Type is OptionalTypeDeclaration)
                {
                    string fieldName = StringFormatter.ToCamelCaseWithReservedWords(property.JsonPropertyName);
                    builder.AppendLine($"    if (this.{propertyName} is {property.Type.GetFullyQualifiedName()} {fieldName})");
                    builder.AppendLine("    {");
                    builder.AppendLine($"        context = Menes.Validation.ValidateProperty(context, {fieldName}, {propertyName}PropertyNamePath);");
                    builder.AppendLine("    }");
                }
                else
                {
                    builder.AppendLine($"    context = Menes.Validation.ValidateRequiredProperty(context, this.{propertyName}, {propertyName}PropertyNamePath);");
                }
            }

            if (this.AdditionalPropertiesType is ITypeDeclaration additionalProperties)
            {
                builder.AppendLine($"foreach (Menes.JsonPropertyReference<{additionalProperties.GetFullyQualifiedName()}> property in this.JsonAdditionalProperties)");
                builder.AppendLine("{");
                builder.AppendLine($"    context = Menes.Validation.ValidateProperty(context, property.AsValue(), \".\" + property.Name);");
                builder.AppendLine("}");
            }

            if (this.MinPropertiesValidation is int || this.MaxPropertiesValidation is int)
            {
                builder.AppendLine($"context = Menes.Validation.ValidateObject(context, this, {this.MinPropertiesValidation?.ToString() ?? "null"}, {this.MaxPropertiesValidation?.ToString() ?? "null"});");
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
                    builder.AppendLine($"{allOfFullyQualifiedName} {allOfTypeNameCamelCase}Value{index} = thisAsAny.As<{allOfFullyQualifiedName}>();");
                    builder.AppendLine($"            allOfValidationContext{index + 1} = {allOfTypeNameCamelCase}Value{index}.Validate(allOfValidationContext{index + 1});");
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

            if (this.ConstValidation is string)
            {
                builder.AppendLine($"Menes.Validation.ValidateConst(context, this, this.ConstValue.AsValue<{this.GetFullyQualifiedName()}>());");
            }

            if (this.EnumValidation is string)
            {
                builder.AppendLine($"Menes.Validation.ValidateEnum(context, this, this.EnumValues.AsValue<Menes.JsonArray<{this.GetFullyQualifiedName()}>>());");
            }

            builder.AppendLine("    return context;");
            builder.AppendLine("}");
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildEquals(List<MemberDeclarationSyntax> members)
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
            builder.AppendLine($"    return {this.BuildEqualsForProperties()};");
            builder.AppendLine("}");

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private string BuildEqualsForProperties()
        {
            var builder = new StringBuilder();

            foreach (PropertyDeclaration property in this.Properties)
            {
                if (builder.Length > 0)
                {
                    builder.Append(" && ");
                }

                string name = StringFormatter.ToPascalCaseWithReservedWords(property.JsonPropertyName);
                builder.Append($"this.{name}.Equals(other.{name})");
            }

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                if (builder.Length > 0)
                {
                    builder.Append(" && ");
                }

                builder.Append("System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties)");
            }

            return builder.ToString();
        }

        private void BuildWriteTo(List<MemberDeclarationSyntax> members)
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

            foreach (PropertyDeclaration property in this.Properties)
            {
                string fieldName = StringFormatter.ToCamelCaseWithReservedWords(property.JsonPropertyName);

                string typename = property.Type.IsCompoundType ? "Menes.JsonReference" : property.Type.GetFullyQualifiedName();

                builder.AppendLine($"if (this.{fieldName} is {typename} {fieldName})");
                builder.AppendLine("{");
                builder.AppendLine($"    writer.WritePropertyName(Encoded{StringFormatter.ToPascalCaseWithReservedWords(property.JsonPropertyName)}PropertyName);");
                builder.AppendLine($"    {fieldName}.WriteTo(writer);");
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
            builder.AppendLine($"   parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?");
            builder.AppendLine("        (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? new {fullyQualifiedTypeName}(property)");
            builder.AppendLine("            : Null)");
            builder.AppendLine("        : Null;");
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
            builder.Clear();

            builder.AppendLine($"public static {fullyQualifiedTypeName} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>");
            builder.AppendLine($"   parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?");
            builder.AppendLine("        (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? new {fullyQualifiedTypeName}(property)");
            builder.AppendLine("            : Null)");
            builder.AppendLine("        : Null;");
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
            builder.Clear();

            builder.AppendLine($"public static {fullyQualifiedTypeName} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>");
            builder.AppendLine($"   parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?");
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

        private void BuildIsNullAccessor(List<MemberDeclarationSyntax> members)
        {
            var builder = new StringBuilder("public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null)");
            foreach (PropertyDeclaration property in this.Properties)
            {
                builder.Append(" && ");
                string propertyName = StringFormatter.ToCamelCaseWithReservedWords(property.JsonPropertyName);
                builder.Append($"(this.{propertyName} is null || this.{propertyName}.Value.IsNull)");
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

        private void BuildConstructors(List<MemberDeclarationSyntax> members)
        {
            // public
            this.BuildJsonElementConstructor(members);

            this.BuildPropertiesConstructors(members);

            // private
            this.BuildCloningConstructor(members);
        }

        private void BuildPropertiesConstructors(List<MemberDeclarationSyntax> members)
        {
            this.BuildPropertiesConstructor(members, null, true);

            if (this.AdditionalPropertiesType is null)
            {
                this.BuildPropertiesConstructor(members, null);
            }
            else
            {
                // Build all the variants.
                this.BuildPropertiesConstructor(members, null);
                this.BuildPropertiesConstructor(members, -1);
                this.BuildPropertiesConstructor(members, 0);
                this.BuildPropertiesConstructor(members, 1);
                this.BuildPropertiesConstructor(members, 2);
                this.BuildPropertiesConstructor(members, 3);
                this.BuildPropertiesConstructor(members, 4);
            }
        }

        private void BuildCloningConstructor(List<MemberDeclarationSyntax> members)
        {
            if (this.Properties.Any(p => p.Type.IsCompoundType) || (this.AdditionalPropertiesType is ITypeDeclaration t && t.IsCompoundType))
            {
                string declaration =
                $"private {this.Name}({this.BuildCloningConstructorParameterList()})" + Environment.NewLine +
                "{" + Environment.NewLine +
                this.BuildCloningConstructorParameterSetters() +
                " }" + Environment.NewLine;

                members.Add(SF.ParseMemberDeclaration(declaration));
            }
        }

        private string BuildCloningConstructorParameterSetters()
        {
            var builder = new StringBuilder();
            int index = 1;
            foreach (PropertyDeclaration property in this.Properties)
            {
                string parameterAndFieldName = StringFormatter.ToCamelCaseWithReservedWords(property.JsonPropertyName);

                if (property.Type.IsCompoundType)
                {
                    builder.AppendLine($"if ({parameterAndFieldName} is Menes.JsonReference item{index})");
                    builder.AppendLine("{");
                    builder.AppendLine($"this.{parameterAndFieldName} = item{index};");
                    builder.AppendLine("}");
                    builder.AppendLine("else");
                    builder.AppendLine("{");
                    builder.AppendLine($"this.{parameterAndFieldName} = null;");
                    builder.AppendLine("}");
                    index++;
                }
                else
                {
                    builder.AppendLine($"this.{parameterAndFieldName} = {parameterAndFieldName};");
                }
            }

            builder.AppendLine("this.JsonElement = default;");

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                builder.AppendLine("this.additionalPropertiesBacking = additionalPropertiesBacking;");
            }

            return builder.ToString();
        }

        private string BuildCloningConstructorParameterList()
        {
            var builder = new StringBuilder();

            var optionalProperties = new List<PropertyDeclaration>();
            var requiredProperties = new List<PropertyDeclaration>();
            foreach (PropertyDeclaration property in this.Properties)
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

            foreach (PropertyDeclaration property in requiredProperties)
            {
                this.BuildCloningConstructorParameter(property, builder, false);
            }

            foreach (PropertyDeclaration property in optionalProperties)
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

        private void BuildPropertiesConstructor(List<MemberDeclarationSyntax> members, int? additionalPropertiesCount, bool requiredOnly = false)
        {
            bool hasAdditionalProperties = !(this.AdditionalPropertiesType is null);
            if (this.Properties.Count == 0)
            {
                if (!hasAdditionalProperties || (additionalPropertiesCount is int apc && apc == 0) || additionalPropertiesCount is null)
                {
                    return;
                }
            }

            var optionalProperties = new List<PropertyDeclaration>();
            var requiredProperties = new List<PropertyDeclaration>();

            this.BuildOptionalAndRequiredProperties(optionalProperties, requiredProperties);

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
            builder.Append(this.BuildPropertiesConstructorParameterSetters(additionalPropertiesCount, requiredOnly));
            builder.AppendLine("}");

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private string BuildPropertiesConstructorParameterSetters(int? additionalPropertiesCount, bool requiredOnly = false)
        {
            var builder = new StringBuilder();
            int index = 1;
            foreach (PropertyDeclaration property in this.Properties)
            {
                string parameterAndFieldName = StringFormatter.ToCamelCaseWithReservedWords(property.JsonPropertyName);

                if (property.Type is OptionalTypeDeclaration && requiredOnly)
                {
                    builder.AppendLine($"this.{parameterAndFieldName} = null;");
                }
                else if (property.Type.IsCompoundType)
                {
                    string fullyQualifiedTypeName = property.Type.GetFullyQualifiedName();
                    builder.AppendLine($"if ({parameterAndFieldName} is {fullyQualifiedTypeName} item{index})");
                    builder.AppendLine("{");
                    builder.AppendLine($"this.{parameterAndFieldName} = Menes.JsonReference.FromValue(item{index});");
                    builder.AppendLine("}");
                    builder.AppendLine("else");
                    builder.AppendLine("{");
                    builder.AppendLine($"this.{parameterAndFieldName} = null;");
                    builder.AppendLine("}");
                    index++;
                }
                else
                {
                    builder.AppendLine($"this.{parameterAndFieldName} = {parameterAndFieldName};");
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

        private string BuildPropertiesConstructorParameterList(IList<PropertyDeclaration> optionalProperties, IList<PropertyDeclaration> requiredProperties, int? additionalPropertiesCount, bool requiredOnly = false)
        {
            var builder = new StringBuilder();

            foreach (PropertyDeclaration property in requiredProperties)
            {
                this.BuildPropertiesConstructorParameter(property, builder, false);
            }

            if (!requiredOnly)
            {
                foreach (PropertyDeclaration property in optionalProperties)
                {
                    this.BuildPropertiesConstructorParameter(property, builder, true);
                }

                if (this.AdditionalPropertiesType is ITypeDeclaration additionalPropertiesType)
                {
                    this.BuildPropertiesConstructorAdditionalPropertiesParameter(additionalPropertiesType, builder, additionalPropertiesCount);
                }
            }

            return builder.ToString();
        }

        private void BuildOptionalAndRequiredProperties(List<PropertyDeclaration> optionalProperties, List<PropertyDeclaration> requiredProperties)
        {
            foreach (PropertyDeclaration property in this.Properties)
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

        private void BuildPropertiesConstructorParameter(PropertyDeclaration property, StringBuilder builder, bool isOptional)
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
            builder.Append(StringFormatter.ToCamelCaseWithReservedWords(property.JsonPropertyName));
        }

        private void BuildCloningConstructorParameter(PropertyDeclaration property, StringBuilder builder, bool isOptional)
        {
            if (builder.Length > 0)
            {
                builder.Append(", ");
            }

            if (property.Type.IsCompoundType)
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
            builder.Append(StringFormatter.ToCamelCaseWithReservedWords(property.JsonPropertyName));
        }

        private void BuildJsonElementConstructor(List<MemberDeclarationSyntax> members)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"public {this.Name}(System.Text.Json.JsonElement jsonElement)");
            builder.AppendLine("{");
            builder.AppendLine("    this.JsonElement = jsonElement;");
            builder.Append(this.BuildNullFieldAssignments());
            builder.AppendLine("}");

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private string BuildNullFieldAssignments()
        {
            var builder = new StringBuilder();

            foreach (PropertyDeclaration property in this.Properties)
            {
                builder.AppendLine($"this.{StringFormatter.ToCamelCaseWithReservedWords(property.JsonPropertyName)} = null;");
            }

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                builder.AppendLine("this.additionalPropertiesBacking = null;");
            }

            return builder.ToString();
        }

        private void BuildJsonReferenceAccessors(List<MemberDeclarationSyntax> members)
        {
            foreach (PropertyDeclaration property in this.Properties)
            {
                this.BuildJsonReferenceAccessor(property, members);
            }
        }

        private void BuildWithPropertyFactories(List<MemberDeclarationSyntax> members)
        {
            foreach (PropertyDeclaration property in this.Properties)
            {
                this.BuildWithPropertyFactory(property, members);
            }

            this.BuildReplaceAllAdditionalPropertiesFactories(members);
            this.BuildAddAdditionalPropertiesFactories(members);
            this.BuildRemoveAdditionalPropertiesFactories(members);
        }

        private void BuildReplaceAllAdditionalPropertiesFactories(List<MemberDeclarationSyntax> members)
        {
            if (this.AdditionalPropertiesType is ITypeDeclaration additionalPropertiesType)
            {
                string fullyQualifiedAdditionalPropertiesName = additionalPropertiesType.GetFullyQualifiedName();
                string fullyQualifiedName = this.GetFullyQualifiedName();
                this.BuildReplaceAllAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, null);
                this.BuildReplaceAllAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, -1);
                this.BuildReplaceAllAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 1);
                this.BuildReplaceAllAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 2);
                this.BuildReplaceAllAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 3);
                this.BuildReplaceAllAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 4);
            }
        }

        private void BuildAddAdditionalPropertiesFactories(List<MemberDeclarationSyntax> members)
        {
            if (this.AdditionalPropertiesType is ITypeDeclaration additionalPropertiesType)
            {
                string fullyQualifiedAdditionalPropertiesName = additionalPropertiesType.GetFullyQualifiedName();
                string fullyQualifiedName = this.GetFullyQualifiedName();
                this.BuildAddAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, -1);
                this.BuildAddAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 1);
                this.BuildAddAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 2);
                this.BuildAddAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 3);
                this.BuildAddAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 4);
            }
        }

        private void BuildRemoveAdditionalPropertiesFactories(List<MemberDeclarationSyntax> members)
        {
            if (this.AdditionalPropertiesType is ITypeDeclaration additionalPropertiesType)
            {
                string fullyQualifiedAdditionalPropertiesName = additionalPropertiesType.GetFullyQualifiedName();
                string fullyQualifiedName = this.GetFullyQualifiedName();
                this.BuildRemoveAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, -1);
                this.BuildRemoveAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 1);
                this.BuildRemoveAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 2);
                this.BuildRemoveAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 3);
                this.BuildRemoveAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 4);
                this.BuildRemoveIfAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members);
            }
        }

        private void BuildReplaceAllAdditionalPropertiesFactory(string fullyQualifiedName, string fullyQualifiedAdditionalPropertiesName, List<MemberDeclarationSyntax> members, int? additionalPropertiesCount)
        {
            var builder = new StringBuilder($"public {fullyQualifiedName} ReplaceAll(");
            if (additionalPropertiesCount is null)
            {
                builder.AppendLine($"Menes.JsonProperties<{fullyQualifiedAdditionalPropertiesName}> newAdditional)");
                builder.AppendLine("{");
                builder.Append($"return new {fullyQualifiedName}( ");
                this.AppendWithParametersCoreForAdditionalProperties(builder);
                builder.AppendLine("newAdditional);");
                builder.AppendLine("}");
            }
            else if (additionalPropertiesCount == -1)
            {
                builder.AppendLine($"params (string, {fullyQualifiedAdditionalPropertiesName})[] newAdditional)");
                builder.AppendLine("{");
                builder.Append($"return new {fullyQualifiedName}( ");
                this.AppendWithParametersCoreForAdditionalProperties(builder);
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
                this.AppendWithParametersCoreForAdditionalProperties(builder);
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

        private void BuildRemoveIfAdditionalPropertiesFactory(string fullyQualifiedName, string fullyQualifiedAdditionalPropertiesName, List<MemberDeclarationSyntax> members)
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
            this.AppendWithParametersCoreForAdditionalProperties(builder);
            builder.AppendLine($"new Menes.JsonProperties<{fullyQualifiedAdditionalPropertiesName}>(arrayBuilder.ToImmutable()));");
            builder.AppendLine("}");
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildRemoveAdditionalPropertiesFactory(string fullyQualifiedName, string fullyQualifiedAdditionalPropertiesName, List<MemberDeclarationSyntax> members, int additionalPropertiesCount)
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
                this.AppendWithParametersCoreForAdditionalProperties(builder);
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
                this.AppendWithParametersCoreForAdditionalProperties(builder);
                builder.AppendLine($"new Menes.JsonProperties<{fullyQualifiedAdditionalPropertiesName}>(arrayBuilder.ToImmutable()));");
                builder.AppendLine("}");
            }

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildAddAdditionalPropertiesFactory(string fullyQualifiedName, string fullyQualifiedAdditionalPropertiesName, List<MemberDeclarationSyntax> members, int additionalPropertiesCount)
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
                this.AppendWithParametersCoreForAdditionalProperties(builder);
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
                this.AppendWithParametersCoreForAdditionalProperties(builder);
                builder.AppendLine($"new Menes.JsonProperties<{fullyQualifiedAdditionalPropertiesName}>(arrayBuilder.ToImmutable()));");
                builder.AppendLine("}");
            }

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void AppendWithParametersCoreForAdditionalProperties(StringBuilder builder)
        {
            string core = this.BuildWithParametersCore(null);
            builder.Append(core);
            if (core.Length > 0)
            {
                builder.Append(", ");
            }
        }

        private void BuildPropertyAccessors(List<MemberDeclarationSyntax> members)
        {
            foreach (PropertyDeclaration property in this.Properties)
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

        private void BuildPropertyBackings(List<MemberDeclarationSyntax> members)
        {
            var propertyNames = new List<(string, string)>();

            this.BuildPropertyNameDeclarations(propertyNames);
            this.BuildPropertyNamePathDeclarations(propertyNames, members);
            this.BuildPropertyNameBytesDeclarations(propertyNames, members);
            this.BuildEncodedPropertyNameDeclarations(propertyNames, members);

            this.AddKnownProperties(propertyNames, members);

            this.BuildPropertyBackingDeclarations(members);
        }

        private void BuildPropertyBackingDeclarations(List<MemberDeclarationSyntax> members)
        {
            foreach (PropertyDeclaration property in this.Properties)
            {
                this.BuildPropertyBackingDeclaration(property, members);
            }
        }

        private void BuildPropertyNameDeclarations(List<(string fieldName, string jsonPropertyName)> propertyNames)
        {
            foreach (PropertyDeclaration property in this.Properties)
            {
                string propertyNameFieldName = GetPropertyNameFieldName(property);
                propertyNames.Add((propertyNameFieldName, property.JsonPropertyName));
            }
        }

        private void BuildPropertyNamePathDeclarations(List<(string, string)> propertyNameFieldNames, List<MemberDeclarationSyntax> members)
        {
            foreach ((string fieldName, string jsonPropertyName) in propertyNameFieldNames)
            {
                this.BuildPropertyNamePathDeclaration(fieldName, jsonPropertyName, members);
            }
        }

        private void BuildEncodedPropertyNameDeclarations(List<(string, string)> propertyNameFieldNames, List<MemberDeclarationSyntax> members)
        {
            foreach ((string, string) propertyNameFieldName in propertyNameFieldNames)
            {
                this.BuildEncodedPropertyNameDeclaration(propertyNameFieldName.Item1, members);
            }
        }

        private void BuildPropertyNameBytesDeclarations(List<(string, string)> propertyNameFieldNames, List<MemberDeclarationSyntax> members)
        {
            foreach ((string, string) propertyNameFieldName in propertyNameFieldNames)
            {
                this.BuildPropertyNameBytesDeclaration(propertyNameFieldName.Item1, propertyNameFieldName.Item2, members);
            }
        }

        private void AddKnownProperties(List<(string, string)> propertyNames, List<MemberDeclarationSyntax> members)
        {
            if (propertyNames.Count > 0)
            {
                string knownPropertiesList = string.Join(", ", propertyNames.Select(n => $"{n.Item1}Bytes"));
                members.Add(SF.ParseMemberDeclaration($"private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create({knownPropertiesList});" + Environment.NewLine));
            }
            else
            {
                members.Add(SF.ParseMemberDeclaration($"private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>>.Empty;" + Environment.NewLine));
            }
        }

        private void BuildJsonReferenceAccessor(PropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            if (!property.Type.IsCompoundType)
            {
                return;
            }

            string camelCasePropertyName = StringFormatter.ToCamelCaseWithReservedWords(property.JsonPropertyName);

            var builder = new StringBuilder();

            if (property.Type is OptionalTypeDeclaration)
            {
                builder.AppendLine($"private Menes.JsonReference? Get{StringFormatter.ToPascalCaseWithReservedWords(property.JsonPropertyName)}()");
            }
            else
            {
                builder.AppendLine($"private Menes.JsonReference Get{StringFormatter.ToPascalCaseWithReservedWords(property.JsonPropertyName)}()");
            }

            builder.AppendLine("{");
            builder.AppendLine($"    if (this.{camelCasePropertyName} is Menes.JsonReference reference)");
            builder.AppendLine("    {");
            builder.AppendLine($"        return reference;");
            builder.AppendLine("    }");
            builder.AppendLine($"    if (this.HasJsonElement && this.JsonElement.TryGetProperty({GetPropertyNameFieldName(property)}Bytes.Span, out System.Text.Json.JsonElement value))");
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

        private void BuildWithPropertyFactory(PropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            string optionalQualifier = property.Type is OptionalTypeDeclaration ? "?" : string.Empty;
            string fullyQualifiedName = this.GetFullyQualifiedName();
            var builder = new StringBuilder();
            builder.AppendLine($" public {fullyQualifiedName} With{StringFormatter.ToPascalCaseWithReservedWords(property.JsonPropertyName)}({property.Type.GetFullyQualifiedName()}{optionalQualifier} value)");
            builder.AppendLine("{");
            builder.AppendLine($"    return new {fullyQualifiedName}(" + this.BuildWithParameters(property) + ");");
            builder.AppendLine("}");
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private string BuildWithParameters(PropertyDeclaration property)
        {
            var builder = new StringBuilder();

            builder.Append(this.BuildWithParametersCore(property));

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

        private string BuildWithParametersCore(PropertyDeclaration? property)
        {
            var builder = new StringBuilder();

            var requiredProperties = new List<PropertyDeclaration>();
            var optionalProperties = new List<PropertyDeclaration>();

            foreach (PropertyDeclaration current in this.Properties)
            {
                if (current.Type is OptionalTypeDeclaration)
                {
                    optionalProperties.Add(current);
                }
                else
                {
                    requiredProperties.Add(current);
                }
            }

            foreach (PropertyDeclaration current in requiredProperties)
            {
                this.BuildWithParameter(property, builder, current);
            }

            foreach (PropertyDeclaration current in optionalProperties)
            {
                this.BuildWithParameter(property, builder, current);
            }

            return builder.ToString();
        }

        private void BuildWithParameter(PropertyDeclaration? property, StringBuilder builder, PropertyDeclaration current)
        {
            if (builder.Length > 0)
            {
                builder.Append(", ");
            }

            if (property is PropertyDeclaration prop && prop == current)
            {
                if (current.Type.IsCompoundType)
                {
                    builder.Append("Menes.JsonReference.FromValue(value)");
                }
                else
                {
                    builder.Append("value");
                }
            }
            else if (current.Type.IsCompoundType)
            {
                builder.Append($"this.Get{StringFormatter.ToPascalCaseWithReservedWords(current.JsonPropertyName)}()");
            }
            else
            {
                builder.Append($"this.{StringFormatter.ToPascalCaseWithReservedWords(current.JsonPropertyName)}");
            }
        }

        private void BuildPropertyAccessor(PropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            string typeName = property.Type.GetFullyQualifiedName();
            string propertyName = StringFormatter.ToPascalCaseWithReservedWords(property.JsonPropertyName);

            string fieldNameAccessor = property.Type.IsCompoundType ? $"this.{StringFormatter.ToCamelCaseWithReservedWords(property.JsonPropertyName)}?.AsValue<{typeName}>()" : $"this.{StringFormatter.ToCamelCaseWithReservedWords(property.JsonPropertyName)}";

            if (property.Type is OptionalTypeDeclaration)
            {
                members.Add(SF.ParseMemberDeclaration($"public {typeName}? {propertyName} => {fieldNameAccessor} ?? {typeName}.FromOptionalProperty(this.JsonElement, {propertyName}PropertyNameBytes.Span).AsOptional;" + Environment.NewLine));
            }
            else
            {
                members.Add(SF.ParseMemberDeclaration($"public {typeName} {propertyName} => {fieldNameAccessor} ?? {typeName}.FromOptionalProperty(this.JsonElement, {propertyName}PropertyNameBytes.Span);" + Environment.NewLine));
            }
        }

        private void BuildPropertyBackingDeclaration(PropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            if (property.Type.IsCompoundType)
            {
                members.Add(SF.ParseMemberDeclaration($"private readonly Menes.JsonReference? {StringFormatter.ToCamelCaseWithReservedWords(property.JsonPropertyName)};" + Environment.NewLine));
            }
            else
            {
                members.Add(SF.ParseMemberDeclaration($"private readonly {property.Type.GetFullyQualifiedName()}? {StringFormatter.ToCamelCaseWithReservedWords(property.JsonPropertyName)};" + Environment.NewLine));
            }
        }

        private void BuildPropertyNamePathDeclaration(string propertyNameFieldName, string jsonPropertyName, List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration($"private const string {propertyNameFieldName}Path = \".{jsonPropertyName}\";" + Environment.NewLine));
        }

        private void BuildEncodedPropertyNameDeclaration(string propertyNameFieldName, List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration($"private static readonly System.Text.Json.JsonEncodedText Encoded{propertyNameFieldName} = System.Text.Json.JsonEncodedText.Encode({propertyNameFieldName}Bytes.Span);" + Environment.NewLine));
        }

        private void BuildPropertyNameBytesDeclaration(string propertyNameFieldName, string jsonPropertyName, List<MemberDeclarationSyntax> members)
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
            members.Add(SF.ParseMemberDeclaration($"private static readonly System.ReadOnlyMemory<byte> {propertyNameFieldName}Bytes = new byte[] {{ {string.Join(", ", System.Text.Encoding.UTF8.GetBytes(jsonPropertyName).Select(b => b.ToString()))} }};" + Environment.NewLine));
        }
    }
}
