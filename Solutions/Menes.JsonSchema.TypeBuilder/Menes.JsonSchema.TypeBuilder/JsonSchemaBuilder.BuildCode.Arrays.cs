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
                memberBuilder.AppendLine("            else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonArrayValueBacking> array && this.index >= 0 && this.index < array.Length)");
                memberBuilder.AppendLine("            {");
                memberBuilder.AppendLine($"                return array[this.index].As<{itemsType.FullyQualifiedDotNetTypeName}>();");
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
                memberBuilder.AppendLine("        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<Menes.JsonArrayValueBacking> array && this.index + 1 < array.Length)");
            }
            else
            {
                memberBuilder.AppendLine($"        else if (this.instance._menesArrayValueBacking is System.Collections.Immutable.ImmutableArray<{itemsType.FullyQualifiedDotNetTypeName}> array && this.index + 1 < array.Length)");
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

            memberBuilder.Append($"System.Collections.Generic.IEnumerator<{itemsType.FullyQualifiedDotNetTypeName}> System.Collections.Generic.IEnumerable<{itemsType.FullyQualifiedDotNetTypeName}>.GetEnumerator()");
            memberBuilder.Append("{");
            memberBuilder.Append("    return this.GetEnumerator();");
            memberBuilder.Append("}");
        }

        private void BuildArrayAdd(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsArrayTypeDeclaration)
            {
                return;
            }

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} Add<T1>(T1 item1)");
            memberBuilder.AppendLine("    where T1 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");

            this.BuildArrayAddOrInsert(typeDeclaration, memberBuilder, false, 1);

            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} Add<T1, T2>(T1 item1, T2 item2)");
            memberBuilder.AppendLine("    where T1 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("    where T2 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");

            this.BuildArrayAddOrInsert(typeDeclaration, memberBuilder, false, 2);

            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} Add<T1, T2, T3>(T1 item1, T2 item2, T3 item3)");
            memberBuilder.AppendLine("    where T1 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("    where T2 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("    where T3 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");

            this.BuildArrayAddOrInsert(typeDeclaration, memberBuilder, false, 3);

            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} Add<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)");
            memberBuilder.AppendLine("    where T1 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("    where T2 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("    where T3 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("    where T4 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");

            this.BuildArrayAddOrInsert(typeDeclaration, memberBuilder, false, 4);

            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} Add<T>(params T[] items)");
            memberBuilder.AppendLine("    where T : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");

            this.BuildArrayAddOrInsert(typeDeclaration, memberBuilder, false, -1);

            memberBuilder.AppendLine("}");
        }

        private void BuildArrayInsert(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsArrayTypeDeclaration)
            {
                return;
            }

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} Insert<T>(int index, T item1)");
            memberBuilder.AppendLine("    where T : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");

            this.BuildArrayAddOrInsert(typeDeclaration, memberBuilder, true, 1);

            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} Insert<T1, T2>(int index, T1 item1, T2 item2)");
            memberBuilder.AppendLine("    where T1 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("    where T2 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");

            this.BuildArrayAddOrInsert(typeDeclaration, memberBuilder, true, 2);

            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} Insert<T1, T2, T3>(int index, T1 item1, T2 item2, T3 item3)");
            memberBuilder.AppendLine("    where T1 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("    where T2 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("    where T3 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");

            this.BuildArrayAddOrInsert(typeDeclaration, memberBuilder, true, 3);

            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} Insert<T1, T2, T3, T4>(int index, T1 item1, T2 item2, T3 item3, T4 item4)");
            memberBuilder.AppendLine("    where T1 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("    where T2 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("    where T3 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("    where T4 : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");

            this.BuildArrayAddOrInsert(typeDeclaration, memberBuilder, true, 4);

            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} Insert<T>(int index, params T[] items)");
            memberBuilder.AppendLine("    where T : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");

            this.BuildArrayAddOrInsert(typeDeclaration, memberBuilder, true, -1);

            memberBuilder.AppendLine("}");
        }

        private void BuildArrayAddOrInsert(TypeDeclaration typeDeclaration, StringBuilder memberBuilder, bool insert, int itemsCount)
        {
            TypeDeclaration itemsType = this.GetItemsTypeFor(typeDeclaration);
            bool containsReference = itemsType.ContainsReferenceTo(typeDeclaration);

            if (containsReference)
            {
                memberBuilder.AppendLine("var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();");
            }
            else
            {
                memberBuilder.AppendLine($"var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemsType.FullyQualifiedDotNetTypeName}>();");
            }

            if (insert)
            {
                memberBuilder.AppendLine("int currentIndex = 0;");
                memberBuilder.AppendLine("bool inserted = false;");
            }

            memberBuilder.AppendLine("foreach(var oldItem in this._menesArrayValueBacking)");
            memberBuilder.AppendLine("{");
            if (insert)
            {
                memberBuilder.AppendLine("if (currentIndex == index)");
                memberBuilder.AppendLine("{");
                if (itemsCount == -1)
                {
                    memberBuilder.AppendLine("foreach (var item1 in items)");
                    memberBuilder.AppendLine("{");
                    this.AddNewItem(memberBuilder, itemsType, containsReference, 1);
                    memberBuilder.AppendLine("}");
                }
                else
                {
                    for (int i = 0; i < itemsCount; ++i)
                    {
                        this.AddNewItem(memberBuilder, itemsType, containsReference, i + 1);
                    }
                }

                memberBuilder.AppendLine("    inserted = true;");
                memberBuilder.AppendLine("}");
            }

            memberBuilder.AppendLine("arrayBuilder.Add(oldItem);");

            if (insert)
            {
                memberBuilder.AppendLine("currentIndex++;");
            }

            memberBuilder.AppendLine("}");

            if (insert)
            {
                memberBuilder.AppendLine("if (!inserted)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    throw new System.IndexOutOfRangeException($\"The given index {index} was out of range.\");");
                memberBuilder.AppendLine("}");
            }
            else
            {
                if (itemsCount == -1)
                {
                    memberBuilder.AppendLine("foreach (var item1 in items)");
                    memberBuilder.AppendLine("{");
                    this.AddNewItem(memberBuilder, itemsType, containsReference, 1);
                    memberBuilder.AppendLine("}");
                }
                else
                {
                    for (int i = 0; i < itemsCount; ++i)
                    {
                        this.AddNewItem(memberBuilder, itemsType, containsReference, i + 1);
                    }
                }
            }

            memberBuilder.AppendLine($"return new {typeDeclaration.FullyQualifiedDotNetTypeName}(arrayBuilder.ToImmutable());");
        }

        private void BuildArrayRemoveAt(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsArrayTypeDeclaration)
            {
                return;
            }

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} RemoveAt(int index)");
            memberBuilder.AppendLine("{");

            TypeDeclaration itemsType = this.GetItemsTypeFor(typeDeclaration);
            bool containsReference = itemsType.ContainsReferenceTo(typeDeclaration);

            if (containsReference)
            {
                memberBuilder.AppendLine("var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();");
            }
            else
            {
                memberBuilder.AppendLine($"var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemsType.FullyQualifiedDotNetTypeName}>();");
            }

            memberBuilder.AppendLine("int currentIndex = 0;");
            memberBuilder.AppendLine("bool removed = false;");
            memberBuilder.AppendLine("foreach(var item in this._menesArrayValueBacking)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    if (currentIndex != index)");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        arrayBuilder.Add(item);");
            memberBuilder.AppendLine("    }");
            memberBuilder.AppendLine("    else");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        removed = true;");
            memberBuilder.AppendLine("    }");
            memberBuilder.AppendLine("    currentIndex++;");
            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine("if (!removed)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    throw new System.IndexOutOfRangeException($\"The given index {index} was out of range.\");");
            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine($"return new {typeDeclaration.FullyQualifiedDotNetTypeName}(arrayBuilder.ToImmutable());");

            memberBuilder.AppendLine("}");
        }

        private void BuildArrayRemoveIf(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsArrayTypeDeclaration)
            {
                return;
            }

            TypeDeclaration itemsType = this.GetItemsTypeFor(typeDeclaration);
            bool containsReference = itemsType.ContainsReferenceTo(typeDeclaration);

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} RemoveIf(System.Predicate<{itemsType.FullyQualifiedDotNetTypeName}> condition)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine($"    return this.RemoveIf<{itemsType.FullyQualifiedDotNetTypeName}>(condition);");
            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} RemoveIf<T>(System.Predicate<T> condition)");
            memberBuilder.AppendLine($"    where T : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");

            if (containsReference)
            {
                memberBuilder.AppendLine("var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();");
            }
            else
            {
                memberBuilder.AppendLine($"var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{itemsType.FullyQualifiedDotNetTypeName}>();");
            }

            memberBuilder.AppendLine("foreach(var item in this._menesArrayValueBacking)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    if (!condition(item.As<T>()))");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        arrayBuilder.Add(item);");
            memberBuilder.AppendLine("    }");
            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine($"return new {typeDeclaration.FullyQualifiedDotNetTypeName}(arrayBuilder.ToImmutable());");

            memberBuilder.AppendLine("}");
        }

        private void AddNewItem(StringBuilder memberBuilder, TypeDeclaration itemsType, bool containsReference, int itemIndex)
        {
            if (containsReference)
            {
                memberBuilder.AppendLine($"    arrayBuilder.Add(Menes.JsonArrayValueBacking.From<{itemsType.FullyQualifiedDotNetTypeName}>(item{itemIndex}.As<{itemsType.FullyQualifiedDotNetTypeName}>()));");
            }
            else
            {
                memberBuilder.AppendLine($"    arrayBuilder.Add(item{itemIndex}.As<{itemsType.FullyQualifiedDotNetTypeName}>());");
            }
        }

        private void BuildArrayInterfaces(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsArrayTypeDeclaration)
            {
                return;
            }

            TypeDeclaration itemsType = this.GetItemsTypeFor(typeDeclaration);
            memberBuilder.Append($", Menes.IJsonArray<{typeDeclaration.DotnetTypeName}, {itemsType.FullyQualifiedDotNetTypeName}>");
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
            if (typeDeclaration.IsArrayTypeDeclaration)
            {
                TypeDeclaration itemsType = this.GetItemsTypeFor(typeDeclaration);
                if (itemsType.ContainsReferenceTo(typeDeclaration))
                {
                    memberBuilder.AppendLine("private readonly System.Collections.Immutable.ImmutableArray<Menes.JsonArrayValueBacking>? _menesArrayValueBacking;");
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
