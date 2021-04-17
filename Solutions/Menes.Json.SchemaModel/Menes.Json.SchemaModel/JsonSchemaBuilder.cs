// <copyright file="JsonSchemaBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
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
        /// Rebases a reference to an artificial root document.
        /// </summary>
        /// <param name="reference">The reference to rebase as a root document.</param>
        /// <returns>A <see cref="Task{TResult}"/> which, when complete, provides the artificial reference of the root document.</returns>
        public async Task<string> RebaseReferenceAsRootDocument(string reference)
        {
            return await this.walker.RebaseReferenceAsRootDocument(reference);
        }

        /// <summary>
        /// Builds types for the schema provided by the given reference.
        /// </summary>
        /// <param name="reference">a uri-reference to the schema in which to build the types.</param>
        /// <param name="rootNamespace">The root namespace to use for types.</param>
        /// <param name="rebase">Rebase the root reference as if it were a root document.</param>
        /// <param name="baseUriToNamespaceMap">A map of base URIs to namespaces to use for specific types.</param>
        /// <returns>A <see cref="Task"/> which completes once the types are built. The tuple provides the root type name, and the generated types.</returns>
        public async Task<(string rootType, ImmutableDictionary<string, (string, string)> generatedTypes)> BuildTypesFor(string reference, string rootNamespace, bool rebase = false, Dictionary<string, string>? baseUriToNamespaceMap = null)
        {
            // First, we resolve the reference and locate our root element.
            LocatedElement? rootElement = await this.walker.ResolveReference(new JsonReference(reference), false).ConfigureAwait(false);

            await this.walker.ResolveUnresolvedReferences();

            if (rootElement is null)
            {
                throw new ArgumentException($"Unable to find a schema at location: {reference}", nameof(reference));
            }

            // Then, we build type instances for all the elements we have found
            string rootLocation = this.BuildTypeDeclarations(rootElement);

            // Then we prune the types we aren't actually using
            Dictionary<string, TypeDeclaration> referencedTypesByLocation = this.PruneUnreferencedTypes(rootLocation);

            // Then prune the built-in types (setting their dotnet type names appropriately)
            Dictionary<string, TypeDeclaration> typesForGenerationByLocation = this.PruneBuiltInTypes(referencedTypesByLocation);

            // Now we are going to populate the types we have built with information that cannot be derived locally from the schema.
            // And set the parents for the remaining types that we are going to generate.
            this.SetParents(typesForGenerationByLocation);

            // Once the parents are set, we can build names for our types.
            this.SetNames(typesForGenerationByLocation, rootNamespace, baseUriToNamespaceMap);

            // Now, find and add all our properties.
            this.FindProperties(typesForGenerationByLocation, referencedTypesByLocation);

            string rootTypeName = this.locatedTypeDeclarations[rootLocation].FullyQualifiedDotnetTypeName!;
            return (
                rootTypeName,
                typesForGenerationByLocation.Where(t => t.Value.Parent is null).Select(
                    typeForGeneration =>
                    {
                        var template = new SchemaEntity(this, typeForGeneration.Value);
                        return (typeForGeneration.Key, (typeForGeneration.Value.DotnetTypeName!, template.TransformText()));
                    }).ToImmutableDictionary(i => i.Key, i => i.Item2));
        }

        /// <summary>
        /// Build the type declarations that have been found by the walker.
        /// </summary>
        /// <param name="rootElement">The root element.</param>
        /// <returns>The absolute location of the root element, as transformed using the $id.</returns>
        /// <remarks>
        /// This is typically used by builders which use the <see cref="JsonSchemaBuilder"/> in their implementation
        /// but kick off a walk of the JSON tree themselves.
        /// </remarks>
        public string BuildTypeDeclarations(LocatedElement rootElement)
        {
            string result = string.Empty;

            foreach (LocatedElement element in this.walker.EnumerateLocatedElements())
            {
                if (element.ContentType == JsonSchemaWalker.Draft201909SchemaContent && new JsonReference(element.AbsoluteLocation).HasAbsoluteUri)
                {
                    TypeDeclaration declaration = this.BuildTypeDeclarationFor(element);
                    if (element.AbsoluteLocation == rootElement.AbsoluteLocation)
                    {
                        result = declaration.Location;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the type declaration for a property of a type.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration.</param>
        /// <param name="property">The property that provides a schema.</param>
        /// <returns>The given type declaration.</returns>
        public TypeDeclaration GetTypeDeclarationForProperty(TypeDeclaration typeDeclaration, string property)
        {
            return this.GetTypeDeclarationForProperty(typeDeclaration.Location, property);
        }

        /// <summary>
        /// Gets the type declaration for a property of a type.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration.</param>
        /// <param name="patternProperty">The pattern property that provides a schema.</param>
        /// <returns>The given type declaration.</returns>
        public TypeDeclaration GetTypeDeclarationForPatternProperty(TypeDeclaration typeDeclaration, string patternProperty)
        {
            return this.GetTypeDeclarationForProperty(new JsonReference(typeDeclaration.Location).AppendUnencodedPropertyNameToFragment("patternProperties"), patternProperty);
        }

        /// <summary>
        /// Gets the type declaration for a dependent of a type.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration.</param>
        /// <param name="dependentSchema">The dependent schema that provides a schema.</param>
        /// <returns>The given type declaration.</returns>
        public TypeDeclaration GetTypeDeclarationForDependentSchema(TypeDeclaration typeDeclaration, string dependentSchema)
        {
            return this.GetTypeDeclarationForProperty(new JsonReference(typeDeclaration.Location).AppendUnencodedPropertyNameToFragment("dependentSchemas"), dependentSchema);
        }

        /// <summary>
        /// Gets the type declaration for a schema array property at a given index.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration.</param>
        /// <param name="property">The property that provides a schema.</param>
        /// <param name="index">The index of the schema in the array.</param>
        /// <returns>The given type declaration.</returns>
        public TypeDeclaration GetTypeDeclarationForPropertyArrayIndex(TypeDeclaration typeDeclaration, string property, int index)
        {
            return this.GetTypeDeclarationForPropertyArrayIndex(typeDeclaration.Location, property, index);
        }

        private Dictionary<string, TypeDeclaration> PruneUnreferencedTypes(string rootLocation)
        {
            TypeDeclaration root = this.locatedTypeDeclarations[rootLocation];
            var referencedTypes = new HashSet<TypeDeclaration>();
            this.FindReferencedTypes(root, referencedTypes);
            referencedTypes.Add(root);
            return referencedTypes.ToDictionary(k => k.Location);
        }

        private void FindReferencedTypes(TypeDeclaration currentDeclaration, HashSet<TypeDeclaration> referencedTypes)
        {
            var localTypes = new HashSet<TypeDeclaration>();

            this.FindReferencedTypesCore(currentDeclaration, referencedTypes, localTypes);
            currentDeclaration.SetReferencedTypes(localTypes);

            var inspectedTypes = localTypes.ToHashSet();

            var currentTypes = localTypes.ToList();

            while (currentTypes.Any())
            {
                localTypes.Clear();
                foreach (TypeDeclaration type in currentTypes)
                {
                    inspectedTypes.Add(type);
                    this.FindReferencedTypesCore(type, referencedTypes, localTypes);
                }

                currentTypes = localTypes.Except(inspectedTypes).ToList();
            }
        }

        private void FindReferencedTypesCore(TypeDeclaration currentDeclaration, HashSet<TypeDeclaration> referencedTypes, HashSet<TypeDeclaration> localTypes)
        {
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
        }

        private void AddTypeDeclarationsToReferencedTypes(HashSet<TypeDeclaration> referencedTypes, TypeDeclaration typeDeclaration)
        {
            if (!referencedTypes.Contains(typeDeclaration))
            {
                referencedTypes.Add(typeDeclaration);
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

            ////if (draft201909Schema.Id is Draft201909MetaCore.IdValue idValue)
            ////{
            ////    location = new JsonReference(location).Apply(new JsonReference(idValue));
            ////}

            if (this.TryReduceSchema(location, draft201909Schema, out TypeDeclaration? reducedTypeDeclaration))
            {
                this.locatedTypeDeclarations.Add(location, reducedTypeDeclaration);
                return reducedTypeDeclaration;
            }

            // Check to see that we haven't located a type declration uring reduction.
            if (this.locatedTypeDeclarations.TryGetValue(location, out TypeDeclaration builtDuringReduction))
            {
                return builtDuringReduction;
            }

            // If not, then add ourselves into the collection
            var result = new TypeDeclaration(location, draft201909Schema);
            this.typeDeclarations.Add(result);
            this.locatedTypeDeclarations.Add(location, result);

            return result;
        }

        private bool TryReduceSchema(string absoluteLocation, Draft201909Schema draft201909Schema, [NotNullWhen(true)] out TypeDeclaration? reducedTypeDeclaration)
        {
            if (draft201909Schema.IsNakedReference() && draft201909Schema.Ref is JsonUriReference)
            {
                return this.ReduceSchema(absoluteLocation, out reducedTypeDeclaration, "$ref");
            }

            if (draft201909Schema.IsNakedRecursiveReference() && draft201909Schema.RecursiveRef is JsonUriReference)
            {
                return this.ReduceSchema(absoluteLocation, out reducedTypeDeclaration, "$recursiveRef");
            }

            reducedTypeDeclaration = default;
            return false;
        }

        private bool ReduceSchema(string absoluteLocation, out TypeDeclaration? reducedTypeDeclaration, string referenceProperty)
        {
            JsonReference currentLocation = new JsonReference(absoluteLocation).AppendUnencodedPropertyNameToFragment(referenceProperty);
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

        private void SetParents(Dictionary<string, TypeDeclaration> referencedTypesByLocation)
        {
            foreach (TypeDeclaration typeDeclaration in referencedTypesByLocation.Values)
            {
                FindAndSetParent(referencedTypesByLocation, typeDeclaration);
            }

            static void FindAndSetParent(Dictionary<string, TypeDeclaration> referencedTypesByLocation, TypeDeclaration typeDeclaration)
            {
                ReadOnlySpan<char> location = typeDeclaration.Location.AsSpan();
                while (true)
                {
                    int lastSlash = location.LastIndexOf('/');
                    if (lastSlash <= 0)
                    {
                        break;
                    }

                    if (location[lastSlash - 1] == '#')
                    {
                        lastSlash -= 1;
                    }

                    if (lastSlash <= 0)
                    {
                        break;
                    }

                    location = location.Slice(0, lastSlash);
                    if (referencedTypesByLocation.TryGetValue(location.ToString(), out TypeDeclaration parent) && parent != typeDeclaration)
                    {
                        typeDeclaration.SetParent(parent);
                        break;
                    }
                }
            }
        }

        private void FindProperties(Dictionary<string, TypeDeclaration> typesForGenerationByLocation, Dictionary<string, TypeDeclaration> referencedTypesByLocation)
        {
            // Find all the properties in everything
            foreach (TypeDeclaration type in typesForGenerationByLocation.Values)
            {
                var typesVisited = new HashSet<string>();
                this.AddPropertiesFromType(type, type, typesVisited);
            }

            // Once we've got the whole set, set the dotnet property names.
            foreach (TypeDeclaration type in typesForGenerationByLocation.Values)
            {
                type.SetDotnetPropertyNames();
            }
        }

        private void AddPropertiesFromType(TypeDeclaration source, TypeDeclaration target, HashSet<string> typesVisited)
        {
            if (typesVisited.Contains(source.Location))
            {
                return;
            }

            typesVisited.Add(source.Location);

            // First we add the 'required' properties as JsonAny; they will be overridden if we have explicit implementations
            // elsewhere
            if (source.Schema.Required is Draft201909MetaValidation.StringArray requiredArray)
            {
                foreach (JsonString requiredName in requiredArray.EnumerateArray())
                {
                    target.AddOrReplaceProperty(new PropertyDeclaration(BuiltInTypes.AnyTypeDeclarationInstance, requiredName!, true, source.Location == target.Location));
                }
            }

            if (source.Schema.AllOf is Draft201909MetaApplicator.ItemsEntity.SchemaArray allOf)
            {
                int index = 0;
                foreach (Draft201909Schema schema in allOf.EnumerateArray())
                {
                    TypeDeclaration allOfTypeDeclaration = this.GetTypeDeclarationForPropertyArrayIndex(source.Location, "allOf", index);
                    this.AddPropertiesFromType(allOfTypeDeclaration, target, typesVisited);
                    index++;
                }
            }

            if (source.Schema.Ref is JsonUriReference && !source.Schema.IsNakedReference())
            {
                TypeDeclaration refTypeDeclaration = this.GetTypeDeclarationForProperty(source.Location, "$ref");
                this.AddPropertiesFromType(refTypeDeclaration, target, typesVisited);
            }

            if (source.Schema.RecursiveRef is JsonUriReference && !source.Schema.IsNakedRecursiveReference())
            {
                TypeDeclaration refTypeDeclaration = this.GetTypeDeclarationForProperty(source.Location, "$recursiveRef");
                this.AddPropertiesFromType(refTypeDeclaration, target, typesVisited);
            }

            // Then we add our own properties.
            if (source.Schema.Properties is Draft201909MetaApplicator.PropertiesEntity properties)
            {
                foreach (Property<Draft201909MetaApplicator.PropertiesEntity> property in properties.EnumerateObject())
                {
                    string propertyName = property.Name;
                    bool isRequired = false;

                    if (source.Schema.Required is Draft201909MetaValidation.StringArray required)
                    {
                        if (required.Any(r => propertyName == r.GetString()))
                        {
                            isRequired = true;
                        }
                    }

                    TypeDeclaration propertyTypeDeclaration = this.GetTypeDeclarationForProperty(new JsonReference(source.Location).AppendUnencodedPropertyNameToFragment("properties"), propertyName);
                    target.AddOrReplaceProperty(new PropertyDeclaration(propertyTypeDeclaration, propertyName, isRequired, source.Location == target.Location));
                }
            }
        }

        private void SetNames(Dictionary<string, TypeDeclaration> typesForGenerationByLocation, string rootNamespace, Dictionary<string, string>? baseUriToNamespaceMap)
        {
            foreach (TypeDeclaration type in typesForGenerationByLocation.Values.Where(t => t.Parent is null))
            {
                this.RecursivelySetName(type, rootNamespace, baseUriToNamespaceMap);
            }

            // Now we've named everything once, we can fix up our array names to better reflect the types of the items
            foreach (TypeDeclaration type in typesForGenerationByLocation.Values.Where(t => t.Parent is null))
            {
                this.RecursivelyFixArrayName(type);
            }

            // Once we've set all the base names, and namespaces, we can set the fully qualified names.
            foreach (TypeDeclaration type in typesForGenerationByLocation.Values)
            {
                type.SetFullyQualifiedDotnetTypeName();
            }
        }

        private void RecursivelyFixArrayName(TypeDeclaration type)
        {
            if (type.Schema.IsExplicitArrayType())
            {
                if (type.Schema.Items is Draft201909MetaApplicator.ItemsEntity items && items.IsObject)
                {
                    TypeDeclaration itemsDeclaration = this.GetTypeDeclarationForProperty(type.Location, "items");

                    string targetName = $"{itemsDeclaration.DotnetTypeName}Array";
                    if (type.Parent is TypeDeclaration p && type.Parent.Children.Any(c => c.DotnetTypeName == targetName))
                    {
                        targetName = $"{type.DotnetTypeName.AsSpan()[..^5].ToString()}{targetName}";
                    }

                    type.OverrideDotnetTypeName(targetName);
                }
            }

            foreach (TypeDeclaration child in type.Children)
            {
                this.RecursivelyFixArrayName(child);
            }
        }

        private void RecursivelySetName(TypeDeclaration type, string rootNamespace, Dictionary<string, string>? baseUriToNamespaceMap, int? index = null)
        {
            string ns;
            if (baseUriToNamespaceMap is Dictionary<string, string> butnmp)
            {
                var location = new JsonReference(type.Location);

                if (!location.HasAbsoluteUri || !butnmp.TryGetValue(location.Uri.ToString(), out ns))
                {
                    ns = rootNamespace;
                }
            }
            else
            {
                ns = rootNamespace;
            }

            type.SetDotnetTypeNameAndNamespace(ns, index is null ? "Entity" : $"Entity{index + 1}");

            this.FixNameForChildren(type);

            int childIndex = 0;
            foreach (TypeDeclaration child in type.Children)
            {
                this.RecursivelySetName(child, rootNamespace, baseUriToNamespaceMap, childIndex);
                ++childIndex;
            }
        }

        private void FixNameForChildren(TypeDeclaration type)
        {
            if (type.Parent is TypeDeclaration parent)
            {
                int index = 1;
                while (parent.DotnetTypeName == type.DotnetTypeName || parent.Children.Any(c => c != type && c.DotnetTypeName == type.DotnetTypeName))
                {
                    string trimmedString = type.DotnetTypeName!.Trim('0', '1', '2', '3', '4', '5', '6', '7', '8', '9');
                    string newName = $"{trimmedString}{index}";
                    type.OverrideDotnetTypeName(newName);
                    index++;
                }
            }
        }

        private Dictionary<string, TypeDeclaration> PruneBuiltInTypes(Dictionary<string, TypeDeclaration> referencedTypesByLocation)
        {
            var pruned = new Dictionary<string, TypeDeclaration>();

            foreach (KeyValuePair<string, TypeDeclaration> item in referencedTypesByLocation)
            {
                if (!item.Value.Schema.IsBuiltInType())
                {
                    pruned.Add(item.Key, item.Value);
                }
                else
                {
                    item.Value.SetBuiltInTypeNameAndNamespace();
                }
            }

            return pruned;
        }
    }
}
