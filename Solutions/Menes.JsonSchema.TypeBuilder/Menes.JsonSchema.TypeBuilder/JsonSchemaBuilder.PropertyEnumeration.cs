// <copyright file="JsonSchemaBuilder.PropertyEnumeration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Text;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        /// <summary>
        /// Builds a property enumerator for the given type.
        /// </summary>
        /// <param name="parentTypeDeclaration">The type declaration for the owner of this method.</param>
        /// <param name="memberBuilder">The member builder for output.</param>
        /// <remarks>
        /// <para>
        /// This relies on <see cref="BuildGetPropertyAtIndex(TypeDeclaration, StringBuilder)"/> to create the corresponding <c>Menes.Property&lt;TValue&gt;.GetPropertyAtIndex(int index)</c> method on the parent.
        /// </para>
        /// <para>
        /// It is used by <see cref="BuildPropertyEnumerator(TypeDeclaration, StringBuilder)"/>.
        /// </para>
        /// </remarks>
        public void BuildPropertyEnumerator(TypeDeclaration parentTypeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("/// <summary>");
            memberBuilder.AppendLine($"/// An enumerator for the properties in a <see cref=\"{parentTypeDeclaration.DotnetTypeName}\"/>.");
            memberBuilder.AppendLine("/// </summary>");
            memberBuilder.AppendLine($"public struct PropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<{parentTypeDeclaration.DotnetTypeName}>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<{parentTypeDeclaration.DotnetTypeName}>>, System.Collections.IEnumerator");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine($"    private {parentTypeDeclaration.DotnetTypeName} instance;");
            memberBuilder.AppendLine($"    private System.Text.Json.JsonElement.ObjectEnumerator? jsonEnumerator;");
            memberBuilder.AppendLine($"    private bool hasJsonEnumerator;");
            memberBuilder.AppendLine($"    private int index;");

            memberBuilder.AppendLine($"    internal PropertyEnumerator({parentTypeDeclaration.DotnetTypeName} instance)");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        this.instance = instance;");
            memberBuilder.AppendLine("        if (this.instance.HasJsonElement)");
            memberBuilder.AppendLine("        {");
            memberBuilder.AppendLine("            this.index = -2;");
            memberBuilder.AppendLine("            this.hasJsonEnumerator = true;");
            memberBuilder.AppendLine("            this.jsonEnumerator = this.instance.JsonElement.EnumerateObject();");
            memberBuilder.AppendLine("        }");
            memberBuilder.AppendLine("        else");
            memberBuilder.AppendLine("        {");
            memberBuilder.AppendLine("            this.index = -1");
            memberBuilder.AppendLine("            this.hasJsonEnumerator = false;");
            memberBuilder.AppendLine("            this.jsonEnumerator = default;");
            memberBuilder.AppendLine("        }");
            memberBuilder.AppendLine("    }");

            memberBuilder.AppendLine("    /// <inheritdoc/>");
            memberBuilder.AppendLine($"    public Menes.Property<{parentTypeDeclaration.DotnetTypeName}> Current");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        get");
            memberBuilder.AppendLine("        {");
            memberBuilder.AppendLine("            if (this.hasJsonEnumerator)");
            memberBuilder.AppendLine("            {");
            memberBuilder.AppendLine($"                return new Menes.Property<{parentTypeDeclaration.DotnetTypeName}>(this.instance, this.jsonEnumerator.Current);");
            memberBuilder.AppendLine("            }");
            memberBuilder.AppendLine("            else if (this.index >= 0)");
            memberBuilder.AppendLine("            {");
            memberBuilder.AppendLine($"                return this.instance.GetPropertyAtIndex(this.index);");
            memberBuilder.AppendLine("            }");
            memberBuilder.AppendLine($"            return new Menes.Property<{parentTypeDeclaration.DotnetTypeName}>(this.instance, default);");
            memberBuilder.AppendLine("        }");
            memberBuilder.AppendLine("    }");

            memberBuilder.AppendLine("    /// <inheritdoc/>");
            memberBuilder.AppendLine("    object System.Collections.IEnumerator.Current => this.Current;");

            memberBuilder.AppendLine("    /// <summary>");
            memberBuilder.AppendLine("    /// Returns a fresh copy of the enumerator");
            memberBuilder.AppendLine("    /// </summary>");
            memberBuilder.AppendLine($"    /// <returns>An enumerator for the properties in a <see cref=\"{parentTypeDeclaration.DotnetTypeName}\"/>.</returns>");
            memberBuilder.AppendLine("    public PropertyEnumerator GetEnumerator()");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        PropertyEnumerator result = this;");
            memberBuilder.AppendLine("        result.Reset();");
            memberBuilder.AppendLine("        return result;");
            memberBuilder.AppendLine("    }");

            memberBuilder.AppendLine("    /// <inheritdoc/>");
            memberBuilder.AppendLine("    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        return this.GetEnumerator();");
            memberBuilder.AppendLine("    }");

            memberBuilder.AppendLine("    /// <inheritdoc/>");
            memberBuilder.AppendLine($"    System.Collections.Generic.IEnumerator<Menes.Property<{parentTypeDeclaration.DotnetTypeName}>> System.Collections.Generic.IEnumerable<Menes.Property<{parentTypeDeclaration.DotnetTypeName}>>.GetEnumerator()");
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
            memberBuilder.AppendLine("    }");

            memberBuilder.AppendLine("    /// <inheritdoc/>");
            memberBuilder.AppendLine("    public bool MoveNext()");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        if (this.hasJsonEnumerator)");
            memberBuilder.AppendLine("        {");
            memberBuilder.AppendLine("            return this.jsonEnumerator.MoveNext();");
            memberBuilder.AppendLine("        }");
            memberBuilder.AppendLine("        else");
            memberBuilder.AppendLine("        {");
            memberBuilder.AppendLine("            return this.index++;");
            memberBuilder.AppendLine("        }");

            memberBuilder.AppendLine("        return false;");
            memberBuilder.AppendLine("    }");
            memberBuilder.AppendLine("}");
        }

        /// <summary>
        /// Builds the supporting method for <see cref="BuildPropertyEnumerator(TypeDeclaration, StringBuilder)"/>.
        /// </summary>
        /// <param name="parentTypeDeclaration">The type declaration for the owner of this method.</param>
        /// <param name="memberBuilder">The member builder for output.</param>
        public void BuildGetPropertyAtIndex(TypeDeclaration parentTypeDeclaration, StringBuilder memberBuilder)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Builds the object property enumerator.
        /// </summary>
        /// <param name="parentTypeDeclaration">The type declaration for the owner of this method.</param>
        /// <param name="memberBuilder">The member builder for output.</param>
        /// <remarks>
        /// This relies on the <c>PropertyEnumerator</c> type built by <see cref="BuildPropertyEnumerator(TypeDeclaration, StringBuilder)"/>.
        /// </remarks>
        public void BuildEnumerateObject(TypeDeclaration parentTypeDeclaration, StringBuilder memberBuilder)
        {
            throw new NotImplementedException();
        }
    }
}