// <copyright file="OpenApiDocumentValidation.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Validation
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.OpenApi.Models;
    using Microsoft.OpenApi.Services;
    using Microsoft.OpenApi.Validations;

    /// <summary>
    /// Extension methods for checking the internal consistency of Open API documents.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Cf <see cref="OpenApiSchemaValidator"/>, which checks JSON documents against a schema.
    /// This, by contrast, peforms various checks to see if the schem itself makes sense.
    /// </para>
    /// <para>
    /// Currently, this only checks one rule: if an object schema lists required properties, and
    /// it is not configured to allow unlisted properties (i.e., if additionalProperties has been
    /// set to false), then all the required properties must have been defined. This turns out to
    /// be a very easy thing to get wrong as a result of typos, and one we run into a lot because,
    /// annoyingly, there's no shortcut for saying "only allow the properties I've defined".
    /// </para>
    /// </remarks>
    public static class OpenApiDocumentValidation
    {
        /// <summary>
        /// Checks an <see cref="OpenApiDocument"/> for internal consistency.
        /// </summary>
        /// <param name="document">The document to check.</param>
        /// <returns>
        /// The results of the validation process.
        /// </returns>
        public static OpenApiDocumentValidationResult ValidateDocument(this OpenApiDocument document)
        {
            var validator = new OpenApiValidator(new ValidationRuleSet(
                new[]
                {
                        new ValidationRule<OpenApiSchema>(ValidateSchema),
                }));
            var walker = new OpenApiWalker(validator);
            walker.Walk(document);

            return new OpenApiDocumentValidationResult(validator.Errors);
        }

        /// <summary>
        /// Checks an <see cref="OpenApiSchema"/> for internal consistency.
        /// </summary>
        /// <param name="context">Validation context, enabling errors to be reported.</param>
        /// <param name="schema">The schema to check.</param>
        public static void ValidateSchema(
            IValidationContext context,
            OpenApiSchema schema)
        {
            if (schema.Type == "object")
            {
                if (!schema.AdditionalPropertiesAllowed)
                {
                    IEnumerable<string> allProperties = EnumerableEx
                        .Return(schema)
                        .Expand(s => s.AdditionalProperties == null ? Enumerable.Empty<OpenApiSchema>() : EnumerableEx.Return(s.AdditionalProperties))
                        .SelectMany(s => s.Properties.Keys);

                    foreach (string propertyName in schema.Required.Except(allProperties))
                    {
                        context.CreateError(
                            "InvalidRequiredProperty",
                            $"Required properties include '{propertyName}', which is not recognized.");
                    }
                }
            }
        }
    }
}
