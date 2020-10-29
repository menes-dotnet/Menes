// <copyright file="DiscriminatedUnionTypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    /// <summary>
    /// A discriminated union of other types.
    /// </summary>
    public class DiscriminatedUnionTypeDeclaration : TypeDeclaration
    {
        private readonly Dictionary<string, (ITypeDeclaration, string)> typesInUnion = new Dictionary<string, (ITypeDeclaration, string)>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscriminatedUnionTypeDeclaration"/> class.
        /// </summary>
        /// <param name="name">The name of this type.</param>
        /// <param name="discriminatorPropertyName">The name of the common property that discriminates between the types.</param>
        /// <param name="kind">The type of union for the discriminated union.</param>
        public DiscriminatedUnionTypeDeclaration(string name, string discriminatorPropertyName, UnionKind kind = UnionKind.AnyOf)
            : base(name)
        {
            this.DiscriminatorPropertyName = discriminatorPropertyName;
            this.Kind = kind;
        }

        /// <summary>
        /// The type of union this type represents.
        /// </summary>
        public enum UnionKind
        {
            /// <summary>
            /// An anyOf validation
            /// </summary>
            AnyOf,

            /// <summary>
            /// A oneOf validation
            /// </summary>
            OneOf,
        }

        /// <summary>
        /// Gets the kind of union.
        /// </summary>
        public UnionKind Kind { get; }

        /// <inheritdoc/>
        /// <remarks>
        /// The discriminated union type is a compound type if and only if any of its children is a compound type, Union type or Discriminated Union type.
        /// </remarks>
        public override bool IsCompoundType => this.typesInUnion.Any(t => t.Value.Item1 is UnionTypeDeclaration || t.Value.Item1 is DiscriminatedUnionTypeDeclaration || t.Value.Item1.IsCompoundType);

        /// <summary>
        /// Gets the discriminator property name.
        /// </summary>
        public string DiscriminatorPropertyName { get; }

        /// <summary>
        /// Adds the given type to the union.
        /// </summary>
        /// <param name="discriminatorValue">The value of the discriminator for this type.</param>
        /// <param name="type">The type to add to the union.</param>
        public void AddTypeToUnion(string discriminatorValue, ITypeDeclaration type)
        {
            // Idempotent based on the name of the type.
            this.typesInUnion.TryAdd(type.GetFullyQualifiedName(), (type, discriminatorValue));
        }

        /// <summary>
        /// Add types to the union.
        /// </summary>
        /// <param name="types">The types to add.</param>
        public void AddTypesToUnion(params (string, ITypeDeclaration)[] types)
        {
            foreach ((string, ITypeDeclaration) type in types)
            {
                this.AddTypeToUnion(type.Item1, type.Item2);
            }
        }

        /// <summary>
        /// Gets a value which indicates whether the given type is a part of this union.
        /// </summary>
        /// <param name="fullyQualifiedTypeName">The fully qualified name of the type.</param>
        /// <returns><c>True</c> if the type is in the union, otherwise false.</returns>
        public bool ContainsTypeInUnion(string fullyQualifiedTypeName)
        {
            return this.typesInUnion.ContainsKey(fullyQualifiedTypeName);
        }

        /// <inheritdoc/>
        public override TypeDeclarationSyntax GenerateType()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"public readonly struct {this.Name} : Menes.IJsonValue");
            builder.AppendLine("{");
            builder.AppendLine($"    public static readonly {this.Name} Null = new {this.Name}(default(System.Text.Json.JsonElement));");
            builder.AppendLine($"    public static readonly System.Func<System.Text.Json.JsonElement, {this.GetFullyQualifiedName()}> FromJsonElement = e => new {this.GetFullyQualifiedName()}(e);");

            builder.AppendLine($"        private static readonly System.ReadOnlyMemory<byte> DiscriminatorPropertyName = new byte[] {{ {string.Join(", ", Encoding.UTF8.GetBytes(this.DiscriminatorPropertyName).Select(b => b.ToString()))} }};");

            foreach ((ITypeDeclaration unionType, string discriminatorValue) in this.typesInUnion.Values)
            {
                builder.AppendLine($"        private static readonly System.ReadOnlyMemory<byte> {unionType.Name}DiscriminatorValue = new byte[] {{ {string.Join(", ", Encoding.UTF8.GetBytes(discriminatorValue).Select(b => b.ToString()))} }};");
            }

            int index = 0;
            foreach ((ITypeDeclaration unionType, string discriminatorValue) in this.typesInUnion.Values)
            {
                if (unionType.IsCompoundType)
                {
                    builder.AppendLine($"    private readonly Menes.JsonReference? item{index + 1};");
                }
                else
                {
                    builder.AppendLine($"    private readonly {unionType.GetFullyQualifiedName()}? item{index + 1};");
                }

                index++;
            }

            index = 0;

            foreach ((ITypeDeclaration unionType, string discriminatorValue) in this.typesInUnion.Values)
            {
                builder.AppendLine($"    public {this.Name}({unionType.GetFullyQualifiedName()} clrInstance)");
                builder.AppendLine("    {");
                builder.AppendLine("        if (clrInstance.HasJsonElement)");
                builder.AppendLine("        {");
                builder.AppendLine("            this.JsonElement = clrInstance.JsonElement;");
                builder.AppendLine($"            this.item{index + 1} = null;");
                builder.AppendLine("        }");
                builder.AppendLine("        else");
                builder.AppendLine("        {");

                if (unionType.IsCompoundType)
                {
                    builder.AppendLine($"            this.item{index + 1} = Menes.JsonReference.FromValue(clrInstance);");
                }
                else
                {
                    builder.AppendLine($"            this.item{index + 1} = clrInstance;");
                }

                builder.AppendLine("            this.JsonElement = default;");
                builder.AppendLine("        }");

                for (int i = 0; i < this.typesInUnion.Count; ++i)
                {
                    if (i == index)
                    {
                        continue;
                    }

                    builder.AppendLine($"        this.item{i + 1} = null;");
                }

                builder.AppendLine("    }");
                index++;
            }

            builder.AppendLine($"    public {this.Name}(System.Text.Json.JsonElement jsonElement)");
            builder.AppendLine("    {");

            for (int i = 0; i < this.typesInUnion.Count; ++i)
            {
                builder.AppendLine($"        this.item{i + 1} = null;");
            }

            builder.AppendLine("        this.JsonElement = jsonElement;");
            builder.AppendLine("    }");

            builder.Append("    public bool IsNull =>");

            for (int i = 0; i < this.typesInUnion.Count; ++i)
            {
                if (i > 0)
                {
                    builder.Append(" &&");
                }

                builder.Append($" this.item{i + 1} is null");
            }

            builder.AppendLine(" && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);");

            builder.AppendLine($"    public {this.Name}? AsOptional => this.IsNull ? default({this.Name}?) : this;");

            index = 0;

            foreach ((ITypeDeclaration unionType, string discriminatorValue) in this.typesInUnion.Values)
            {
                string fullyQualifiedTypeName = unionType.GetFullyQualifiedName();
                string fullyQualifiedTypeNameOrReference = unionType.IsCompoundType ? "Menes.JsonReference" : fullyQualifiedTypeName;
                builder.AppendLine($"    public bool Is{unionType.Name} => this.item{index + 1} is {fullyQualifiedTypeNameOrReference} || (this.JsonElement.TryGetProperty(DiscriminatorPropertyName.Span, out System.Text.Json.JsonElement propVal) && propVal.ValueEquals({unionType.Name}DiscriminatorValue.Span));");
                index++;
            }

            builder.AppendLine("    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;");

            builder.AppendLine("    public System.Text.Json.JsonElement JsonElement { get; }");

            var existingConversions = new HashSet<string>();

            foreach ((ITypeDeclaration unionType, string discriminatorValue) in this.typesInUnion.Values)
            {
                string fullyQualifiedTypeName = unionType.GetFullyQualifiedName();
                builder.AppendLine($"    public static explicit operator {fullyQualifiedTypeName}({this.Name} value) => value.As{unionType.Name}();");
                builder.AppendLine($"    public static implicit operator {this.Name}({fullyQualifiedTypeName} value) => new {this.Name}(value);");

                if (unionType is ValidatedArrayTypeDeclaration vdat)
                {
                    string itemFullyQualifiedName = vdat.ItemType!.GetFullyQualifiedName();
                    if (!existingConversions.Contains(itemFullyQualifiedName))
                    {
                        existingConversions.Add(itemFullyQualifiedName);
                        builder.AppendLine($"    public static implicit operator {this.Name}(Menes.JsonArray<{itemFullyQualifiedName}> value)");
                        builder.AppendLine("    {");
                        builder.AppendLine($"        return new {this.Name}(value);");
                        builder.AppendLine("    }");
                    }
                }

                if (unionType is ArrayTypeDeclaration atd)
                {
                    string itemFullyQualifiedName = atd.ItemType!.GetFullyQualifiedName();
                    if (!existingConversions.Contains(itemFullyQualifiedName))
                    {
                        existingConversions.Add(itemFullyQualifiedName);
                        builder.AppendLine($"    public static implicit operator {this.Name}(Menes.JsonArray<{itemFullyQualifiedName}> value)");
                        builder.AppendLine("    {");
                        builder.AppendLine($"        return new {this.Name}(value);");
                        builder.AppendLine("    }");
                    }
                }
            }

            builder.AppendLine($"public static {this.Name} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>");
            builder.AppendLine($"   parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?");
            builder.AppendLine("        (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? new {this.Name}(property)");
            builder.AppendLine("            : Null)");
            builder.AppendLine("        : Null;");
            builder.AppendLine($"public static {this.Name} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>");
            builder.AppendLine($"   parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?");
            builder.AppendLine("        (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? new {this.Name}(property)");
            builder.AppendLine("            : Null)");
            builder.AppendLine("        : Null;");
            builder.AppendLine($"public static {this.Name} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>");
            builder.AppendLine($"   parentDocument.ValueKind != System.Text.Json.JsonValueKind.Undefined ?");
            builder.AppendLine("        (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? new {this.Name}(property)");
            builder.AppendLine("            : Null)");
            builder.AppendLine("        : Null;");

            builder.AppendLine("public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)");
            builder.AppendLine("{");

            foreach ((ITypeDeclaration unionType, string _) in this.typesInUnion.Values)
            {
                builder.AppendLine($"if ({unionType.GetFullyQualifiedName()}.IsConvertibleFrom(jsonElement))");
                builder.AppendLine("{");
                builder.AppendLine($"    return true;");
                builder.AppendLine("}");
            }

            builder.AppendLine("return false;");

            builder.AppendLine("}");

            index = 0;
            foreach ((ITypeDeclaration unionType, string discriminatorValue) in this.typesInUnion.Values)
            {
                string fullyQualifiedTypeName = unionType.GetFullyQualifiedName();

                if (unionType.IsCompoundType)
                {
                    builder.AppendLine($"    public {fullyQualifiedTypeName} As{unionType.Name}() => this.Is{unionType.Name} ? this.item{index + 1}?.AsValue<{fullyQualifiedTypeName}>() ?? new {fullyQualifiedTypeName}(this.JsonElement) : throw new System.Text.Json.JsonException(\"The union value is not a {fullyQualifiedTypeName}\");");
                }
                else
                {
                    builder.AppendLine($"    public {fullyQualifiedTypeName} As{unionType.Name}() => this.Is{unionType.Name} ? this.item{index + 1} ?? new {fullyQualifiedTypeName}(this.JsonElement) : throw new System.Text.Json.JsonException(\"The union value is not a {fullyQualifiedTypeName}\");");
                }

                ++index;
            }

            builder.AppendLine("    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)");
            builder.AppendLine("    {");

            index = 0;

            foreach ((ITypeDeclaration unionType, string discriminatorValue) in this.typesInUnion.Values)
            {
                if (index > 0)
                {
                    builder.Append("else ");
                }

                string typeName = unionType.IsCompoundType ? "Menes.JsonReference" : unionType.GetFullyQualifiedName();

                builder.AppendLine($"        if (this.item{index + 1} is {typeName} item{index + 1})");
                builder.AppendLine("        {");
                builder.AppendLine($"            item{index + 1}.WriteTo(writer);");
                builder.AppendLine("        }");
                index++;
            }

            builder.AppendLine("        else");
            builder.AppendLine("        {");
            builder.AppendLine("            this.JsonElement.WriteTo(writer);");
            builder.AppendLine("        }");
            builder.AppendLine("    }");

            builder.AppendLine("    public override string ToString()");
            builder.AppendLine("    {");
            builder.AppendLine("        var builder = new System.Text.StringBuilder();");
            index = 0;

            foreach ((ITypeDeclaration unionType, string discriminatorValue) in this.typesInUnion.Values)
            {
                string typeName = unionType.IsCompoundType ? "Menes.JsonReference" : unionType.GetFullyQualifiedName();

                builder.AppendLine($"        if (this.Is{unionType.Name})");
                builder.AppendLine("        {");
                builder.AppendLine("            builder.Append(\"{\");");
                builder.AppendLine($"            builder.Append(\"{unionType.Name}\");");
                builder.AppendLine("            builder.Append(\", \");");
                builder.AppendLine($"            builder.Append(this.As{unionType.Name}().ToString());");
                builder.AppendLine("            builder.AppendLine(\"}\");");
                builder.AppendLine("        }");
                index++;
            }

            builder.AppendLine("        return builder.Length > 0 ? builder.ToString() : this.JsonElement.ToString();");

            builder.AppendLine("    }");

            builder.AppendLine("    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)");
            builder.AppendLine("    {");
            builder.AppendLine("        if (this.IsNull)");
            builder.AppendLine("        {");
            builder.AppendLine("            return validationContext;");
            builder.AppendLine("        }");

            builder.AppendLine("        Menes.ValidationContext context = validationContext;");

            index = 0;
            foreach ((ITypeDeclaration unionType, string discriminatorValue) in this.typesInUnion.Values)
            {
                if (this.Kind == UnionKind.OneOf)
                {
                    builder.AppendLine("        int matchCount = 0;");
                }

                builder.AppendLine($"        if (this.Is{unionType.Name})");
                builder.AppendLine("        {");
                builder.AppendLine($"            context = this.As{unionType.Name}().Validate(context);");
                if (this.Kind == UnionKind.OneOf)
                {
                    builder.AppendLine("            matchCount++;");
                }

                builder.AppendLine("        }");
                index++;
            }

            if (this.Kind == UnionKind.OneOf)
            {
                builder.AppendLine("if (matchCount != 1)");
                builder.AppendLine("{");
                builder.AppendLine("var builder = new System.Text.StringBuilder();");
                foreach ((ITypeDeclaration unionType, string discriminatorValue) in this.typesInUnion.Values)
                {
                    builder.AppendLine($"if (this.Is{unionType.Name})");
                    builder.AppendLine("{");
                    builder.AppendLine($"    builder.Append(builder.Length > 0 ? \", \" : string.Empty);");
                    builder.AppendLine($"    builder.Append(\"{unionType.Name}\");");
                    builder.AppendLine("}");
                }

                builder.AppendLine($"        context = context.WithError($\"core 9.2.1.3. oneOf: The type validated against {{matchCount}} items: {{builder.ToString()}}.\");");
                builder.AppendLine("}");
            }

            builder.Append("        return context;");
            builder.AppendLine("    }");
            builder.AppendLine("}");

            return (TypeDeclarationSyntax)SF.ParseMemberDeclaration(builder.ToString());
        }

        /// <inheritdoc/>
        public override bool IsSpecializedBy(ITypeDeclaration type)
        {
            return this.ContainsTypeInUnion(type.GetFullyQualifiedName());
        }

        /// <inheritdoc/>
        public override void AddPropertyDeclaration(PropertyDeclaration propertyDeclaration)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public override void AddMethodDeclaration(MethodDeclaration methodDeclaration)
        {
            throw new NotSupportedException();
        }
    }
}
