// <copyright file="ObjectTypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    /// <summary>
    /// Type declaration for a complex object.
    /// </summary>
    public class ObjectTypeDeclaration : TypeDeclaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectTypeDeclaration"/> class.
        /// </summary>
        /// <param name="parent">The parent scope.</param>
        /// <param name="name">The name of the type.</param>
        public ObjectTypeDeclaration(IDeclaration parent, string name)
            : base(parent, name)
        {
        }

        /// <inheritdoc/>
        public override TypeDeclarationSyntax GenerateType()
        {
            return
                SF.StructDeclaration(NameFormatter.ToPascalCase(this.Name))
                .AddBaseListTypes(SF.SimpleBaseType(SF.ParseTypeName(typeof(IJsonValue).FullName)), SF.SimpleBaseType(SF.ParseTypeName(typeof(IJsonAdditionalProperties).FullName)))
                .AddMembers(this.BuildMembers());
        }

        /// <inheritdoc/>
        public override bool IsSpecializedBy(ITypeDeclaration type)
        {
            return false;
        }

        private MemberDeclarationSyntax[] BuildMembers()
        {
            var members = new List<MemberDeclarationSyntax>();

            foreach (PropertyDeclaration property in this.Properties)
            {
                // TODO: WORKING ON THIS
                // property.JsonPropertyName
            }

            return members.ToArray();
        }
    }
}
