// <copyright file="UnionTypeDeclaration.cs" company="Endjin Limited">
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
    /// A union of other types.
    /// </summary>
    public class UnionTypeDeclaration : TypeDeclaration
    {
        private readonly Dictionary<string, ITypeDeclaration> typesInUnion = new Dictionary<string, ITypeDeclaration>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UnionTypeDeclaration"/> class.
        /// </summary>
        /// <param name="name">The name of this type.</param>
        /// <param name="kind">The kind of the union.</param>
        public UnionTypeDeclaration(string name, UnionKind kind = UnionKind.AnyOf)
            : base(name)
        {
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

            /// <summary>
            /// An allOf validation
            /// </summary>
            AllOf,
        }

        /// <summary>
        /// Gets the kind of union.
        /// </summary>
        public UnionKind Kind { get; }

        /// <summary>
        /// Adds the given type to the union.
        /// </summary>
        /// <param name="type">The type to add to the union.</param>
        public void AddTypeToUnion(ITypeDeclaration type)
        {
            // Idempotent based on the name of the type.
            this.typesInUnion.TryAdd(type.GetFullyQualifiedName(), type);
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
            builder.AppendLine($"public static readonly System.Func<System.Text.Json.JsonElement, {this.GetFullyQualifiedName()}> FromJsonElement = e => new {this.GetFullyQualifiedName()}(e);");

            int index = 0;
            foreach (ITypeDeclaration unionType in this.typesInUnion.Values)
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

            foreach (ITypeDeclaration unionType in this.typesInUnion.Values)
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

            if (this.typesInUnion.Count > 0)
            {
                builder.Append(" && ");
            }

            builder.AppendLine("(this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);");

            builder.AppendLine($"    public {this.Name}? AsOptional => this.IsNull ? default({this.Name}?) : this;");

            index = 0;

            foreach (ITypeDeclaration type in this.typesInUnion.Values)
            {
                string fullyQualifiedTypeName = type.GetFullyQualifiedName();
                string fullyQualifiedTypeNameOrReference = type.IsCompoundType ? "Menes.JsonReference" : fullyQualifiedTypeName;
                builder.AppendLine($"    public bool Is{StringFormatter.ToPascalCaseWithReservedWords(type.Name)} => this.item{index + 1} is {fullyQualifiedTypeNameOrReference} || ({fullyQualifiedTypeName}.IsConvertibleFrom(this.JsonElement) && {fullyQualifiedTypeName}.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);");
                index++;
            }

            builder.AppendLine("    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;");

            builder.AppendLine("    public System.Text.Json.JsonElement JsonElement { get; }");

            var existingConversions = new HashSet<string>();

            foreach (ITypeDeclaration type in this.typesInUnion.Values)
            {
                string fullyQualifiedTypeName = type.GetFullyQualifiedName();
                builder.AppendLine($"    public static explicit operator {fullyQualifiedTypeName}({this.Name} value) => value.As{StringFormatter.ToPascalCaseWithReservedWords(type.Name)}();");
                builder.AppendLine($"    public static implicit operator {this.Name}({fullyQualifiedTypeName} value) => new {this.Name}(value);");
                existingConversions.Add(fullyQualifiedTypeName);

                if (type is ValidatedArrayTypeDeclaration vdat)
                {
                    string itemFullyQualifiedName = vdat.ItemType!.GetFullyQualifiedName();
                    string arrayName = $"Menes.JsonArray<{itemFullyQualifiedName}>";
                    if (!existingConversions.Contains(arrayName))
                    {
                        existingConversions.Add(itemFullyQualifiedName);
                        builder.AppendLine($"    public static implicit operator {this.Name}({arrayName} value)");
                        builder.AppendLine("    {");
                        builder.AppendLine($"        return new {this.Name}(({fullyQualifiedTypeName})value);");
                        builder.AppendLine("    }");
                    }
                }

                if (type is ArrayTypeDeclaration atd)
                {
                    string itemFullyQualifiedName = atd.ItemType!.GetFullyQualifiedName();
                    string arrayName = $"Menes.JsonArray<{itemFullyQualifiedName}>";
                    if (!existingConversions.Contains(arrayName))
                    {
                        existingConversions.Add(itemFullyQualifiedName);
                        builder.AppendLine($"    public static implicit operator {this.Name}({arrayName} value)");
                        builder.AppendLine("    {");
                        builder.AppendLine($"        return new {this.Name}(({fullyQualifiedTypeName})value);");
                        builder.AppendLine("    }");
                    }
                }
            }

            builder.AppendLine($"public static {this.Name} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>");
            builder.AppendLine($"   parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?");
            builder.AppendLine("        (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? new {this.Name}(property)");
            builder.AppendLine("            : Null)");
            builder.AppendLine("        : Null;");
            builder.AppendLine($"public static {this.Name} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>");
            builder.AppendLine($"   parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?");
            builder.AppendLine("        (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? new {this.Name}(property)");
            builder.AppendLine("            : Null)");
            builder.AppendLine("        : Null;");
            builder.AppendLine($"public static {this.Name} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>");
            builder.AppendLine($"   parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?");
            builder.AppendLine("        (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)");
            builder.AppendLine($"            ? new {this.Name}(property)");
            builder.AppendLine("            : Null)");
            builder.AppendLine("        : Null;");

            builder.AppendLine("public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)");
            builder.AppendLine("{");
            foreach (ITypeDeclaration type in this.typesInUnion.Values)
            {
                builder.AppendLine($"if ({type.GetFullyQualifiedName()}.IsConvertibleFrom(jsonElement))");
                builder.AppendLine("{");
                builder.AppendLine($"    return true;");
                builder.AppendLine("}");
            }

            builder.AppendLine("return false;");

            builder.AppendLine("}");

            index = 0;
            foreach (ITypeDeclaration type in this.typesInUnion.Values)
            {
                string fullyQualifiedTypeName = type.GetFullyQualifiedName();

                string typeName = StringFormatter.ToPascalCaseWithReservedWords(type.Name);

                if (type.IsCompoundType)
                {
                    builder.AppendLine($"    public {fullyQualifiedTypeName} As{typeName}() => this.item{index + 1}?.AsValue<{fullyQualifiedTypeName}>() ?? new {fullyQualifiedTypeName}(this.JsonElement);");
                }
                else
                {
                    builder.AppendLine($"    public {fullyQualifiedTypeName} As{typeName}() => this.item{index + 1} ?? new {fullyQualifiedTypeName}(this.JsonElement);");
                }

                ++index;
            }

            builder.AppendLine("    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)");
            builder.AppendLine("    {");

            index = 0;

            foreach (ITypeDeclaration type in this.typesInUnion.Values)
            {
                if (index > 0)
                {
                    builder.Append("else ");
                }

                string typeName = type.IsCompoundType ? "Menes.JsonReference" : type.GetFullyQualifiedName();

                builder.AppendLine($"        if (this.item{index + 1} is {typeName} item{index + 1})");
                builder.AppendLine("        {");
                builder.AppendLine($"            item{index + 1}.WriteTo(writer);");
                builder.AppendLine("        }");
                index++;
            }

            if (this.typesInUnion.Count > 0)
            {
                builder.AppendLine("        else");
                builder.AppendLine("        {");
            }

            builder.AppendLine("            this.JsonElement.WriteTo(writer);");
            if (this.typesInUnion.Count > 0)
            {
                builder.AppendLine("        }");
            }

            builder.AppendLine("    }");

            builder.AppendLine("    public override string ToString()");
            builder.AppendLine("    {");
            builder.AppendLine("        var builder = new System.Text.StringBuilder();");
            index = 0;

            foreach (ITypeDeclaration type in this.typesInUnion.Values)
            {
                string formattedTypeName = StringFormatter.ToPascalCaseWithReservedWords(type.Name);
                builder.AppendLine($"        if (this.Is{formattedTypeName})");
                builder.AppendLine("        {");
                builder.AppendLine("            builder.Append(\"{\");");
                builder.AppendLine($"            builder.Append(\"{formattedTypeName}\");");
                builder.AppendLine("            builder.Append(\", \");");
                builder.AppendLine($"            builder.Append(this.As{formattedTypeName}().ToString());");
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

            for (int i = 0; i < this.typesInUnion.Count; ++i)
            {
                builder.AppendLine($"        Menes.ValidationContext validationContext{i + 1} = Menes.ValidationContext.Root.WithPath(validationContext.Path);");
            }

            index = 0;
            foreach (ITypeDeclaration unionType in this.typesInUnion.Values)
            {
                builder.AppendLine($"        if (this.Is{StringFormatter.ToPascalCaseWithReservedWords(unionType.Name)})");
                builder.AppendLine("        {");
                builder.AppendLine($"            validationContext{index + 1} = this.As{StringFormatter.ToPascalCaseWithReservedWords(unionType.Name)}().Validate(validationContext{index + 1});");
                builder.AppendLine("        }");
                builder.AppendLine("        else");
                builder.AppendLine("        {");
                builder.AppendLine($"            validationContext{index + 1} = validationContext{index + 1}.WithError(\"The value is not convertible to a {unionType.GetFullyQualifiedName()}.\");");
                builder.AppendLine("        }");
                index++;
            }

            if (this.Kind == UnionKind.AllOf)
            {
                builder.Append("        return Menes.Validation.ValidateAllOf(validationContext");
            }
            else if (this.Kind == UnionKind.OneOf)
            {
                builder.Append("        return Menes.Validation.ValidateOneOf(validationContext");
            }
            else
            {
                builder.Append("        return Menes.Validation.ValidateAnyOf(validationContext");
            }

            index = 0;
            foreach (ITypeDeclaration? unionType in this.typesInUnion.Values)
            {
                builder.Append(", ");
                if (this.Kind == UnionKind.OneOf)
                {
                    builder.Append($"(\"{unionType.GetFullyQualifiedName()}\", validationContext{index + 1})");
                }
                else
                {
                    builder.Append($"validationContext{index + 1}");
                }

                index++;
            }

            builder.AppendLine(");");

            builder.AppendLine("    }");
            builder.AppendLine("}");

            var tds = (TypeDeclarationSyntax)SF.ParseMemberDeclaration(builder.ToString());
            return this.BuildNestedTypes(tds);
        }

        /// <summary>
        /// Add types to the union.
        /// </summary>
        /// <param name="types">The types to add.</param>
        public void AddTypesToUnion(params ITypeDeclaration[] types)
        {
            foreach (ITypeDeclaration type in types)
            {
                this.AddTypeToUnion(type);
            }
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

        /// <inheritdoc/>
        public override bool ContainsReference(ITypeDeclaration typeDeclaration, IList<ITypeDeclaration> visitedDeclarations)
        {
            foreach (ITypeDeclaration itemType in this.typesInUnion.Values)
            {
                if (CheckType(typeDeclaration, visitedDeclarations, itemType))
                {
                    return true;
                }
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
