// <copyright file="JsonSchemaBuilder.Naming.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        private static ReadOnlySpan<char> MakeMemberNameUnique(TypeDeclaration typeDeclaration, ReadOnlySpan<char> baseName)
        {
            if (typeDeclaration.Parent is TypeDeclaration parent)
            {
                // You can have up to 999 items with the same name before we blow up!
                Span<char> name = new char[baseName.Length + 3];
                baseName.CopyTo(name);
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
                        throw new InvalidOperationException($"Unsupported schema: more than 999 members have been defined which resolve to the name '{baseName.ToString()}'");
                    }

                    index++;
                }

                return name.Slice(0, length);
            }
            else
            {
                return baseName;
            }
        }
    }
}