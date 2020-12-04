// <copyright file="JsonSchemaBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeModel
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using Menes.Json;

    /// <summary>
    /// A JSON schema type builder.
    /// </summary>
    public class JsonSchemaBuilder
    {
        private readonly HashSet<TypeDeclaration> typeDeclarations = new HashSet<TypeDeclaration>();
        private readonly Dictionary<string, TypeDeclaration> locatedTypeDeclarations = new Dictionary<string, TypeDeclaration>();
        private readonly JsonWalker walker;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaBuilder"/> class.
        /// </summary>
        /// <param name="walker">The JsonWalker to use.</param>
        public JsonSchemaBuilder(JsonWalker walker)
        {
            this.walker = walker;
            var jsonSchemaWalker = new JsonSchemaWalker();
            jsonSchemaWalker.RegisterWith(this.walker);
        }

        /// <summary>
        /// Builds types for the schema provided by the given reference.
        /// </summary>
        /// <param name="reference">a uri-reference to the schema in which to build the types.</param>
        /// <returns>A <see cref="Task"/> which completes once the types are built.</returns>
        public async Task BuildTypesFor(string reference)
        {
            // First, we resolve the reference and locate our root element.
            LocatedElement rootElement = await this.walker.ResolveReference(new JsonReference(reference), false).ConfigureAwait(false);

            // Then, we build type instances for all the elements we have found
            this.BuildTypeDeclarations();

            // Then we prune the types we aren't actually using
            this.PruneUnreferencedTypes(rootElement.AbsoluteLocation);
        }

        /// <summary>
        /// Build the type declarations that have been found by the walker.
        /// </summary>
        /// <remarks>
        /// This is typically used by builders which use the <see cref="JsonSchemaBuilder"/> in their implementation
        /// but kick off a walk of the JSON tree themselves.
        /// </remarks>
        public void BuildTypeDeclarations()
        {
            foreach (LocatedElement element in this.walker.EnumerateLocatedElements())
            {
                if (element.ContentType == JsonSchemaWalker.Draft201909SchemaContent && new JsonReference(element.AbsoluteLocation).HasAbsoluteUri)
                {
                    this.BuildTypeDeclarationFor(element);
                }
            }
        }

        private void PruneUnreferencedTypes(string rootLocation)
        {
            TypeDeclaration root = this.locatedTypeDeclarations[rootLocation];
            var referencedTypes = new HashSet<TypeDeclaration>();
            this.FindReferencedTypes(root, referencedTypes);
            this.typeDeclarations.IntersectWith(referencedTypes);
        }

        private void FindReferencedTypes(TypeDeclaration currentDeclaration, HashSet<TypeDeclaration> referencedTypes)
        {
            var localTypes = new HashSet<TypeDeclaration>();

            if (currentDeclaration.Schema.AdditionalItems is Draft201909Schema)
            {
                TypeDeclaration typeDeclaration = this.GetTypeDeclarationForProperty(currentDeclaration.Location, "additionalItems");
                this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                localTypes.Add(typeDeclaration);
            }

            if (currentDeclaration.Schema.AdditionalProperties is Draft201909Schema)
            {
                TypeDeclaration typeDeclaration = this.GetTypeDeclarationForProperty(currentDeclaration.Location, "additionalProperties");
                this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                localTypes.Add(typeDeclaration);
            }

            if (currentDeclaration.Schema.AllOf is Draft201909MetaApplicator.ItemsEntity.SchemaArray allOf)
            {
                int index = 0;
                foreach (Draft201909Schema schema in allOf.EnumerateArray())
                {
                    TypeDeclaration typeDeclaration = this.GetTypeDeclarationForPropertyArrayIndex(currentDeclaration.Location, "allOf", index);
                    this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                    localTypes.Add(typeDeclaration);
                    index++;
                }
            }

            if (currentDeclaration.Schema.AnyOf is Draft201909MetaApplicator.ItemsEntity.SchemaArray anyOf)
            {
                int index = 0;
                foreach (Draft201909Schema schema in anyOf.EnumerateArray())
                {
                    TypeDeclaration typeDeclaration = this.GetTypeDeclarationForPropertyArrayIndex(currentDeclaration.Location, "anyOf", index);
                    this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                    localTypes.Add(typeDeclaration);
                    index++;
                }
            }

            if (currentDeclaration.Schema.Contains is Draft201909Schema)
            {
                TypeDeclaration typeDeclaration = this.GetTypeDeclarationForProperty(currentDeclaration.Location, "contains");
                this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                localTypes.Add(typeDeclaration);
            }

            if (currentDeclaration.Schema.ContentSchema is Draft201909Schema)
            {
                TypeDeclaration typeDeclaration = this.GetTypeDeclarationForProperty(currentDeclaration.Location, "contentSchema");
                this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                localTypes.Add(typeDeclaration);
            }

            if (currentDeclaration.Schema.DependentSchemas is Draft201909MetaApplicator.DependentSchemasEntity dependentSchemas)
            {
                foreach (Property<Draft201909MetaApplicator.DependentSchemasEntity> schemaProperty in dependentSchemas.EnumerateObject())
                {
                    TypeDeclaration typeDeclaration = this.GetTypeDeclarationForProperty(new JsonReference(currentDeclaration.Location).AppendUnencodedPropertyNameToFragment("dependentSchemas"), schemaProperty.Name);
                    this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                    localTypes.Add(typeDeclaration);
                }
            }

            if (currentDeclaration.Schema.Else is Draft201909Schema)
            {
                TypeDeclaration typeDeclaration = this.GetTypeDeclarationForProperty(currentDeclaration.Location, "else");
                this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                localTypes.Add(typeDeclaration);
            }

            if (currentDeclaration.Schema.If is Draft201909Schema)
            {
                TypeDeclaration typeDeclaration = this.GetTypeDeclarationForProperty(currentDeclaration.Location, "if");
                this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                localTypes.Add(typeDeclaration);
            }

            if (currentDeclaration.Schema.Items is Draft201909MetaApplicator.ItemsEntity items)
            {
                if (items.IsArray)
                {
                    int index = 0;
                    foreach (Draft201909Schema schema in items.AsSchemaArray().EnumerateArray())
                    {
                        TypeDeclaration typeDeclaration = this.GetTypeDeclarationForPropertyArrayIndex(currentDeclaration.Location, "items", index);
                        this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                        localTypes.Add(typeDeclaration);
                        index++;
                    }
                }
                else
                {
                    TypeDeclaration typeDeclaration = this.GetTypeDeclarationForProperty(currentDeclaration.Location, "items");
                    this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                    localTypes.Add(typeDeclaration);
                }
            }

            if (currentDeclaration.Schema.Not is Draft201909Schema)
            {
                TypeDeclaration typeDeclaration = this.GetTypeDeclarationForProperty(currentDeclaration.Location, "not");
                this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                localTypes.Add(typeDeclaration);
            }

            if (currentDeclaration.Schema.OneOf is Draft201909MetaApplicator.ItemsEntity.SchemaArray oneOf)
            {
                int index = 0;
                foreach (Draft201909Schema schema in oneOf.EnumerateArray())
                {
                    TypeDeclaration typeDeclaration = this.GetTypeDeclarationForPropertyArrayIndex(currentDeclaration.Location, "oneOf", index);
                    this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                    localTypes.Add(typeDeclaration);
                    index++;
                }
            }

            if (currentDeclaration.Schema.PatternProperties is Draft201909MetaApplicator.PatternPropertiesEntity patternProperties)
            {
                foreach (Property<Draft201909MetaApplicator.PatternPropertiesEntity> schemaProperty in patternProperties.EnumerateObject())
                {
                    TypeDeclaration typeDeclaration = this.GetTypeDeclarationForProperty(new JsonReference(currentDeclaration.Location).AppendUnencodedPropertyNameToFragment("patternProperties"), schemaProperty.Name);
                    this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                    localTypes.Add(typeDeclaration);
                }
            }

            if (currentDeclaration.Schema.Properties is Draft201909MetaApplicator.PropertiesEntity properties)
            {
                foreach (Property<Draft201909MetaApplicator.PropertiesEntity> schemaProperty in properties.EnumerateObject())
                {
                    TypeDeclaration typeDeclaration = this.GetTypeDeclarationForProperty(new JsonReference(currentDeclaration.Location).AppendUnencodedPropertyNameToFragment("properties"), schemaProperty.Name);
                    this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                    localTypes.Add(typeDeclaration);
                }
            }

            if (currentDeclaration.Schema.PropertyNames is Draft201909Schema)
            {
                TypeDeclaration typeDeclaration = this.GetTypeDeclarationForProperty(currentDeclaration.Location, "propertyNames");
                this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                localTypes.Add(typeDeclaration);
            }

            if (currentDeclaration.Schema.RecursiveRef is JsonUriReference)
            {
                // If we have a recursive ref, this is being applied in place; naked refs have already been reduced.
                TypeDeclaration typeDeclaration = this.GetTypeDeclarationForProperty(currentDeclaration.Location, "$recursiveRef");
                this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                localTypes.Add(typeDeclaration);
            }

            if (currentDeclaration.Schema.Ref is JsonUriReference)
            {
                // If we have a recursive ref, this is being applied in place; naked refs have already been reduced.
                TypeDeclaration typeDeclaration = this.GetTypeDeclarationForProperty(currentDeclaration.Location, "$ref");
                this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                localTypes.Add(typeDeclaration);
            }

            if (currentDeclaration.Schema.Then is Draft201909Schema)
            {
                TypeDeclaration typeDeclaration = this.GetTypeDeclarationForProperty(currentDeclaration.Location, "then");
                this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                localTypes.Add(typeDeclaration);
            }

            if (currentDeclaration.Schema.UnevaluatedItems is Draft201909Schema)
            {
                TypeDeclaration typeDeclaration = this.GetTypeDeclarationForProperty(currentDeclaration.Location, "unevaluatedItems");
                this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                localTypes.Add(typeDeclaration);
            }

            if (currentDeclaration.Schema.UnevaluatedProperties is Draft201909Schema)
            {
                TypeDeclaration typeDeclaration = this.GetTypeDeclarationForProperty(currentDeclaration.Location, "unevaluatedProperties");
                this.AddTypeDeclarationsToReferencedTypes(referencedTypes, typeDeclaration);
                localTypes.Add(typeDeclaration);
            }

            currentDeclaration.SetReferencedTypes(localTypes);
        }

        private void AddTypeDeclarationsToReferencedTypes(HashSet<TypeDeclaration> referencedTypes, TypeDeclaration typeDeclaration)
        {
            if (!referencedTypes.Contains(typeDeclaration))
            {
                referencedTypes.Add(typeDeclaration);
                this.FindReferencedTypes(typeDeclaration, referencedTypes);
            }
        }

        private TypeDeclaration BuildTypeDeclarationFor(LocatedElement rootElement)
        {
            return this.BuildTypeDeclarationFor(rootElement.AbsoluteLocation, rootElement.Element.As<Draft201909Schema>());
        }

        /// <summary>
        /// Build the type declaration for the given schema.
        /// </summary>
        private TypeDeclaration BuildTypeDeclarationFor(string location, Draft201909Schema draft201909Schema)
        {
            if (this.locatedTypeDeclarations.TryGetValue(location, out TypeDeclaration existingDeclaration))
            {
                return existingDeclaration;
            }

            if (!draft201909Schema.Validate(ValidationContext.ValidContext).IsValid)
            {
                throw new InvalidOperationException("Unable to build types for an invalid schema.");
            }

            if (this.TryReduceSchema(location, draft201909Schema, out TypeDeclaration? reducedTypeDeclaration))
            {
                this.locatedTypeDeclarations.Add(location, reducedTypeDeclaration);
                return reducedTypeDeclaration;
            }

            var result = new TypeDeclaration(location, draft201909Schema);
            this.typeDeclarations.Add(result);
            this.locatedTypeDeclarations.Add(location, result);
            return result;
        }

        private bool TryReduceSchema(string absoluteLocation, Draft201909Schema draft201909Schema, [NotNullWhen(true)] out TypeDeclaration? reducedTypeDeclaration)
        {
            if (draft201909Schema.IsNakedReference() && draft201909Schema.Ref is JsonUriReference reference)
            {
                return this.ReduceSchema(absoluteLocation, out reducedTypeDeclaration, reference);
            }

            if (draft201909Schema.IsNakedRecursiveReference() && draft201909Schema.RecursiveRef is JsonUriReference recursiveReference)
            {
                return this.ReduceSchema(absoluteLocation, out reducedTypeDeclaration, recursiveReference);
            }

            reducedTypeDeclaration = default;
            return false;
        }

        private bool ReduceSchema(string absoluteLocation, out TypeDeclaration? reducedTypeDeclaration, JsonUriReference reference)
        {
            JsonReference currentLocation = new JsonReference(absoluteLocation).Apply(new JsonReference(reference.GetUri().OriginalString));
            if (this.locatedTypeDeclarations.TryGetValue(currentLocation, out TypeDeclaration locatedTypeDeclaration))
            {
                reducedTypeDeclaration = locatedTypeDeclaration;
                return true;
            }

            LocatedElement? locatedElement = this.walker.GetLocatedElement(currentLocation.ToString());
            reducedTypeDeclaration = this.BuildTypeDeclarationFor(locatedElement);
            return true;
        }

        private TypeDeclaration GetTypeDeclarationForPropertyArrayIndex(string location, string propertyName, int arrayIndex)
        {
            JsonReference schemaLocation = new JsonReference(location).AppendUnencodedPropertyNameToFragment(propertyName).AppendArrayIndexToFragment(arrayIndex);
            string resolvedSchemaLocation = this.walker.GetLocatedElement(schemaLocation.ToString()).AbsoluteLocation;
            if (this.locatedTypeDeclarations.TryGetValue(resolvedSchemaLocation, out TypeDeclaration typeDeclaration))
            {
                return typeDeclaration;
            }

            throw new InvalidOperationException($"Unable to find the TypeDeclaration for location '{resolvedSchemaLocation}'");
        }

        private TypeDeclaration GetTypeDeclarationForProperty(string location, string propertyName)
        {
            JsonReference schemaLocation = new JsonReference(location).AppendUnencodedPropertyNameToFragment(propertyName);
            string resolvedSchemaLocation = this.walker.GetLocatedElement(schemaLocation.ToString()).AbsoluteLocation;
            if (this.locatedTypeDeclarations.TryGetValue(resolvedSchemaLocation, out TypeDeclaration typeDeclaration))
            {
                return typeDeclaration;
            }

            throw new InvalidOperationException($"Unable to find the TypeDeclaration for location '{resolvedSchemaLocation}'");
        }
    }
}
