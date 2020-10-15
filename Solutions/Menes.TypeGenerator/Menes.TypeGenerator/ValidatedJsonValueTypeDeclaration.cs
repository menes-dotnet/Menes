// <copyright file="ValidatedJsonValueTypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.Json;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    /// <summary>
    /// Represents a validated <see cref="JsonValueTypeDeclaration"/> type.
    /// </summary>
    public class ValidatedJsonValueTypeDeclaration : ITypeDeclaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatedJsonValueTypeDeclaration"/> class.
        /// </summary>
        /// <param name="name">The name of the validated type.</param>
        /// <param name="validatedType">The name of the type of the item in the array.</param>
        public ValidatedJsonValueTypeDeclaration(string name, JsonValueTypeDeclaration? validatedType = null)
        {
            this.Name = name;
            this.ValidatedType = validatedType;
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<MethodDeclaration> Methods => TypeDeclaration.EmptyMethodDeclarations;

        /// <inheritdoc/>
        public IReadOnlyCollection<PropertyDeclaration> Properties => TypeDeclaration.EmptyPropertyDeclarations;

        /// <inheritdoc/>
        public IReadOnlyCollection<ITypeDeclaration> TypeDeclarations => TypeDeclaration.EmptyTypeDeclarations;

        /// <inheritdoc/>
        public string Name { get; }

        /// <inheritdoc/>
        public IDeclaration? Parent { get; set; }

        /// <inheritdoc/>
        public bool ShouldGenerate => true;

        /// <summary>
        /// Gets or sets the type of the validated type.
        /// </summary>
        public JsonValueTypeDeclaration? ValidatedType { get; set; }

        /// <summary>
        /// Gets or sets the type of the not validation.
        /// </summary>
        public ITypeDeclaration? NotTypeValidation { get; set; }

        /// <summary>
        /// Gets or sets the JSON array of objects for the enum validation.
        /// </summary>
        public string? EnumValidation { get; set; }

        /// <summary>
        /// Gets or sets the JSON object for the const validation.
        /// </summary>
        public string? ConstValidation { get; set; }

        /// <summary>
        /// Gets or sets the maximum length of a string.
        /// </summary>
        public int? MaxLengthValidation { get; set; }

        /// <summary>
        /// Gets or sets the minimum length of a string.
        /// </summary>
        public int? MinLengthValidation { get; set; }

        /// <summary>
        /// Gets or sets a numeric value for "multipleOf" as a string.
        /// </summary>
        public JsonNumber? MultipleOfValidation { get; set; }

        /// <summary>
        /// Gets or sets a numeric value for "maximum" as a string.
        /// </summary>
        public JsonNumber? MaximumValidation { get; set; }

        /// <summary>
        /// Gets or sets a numeric value for "exclusiveMaximum" as a string.
        /// </summary>
        public JsonNumber? ExclusiveMaximumValidation { get; set; }

        /// <summary>
        /// Gets or sets a numeric value for "minimum" as a string.
        /// </summary>
        public JsonNumber? MinimumValidation { get; set; }

        /// <summary>
        /// Gets or sets a numeric value for "exclusiveMinimum" as a string.
        /// </summary>
        public JsonNumber? ExclusiveMinimumValidation { get; set; }

        /// <summary>
        /// Gets or sets the Regular Expression pattern validation for a string.
        /// </summary>
        public string? PatternValidation { get; set; }

        /// <inheritdoc/>
        public bool IsCompoundType => false;

        /// <inheritdoc/>
        public void AddMethodDeclaration(MethodDeclaration methodDeclaration)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public void AddPropertyDeclaration(PropertyDeclaration propertyDeclaration)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public void AddTypeDeclaration(ITypeDeclaration typeDeclaration)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public bool ContainsMethod(string name)
        {
            return false;
        }

        /// <inheritdoc/>
        public bool ContainsProperty(string name)
        {
            return false;
        }

        /// <inheritdoc/>
        public bool ContainsTypeDeclaration(string name)
        {
            return false;
        }

        /// <inheritdoc/>
        public TypeDeclarationSyntax GenerateType()
        {
            if (this.ValidatedType is null)
            {
                throw new InvalidOperationException("You must set the type to be validated before generating the type.");
            }

            var builder = new StringBuilder();
            string validatedTypeFullyQualifiedName = this.ValidatedType.GetFullyQualifiedName();
            string name = this.Name;
            builder.AppendLine($"public readonly struct {name} : Menes.IJsonValue, System.IEquatable<{name}>");
            builder.AppendLine("{");

            builder.AppendLine($"    public static readonly System.Func<System.Text.Json.JsonElement, {name}> FromJsonElement = e => new {name}(e);");
            builder.AppendLine($"    public static readonly {name} Null = new {name}(default(System.Text.Json.JsonElement));");

            builder.AppendLine($"    private static readonly {this.ValidatedType.RawClrType}? ConstValue = BuildConstValue();");
            builder.AppendLine($"    private static readonly System.Collections.Immutable.ImmutableArray<{this.ValidatedType.RawClrType}>? EnumValues = BuildEnumValues();");

            if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.String)
            {
                builder.AppendLine($"    private static readonly int? MaxLength = {this.MaxLengthValidation?.ToString() ?? "null"};");
                builder.AppendLine($"    private static readonly int? MinLength = {this.MaxLengthValidation?.ToString() ?? "null"};");

                if (this.PatternValidation is string pattern)
                {
                    builder.AppendLine($"    private static readonly System.Text.RegularExpressions.Regex? Pattern = new System.Text.RegularExpressions.Regex({StringFormatter.EscapeForCSharpString(pattern, true)}, System.Text.RegularExpressions.RegexOptions.Compiled);");
                }
                else
                {
                    builder.AppendLine($"    private static readonly System.Text.RegularExpressions.Regex? Pattern = null;");
                }
            }
            else if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.Number)
            {
                builder.AppendLine($"    private static readonly {this.ValidatedType.RawClrType}? MultipleOf = {this.MultipleOfValidation?.ToString() ?? "null"};");
                builder.AppendLine($"    private static readonly {this.ValidatedType.RawClrType}? Maximum = {this.MaximumValidation?.ToString() ?? "null"};");
                builder.AppendLine($"    private static readonly {this.ValidatedType.RawClrType}? ExclusiveMaximum = {this.ExclusiveMaximumValidation?.ToString() ?? "null"};");
                builder.AppendLine($"    private static readonly {this.ValidatedType.RawClrType}? Minimum = {this.MinimumValidation?.ToString() ?? "null"};");
                builder.AppendLine($"    private static readonly {this.ValidatedType.RawClrType}? ExclusiveMinimum = {this.ExclusiveMinimumValidation?.ToString() ?? "null"};");
            }
            else if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.Decimal)
            {
                builder.AppendLine($"    private static readonly {this.ValidatedType.RawClrType}? MultipleOf = {GetDecimalFor(this.MultipleOfValidation?.ToString())};");
                builder.AppendLine($"    private static readonly {this.ValidatedType.RawClrType}? Maximum = {GetDecimalFor(this.MaximumValidation?.ToString())};");
                builder.AppendLine($"    private static readonly {this.ValidatedType.RawClrType}? ExclusiveMaximum = {GetDecimalFor(this.ExclusiveMaximumValidation?.ToString())};");
                builder.AppendLine($"    private static readonly {this.ValidatedType.RawClrType}? Minimum = {GetDecimalFor(this.MinimumValidation?.ToString())};");
                builder.AppendLine($"    private static readonly {this.ValidatedType.RawClrType}? ExclusiveMinimum = {GetDecimalFor(this.ExclusiveMinimumValidation?.ToString())};");
            }

            builder.AppendLine($"    private readonly {validatedTypeFullyQualifiedName}? value;");
            builder.AppendLine($"    public {name}({validatedTypeFullyQualifiedName} value)");
            builder.AppendLine("    {");
            builder.AppendLine($"        if (value.HasJsonElement)");
            builder.AppendLine("        {");
            builder.AppendLine("            this.JsonElement = value.JsonElement;");
            builder.AppendLine("            this.value = null;");
            builder.AppendLine("        }");
            builder.AppendLine("        else");
            builder.AppendLine("        {");
            builder.AppendLine("            this.value = value;");
            builder.AppendLine("            this.JsonElement = default;");
            builder.AppendLine("        }");
            builder.AppendLine("    }");
            builder.AppendLine($"    public {name}(System.Text.Json.JsonElement jsonElement)");
            builder.AppendLine("    {");
            builder.AppendLine("        this.value = null;");
            builder.AppendLine("        this.JsonElement = jsonElement;");
            builder.AppendLine("    }");
            builder.AppendLine("    public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);");
            builder.AppendLine($"    public {name}? AsOptional => this.IsNull ? default({name}?) : this;");
            builder.AppendLine("    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;");
            builder.AppendLine("    public System.Text.Json.JsonElement JsonElement { get; }");
            builder.AppendLine($"    public static implicit operator {name}({validatedTypeFullyQualifiedName} value)");
            builder.AppendLine("    {");
            builder.AppendLine($"        return new {name}(value);");
            builder.AppendLine("    }");

            if (this.ValidatedType.RawClrType != validatedTypeFullyQualifiedName)
            {
                builder.AppendLine($"    public static implicit operator {name}({this.ValidatedType.RawClrType} value)");
                builder.AppendLine("    {");
                builder.AppendLine($"        return new {name}(value);");
                builder.AppendLine("    }");
            }

            builder.AppendLine($"    public static implicit operator {validatedTypeFullyQualifiedName}({name} value)");
            builder.AppendLine("    {");
            builder.AppendLine($"        if (value.value is {validatedTypeFullyQualifiedName} clrValue)");
            builder.AppendLine("        {");
            builder.AppendLine("            return clrValue;");
            builder.AppendLine("        }");
            builder.AppendLine($"        return new {validatedTypeFullyQualifiedName}(value.JsonElement);");
            builder.AppendLine("    }");
            builder.AppendLine("    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)");
            builder.AppendLine("    {");
            builder.AppendLine($"        return {validatedTypeFullyQualifiedName}.IsConvertibleFrom(jsonElement);");
            builder.AppendLine("    }");
            builder.AppendLine($"    public static {name} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>");
            builder.AppendLine("        parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? {name}.FromJsonElement(property)");
            builder.AppendLine("            : Null;");
            builder.AppendLine($"    public static {name} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>");
            builder.AppendLine("        parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? {name}.FromJsonElement(property)");
            builder.AppendLine("            : Null;");
            builder.AppendLine($"    public static {name} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>");
            builder.AppendLine("        parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? {name}.FromJsonElement(property)");
            builder.AppendLine("            : Null;");
            builder.AppendLine($"    public bool Equals({name} other)");
            builder.AppendLine("    {");
            builder.AppendLine($"        return this.Equals(({validatedTypeFullyQualifiedName})other);");
            builder.AppendLine("    }");
            builder.AppendLine($"    public bool Equals({validatedTypeFullyQualifiedName} other)");
            builder.AppendLine("    {");
            builder.AppendLine($"        return (({validatedTypeFullyQualifiedName})this).Equals(other);");
            builder.AppendLine("    }");
            builder.AppendLine("    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)");
            builder.AppendLine("    {");
            builder.AppendLine($"        {validatedTypeFullyQualifiedName} value = this;");
            builder.AppendLine("        Menes.ValidationContext context = validationContext;");
            builder.AppendLine("        context = value.Validate(context);");

            if (this.NotTypeValidation is ITypeDeclaration notType)
            {
                builder.AppendLine($"context = Menes.Validation.ValidateNot<{validatedTypeFullyQualifiedName}, {notType.GetFullyQualifiedName()}>(context, this);");
            }

            if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.String)
            {
                builder.AppendLine($"context = value.ValidateAsString(context, MinLength, MaxLength, Pattern, EnumValues, ConstValue);");
            }
            else if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.Decimal || this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.Number)
            {
                builder.AppendLine($"context = value.ValidateAsNumber(context, MultipleOf, Maximum, ExclusiveMaximum, Minimum, ExclusiveMinimum, EnumValues, ConstValue);");
            }
            else if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.Boolean)
            {
                builder.AppendLine($"context = value.ValidateAsBoolean(context, EnumValues, ConstValue);");
            }

            builder.AppendLine("return context;");
            builder.AppendLine("    }");
            builder.AppendLine("    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)");
            builder.AppendLine("    {");
            builder.AppendLine("        if (this.HasJsonElement)");
            builder.AppendLine("        {");
            builder.AppendLine("            this.JsonElement.WriteTo(writer);");
            builder.AppendLine("        }");
            builder.AppendLine($"       else if (this.value is {validatedTypeFullyQualifiedName} clrValue)");
            builder.AppendLine("        {");
            builder.AppendLine("            clrValue.WriteTo(writer);");
            builder.AppendLine("        }");
            builder.AppendLine("    }");

            if (this.ConstValidation is string constValue)
            {
                builder.AppendLine($"private static {this.ValidatedType.RawClrType}? BuildConstValue()");
                builder.AppendLine("{");
                if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.Decimal)
                {
                    builder.AppendLine($"    return {constValue}M;");
                }
                else
                {
                    builder.AppendLine($"    return {constValue};");
                }

                builder.AppendLine("}");
            }
            else
            {
                builder.AppendLine($"private static {this.ValidatedType.RawClrType}? BuildConstValue()");
                builder.AppendLine("{");
                builder.AppendLine("    return null;");
                builder.AppendLine("}");
            }

            if (this.EnumValidation is string enumValidation)
            {
                builder.AppendLine($"    private static System.Collections.Immutable.ImmutableArray<{this.ValidatedType.RawClrType}>? BuildEnumValues()");
                builder.AppendLine("    {");
                builder.AppendLine($"        System.Collections.Immutable.ImmutableArray<{this.ValidatedType.RawClrType}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{this.ValidatedType.RawClrType}>();");

                using var document = JsonDocument.Parse(enumValidation);
                JsonElement.ArrayEnumerator enumerator = document.RootElement.EnumerateArray();
                while (enumerator.MoveNext())
                {
                    if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.Decimal)
                    {
                        builder.AppendLine($"arrayBuilder.Add({enumerator.Current.GetRawText()}M);");
                    }
                    else
                    {
                        builder.AppendLine($"arrayBuilder.Add({enumerator.Current.GetRawText()});");
                    }
                }

                builder.AppendLine("        return arrayBuilder.ToImmutable();");
                builder.AppendLine("    }");
            }
            else
            {
                builder.AppendLine($"private static System.Collections.Immutable.ImmutableArray<{this.ValidatedType.RawClrType}>? BuildEnumValues()");
                builder.AppendLine("{");
                builder.AppendLine("    return null;");
                builder.AppendLine("}");
            }

            builder.AppendLine("}");
            return (TypeDeclarationSyntax)SF.ParseMemberDeclaration(builder.ToString());
        }

        /// <inheritdoc/>
        public IDeclaration GetTypeDeclaration(string name)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public bool IsSpecializedBy(ITypeDeclaration type)
        {
            if (this.ValidatedType is null)
            {
                throw new InvalidOperationException("You must set the ItemType before calling IsSpecializedBy(ITypeDeclaration).");
            }

            return false;
        }

        private static string GetDecimalFor(string? optionalValue)
        {
            return optionalValue is string value ? value + "M" : "null";
        }
    }
}
