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
        public static readonly TypeDeclaration AnyTypeDeclaration = new TypeDeclaration(builtInType: true) { IsBooleanTrueType = true, DotnetTypeName = "Menes.JsonAny" };

        /// <summary>
        /// The not {}/false type declaration.
        /// </summary>
        public static readonly TypeDeclaration NotTypeDeclaration = new TypeDeclaration(builtInType: true) { IsBooleanFalseType = true, DotnetTypeName = "Menes.JsonNotAny" };

        /// <summary>
        /// A clr <see cref="int"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrInt32TypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonInteger" };

        /// <summary>
        /// A clr <see cref="long"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrInt64TypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonInteger" };

        /// <summary>
        /// A clr <see cref="float"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrFloatTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonNumber" };

        /// <summary>
        /// A clr <see cref="double"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrDoubleTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonNumber" };

        /// <summary>
        /// A clr <see cref="decimal"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrDecimalTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonNumber" };

        /// <summary>
        /// A clr <see cref="string"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrStringTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonString" };

        /// <summary>
        /// A clr <see cref="bool"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrBoolTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonBoolean" };

        /// <summary>
        /// A clr <see cref="System.Guid"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrGuidTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonGuid" };

        /// <summary>
        /// A clr <see cref="System.Uri"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrUriTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonUri" };

        /// <summary>
        /// A clr <see cref="System.Memory{T}"/> of <see cref="byte"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrByteArrayTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonByteArray" };

        /// <summary>
        /// A clr <see cref="NodaTime.LocalDate"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrDateTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonDate" };

        /// <summary>
        /// A clr <see cref="NodaTime.OffsetDateTime"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrDateTimeTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonDateTime" };

        /// <summary>
        /// A clr <see cref="NodaTime.Duration"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrDurationTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonDuration" };

        /// <summary>
        /// A clr <see cref="NodaTime.OffsetTime"/> type.
        /// </summary>
        public static readonly TypeDeclaration ClrTimeTypeDeclaration = new TypeDeclaration(builtInType: true) { DotnetTypeName = "Menes.JsonTime" };

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
        /// <param name="type">One of "integer", "number", "boolean", "string".</param>
        /// <returns>The corresponding fully qualified type name.</returns>
        public static string GetTypeNameFor(string type)
        {
            return type switch
            {
                "integer" => "Menes.JsonInteger",
                "number" => "Menes.JsonNumber",
                "boolean" => "Menes.JsonBoolean",
                "string" => "Menes.JsonString",
                _ => throw new InvalidOperationException($"Unsupported type name: '{type}'"),
            };
        }
    }
}
