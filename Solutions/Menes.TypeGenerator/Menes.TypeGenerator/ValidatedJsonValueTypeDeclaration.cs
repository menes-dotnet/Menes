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
    public class ValidatedJsonValueTypeDeclaration : TypeDeclaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatedJsonValueTypeDeclaration"/> class.
        /// </summary>
        /// <param name="name">The name of the validated type.</param>
        /// <param name="validatedType">The name of the type of the item in the array.</param>
        public ValidatedJsonValueTypeDeclaration(string name, JsonValueTypeDeclaration? validatedType = null)
            : base(name)
        {
            this.ValidatedType = validatedType;
        }

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
        /// Gets or sets the allOf type validation.
        /// </summary>
        public List<ITypeDeclaration>? AllOfTypeValidation { get; set; }

        /// <summary>
        /// Gets or sets the anyOf type validation.
        /// </summary>
        public List<ITypeDeclaration>? AnyOfTypeValidation { get; set; }

        /// <summary>
        /// Gets or sets the oneOf type validation.
        /// </summary>
        public List<ITypeDeclaration>? OneOfTypeValidation { get; set; }

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
        public override bool IsCompoundType => false;

        /// <inheritdoc/>
        public override TypeDeclarationSyntax GenerateType()
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

            if (this.EnumValidation is string)
            {
                builder.AppendLine($"    public static readonly System.Collections.Immutable.ImmutableArray<{this.ValidatedType.RawClrTypes[0]}> EnumValues = BuildEnumValues();");
            }

            if (this.EnumValidation is string enumValidation)
            {
                int enumIndex = 0;
                using var document = JsonDocument.Parse(enumValidation);
                JsonElement.ArrayEnumerator enumerator = document.RootElement.EnumerateArray();
                while (enumerator.MoveNext())
                {
                    string baseEnumPropertyName = StringFormatter.ToPascalCaseWithReservedWords(enumerator.Current.GetRawText());
                    string enumPropertyName = baseEnumPropertyName;
                    int enumNameIndex = 1;

                    while (enumPropertyName == "Null" || enumPropertyName == "ConstValue" || enumPropertyName == "EnumValues" || enumPropertyName == "MultipleOf" || enumPropertyName == "Maximum" || enumPropertyName == "ExclusiveMaximum" || enumPropertyName == "Minumum" || enumPropertyName == "ExclusiveMinimum")
                    {
                        enumPropertyName = baseEnumPropertyName + enumNameIndex;
                        enumNameIndex++;
                    }

                    builder.AppendLine($"    public static readonly {name} {enumPropertyName} = new {name}(EnumValues[{enumIndex}]);");
                    enumIndex++;
                }
            }

            if (this.ConstValidation is string)
            {
                builder.AppendLine($"    private static readonly {this.ValidatedType.RawClrTypes[0]} ConstValue = BuildConstValue();");
            }

            if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.String)
            {
                this.AppendStringValidationProperties(builder);
            }
            else if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.Number)
            {
                this.AppendNumberValidationProperties(builder);
            }
            else if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.Decimal)
            {
                builder.AppendLine($"    private static readonly Menes.JsonNumber? MultipleOf = {GetDecimalFor(this.MultipleOfValidation?.ToString())};");
                builder.AppendLine($"    private static readonly Menes.JsonNumber? Maximum = {GetDecimalFor(this.MaximumValidation?.ToString())};");
                builder.AppendLine($"    private static readonly Menes.JsonNumber? ExclusiveMaximum = {GetDecimalFor(this.ExclusiveMaximumValidation?.ToString())};");
                builder.AppendLine($"    private static readonly Menes.JsonNumber? Minimum = {GetDecimalFor(this.MinimumValidation?.ToString())};");
                builder.AppendLine($"    private static readonly Menes.JsonNumber? ExclusiveMinimum = {GetDecimalFor(this.ExclusiveMinimumValidation?.ToString())};");
            }
            else if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.Any)
            {
                if (this.MinLengthValidation.HasValue || this.MaxLengthValidation.HasValue || !(this.PatternValidation is null))
                {
                    this.AppendStringValidationProperties(builder);
                }

                if (this.MultipleOfValidation.HasValue || this.MaximumValidation.HasValue || this.ExclusiveMaximumValidation.HasValue || this.MinimumValidation.HasValue || this.ExclusiveMinimumValidation.HasValue)
                {
                    this.AppendNumberValidationProperties(builder);
                }
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

            foreach (string clrType in this.ValidatedType.RawClrTypes)
            {
                if (clrType != validatedTypeFullyQualifiedName)
                {
                    builder.AppendLine($"    public static implicit operator {name}({clrType} value)");
                    builder.AppendLine("    {");
                    builder.AppendLine($"        return new {name}(value);");
                    builder.AppendLine("    }");
                }
            }

            foreach (string clrType in this.ValidatedType.RawClrTypes)
            {
                if (clrType != validatedTypeFullyQualifiedName)
                {
                    builder.AppendLine($"    public static implicit operator {clrType}({name} value)");
                    builder.AppendLine("    {");
                    builder.AppendLine($"        return ({clrType})({validatedTypeFullyQualifiedName})value;");
                    builder.AppendLine("    }");
                }
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
            builder.AppendLine($"   public static {name} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>");
            builder.AppendLine($"      parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?");
            builder.AppendLine("           (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"               ? new {name}(property)");
            builder.AppendLine("               : Null)");
            builder.AppendLine("           : Null;");
            builder.AppendLine($"   public static {name} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>");
            builder.AppendLine($"      parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?");
            builder.AppendLine("           (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"               ? new {name}(property)");
            builder.AppendLine("               : Null)");
            builder.AppendLine("           : Null;");
            builder.AppendLine($"   public static {name} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>");
            builder.AppendLine($"      parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?");
            builder.AppendLine("           (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"               ? new {name}(property)");
            builder.AppendLine("               : Null)");
            builder.AppendLine("           : Null;");

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

            if (this.AllOfTypeValidation is List<ITypeDeclaration> allOf)
            {
                for (int i = 0; i < allOf.Count; ++i)
                {
                    builder.AppendLine($"        Menes.ValidationContext allOfValidationContext{i + 1} = Menes.ValidationContext.Root.WithPath(context.Path);");
                }

                int index = 0;
                foreach (ITypeDeclaration allOfType in allOf)
                {
                    string allOfFullyQualifiedName = allOfType.GetFullyQualifiedName();
                    string allOfTypeNameCamelCase = StringFormatter.ToCamelCaseWithReservedWords(allOfType.Name);
                    builder.AppendLine($"{allOfFullyQualifiedName} {allOfTypeNameCamelCase}AllOfValue{index} = Menes.JsonAny.From(value).As<{allOfFullyQualifiedName}>();");
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

            if (this.AnyOfTypeValidation is List<ITypeDeclaration> anyOf)
            {
                for (int i = 0; i < anyOf.Count; ++i)
                {
                    builder.AppendLine($"        Menes.ValidationContext anyOfValidationContext{i + 1} = Menes.ValidationContext.Root.WithPath(context.Path);");
                }

                int index = 0;
                foreach (ITypeDeclaration anyOfType in anyOf)
                {
                    string anyOfFullyQualifiedName = anyOfType.GetFullyQualifiedName();
                    string anyOfTypeNameCamelCase = StringFormatter.ToCamelCaseWithReservedWords(anyOfType.Name);
                    builder.AppendLine($"{anyOfFullyQualifiedName} anyOfitem{index + 1} = Menes.JsonAny.From(value).As<{anyOfFullyQualifiedName}>();");
                    builder.AppendLine($"            anyOfValidationContext{index + 1} = anyOfitem{index + 1}.Validate(anyOfValidationContext{index + 1});");
                    index++;
                }

                builder.Append("        context = Menes.Validation.ValidateAnyOf(context");

                index = 0;
                foreach (ITypeDeclaration anyOfType in anyOf)
                {
                    builder.Append(", ");
                    builder.Append($"anyOfValidationContext{index + 1}");
                    index++;
                }

                builder.AppendLine(");");
            }

            if (this.OneOfTypeValidation is List<ITypeDeclaration> oneOf)
            {
                for (int i = 0; i < oneOf.Count; ++i)
                {
                    builder.AppendLine($"        Menes.ValidationContext oneOfValidationContext{i + 1} = Menes.ValidationContext.Root.WithPath(context.Path);");
                }

                int index = 0;
                foreach (ITypeDeclaration oneOfType in oneOf)
                {
                    string oneOfFullyQualifiedName = oneOfType.GetFullyQualifiedName();
                    string oneOfTypeNameCamelCase = StringFormatter.ToCamelCaseWithReservedWords(oneOfType.Name);
                    builder.AppendLine($"{oneOfFullyQualifiedName} {oneOfTypeNameCamelCase}OneOfValue{index} = Menes.JsonAny.From(value).As<{oneOfFullyQualifiedName}>();");
                    builder.AppendLine($"            oneOfValidationContext{index + 1} = {oneOfTypeNameCamelCase}OneOfValue{index}.Validate(oneOfValidationContext{index + 1});");
                    index++;
                }

                builder.Append("        context = Menes.Validation.ValidateOneOf(context");

                index = 0;
                foreach (ITypeDeclaration oneOfType in oneOf)
                {
                    builder.Append(", ");
                    builder.Append($"oneOfValidationContext{index + 1}");
                    index++;
                }

                builder.AppendLine(");");
            }

            string enumValuesAccessor = this.EnumValidation is null ? $"(System.Collections.Immutable.ImmutableArray<{this.ValidatedType.RawClrTypes[0]}>?)null" : "EnumValues";
            string constValueAccessor = this.ConstValidation is null ? $"({this.ValidatedType.RawClrTypes[0]}?)null" : "ConstValue";

            if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.String)
            {
                builder.AppendLine($"context = value.ValidateAsString(context, MaxLength, MinLength, Pattern, {enumValuesAccessor}, {constValueAccessor});");
            }
            else if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.Decimal || this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.Number)
            {
                builder.AppendLine($"context = value.ValidateAsNumber(context, MultipleOf, Maximum, ExclusiveMaximum, Minimum, ExclusiveMinimum, {enumValuesAccessor}, {constValueAccessor});");
            }
            else if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.Boolean)
            {
                builder.AppendLine($"context = value.ValidateAsBoolean(context, {enumValuesAccessor}, {constValueAccessor});");
            }
            else if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.Any)
            {
                if (this.MinLengthValidation.HasValue || this.MaxLengthValidation.HasValue || !(this.PatternValidation is null))
                {
                    builder.AppendLine($"context = value.As<Menes.JsonString>().ValidateAsString(context, MaxLength, MinLength, Pattern, null, null);");
                }

                if (this.MultipleOfValidation.HasValue || this.MaximumValidation.HasValue || this.ExclusiveMaximumValidation.HasValue || this.MinimumValidation.HasValue || this.ExclusiveMinimumValidation.HasValue)
                {
                    builder.AppendLine($"context = value.As<Menes.JsonNumber>().ValidateAsNumber(context, MultipleOf, Maximum, ExclusiveMaximum, Minimum, ExclusiveMinimum, null, null);");
                }

                if (!(this.EnumValidation is null))
                {
                    builder.AppendLine($"context = Menes.Validation.ValidateEnum(context, value, {enumValuesAccessor});");
                }

                if (!(this.ConstValidation is null))
                {
                    builder.AppendLine($"context = Menes.Validation.ValidateConst(context, value, {constValueAccessor});");
                }
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

            builder.AppendLine("public override string ToString()");
            builder.AppendLine("{");
            builder.AppendLine($"        if (this.value is {validatedTypeFullyQualifiedName} clrValue)");
            builder.AppendLine("        {");
            builder.AppendLine("            return clrValue.ToString();");
            builder.AppendLine("        }");
            builder.AppendLine("        else");
            builder.AppendLine("        {");
            builder.AppendLine("             return this.JsonElement.GetRawText();");
            builder.AppendLine("        }");
            builder.AppendLine("}");

            if (this.ConstValidation is string constValue)
            {
                builder.AppendLine($"private static {this.ValidatedType.RawClrTypes[0]} BuildConstValue()");
                builder.AppendLine("{");
                if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.Decimal)
                {
                    builder.AppendLine($"    return {constValue}M;");
                }
                else if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.Any)
                {
                    builder.AppendLine($"    using var document = System.Text.Json.JsonDocument.Parse({StringFormatter.EscapeForCSharpString(constValue, true)});");
                    builder.AppendLine($"    return new {this.ValidatedType.RawClrTypes[0]}(document.RootElement.Clone());");
                }
                else
                {
                    builder.AppendLine($"    return {constValue};");
                }

                builder.AppendLine("}");
            }

            if (this.EnumValidation is string enumValidation1)
            {
                builder.AppendLine($"    private static System.Collections.Immutable.ImmutableArray<{this.ValidatedType.RawClrTypes[0]}> BuildEnumValues()");
                builder.AppendLine("    {");
                builder.AppendLine($"        System.Collections.Immutable.ImmutableArray<{this.ValidatedType.RawClrTypes[0]}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{this.ValidatedType.RawClrTypes[0]}>();");

                if (this.ValidatedType.Kind == JsonValueTypeDeclaration.ValueKind.Any)
                {
                    builder.AppendLine($"using var document = System.Text.Json.JsonDocument.Parse({StringFormatter.EscapeForCSharpString(enumValidation1, true)});");
                    builder.AppendLine("System.Text.Json.JsonElement.ArrayEnumerator enumerator = document.RootElement.EnumerateArray();");
                    builder.AppendLine("while (enumerator.MoveNext())");
                    builder.AppendLine("{");
                    builder.AppendLine("    arrayBuilder.Add(new Menes.JsonAny(enumerator.Current.Clone()));");
                    builder.AppendLine("}");
                }
                else
                {
                    using var document = JsonDocument.Parse(enumValidation1);
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
                }

                builder.AppendLine("        return arrayBuilder.ToImmutable();");
                builder.AppendLine("    }");
            }

            builder.AppendLine("}");
            var tds = (TypeDeclarationSyntax)SF.ParseMemberDeclaration(builder.ToString());
            return this.BuildNestedTypes(tds);
        }

        /// <inheritdoc/>
        public override bool IsSpecializedBy(ITypeDeclaration type)
        {
            if (this.ValidatedType is null)
            {
                throw new InvalidOperationException("You must set the ItemType before calling IsSpecializedBy(ITypeDeclaration).");
            }

            return false;
        }

        /// <inheritdoc/>
        public override bool ContainsReference(ITypeDeclaration typeDeclaration, IList<ITypeDeclaration> visitedDeclarations)
        {
            if (this.ValidatedType is ITypeDeclaration itemType && CheckType(typeDeclaration, visitedDeclarations, itemType))
            {
                return true;
            }

            return base.ContainsReference(typeDeclaration, visitedDeclarations);
        }

        private static string GetDecimalFor(string? optionalValue)
        {
            return optionalValue is string value ? value + "M" : "null";
        }

        private void AppendNumberValidationProperties(StringBuilder builder)
        {
            builder.AppendLine($"    private static readonly Menes.JsonNumber? MultipleOf = {this.MultipleOfValidation?.ToString() ?? "null"};");
            builder.AppendLine($"    private static readonly Menes.JsonNumber? Maximum = {this.MaximumValidation?.ToString() ?? "null"};");
            builder.AppendLine($"    private static readonly Menes.JsonNumber? ExclusiveMaximum = {this.ExclusiveMaximumValidation?.ToString() ?? "null"};");
            builder.AppendLine($"    private static readonly Menes.JsonNumber? Minimum = {this.MinimumValidation?.ToString() ?? "null"};");
            builder.AppendLine($"    private static readonly Menes.JsonNumber? ExclusiveMinimum = {this.ExclusiveMinimumValidation?.ToString() ?? "null"};");
        }

        private void AppendStringValidationProperties(StringBuilder builder)
        {
            builder.AppendLine($"    private static readonly int? MaxLength = {this.MaxLengthValidation?.ToString() ?? "null"};");
            builder.AppendLine($"    private static readonly int? MinLength = {this.MinLengthValidation?.ToString() ?? "null"};");

            if (this.PatternValidation is string pattern)
            {
                builder.AppendLine($"    private static readonly System.Text.RegularExpressions.Regex? Pattern = new System.Text.RegularExpressions.Regex({StringFormatter.EscapeForCSharpString(pattern, true)}, System.Text.RegularExpressions.RegexOptions.Compiled);");
            }
            else
            {
                builder.AppendLine($"    private static readonly System.Text.RegularExpressions.Regex? Pattern = null;");
            }
        }

        private TypeDeclarationSyntax BuildNestedTypes(TypeDeclarationSyntax tds)
        {
            foreach (ITypeDeclaration declaration in this.TypeDeclarations)
            {
                tds = tds.AddMembers((MemberDeclarationSyntax)declaration.GenerateType());
            }

            return tds;
        }
    }
}
