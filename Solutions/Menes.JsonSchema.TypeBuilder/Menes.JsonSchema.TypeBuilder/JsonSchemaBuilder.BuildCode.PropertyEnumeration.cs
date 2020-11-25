// <copyright file="JsonSchemaBuilder.BuildCode.PropertyEnumeration.cs" company="Endjin Limited">
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
        /// <summary>
        /// Builds a property enumerator for the given type.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This relies on <see cref="BuildPrivateGetPropertyAtIndex(TypeDeclaration, StringBuilder)"/> to create the corresponding <c>Menes.Property&lt;TValue&gt;.GetPropertyAtIndex(int index)</c> method on the parent.
        /// </para>
        /// <para>
        /// It is used by <see cref="BuildPropertyEnumerator(TypeDeclaration, StringBuilder)"/>.
        /// </para>
        /// </remarks>
        private void BuildPropertyEnumerator(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsObjectTypeDeclaration)
            {
                return;
            }

            memberBuilder.AppendLine("/// <summary>");
            memberBuilder.AppendLine($"/// An enumerator for the properties in a <see cref=\"{typeDeclaration.DotnetTypeName}\"/>.");
            memberBuilder.AppendLine("/// </summary>");
            memberBuilder.AppendLine($"public struct MenesPropertyEnumerator : System.Collections.Generic.IEnumerable<Menes.Property<{typeDeclaration.DotnetTypeName}>>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<Menes.Property<{typeDeclaration.DotnetTypeName}>>, System.Collections.IEnumerator");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine($"    private {typeDeclaration.DotnetTypeName} instance;");
            memberBuilder.AppendLine($"    private System.Text.Json.JsonElement.ObjectEnumerator jsonEnumerator;");
            memberBuilder.AppendLine($"    private bool hasJsonEnumerator;");
            memberBuilder.AppendLine($"    private int index;");
            memberBuilder.AppendLine($"    private int propertyCount;");

            memberBuilder.AppendLine($"    internal MenesPropertyEnumerator({typeDeclaration.DotnetTypeName} instance)");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        this.instance = instance;");
            memberBuilder.AppendLine("        this.propertyCount = instance.PropertyCount;");
            memberBuilder.AppendLine("        if (this.instance.HasJsonElement)");
            memberBuilder.AppendLine("        {");
            memberBuilder.AppendLine("            this.index = -2;");
            memberBuilder.AppendLine("            this.hasJsonEnumerator = true;");
            memberBuilder.AppendLine("            this.jsonEnumerator = this.instance.JsonElement.EnumerateObject();");
            memberBuilder.AppendLine("        }");
            memberBuilder.AppendLine("        else");
            memberBuilder.AppendLine("        {");
            memberBuilder.AppendLine("            this.index = -1;");
            memberBuilder.AppendLine("            this.hasJsonEnumerator = false;");
            memberBuilder.AppendLine("            this.jsonEnumerator = default;");
            memberBuilder.AppendLine("        }");
            memberBuilder.AppendLine("    }");

            memberBuilder.AppendLine("    /// <inheritdoc/>");
            memberBuilder.AppendLine($"    public Menes.Property<{typeDeclaration.DotnetTypeName}> Current");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        get");
            memberBuilder.AppendLine("        {");
            memberBuilder.AppendLine("            if (this.hasJsonEnumerator)");
            memberBuilder.AppendLine("            {");
            memberBuilder.AppendLine($"                return new Menes.Property<{typeDeclaration.DotnetTypeName}>(this.jsonEnumerator.Current);");
            memberBuilder.AppendLine("            }");
            memberBuilder.AppendLine("            else if (this.index >= 0)");
            memberBuilder.AppendLine("            {");
            memberBuilder.AppendLine($"                if (this.instance.TryGetPropertyAtIndex(this.index, out Menes.Property<{typeDeclaration.DotnetTypeName}> result))");
            memberBuilder.AppendLine("                {");
            memberBuilder.AppendLine("                    return result;");
            memberBuilder.AppendLine("                }");
            memberBuilder.AppendLine("                throw new System.InvalidOperationException(\"Unable to get the property in the enumeration. The collection has been modified.\");");
            memberBuilder.AppendLine("            }");
            memberBuilder.AppendLine($"            return new Menes.Property<{typeDeclaration.DotnetTypeName}>(this.instance, default);");
            memberBuilder.AppendLine("        }");
            memberBuilder.AppendLine("    }");
            memberBuilder.AppendLine("    /// <inheritdoc/>");
            memberBuilder.AppendLine("    object System.Collections.IEnumerator.Current => this.Current;");

            memberBuilder.AppendLine("    /// <summary>");
            memberBuilder.AppendLine("    /// Returns a fresh copy of the enumerator");
            memberBuilder.AppendLine("    /// </summary>");
            memberBuilder.AppendLine($"    /// <returns>An enumerator for the properties in a <see cref=\"{typeDeclaration.DotnetTypeName}\"/>.</returns>");
            memberBuilder.AppendLine("    public MenesPropertyEnumerator GetEnumerator()");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        MenesPropertyEnumerator result = this;");
            memberBuilder.AppendLine("        result.Reset();");
            memberBuilder.AppendLine("        return result;");
            memberBuilder.AppendLine("    }");

            memberBuilder.AppendLine("    /// <inheritdoc/>");
            memberBuilder.AppendLine("    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        return this.GetEnumerator();");
            memberBuilder.AppendLine("    }");

            memberBuilder.AppendLine("    /// <inheritdoc/>");
            memberBuilder.AppendLine($"    System.Collections.Generic.IEnumerator<Menes.Property<{typeDeclaration.DotnetTypeName}>> System.Collections.Generic.IEnumerable<Menes.Property<{typeDeclaration.DotnetTypeName}>>.GetEnumerator()");
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
            memberBuilder.AppendLine("            if (this.index + 1 < this.propertyCount)");
            memberBuilder.AppendLine("            {");
            memberBuilder.AppendLine("                this.index++;");
            memberBuilder.AppendLine("                return true;");
            memberBuilder.AppendLine("            }");
            memberBuilder.AppendLine("            return false;");
            memberBuilder.AppendLine("        }");
            memberBuilder.AppendLine("    }");
            memberBuilder.AppendLine("}");
        }

        private void BuildPropertyCountProperty(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsObjectTypeDeclaration)
            {
                return;
            }

            memberBuilder.AppendLine("public int PropertyCount");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("   get");
            memberBuilder.AppendLine("   {");
            memberBuilder.AppendLine("       if (this.HasJsonElement)");
            memberBuilder.AppendLine("       {");
            memberBuilder.AppendLine("           int jsonPropertyIndex = 0;");
            memberBuilder.AppendLine("           foreach (var property in this.JsonElement.EnumerateObject())");
            memberBuilder.AppendLine("           {");
            memberBuilder.AppendLine("               jsonPropertyIndex++;");
            memberBuilder.AppendLine("           }");
            memberBuilder.AppendLine("           return jsonPropertyIndex;");
            memberBuilder.AppendLine("       }");
            memberBuilder.AppendLine("       else");
            memberBuilder.AppendLine("       {");

            if (typeDeclaration.Properties?.Count is int count)
            {
                if (typeDeclaration.AllowsAdditionalProperties)
                {
                    memberBuilder.AppendLine($"           return {count} + this._menesAdditionalPropertiesBacking.Length;");
                }
                else
                {
                    memberBuilder.AppendLine($"           return {count} + this._menesAdditionalPropertiesBacking.Length;");
                }
            }
            else
            {
                if (typeDeclaration.AllowsAdditionalProperties)
                {
                    memberBuilder.AppendLine($"           return this._menesAdditionalPropertiesBacking.Length;");
                }
                else
                {
                    memberBuilder.AppendLine($"           return 0;");
                }
            }

            memberBuilder.AppendLine("       }");
            memberBuilder.AppendLine("   }");
            memberBuilder.AppendLine("}");
        }

        private void BuildPublicGetPropertyAtIndex(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsObjectTypeDeclaration)
            {
                return;
            }

            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public bool TryGetPropertyAtIndex(int index, out Menes.IProperty result)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine($"    var rc = this.TryGetPropertyAtIndex(index, out Menes.Property<{typeDeclaration.DotnetTypeName}> prop);");
            memberBuilder.AppendLine("    result = prop;");
            memberBuilder.AppendLine("    return rc;");
            memberBuilder.AppendLine("}");
        }

        private void BuildPrivateGetPropertyAtIndex(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsObjectTypeDeclaration)
            {
                return;
            }

            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine($"private bool TryGetPropertyAtIndex(int index, out Menes.Property<{typeDeclaration.DotnetTypeName}> result)");
            memberBuilder.AppendLine("{");

            this.BuildTryGetPropertyAtIndexFromJsonElement(typeDeclaration, memberBuilder);

            memberBuilder.AppendLine("int currentIndex = 0;");
            if (typeDeclaration.Properties is not null)
            {
                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
                    memberBuilder.AppendLine($"    if (currentIndex == index)");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine($"        result = new Menes.Property<{typeDeclaration.DotnetTypeName}>(this, _Menes{property.DotnetPropertyName}JsonPropertyName);");
                    memberBuilder.AppendLine("      return true;");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("    currentIndex++;");
                }
            }

            if (typeDeclaration.AllowsAdditionalProperties)
            {
                memberBuilder.AppendLine("foreach (var property in this._menesAdditionalPropertiesBacking)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    if (currentIndex == index)");
                memberBuilder.AppendLine("    {");
                memberBuilder.AppendLine($"        result = new Menes.Property<{typeDeclaration.DotnetTypeName}>(this, property.NameAsMemory);");
                memberBuilder.AppendLine("        return true;");
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("    currentIndex++;");
                memberBuilder.AppendLine("}");
            }

            memberBuilder.AppendLine("    result = default;;");
            memberBuilder.AppendLine("    return false;");
            memberBuilder.AppendLine("}");
        }

        private void BuildTryGetPropertyAtIndexFromJsonElement(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("if (this.HasJsonElement)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    int jsonPropertyIndex = 0;");
            memberBuilder.AppendLine("    foreach (var property in this.JsonElement.EnumerateObject())");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        if (jsonPropertyIndex == index)");
            memberBuilder.AppendLine("        {");
            memberBuilder.AppendLine($"            result = new Menes.Property<{typeDeclaration.DotnetTypeName}>(property);");
            memberBuilder.AppendLine($"            return true;");
            memberBuilder.AppendLine("        }");
            memberBuilder.AppendLine("        jsonPropertyIndex++;");
            memberBuilder.AppendLine("    }");
            memberBuilder.AppendLine("}");
        }

        /// <summary>
        /// Builds the object property enumerator.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration for the owner of this method.</param>
        /// <param name="memberBuilder">The member builder for output.</param>
        /// <remarks>
        /// This relies on the <c>PropertyEnumerator</c> type built by <see cref="BuildPropertyEnumerator(TypeDeclaration, StringBuilder)"/>.
        /// </remarks>
        private void BuildObjectEnumerator(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsObjectTypeDeclaration)
            {
                return;
            }

            if (!typeDeclaration.IsArrayTypeDeclaration)
            {
                memberBuilder.AppendLine($"public {typeDeclaration.FullyQualifiedDotNetTypeName}.MenesPropertyEnumerator GetEnumerator()");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine($"    return new {typeDeclaration.FullyQualifiedDotNetTypeName}.MenesPropertyEnumerator(this);");
                memberBuilder.AppendLine("}");

                memberBuilder.AppendLine("System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    return this.GetEnumerator();");
                memberBuilder.AppendLine("}");

                memberBuilder.AppendLine($"System.Collections.Generic.IEnumerator<Menes.Property<{typeDeclaration.FullyQualifiedDotNetTypeName}>> System.Collections.Generic.IEnumerable<Menes.Property<{typeDeclaration.FullyQualifiedDotNetTypeName}>>.GetEnumerator()");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    return this.GetEnumerator();");
                memberBuilder.AppendLine("}");
            }
            else
            {
                // In this code path we integrate both object and array type
                // enumeration as per JsonAny.
                TypeDeclaration itemsType = this.GetItemsTypeFor(typeDeclaration);

                memberBuilder.AppendLine("/// <summary>");
                memberBuilder.AppendLine("/// Enumerate the array.");
                memberBuilder.AppendLine("/// </summary>");
                memberBuilder.AppendLine("/// <returns>An array enumerator.</returns>");
                memberBuilder.AppendLine("public MenesArrayEnumerator EnumerateArray()");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    return new MenesArrayEnumerator(this);");
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("/// <summary>");
                memberBuilder.AppendLine("/// Enumerate the properties in the object.");
                memberBuilder.AppendLine("/// </summary>");
                memberBuilder.AppendLine("/// <returns>The object enumerator.</returns>");
                memberBuilder.AppendLine("public MenesPropertyEnumerator EnumerateObject()");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    return new MenesPropertyEnumerator(this);");
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("/// <inheritdoc/>");
                memberBuilder.AppendLine("public System.Collections.IEnumerator GetEnumerator()");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    if (this.IsObject)");
                memberBuilder.AppendLine("    {");
                memberBuilder.AppendLine("        return this.EnumerateObject();");
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("    if (this.IsArray)");
                memberBuilder.AppendLine("    {");
                memberBuilder.AppendLine("        return this.EnumerateArray();");
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("    throw new System.InvalidOperationException(\"Cannot enumerate a non array or object type.\");");
                memberBuilder.AppendLine("}");

                memberBuilder.AppendLine($"System.Collections.Generic.IEnumerator<Menes.Property<{typeDeclaration.FullyQualifiedDotNetTypeName}>> System.Collections.Generic.IEnumerable<Menes.Property<{typeDeclaration.FullyQualifiedDotNetTypeName}>>.GetEnumerator()");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    return this.EnumerateObject();");
                memberBuilder.AppendLine("}");

                memberBuilder.AppendLine($"System.Collections.Generic.IEnumerator<{itemsType.FullyQualifiedDotNetTypeName}> System.Collections.Generic.IEnumerable<{itemsType.FullyQualifiedDotNetTypeName}>.GetEnumerator()");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    return this.EnumerateArray();");
                memberBuilder.AppendLine("}");
            }
        }
    }
}