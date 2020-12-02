// <copyright file="JsonSchemaBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Menes.Json;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        private readonly Dictionary<string, TypeDeclaration> builtDeclarationsByLocation = new Dictionary<string, TypeDeclaration>();
        private readonly Stack<JsonReference> absoluteKeywordLocationStack = new Stack<JsonReference>();
        private readonly HashSet<string> unresolvedElements = new HashSet<string>();

        // Note that anchors are stored as a full reference, with the base uri of the root document combined with the anchor name.
        private readonly Dictionary<string, LocatedElement> anchors = new Dictionary<string, LocatedElement>();

        private readonly Dictionary<string, LocatedElement> locatedElementsByLocation = new Dictionary<string, LocatedElement>();

        private readonly IDocumentResolver documentResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaBuilder"/> class.
        /// </summary>
        /// <param name="documentResolver">The <see cref="IDocumentResolver"/> to use to pull down referenced schema.</param>
        public JsonSchemaBuilder(IDocumentResolver documentResolver)
        {
            this.documentResolver = documentResolver;
        }

        /// <summary>
        /// Attempts to build an entity for a <see cref="JsonElement"/> containing a schema.
        /// </summary>
        /// <param name="schema">The root schema for which to build the entity.</param>
        /// <param name="baseAbsoluteKeywordLocation">A base absolute keyword locatoin for the schema.</param>
        /// <param name="fallbackRootName">The type name to use if there is no derivable name on the root.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks>
        /// <para>
        /// Use this overload when your base schema is not the root of a document, and you need to treat it
        /// as if it is located in place. Relative references may therefore be applied outside the scope
        /// of this element into its parent document.
        /// </para>
        /// <para>
        /// You may use this, for example, when referencing a schema element from an OpenAPI document.
        /// </para>
        /// </remarks>
        public async Task BuildEntity(JsonElement schema, JsonReference baseAbsoluteKeywordLocation, string? fallbackRootName)
        {
            this.absoluteKeywordLocationStack.Push(baseAbsoluteKeywordLocation);
            await this.BuildEntity(schema, fallbackRootName);
            this.absoluteKeywordLocationStack.Pop();
        }

        /// <summary>
        /// Attempts to build an entity for a <see cref="JsonElement"/> containing a schema.
        /// </summary>
        /// <param name="schema">The root schema for which to build the entity.</param>
        /// <param name="fallbackRootName">The type name to use if there is no derivable name on the root.</param>
        /// <returns>A <see cref="Task{T}"/> representing the asynchronous operation, which provides the fully qualified type name of the root type you have generated.</returns>
        /// <remarks>
        /// Use this overload when your base schema is the root of a document.
        /// </remarks>
        public async Task<string> BuildEntity(JsonElement schema, string? fallbackRootName)
        {
            LocatedElement rootElement = await this.WalkTreeAndLocateElementsFrom(schema).ConfigureAwait(false);

            // Verify that our schema walk and loading did not lead to any unresolved references.
            this.ValidateUnresolvedElements();

            // Nothing for us to do if the named element has already been built (or we are currently building it).
            if (this.builtDeclarationsByLocation.TryGetValue(rootElement.AbsoluteKeywordLocation, out TypeDeclaration? builtType))
            {
                return builtType.Lowered.FullyQualifiedDotNetTypeName!;
            }

            TypeDeclaration root = await this.CreateTypeDeclarations(rootElement, fallbackRootName).ConfigureAwait(false);
            return root.Lowered.FullyQualifiedDotNetTypeName!;
        }

        /// <summary>
        /// Build the types we have generated.
        /// </summary>
        /// <param name="namespaceName">The namespace into which to build the types.</param>
        /// <returns>A dictionary mapping file names to the code generated for the type.</returns>
        public ImmutableDictionary<string, string> BuildTypes(string namespaceName)
        {
            var generatedTypeNames = new HashSet<string>();

            var memberBuilder = new System.Text.StringBuilder();
            ImmutableDictionary<string, string>.Builder generatedTypes = ImmutableDictionary.CreateBuilder<string, string>();
            foreach (TypeDeclaration type in this.builtDeclarationsByLocation.Values)
            {
                TypeDeclaration loweredType = type.Lowered;

                if (!loweredType.IsBuiltInType && loweredType.Parent is null && !generatedTypeNames.Contains(loweredType.FullyQualifiedDotNetTypeName!))
                {
                    memberBuilder.Clear();
                    memberBuilder.AppendLine($"// <copyright file=\"{loweredType.DotnetTypeName}.cs\" company=\"Endjin Limited\">");
                    memberBuilder.AppendLine("// Copyright (c) Endjin Limited. All rights reserved.");
                    memberBuilder.AppendLine("// </copyright>");
                    memberBuilder.AppendLine("#pragma warning disable");
                    memberBuilder.AppendLine($"namespace {namespaceName}");
                    memberBuilder.AppendLine("{");
                    this.BuildCode(loweredType, memberBuilder);
                    generatedTypeNames.Add(loweredType.FullyQualifiedDotNetTypeName!);
                    memberBuilder.AppendLine("}");
                    generatedTypes.Add($"{loweredType.DotnetTypeName}.cs", memberBuilder.ToString());
                }
            }

            return generatedTypes.ToImmutable();
        }
    }
}
