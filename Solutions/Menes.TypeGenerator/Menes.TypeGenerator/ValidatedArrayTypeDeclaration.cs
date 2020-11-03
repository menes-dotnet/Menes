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
    public class ValidatedArrayTypeDeclaration : TypeDeclaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatedArrayTypeDeclaration"/> class.
        /// </summary>
        /// <param name="name">The name of the array.</param>
        /// <param name="itemType">The name of the type of the item in the array.</param>
        public ValidatedArrayTypeDeclaration(string name, ITypeDeclaration? itemType = null)
            : base(name)
        {
            this.ItemType = itemType;
        }

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
        /// Gets or sets the ordered item schema of the items in the array.
        /// </summary>
        public List<ITypeDeclaration>? ItemsValidation { get; set; }

        /// <summary>
        /// Gets or sets the type declaration for additional items in the array.
        /// </summary>
        public ITypeDeclaration? AdditionalItemsValidation { get; set; }

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

        /// <summary>
        /// Gets or sets a value indicating whether to explicitly
        /// validate this as an array.
        /// </summary>
        public bool ValidateAsArray { get; set; }

        /// <inheritdoc/>
        public override TypeDeclarationSyntax GenerateType()
        {
            var builder = new StringBuilder();
            string itemFullyQualifiedName = (this.ItemType ?? AnyTypeDeclaration.Instance).GetFullyQualifiedName();
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

            if (this.ItemType is ValidatedJsonValueTypeDeclaration vjvtd)
            {
                string validatedTypeName = vjvtd.ValidatedType!.GetFullyQualifiedName();
                builder.AppendLine($"    public {name}(Menes.JsonArray<{validatedTypeName}> jsonArray)");
                builder.AppendLine("    {");
                builder.AppendLine($"        if (jsonArray.HasJsonElement)");
                builder.AppendLine("        {");
                builder.AppendLine("            this.JsonElement = jsonArray.JsonElement;");
                builder.AppendLine("            this.value = null;");
                builder.AppendLine("        }");
                builder.AppendLine("        else");
                builder.AppendLine("        {");
                builder.AppendLine($"               System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
                builder.AppendLine($"               foreach ({vjvtd.ValidatedType!.GetFullyQualifiedName()} item in jsonArray)");
                builder.AppendLine("               {");
                builder.AppendLine($"                   arrayBuilder.Add(item);");
                builder.AppendLine("               }");
                builder.AppendLine("            this.value = Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
                builder.AppendLine("            this.JsonElement = default;");
                builder.AppendLine("        }");
                builder.AppendLine("    }");
            }

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

            builder.AppendLine("public int Length");
            builder.AppendLine("{");
            builder.AppendLine("    get");
            builder.AppendLine("    {");
            builder.AppendLine("        if (this.HasJsonElement)");
            builder.AppendLine("        {");
            builder.AppendLine("            return this.JsonElement.GetArrayLength();");
            builder.AppendLine("        }");
            builder.AppendLine($"        if (this.value is Menes.JsonArray<{itemFullyQualifiedName}> value)");
            builder.AppendLine("        {");
            builder.AppendLine("            return value.Length;");
            builder.AppendLine("        }");
            builder.AppendLine("        return 0;");
            builder.AppendLine("    }");
            builder.AppendLine("}");

            builder.AppendLine("    public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);");
            builder.AppendLine($"    public {name}? AsOptional => this.IsNull ? default({name}?) : this;");
            builder.AppendLine("    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;");
            builder.AppendLine("    public System.Text.Json.JsonElement JsonElement { get; }");

            if (this.ItemType is ValidatedJsonValueTypeDeclaration vjvtd2)
            {
                string validatedTypeName = vjvtd2.ValidatedType!.GetFullyQualifiedName();

                builder.AppendLine($"    public static implicit operator {name}(Menes.JsonArray<{validatedTypeName}> value)");
                builder.AppendLine("    {");
                builder.AppendLine($"        return new {name}(value);");
                builder.AppendLine("    }");
            }

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
            builder.AppendLine($"   parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?");
            builder.AppendLine("        (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? new {name}(property)");
            builder.AppendLine("            : Null)");
            builder.AppendLine("        : Null;");
            builder.AppendLine($"public static {name} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>");
            builder.AppendLine($"   parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?");
            builder.AppendLine("        (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? new {name}(property)");
            builder.AppendLine("            : Null)");
            builder.AppendLine("        : Null;");
            builder.AppendLine($"public static {name} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>");
            builder.AppendLine($"   parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?");
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

            if (this.ValidateAsArray)
            {
                builder.AppendLine("    context = array.Validate(context);");
            }

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

            if (this.ItemsValidation is List<ITypeDeclaration> itemsValidation)
            {
                builder.AppendLine("var itemsValidationEnumerator = array.GetEnumerator();");

                int itemIndex = 0;

                foreach (ITypeDeclaration item in itemsValidation)
                {
                    builder.AppendLine("if (itemsValidationEnumerator.MoveNext())");
                    builder.AppendLine("{");
                    builder.AppendLine($"    context = Menes.Validation.ValidateProperty(context, Menes.JsonAny.From(itemsValidationEnumerator.Current).As<{item.GetFullyQualifiedName()}>(), $\"[{itemIndex}]\");");
                    builder.AppendLine("}");
                    itemIndex++;
                }

                if (this.AdditionalItemsValidation is ITypeDeclaration additionalItemsValidation)
                {
                    string fqtn = additionalItemsValidation.GetFullyQualifiedName();
                    builder.AppendLine("    int extraIndex = 0;");
                    builder.AppendLine("    while (itemsValidationEnumerator.MoveNext())");
                    builder.AppendLine("    {");
                    builder.AppendLine($"        context = Menes.Validation.ValidateProperty(context, Menes.JsonAny.From(itemsValidationEnumerator.Current).As<{fqtn}>(), $\"[{{extraIndex + {itemIndex}}}]\");");
                    builder.AppendLine("        extraIndex++;");
                    builder.AppendLine("    }");
                }
                else
                {
                    builder.AppendLine("if (itemsValidationEnumerator.MoveNext())");
                    builder.AppendLine("{");
                    builder.AppendLine($"    context = context.WithError($\"core 9.3.1.1. items: The array should have contained {itemsValidation.Count} items but actually contained {{array.Length}} items.\");");
                    builder.AppendLine("}");
                }
            }

            if (this.ContainsValidation is ITypeDeclaration contains)
            {
                int minContains = this.MinContainsValidation ?? 1;
                int maxContains = this.MaxContainsValidation ?? int.MaxValue;
                string unique = (this.UniqueValidation ?? false) ? "true" : "false";
                builder.AppendLine($"        return array.ValidateRangeContains<{contains.GetFullyQualifiedName()}>(context, {minContains}, {maxContains}, {unique}, true);");
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

            builder.AppendLine($"public {name} Add(params {itemFullyQualifiedName}[] items)");
            builder.AppendLine("{");
            builder.AppendLine($"    System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in this)");
            builder.AppendLine("    {");
            builder.AppendLine($"        arrayBuilder.Add(item);");
            builder.AppendLine("    }");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in items)");
            builder.AppendLine("    {");
            builder.AppendLine($"        arrayBuilder.Add(item);");
            builder.AppendLine("    }");
            builder.AppendLine("    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
            builder.AppendLine("}");

            builder.AppendLine($"public {name} Add(in {itemFullyQualifiedName} item1)");
            builder.AppendLine("{");
            builder.AppendLine($"    System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in this)");
            builder.AppendLine("    {");
            builder.AppendLine($"        arrayBuilder.Add(item);");
            builder.AppendLine("    }");
            builder.AppendLine($"    arrayBuilder.Add(item1);");
            builder.AppendLine("    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
            builder.AppendLine("}");

            builder.AppendLine($"public {name} Add(in {itemFullyQualifiedName} item1, in {itemFullyQualifiedName} item2)");
            builder.AppendLine("{");
            builder.AppendLine($"    System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in this)");
            builder.AppendLine("    {");
            builder.AppendLine($"        arrayBuilder.Add(item);");
            builder.AppendLine("    }");
            builder.AppendLine($"    arrayBuilder.Add(item1);");
            builder.AppendLine($"    arrayBuilder.Add(item2);");
            builder.AppendLine("    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
            builder.AppendLine("}");

            builder.AppendLine($"public {name} Add(in {itemFullyQualifiedName} item1, in {itemFullyQualifiedName} item2, in {itemFullyQualifiedName} item3)");
            builder.AppendLine("{");
            builder.AppendLine($"    System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in this)");
            builder.AppendLine("    {");
            builder.AppendLine($"        arrayBuilder.Add(item);");
            builder.AppendLine("    }");
            builder.AppendLine($"    arrayBuilder.Add(item1);");
            builder.AppendLine($"    arrayBuilder.Add(item2);");
            builder.AppendLine($"    arrayBuilder.Add(item3);");
            builder.AppendLine("    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
            builder.AppendLine("}");

            builder.AppendLine($"public {name} Add(in {itemFullyQualifiedName} item1, in {itemFullyQualifiedName} item2, in {itemFullyQualifiedName} item3, in {itemFullyQualifiedName} item4)");
            builder.AppendLine("{");
            builder.AppendLine($"    System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in this)");
            builder.AppendLine("    {");
            builder.AppendLine($"        arrayBuilder.Add(item);");
            builder.AppendLine("    }");
            builder.AppendLine($"    arrayBuilder.Add(item1);");
            builder.AppendLine($"    arrayBuilder.Add(item2);");
            builder.AppendLine($"    arrayBuilder.Add(item3);");
            builder.AppendLine($"    arrayBuilder.Add(item4);");
            builder.AppendLine("    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
            builder.AppendLine("}");

            builder.AppendLine($"public {name} Insert(int indexToInsert, params {itemFullyQualifiedName}[] items)");
            builder.AppendLine("{");
            builder.AppendLine($"    System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
            builder.AppendLine("    int index = 0;");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in this)");
            builder.AppendLine("    {");
            builder.AppendLine("        if (index == indexToInsert)");
            builder.AppendLine("        {");
            builder.AppendLine($"            foreach ({itemFullyQualifiedName} itemToInsert in items)");
            builder.AppendLine("            {");
            builder.AppendLine("                arrayBuilder.Add(itemToInsert);");
            builder.AppendLine("            }");
            builder.AppendLine("        }");
            builder.AppendLine("        arrayBuilder.Add(item);");
            builder.AppendLine("        ++index;");
            builder.AppendLine("    }");
            builder.AppendLine("    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
            builder.AppendLine("}");

            builder.AppendLine($"public {name} Insert(int indexToInsert, in {itemFullyQualifiedName} item1)");
            builder.AppendLine("{");
            builder.AppendLine($"    System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
            builder.AppendLine("    int index = 0;");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in this)");
            builder.AppendLine("    {");
            builder.AppendLine("        if (index == indexToInsert)");
            builder.AppendLine("        {");
            builder.AppendLine("            arrayBuilder.Add(item1);");
            builder.AppendLine("        }");
            builder.AppendLine("        arrayBuilder.Add(item);");
            builder.AppendLine("        ++index;");
            builder.AppendLine("    }");
            builder.AppendLine("    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
            builder.AppendLine("}");

            builder.AppendLine($"public {name} Insert(int indexToInsert, in {itemFullyQualifiedName} item1, in {itemFullyQualifiedName} item2)");
            builder.AppendLine("{");
            builder.AppendLine($"    System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
            builder.AppendLine("    int index = 0;");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in this)");
            builder.AppendLine("    {");
            builder.AppendLine("        if (index == indexToInsert)");
            builder.AppendLine("        {");
            builder.AppendLine("            arrayBuilder.Add(item1);");
            builder.AppendLine("            arrayBuilder.Add(item2);");
            builder.AppendLine("        }");
            builder.AppendLine("        arrayBuilder.Add(item);");
            builder.AppendLine("        ++index;");
            builder.AppendLine("    }");
            builder.AppendLine("    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
            builder.AppendLine("}");

            builder.AppendLine($"public {name} Insert(int indexToInsert, in {itemFullyQualifiedName} item1, in {itemFullyQualifiedName} item2, in {itemFullyQualifiedName} item3)");
            builder.AppendLine("{");
            builder.AppendLine($"    System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
            builder.AppendLine("    int index = 0;");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in this)");
            builder.AppendLine("    {");
            builder.AppendLine("        if (index == indexToInsert)");
            builder.AppendLine("        {");
            builder.AppendLine("            arrayBuilder.Add(item1);");
            builder.AppendLine("            arrayBuilder.Add(item2);");
            builder.AppendLine("            arrayBuilder.Add(item3);");
            builder.AppendLine("        }");
            builder.AppendLine("        arrayBuilder.Add(item);");
            builder.AppendLine("        ++index;");
            builder.AppendLine("    }");
            builder.AppendLine("    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
            builder.AppendLine("}");

            builder.AppendLine($"public {name} Insert(int indexToInsert, in {itemFullyQualifiedName} item1, in {itemFullyQualifiedName} item2, in {itemFullyQualifiedName} item3, in {itemFullyQualifiedName} item4)");
            builder.AppendLine("{");
            builder.AppendLine($"    System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
            builder.AppendLine("    int index = 0;");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in this)");
            builder.AppendLine("    {");
            builder.AppendLine("        if (index == indexToInsert)");
            builder.AppendLine("        {");
            builder.AppendLine("            arrayBuilder.Add(item1);");
            builder.AppendLine("            arrayBuilder.Add(item2);");
            builder.AppendLine("            arrayBuilder.Add(item3);");
            builder.AppendLine("            arrayBuilder.Add(item4);");
            builder.AppendLine("        }");
            builder.AppendLine("        arrayBuilder.Add(item);");
            builder.AppendLine("        ++index;");
            builder.AppendLine("    }");
            builder.AppendLine("    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
            builder.AppendLine("}");

            builder.AppendLine($"public {name} Remove(params {itemFullyQualifiedName}[] items)");
            builder.AppendLine("{");
            builder.AppendLine($"    System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in this)");
            builder.AppendLine("    {");
            builder.AppendLine("        bool found = false;");
            builder.AppendLine($"        foreach ({itemFullyQualifiedName} itemToRemove in items)");
            builder.AppendLine("        {");
            builder.AppendLine($"           if (itemToRemove.Equals(item))");
            builder.AppendLine("            {");
            builder.AppendLine("                found = true;");
            builder.AppendLine("                break;");
            builder.AppendLine("            }");
            builder.AppendLine("        }");
            builder.AppendLine("        if (!found)");
            builder.AppendLine("        {");
            builder.AppendLine($"            arrayBuilder.Add(item);");
            builder.AppendLine("    }   ");
            builder.AppendLine("    }");
            builder.AppendLine("    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
            builder.AppendLine("}");

            builder.AppendLine($"public {name} Remove({itemFullyQualifiedName} item1)");
            builder.AppendLine("{");
            builder.AppendLine($"    System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in this)");
            builder.AppendLine("    {");
            builder.AppendLine($"       if (item1.Equals(item))");
            builder.AppendLine("        {");
            builder.AppendLine("            break;");
            builder.AppendLine("        }");
            builder.AppendLine($"        arrayBuilder.Add(item);");
            builder.AppendLine("    }");
            builder.AppendLine("    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
            builder.AppendLine("}");

            builder.AppendLine($"public {name} Remove({itemFullyQualifiedName} item1, {itemFullyQualifiedName} item2)");
            builder.AppendLine("{");
            builder.AppendLine($"    System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in this)");
            builder.AppendLine("    {");
            builder.AppendLine($"       if (item1.Equals(item) || item2.Equals(item))");
            builder.AppendLine("        {");
            builder.AppendLine("            break;");
            builder.AppendLine("        }");
            builder.AppendLine($"        arrayBuilder.Add(item);");
            builder.AppendLine("    }");
            builder.AppendLine("    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
            builder.AppendLine("}");

            builder.AppendLine($"public {name} Remove({itemFullyQualifiedName} item1, {itemFullyQualifiedName} item2, {itemFullyQualifiedName} item3)");
            builder.AppendLine("{");
            builder.AppendLine($"    System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in this)");
            builder.AppendLine("    {");
            builder.AppendLine($"       if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))");
            builder.AppendLine("        {");
            builder.AppendLine("            break;");
            builder.AppendLine("        }");
            builder.AppendLine($"        arrayBuilder.Add(item);");
            builder.AppendLine("    }");
            builder.AppendLine("    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
            builder.AppendLine("}");

            builder.AppendLine($"public {name} Remove({itemFullyQualifiedName} item1, {itemFullyQualifiedName} item2, {itemFullyQualifiedName} item3, {itemFullyQualifiedName} item4)");
            builder.AppendLine("{");
            builder.AppendLine($"    System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in this)");
            builder.AppendLine("    {");
            builder.AppendLine($"       if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))");
            builder.AppendLine("        {");
            builder.AppendLine("            break;");
            builder.AppendLine("        }");
            builder.AppendLine($"        arrayBuilder.Add(item);");
            builder.AppendLine("    }");
            builder.AppendLine("    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
            builder.AppendLine("}");

            builder.AppendLine($"public {name} RemoveAt(int indexToRemove)");
            builder.AppendLine("{");
            builder.AppendLine($"    System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
            builder.AppendLine("    int index = 0;");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in this)");
            builder.AppendLine("    {");
            builder.AppendLine($"       if (index == indexToRemove)");
            builder.AppendLine("        {");
            builder.AppendLine("            index++;");
            builder.AppendLine("            continue;");
            builder.AppendLine("        }");
            builder.AppendLine($"        arrayBuilder.Add(item);");
            builder.AppendLine("        index++;");
            builder.AppendLine("    }");
            builder.AppendLine("    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
            builder.AppendLine("}");

            builder.AppendLine($"public {name} RemoveRange(int startIndex, int length)");
            builder.AppendLine("{");
            builder.AppendLine("    if (startIndex < 0 || startIndex > this.Length - 1)");
            builder.AppendLine("    {");
            builder.AppendLine("        throw new System.ArgumentOutOfRangeException(nameof(startIndex));");
            builder.AppendLine("    }");
            builder.AppendLine("    if (length < 1 || startIndex + length > this.Length - 1)");
            builder.AppendLine("    {");
            builder.AppendLine("        throw new System.ArgumentOutOfRangeException(nameof(length));");
            builder.AppendLine("    }");
            builder.AppendLine($"    System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
            builder.AppendLine("    int index = 0;");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in this)");
            builder.AppendLine("    {");
            builder.AppendLine("        if (index >= startIndex && index < startIndex + length)");
            builder.AppendLine("        {");
            builder.AppendLine("            index++;");
            builder.AppendLine("            continue;");
            builder.AppendLine("        }");
            builder.AppendLine("        arrayBuilder.Add(item);");
            builder.AppendLine("        index++;");
            builder.AppendLine("    }");
            builder.AppendLine("    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
            builder.AppendLine("}");

            builder.AppendLine($"public {name} Remove(System.Predicate<{itemFullyQualifiedName}> removeIfTrue)");
            builder.AppendLine("{");
            builder.AppendLine($"    System.Collections.Immutable.ImmutableArray<{itemFullyQualifiedName}>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemFullyQualifiedName}>();");
            builder.AppendLine($"    foreach ({itemFullyQualifiedName} item in this)");
            builder.AppendLine("    {");
            builder.AppendLine($"       if (removeIfTrue(item))");
            builder.AppendLine("        {");
            builder.AppendLine("            continue;");
            builder.AppendLine("        }");
            builder.AppendLine($"        arrayBuilder.Add(item);");
            builder.AppendLine("    }");
            builder.AppendLine("    return Menes.JsonArray.Create(arrayBuilder.ToImmutable());");
            builder.AppendLine("}");

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
            var tds = (TypeDeclarationSyntax)SF.ParseMemberDeclaration(builder.ToString());
            return this.BuildNestedTypes(tds);
        }

        /// <inheritdoc/>
        public override bool IsSpecializedBy(ITypeDeclaration type)
        {
            if (this.ItemType is null)
            {
                throw new InvalidOperationException("You must set the ItemType before calling IsSpecializedBy(ITypeDeclaration).");
            }

            // The array is specialized by an array of a type which is a specialized version of this item type.
            return type is ValidatedArrayTypeDeclaration arrayType && !(arrayType.ItemType is null) && this.ItemType.IsSpecializedBy(arrayType.ItemType);
        }

        /// <inheritdoc/>
        public override bool ContainsReference(ITypeDeclaration typeDeclaration, IList<ITypeDeclaration> visitedDeclarations)
        {
            if (this.ItemType is ITypeDeclaration itemType && CheckType(typeDeclaration, visitedDeclarations, itemType))
            {
                return true;
            }

            return base.ContainsReference(typeDeclaration, visitedDeclarations);
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
