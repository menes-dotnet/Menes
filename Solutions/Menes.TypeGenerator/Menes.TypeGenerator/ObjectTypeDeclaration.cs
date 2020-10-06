// <copyright file="ObjectTypeDeclaration.cs" company="Endjin Limited">
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
                SF.StructDeclaration(NameFormatter.ToPascalCase(this.Name))
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
            var bases = new List<BaseTypeSyntax> { SF.SimpleBaseType(SF.ParseTypeName(typeof(IJsonValue).FullName)) };

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
            this.BuildAdditionalPropertiesBacking(members);

            //// private const, private static, private readonly (we may need to split these up)

            this.BuildPropertyBackings(members);

            //// Constructors (public then private)

            this.BuildConstructors(members);

            //// Public properties

            this.BuildPropertyAccessors(members);

            //// Public static methods

            this.BuildWithPropertyFactories(members);

            //// Public methods

            //// Private methods
            this.BuildJsonElementAccessors(members);
            this.BuildAdditionalPropertiesAccessor(members);

            return members.ToArray();
        }

        private void BuildAdditionalPropertiesBacking(List<MemberDeclarationSyntax> members)
        {
            if (this.AdditionalPropertiesType is null)
            {
                return;
            }

            members.Add(SF.ParseMemberDeclaration($"private readonly Menes.JsonProperties<{this.AdditionalPropertiesType.GetFullyQualifiedName()}>? additionalProperties;"));
        }

        private void BuildConstructors(List<MemberDeclarationSyntax> members)
        {
            // public
            this.BuildJsonElementConstructor(members);
            this.BuildPropertiesConstructor(members);

            // private
            this.BuildCloningConstructor(members);
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
            throw new NotImplementedException();
        }

        private string BuildCloningConstructorParameterList()
        {
            throw new NotImplementedException();
        }

        private void BuildPropertiesConstructor(List<MemberDeclarationSyntax> members)
        {
            string declaration =
            $"public {this.Name}({this.BuildPropertiesConstructorParameterList()}) " +
            "{ " +
            this.BuildPropertiesConstructorParameterSetters() +
            " }";

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private string BuildPropertiesConstructorParameterSetters()
        {
            var builder = new StringBuilder();

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
                    builder.Append($"this.{parameterAndFieldName} = new Menes.ReferenceOf<{fullyQualifiedTypeName}>(new {fullyQualifiedTypeName}({parameterAndFieldName})); ");
                    builder.Append($"this.{parameterAndFieldName}JsonElement = default;");
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

            if (this.AdditionalPropertiesType is ITypeDeclaration additionalProperties)
            {
                if (builder.Length > 0)
                {
                    builder.Append(" ");
                }

                builder.Append($"this.additionalProperties = new Menes.JsonProperties<{additionalProperties.GetFullyQualifiedName()}>(additionalProperties);");
            }

            return builder.ToString();
        }

        private string BuildPropertiesConstructorParameterList()
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
                this.BuildPropertiesConstructorAdditionalPropertiesParameter(additionalPropertiesType, builder);
            }

            return builder.ToString();
        }

        private void BuildPropertiesConstructorAdditionalPropertiesParameter(ITypeDeclaration additionalPropertiesType, StringBuilder builder)
        {
            if (builder.Length > 0)
            {
                builder.Append(", ");
            }

            builder.Append($"params (string, {additionalPropertiesType.GetFullyQualifiedName()})[] additionalProperties");
        }

        private void BuildPropertiesConstructorParameter(PropertyDeclaration property, StringBuilder builder, bool isOptional)
        {
            if (builder.Length > 0)
            {
                builder.Append(", ");
            }

            if (property.Type is ArrayTypeDeclaration atd)
            {
                builder.Append($"System.Collections.Generic.Enumerable<{atd.ItemType.GetFullyQualifiedName()}>");
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

                if (property.Type.IsCompoundType)
                {
                    builder.Append($"this.{NameFormatter.ToCamelCase(property.JsonPropertyName)}JsonElement = default;");
                }
            }

            return builder.ToString();
        }

        private void BuildJsonElementAccessors(List<MemberDeclarationSyntax> members)
        {
            foreach (PropertyDeclaration property in this.Properties)
            {
                this.BuildJsonElementAccessor(property, members);
            }
        }

        private void BuildWithPropertyFactories(List<MemberDeclarationSyntax> members)
        {
            foreach (PropertyDeclaration property in this.Properties)
            {
                this.BuildWithPropertyFactory(property, members);
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
            members.Add(SF.ParseMemberDeclaration($"public static readonly Func<System.Text.Json.JsonElement, {this.GetFullyQualifiedName()}> FromJsonElement = e => new {this.GetFullyQualifiedName()}(e);"));
        }

        private void BuildNullAccessor(List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration($"public static readonly {this.GetFullyQualifiedName()} Null = new {this.GetFullyQualifiedName()}(default);"));
        }

        private void BuildPropertyBackings(List<MemberDeclarationSyntax> members)
        {
            var propertyNames = new List<string>();

            this.BuildPropertyNameDeclarations(members, propertyNames);
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

        private void BuildPropertyNameDeclarations(List<MemberDeclarationSyntax> members, List<string> propertyNames)
        {
            foreach (PropertyDeclaration property in this.Properties)
            {
                string propertyNameFieldName = GetPropertyNameFieldName(property);
                this.BuildPropertyNameDeclaration(propertyNameFieldName, property.JsonPropertyName, members);
                propertyNames.Add(propertyNameFieldName);
            }
        }

        private void BuildEncodedPropertyNameDeclarations(List<string> propertyNameFieldNames, List<MemberDeclarationSyntax> members)
        {
            foreach (string propertyNameFieldName in propertyNameFieldNames)
            {
                this.BuildEncodedPropertyNameDeclaration(propertyNameFieldName, members);
            }
        }

        private void BuildPropertyNameBytesDeclarations(List<string> propertyNameFieldNames, List<MemberDeclarationSyntax> members)
        {
            foreach (string propertyNameFieldName in propertyNameFieldNames)
            {
                this.BuildPropertyNameBytesDeclaration(propertyNameFieldName, members);
            }
        }

        private void AddKnownProperties(List<string> propertyNames, List<MemberDeclarationSyntax> members)
        {
            string knownPropertiesList = string.Join(", ", propertyNames.Select(n => $"{n}Bytes"));
            members.Add(SF.ParseMemberDeclaration($"private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create({knownPropertiesList});"));
        }

        private void BuildJsonElementAccessor(PropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            if (!property.Type.IsCompoundType)
            {
                return;
            }

            string camelCasePropertyName = NameFormatter.ToCamelCase(property.JsonPropertyName);

            string declaration =
            $"private System.Text.Json.JsonElement Get{NameFormatter.ToPascalCase(property.JsonPropertyName)}Element() " +
            "{ " +
            $"    if (this.{camelCasePropertyName}JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined) " +
            "    { " +
            $"        return this.{camelCasePropertyName}JsonElement; " +
            "    } " +
            " " +
            $"    if (this.HasJsonElement && this.JsonElement.TryGetProperty({GetPropertyNameFieldName(property)}Bytes.Span, out System.Text.Json.JsonElement value)) " +
            "    { " +
            "        return value; " +
            "    } " +
            " " +
            "    return default; " +
            "}";

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private void BuildAdditionalPropertiesAccessor(List<MemberDeclarationSyntax> members)
        {
            if (!(this.AdditionalPropertiesType is ITypeDeclaration additionalProperties))
            {
                return;
            }

            string fullyQualifiedPropertiesName = additionalProperties.GetFullyQualifiedName();
            string declaration =
            $"private Menes.JsonProperties<{fullyQualifiedPropertiesName}>? GetAdditionalProperties() " +
            "{ " +
            $"    if (this.additionalProperties is MenesJsonProperties<{fullyQualifiedPropertiesName}> props) " +
            "    { " +
            "        return props; " +
            "    } " +
            " " +
            $"    return new MenesJsonProperties<{fullyQualifiedPropertiesName}>(this.AdditionalProperties); " +
            "} ";

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private void BuildWithPropertyFactory(PropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            string declaration =
$" public {this.GetFullyQualifiedName()} With{NameFormatter.ToPascalCase(property.JsonPropertyName)}({property.Type.GetFullyQualifiedName()}? value) " +
" { " +
$"    return new {this.GetFullyQualifiedName()}(" + this.BuildWithParameters(property) + "); " +
" }";
            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private string BuildWithParameters(PropertyDeclaration property)
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

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                if (builder.Length > 0)
                {
                    builder.Append(", ");
                }

                builder.Append("this.GetAdditionalProperties()");
            }

            return builder.ToString();
        }

        private void BuildWithParameter(PropertyDeclaration property, StringBuilder builder, PropertyDeclaration current)
        {
            if (builder.Length > 0)
            {
                builder.Append(", ");
            }

            if (property == current)
            {
                builder.Append("value");
            }
            else if (current.Type.IsCompoundType)
            {
                builder.Append($"this.{NameFormatter.ToCamelCase(current.JsonPropertyName)}");
                builder.Append($", this.Get{NameFormatter.ToPascalCase(current.JsonPropertyName)}Element()");
            }
            else
            {
                builder.Append($"this.{NameFormatter.ToPascalCase(current.JsonPropertyName)}");
            }
        }

        private void BuildPropertyAccessor(PropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            if (property.Type.IsCompoundType)
            {
                string backingFieldName = NameFormatter.ToCamelCase(property.JsonPropertyName);
                members.Add(SF.ParseMemberDeclaration($"public {property.Type.GetFullyQualifiedName()}? {NameFormatter.ToPascalCase(property.JsonPropertyName)} => this.{backingFieldName}?.Value ?? (this.{backingFieldName}JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined ? new Menes.JsonArray<JsonObjectExample>(this.{backingFieldName}JsonElement) : {property.Type.GetFullyQualifiedName()}.FromOptionalProperty(this.JsonElement, {GetPropertyNameFieldName(property)}Bytes.Span).AsOptional);"));
            }
            else
            {
                members.Add(SF.ParseMemberDeclaration($"public {property.Type.GetFullyQualifiedName()}? {NameFormatter.ToPascalCase(property.JsonPropertyName)} => this.{NameFormatter.ToCamelCase(property.JsonPropertyName)} ?? {property.Type.GetFullyQualifiedName()}.FromOptionalProperty(this.JsonElement, {GetPropertyNameFieldName(property)}Bytes.Span).AsOptional;"));
            }
        }

        private void BuildPropertyBackingDeclaration(PropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            if (property.Type.IsCompoundType)
            {
                members.Add(SF.ParseMemberDeclaration($"private readonly Menes.ReferenceOf<{property.Type.GetFullyQualifiedName()}>? {NameFormatter.ToCamelCase(property.JsonPropertyName)};"));
                members.Add(SF.ParseMemberDeclaration($"private readonly Menes.ReferenceOf<{property.Type.GetFullyQualifiedName()}>? {NameFormatter.ToCamelCase(property.JsonPropertyName)};"));
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
