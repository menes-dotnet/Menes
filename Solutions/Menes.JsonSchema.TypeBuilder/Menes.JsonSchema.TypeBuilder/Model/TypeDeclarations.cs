// <copyright file="TypeDeclarations.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder.Model
{
    using System;

    /// <summary>
    /// Gets common type declarations.
    /// </summary>
    public static class TypeDeclarations
    {
        /// <summary>
        /// The {}/true type declaration.
        /// </summary>
        public static readonly TypeDeclaration AnyTypeDeclaration = new TypeDeclaration(builtInType: true) { IsBooleanTrueSchema = true, DotnetTypeName = "Menes.JsonAny" };

        /// <summary>
        /// The not {}/false type declaration.
        /// </summary>
        public static readonly TypeDeclaration NotTypeDeclaration = new TypeDeclaration(builtInType: true) { IsBooleanFalseSchema = true, DotnetTypeName = "Menes.JsonNotAny" };

        /// <summary>
        /// The not {}/false type declaration.
        /// </summary>
        public static readonly TypeDeclaration NullTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonNull" };

        /// <summary>
        /// The not {}/false type declaration.
        /// </summary>
        public static readonly TypeDeclaration NumberTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonNumber" };

        /// <summary>
        /// The not {}/false type declaration.
        /// </summary>
        public static readonly TypeDeclaration IntegerTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonInteger" };

        /// <summary>
        /// A clr <see cref="int"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrInt32TypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonInteger" };

        /// <summary>
        /// A clr <see cref="int"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrInt32RawTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "int" };

        /// <summary>
        /// A clr <see cref="long"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrInt64TypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonInteger" };

        /// <summary>
        /// A clr <see cref="long"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrInt64RawTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "long" };

        /// <summary>
        /// A clr <see cref="float"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrFloatTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonNumber" };

        /// <summary>
        /// A clr <see cref="float"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrFloatRawTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "float" };

        /// <summary>
        /// A clr <see cref="double"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrDoubleTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonNumber" };

        /// <summary>
        /// A clr <see cref="double"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrDoubleRawTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "double" };

        /// <summary>
        /// A clr <see cref="string"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrStringTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonString" };

        /// <summary>
        /// A clr <see cref="string"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrStringRawTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "string" };

        /// <summary>
        /// A clr <see cref="bool"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrBoolTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonBoolean" };

        /// <summary>
        /// A clr <see cref="bool"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrBoolRawTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "bool" };

        /// <summary>
        /// A clr <see cref="System.Guid"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrGuidTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonGuid" };

        /// <summary>
        /// A clr <see cref="System.Guid"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrGuidRawTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "System.Guid" };

        /// <summary>
        /// A clr <see cref="System.Uri"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrUriTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonUri" };

        /// <summary>
        /// A clr IRI type.
        /// </summary>
        public static readonly TypeDeclaration ClrIriTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonIri" };

        /// <summary>
        /// A clr IRI-Reference type.
        /// </summary>
        public static readonly TypeDeclaration ClrIriReferenceTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonIriReference" };

        /// <summary>
        /// A clr <see cref="System.Uri"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrUriRawTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "System.Uri" };

        /// <summary>
        /// A clr <see cref="System.Memory{T}"/> of <see cref="byte"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrByteArrayTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonByteArray" };

        /// <summary>
        /// A clr <see cref="System.Memory{T}"/> of <see cref="byte"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrByteArrayRawTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "System.Memory<byte>" };

        /// <summary>
        /// A clr <see cref="NodaTime.LocalDate"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrDateTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonDate" };

        /// <summary>
        /// A clr <see cref="NodaTime.LocalDate"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrDateRawTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "NodaTime.LocalDate" };

        /// <summary>
        /// A clr <see cref="NodaTime.OffsetDateTime"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrDateTimeTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonDateTime" };

        /// <summary>
        /// A clr <see cref="NodaTime.OffsetDateTime"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrDateTimeRawTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "NodaTime.OffsetDateTime" };

        /// <summary>
        /// A clr <see cref="NodaTime.Period"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrDurationTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonDuration" };

        /// <summary>
        /// A clr <see cref="NodaTime.Period"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrDurationRawTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "NodaTime.Period" };

        /// <summary>
        /// A clr <see cref="NodaTime.OffsetTime"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrTimeTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonTime" };

        /// <summary>
        /// A clr <see cref="NodaTime.OffsetTime"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrTimeRawTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "NodaTime.OffsetTime" };

        /// <summary>
        /// A clr <see cref="string"/> type that matches an email address.
        /// </summary>
        // language=regex
        public static readonly TypeDeclaration EmailTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonString", Pattern = "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])" };

        /// <summary>
        /// A clr <see cref="string"/> type that matches an idn-email address.
        /// </summary>
        // language=regex
        public static readonly TypeDeclaration IdnEmailTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonString", Pattern = "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])" };

        /// <summary>
        /// A clr <see cref="string"/> type that matches a hostname address.
        /// </summary>
        // language=regex
        public static readonly TypeDeclaration HostnameTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonString", Pattern = "^(?=.{1,255}$)[0-9a-z](([0-9a-z]|\\b-){0,61}[0-9a-z])?(\\.[0-9a-z](([0-9a-z]|\\b-){0,61}[0-9a-z])?)*\\.?$" };

        /// <summary>
        /// A clr <see cref="string"/> type that matches a hostname address.
        /// </summary>
        // language=regex
        public static readonly TypeDeclaration IdnHostnameTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonString", Pattern = "^(?=.{1,255}$)[0-9a-z](([0-9a-z]|\\b-){0,61}[0-9a-z])?(\\.[0-9a-z](([0-9a-z]|\\b-){0,61}[0-9a-z])?)*\\.?$" };

        /// <summary>
        /// A clr <see cref="string"/> type that matches a V4 IP address.
        /// </summary>
        // language=regex
        public static readonly TypeDeclaration IpV4TypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonString", Pattern = "(?:(?:^|\\.)(?:2(?:5[0-5]|[0-4]\\d)|1?\\d?\\d)){4}" };

        /// <summary>
        /// A clr <see cref="string"/> type that matches a V6 IP address.
        /// </summary>
        // language=regex
        public static readonly TypeDeclaration IpV6TypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonString", Pattern = "^(?=.{1,255}$)[0-9a-z](([0-9a-z]|\\b-){0,61}[0-9a-z])?(\\.[0-9a-z](([0-9a-z]|\\b-){0,61}[0-9a-z])?)*\\.?$" };

        /// <summary>
        /// Gets the Menes type name for the given json-schema type.
        /// </summary>
        /// <param name="type">One of "integer", "number", "boolean", "string" or "null".</param>
        /// <param name="format">THe supported formats.</param>
        /// <returns>The corresponding fully qualified type name.</returns>
        public static string GetTypeNameFor(string type, string? format)
        {
            return GetTypeFor(type, format).FullyQualifiedDotNetTypeName!;
        }

        /// <summary>
        /// Gets the TypeDeclaration for the given type and optional format.
        /// </summary>
        /// <param name="type">The type for which to get the type declaration.</param>
        /// <param name="format">The format for which to get the type declaration.</param>
        /// <returns>The <see cref="TypeDeclaration"/> corresponding to the type and optional format.</returns>
        public static TypeDeclaration GetTypeFor(string? type, string? format)
        {
            return type switch
            {
                "null" => NullTypeDeclaration,
                "integer" => GetIntegerFor(format) ?? IntegerTypeDeclaration,
                "number" => GetNumberFor(format) ?? NumberTypeDeclaration,
                "boolean" => ClrBoolTypeDeclaration,
                "string" => GetStringFor(format) ?? ClrStringTypeDeclaration,
                null => GetIntegerFor(format) ?? GetNumberFor(format) ?? GetStringFor(format) ?? throw new InvalidOperationException($"Unsupported format declaration {format}."),
                _ => throw new InvalidOperationException($"Unsupported type declaration {type}."),
            };
        }

        /// <summary>
        /// Gets a value indicating whether the supplied format is a string format.
        /// </summary>
        /// <param name="format">The format to check.</param>
        /// <returns>True if this is a string format.</returns>
        public static bool IsStringFormat(string format)
        {
            return GetStringFor(format) is not null;
        }

        /// <summary>
        /// Gets a value indicating whether the supplied format is a numeric format.
        /// </summary>
        /// <param name="format">The format to check.</param>
        /// <returns>True if this is a numeric format.</returns>
        public static bool IsNumericFormat(string format)
        {
            return (GetNumberFor(format) ?? GetIntegerFor(format)) is not null;
        }

        private static TypeDeclaration? GetStringFor(string? format)
        {
            return format switch
            {
                "date" => ClrDateTypeDeclaration,
                "date-time" => ClrDateTimeTypeDeclaration,
                "time" => ClrTimeTypeDeclaration,
                "duration" => ClrDurationTypeDeclaration,
                "email" => EmailTypeDeclaration,
                "idn-email" => IdnEmailTypeDeclaration,
                "hostname" => HostnameTypeDeclaration,
                "idn-hostname" => IdnHostnameTypeDeclaration,
                "ipv4" => IpV4TypeDeclaration,
                "ipv6" => IpV6TypeDeclaration,
                "guid" => ClrGuidTypeDeclaration,
                "uri" => ClrUriTypeDeclaration,
                "iri" => ClrIriTypeDeclaration,
                "iri-reference" => ClrIriReferenceTypeDeclaration,
                _ => null,
            };
        }

        private static TypeDeclaration? GetNumberFor(string? format)
        {
            return format switch
            {
                "single" => ClrFloatTypeDeclaration,
                "double" => ClrDoubleTypeDeclaration,
                _ => null,
            };
        }

        private static TypeDeclaration? GetIntegerFor(string? format)
        {
            return format switch
            {
                "int32" => ClrInt32TypeDeclaration,
                "int64" => ClrInt64TypeDeclaration,
                _ => null,
            };
        }
    }
}
