// <copyright file="SimpleJsonValueTypeDeclaration.String.DateTime.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    /// <summary>
    /// A simple type declaration.
    /// </summary>
    public partial class SimpleJsonValueTypeDeclaration : ITypeDeclaration
    {
        /// <summary>
        /// Get the nodatime LocalDate type for JSON Schema date.
        /// </summary>
        public static readonly SimpleJsonValueTypeDeclaration Date = new SimpleJsonValueTypeDeclaration(typeof(JsonDate).FullName);

        /// <summary>
        /// Get the nodatime OffsetTime type for JSON Schema time.
        /// </summary>
        public static readonly SimpleJsonValueTypeDeclaration Time = new SimpleJsonValueTypeDeclaration(typeof(JsonTime).FullName);

        /// <summary>
        /// Get the nodatime OffsetDateTime type for JSON Schema date-time.
        /// </summary>
        public static readonly SimpleJsonValueTypeDeclaration DateTime = new SimpleJsonValueTypeDeclaration(typeof(JsonDateTime).FullName);

        /// <summary>
        /// Get the nodatime Duration type for JSON Schema duration.
        /// </summary>
        public static readonly SimpleJsonValueTypeDeclaration Duration = new SimpleJsonValueTypeDeclaration(typeof(JsonDuration).FullName);
    }
}
