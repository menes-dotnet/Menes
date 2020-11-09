// <copyright file="TypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A declaration of a type built from schema.
    /// </summary>
    public class TypeDeclaration
    {
        private readonly List<string> memberNames = new List<string>();

        /// <summary>
        /// Gets or sets the parent declaration containing this type declaration.
        /// </summary>
        public TypeDeclaration? Parent { get; set; }

        /// <summary>
        /// Gets or sets the dotnet name of the type.
        /// </summary>
        public string? DotnetTypeName { get; set; }

        /// <summary>
        /// Gets the fully qualified dotnet name of the type.
        /// </summary>
        public string? FullyQualifiedDotNetTypeName
        {
            get
            {
                if (this.DotnetTypeName is null)
                {
                    return null;
                }

                var nameSegments = new List<string>
                {
                    this.DotnetTypeName,
                };

                TypeDeclaration? parent = this.Parent;
                while (parent is TypeDeclaration p)
                {
                    nameSegments.Insert(0, p.DotnetTypeName!);
                    parent = parent.Parent;
                }

                return string.Join('.', nameSegments);
            }
        }

        /// <summary>
        /// Gets or sets the schema from which the type was built.
        /// </summary>
        public LocatedElement TypeSchema { get; set; }

        /// <summary>
        /// Gets or sets the non-optional properties exposed by the type.
        /// </summary>
        public List<PropertyDeclaration>? Properties { get; set; }

        /// <summary>
        /// Gets or sets the list of conversion operators for the type.
        /// </summary>
        public List<ConversionDeclaration>? ConversionOperators { get; set; }

        /// <summary>
        /// Gets or sets the list of explicit AsSomeType() and IsSomeType() validation methods for the type.
        /// </summary>
        public List<AsConversionDeclaration>? AsConversionMethods { get; set; }

        /// <summary>
        /// Gets or sets the list of nested types in this declaration.
        /// </summary>
        public List<TypeDeclaration>? NestedTypes { get; set; }

        /// <summary>
        /// Gets a value which determines whether this type contains a reference to a given type.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration to compare.</param>
        /// <returns><c>true</c> if this object is itself an instance of the type, or if any of its properties are instances of that type.</returns>
        public bool ContainsReferenceTo(TypeDeclaration typeDeclaration)
        {
            if (this == typeDeclaration)
            {
                return true;
            }

            return this.Properties.Any(p => p.TypeDeclaration?.ContainsReferenceTo(typeDeclaration) ?? false);
        }

        /// <summary>
        /// Add a child type declaration to this type.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration to add.</param>
        public void AddTypeDeclaration(TypeDeclaration typeDeclaration)
        {
            this.ValidateMemberName(typeDeclaration.DotnetTypeName);
            this.memberNames.Add(typeDeclaration.DotnetTypeName!);
            this.EnsureNestedTypes().Add(typeDeclaration);
        }

        /// <summary>
        /// Determines if we contain a member matching the given name.
        /// </summary>
        /// <param name="span">The name to match.</param>
        /// <returns>True if we match the name.</returns>
        public bool ContainsMemberNamed(Span<char> span)
        {
            foreach (string name in this.memberNames)
            {
                if (span.SequenceEqual(name))
                {
                    return true;
                }
            }

            return false;
        }

        private List<TypeDeclaration> EnsureNestedTypes()
        {
            return this.NestedTypes ??= new List<TypeDeclaration>();
        }

        private void ValidateMemberName(string? name)
        {
            if (name is null)
            {
                throw new InvalidOperationException($"You must set the name of the member before adding it to its parent.");
            }

            if (this.memberNames.Contains(name))
            {
                throw new InvalidOperationException($"A member with the name {name} already exists in {this.DotnetTypeName}.");
            }
        }
    }
}
