// <copyright file="ObjectTypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using Microsoft.CodeAnalysis;
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
        /// <param name="parent">The parent scope.</param>
        /// <param name="name">The name of the type.</param>
        /// <param name="additionalPropertiesType">The type of any additional properties.</param>
        public ObjectTypeDeclaration(IDeclaration parent, string name, ITypeDeclaration? additionalPropertiesType = null)
            : base(parent, name)
        {
            this.AdditionalPropertiesType = additionalPropertiesType;
        }

        /// <summary>
        /// Gets the type of any additional properties.
        /// </summary>
        public ITypeDeclaration? AdditionalPropertiesType { get; }

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

        private static string GetPropertyNameFieldName(PropertyDeclaration property)
        {
            return $"{NameFormatter.ToPascalCase(property.JsonPropertyName)}PropertyName";
        }

        private BaseTypeSyntax[] BuildBaseListTypes()
        {
            var bases = new List<BaseTypeSyntax> { SF.SimpleBaseType(SF.ParseTypeName(typeof(IJsonObject).FullName)), SF.SimpleBaseType(SF.ParseTypeName($"System.IEquatable<{this.GetFullyQualifiedName()}>")) };

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                bases.Add(SF.SimpleBaseType(SF.ParseTypeName(typeof(IJsonAdditionalProperties).FullName)));
            }

            return bases.ToArray();
        }

        private MemberDeclarationSyntax[] BuildMembers()
        {
            var members = new List<MemberDeclarationSyntax>();

            //// Public static readonly fields

            this.BuildNullAccessor(members);
            this.BuildJsonElementFactory(members);

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

            //// Private methods
            this.BuildJsonReferenceAccessors(members);
            this.BuildJsonPropertiesAccessor(members);

            return members.ToArray();
        }

        private void BuildEquals(List<MemberDeclarationSyntax> members)
        {
            string declaration =
            $"public bool Equals({this.GetFullyQualifiedName()} other) " +
            "{ " +
            "    if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull)) " +
            "    { " +
            "        return false; " +
            "    } " +
            " " +
            "    if (this.HasJsonElement && other.HasJsonElement) " +
            "    { " +
            "        return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other)); " +
            "    } " +
            " " +
            $"    return {this.BuildEqualsForProperties()}; " +
            "} ";

            members.Add(SF.ParseMemberDeclaration(declaration));
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

                string name = NameFormatter.ToPascalCase(property.JsonPropertyName);
                builder.Append($"this.{name}.Equals(other.{name})");
            }

            if (this.AdditionalPropertiesType is ITypeDeclaration additionalProperties)
            {
                if (builder.Length > 0)
                {
                    builder.Append(" && ");
                }

                builder.Append("this.AdditionalProperties.SequenceEqual(other.AdditionalProperties)");
            }

            return builder.ToString();
        }

        private void BuildWriteTo(List<MemberDeclarationSyntax> members)
        {
            var builder = new StringBuilder("public void WriteTo(System.Text.Json.Utf8JsonWriter writer) { if (this.HasJsonElement) { this.JsonElement.WriteTo(writer); } else { writer.WriteStartObject(); ");

            foreach (PropertyDeclaration property in this.Properties)
            {
                string fieldName = NameFormatter.ToCamelCase(property.JsonPropertyName);
                string declaration =
                $"if (this.{fieldName} is Menes.JsonString {fieldName}) " +
                "{ " +
                $"    writer.WritePropertyName(Encoded{NameFormatter.ToPascalCase(property.JsonPropertyName)}PropertyName); " +
                $"    {fieldName}.WriteTo(writer); " +
                "} ";

                builder.Append(declaration);
            }

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                builder.Append("Menes.JsonPropertyEnumerator enumerator = this.AdditionalProperties; while (enumerator.MoveNext()) { enumerator.Current.Write(writer); } ");
            }

            builder.Append(" writer.WriteEndObject(); } }");

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildFromOptionalFactories(List<MemberDeclarationSyntax> members)
        {
            string fullyQualifiedTypeName = this.GetFullyQualifiedName();

            string declaration1 =
            $"public static {fullyQualifiedTypeName} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) => " +
            "    parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property) " +
            "        ? new {fullyQualifiedTypeName}(property) " +
            "        : Null; ";

            string declaration2 =
                $"public static {fullyQualifiedTypeName} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) => " +
                "    parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property) " +
                "        ? new {fullyQualifiedTypeName}(property) " +
                "        : Null; ";

            string declaration3 =
                $"public static {fullyQualifiedTypeName} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) => " +
                "    parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property) " +
                "        ? new {fullyQualifiedTypeName}(property) " +
                "        : Null; ";

            members.Add(SF.ParseMemberDeclaration(declaration1));
            members.Add(SF.ParseMemberDeclaration(declaration2));
            members.Add(SF.ParseMemberDeclaration(declaration3));
        }

        private void BuildIsConvertibleFrom(List<MemberDeclarationSyntax> members)
        {
            string declaration =
                "public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement) " +
                "{ " +
                "    return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null; " +
                "}";

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private void BuildAdditionalPropertiesAccessor(List<MemberDeclarationSyntax> members)
        {
            if (!(this.AdditionalPropertiesType is ITypeDeclaration))
            {
                return;
            }

            string declaration =
                "public Menes.JsonPropertyEnumerator AdditionalProperties " +
                "{ " +
                "    get " +
                "    { " +
                "        if (this.additionalProperties is Menes.JsonProperties ap) " +
                "        { " +
                "            return new Menes.JsonPropertyEnumerator(ap, KnownProperties); " +
                "        } " +
                " " +
                "        if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object) " +
                "        { " +
                "            return new Menes.JsonPropertyEnumerator(this.JsonElement, KnownProperties); " +
                "        } " +
                " " +
                "        return new Menes.JsonPropertyEnumerator(Menes.JsonProperties.Empty, KnownProperties); " +
                "    } " +
                "} ";

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private void BuildJsonElementAccessors(List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration("public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;"));
            members.Add(SF.ParseMemberDeclaration("public System.Text.Json.JsonElement JsonElement { get; }"));
        }

        private void BuildPropertyCountAccessors(List<MemberDeclarationSyntax> members)
        {
            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                members.Add(SF.ParseMemberDeclaration("public int PropertiesCount => KnownProperties.Length + this.AdditionalPropertiesCount;"));

                string declaration =
                    "public int AdditionalPropertiesCount " +
                    "{ " +
                    "    get " +
                    "    { " +
                    "        JsonPropertyEnumerator enumerator = this.AdditionalProperties; " +
                    "        int count = 0; " +
                    " " +
                    "        while (enumerator.MoveNext()) " +
                    "        { " +
                    "            count++; " +
                    "        } " +
                    " " +
                    "        return count; " +
                    "    } " +
                    "} ";

                members.Add(SF.ParseMemberDeclaration(declaration));
            }
            else
            {
                members.Add(SF.ParseMemberDeclaration("public int PropertiesCount => KnownProperties.Length;"));
            }
        }

        private void BuildAsOptionalAccessor(List<MemberDeclarationSyntax> members)
        {
            string? typeName = this.GetFullyQualifiedName();
            members.Add(SF.ParseMemberDeclaration($"public {typeName}? AsOptional => this.IsNull ? default({typeName}?) : this;"));
        }

        private void BuildIsNullAccessor(List<MemberDeclarationSyntax> members)
        {
            var builder = new StringBuilder("public bool IsNull => (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null)");
            foreach (PropertyDeclaration property in this.Properties)
            {
                builder.Append(" && ");
                string propertyName = NameFormatter.ToCamelCase(property.JsonPropertyName);
                if (property.Type is OptionalTypeDeclaration)
                {
                    builder.Append($"(this.{propertyName} is null || this.{propertyName}.Value.IsNull)");
                }
                else
                {
                    builder.Append($"this.{propertyName}.IsNull)");
                }
            }

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildAdditionalPropertiesBacking(List<MemberDeclarationSyntax> members)
        {
            if (this.AdditionalPropertiesType is null)
            {
                return;
            }

            members.Add(SF.ParseMemberDeclaration($"private readonly Menes.JsonProperties? additionalProperties;"));
        }

        private void BuildConstructors(List<MemberDeclarationSyntax> members)
        {
            // public
            this.BuildJsonElementConstructor(members);

            this.BuildPropertiesConstruct(members);

            // private
            this.BuildCloningConstructor(members);
        }

        private void BuildPropertiesConstruct(List<MemberDeclarationSyntax> members)
        {
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
            string declaration =
            $"private {this.Name}({this.BuildCloningConstructorParameterList()}) " +
            "{ " +
            this.BuildCloningConstructorParameterSetters() +
            " }";

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private string BuildCloningConstructorParameterSetters()
        {
            var builder = new StringBuilder();
            int index = 1;
            foreach (PropertyDeclaration property in this.Properties)
            {
                if (builder.Length > 0)
                {
                    builder.Append(" ");
                }

                string parameterAndFieldName = NameFormatter.ToCamelCase(property.JsonPropertyName);

                if (property.Type.IsCompoundType)
                {
                    string fullyQualifiedTypeName = property.Type.GetFullyQualifiedName();
                    builder.Append($"if ({parameterAndFieldName} is {fullyQualifiedTypeName} item{index}) {{ ");
                    builder.Append($"this.{parameterAndFieldName} = Menes.JsonReference.FromValue(item{index}); }} else {{ ");
                    builder.Append($"this.{parameterAndFieldName} = null; }}");
                    index++;
                }
                else
                {
                    builder.Append($"this.{parameterAndFieldName} = {parameterAndFieldName};");
                }
            }

            if (builder.Length > 0)
            {
                builder.Append(" ");
            }

            builder.Append("this.JsonElement = default;");

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                if (builder.Length > 0)
                {
                    builder.Append(" ");
                }

                builder.Append("this.additionalProperties = additionalProperties;");
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

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                if (builder.Length > 0)
                {
                    builder.Append(", ");
                }

                builder.Append($"Menes.JsonProperties? additionalProperties");
            }

            return builder.ToString();
        }

        private void BuildPropertiesConstructor(List<MemberDeclarationSyntax> members, int? additionalPropertiesCount)
        {
            string declaration =
            $"public {this.Name}({this.BuildPropertiesConstructorParameterList(additionalPropertiesCount)}) " +
            "{ " +
            this.BuildPropertiesConstructorParameterSetters(additionalPropertiesCount) +
            " }";

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private string BuildPropertiesConstructorParameterSetters(int? additionalPropertiesCount)
        {
            var builder = new StringBuilder();
            int index = 1;
            foreach (PropertyDeclaration property in this.Properties)
            {
                if (builder.Length > 0)
                {
                    builder.Append(" ");
                }

                string parameterAndFieldName = NameFormatter.ToCamelCase(property.JsonPropertyName);

                if (property.Type.IsCompoundType)
                {
                    string fullyQualifiedTypeName = property.Type.GetFullyQualifiedName();
                    builder.Append($"if ({parameterAndFieldName} is {fullyQualifiedTypeName} item{index}) {{ ");
                    builder.Append($"this.{parameterAndFieldName} = Menes.JsonReference.FromValue(item{index}); }} else {{ ");
                    builder.Append($"this.{parameterAndFieldName} = null; }}");
                    index++;
                }
                else
                {
                    builder.Append($"this.{parameterAndFieldName} = {parameterAndFieldName};");
                }
            }

            if (builder.Length > 0)
            {
                builder.Append(" ");
            }

            builder.Append("this.JsonElement = default;");

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                if (builder.Length > 0)
                {
                    builder.Append(" ");
                }

                if (additionalPropertiesCount is null)
                {
                    builder.Append("this.additionalProperties = additionalProperties;");
                }
                else if (additionalPropertiesCount == -1)
                {
                    builder.Append("this.additionalProperties = Menes.JsonProperties.FromValues(additionalProperties);");
                }
                else if (additionalPropertiesCount == 0)
                {
                    builder.Append("this.additionalProperties = null");
                }
                else
                {
                    builder.Append("this.additionalProperties = Menes.JsonProperties.FromValues(");
                    for (int i = 0; i < additionalPropertiesCount; ++i)
                    {
                        if (i > 0)
                        {
                            builder.Append(", ");
                        }

                        builder.Append($"additionalProperty{i + 1}");
                    }

                    builder.Append("); ");
                }
            }

            return builder.ToString();
        }

        private string BuildPropertiesConstructorParameterList(int? additionalPropertiesCount)
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
                this.BuildPropertiesConstructorParameter(property, builder, false);
            }

            foreach (PropertyDeclaration property in optionalProperties)
            {
                this.BuildPropertiesConstructorParameter(property, builder, true);
            }

            if (this.AdditionalPropertiesType is ITypeDeclaration additionalPropertiesType)
            {
                this.BuildPropertiesConstructorAdditionalPropertiesParameter(additionalPropertiesType, builder, additionalPropertiesCount);
            }

            return builder.ToString();
        }

        private void BuildPropertiesConstructorAdditionalPropertiesParameter(ITypeDeclaration additionalPropertiesType, StringBuilder builder, int? additionalPropertiesCount)
        {
            if (additionalPropertiesCount is null)
            {
                if (builder.Length > 0)
                {
                    builder.Append(", ");
                }

                builder.Append($"Menes.JsonProperties additionalProperties");
            }
            else if (additionalPropertiesCount == -1)
            {
                if (builder.Length > 0)
                {
                    builder.Append(", ");
                }

                builder.Append($"params (string, {additionalPropertiesType.GetFullyQualifiedName()})[] additionalProperties");
            }
            else
            {
                for (int i = 0; i < additionalPropertiesCount; ++i)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append(", ");
                    }

                    builder.Append($"(string, {additionalPropertiesType.GetFullyQualifiedName()}) additionalProperties{i + 1}");
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
            builder.Append(NameFormatter.ToCamelCase(property.JsonPropertyName));

            if (isOptional)
            {
                builder.Append(" = null");
            }
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
            builder.Append(NameFormatter.ToCamelCase(property.JsonPropertyName));

            if (isOptional)
            {
                builder.Append(" = null");
            }
        }

        private void BuildJsonElementConstructor(List<MemberDeclarationSyntax> members)
        {
            string declaration =
            $"public {this.Name}(System.Text.Json.JsonElement jsonElement) " +
            "{ " +
            "    this.JsonElement = jsonElement; " +
            this.BuildNullFieldAssignments() +
            "}";

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private string BuildNullFieldAssignments()
        {
            var builder = new StringBuilder();

            foreach (PropertyDeclaration property in this.Properties)
            {
                if (builder.Length > 0)
                {
                    builder.Append(" ");
                }

                builder.Append($"this.{NameFormatter.ToCamelCase(property.JsonPropertyName)} = null;");
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

            this.BuildWithAdditionalPropertiesFactories(members);
        }

        private void BuildWithAdditionalPropertiesFactories(List<MemberDeclarationSyntax> members)
        {
            if (this.AdditionalPropertiesType is ITypeDeclaration additionalPropertiesType)
            {
                string fullyQualifiedAdditionalPropertiesName = additionalPropertiesType.GetFullyQualifiedName();
                string fullyQualifiedName = this.GetFullyQualifiedName();
                this.BuildWithAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, null);
                this.BuildWithAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, -1);
                this.BuildWithAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 1);
                this.BuildWithAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 2);
                this.BuildWithAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 3);
                this.BuildWithAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 4);
            }
        }

        private void BuildWithAdditionalPropertiesFactory(string fullyQualifiedName, string fullyQualifiedAdditionalPropertiesName, List<MemberDeclarationSyntax> members, int? additionalPropertiesCount)
        {
            var builder = new StringBuilder($"public {fullyQualifiedName} WithAdditionalProperties(");
            if (additionalPropertiesCount is null)
            {
                builder.Append($"JsonProperties newAdditional) {{ return new {fullyQualifiedName}( ");
                builder.Append(this.BuildWithParametersCore(null));
                builder.Append(", newAdditional); }");
            }
            else if (additionalPropertiesCount == -1)
            {
                builder.Append($"params (string, {fullyQualifiedAdditionalPropertiesName})[] newAdditional) {{ return new {fullyQualifiedName}( ");
                builder.Append(this.BuildWithParametersCore(null));
                builder.Append(", Menes.JsonProperties.FromValues(newAdditional)); }");
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

                builder.Append($") {{ return new {fullyQualifiedName}( ");
                builder.Append(this.BuildWithParametersCore(null));
                builder.Append(", Menes.JsonProperties.FromValues(");
                for (int i = 0; i < additionalPropertiesCount; ++i)
                {
                    if (i > 0)
                    {
                        builder.Append(", ");
                    }

                    builder.Append($"newAdditional{i + 1}");
                }

                builder.Append(")); }");
            }

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
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
            members.Add(SF.ParseMemberDeclaration($"public static readonly Func<System.Text.Json.JsonElement, {this.GetFullyQualifiedName()}> FromJsonElement = e => new {this.GetFullyQualifiedName()}(e);"));
        }

        private void BuildNullAccessor(List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration($"public static readonly {this.GetFullyQualifiedName()} Null = new {this.GetFullyQualifiedName()}(default);"));
        }

        private void BuildPropertyBackings(List<MemberDeclarationSyntax> members)
        {
            var propertyNames = new List<(string, string)>();

            this.BuildPropertyNameDeclarations(members, propertyNames);
            this.BuildPropertyNamePathDeclarations(propertyNames, members);
            this.BuildEncodedPropertyNameDeclarations(propertyNames, members);
            this.BuildPropertyNameBytesDeclarations(propertyNames, members);

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

        private void BuildPropertyNameDeclarations(List<MemberDeclarationSyntax> members, List<(string fieldName, string jsonPropertyName)> propertyNames)
        {
            foreach (PropertyDeclaration property in this.Properties)
            {
                string propertyNameFieldName = GetPropertyNameFieldName(property);
                this.BuildPropertyNameDeclaration(propertyNameFieldName, property.JsonPropertyName, members);
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
                this.BuildPropertyNameBytesDeclaration(propertyNameFieldName.Item1, members);
            }
        }

        private void AddKnownProperties(List<(string, string)> propertyNames, List<MemberDeclarationSyntax> members)
        {
            string knownPropertiesList = string.Join(", ", propertyNames.Select(n => $"{n.Item1}Bytes"));
            members.Add(SF.ParseMemberDeclaration($"private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create({knownPropertiesList});"));
        }

        private void BuildJsonReferenceAccessor(PropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            if (!property.Type.IsCompoundType)
            {
                return;
            }

            string camelCasePropertyName = NameFormatter.ToCamelCase(property.JsonPropertyName);

            string declaration =
            $"private Menes.JsonReference? Get{NameFormatter.ToPascalCase(property.JsonPropertyName)}() " +
            "{ " +
            $"    if (this.{camelCasePropertyName} is Menes.JsonReference) " +
            "    { " +
            $"        return this.{camelCasePropertyName}; " +
            "    } " +
            " " +
            $"    if (this.HasJsonElement && this.JsonElement.TryGetProperty({GetPropertyNameFieldName(property)}Bytes.Span, out System.Text.Json.JsonElement value)) " +
            "    { " +
            "        return Menes.JsonReference.FromValue(value); " +
            "    } " +
            " " +
            "    return default; " +
            "}";

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private void BuildJsonPropertiesAccessor(List<MemberDeclarationSyntax> members)
        {
            if (!(this.AdditionalPropertiesType is ITypeDeclaration))
            {
                return;
            }

            string declaration =
            "private Menes.JsonProperties GetJsonProperties() " +
            "{ " +
            "    if (this.additionalProperties is Menes.JsonProperties props) " +
            "    { " +
            "        return props; " +
            "    } " +
            " " +
            "    return new Menes.JsonProperties(this.AdditionalProperties.ToImmutableArray()); " +
            "} ";

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private void BuildWithPropertyFactory(PropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            string optionalQualifier = property.Type is OptionalTypeDeclaration ? "?" : string.Empty;
            string fullyQualifiedName = this.GetFullyQualifiedName();
            string declaration =
$" public {fullyQualifiedName} With{NameFormatter.ToPascalCase(property.JsonPropertyName)}({property.Type.GetFullyQualifiedName()}{optionalQualifier} value) " +
" { " +
$"    return new {fullyQualifiedName}(" + this.BuildWithParameters(property) + "); " +
" }";
            members.Add(SF.ParseMemberDeclaration(declaration));
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
                builder.Append("value");
            }
            else if (current.Type.IsCompoundType)
            {
                builder.Append($", this.Get{NameFormatter.ToPascalCase(current.JsonPropertyName)}()");
            }
            else
            {
                builder.Append($"this.{NameFormatter.ToPascalCase(current.JsonPropertyName)}");
            }
        }

        private void BuildPropertyAccessor(PropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            string typeName = property.Type.GetFullyQualifiedName();
            string propertyName = NameFormatter.ToPascalCase(property.JsonPropertyName);
            string fieldName = NameFormatter.ToCamelCase(property.JsonPropertyName);

            if (property.Type is OptionalTypeDeclaration)
            {
                members.Add(SF.ParseMemberDeclaration($"public {typeName}? {propertyName} => this.{fieldName} ?? {typeName}.FromOptionalProperty(this.JsonElement, {propertyName}PropertyNameBytes.Span).AsOptional;"));
            }
            else
            {
                members.Add(SF.ParseMemberDeclaration($"public {typeName} {propertyName} => this.{fieldName} ?? {typeName}.FromOptionalProperty(this.JsonElement, {propertyName}PropertyNameBytes.Span);"));
            }
        }

        private void BuildPropertyBackingDeclaration(PropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            if (property.Type.IsCompoundType)
            {
                members.Add(SF.ParseMemberDeclaration($"private readonly Menes.JsonReference? {NameFormatter.ToCamelCase(property.JsonPropertyName)};"));
            }
            else
            {
                members.Add(SF.ParseMemberDeclaration($"private readonly {property.Type.GetFullyQualifiedName()}? {NameFormatter.ToCamelCase(property.JsonPropertyName)};"));
            }
        }

        private void BuildPropertyNameDeclaration(string propertyNameFieldName, string jsonPropertyName, List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration($"private const string {propertyNameFieldName} = \"{jsonPropertyName}\";"));
        }

        private void BuildPropertyNamePathDeclaration(string propertyNameFieldName, string jsonPropertyName, List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration($"private const string {propertyNameFieldName}Path = \".{jsonPropertyName}\";"));
        }

        private void BuildEncodedPropertyNameDeclaration(string propertyNameFieldName, List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration($"private static readonly System.Text.Json.JsonEncodedText Encoded{propertyNameFieldName} = System.Text.Json.JsonEncodedText.Encode({propertyNameFieldName});"));
        }

        private void BuildPropertyNameBytesDeclaration(string propertyNameFieldName, List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration($"private static readonly System.ReadOnlyMemory<byte> {propertyNameFieldName}Bytes = System.Text.Encoding.UTF8.GetBytes({propertyNameFieldName});"));
        }
    }
}
