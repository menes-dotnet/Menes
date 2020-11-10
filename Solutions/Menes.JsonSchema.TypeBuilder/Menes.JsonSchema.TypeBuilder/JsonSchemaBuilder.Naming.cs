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

        private static ReadOnlyMemory<char> MakeMemberNameUnique(TypeDeclaration? typeDeclaration, ReadOnlyMemory<char> baseName, ReadOnlyMemory<char>? suffix = null)
        {
            if (typeDeclaration is TypeDeclaration owner)
            {
                int baseLength = baseName.Length + 3 + (suffix?.Length ?? 0);

                // You can have up to 999 items with the same name before we blow up!
                Memory<char> nameMemory = new char[baseLength];
                Span<char> name = nameMemory.Span;
                baseName.Span.CopyTo(name);
                if (suffix is ReadOnlyMemory<char>)
                {
                    suffix.Value.Span.CopyTo(name[baseName.Length..]);
                }

                int index = 1;
                int length = baseName.Length + (suffix?.Length ?? 0);
                while (owner.ContainsMemberName(name.Slice(0, length)))
                {
                    if (index < 10)
                    {
                        name[baseName.Length] = Convert.ToChar(0x30 + index);
                        length = baseName.Length + 1;
                        if (suffix is ReadOnlyMemory<char>)
                        {
                            suffix.Value.Span.CopyTo(name[(baseName.Length + 1) ..]);
                        }
                    }
                    else if (index < 100)
                    {
                        name[baseName.Length] = Convert.ToChar(0x30 + (index % 10));
                        name[baseName.Length + 1] = Convert.ToChar(0x30 + index);
                        length = baseName.Length + 2;
                        if (suffix is ReadOnlyMemory<char>)
                        {
                            suffix.Value.Span.CopyTo(name[(baseName.Length + 2) ..]);
                        }
                    }
                    else if (index < 1000)
                    {
                        name[baseName.Length] = Convert.ToChar(0x30 + (index % 100));
                        name[baseName.Length + 1] = Convert.ToChar(0x30 + (index % 10));
                        name[baseName.Length + 2] = Convert.ToChar(0x30 + index);
                        length = baseName.Length + 3;
                        if (suffix is ReadOnlyMemory<char>)
                        {
                            suffix.Value.Span.CopyTo(name[(baseName.Length + 3) ..]);
                        }
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

        private static ReadOnlySpan<char> MakeMemberNameUnique(TypeDeclaration? typeDeclaration, ReadOnlySpan<char> baseName, ReadOnlyMemory<char>? suffix = null)
        {
            if (typeDeclaration is TypeDeclaration owner)
            {
                int baseLength = baseName.Length + 3 + (suffix?.Length ?? 0);

                // You can have up to 999 items with the same name before we blow up!
                Memory<char> nameMemory = new char[baseLength];
                Span<char> name = nameMemory.Span;
                baseName.CopyTo(name);
                if (suffix is ReadOnlyMemory<char>)
                {
                    suffix.Value.Span.CopyTo(name[baseName.Length..]);
                }

                int index = 1;
                int length = baseName.Length + (suffix?.Length ?? 0);
                while (owner.ContainsMemberName(name.Slice(0, length)))
                {
                    if (index < 10)
                    {
                        name[baseName.Length] = Convert.ToChar(0x30 + index);
                        length = baseName.Length + 1;
                        if (suffix is ReadOnlyMemory<char>)
                        {
                            suffix.Value.Span.CopyTo(name[(baseName.Length + 1) ..]);
                        }
                    }
                    else if (index < 100)
                    {
                        name[baseName.Length] = Convert.ToChar(0x30 + (index % 10));
                        name[baseName.Length + 1] = Convert.ToChar(0x30 + index);
                        length = baseName.Length + 2;
                        if (suffix is ReadOnlyMemory<char>)
                        {
                            suffix.Value.Span.CopyTo(name[(baseName.Length + 2) ..]);
                        }
                    }
                    else if (index < 1000)
                    {
                        name[baseName.Length] = Convert.ToChar(0x30 + (index % 100));
                        name[baseName.Length + 1] = Convert.ToChar(0x30 + (index % 10));
                        name[baseName.Length + 2] = Convert.ToChar(0x30 + index);
                        length = baseName.Length + 3;
                        if (suffix is ReadOnlyMemory<char>)
                        {
                            suffix.Value.Span.CopyTo(name[(baseName.Length + 3) ..]);
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unsupported schema: more than 999 members have been defined which resolve to the name '{baseName.ToString()}'");
                    }

                    index++;
                }

                return nameMemory.Span.Slice(0, length);
            }
            else
            {
                return baseName;
            }
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

            // If we named from the fragment, then we need to add a suffix
            if (schema.AbsoluteKeywordLocation.HasFragment)
            {
                typeDeclaration.DotnetTypeName = MakeMemberNameUnique(typeDeclaration.Parent, baseName, GetTypeSuffixFor(schema)).ToString();
            }
            else
            {
                typeDeclaration.DotnetTypeName = MakeMemberNameUnique(typeDeclaration.Parent, baseName).ToString();
            }

            if (string.IsNullOrEmpty(typeDeclaration.DotnetTypeName))
            {
                throw new InvalidOperationException("DotNetTypeName cannot be null or empty.");
            }
        }

        private void SetPropertyName(TypeDeclaration typeDeclaration, string name, PropertyDeclaration propertyDeclaration)
        {
            propertyDeclaration.JsonPropertyName = name;

            ReadOnlySpan<char> basePropertyName = Formatting.ToPascalCaseWithReservedWords(name);
            propertyDeclaration.DotnetPropertyName = MakeMemberNameUnique(typeDeclaration, basePropertyName).ToString();

            ReadOnlySpan<char> baseFieldName = Formatting.ToCamelCaseWithReservedWords(name);
            propertyDeclaration.DotnetFieldName = MakeMemberNameUnique(typeDeclaration, baseFieldName).ToString();
        }
    }
}