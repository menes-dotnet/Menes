// <copyright file="JsonSchemaBuilder.Naming.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Text.Json;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        private static readonly ReadOnlyMemory<char> ArraySuffix = "Array".AsMemory();
        private static readonly ReadOnlyMemory<char> ValueSuffix = "Value".AsMemory();
        private static readonly ReadOnlyMemory<char> EntitySuffix = "Entity".AsMemory();

        private static ReadOnlyMemory<char> MakeMemberNameUnique(TypeDeclaration typeDeclaration, ReadOnlyMemory<char> baseName)
        {
            if (typeDeclaration.Parent is TypeDeclaration parent)
            {
                // You can have up to 999 items with the same name before we blow up!
                Memory<char> nameMemory = new char[baseName.Length + 3];
                Span<char> name = nameMemory.Span;
                baseName.Span.CopyTo(name);
                int index = 1;
                int length = baseName.Length;
                while (parent.ContainsMemberNamed(name.Slice(0, length)))
                {
                    if (index < 10)
                    {
                        name[baseName.Length] = Convert.ToChar(0x30 + index);
                        length = baseName.Length + 1;
                    }
                    else if (index < 100)
                    {
                        name[baseName.Length] = Convert.ToChar(0x30 + (index % 10));
                        name[baseName.Length + 1] = Convert.ToChar(0x30 + index);
                        length = baseName.Length + 2;
                    }
                    else if (index < 1000)
                    {
                        name[baseName.Length] = Convert.ToChar(0x30 + (index % 100));
                        name[baseName.Length + 1] = Convert.ToChar(0x30 + (index % 10));
                        name[baseName.Length + 2] = Convert.ToChar(0x30 + index);
                        length = baseName.Length + 3;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unsupported schema: more than 999 members have been defined which resolve to the name '{baseName}'");
                    }

                    index++;
                }

                return nameMemory.Slice(0, length);
            }
            else
            {
                return baseName;
            }
        }

        private static void SetTypeNameWithSuffix(TypeDeclaration typeDeclaration, ReadOnlyMemory<char> uniqueName, ReadOnlyMemory<char> suffix)
        {
            typeDeclaration.DotnetTypeName = string.Create(
                                    uniqueName.Length + suffix.Length,
                                    (name: uniqueName, suffix),
                                    (chars, state) =>
                                    {
                                        state.name.Span.CopyTo(chars);
                                        state.suffix.Span.CopyTo(chars.Slice(state.name.Length));
                                    });
        }

        private static ReadOnlyMemory<char> GetTypeSuffixFor(LocatedElement schema)
        {
            // If we have an explicit type and it is a string we can determine a better type name
            if (schema.JsonElement.ValueKind == JsonValueKind.Object && schema.JsonElement.TryGetProperty("type", out JsonElement type) && type.ValueKind == JsonValueKind.String)
            {
                if (type.ValueEquals("object"))
                {
                    return EntitySuffix;
                }
                else if (type.ValueEquals("array"))
                {
                    return ArraySuffix;
                }
                else
                {
                    return ValueSuffix;
                }
            }

            return EntitySuffix;
        }

        private void SetTypeName(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            ReadOnlyMemory<char> baseName = Formatting.FormatReferenceAsName(schema.AbsoluteKeywordLocation);
            ReadOnlyMemory<char> uniqueName = MakeMemberNameUnique(typeDeclaration, baseName);

            // If we named from the fragment, then we need to add a suffix
            if (schema.AbsoluteKeywordLocation.HasFragment)
            {
                SetTypeNameWithSuffix(typeDeclaration, uniqueName, GetTypeSuffixFor(schema));
            }
            else
            {
                typeDeclaration.DotnetTypeName = uniqueName.ToString();
            }
        }
    }
}