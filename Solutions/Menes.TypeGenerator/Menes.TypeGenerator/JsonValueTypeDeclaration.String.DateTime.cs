// <copyright file="JsonValueTypeDeclaration.String.DateTime.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    /// <summary>
    /// A simple type declaration.
    /// </summary>
    public partial class JsonValueTypeDeclaration : ITypeDeclaration
    {
        /// <summary>
        /// Get the nodatime LocalDate type for JSON Schema date.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Date = new JsonValueTypeDeclaration(typeof(JsonDate).FullName, "string", ValueKind.String);

        /// <summary>
        /// Get the nodatime OffsetTime type for JSON Schema time.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Time = new JsonValueTypeDeclaration(typeof(JsonTime).FullName, "string", ValueKind.String);

        /// <summary>
        /// Get the nodatime OffsetDateTime type for JSON Schema date-time.
        /// </summary>
        public static readonly JsonValueTypeDeclaration DateTime = new JsonValueTypeDeclaration(typeof(JsonDateTime).FullName, "string", ValueKind.String);

        /// <summary>
        /// Get the nodatime Duration type for JSON Schema duration.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Duration = new JsonValueTypeDeclaration(typeof(JsonDuration).FullName, "string", ValueKind.String);
    }
}
