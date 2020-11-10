// <copyright file="TypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// A declaration of a type built from schema.
    /// </summary>
    public class TypeDeclaration
    {
        private readonly List<string> memberNames = new List<string>();
        private readonly HashSet<string> jsonPropertyNames = new HashSet<string>();

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
        /// Gets the non-optional properties exposed by the type.
        /// </summary>
        public List<PropertyDeclaration>? Properties { get; private set; }

        /// <summary>
        /// Gets the list of conversion operators for the type.
        /// </summary>
        public List<ConversionDeclaration>? ConversionOperators { get; private set; }

        /// <summary>
        /// Gets the list of explicit AsSomeType() and IsSomeType() validation methods for the type.
        /// </summary>
        public List<AsConversionDeclaration>? AsConversionMethods { get; private set; }

        /// <summary>
        /// Gets the list of nested types in this declaration.
        /// </summary>
        public List<TypeDeclaration>? NestedTypes { get; private set; }

        /// <summary>
        /// Gets the list of merged types in this declaration.
        /// </summary>
        /// <remarks>These will have been merged as a result of compounding property types through an <c>allOf</c> declaration, or an array-based <c>type</c> property.</remarks>
        public List<TypeDeclaration>? MergedTypes { get; private set; }

        /// <summary>
        /// Gets the list of types that form a oneOf set.
        /// </summary>
        public List<TypeDeclaration>? AnyOfTypes { get; private set; }

        /// <summary>
        /// Gets the list of types that form a oneOf set.
        /// </summary>
        public List<TypeDeclaration>? OneOfTypes { get; private set; }

        /// <summary>
        /// Gets the list of types that form an allOf set.
        /// </summary>
        public List<TypeDeclaration>? AllOfTypes { get; private set; }

        /// <summary>
        /// Gets the Not type.
        /// </summary>
        public TypeDeclaration? NotType { get; private set; }

        /// <summary>
        /// Gets the Not type.
        /// </summary>
        public IfThenElse? IfThenElseTypes { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this type allows additional properties.
        /// </summary>
        public bool AllowsAdditionalProperties { get; set; } = true;

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
        /// Add a property declaration to this type.
        /// </summary>
        /// <param name="propertyDeclaration">The property declaration to add.</param>
        public void AddPropertyDeclaration(PropertyDeclaration propertyDeclaration)
        {
            this.ValidateMemberName(propertyDeclaration.DotnetPropertyName);
            this.jsonPropertyNames.Add(propertyDeclaration.JsonPropertyName!);
            this.memberNames.Add(propertyDeclaration.DotnetPropertyName!);
            this.EnsureProperties().Add(propertyDeclaration);
        }

        /// <summary>
        /// Determines if we contain a member matching the given name.
        /// </summary>
        /// <param name="span">The name to match.</param>
        /// <returns>True if we match the name.</returns>
        public bool ContainsMemberName(Span<char> span)
        {
            foreach (string name in this.memberNames)
            {
                if (span.SequenceEqual(name.AsSpan()))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Merge the given type declartion into this type.
        /// </summary>
        /// <param name="allOfType">Add the given allOf type declaration into this type.</param>
        /// <remarks>
        /// The all of type will be merged with this type, and added to the allOf list for validation.
        /// </remarks>
        public void AddAllOfType(TypeDeclaration allOfType)
        {
            this.Merge(allOfType);
            List<TypeDeclaration> allOfTypes = this.EnsureAllOfTypes();
            if (!allOfTypes.Contains(allOfType))
            {
                allOfTypes.Insert(0, allOfType);
            }
        }

        /// <summary>
        /// Merge the given type declartion into this type.
        /// </summary>
        /// <param name="anyOfType">Add the given anyOf type declaration into this type.</param>
        /// <remarks>
        /// The all of type will not be merged with this type, but is added to the anyOf list for validation.
        /// </remarks>
        public void AddAnyOfType(TypeDeclaration anyOfType)
        {
            List<TypeDeclaration> anyOfTypes = this.EnsureAnyOfTypes();
            if (!anyOfTypes.Contains(anyOfType))
            {
                anyOfTypes.Insert(0, anyOfType);
                this.AddConversionOperator(
                    new ConversionDeclaration { Conversion = ConversionDeclaration.ConversionType.GenericAs, ToTypeName = anyOfType.FullyQualifiedDotNetTypeName });
            }
        }

        /// <summary>
        /// Merge the given type declartion into this type.
        /// </summary>
        /// <param name="oneOfType">Add the given oneOf type declaration into this type.</param>
        /// <remarks>
        /// The all of type will not be merged with this type, but is added to the oneOf list for validation.
        /// </remarks>
        public void AddOneOfType(TypeDeclaration oneOfType)
        {
            List<TypeDeclaration> oneOfTypes = this.EnsureOneOfTypes();
            if (!oneOfTypes.Contains(oneOfType))
            {
                oneOfTypes.Insert(0, oneOfType);
            }
        }

        /// <summary>
        /// Merge the given type declartion into this type.
        /// </summary>
        /// <param name="typeToMerge">Merge the given type declaration into this type.</param>
        /// <remarks>
        /// The order in which you merge types is important.
        /// </remarks>
        public void Merge(TypeDeclaration typeToMerge)
        {
            List<TypeDeclaration> mergedTypes = this.EnsureMergedTypes();
            if (!mergedTypes.Contains(typeToMerge))
            {
                mergedTypes.Insert(0, typeToMerge);
            }
        }

        /// <summary>
        /// Try to get the property declaration with the given JSON property name.
        /// </summary>
        /// <param name="jsonPropertyName">The JSON property name of the property.</param>
        /// <param name="propertyDeclaration">The property declaration.</param>
        /// <returns><c>true</c> if the type declaration contained a property with the specified name.</returns>
        public bool TryGetPropertyDeclaration(string jsonPropertyName, [NotNullWhen(true)] out PropertyDeclaration? propertyDeclaration)
        {
            if (this.Properties is null)
            {
                propertyDeclaration = default;
                return false;
            }

            foreach (PropertyDeclaration property in this.Properties)
            {
                if (property.JsonPropertyName == jsonPropertyName)
                {
                    propertyDeclaration = property;
                    return true;
                }
            }

            propertyDeclaration = default;
            return false;
        }

        /// <summary>
        /// Determines whether the type contains at least one JSON property
        /// of the given name.
        /// </summary>
        /// <param name="name">The JSON property name to check.</param>
        /// <returns><c>True</c> if there is at least one property declared with that JSON property name.</returns>
        public bool ContainsJsonProperty(string name)
        {
            return this.jsonPropertyNames.Contains(name);
        }

        /// <summary>
        /// Returns true if this type specializes the other type declaration.
        /// </summary>
        /// <param name="other">The other type delaration.</param>
        /// <returns><c>true</c> if this type represents a more constrained version of the other type.</returns>
        public bool Specializes(TypeDeclaration other)
        {
            // We can short circuit the longer check, by looking at all of types directly.
            // If we must match this, then we are indeed a specialized version of that
            if (this.EnsureAllOfTypes().Contains(other))
            {
                return true;
            }

            // The other merged types are more interesting. We are a specialized version of that type if
            // either we don't declare any additional properties, or if it allows additional properties.
            foreach (TypeDeclaration type in this.EnsureMergedTypes())
            {
                if (!type.AllowsAdditionalProperties)
                {
                    if (type.EnsureProperties().Count != this.EnsureProperties().Count)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void AddConversionOperator(ConversionDeclaration conversionDeclaration)
        {
            List<ConversionDeclaration> conversionOperators = this.EnsureConversionOperators();
            conversionOperators.Add(conversionDeclaration);
        }

        private List<TypeDeclaration> EnsureMergedTypes()
        {
            return this.MergedTypes ??= new List<TypeDeclaration>();
        }

        private List<TypeDeclaration> EnsureAnyOfTypes()
        {
            return this.AnyOfTypes ??= new List<TypeDeclaration>();
        }

        private List<TypeDeclaration> EnsureOneOfTypes()
        {
            return this.OneOfTypes ??= new List<TypeDeclaration>();
        }

        private List<TypeDeclaration> EnsureAllOfTypes()
        {
            return this.AllOfTypes ??= new List<TypeDeclaration>();
        }

        private List<TypeDeclaration> EnsureNestedTypes()
        {
            return this.NestedTypes ??= new List<TypeDeclaration>();
        }

        private List<PropertyDeclaration> EnsureProperties()
        {
            return this.Properties ??= new List<PropertyDeclaration>();
        }

        private List<ConversionDeclaration> EnsureConversionOperators()
        {
            return this.ConversionOperators ??= new List<ConversionDeclaration>();
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
