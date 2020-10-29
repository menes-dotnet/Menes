// <copyright file="ValidatedArrayTypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    /// <summary>
    /// Represents a validated <c>array</c> type.
    /// </summary>
    public class ValidatedArrayTypeDeclaration : ITypeDeclaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatedArrayTypeDeclaration"/> class.
        /// </summary>
        /// <param name="name">The name of the array.</param>
        /// <param name="itemType">The name of the type of the item in the array.</param>
        public ValidatedArrayTypeDeclaration(string name, ITypeDeclaration? itemType = null)
        {
            this.Name = name;
            this.ItemType = itemType;
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
        /// Gets or sets the type of the item in the array.
        /// </summary>
        public ITypeDeclaration? ItemType { get; set; }

        /// <summary>
        /// Gets or sets the minimum items validation.
        /// </summary>
        public int? MinItemsValidation { get; set; }

        /// <summary>
        /// Gets or sets the maximum items validation.
        /// </summary>
        public int? MaxItemsValidation { get; set; }

        /// <summary>
        /// Gets or sets the type for the contains validation.
        /// </summary>
        public ITypeDeclaration? ContainsValidation { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of items of the <see cref="ContainsValidation"/> type.
        /// </summary>
        public int? MinContainsValidation { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of items of the <see cref="ContainsValidation"/> type.
        /// </summary>
        public int? MaxContainsValidation { get; set; }

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
        /// Gets or sets a value indicating whether we require unique values.
        /// </summary>
        public bool? UniqueValidation { get; set; }

        /// <inheritdoc/>
        public bool IsCompoundType => true;

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
            if (this.ItemType is null)
            {
                throw new InvalidOperationException("You must set the item type before generating the type.");
            }

            var builder = new StringBuilder();
            string itemFullyQualifiedName = this.ItemType.GetFullyQualifiedName();
            string name = this.Name;
            builder.AppendLine($"public readonly struct {name} : Menes.IJsonValue, System.Collections.Generic.IEnumerable<{itemFullyQualifiedName}>, System.Collections.IEnumerable, System.IEquatable<{name}>, System.IEquatable<Menes.JsonArray<{itemFullyQualifiedName}>>");
            builder.AppendLine("{");
            builder.AppendLine($"    public static readonly System.Func<System.Text.Json.JsonElement, {name}> FromJsonElement = e => new {name}(e);");
            builder.AppendLine($"    public static readonly {name} Null = new {name}(default(System.Text.Json.JsonElement));");
            if (this.ConstValidation is string)
            {
                builder.AppendLine("    private static readonly Menes.JsonReference? ConstantValue = BuildConstValue();");
            }

            if (this.EnumValidation is string)
            {
                builder.AppendLine("    private static readonly Menes.JsonReference? EnumValues = BuildEnumValues();");
            }

            builder.AppendLine($"    private readonly Menes.JsonArray<{itemFullyQualifiedName}>? value;");
            builder.AppendLine($"    public {name}(Menes.JsonArray<{itemFullyQualifiedName}> jsonArray)");
            builder.AppendLine("    {");
            builder.AppendLine($"        if (jsonArray.HasJsonElement)");
            builder.AppendLine("        {");
            builder.AppendLine("            this.JsonElement = jsonArray.JsonElement;");
            builder.AppendLine("            this.value = null;");
            builder.AppendLine("        }");
            builder.AppendLine("        else");
            builder.AppendLine("        {");
            builder.AppendLine("            this.value = jsonArray;");
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
            builder.AppendLine($"    public static implicit operator {name}(Menes.JsonArray<{itemFullyQualifiedName}> value)");
            builder.AppendLine("    {");
            builder.AppendLine($"        return new {name}(value);");
            builder.AppendLine("    }");
            builder.AppendLine($"    public static implicit operator Menes.JsonArray<{itemFullyQualifiedName}>({name} value)");
            builder.AppendLine("    {");
            builder.AppendLine($"        if (value.value is Menes.JsonArray<{itemFullyQualifiedName}> clrValue)");
            builder.AppendLine("        {");
            builder.AppendLine("            return clrValue;");
            builder.AppendLine("        }");
            builder.AppendLine($"        return new Menes.JsonArray<{itemFullyQualifiedName}>(value.JsonElement);");
            builder.AppendLine("    }");
            builder.AppendLine("    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)");
            builder.AppendLine("    {");
            builder.AppendLine($"        return Menes.JsonArray<{itemFullyQualifiedName}>.IsConvertibleFrom(jsonElement);");
            builder.AppendLine("    }");
            builder.AppendLine($"public static {name} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>");
            builder.AppendLine($"   parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?");
            builder.AppendLine("        (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? new {name}(property)");
            builder.AppendLine("            : Null)");
            builder.AppendLine("        : Null;");
            builder.AppendLine($"public static {name} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>");
            builder.AppendLine($"   parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?");
            builder.AppendLine("        (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? new {name}(property)");
            builder.AppendLine("            : Null)");
            builder.AppendLine("        : Null;");
            builder.AppendLine($"public static {name} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>");
            builder.AppendLine($"   parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?");
            builder.AppendLine("        (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? new {name}(property)");
            builder.AppendLine("            : Null)");
            builder.AppendLine("        : Null;");
            builder.AppendLine($"    public bool Equals({name} other)");
            builder.AppendLine("    {");
            builder.AppendLine($"        return this.Equals((Menes.JsonArray<{itemFullyQualifiedName}>)other);");
            builder.AppendLine("    }");
            builder.AppendLine($"    public bool Equals(Menes.JsonArray<{itemFullyQualifiedName}> other)");
            builder.AppendLine("    {");
            builder.AppendLine($"        return ((Menes.JsonArray<{itemFullyQualifiedName}>)this).Equals(other);");
            builder.AppendLine("    }");
            builder.AppendLine("    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)");
            builder.AppendLine("    {");
            builder.AppendLine($"        Menes.JsonArray<{itemFullyQualifiedName}> array = this;");
            builder.AppendLine("        Menes.ValidationContext context = validationContext;");
            builder.AppendLine("        context = array.Validate(context);");

            if (this.MinItemsValidation is int minItems)
            {
                builder.AppendLine($"        context = array.ValidateMinItems(context, {minItems});");
            }

            if (this.MaxItemsValidation is int maxItems)
            {
                builder.AppendLine($"        context = array.ValidateMaxItems(context, {maxItems});");
            }

            if (this.ConstValidation is string)
            {
                builder.AppendLine($"Menes.Validation.ValidateConst(context, this, this.ConstValue.AsValue<{name}>());");
            }

            if (this.EnumValidation is string)
            {
                builder.AppendLine($"Menes.Validation.ValidateEnum(context, this, this.EnumValues.AsValue<Menes.JsonArray<{name}>>());");
            }

            if (this.ContainsValidation is ITypeDeclaration contains)
            {
                int minContains = this.MinContainsValidation ?? 1;
                int maxContains = this.MaxContainsValidation ?? int.MaxValue;
                builder.AppendLine($"        return array.ValidateRangeContains<{contains.GetFullyQualifiedName()}>(context, {minContains}, {maxContains}, {this.UniqueValidation}, true);");
            }
            else if (this.UniqueValidation is bool unique && unique)
            {
                builder.AppendLine("        return array.ValidateUniqueItems(context, true);");
            }
            else
            {
                builder.AppendLine("        return array.ValidateItems(context);");
            }

            builder.AppendLine("    }");
            builder.AppendLine("    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)");
            builder.AppendLine("    {");
            builder.AppendLine("        if (this.HasJsonElement)");
            builder.AppendLine("        {");
            builder.AppendLine("            this.JsonElement.WriteTo(writer);");
            builder.AppendLine("        }");
            builder.AppendLine($"        if (this.value is Menes.JsonArray<{itemFullyQualifiedName}> clrValue)");
            builder.AppendLine("        {");
            builder.AppendLine("            clrValue.WriteTo(writer);");
            builder.AppendLine("        }");
            builder.AppendLine("    }");
            builder.AppendLine($"    public Menes.JsonArray<{itemFullyQualifiedName}>.JsonArrayEnumerator GetEnumerator()");
            builder.AppendLine("    {");
            builder.AppendLine($"        return ((Menes.JsonArray<{itemFullyQualifiedName}>)this).GetEnumerator();");
            builder.AppendLine("    }");
            builder.AppendLine($"    System.Collections.Generic.IEnumerator<{itemFullyQualifiedName}> System.Collections.Generic.IEnumerable<{itemFullyQualifiedName}>.GetEnumerator()");
            builder.AppendLine("    {");
            builder.AppendLine("        return this.GetEnumerator();");
            builder.AppendLine("    }");
            builder.AppendLine("    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()");
            builder.AppendLine("    {");
            builder.AppendLine("        return this.GetEnumerator();");
            builder.AppendLine("    }");

            if (this.ConstValidation is string constValue)
            {
                builder.AppendLine("private static Menes.JsonReference BuildConstValue()");
                builder.AppendLine("{");
                builder.AppendLine($"    using var document = System.Text.Json.JsonDocument.Parse({StringFormatter.EscapeForCSharpString(constValue, true)});");
                builder.AppendLine("    return new Menes.JsonReference(document.RootElement.Clone());");
                builder.AppendLine("}");
            }

            if (this.EnumValidation is string enumValidation)
            {
                builder.AppendLine("    private static Menes.JsonReference BuildEnumValues()");
                builder.AppendLine("    {");
                builder.AppendLine($"        using var document = System.Text.Json.JsonDocument.Parse({StringFormatter.EscapeForCSharpString(enumValidation, true)});");
                builder.AppendLine("        return new Menes.JsonReference(document.RootElement.Clone());");
                builder.AppendLine("    }");
            }

            builder.AppendLine("}");
            return (TypeDeclarationSyntax)SF.ParseMemberDeclaration(builder.ToString());
        }

        /// <inheritdoc/>
        public ITypeDeclaration GetTypeDeclaration(string name)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public bool IsSpecializedBy(ITypeDeclaration type)
        {
            if (this.ItemType is null)
            {
                throw new InvalidOperationException("You must set the ItemType before calling IsSpecializedBy(ITypeDeclaration).");
            }

            // The array is specialized by an array of a type which is a specialized version of this item type.
            return type is ValidatedArrayTypeDeclaration arrayType && !(arrayType.ItemType is null) && this.ItemType.IsSpecializedBy(arrayType.ItemType);
        }
    }
}
