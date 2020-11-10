// <copyright file="JsonSchemaBuilder.Building.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Threading.Tasks;
    using Menes.Json;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        /// <summary>
        /// Build a <see cref="TypeDeclaration"/> from a <see cref="LocatedElement"/> produced
        /// by calling <see cref="GetOrCreateLocatedElement(System.Text.Json.JsonElement)"/>.
        /// </summary>
        private async Task<TypeDeclaration> BuildTypeDeclaration(LocatedElement schema)
        {
            // We create the type declaration and immediately add it to the built declarations
            // collection so that we will be able to bomb out if we have already started building
            // this when we see a recursive definition.
            if (this.builtDeclarationsByLocation.TryGetValue(schema.AbsoluteKeywordLocation, out TypeDeclaration prebuilt))
            {
                return prebuilt;
            }

            var typeDeclaration = new TypeDeclaration();
            this.builtDeclarationsByLocation.Add(schema.AbsoluteKeywordLocation, typeDeclaration);

            // Update the stack with the current absolute keyword location.
            this.absoluteKeywordLocationStack.Push(schema.AbsoluteKeywordLocation);

            try
            {
                await this.SetNameAndParent(schema, typeDeclaration).ConfigureAwait(false);
                await this.AddRef(schema, typeDeclaration).ConfigureAwait(false);
                await this.AddAllOf(schema, typeDeclaration).ConfigureAwait(false);
                await this.AddAnyOf(schema, typeDeclaration).ConfigureAwait(false);
                await this.AddOneOf(schema, typeDeclaration).ConfigureAwait(false);
                await this.FindProperties(schema, typeDeclaration).ConfigureAwait(false);
                return typeDeclaration;
            }
            finally
            {
                this.absoluteKeywordLocationStack.Pop();
            }
        }

        /// <summary>
        /// <para>
        /// We set the name and the parent in a single operation as it has to be done in two stages.
        /// </para>
        /// <para>
        /// First, we find and set our own parent reference, if we have one.
        /// </para>
        /// <para>
        /// Then we build our name, based on the knowledge of the other members in our parent
        /// to avoid clashes.
        /// </para>
        /// <para>
        /// Then we add ourselves to our parent, in the knowledge that we will not fall foul
        /// of our parent's unique name validation constraints.
        /// </para>
        /// </summary>
        private async Task SetNameAndParent(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            await this.SetParent(schema, typeDeclaration).ConfigureAwait(false);
            this.SetTypeName(schema, typeDeclaration);
            this.AddToParent(typeDeclaration);
        }

        private void AddToParent(TypeDeclaration typeDeclaration)
        {
            typeDeclaration.Parent?.AddTypeDeclaration(typeDeclaration);
        }

        private async Task SetParent(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            if (schema.AbsoluteParentKeywordLocation is JsonReference reference)
            {
                if (!this.builtDeclarationsByLocation.TryGetValue(reference, out TypeDeclaration parent))
                {
                    if (this.TryGetResolvedElement(reference, out LocatedElement parentElement))
                    {
                        parent = await this.BuildTypeDeclaration(parentElement).ConfigureAwait(false);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to find element for parent at location: '{reference}'");
                    }
                }

                typeDeclaration.Parent = parent;
                return;
            }
        }
    }
}