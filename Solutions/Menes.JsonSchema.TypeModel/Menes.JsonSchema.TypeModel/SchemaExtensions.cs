﻿// <copyright file="SchemaExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeModel
{
    /// <summary>
    /// Extension methods for Draft201909-related schema types.
    /// </summary>
    public static class SchemaExtensions
    {
        /// <summary>
        /// Determines if this schema is empty of known items, but contains unknown extensions.
        /// </summary>
        /// <param name="draft201909Schema">The schema to test.</param>
        /// <returns><c>True</c> if all the known items are empty, but there are additional properties on the JsonElement.</returns>
        public static bool EmptyButWithUnknownExtensions(this Draft201909Schema draft201909Schema)
        {
            return draft201909Schema.IsObject && IsEmpty(draft201909Schema) && draft201909Schema.EnumerateObject().MoveNext();
        }

        /// <summary>
        /// Determines if this schema is a simple type.
        /// </summary>
        /// <param name="draft201909Schema">The schema to test.</param>
        /// <returns><c>True</c> if the schema has a single type value, or no type value but a format value.</returns>
        public static bool IsExplicitArrayType(this Draft201909Schema draft201909Schema)
        {
            return
                draft201909Schema.Type is Draft201909MetaValidation.TypeEntity type && type.IsString && type == Draft201909MetaValidation.TypeEntity.SimpleTypesEntity.EnumValues.Array;
        }

        /// <summary>
        /// Determines if this schema is a simple type.
        /// </summary>
        /// <param name="draft201909Schema">The schema to test.</param>
        /// <returns><c>True</c> if the schema has a single type value, or no type value but a format value.</returns>
        public static bool IsSimpleType(this Draft201909Schema draft201909Schema)
        {
            return
                (draft201909Schema.Type is Draft201909MetaValidation.TypeEntity type && type.Is<Draft201909MetaValidation.TypeEntity.SimpleTypesEntity>()) ||
                (draft201909Schema.Type is null && draft201909Schema.Format is not null);
        }

        /// <summary>
        /// Determines if this schema is empty of non-extension items.
        /// </summary>
        /// <param name="draft201909Schema">The schema to test.</param>
        /// <returns><c>True</c> if all the non-extension items are empty.</returns>
        public static bool IsBuiltInType(this Draft201909Schema draft201909Schema)
        {
            return
                draft201909Schema.IsBoolean ||
                draft201909Schema.IsEmpty() ||
                (draft201909Schema.IsSimpleType() &&
                draft201909Schema.AdditionalItems is null &&
                draft201909Schema.AdditionalProperties is null &&
                draft201909Schema.AllOf is null &&
                draft201909Schema.Anchor is null &&
                draft201909Schema.AnyOf is null &&
                draft201909Schema.Const is null &&
                draft201909Schema.Contains is null &&
                draft201909Schema.ContentEncoding is null &&
                draft201909Schema.ContentMediaType is null &&
                draft201909Schema.ContentSchema is null &&
                draft201909Schema.Default is null &&
                draft201909Schema.Dependencies is null &&
                draft201909Schema.DependentRequired is null &&
                draft201909Schema.DependentSchemas is null &&
                draft201909Schema.Else is null &&
                draft201909Schema.Enum is null &&
                draft201909Schema.ExclusiveMaximum is null &&
                draft201909Schema.ExclusiveMinimum is null &&
                draft201909Schema.If is null &&
                draft201909Schema.Items is null &&
                draft201909Schema.MaxContains is null &&
                draft201909Schema.Maximum is null &&
                draft201909Schema.MaxItems is null &&
                draft201909Schema.MaxLength is null &&
                draft201909Schema.MaxProperties is null &&
                draft201909Schema.MinContains is null &&
                draft201909Schema.Minimum is null &&
                draft201909Schema.MinItems is null &&
                draft201909Schema.MinLength is null &&
                draft201909Schema.MinProperties is null &&
                draft201909Schema.MultipleOf is null &&
                draft201909Schema.Not is null &&
                draft201909Schema.OneOf is null &&
                draft201909Schema.Pattern is null &&
                draft201909Schema.PatternProperties is null &&
                draft201909Schema.Properties is null &&
                draft201909Schema.PropertyNames is null &&
                draft201909Schema.ReadOnly is null &&
                draft201909Schema.RecursiveAnchor is null &&
                draft201909Schema.RecursiveRef is null &&
                draft201909Schema.Ref is null &&
                draft201909Schema.Required is null &&
                draft201909Schema.Then is null &&
                draft201909Schema.UnevaluatedItems is null &&
                draft201909Schema.UnevaluatedProperties is null &&
                draft201909Schema.UniqueItems is null &&
                draft201909Schema.WriteOnly is null);
        }

        /// <summary>
        /// Determines if this schema is empty of non-extension items.
        /// </summary>
        /// <param name="draft201909Schema">The schema to test.</param>
        /// <returns><c>True</c> if all the non-extension items are empty.</returns>
        public static bool IsEmpty(this Draft201909Schema draft201909Schema)
        {
            return
                draft201909Schema.Comment is null &&
                draft201909Schema.AdditionalItems is null &&
                draft201909Schema.AdditionalProperties is null &&
                draft201909Schema.AllOf is null &&
                draft201909Schema.Anchor is null &&
                draft201909Schema.AnyOf is null &&
                draft201909Schema.Const is null &&
                draft201909Schema.Contains is null &&
                draft201909Schema.ContentEncoding is null &&
                draft201909Schema.ContentMediaType is null &&
                draft201909Schema.ContentSchema is null &&
                draft201909Schema.Default is null &&
                draft201909Schema.Definitions is null &&
                draft201909Schema.Defs is null &&
                draft201909Schema.Deprecated is null &&
                draft201909Schema.Dependencies is null &&
                draft201909Schema.DependentRequired is null &&
                draft201909Schema.DependentSchemas is null &&
                draft201909Schema.Description is null &&
                draft201909Schema.Examples is null &&
                draft201909Schema.Else is null &&
                draft201909Schema.Enum is null &&
                draft201909Schema.ExclusiveMaximum is null &&
                draft201909Schema.ExclusiveMinimum is null &&
                draft201909Schema.Format is null &&
                draft201909Schema.If is null &&
                draft201909Schema.Items is null &&
                draft201909Schema.MaxContains is null &&
                draft201909Schema.Maximum is null &&
                draft201909Schema.MaxItems is null &&
                draft201909Schema.MaxLength is null &&
                draft201909Schema.MaxProperties is null &&
                draft201909Schema.MinContains is null &&
                draft201909Schema.Minimum is null &&
                draft201909Schema.MinItems is null &&
                draft201909Schema.MinLength is null &&
                draft201909Schema.MinProperties is null &&
                draft201909Schema.MultipleOf is null &&
                draft201909Schema.Not is null &&
                draft201909Schema.OneOf is null &&
                draft201909Schema.Pattern is null &&
                draft201909Schema.PatternProperties is null &&
                draft201909Schema.Properties is null &&
                draft201909Schema.PropertyNames is null &&
                draft201909Schema.ReadOnly is null &&
                draft201909Schema.RecursiveAnchor is null &&
                draft201909Schema.RecursiveRef is null &&
                draft201909Schema.Ref is null &&
                draft201909Schema.Required is null &&
                draft201909Schema.Then is null &&
                draft201909Schema.Title is null &&
                draft201909Schema.Type is null &&
                draft201909Schema.UnevaluatedItems is null &&
                draft201909Schema.UnevaluatedProperties is null &&
                draft201909Schema.UniqueItems is null &&
                draft201909Schema.WriteOnly is null;
        }

        /// <summary>
        /// Determines if this schema is a naked reference.
        /// </summary>
        /// <param name="draft201909Schema">The schema to test.</param>
        /// <returns><c>True</c> if the schema has a $ref and no other substantive properties.</returns>
        public static bool IsNakedReference(this Draft201909Schema draft201909Schema)
        {
            return
                draft201909Schema.Ref is not null &&
                draft201909Schema.AdditionalItems is null &&
                draft201909Schema.AdditionalProperties is null &&
                draft201909Schema.AllOf is null &&
                draft201909Schema.Anchor is null &&
                draft201909Schema.AnyOf is null &&
                draft201909Schema.Const is null &&
                draft201909Schema.Contains is null &&
                draft201909Schema.ContentEncoding is null &&
                draft201909Schema.ContentMediaType is null &&
                draft201909Schema.ContentSchema is null &&
                draft201909Schema.Default is null &&
                draft201909Schema.Dependencies is null &&
                draft201909Schema.DependentRequired is null &&
                draft201909Schema.DependentSchemas is null &&
                draft201909Schema.Else is null &&
                draft201909Schema.Enum is null &&
                draft201909Schema.ExclusiveMaximum is null &&
                draft201909Schema.ExclusiveMinimum is null &&
                draft201909Schema.Format is null &&
                draft201909Schema.If is null &&
                draft201909Schema.Items is null &&
                draft201909Schema.MaxContains is null &&
                draft201909Schema.Maximum is null &&
                draft201909Schema.MaxItems is null &&
                draft201909Schema.MaxLength is null &&
                draft201909Schema.MaxProperties is null &&
                draft201909Schema.MinContains is null &&
                draft201909Schema.Minimum is null &&
                draft201909Schema.MinItems is null &&
                draft201909Schema.MinLength is null &&
                draft201909Schema.MinProperties is null &&
                draft201909Schema.MultipleOf is null &&
                draft201909Schema.Not is null &&
                draft201909Schema.OneOf is null &&
                draft201909Schema.Pattern is null &&
                draft201909Schema.PatternProperties is null &&
                draft201909Schema.Properties is null &&
                draft201909Schema.PropertyNames is null &&
                draft201909Schema.ReadOnly is null &&
                draft201909Schema.RecursiveRef is null &&
                draft201909Schema.Required is null &&
                draft201909Schema.Then is null &&
                draft201909Schema.Type is null &&
                draft201909Schema.UnevaluatedItems is null &&
                draft201909Schema.UnevaluatedProperties is null &&
                draft201909Schema.UniqueItems is null &&
                draft201909Schema.WriteOnly is null;
        }

        /// <summary>
        /// Determines if this schema is a naked recursive reference.
        /// </summary>
        /// <param name="draft201909Schema">The schema to test.</param>
        /// <returns><c>True</c> if the schema has a $recursiveRef and no other substantive properties.</returns>
        public static bool IsNakedRecursiveReference(this Draft201909Schema draft201909Schema)
        {
            return
                draft201909Schema.RecursiveRef is not null &&
                draft201909Schema.AdditionalItems is null &&
                draft201909Schema.AdditionalProperties is null &&
                draft201909Schema.AllOf is null &&
                draft201909Schema.Anchor is null &&
                draft201909Schema.AnyOf is null &&
                draft201909Schema.Const is null &&
                draft201909Schema.Contains is null &&
                draft201909Schema.ContentEncoding is null &&
                draft201909Schema.ContentMediaType is null &&
                draft201909Schema.ContentSchema is null &&
                draft201909Schema.Default is null &&
                draft201909Schema.Dependencies is null &&
                draft201909Schema.DependentRequired is null &&
                draft201909Schema.DependentSchemas is null &&
                draft201909Schema.Else is null &&
                draft201909Schema.Enum is null &&
                draft201909Schema.ExclusiveMaximum is null &&
                draft201909Schema.ExclusiveMinimum is null &&
                draft201909Schema.Format is null &&
                draft201909Schema.If is null &&
                draft201909Schema.Items is null &&
                draft201909Schema.MaxContains is null &&
                draft201909Schema.Maximum is null &&
                draft201909Schema.MaxItems is null &&
                draft201909Schema.MaxLength is null &&
                draft201909Schema.MaxProperties is null &&
                draft201909Schema.MinContains is null &&
                draft201909Schema.Minimum is null &&
                draft201909Schema.MinItems is null &&
                draft201909Schema.MinLength is null &&
                draft201909Schema.MinProperties is null &&
                draft201909Schema.MultipleOf is null &&
                draft201909Schema.Not is null &&
                draft201909Schema.OneOf is null &&
                draft201909Schema.Pattern is null &&
                draft201909Schema.PatternProperties is null &&
                draft201909Schema.Properties is null &&
                draft201909Schema.PropertyNames is null &&
                draft201909Schema.ReadOnly is null &&
                draft201909Schema.Ref is null &&
                draft201909Schema.Required is null &&
                draft201909Schema.Then is null &&
                draft201909Schema.Type is null &&
                draft201909Schema.UnevaluatedItems is null &&
                draft201909Schema.UnevaluatedProperties is null &&
                draft201909Schema.UniqueItems is null &&
                draft201909Schema.WriteOnly is null;
        }
    }
}
