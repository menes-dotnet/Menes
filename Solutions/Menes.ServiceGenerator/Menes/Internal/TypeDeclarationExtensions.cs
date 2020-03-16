// <copyright file="TypeDeclarationExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Linq;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    /// <summary>
    /// Extensions for <see cref="TypeDeclarationSyntax"/>.
    /// </summary>
    public static class TypeDeclarationExtensions
    {
        /// <summary>
        /// Adds an auto property to a type.
        /// </summary>
        /// <param name="tds">The type to which to add the property.</param>
        /// <param name="propertyTypeName">The name of the type of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The type declaration syntax with the properties added.</returns>
        public static TypeDeclarationSyntax AddAutoProperty(this TypeDeclarationSyntax tds, string propertyTypeName, string propertyName)
        {
            PropertyDeclarationSyntax property =
                SF.PropertyDeclaration(SF.ParseTypeName(propertyTypeName), SF.Identifier(propertyName))
                    .AddModifiers(SF.Token(SyntaxKind.PublicKeyword))
                    .AddAccessorListAccessors(
                        SF.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                            .WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken)),
                        SF.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                            .WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken)));
            return tds.AddMembers(property);
        }

        /// <summary>
        /// Copies uniquely named properties from the source type declaration to the destination.
        /// </summary>
        /// <param name="destination">The destination type.</param>
        /// <param name="source">The source type.</param>
        /// <returns>The target declaration with the additional properties added.</returns>
        public static TypeDeclarationSyntax CopyUniquePropertiesFrom(this TypeDeclarationSyntax destination, TypeDeclarationSyntax source)
        {
            foreach (PropertyDeclarationSyntax property in source.Members.OfType<PropertyDeclarationSyntax>())
            {
                if (!destination.Members.OfType<PropertyDeclarationSyntax>().Any(p => p.Identifier.ValueText == property.Identifier.ValueText))
                {
                    destination = destination.AddMembers(property);
                }
            }

            return destination;
        }

        /// <summary>
        /// Adds a method to <paramref name="mapFrom"/> instance that maps to an instance of the <paramref name="mapTo"/> type.
        /// </summary>
        /// <param name="mapFrom">The type declaration to which the method should be added.</param>
        /// <param name="mapTo">The type declaration of the type to which the type should be mapped.</param>
        /// <returns>The type declaration from which to map with an <c>As{MapToTypeName}</c>() method which provides the mapping.</returns>
        /// <remarks>
        /// <para>This provides a simple mapping that assumes that the source and target contain matching properties. Typically, this will have been set up using the <see cref="CopyUniquePropertiesFrom(TypeDeclarationSyntax, TypeDeclarationSyntax)"/> method.</para>
        /// </remarks>
        public static TypeDeclarationSyntax AddMapperMethod(this TypeDeclarationSyntax mapFrom, TypeDeclarationSyntax mapTo)
        {
            string methodName = $"As{mapTo.Identifier.ValueText}";

            MethodDeclarationSyntax md = SF.MethodDeclaration(SF.ParseTypeName(mapTo.Identifier.ValueText), SF.Identifier(methodName));
            md = md.AddBodyStatements(SF.ParseStatement($"var result = new {mapTo.Identifier.ValueText}();"));

            foreach (PropertyDeclarationSyntax property in mapTo.Members.OfType<PropertyDeclarationSyntax>())
            {
                md = md.AddBodyStatements(SF.ParseStatement($"result.{property.Identifier.Text} = this.{property.Identifier.Text};"));
            }

            md = md.AddBodyStatements(SF.ParseStatement($"return result;"));
            return mapFrom.AddMembers(md);
        }
    }
}
