// <copyright file="TypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text.Json;

    /// <summary>
    /// A declaration of a type built from schema.
    /// </summary>
    [DebuggerDisplay("{FullyQualifiedDotNetTypeName}")]
    public class TypeDeclaration
    {
        private readonly List<string> memberNames = new List<string>();
        private readonly HashSet<string> jsonPropertyNames = new HashSet<string>();
        private TypeDeclaration? lowered;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeDeclaration"/> class.
        /// </summary>
        /// <param name="typeSchema">The schema element related to the type.</param>
        /// <param name="builtInType">Determines whether this is a built-in type.</param>
        public TypeDeclaration(LocatedElement typeSchema = default, bool builtInType = false)
        {
            this.TypeSchema = typeSchema;
            this.IsBuiltInType = builtInType;
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
        /// Gets a value indicating whether this is a lowered reference type.
        /// </summary>
        /// <remarks>
        /// If <c>true</c> you will not need to generate this instance of the type, but just use
        /// its type name.
        /// </remarks>
        public bool IsRef { get; private set; }

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
        /// Gets a value indicating whether this is a built-in type or not.
        /// </summary>
        /// <remarks>
        /// Built-in types do not need generation, and may not be decorated.
        /// </remarks>
        public bool IsBuiltInType { get; }

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
        public List<TypeDeclaration>? EmbeddedTypes { get; private set; }

        /// <summary>
        /// Gets the list of merged types in this declaration.
        /// </summary>
        /// <remarks>These will have been merged as a result of compounding property types through an <c>allOf</c> declaration, or an array-based <c>type</c> property.</remarks>
        public List<TypeDeclaration>? MergedTypes { get; private set; }

        /// <summary>
        /// Gets the list of types that form a oneOf set.
        /// </summary>
        public List<TypeDeclaration>? AnyOf { get; private set; }

        /// <summary>
        /// Gets the list of types that form a oneOf set.
        /// </summary>
        public List<TypeDeclaration>? OneOf { get; private set; }

        /// <summary>
        /// Gets the list of types that form an allOf set.
        /// </summary>
        public List<TypeDeclaration>? AllOf { get; private set; }

        /// <summary>
        /// Gets or sets the Not type.
        /// </summary>
        public TypeDeclaration? Not { get; set; }

        /// <summary>
        /// Gets or sets the UnevaluatedProperties type.
        /// </summary>
        public TypeDeclaration? UnevaluatedProperties { get; set; }

        /// <summary>
        /// Gets or sets the propertyNames type.
        /// </summary>
        public TypeDeclaration? PropertyNames { get; set; }

        /// <summary>
        /// Gets or sets the If Then and Else types.
        /// </summary>
        public IfThenElse? IfThenElse { get; set; }

        /// <summary>
        /// Gets or sets the items type.
        /// </summary>
        public List<TypeDeclaration>? Items { get; set; }

        /// <summary>
        /// Gets or sets the additional items type.
        /// </summary>
        public TypeDeclaration? AdditionalItems { get; set; }

        /// <summary>
        /// Gets or sets the unevaluated items type.
        /// </summary>
        public TypeDeclaration? UnevaluatedItems { get; set; }

        /// <summary>
        /// Gets or sets the contains type.
        /// </summary>
        public TypeDeclaration? Contains { get; set; }

        /// <summary>
        /// Gets or sets the additional items type.
        /// </summary>
        public TypeDeclaration? AdditionalProperties { get; set; }

        /// <summary>
        /// Gets or sets the pattern properties.
        /// </summary>
        public List<PatternProperty>? PatternProperties { get; set; }

        /// <summary>
        /// Gets or sets the dependent schemas.
        /// </summary>
        public List<DependentSchema>? DependentSchemas { get; set; }

        /// <summary>
        /// Gets or sets an enum value.
        /// </summary>
        public List<JsonElement>? Enum { get; set; }

        /// <summary>
        /// Gets or sets a constant value.
        /// </summary>
        public JsonElement? Const { get; set; }

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

                return this.IsObjectTypeDeclaration;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is a boolean schema.
        /// </summary>
        public bool IsBooleanSchema => this.IsBooleanFalseType || this.IsBooleanTrueType;

        /// <summary>
        /// Gets a value indicating whether this type has been lowered.
        /// </summary>
        public bool IsLowered { get; private set; }

        /// <summary>
        /// Gets the fully lowered version of this type and its entire graph.
        /// </summary>
        public TypeDeclaration Lowered
        {
            get
            {
                TypeDeclaration current = this.Lower();
                while (current.lowered != null && current != current.lowered)
                {
                    current = current.lowered;
                }

                return current;
            }
        }

        /// <summary>
        /// Gets or sets the pattern for a string value.
        /// </summary>
        public string? Pattern { get; set; }

        /// <summary>
        /// Gets or sets the maximum length of a string.
        /// </summary>
        public int? MaxLength { get; set; }

        /// <summary>
        /// Gets or sets the minimum length of a string.
        /// </summary>
        public int? MinLength { get; set; }

        /// <summary>
        /// Gets or sets the multiple-of numeric validation.
        /// </summary>
        public double? MultipleOf { get; set; }

        /// <summary>
        /// Gets or sets the maximum numeric validation.
        /// </summary>
        public double? Maximum { get; set; }

        /// <summary>
        /// Gets or sets the exclusive maximum numeric validation.
        /// </summary>
        public double? ExclusiveMaximum { get; set; }

        /// <summary>
        /// Gets or sets the minimum numeric validation.
        /// </summary>
        public double? Minimum { get; set; }

        /// <summary>
        /// Gets or sets the exclusive minimum numeric validation.
        /// </summary>
        public double? ExclusiveMinimum { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of items in the array.
        /// </summary>
        public int? MaxItems { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of items in the array.
        /// </summary>
        public int? MinItems { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the items in the array should be unique.
        /// </summary>
        public bool? UniqueItems { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of items in the array that match the contains type.
        /// </summary>
        public int? MaxContains { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of items in the array that match the contains type.
        /// </summary>
        public int? MinContains { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of properties in the object.
        /// </summary>
        public int? MaxProperties { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of properties in the object.
        /// </summary>
        public int? MinProperties { get; set; }

        /// <summary>
        /// Gets or sets the set of dependent required properties in the object.
        /// </summary>
        public Dictionary<string, List<string>>? DependentRequired { get; set; }

        /// <summary>
        /// Gets a value indicating whether this is an object-type declaration.
        /// </summary>
        public bool IsObjectTypeDeclaration => (this.Type is not null && this.Type.Contains("object")) || this.AdditionalProperties is not null || this.DependentRequired is not null || this.DependentSchemas is not null || this.MaxProperties is not null || this.MinProperties is not null || this.PatternProperties is not null || this.Properties is not null || this.PropertyNames is not null || this.UnevaluatedProperties is not null;

        /// <summary>
        /// Gets a value indicating whether this is an array-type declaration.
        /// </summary>
        public bool IsArrayTypeDeclaration => (this.Type is not null && this.Type.Contains("array")) || this.AdditionalItems is not null || this.Items is not null || this.UnevaluatedItems is not null || this.Contains is not null || this.MaxContains is not null || this.MaxItems is not null || this.MinContains is not null || this.MinItems is not null || this.UniqueItems is not null;

        /// <summary>
        /// Gets or sets the type format.
        /// </summary>
        public string? Format { get; set; }

        /// <summary>
        /// Add a conversion operator.
        /// </summary>
        /// <param name="conversionOperatorDeclaration">The operator to add.</param>
        /// <remarks>
        /// This will not add a conversion operator if it already existing in the type.
        /// </remarks>
        public void AddConversionOperator(ConversionOperatorDeclaration conversionOperatorDeclaration)
        {
            List<ConversionOperatorDeclaration> operators = this.EnsureConversionOperators();

            if (operators.Any(o => o.TargetType?.FullyQualifiedDotNetTypeName == conversionOperatorDeclaration.TargetType?.FullyQualifiedDotNetTypeName))
            {
                return;
            }

            operators.Add(conversionOperatorDeclaration);
        }

        /// <summary>
        /// Add a pattern property to the collection.
        /// </summary>
        /// <param name="patternProperty">The pattern property to add.</param>
        public void AddPatternProperty(PatternProperty patternProperty)
        {
            this.EnsurePatternProperties().Add(patternProperty);
        }

        /// <summary>
        /// Add a dependent schema to the collection.
        /// </summary>
        /// <param name="dependentSchema">The dependent schema to add.</param>
        public void AddDependentSchema(DependentSchema dependentSchema)
        {
            this.EnsureDependentSchemas().Add(dependentSchema);
        }

        /// <summary>
        /// Gets a value which determines whether this type contains a reference to a given type.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration to compare.</param>
        /// <param name="typeNamesVisited">The types we've already visited in this inspection.</param>
        /// <returns><c>true</c> if this object is itself an instance of the type, or if any of its properties are instances of that type.</returns>
        public bool ContainsReferenceTo(TypeDeclaration typeDeclaration, List<string>? typeNamesVisited = null)
        {
            if (this.FullyQualifiedDotNetTypeName is null)
            {
                throw new InvalidOperationException("You must set the DotNetTypeName before calling ContainsReferenceTo().");
            }

            if (typeNamesVisited is null)
            {
                typeNamesVisited = new List<string>();
            }
            else if (typeNamesVisited.Contains(this.FullyQualifiedDotNetTypeName))
            {
                return false;
            }

            typeNamesVisited.Add(this.FullyQualifiedDotNetTypeName);

            if (this.FullyQualifiedDotNetTypeName == typeDeclaration.FullyQualifiedDotNetTypeName)
            {
                return true;
            }

            return (this.Properties is not null && this.Properties.Any(p => p.TypeDeclaration?.ContainsReferenceTo(typeDeclaration, typeNamesVisited) ?? false)) ||
                (this.Items is not null && this.Items.Any(i => i.ContainsReferenceTo(typeDeclaration, typeNamesVisited))) ||
                (this.AnyOf is not null && this.AnyOf.Any(ao => ao.ContainsReferenceTo(typeDeclaration, typeNamesVisited))) ||
                (this.OneOf is not null && this.OneOf.Any(oo => oo.ContainsReferenceTo(typeDeclaration, typeNamesVisited)));
        }

        /// <summary>
        /// Add a child type declaration to this type.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration to add.</param>
        public void AddEmbeddedTypeDeclaration(TypeDeclaration typeDeclaration)
        {
            this.ValidateMemberName(typeDeclaration.DotnetTypeName);
            this.memberNames.Add(typeDeclaration.DotnetTypeName!);
            this.EnsureEmbeddedTypes().Add(typeDeclaration);
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
            this.memberNames.Add(propertyDeclaration.DotnetFieldName!);
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
            if (!allOfTypes.Any(t => t.FullyQualifiedDotNetTypeName == allOfType.FullyQualifiedDotNetTypeName))
            {
                allOfTypes.Add(allOfType);
                this.AddConversionOperatorsFor(allOfType);
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
            if (!anyOfTypes.Any(t => t.FullyQualifiedDotNetTypeName == anyOfType.FullyQualifiedDotNetTypeName))
            {
                anyOfTypes.Add(anyOfType);
                this.AddConversionOperatorsFor(anyOfType);
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
            if (!oneOfTypes.Any(t => t.FullyQualifiedDotNetTypeName == oneOfType.FullyQualifiedDotNetTypeName))
            {
                oneOfTypes.Add(oneOfType);
                this.AddConversionOperatorsFor(oneOfType);
            }
        }

        /// <summary>
        /// Adds a dependency to the dependent required list, if not already present.
        /// </summary>
        /// <param name="key">The key for the dependency.</param>
        /// <param name="value">The value of the dependency.</param>
        public void AddDependentRequired(string key, string value)
        {
            Dictionary<string, List<string>> dr = this.EnsureDependentRequired();
            if (!dr.TryGetValue(key, out List<string> required))
            {
                required = new List<string>();
                dr.Add(key, required);
            }

            if (!required.Contains(value))
            {
                required.Add(value);
            }
        }

        /// <summary>
        /// Add the item to the items list.
        /// </summary>
        /// <param name="itemsDeclaration">The items declaration to add.</param>
        public void AddItem(TypeDeclaration itemsDeclaration)
        {
            List<TypeDeclaration> items = this.EnsureItems();
            items.Add(itemsDeclaration);
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
            if (!mergedTypes.Any(t => t.FullyQualifiedDotNetTypeName == typeToMerge.FullyQualifiedDotNetTypeName))
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
            // Lower the types and work off those
            TypeDeclaration lowered = this.Lowered;
            TypeDeclaration loweredOther = other.Lowered;

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
            if (lowered.AllOf is not null && lowered.AllOf.Any(t => t.FullyQualifiedDotNetTypeName == loweredOther.FullyQualifiedDotNetTypeName))
            {
                return true;
            }

            if (loweredOther.AnyOf is not null && loweredOther.AnyOf.Any(t => lowered.Specializes(t)))
            {
                return true;
            }

            if (loweredOther.OneOf is not null && loweredOther.OneOf.Any(t => lowered.Specializes(t)))
            {
                return true;
            }

            // Notice that we have to invert the check for the not type - we are a more specialized version of this if
            // the Not type is a more specialized version of us.
            // Consider if they are Not {} and we are not {type: boolean} - we cannot specialize because they are denying
            // everything and we are denying just booleans so we are more relaxed about the range of values we would support
            // and yet normally {type: boolean} would specialise {} as it is more constrained.
            if (loweredOther.Not is not null &&
                lowered.Not is not null &&
                !loweredOther.Not.Specializes(lowered.Not))
            {
                return false;
            }

            if (loweredOther.AdditionalItems is not null &&
                lowered.AdditionalItems is not null &&
                !lowered.AdditionalItems.Specializes(loweredOther.AdditionalItems))
            {
                return false;
            }

            if (loweredOther.UnevaluatedItems is not null &&
                lowered.UnevaluatedItems is not null &&
                !lowered.UnevaluatedItems.Specializes(loweredOther.UnevaluatedItems))
            {
                return false;
            }

            if (loweredOther.UnevaluatedProperties is not null &&
                lowered.UnevaluatedProperties is not null &&
                !lowered.UnevaluatedProperties.Specializes(loweredOther.UnevaluatedProperties))
            {
                return false;
            }

            if (loweredOther.Contains is not null &&
                lowered.Contains is not null &&
                !lowered.Contains.Specializes(loweredOther.Contains))
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

        private static void MergeEmbeddedTypes(TypeDeclaration baseType, TypeDeclaration result)
        {
            if (baseType.EmbeddedTypes is null)
            {
                return;
            }

            List<TypeDeclaration> types = result.EnsureEmbeddedTypes();
            foreach (TypeDeclaration type in baseType.EmbeddedTypes)
            {
                TypeDeclaration lowered = type.Lowered;
                if (lowered.Parent?.FullyQualifiedDotNetTypeName == result.FullyQualifiedDotNetTypeName && !types.Any(t => t.FullyQualifiedDotNetTypeName == lowered.FullyQualifiedDotNetTypeName))
                {
                    types.Add(lowered);
                }
            }
        }

        private static void MergeItems(List<TypeDeclaration>? items, TypeDeclaration result)
        {
            if (items is null)
            {
                return;
            }

            List<TypeDeclaration> resultItems = result.EnsureItems();

            foreach (TypeDeclaration item in items)
            {
                if (!resultItems.Any(i => i.FullyQualifiedDotNetTypeName == item.FullyQualifiedDotNetTypeName))
                {
                    resultItems.Add(item);
                }
            }
        }

        /// <summary>
        /// Lowers and merges all the validations.
        /// </summary>
        /// <remarks>
        /// This is used to merge the base type's conversion methods into the target type when
        /// merging multiple types together.
        /// </remarks>
        private static void MergeConversions(TypeDeclaration typeToMerge, TypeDeclaration result)
        {
            MergeAsConversionMethods(Lower(typeToMerge.AsConversionMethods), result);
            MergeConversionOperators(Lower(typeToMerge.ConversionOperators), result);
            MergeChildConversionOperators(typeToMerge, result);
        }

        private static void MergeChildConversionOperators(TypeDeclaration typeToMerge, TypeDeclaration result)
        {
            TypeDeclaration lowered = typeToMerge.Lowered;
            if (lowered.AnyOf is not null)
            {
                foreach (TypeDeclaration targetType in lowered.AnyOf)
                {
                    AddChildConversionOperators(result, targetType);
                }
            }

            if (lowered.OneOf is not null)
            {
                foreach (TypeDeclaration targetType in lowered.OneOf)
                {
                    AddChildConversionOperators(result, targetType);
                }
            }
        }

        private static void AddChildConversionOperators(TypeDeclaration result, TypeDeclaration targetType)
        {
            if (targetType.ConversionOperators is List<ConversionOperatorDeclaration> childOperators)
            {
                // Add conversion operators for the child operator via the target type
                foreach (ConversionOperatorDeclaration childOperator in childOperators)
                {
                    result.AddConversionOperator(
                        new ConversionOperatorDeclaration
                        {
                            Conversion = ConversionOperatorDeclaration.ConversionType.Cast,
                            Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                            TargetType = childOperator.TargetType,
                            Via = targetType,
                        });
                }
            }
        }

        /// <summary>
        /// Merge the const and enum values.
        /// </summary>
        /// <remarks>
        /// We merge const and enum down the stack, overwriting in order, so that
        /// we can present a sensible set of values if we have one from an allOf
        /// type we are composing in.
        /// </remarks>
        private static void MergeConstAndEnum(TypeDeclaration typeToMerge, TypeDeclaration result)
        {
            if (typeToMerge.Const is not null)
            {
                result.Const = typeToMerge.Const;
            }

            if (typeToMerge.Enum is not null)
            {
                result.Enum = typeToMerge.Enum;
            }
        }

        /// <summary>
        /// Lowers and merges all the validations.
        /// </summary>
        /// <remarks>
        /// This is used to merge the base type's validations into the target type when
        /// merging multiple types together. It is not used for the types being merged into
        /// the base, as their validation is carried out by calling their own <see cref="IJsonValue.Validate"/> method.
        /// in order to maintain the keyword location stack correctly.
        /// </remarks>
        private static void MergeValidations(TypeDeclaration typeToMerge, TypeDeclaration result)
        {
            MergeAdditionalItems(typeToMerge.AdditionalItems?.Lowered, result);
            MergeUnevaluatedItems(typeToMerge.UnevaluatedItems?.Lowered, result);
            MergeContains(typeToMerge.Contains?.Lowered, result);

            MergeIfThenElse(Lower(typeToMerge.IfThenElse), result);
            MergeNot(typeToMerge.Not?.Lowered, result);
            MergeAllOf(Lower(typeToMerge.AllOf), result);
            MergeAnyOf(Lower(typeToMerge.AnyOf), result);
            MergeOneOf(Lower(typeToMerge.OneOf), result);
            MergeDependentSchemas(typeToMerge.DependentSchemas, result);

            MergeDependentRequired(typeToMerge, result);
            MergeUnevaluatedProperties(typeToMerge.UnevaluatedProperties?.Lowered, result);
            MergeAdditionalProperties(typeToMerge.AdditionalProperties?.Lowered, result);
            MergePatternProperties(typeToMerge.PatternProperties, result);
            MergePropertyNames(typeToMerge.PropertyNames, result);

            if (typeToMerge.ExclusiveMaximum is not null)
            {
                result.ExclusiveMaximum = typeToMerge.ExclusiveMaximum;
            }

            if (typeToMerge.ExclusiveMinimum is not null)
            {
                result.ExclusiveMinimum = typeToMerge.ExclusiveMinimum;
            }

            if (typeToMerge.MaxContains is not null)
            {
                result.MaxContains = typeToMerge.MaxContains;
            }

            if (typeToMerge.Maximum is not null)
            {
                result.Maximum = typeToMerge.Maximum;
            }

            if (typeToMerge.MaxItems is not null)
            {
                result.MaxItems = typeToMerge.MaxItems;
            }

            if (typeToMerge.MaxLength is not null)
            {
                result.MaxLength = typeToMerge.MaxLength;
            }

            if (typeToMerge.MaxProperties is not null)
            {
                result.MaxProperties = typeToMerge.MaxProperties;
            }

            if (typeToMerge.MinContains is not null)
            {
                result.MinContains = typeToMerge.MinContains;
            }

            if (typeToMerge.Minimum is not null)
            {
                result.Minimum = typeToMerge.Minimum;
            }

            if (typeToMerge.MinItems is not null)
            {
                result.MinItems = typeToMerge.MinItems;
            }

            if (typeToMerge.MinLength is not null)
            {
                result.MinLength = typeToMerge.MinLength;
            }

            if (typeToMerge.MinProperties is not null)
            {
                result.MinProperties = typeToMerge.MinProperties;
            }

            if (typeToMerge.MultipleOf is not null)
            {
                result.MultipleOf = typeToMerge.MultipleOf;
            }

            if (typeToMerge.Pattern is not null)
            {
                result.Pattern = typeToMerge.Pattern;
            }

            if (typeToMerge.UniqueItems is not null)
            {
                result.UniqueItems = typeToMerge.UniqueItems;
            }
        }

        private static void MergePatternProperties(List<PatternProperty>? patternProperties, TypeDeclaration result)
        {
            if (patternProperties is null)
            {
                return;
            }

            List<PatternProperty> resultProperties = result.EnsurePatternProperties();

            foreach (PatternProperty property in patternProperties)
            {
                resultProperties.Add(new PatternProperty(property.Pattern, property.Schema.Lowered));
            }
        }

        private static void MergeDependentSchemas(List<DependentSchema>? dependentSchemas, TypeDeclaration result)
        {
            if (dependentSchemas is null)
            {
                return;
            }

            List<DependentSchema> resultProperties = result.EnsureDependentSchemas();

            foreach (DependentSchema property in dependentSchemas)
            {
                resultProperties.Add(new DependentSchema(property.PropertyName, property.Schema.Lowered));
            }
        }

        private static void MergeTypesToBase(TypeDeclaration result, TypeDeclaration typeToMerge)
        {
            MergeAllOf(typeToMerge.AllOf, result);
            MergeAnyOf(typeToMerge.AnyOf, result);
            MergeOneOf(typeToMerge.OneOf, result);
            MergeProperties(typeToMerge.Properties, result);
            MergeItems(typeToMerge.Items, result);
            MergeConstAndEnum(typeToMerge, result);

            // Note that we don't merge validations on the merged types
            // These will be dealt with by running the validations of the actual allOf, anyOf, oneOf
            // types. This must be done in order to ensure that the keyword context is maintained correctly.

            // We also don't merge conversion methods as these are dealt with when the types are added to the
            // allOf, oneOf, anyOf properties using the 'Vias'
        }

        private static void MergeDependentRequired(TypeDeclaration typeToMerge, TypeDeclaration result)
        {
            if (typeToMerge.DependentRequired is null)
            {
                return;
            }

            if (result.DependentRequired is null)
            {
                result.DependentRequired = typeToMerge.DependentRequired;
                return;
            }

            foreach (KeyValuePair<string, List<string>> entry in typeToMerge.DependentRequired)
            {
                if (result.DependentRequired.TryGetValue(entry.Key, out List<string> resultList))
                {
                    foreach (string item in entry.Value)
                    {
                        if (!resultList.Contains(item))
                        {
                            resultList.Add(item);
                        }
                    }
                }
                else
                {
                    typeToMerge.DependentRequired.Add(entry.Key, entry.Value);
                }
            }
        }

        private static IfThenElse? Lower(IfThenElse? ifThenElseTypes)
        {
            if (ifThenElseTypes is null ||
               (ifThenElseTypes.If.IsLowered &&
               (ifThenElseTypes.Then?.IsLowered ?? true) &&
               (ifThenElseTypes.Else?.IsLowered ?? true)))
            {
                return ifThenElseTypes;
            }

            return new IfThenElse(ifThenElseTypes.If.Lowered, ifThenElseTypes.Then?.Lowered, ifThenElseTypes.Else?.Lowered);
        }

        private static List<PropertyDeclaration>? Lower(List<PropertyDeclaration>? properties)
        {
            return properties?.Select(p => (p.TypeDeclaration?.IsLowered ?? true) ? p : new PropertyDeclaration { DotnetFieldName = p.DotnetFieldName, DotnetPropertyName = p.DotnetPropertyName, IsRequired = p.IsRequired, JsonPropertyName = p.JsonPropertyName, TypeDeclaration = p.TypeDeclaration?.Lowered }).ToList();
        }

        private static List<ConversionOperatorDeclaration>? Lower(List<ConversionOperatorDeclaration>? conversionOperators)
        {
            return conversionOperators?.Select(c => new ConversionOperatorDeclaration { Conversion = c.Conversion, TargetType = c.TargetType?.Lowered, Direction = c.Direction, Via = c.Via }).ToList();
        }

        private static List<AsConversionMethodDeclaration>? Lower(List<AsConversionMethodDeclaration>? asConversionMethods)
        {
            return asConversionMethods?.Select(c => new AsConversionMethodDeclaration { Conversion = c.Conversion, Direction = c.Direction, DotnetMethodTypeSuffix = c.DotnetMethodTypeSuffix, TargetType = c.TargetType?.Lowered, Via = c.Via }).ToList();
        }

        [return: NotNullIfNotNull("typeDeclarations")]
        private static List<TypeDeclaration>? Lower(List<TypeDeclaration>? typeDeclarations)
        {
            return typeDeclarations?.Select(t => t.Lowered).ToList();
        }

        private static void MergeConversionOperators(List<ConversionOperatorDeclaration>? conversionOperatorsToMerge, TypeDeclaration result)
        {
            if (conversionOperatorsToMerge is null)
            {
                return;
            }

            List<ConversionOperatorDeclaration>? conversionOperators = result.EnsureConversionOperators();
            foreach (ConversionOperatorDeclaration conversion in conversionOperatorsToMerge)
            {
                if (!conversionOperators.Any(c => c.TargetType == conversion.TargetType))
                {
                    conversionOperators.Add(conversion);
                }
            }

            result.ConversionOperators = conversionOperators;
        }

        private static void MergeAsConversionMethods(List<AsConversionMethodDeclaration>? asConversionMethodsToMerge, TypeDeclaration result)
        {
            if (asConversionMethodsToMerge is null)
            {
                return;
            }

            List<AsConversionMethodDeclaration>? conversionMethods = result.EnsureAsConversionMethods();
            foreach (AsConversionMethodDeclaration conversion in asConversionMethodsToMerge)
            {
                if (!conversionMethods.Any(c => c.TargetType == conversion.TargetType))
                {
                    conversionMethods.Add(conversion);
                }
            }

            result.AsConversionMethods = conversionMethods;
        }

        private static void MergeProperties(List<PropertyDeclaration>? propertiesToMerge, TypeDeclaration result)
        {
            if (propertiesToMerge is null)
            {
                return;
            }

            List<PropertyDeclaration> properties = result.EnsureProperties();

            foreach (PropertyDeclaration property in propertiesToMerge)
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

        private static void MergeNot(TypeDeclaration? typeToMerge, TypeDeclaration result)
        {
            result.Not = PickMostDerivedTypeWithOptionals(typeToMerge, result.Not);
        }

        private static void MergeUnevaluatedProperties(TypeDeclaration? typeToMerge, TypeDeclaration result)
        {
            result.UnevaluatedProperties = PickMostDerivedTypeWithOptionals(typeToMerge, result.UnevaluatedProperties);
        }

        private static void MergePropertyNames(TypeDeclaration? typeToMerge, TypeDeclaration result)
        {
            result.PropertyNames = PickMostDerivedTypeWithOptionals(typeToMerge, result.PropertyNames);
        }

        private static void MergeIfThenElse(IfThenElse? typeToMerge, TypeDeclaration result)
        {
            if (typeToMerge is not null)
            {
                if (result.IfThenElse is null)
                {
                    result.IfThenElse = typeToMerge;
                    return;
                }

                result.IfThenElse = new IfThenElse(
                    PickMostDerivedType(typeToMerge.If, result.IfThenElse.If),
                    PickMostDerivedTypeWithOptionals(typeToMerge.Then, result.IfThenElse.Then),
                    PickMostDerivedTypeWithOptionals(typeToMerge.Else, result.IfThenElse.Else));
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

        private static void MergeAllOf(List<TypeDeclaration>? allOfTypes, TypeDeclaration result)
        {
            if (allOfTypes is not null)
            {
                List<TypeDeclaration> resultTypes = result.EnsureAllOfTypes();

                foreach (TypeDeclaration type in allOfTypes)
                {
                    if (type != result && !resultTypes.Any(t => t.FullyQualifiedDotNetTypeName == type.FullyQualifiedDotNetTypeName))
                    {
                        resultTypes.Add(type);
                    }
                }

                result.AllOf = resultTypes;
            }
        }

        private static void MergeAnyOf(List<TypeDeclaration>? anyOfTypes, TypeDeclaration result)
        {
            if (anyOfTypes is not null)
            {
                List<TypeDeclaration> resultTypes = result.EnsureAnyOfTypes();

                foreach (TypeDeclaration type in anyOfTypes)
                {
                    if (type != result && !resultTypes.Any(t => t.FullyQualifiedDotNetTypeName == type.FullyQualifiedDotNetTypeName))
                    {
                        resultTypes.Add(type);
                    }
                }

                result.AnyOf = resultTypes;
            }
        }

        private static void MergeOneOf(List<TypeDeclaration>? oneOfTypes, TypeDeclaration result)
        {
            if (oneOfTypes is not null)
            {
                List<TypeDeclaration> resultTypes = result.EnsureOneOfTypes();

                foreach (TypeDeclaration type in oneOfTypes)
                {
                    if (type != result && !resultTypes.Any(t => t.FullyQualifiedDotNetTypeName == type.FullyQualifiedDotNetTypeName))
                    {
                        resultTypes.Add(type);
                    }
                }

                result.OneOf = resultTypes;
            }
        }

        private static void MergeAdditionalProperties(TypeDeclaration? additionalProperties, TypeDeclaration result)
        {
            result.AdditionalProperties = PickMostDerivedTypeWithOptionals(additionalProperties, result.AdditionalProperties);
        }

        private static void MergeAdditionalItems(TypeDeclaration? additionalItems, TypeDeclaration result)
        {
            result.AdditionalItems = PickMostDerivedTypeWithOptionals(additionalItems, result.AdditionalItems);
        }

        private static void MergeUnevaluatedItems(TypeDeclaration? unevaluatedItems, TypeDeclaration result)
        {
            result.UnevaluatedItems = PickMostDerivedTypeWithOptionals(unevaluatedItems, result.UnevaluatedItems);
        }

        private static void MergeContains(TypeDeclaration? contains, TypeDeclaration result)
        {
            result.Contains = PickMostDerivedTypeWithOptionals(contains, result.Contains);
        }

        /// <summary>
        /// Collapses the merged type declarations into a single type declaration for use in generation.
        /// </summary>
        /// <returns>The lowered type declaration.</returns>
        private TypeDeclaration Lower()
        {
            if (this.lowered is TypeDeclaration)
            {
                return this.lowered;
            }

            if (this.IsNakedType() && this.Type?.Count == 1)
            {
                string nakedType = this.Type[0];
                if (nakedType != "object" && nakedType != "array")
                {
                    // If we are empty apart from a single merged type, that is a naked type of a non-compound kind
                    this.lowered = TypeDeclarations.GetTypeFor(nakedType, this.Format);

                    return this.lowered;
                }
            }

            // First - we don't change our type schema; we are still the same type, however we got here...
            // Our typename and the "type" of the item comes from us, and we will still parent into the existing
            // parent type
            var result = new TypeDeclaration(this.TypeSchema, this.IsBuiltInType)
            {
                DotnetTypeName = this.DotnetTypeName,
                Type = this.Type,
                Parent = this.Parent,
                IsLowered = true,
            };

            // Move back up our lowered stack looking for an unreferenced parent to which to add ourselves
            while (result.Parent is not null && result.Parent.IsNakedReference())
            {
                result.Parent = result.Parent.Parent;
            }

            TypeDeclaration baseType = this;

            // Ensure we have set the result early, before we start potentially recursively
            // lowering, so that the lowered result is available to recursive calls.
            this.lowered = result;

            if (this.MergedTypes is List<TypeDeclaration> mergedTypes)
            {
                if (mergedTypes.Count == 1 && this.IsNakedReference())
                {
                    // If we are empty apart from a single merged type, that is a reference to another type
                    // then treat us as that merged type.
                    this.lowered = mergedTypes[0].Lowered;

                    return this.lowered;
                }
                else
                {
                    List<TypeDeclaration>? lowered = Lower(mergedTypes);

                    // Iterate the types to merge and merge them in
                    foreach (TypeDeclaration typeToMerge in lowered!)
                    {
                        MergeTypesToBase(result, typeToMerge);
                    }
                }
            }

            // Then merge in our own base type to the target.
            MergeItems(Lower(baseType.Items), result);
            MergeProperties(Lower(baseType.Properties), result);
            MergeValidations(baseType, result);
            MergeConversions(baseType, result);
            MergeConstAndEnum(baseType, result);
            MergeEmbeddedTypes(baseType, result);
            return this.lowered;
        }

        private bool IsNakedReference()
        {
            return this.AdditionalItems is null &&
                   this.AdditionalProperties is null &&
                   this.AllOf is null &&
                   this.AnyOf is null &&
                   this.AsConversionMethods is null &&
                   this.Const is null &&
                   this.Contains is null &&
                   this.ConversionOperators is null &&
                   this.DependentRequired is null &&
                   this.Enum is null &&
                   this.ExclusiveMaximum is null &&
                   this.ExclusiveMinimum is null &&
                   this.Format is null &&
                   this.IfThenElse is null &&
                   this.Items is null &&
                   this.MaxContains is null &&
                   this.Maximum is null &&
                   this.MaxItems is null &&
                   this.MaxLength is null &&
                   this.MaxProperties is null &&
                   this.MinContains is null &&
                   this.Minimum is null &&
                   this.MinItems is null &&
                   this.MinLength is null &&
                   this.MinProperties is null &&
                   this.MultipleOf is null &&
                   this.Not is null &&
                   this.OneOf is null &&
                   this.Pattern is null &&
                   this.PatternProperties is null &&
                   this.DependentSchemas is null &&
                   this.Properties is null &&
                   this.PropertyNames is null &&
                   this.Type is null &&
                   this.UnevaluatedItems is null &&
                   this.UnevaluatedProperties is null &&
                   this.UniqueItems is null;
        }

        private bool IsNakedType()
        {
            return
                   !this.IsRef &&
                   this.AdditionalItems is null &&
                   this.AdditionalProperties is null &&
                   this.AllOf is null &&
                   this.AnyOf is null &&
                   this.Const is null &&
                   this.Contains is null &&
                   this.DependentRequired is null &&
                   this.Enum is null &&
                   this.ExclusiveMaximum is null &&
                   this.ExclusiveMinimum is null &&
                   this.IfThenElse is null &&
                   this.Items is null &&
                   this.MaxContains is null &&
                   this.Maximum is null &&
                   this.MaxItems is null &&
                   this.MaxLength is null &&
                   this.MaxProperties is null &&
                   this.MinContains is null &&
                   this.Minimum is null &&
                   this.MinItems is null &&
                   this.MinLength is null &&
                   this.MinProperties is null &&
                   this.MultipleOf is null &&
                   this.Not is null &&
                   this.OneOf is null &&
                   this.Pattern is null &&
                   this.PatternProperties is null &&
                   this.DependentSchemas is null &&
                   this.Properties is null &&
                   this.PropertyNames is null &&
                   this.UnevaluatedItems is null &&
                   this.UnevaluatedProperties is null &&
                   this.UniqueItems is null;
        }

        private void AddAsConversionMethod(AsConversionMethodDeclaration asConversionMethodDeclaration)
        {
            List<AsConversionMethodDeclaration> conversionOperators = this.EnsureAsConversionMethods();
            conversionOperators.Add(asConversionMethodDeclaration);
        }

        private void AddConversionOperatorsFor(TypeDeclaration targetType)
        {
            // Add implicit bidirectional conversion from the all/any/oneOf type.
            this.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = targetType,
                });

            // Add an As{Typename} method
            this.AddAsConversionMethod(
                new AsConversionMethodDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    TargetType = targetType,
                });
        }

        private List<TypeDeclaration> EnsureMergedTypes()
        {
            return this.MergedTypes ??= new List<TypeDeclaration>();
        }

        private List<TypeDeclaration> EnsureAnyOfTypes()
        {
            return this.AnyOf ??= new List<TypeDeclaration>();
        }

        private List<PatternProperty> EnsurePatternProperties()
        {
            return this.PatternProperties ??= new List<PatternProperty>();
        }

        private List<DependentSchema> EnsureDependentSchemas()
        {
            return this.DependentSchemas ??= new List<DependentSchema>();
        }

        private List<TypeDeclaration> EnsureOneOfTypes()
        {
            return this.OneOf ??= new List<TypeDeclaration>();
        }

        private List<TypeDeclaration> EnsureAllOfTypes()
        {
            return this.AllOf ??= new List<TypeDeclaration>();
        }

        private List<TypeDeclaration> EnsureEmbeddedTypes()
        {
            return this.EmbeddedTypes ??= new List<TypeDeclaration>();
        }

        private List<PropertyDeclaration> EnsureProperties()
        {
            return this.Properties ??= new List<PropertyDeclaration>();
        }

        private List<TypeDeclaration> EnsureItems()
        {
            return this.Items ??= new List<TypeDeclaration>();
        }

        private List<ConversionOperatorDeclaration> EnsureConversionOperators()
        {
            return this.ConversionOperators ??= new List<ConversionOperatorDeclaration>();
        }

        private List<AsConversionMethodDeclaration> EnsureAsConversionMethods()
        {
            return this.AsConversionMethods ??= new List<AsConversionMethodDeclaration>();
        }

        private Dictionary<string, List<string>> EnsureDependentRequired()
        {
            return this.DependentRequired ??= new Dictionary<string, List<string>>();
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
