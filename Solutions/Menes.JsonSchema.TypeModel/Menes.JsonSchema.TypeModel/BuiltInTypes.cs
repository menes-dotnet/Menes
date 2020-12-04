// <copyright file="BuiltInTypes.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeModel
{
    using System;

    /// <summary>
    /// Gets common type declarations.
    /// </summary>
    public static class BuiltInTypes
    {
        /// <summary>
        /// The {}/true type declaration.
        /// </summary>
        public static readonly (string ns, string type) AnyTypeDeclaration = ("Menes", "JsonAny");

        /// <summary>
        /// The not {}/false type declaration.
        /// </summary>
        public static readonly (string ns, string type) NotTypeDeclaration = ("Menes", "JsonNotAny");

        /// <summary>
        /// The not {}/false type declaration.
        /// </summary>
        public static readonly (string ns, string type) NullTypeDeclaration = ("Menes", "JsonNull");

        /// <summary>
        /// The not {}/false type declaration.
        /// </summary>
        public static readonly (string ns, string type) NumberTypeDeclaration = ("Menes", "JsonNumber");

        /// <summary>
        /// The not {}/false type declaration.
        /// </summary>
        public static readonly (string ns, string type) IntegerTypeDeclaration = ("Menes", "JsonInteger");

        /// <summary>
        /// A clr <see cref="int"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrInt32TypeDeclaration = ("Menes", "JsonInteger");

        /// <summary>
        /// A clr <see cref="int"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrInt32RawTypeDeclaration = (string.Empty, "int");

        /// <summary>
        /// A clr <see cref="long"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrInt64TypeDeclaration = ("Menes", "JsonInteger");

        /// <summary>
        /// A clr <see cref="long"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrInt64RawTypeDeclaration = (string.Empty, "long");

        /// <summary>
        /// A clr <see cref="float"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrFloatTypeDeclaration = ("Menes", "JsonNumber");

        /// <summary>
        /// A clr <see cref="float"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrFloatRawTypeDeclaration = (string.Empty, "float");

        /// <summary>
        /// A clr <see cref="double"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrDoubleTypeDeclaration = ("Menes", "JsonNumber");

        /// <summary>
        /// A clr <see cref="double"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrDoubleRawTypeDeclaration = (string.Empty, "double");

        /// <summary>
        /// A clr <see cref="string"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrStringTypeDeclaration = ("Menes", "JsonString");

        /// <summary>
        /// A clr <see cref="string"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrStringRawTypeDeclaration = (string.Empty, "string");

        /// <summary>
        /// A clr <see cref="bool"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrBoolTypeDeclaration = ("Menes", "JsonBoolean");

        /// <summary>
        /// A clr <see cref="bool"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrBoolRawTypeDeclaration = (string.Empty, "bool");

        /// <summary>
        /// A clr <see cref="Guid"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrGuidTypeDeclaration = ("Menes", "JsonGuid");

        /// <summary>
        /// A clr <see cref="Guid"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrGuidRawTypeDeclaration = (string.Empty, "System.Guid");

        /// <summary>
        /// A clr <see cref="Uri"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrUriTypeDeclaration = ("Menes", "JsonUri");

        /// <summary>
        /// A clr <see cref="Uri"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrUriReferenceTypeDeclaration = ("Menes", "JsonUriReference");

        /// <summary>
        /// A clr <see cref="Uri"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrUriTemplateTypeDeclaration = ("Menes", "JsonUriTemplate");

        /// <summary>
        /// A clr IRI type.
        /// </summary>
        public static readonly (string ns, string type) ClrIriTypeDeclaration = ("Menes", "JsonIri");

        /// <summary>
        /// A clr JsonPointer type.
        /// </summary>
        public static readonly (string ns, string type) ClrJsonPointerTypeDeclaration = ("Menes", "JsonPointer");

        /// <summary>
        /// A clr RelativeJsonPointer type.
        /// </summary>
        public static readonly (string ns, string type) ClrRelativeJsonPointerTypeDeclaration = ("Menes", "RelativeJsonPointer");

        /// <summary>
        /// A clr Regex type.
        /// </summary>
        public static readonly (string ns, string type) ClrRegexTypeDeclaration = ("Menes", "JsonRegex");

        /// <summary>
        /// A clr IRI-Reference type.
        /// </summary>
        public static readonly (string ns, string type) ClrIriReferenceTypeDeclaration = ("Menes", "JsonIriReference");

        /// <summary>
        /// A clr <see cref="Uri"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrUriRawTypeDeclaration = ("System", "Uri");

        /// <summary>
        /// A clr <see cref="JsonBase64String"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrBase64StringTypeDeclaration = ("Menes", "JsonBase64String");

        /// <summary>
        /// A clr <see cref="JsonBase64Content"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrBase64ContentTypeDeclaration = ("Menes", "JsonBase64Content");

        /// <summary>
        /// A clr <see cref="JsonContent"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrContentTypeDeclaration = ("Menes", "JsonContent");

        /// <summary>
        /// A clr <see cref="NodaTime.LocalDate"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrDateTypeDeclaration = ("Menes", "JsonDate");

        /// <summary>
        /// A clr <see cref="NodaTime.LocalDate"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrDateRawTypeDeclaration = ("NodaTime", "LocalDate");

        /// <summary>
        /// A clr <see cref="NodaTime.OffsetDateTime"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrDateTimeTypeDeclaration = ("Menes", "JsonDateTime");

        /// <summary>
        /// A clr <see cref="NodaTime.OffsetDateTime"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrDateTimeRawTypeDeclaration = ("NodaTime", "OffsetDateTime");

        /// <summary>
        /// A clr <see cref="NodaTime.Period"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrDurationTypeDeclaration = ("Menes", "JsonDuration");

        /// <summary>
        /// A clr <see cref="NodaTime.Period"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrDurationRawTypeDeclaration = ("NodaTime", "Period");

        /// <summary>
        /// A clr <see cref="NodaTime.OffsetTime"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrTimeTypeDeclaration = ("Menes", "JsonTime");

        /// <summary>
        /// A clr <see cref="NodaTime.OffsetTime"/> type.
        /// </summary>
        public static readonly (string ns, string type) ClrTimeRawTypeDeclaration = ("NodaTime", "OffsetTime");

        /// <summary>
        /// A clr <see cref="string"/> type that matches an email address.
        /// </summary>
        // language=regex
        public static readonly (string ns, string type) EmailTypeDeclaration = ("Menes", "JsonEmail");

        /// <summary>
        /// A clr <see cref="string"/> type that matches an idn-email address.
        /// </summary>
        // language=regex
        public static readonly (string ns, string type) IdnEmailTypeDeclaration = ("Menes", "JsonIdnEmail");

        /// <summary>
        /// A clr <see cref="string"/> type that matches a hostname address.
        /// </summary>
        // language=regex
        public static readonly (string ns, string type) HostnameTypeDeclaration = ("Menes", "JsonHostname");

        /// <summary>
        /// A clr <see cref="string"/> type that matches a hostname address.
        /// </summary>
        // language=regex
        public static readonly (string ns, string type) IdnHostnameTypeDeclaration = ("Menes", "JsonIdnHostname");

        /// <summary>
        /// A clr <see cref="string"/> type that matches a V4 IP address.
        /// </summary>
        // language=regex
        public static readonly (string ns, string type) IpV4TypeDeclaration = ("Menes", "JsonIpV4");

        /// <summary>
        /// A clr <see cref="string"/> type that matches a V6 IP address.
        /// </summary>
        // language=regex
        public static readonly (string ns, string type) IpV6TypeDeclaration = ("Menes", "JsonIpV6");

        /// <summary>
        /// Gets the built in type and namespace for the given type and optional format.
        /// </summary>
        /// <param name="type">The type for which to get the type declaration.</param>
        /// <param name="format">The format for which to get the type declaration.</param>
        /// <returns>A tuple of the namespace and type corresponding to the type and optional format.</returns>
        public static (string ns, string type) GetTypeFor(string? type, string? format)
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

        private static (string ns, string type)? GetStringFor(string? format)
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
                "uuid" => ClrGuidTypeDeclaration,
                "uri" => ClrUriTypeDeclaration,
                "uri-template" => ClrUriTemplateTypeDeclaration,
                "uri-reference" => ClrUriReferenceTypeDeclaration,
                "iri" => ClrIriTypeDeclaration,
                "iri-reference" => ClrIriReferenceTypeDeclaration,
                "json-pointer" => ClrJsonPointerTypeDeclaration,
                "relative-json-pointer" => ClrRelativeJsonPointerTypeDeclaration,
                "regex" => ClrRegexTypeDeclaration,
                _ => null,
            };
        }

        private static (string ns, string type)? GetNumberFor(string? format)
        {
            return format switch
            {
                "single" => ClrFloatTypeDeclaration,
                "double" => ClrDoubleTypeDeclaration,
                _ => null,
            };
        }

        private static (string ns, string type)? GetIntegerFor(string? format)
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
