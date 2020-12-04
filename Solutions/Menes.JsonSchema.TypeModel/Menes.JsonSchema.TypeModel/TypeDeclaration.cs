// <copyright file="TypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeModel
{
    using System.Collections.Generic;
    using System.Collections.Immutable;

    /// <summary>
    /// A type declaration based on a schema.
    /// </summary>
    public class TypeDeclaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeDeclaration"/> class.
        /// </summary>
        /// <param name="location">The canonical location of the type declaration.</param>
        /// <param name="schema">The schema with which this type declaration is associated.</param>
        public TypeDeclaration(string location, Draft201909Schema schema)
        {
            this.Location = location;
            this.Schema = schema;
        }

        /// <summary>
        /// Gets the canonical location of the type declaration.
        /// </summary>
        public string Location { get; }

        /// <summary>
        /// Gets the schema associated with this type declaration.
        /// </summary>
        public Draft201909Schema Schema { get; }

        /// <summary>
        /// Gets the parent declaration of this type declaration.
        /// </summary>
        public TypeDeclaration? Parent { get; private set; }

        /// <summary>
        /// Gets the set of <see cref="TypeDeclaration"/> instances referenced by this <see cref="TypeDeclaration"/>.
        /// </summary>
        public ImmutableHashSet<TypeDeclaration>? ReferencedTypes { get; private set; }

        /// <summary>
        /// Sets the parent type declaration.
        /// </summary>
        /// <param name="parent">The parent type declaration.</param>
        public void SetParent(TypeDeclaration parent)
        {
            this.Parent = parent;
        }

        /// <summary>
        /// Sets the referenced types.
        /// </summary>
        /// <param name="referencedTypes">The referenced types.</param>
        public void SetReferencedTypes(HashSet<TypeDeclaration> referencedTypes)
        {
            this.ReferencedTypes = referencedTypes.ToImmutableHashSet();
        }
    }
}
