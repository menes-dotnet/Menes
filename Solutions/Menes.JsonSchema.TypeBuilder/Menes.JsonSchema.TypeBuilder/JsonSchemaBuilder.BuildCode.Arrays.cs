// <copyright file="JsonSchemaBuilder.BuildCode.Arrays.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System.Text;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        private void BuildArrayEnumerator(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsArrayTypeDeclaration)
            {
                return;
            }

            TypeDeclaration itemsType = this.GetItemsTypeFor(typeDeclaration);

            memberBuilder.AppendLine("/// <summary>");
            memberBuilder.AppendLine($"/// An enumerator for the array values in a <see cref=\"{typeDeclaration.DotnetTypeName}\"/>.");
            memberBuilder.AppendLine("/// </summary>");
            memberBuilder.AppendLine($"public struct MenesArrayEnumerator : System.Collections.Generic.IEnumerable<{itemsType.FullyQualifiedDotNetTypeName}>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<{itemsType.FullyQualifiedDotNetTypeName}>, System.Collections.IEnumerator");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine($"    private {typeDeclaration.DotnetTypeName} instance;");
            memberBuilder.AppendLine($"    private System.Text.Json.JsonElement.ArrayEnumerator jsonEnumerator;");
            memberBuilder.AppendLine($"    private bool hasJsonEnumerator;");
            memberBuilder.AppendLine($"    private int index;");

            memberBuilder.AppendLine($"    internal MenesArrayEnumerator({typeDeclaration.DotnetTypeName} instance)");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        this.instance = instance;");
            memberBuilder.AppendLine("        if (this.instance.HasJsonElement)");
            memberBuilder.AppendLine("        {");
            memberBuilder.AppendLine("            this.index = -2;");
            memberBuilder.AppendLine("            this.hasJsonEnumerator = true;");
            memberBuilder.AppendLine("            this.jsonEnumerator = this.instance.JsonElement.EnumerateArray();");
            memberBuilder.AppendLine("        }");
            memberBuilder.AppendLine("        else");
            memberBuilder.AppendLine("        {");
            memberBuilder.AppendLine("            this.index = -1;");
            memberBuilder.AppendLine("            this.hasJsonEnumerator = false;");
            memberBuilder.AppendLine("            this.jsonEnumerator = default;");
            memberBuilder.AppendLine("        }");
            memberBuilder.AppendLine("    }");

            memberBuilder.AppendLine("    /// <inheritdoc/>");
            memberBuilder.AppendLine($"    public {itemsType.FullyQualifiedDotNetTypeName} Current");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        get");
            memberBuilder.AppendLine("        {");
            memberBuilder.AppendLine("            if (this.hasJsonEnumerator)");
            memberBuilder.AppendLine("            {");
            memberBuilder.AppendLine($"                return new {itemsType.FullyQualifiedDotNetTypeName}(this.jsonEnumerator.Current);");
            memberBuilder.AppendLine("            }");

            if (itemsType.ContainsReferenceTo(typeDeclaration))
            {
                memberBuilder.AppendLine("            else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonValueBacking> array && this.index >= 0 && this.index < array.Length)");
                memberBuilder.AppendLine("            {");
                memberBuilder.AppendLine($"                return array[this.index].Value<{itemsType.FullyQualifiedDotNetTypeName}>() ?? default;");
                memberBuilder.AppendLine("            }");
            }
            else
            {
                memberBuilder.AppendLine($"            else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<{itemsType.FullyQualifiedDotNetTypeName}> array && this.index >= 0 && this.index < array.Length)");
                memberBuilder.AppendLine("            {");
                memberBuilder.AppendLine("                return array[this.index];");
                memberBuilder.AppendLine("            }");
            }

            memberBuilder.AppendLine($"            return default;");
            memberBuilder.AppendLine("        }");
            memberBuilder.AppendLine("    }");

            memberBuilder.AppendLine("    /// <inheritdoc/>");
            memberBuilder.AppendLine("    object System.Collections.IEnumerator.Current => this.Current;");

            memberBuilder.AppendLine("    /// <summary>");
            memberBuilder.AppendLine("    /// Returns a fresh copy of the enumerator");
            memberBuilder.AppendLine("    /// </summary>");
            memberBuilder.AppendLine($"    /// <returns>An enumerator for the array values in a <see cref=\"{typeDeclaration.DotnetTypeName}\"/>.</returns>");
            memberBuilder.AppendLine("    public MenesArrayEnumerator GetEnumerator()");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        MenesArrayEnumerator result = this;");
            memberBuilder.AppendLine("        result.Reset();");
            memberBuilder.AppendLine("        return result;");
            memberBuilder.AppendLine("    }");

            memberBuilder.AppendLine("    /// <inheritdoc/>");
            memberBuilder.AppendLine("    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        return this.GetEnumerator();");
            memberBuilder.AppendLine("    }");

            memberBuilder.AppendLine("    /// <inheritdoc/>");
            memberBuilder.AppendLine($"    System.Collections.Generic.IEnumerator<{itemsType.FullyQualifiedDotNetTypeName}> System.Collections.Generic.IEnumerable<{itemsType.FullyQualifiedDotNetTypeName}>.GetEnumerator()");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        return this.GetEnumerator();");
            memberBuilder.AppendLine("    }");

            memberBuilder.AppendLine("    /// <inheritdoc/>");
            memberBuilder.AppendLine("    public void Dispose()");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        if (this.hasJsonEnumerator)");
            memberBuilder.AppendLine("        {");
            memberBuilder.AppendLine("            this.jsonEnumerator.Dispose();");
            memberBuilder.AppendLine("        }");
            memberBuilder.AppendLine("    }");

            memberBuilder.AppendLine("    /// <inheritdoc/>");
            memberBuilder.AppendLine("    public void Reset()");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        if (this.hasJsonEnumerator)");
            memberBuilder.AppendLine("        {");
            memberBuilder.AppendLine("            this.jsonEnumerator.Reset();");
            memberBuilder.AppendLine("        }");
            memberBuilder.AppendLine("        else");
            memberBuilder.AppendLine("        {");
            memberBuilder.AppendLine("            this.index = -1;");
            memberBuilder.AppendLine("        }");
            memberBuilder.AppendLine("    }");

            memberBuilder.AppendLine("    /// <inheritdoc/>");
            memberBuilder.AppendLine("    public bool MoveNext()");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        if (this.hasJsonEnumerator)");
            memberBuilder.AppendLine("        {");
            memberBuilder.AppendLine("            return this.jsonEnumerator.MoveNext();");
            memberBuilder.AppendLine("        }");
            if (itemsType.ContainsReferenceTo(typeDeclaration))
            {
                memberBuilder.AppendLine("        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonValueBacking> array && this.index < array.Length)");
            }
            else
            {
                memberBuilder.AppendLine($"        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<{itemsType.FullyQualifiedDotNetTypeName}> array && this.index < array.Length)");
            }

            memberBuilder.AppendLine("        {");
            memberBuilder.AppendLine("            this.index++;");
            memberBuilder.AppendLine("            return true;");
            memberBuilder.AppendLine("        }");
            memberBuilder.AppendLine("        return false;");
            memberBuilder.AppendLine("    }");
            memberBuilder.AppendLine("}");
        }

        private void BuildArrayEnumerators(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsArrayTypeDeclaration)
            {
                return;
            }

            TypeDeclaration itemsType = this.GetItemsTypeFor(typeDeclaration);

            memberBuilder.Append($"public {typeDeclaration.FullyQualifiedDotNetTypeName}.MenesArrayEnumerator GetEnumerator()");
            memberBuilder.Append("{");
            memberBuilder.Append($"    return new {typeDeclaration.FullyQualifiedDotNetTypeName}.MenesArrayEnumerator(this);");
            memberBuilder.Append("}");

            memberBuilder.Append("System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()");
            memberBuilder.Append("{");
            memberBuilder.Append("    return this.GetEnumerator();");
            memberBuilder.Append("}");

            if (!itemsType.ContainsReferenceTo(typeDeclaration))
            {
                memberBuilder.Append($"System.Collections.Generic.IEnumerator<{itemsType.FullyQualifiedDotNetTypeName}> System.Collections.Generic.IEnumerable<{itemsType.FullyQualifiedDotNetTypeName}>.GetEnumerator()");
                memberBuilder.Append("{");
                memberBuilder.Append("    return this.GetEnumerator();");
                memberBuilder.Append("}");
            }
        }

        private void BuildArrayInterfaces(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsArrayTypeDeclaration)
            {
                return;
            }

            TypeDeclaration itemsType = this.GetItemsTypeFor(typeDeclaration);
            if (!itemsType.ContainsReferenceTo(typeDeclaration))
            {
                // If we are not recursively defined, we can explicitly implement IEnumerable<T>.
                memberBuilder.Append($", System.Collections.Generic.IEnumerable<{itemsType.FullyQualifiedDotNetTypeName}>, System.Collections.IEnumerable");
            }
            else
            {
                memberBuilder.Append($", System.Collections.IEnumerable");
            }
        }

        private TypeDeclaration GetItemsTypeFor(TypeDeclaration typeDeclaration)
        {
            if (typeDeclaration.Items is not null && typeDeclaration.Items.Count == 1)
            {
                return typeDeclaration.Items[0];
            }

            return TypeDeclarations.AnyTypeDeclaration;
        }

        private void BuildArrayBackingField(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Items is not null)
            {
                TypeDeclaration itemsType = this.GetItemsTypeFor(typeDeclaration);
                if (itemsType.ContainsReferenceTo(typeDeclaration))
                {
                    memberBuilder.AppendLine("private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonValueBacking>? _menesArrayValueBacking;");
                }
                else
                {
                    memberBuilder.AppendLine($"private readonly System.Collections.Immutable.ImmutableArray<{itemsType.FullyQualifiedDotNetTypeName}>? _menesArrayValueBacking;");
                }
            }
        }

        private void BuildArrayBackingFieldIsNull(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IsArrayTypeDeclaration)
            {
                memberBuilder.AppendLine($"if (this._menesArrayValueBacking is not null)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    return false;");
                memberBuilder.AppendLine("}");
            }
        }
    }
}
