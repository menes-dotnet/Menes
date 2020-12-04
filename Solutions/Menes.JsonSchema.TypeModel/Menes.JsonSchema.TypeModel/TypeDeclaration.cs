// <copyright file="TypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using Menes.Json;

    /// <summary>
    /// A type declaration based on a schema.
    /// </summary>
    public class TypeDeclaration
    {
        private ImmutableArray<TypeDeclaration> children = ImmutableArray<TypeDeclaration>.Empty;

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
        /// Gets the embedded children of this type.
        /// </summary>
        public ImmutableArray<TypeDeclaration> Children => this.children;

        /// <summary>
        /// Gets the namespace in which to put this type.
        /// </summary>
        /// <remarks>
        /// If <see cref="Parent"/> is not null, then this will be null, and vice-versa.
        /// </remarks>
        public string? Namespace { get; private set; }

        /// <summary>
        /// Gets the dotnet type name for this type.
        /// </summary>
        public string? DotnetTypeName { get; private set; }

        /// <summary>
        /// Gets the fully qualified dotnet type name for this type.
        /// </summary>
        public string? FullyQualifiedDotnetTypeName { get; private set; }

        /// <summary>
        /// Sets the parent type declaration.
        /// </summary>
        /// <param name="parent">The parent type declaration.</param>
        public void SetParent(TypeDeclaration parent)
        {
            if (this.Parent is not null)
            {
                if (this.Parent == parent)
                {
                    return;
                }

                this.Parent.RemoveChild(this);
            }

            this.Parent = parent;
            parent.AddChild(this);
        }

        /// <summary>
        /// Calculates a name for the type based on the inforamtion we have.
        /// </summary>
        /// <remarks>
        /// A builder should call <see cref="SetDotnetTypeNameAndNamespace(string)"/> across the whole hierarchy before calling set fully qualified name.
        /// </remarks>
        public void SetFullyQualifiedDotnetTypeName()
        {
            if (this.DotnetTypeName is null)
            {
                throw new InvalidOperationException("The dotnet type name must be set before you can set the fully qualified dotnet type name.");
            }

            this.FullyQualifiedDotnetTypeName = this.BuildFullyQualifiedDotnetTypeName(this.DotnetTypeName);
            Console.WriteLine(this.FullyQualifiedDotnetTypeName);
        }

        /// <summary>
        /// Sets a built-in type name and namespace.
        /// </summary>
        public void SetBuiltInTypeNameAndNamespace()
        {
            if (this.Schema.IsBuiltInType())
            {
                string ns;
                string type;

                if (this.Schema.IsBoolean)
                {
                    (ns, type) = this.Schema ? BuiltInTypes.AnyTypeDeclaration : BuiltInTypes.NotTypeDeclaration;
                }
                else if (this.Schema.IsEmpty())
                {
                    (ns, type) = BuiltInTypes.AnyTypeDeclaration;
                }
                else
                {
                    (ns, type) = BuiltInTypes.GetTypeFor(this.Schema.Type, this.Schema.Format);
                }

                this.DotnetTypeName = type;
                this.FullyQualifiedDotnetTypeName = $"{ns}.{type}";
                this.Namespace = ns;
            }
        }

        /// <summary>
        /// Explicitly sets the dotnet type name to a new value.
        /// </summary>
        /// <param name="dotnetTypeName">The new dotnet type name.</param>
        public void OverrideDotnetTypeName(string dotnetTypeName)
        {
            this.DotnetTypeName = dotnetTypeName;
        }

        /// <summary>
        /// Calculates a name for the type based on the inforamtion we have.
        /// </summary>
        /// <param name="fallbackBaseName">The base type name to fall back on if we can't derive one from our location and type infomration.</param>
        /// <remarks>
        /// A builder should call <see cref="SetParent(TypeDeclaration)"/> before calling set name.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1009:Closing parenthesis should be spaced correctly", Justification = "Sylecop does not yet support this syntax.")]
        public void SetDotnetTypeNameAndNamespace(string fallbackBaseName)
        {
            var reference = JsonReferenceBuilder.From(this.Location);

            if (this.Parent is null)
            {
                if (reference.HasFragment)
                {
                    int lastSlash = reference.Fragment.LastIndexOf('/');
                    ReadOnlySpan<char> dnt = Formatting.ToPascalCaseWithReservedWords(reference.Fragment[(lastSlash + 1)..].ToArray());
                    this.DotnetTypeName = dnt.ToString();
                }
                else if (reference.HasPath)
                {
                    int lastSlash = reference.Path.LastIndexOf('/');
                    ReadOnlySpan<char> dnt = Formatting.ToPascalCaseWithReservedWords(reference.Path[(lastSlash + 1)..].ToArray());
                    this.DotnetTypeName = dnt.ToString();
                }
                else
                {
                    ReadOnlySpan<char> dnt = fallbackBaseName;
                    this.DotnetTypeName = dnt.ToString();
                }
            }
            else
            {
                ReadOnlySpan<char> typename;

                if (reference.HasFragment)
                {
                    int lastSlash = reference.Fragment.LastIndexOf('/');
                    typename = Formatting.ToPascalCaseWithReservedWords(reference.Fragment[(lastSlash + 1)..].ToArray());
                }
                else if (reference.HasPath)
                {
                    int lastSlash = reference.Path.LastIndexOf('/');
                    typename = Formatting.ToPascalCaseWithReservedWords(reference.Fragment[(lastSlash + 1)..].ToArray());
                }
                else
                {
                    typename = fallbackBaseName;
                }

                if (this.Schema.IsExplicitArrayType())
                {
                    Span<char> dnt = stackalloc char[typename.Length + 5];
                    typename.CopyTo(dnt);
                    "Array".AsSpan().CopyTo(dnt[typename.Length..]);
                    this.DotnetTypeName = dnt.ToString();
                }
                else if (this.Schema.IsSimpleType())
                {
                    Span<char> dnt = stackalloc char[typename.Length + 5];
                    typename.CopyTo(dnt);
                    "Value".AsSpan().CopyTo(dnt[typename.Length..]);
                    this.DotnetTypeName = dnt.ToString();
                }
                else
                {
                    Span<char> dnt = stackalloc char[typename.Length + 6];
                    typename.CopyTo(dnt);
                    "Entity".AsSpan().CopyTo(dnt[typename.Length..]);
                    this.DotnetTypeName = dnt.ToString();
                }
            }
        }

        /// <summary>
        /// Sets the referenced types.
        /// </summary>
        /// <param name="referencedTypes">The referenced types.</param>
        public void SetReferencedTypes(HashSet<TypeDeclaration> referencedTypes)
        {
            this.ReferencedTypes = referencedTypes.ToImmutableHashSet();
        }

        private string BuildFullyQualifiedDotnetTypeName(string dotnetTypeName)
        {
            var nameSegments = new List<string>
                {
                    dotnetTypeName,
                };

            TypeDeclaration? parent = this.Parent;
            while (parent is TypeDeclaration p)
            {
                nameSegments.Insert(0, p.DotnetTypeName!);
                parent = parent.Parent;
            }

            return string.Join('.', nameSegments);
        }

        private void AddChild(TypeDeclaration typeDeclaration)
        {
            this.children = this.children.Add(typeDeclaration);
        }

        private void RemoveChild(TypeDeclaration typeDeclaration)
        {
            this.children = this.children.Remove(typeDeclaration);
        }
    }
}
