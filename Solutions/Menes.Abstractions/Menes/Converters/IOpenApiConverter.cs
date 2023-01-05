// <copyright file="IOpenApiConverter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Converters
{
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Implemented by types that can convert a value to/from an OpenAPI schema value.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface has a slight internal inconsistency: string value handling is different for
    /// inputs (<see cref="ConvertFrom(string, OpenApiSchema)"/>) and outputs
    /// (<see cref="ConvertTo(object, OpenApiSchema)"/>). String-typed inputs normally come from
    /// the path, query, or sometimes a header or cookie, and in these cases, we don't wrap the
    /// strings with double quotes. This is in contrast to JSON where you can always tell the
    /// difference between a string value and some other value, e.g.:
    /// </para>
    /// <code>
    /// {
    ///   "booleanValue": true,
    ///   "stringValue": "true"
    /// </code>
    /// <para>
    /// If inputs were always in JSON form, you'd see a similar difference. For example, if an
    /// input appears in a query string, <c>http://example.com/?x=true</c> would unambiguously
    /// mean that the parameter x has the JSON boolean value <c>true</c>, whereas if we wanted a
    /// string value, we'd use <c>http://example.com/?x=%22true%22</c>. But in practice, it's
    /// unusual for web sites to use this convention. In practice, all query string parameters
    /// have string values, and it's up to the web server whether it chooses to interpret them
    /// as having a particular format.
    /// </para>
    /// <para>
    /// For this reason, this interface expects incoming string values to be unquoted, because
    /// in most cases they are. (The one exception is if the entire request body is a single
    /// string. If the request <c>Content-Type</c> is <c>application/json</c> then it must be
    /// enclosing in double quotes. But for anything other than the body, those quotes will not
    /// be present in the raw inputs. We could have insisted on consistency here, but that would
    /// have required almost all calls to <see cref="ConvertFrom(string, OpenApiSchema)"/>
    /// to create new strings wrapping the existing input values in quotes. This would add noise
    /// to the code, and require additional string allocations, so instead, we just live with
    /// asymmetry in this interface.
    /// </para>
    /// </remarks>
    public interface IOpenApiConverter
    {
        /// <summary>
        /// Determine if the converter can handle a particular schema.
        /// </summary>
        /// <param name="schema">The schema to handle.</param>
        /// <param name="ignoreFormat">Whether it can convert if the format is ignored.</param>
        /// <returns>True if this converter can handle the schema.</returns>
        bool CanConvert(OpenApiSchema schema, bool ignoreFormat = false);

        /// <summary>
        /// Convert from the specified content to an object of the required type.
        /// </summary>
        /// <param name="content">
        /// The content to convert. If the input data is of type string, this will not be
        /// enclosed in double quotes.
        /// </param>
        /// <param name="schema">The schema of the content to convert.</param>
        /// <returns>An instance of the converted object.</returns>
        object ConvertFrom(string content, OpenApiSchema schema);

        /// <summary>
        /// Convert to a string representation from an object of the specified type.
        /// </summary>
        /// <param name="instance">The instance to convert.</param>
        /// <param name="schema">The schema of the content to convert.</param>
        /// <returns>
        /// A JSON representation of the converted object for the output document. Unlike with
        /// <see cref="ConvertFrom(string, OpenApiSchema)"/>, if the data is a JSON string,
        /// it will be enclosed in double quotes.
        /// </returns>
        string ConvertTo(object instance, OpenApiSchema schema);
    }
}