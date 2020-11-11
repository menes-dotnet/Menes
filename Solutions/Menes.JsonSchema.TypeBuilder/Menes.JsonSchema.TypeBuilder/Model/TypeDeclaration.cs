// <copyright file="TypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// A declaration of a type built from schema.
    /// </summary>
    public class TypeDeclaration
    {
        private readonly List<string> memberNames = new List<string>();
        private readonly HashSet<string> jsonPropertyNames = new HashSet<string>();
        private TypeDeclaration? lowered;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeDeclaration"/> class.
        /// </summary>
        /// <param name="typeSchema">The schema element related to the type.</param>
        public TypeDeclaration(LocatedElement typeSchema = default)
        {
            this.TypeSchema = typeSchema;
        }

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
        /// Gets or sets a value indicating whether this is a boolean true type.
        /// </summary>
        public bool IsBooleanTrueType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is a boolean false type.
        /// </summary>
        public bool IsBooleanFalseType { get; set; }

        /// <summary>
        /// Gets or sets the type array for this type declaration.
        /// </summary>
        public List<string>? Type { get; set; }

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
        public List<ConversionOperatorDeclaration>? ConversionOperators { get; private set; }

        /// <summary>
        /// Gets the list of explicit AsSomeType() and IsSomeType() validation methods for the type.
        /// </summary>
        public List<AsConversionMethodDeclaration>? AsConversionMethods { get; private set; }

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
        /// Gets or sets the Not type.
        /// </summary>
        public TypeDeclaration? NotType { get; set; }

        /// <summary>
        /// Gets or sets the If Then and Else types.
        /// </summary>
        public IfThenElse? IfThenElseTypes { get; set; }

        /// <summary>
        /// Gets or sets the additional items type.
        /// </summary>
        public TypeDeclaration? AdditionalItems { get; set; }

        /// <summary>
        /// Gets or sets the additional items type.
        /// </summary>
        public TypeDeclaration? AdditionalProperties { get; set; }

        /// <summary>
        /// Gets a value indicating whether this type allows additional properties.
        /// </summary>
        public bool AllowsAdditionalProperties
        {
            get
            {
                // The only case where we don't allow additional properties
                if (this.AdditionalProperties is not null &&
                    this.AdditionalProperties.IsBooleanFalseType)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is a boolean schema.
        /// </summary>
        public bool IsBooleanSchema => this.IsBooleanFalseType || this.IsBooleanTrueType;

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
                allOfTypes.Add(allOfType);
                this.AddConversionOperator(
                    new ConversionOperatorDeclaration { Conversion = ConversionOperatorDeclaration.ConversionType.GenericAs, ToType = allOfType });
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
                anyOfTypes.Add(anyOfType);
                this.AddConversionOperator(
                    new ConversionOperatorDeclaration { Conversion = ConversionOperatorDeclaration.ConversionType.GenericAs, ToType = anyOfType });
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
                oneOfTypes.Add(oneOfType);
                this.AddConversionOperator(
                    new ConversionOperatorDeclaration { Conversion = ConversionOperatorDeclaration.ConversionType.GenericAs, ToType = oneOfType });
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
                mergedTypes.Add(typeToMerge);
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
            //// TODO - consider recursive definitions here - do we need to break out of this if we see a deeper recursive loop?
            //// I believe we are OK as we have already dealt with that scenario...but we will have to confirm by testing.
            //// (There are existing tests which validate this)

            // Lower the types and work off those
            TypeDeclaration lowered = this.Lower();
            TypeDeclaration loweredOther = other.Lower();

            // If we are the lowered version of this type, just return true
            if (loweredOther == lowered)
            {
                return true;
            }

            // We always specialise the {} type.
            if (loweredOther.IsBooleanTrueType)
            {
                return true;
            }

            // Can never specialise the not type
            if (loweredOther.IsBooleanFalseType)
            {
                return false;
            }

            // Cannot specialize a type if we are not in its types list, or its types list is empty
            if (loweredOther.Type is List<string> otherTypes && loweredOther.Type.Count > 0)
            {
                // We are not more specialized if we are "any"
                if (lowered.Type is null)
                {
                    return false;
                }

                if (lowered.Type.Any(type => !loweredOther.Type.Contains(type)))
                {
                    return false;
                }
            }

            // We can short circuit the longer check, by looking at all of types directly.
            // If we must match this, then we are indeed a specialized version of that
            // type
            if (lowered.AllOfTypes is not null && lowered.AllOfTypes.Contains(loweredOther))
            {
                return true;
            }

            if (loweredOther.AnyOfTypes is not null && loweredOther.AnyOfTypes.Any(t => lowered.Specializes(t)))
            {
                return true;
            }

            if (loweredOther.OneOfTypes is not null && loweredOther.OneOfTypes.Any(t => lowered.Specializes(t)))
            {
                return true;
            }

            // Notice that we have to invert the check for the not type - we are a more specialized version of this if
            // the Not type is a more specialized version of us.
            // Consider if they are Not {} and we are not {type: boolean} - we cannot specialize because they are denying
            // everything and we are denying just booleans so we are more relaxed about the range of values we would support
            // and yet normally {type: boolean} would specialise {} as it is more constrained.
            if (loweredOther.NotType is not null &&
                lowered.NotType is not null &&
                !loweredOther.NotType.Specializes(lowered.NotType))
            {
                return false;
            }

            if (loweredOther.AdditionalItems is not null &&
                lowered.AdditionalItems is not null &&
                !lowered.AdditionalItems.Specializes(loweredOther.AdditionalItems))
            {
                return false;
            }

            if (loweredOther.AdditionalProperties is not null &&
                lowered.AdditionalProperties is not null &&
                !lowered.AdditionalProperties.Specializes(loweredOther.AdditionalProperties))
            {
                return false;
            }

            if (!loweredOther.AllowsAdditionalProperties)
            {
                if (loweredOther.Properties is null || loweredOther.Properties.Count == 0)
                {
                    return lowered.Properties is null || lowered.Properties.Count == 0;
                }

                if (!lowered.AllowsAdditionalProperties)
                {
                    if (lowered.Properties is null || loweredOther.Properties.Count > lowered.Properties.Count)
                    {
                        return false;
                    }
                }
                else
                {
                    if (lowered.Properties is not null && loweredOther.Properties.Count < lowered.Properties.Count)
                    {
                        return false;
                    }
                }
            }

            // So the type allows additional properties, or we have the same number or fewer properties than them
            // so let's check that all of the properties they have are specialized by the properties we have
            // If we see a property we don't have, we return false if we do not allow additional properties.

            // Note that none of lowered guarantees that we will be *valid* if we assign these properties
            // but it does determine whether the schema supports specialising these property values in our
            // composed class.
            if (loweredOther.Properties is null || loweredOther.Properties.Count == 0)
            {
                return true;
            }

            foreach (PropertyDeclaration? property in loweredOther.Properties)
            {
                if (property.JsonPropertyName is null)
                {
                    throw new InvalidOperationException("You must have set the JSON property name on all properties before calling Specializes()");
                }

                if (lowered.TryGetPropertyDeclaration(property.JsonPropertyName, out PropertyDeclaration? ourProperty))
                {
                    if (ourProperty.TypeDeclaration is null)
                    {
                        throw new InvalidOperationException("You must have set the property type on all properties before calling Specializes().");
                    }

                    if (property.TypeDeclaration is null)
                    {
                        throw new InvalidOperationException("You must have set the property type on all properties before calling Specializes()");
                    }

                    if (!ourProperty.TypeDeclaration.Specializes(property.TypeDeclaration))
                    {
                        return false;
                    }
                }
                else
                {
                    // We've found a property in them that we don't have, so we can't specialize lowered type.
                    if (!lowered.AllowsAdditionalProperties)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Collapses the merged type declarations into a single type declaration for use in generation.
        /// </summary>
        /// <returns>The lowered type declaration.</returns>
        public TypeDeclaration Lower()
        {
            if (this.lowered is TypeDeclaration)
            {
                return this.lowered;
            }

            if (this.MergedTypes is null || this.MergedTypes.Count == 0)
            {
                this.lowered = this;
                return this;
            }

            if (this.MergedTypes.Count == 1)
            {
                // If we are empty apart from a single merged type,
                // then treat us as that merged type.
                if (this.AdditionalItems is null &&
                    this.AdditionalProperties is null &&
                    this.AllOfTypes is null &&
                    this.AnyOfTypes is null &&
                    this.AsConversionMethods is null &&
                    this.ConversionOperators is null &&
                    this.IfThenElseTypes is null &&
                    this.NotType is null &&
                    this.OneOfTypes is null &&
                    this.Properties is null &&
                    this.Type is null)
                {
                    // Note that we lose our ref context here, as we are
                    // literally reusing the reffed type, rather than creating
                    // a new type with the ref context.
                    this.lowered = this.MergedTypes[1].Lower();
                    return this.lowered;
                }
            }

            // First - we don't change our type schema; we are still the same type, however we got here...
            // Our typename and the "type" of the item comes from us, and we will still parent into the existing
            // parent type
            var result = new TypeDeclaration(this.TypeSchema)
            {
                DotnetTypeName = this.DotnetTypeName,
                Type = this.Type,
                Parent = this.Parent,
            };

            // Ensure we have set the result early, before we start potentially recursively
            // lowering, so that the lowered result is available to recursive calls.
            this.lowered = result;

            // Lower the types to merge.
            IEnumerable<TypeDeclaration> loweredTypes = this.MergedTypes.Select(m => m.Lower()).ToList();

            // Iterate the types to merge and merge them in
            foreach (TypeDeclaration typeToMerge in loweredTypes)
            {
                MergeTypes(result, typeToMerge);
            }

            // Finally, merge ourselves in at the end.
            MergeTypes(result, this);

            this.lowered = result;
            return this.lowered;
        }

        private static void MergeTypes(TypeDeclaration result, TypeDeclaration typeToMerge)
        {
            MergeAdditionalItems(typeToMerge, result);
            MergeAdditionalProperties(typeToMerge, result);
            MergeAllOfTypes(typeToMerge, result);
            MergeAsConversionMethods(typeToMerge, result);
            MergeAnyOfTypes(typeToMerge, result);
            MergeConversionOperators(typeToMerge, result);
            MergeIfThenElseTypes(typeToMerge, result);
            MergeNotType(typeToMerge, result);
            MergeOneOfTypes(typeToMerge, result);
            MergeProperties(typeToMerge, result);
        }

        private static void MergeConversionOperators(TypeDeclaration typeToMerge, TypeDeclaration result)
        {
            if (typeToMerge.ConversionOperators is null)
            {
                return;
            }

            List<ConversionOperatorDeclaration>? conversionOperators = result.EnsureConversionOperators();
            foreach (ConversionOperatorDeclaration conversion in typeToMerge.ConversionOperators)
            {
                if (!conversionOperators.Any(c => c.ToType == conversion.ToType))
                {
                    conversionOperators.Add(conversion);
                }
            }

            result.ConversionOperators = conversionOperators;
        }

        private static void MergeAsConversionMethods(TypeDeclaration typeToMerge, TypeDeclaration result)
        {
            if (typeToMerge.AsConversionMethods is null)
            {
                return;
            }

            List<AsConversionMethodDeclaration>? conversionMethods = result.EnsureAsConversionMethods();
            foreach (AsConversionMethodDeclaration conversion in typeToMerge.AsConversionMethods)
            {
                if (!conversionMethods.Any(c => c.ToType == conversion.ToType))
                {
                    conversionMethods.Add(conversion);
                }
            }

            result.AsConversionMethods = conversionMethods;
        }

        private static void MergeProperties(TypeDeclaration typeToMerge, TypeDeclaration result)
        {
            if (typeToMerge.Properties is null)
            {
                return;
            }

            List<PropertyDeclaration> properties = result.EnsureProperties();

            foreach (PropertyDeclaration property in typeToMerge.Properties)
            {
                if (property.JsonPropertyName is null)
                {
                    throw new InvalidOperationException("You must set the JsonPropertyName on all properties before calling Lower()");
                }

                if (result.TryGetPropertyDeclaration(property.JsonPropertyName, out PropertyDeclaration? propertyDeclaration))
                {
                    if (property.TypeDeclaration is null)
                    {
                        throw new InvalidOperationException("You must set the TypeDeclaration on all properties before calling Lower()");
                    }

                    if (propertyDeclaration.TypeDeclaration is null)
                    {
                        throw new InvalidOperationException("You must set the TypeDeclaration on all properties before calling Lower()");
                    }

                    if (property.TypeDeclaration.Specializes(propertyDeclaration.TypeDeclaration))
                    {
                        properties.Remove(propertyDeclaration);
                        properties.Add(property);
                    }
                }
                else
                {
                    properties.Add(property);
                }
            }
        }

        private static void MergeNotType(TypeDeclaration typeToMerge, TypeDeclaration result)
        {
            result.NotType = PickMostDerivedTypeWithOptionals(typeToMerge.NotType, result.NotType);
        }

        private static void MergeIfThenElseTypes(TypeDeclaration typeToMerge, TypeDeclaration result)
        {
            if (typeToMerge.IfThenElseTypes is not null)
            {
                if (result.IfThenElseTypes is null)
                {
                    result.IfThenElseTypes = typeToMerge.IfThenElseTypes;
                    return;
                }

                result.IfThenElseTypes = new IfThenElse(
                    PickMostDerivedType(typeToMerge.IfThenElseTypes.If, result.IfThenElseTypes.If),
                    PickMostDerivedTypeWithOptionals(typeToMerge.IfThenElseTypes.Then, result.IfThenElseTypes.Then),
                    PickMostDerivedTypeWithOptionals(typeToMerge.IfThenElseTypes.Else, result.IfThenElseTypes.Else));
            }
        }

        private static TypeDeclaration PickMostDerivedType(TypeDeclaration first, TypeDeclaration second)
        {
            if (first.Specializes(second))
            {
                return first;
            }

            return second;
        }

        private static TypeDeclaration? PickMostDerivedTypeWithOptionals(TypeDeclaration? first, TypeDeclaration? second)
        {
            if (first is null)
            {
                return second;
            }

            if (second is null)
            {
                return first;
            }

            if (first.Specializes(second))
            {
                return first;
            }

            return second;
        }

        private static void MergeAllOfTypes(TypeDeclaration typeToMerge, TypeDeclaration result)
        {
            if (typeToMerge.AllOfTypes is not null)
            {
                List<TypeDeclaration> resultTypes = result.EnsureAllOfTypes();

                foreach (TypeDeclaration type in typeToMerge.AllOfTypes)
                {
                    if (type != result && !resultTypes.Contains(type))
                    {
                        resultTypes.Add(type);
                    }
                }

                result.AllOfTypes = resultTypes;
            }
        }

        private static void MergeAnyOfTypes(TypeDeclaration typeToMerge, TypeDeclaration result)
        {
            if (typeToMerge.AnyOfTypes is not null)
            {
                List<TypeDeclaration> resultTypes = result.EnsureAnyOfTypes();

                foreach (TypeDeclaration type in typeToMerge.AnyOfTypes)
                {
                    if (type != result && !resultTypes.Contains(type))
                    {
                        resultTypes.Add(type);
                    }
                }

                result.AnyOfTypes = resultTypes;
            }
        }

        private static void MergeOneOfTypes(TypeDeclaration typeToMerge, TypeDeclaration result)
        {
            if (typeToMerge.OneOfTypes is not null)
            {
                List<TypeDeclaration> resultTypes = result.EnsureOneOfTypes();

                foreach (TypeDeclaration type in typeToMerge.OneOfTypes)
                {
                    if (type != result && !resultTypes.Contains(type))
                    {
                        resultTypes.Add(type);
                    }
                }

                result.OneOfTypes = resultTypes;
            }
        }

        private static void MergeAdditionalProperties(TypeDeclaration typeToMerge, TypeDeclaration result)
        {
            result.AdditionalProperties = PickMostDerivedTypeWithOptionals(typeToMerge.AdditionalProperties, result.AdditionalProperties);
        }

        private static void MergeAdditionalItems(TypeDeclaration typeToMerge, TypeDeclaration result)
        {
            result.AdditionalItems = PickMostDerivedTypeWithOptionals(typeToMerge.AdditionalItems, result.AdditionalItems);
        }

        private void AddConversionOperator(ConversionOperatorDeclaration conversionDeclaration)
        {
            List<ConversionOperatorDeclaration> conversionOperators = this.EnsureConversionOperators();
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

        private List<ConversionOperatorDeclaration> EnsureConversionOperators()
        {
            return this.ConversionOperators ??= new List<ConversionOperatorDeclaration>();
        }

        private List<AsConversionMethodDeclaration> EnsureAsConversionMethods()
        {
            return this.AsConversionMethods ??= new List<AsConversionMethodDeclaration>();
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
