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
        public static readonly JsonValueTypeDeclaration Date = new JsonValueTypeDeclaration(typeof(JsonDate).Name, new[] { "string", "NodaTime.LocalDate" }, ValueKind.String);

        /// <summary>
        /// Get the nodatime OffsetTime type for JSON Schema time.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Time = new JsonValueTypeDeclaration(typeof(JsonTime).Name, new[] { "string", "NodaTime.OffsetTime" }, ValueKind.String);

        /// <summary>
        /// Get the nodatime OffsetDateTime type for JSON Schema date-time.
        /// </summary>
        public static readonly JsonValueTypeDeclaration DateTime = new JsonValueTypeDeclaration(typeof(JsonDateTime).Name, new[] { "string", "NodaTime.OffsetDateTime" }, ValueKind.String);

        /// <summary>
        /// Get the nodatime Duration type for JSON Schema duration.
        /// </summary>
        public static readonly JsonValueTypeDeclaration Duration = new JsonValueTypeDeclaration(typeof(JsonDuration).Name, new[] { "string", "NodaTime.Duration" }, ValueKind.String);
    }
}
