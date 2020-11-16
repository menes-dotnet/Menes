// <copyright file="JsonSchemaBuilder.Naming.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Collections.Generic;
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

        private Dictionary<string, string> fullyQualifiedTypeNameToAsMethodName = new Dictionary<string, string>();

        private static ReadOnlyMemory<char> MakeMemberNameUnique(TypeDeclaration? typeDeclaration, ReadOnlyMemory<char> baseName, ReadOnlyMemory<char>? suffix = null)
        {
            if (typeDeclaration is TypeDeclaration owner)
            {
                int baseLength = baseName.Length + 3 + (suffix?.Length ?? 0);

                // You can have up to 999 items with the same name before we blow up!
                Memory<char> nameMemory = new char[baseLength];
                Span<char> name = nameMemory.Span;
                baseName.Span.CopyTo(name);
                int length = baseName.Length;

                if (suffix is ReadOnlyMemory<char>)
                {
                    suffix.Value.Span.CopyTo(name[baseName.Length..]);
                }

                int index = 1;
                length = baseName.Length + (suffix?.Length ?? 0);
                while (owner.ContainsMemberName(name.Slice(0, length)))
                {
                    if (index < 10)
                    {
                        name[baseName.Length] = Convert.ToChar(0x30 + index);
                        length = baseName.Length + 1;
                        if (suffix is ReadOnlyMemory<char>)
                        {
                            int start = baseName.Length + 1;
                            suffix.Value.Span.CopyTo(name[start..]);
                        }
                    }
                    else if (index < 100)
                    {
                        name[baseName.Length] = Convert.ToChar(0x30 + (index % 10));
                        name[baseName.Length + 1] = Convert.ToChar(0x30 + index);
                        length = baseName.Length + 2;
                        if (suffix is ReadOnlyMemory<char>)
                        {
                            int start = baseName.Length + 2;
                            suffix.Value.Span.CopyTo(name[start..]);
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
                            int start = baseName.Length + 3;
                            suffix.Value.Span.CopyTo(name[start..]);
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
                            int start = baseName.Length + 1;
                            suffix.Value.Span.CopyTo(name[start..]);
                        }
                    }
                    else if (index < 100)
                    {
                        name[baseName.Length] = Convert.ToChar(0x30 + (index % 10));
                        name[baseName.Length + 1] = Convert.ToChar(0x30 + index);
                        length = baseName.Length + 2;
                        if (suffix is ReadOnlyMemory<char>)
                        {
                            int start = baseName.Length + 2;
                            suffix.Value.Span.CopyTo(name[start..]);
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
                            int start = baseName.Length + 3;
                            suffix.Value.Span.CopyTo(name[start..]);
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

        private static ReadOnlyMemory<char> GetTypeSuffixFor(ReadOnlyMemory<char> baseName, LocatedElement schema)
        {
            // If we have an explicit type and it is a string we can determine a better type name
            if (schema.JsonElement.ValueKind == JsonValueKind.Object && schema.JsonElement.TryGetProperty("type", out JsonElement type) && type.ValueKind == JsonValueKind.String)
            {
                if (type.ValueEquals("object"))
                {
                    if (baseName.Length >= EntitySuffix.Length && baseName[^EntitySuffix.Length..].Span.SequenceEqual(EntitySuffix.Span))
                    {
                        return ValueSuffix;
                    }

                    return EntitySuffix;
                }
                else if (type.ValueEquals("array"))
                {
                    if (baseName.Length >= ArraySuffix.Length && baseName[^ArraySuffix.Length..].Span.SequenceEqual(ArraySuffix.Span))
                    {
                        return EntitySuffix;
                    }

                    return ArraySuffix;
                }
                else
                {
                    if (baseName.Length >= ValueSuffix.Length && baseName[^ValueSuffix.Length..].Span.SequenceEqual(ValueSuffix.Span))
                    {
                        return EntitySuffix;
                    }

                    return ValueSuffix;
                }
            }

            return EntitySuffix;
        }

        /// <summary>
        /// Gets the As{TypeName}() method name for the given type
        /// declaration.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This looks the name up in the map of FQTNs to method names, and builds one if it
        /// isn't.
        /// </para>
        /// </remarks>
        private string GetAsMethodNameFor(TypeDeclaration typeDeclaration)
        {
            if (typeDeclaration.FullyQualifiedDotNetTypeName is not string)
            {
                throw new InvalidOperationException("You must set the type name for an entity before generating code.");
            }

            if (!this.fullyQualifiedTypeNameToAsMethodName.TryGetValue(typeDeclaration.FullyQualifiedDotNetTypeName, out string asMethodName))
            {
                int nameIndex = 1;
                string baseAsMethodName = $"As{typeDeclaration.DotnetTypeName}";
                asMethodName = baseAsMethodName;
                while (this.fullyQualifiedTypeNameToAsMethodName.ContainsKey(asMethodName))
                {
                    asMethodName = $"{baseAsMethodName}{nameIndex}";
                    nameIndex++;
                }

                this.fullyQualifiedTypeNameToAsMethodName.Add(typeDeclaration.FullyQualifiedDotNetTypeName, asMethodName);
            }

            return asMethodName;
        }

        private void SetTypeName(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            ReadOnlyMemory<char> baseName = Formatting.FormatReferenceAsName(schema.AbsoluteKeywordLocation);

            // If we named from the fragment, then we may need to add a suffix
            if (schema.AbsoluteKeywordLocation.HasFragment && this.absoluteKeywordLocationStack.Peek().Equals(schema.AbsoluteKeywordLocation))
            {
                typeDeclaration.DotnetTypeName = MakeMemberNameUnique(typeDeclaration.Parent, baseName, GetTypeSuffixFor(baseName, schema)).ToString();
            }
            else
            {
                typeDeclaration.DotnetTypeName = MakeMemberNameUnique(typeDeclaration.Parent, baseName, GetTypeSuffixFor(baseName, schema)).ToString();
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