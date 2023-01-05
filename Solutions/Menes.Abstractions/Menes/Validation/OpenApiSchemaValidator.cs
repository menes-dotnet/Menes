//-----------------------------------------------------------------------
// <copyright file="OpenApiSchemaValidator.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <license>https://github.com/rsuter/NJsonSchema/blob/master/LICENSE.md</license>
// <author>Derived from code (c) Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

namespace Menes.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Text.Json.Nodes;
    using System.Text.RegularExpressions;

    using Menes.Exceptions;

    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Any;
    using Microsoft.OpenApi.Models;
    using Microsoft.OpenApi.Writers;

    /// <summary>Class to validate a JSON schema against a given <see cref="JsonElement"/>. </summary>
    public class OpenApiSchemaValidator
    {
        private static readonly IEnumerable<JsonObjectType> JsonObjectTypes = Enum
            .GetValues(typeof(JsonObjectType))
            .Cast<JsonObjectType>()
            .Where(t => t != JsonObjectType.None)
            .ToList();

        private static readonly JsonDocument JsonNullDoc = JsonDocument.Parse("null");
        private static JsonElement NullElement => JsonNullDoc.RootElement;

        private readonly ILogger<OpenApiSchemaValidator> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiSchemaValidator"/> class.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        public OpenApiSchemaValidator(ILogger<OpenApiSchemaValidator> logger)
        {
            this.logger = logger;
        }

        /// <summary>Validates the given data, throwing an <see cref="OpenApiInvalidFormatException"/> augmented with <see cref="OpenApiProblemDetailsExtensions"/> detailing the errors.</summary>
        /// <param name="data">The data.</param>
        /// <param name="schema">The schema.</param>
        public void ValidateAndThrow(string data, OpenApiSchema schema)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug("Attempting to validate data to [{schema}]", schema.GetLoggingInformation());
            }

            ICollection<ValidationError> errors = Validate(data, schema);

            if (errors.Count > 0)
            {
                Exception exception = new OpenApiInvalidFormatException("Schema Validation Error", "The content does not conform to the required schema.")
                    .AddProblemDetailsExtension("validationErrors", errors);

                this.logger.LogError(
                    "Failed to validate data to [{schema}], The content does not conform to the required schema, [{errors}]",
                    schema.GetLoggingInformation(),
                    errors.Select(error => new { error.Kind, error.Property, error.LineNumber, error.LinePosition }));
                throw exception;
            }
        }

        /// <summary>Validates the given data, throwing an <see cref="OpenApiInvalidFormatException"/> augmented with <see cref="OpenApiProblemDetailsExtensions"/> detailing the errors.</summary>
        /// <param name="data">The data.</param>
        /// <param name="schema">The schema.</param>
        public void ValidateAndThrow(JsonElement? data, OpenApiSchema schema)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug("Attempting to validate data to [{schema}]", schema.GetLoggingInformation());
            }

            ICollection<ValidationError> errors = Validate(data ?? NullElement, schema, null, string.Empty);

            if (errors.Count > 0)
            {
                Exception exception = new OpenApiInvalidFormatException("Schema Validation Error", "The content does not conform to the required schema.")
                    .AddProblemDetailsExtension("validationErrors", errors);

                throw exception;
            }
        }

        /// <summary>Validates the given data.</summary>
        /// <param name="data">The data.</param>
        /// <param name="schema">The schema.</param>
        /// <returns>The list of validation errors.</returns>
        private static ICollection<ValidationError> Validate(string data, OpenApiSchema schema)
        {
            // There is a problem here. Sometimes we are passed data in its native form, and sometimes
            // in JSON form. For example, a string will generally just be a plain .NET string (whereas the
            // JSON version would need the string to start and end with a double quote character). An
            // object on the other hand will start with a '{' character; an array with a '['.
            // In theory we can work out what to expect based on the schema type. But this gets messy when
            // features such as AnyOf get used.
            // Really, we should just require that data always be passed in JSON form, meaning that if the
            // JSON representation includes quotes, the string should have those quotes inside it.
            if (schema.Type != "string")
            {
                try
                {
                    using var doc = JsonDocument.Parse(data);
                    return Validate(doc.RootElement, schema, null, string.Empty);
                }
                catch (System.Text.Json.JsonException x)
                {
                    throw new OpenApiInvalidFormatException($"Expected JSON object or array, but could not parse: {x.Message}");
                }
            }
            else
            {
                return Validate(JsonSerializer.Deserialize<JsonElement>(JsonValue.Create(data)?.ToJsonString() ?? "null"), schema, null, string.Empty);
            }
        }

        /////// <summary>Validates the given JSON token.</summary>
        /////// <param name="token">The token.</param>
        /////// <param name="schema">The schema.</param>
        /////// <returns>The list of validation errors.</returns>
        ////private static ICollection<ValidationError> Validate(JsonElement token, OpenApiSchema schema)
        ////{
        ////    return Validate(token, schema, null, token.Path);
        ////}

        /// <summary>Validates the given JSON token.</summary>
        /// <param name="token">The token.</param>
        /// <param name="schema">The schema.</param>
        /// <param name="propertyName">The current property name.</param>
        /// <param name="propertyPath">The current property path.</param>
        /// <returns>The list of validation errors.</returns>
        private static ICollection<ValidationError> Validate(JsonElement token, OpenApiSchema schema, string? propertyName, string propertyPath)
        {
            var errors = new List<ValidationError>();

            ValidateAnyOf(token, schema, propertyName, propertyPath, errors);
            ValidateAllOf(token, schema, propertyName, propertyPath, errors);
            ValidateOneOf(token, schema, propertyName, propertyPath, errors);
            ValidateNot(token, schema, propertyName, propertyPath, errors);
            ValidateType(token, schema, propertyName, propertyPath, errors);
            ValidateEnum(token, schema, propertyName, propertyPath, errors);
            ValidateProperties(token, schema, propertyName, propertyPath, errors);

            return errors;
        }

        private static void ValidateType(JsonElement token, OpenApiSchema schema, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            var types = GetTypes(schema).ToDictionary(t => t, _ => (ICollection<ValidationError>)new List<ValidationError>());

            if (types.Count > 1)
            {
                foreach (KeyValuePair<JsonObjectType, ICollection<ValidationError>> type in types)
                {
                    ValidateArray(token, schema, type.Key, propertyName, propertyPath, (List<ValidationError>)type.Value);
                    ValidateString(token, schema, type.Key, propertyName, propertyPath, (List<ValidationError>)type.Value);
                    ValidateNumber(token, schema, type.Key, propertyName, propertyPath, (List<ValidationError>)type.Value);
                    ValidateInteger(token, schema, type.Key, propertyName, propertyPath, (List<ValidationError>)type.Value);
                    ValidateBoolean(token, schema, type.Key, propertyName, propertyPath, (List<ValidationError>)type.Value);
                    ValidateNull(token, schema, type.Key, propertyName, propertyPath, (List<ValidationError>)type.Value);
                    ValidateObject(token, schema, type.Key, propertyName, propertyPath, (List<ValidationError>)type.Value);
                }

                // just one has to validate when multiple types are defined
                if (types.All(t => t.Value.Count > 0))
                {
                    errors.Add(new MultiTypeValidationError(ValidationErrorKind.NoTypeValidates, propertyName, propertyPath, types, token, schema));
                }
            }
            else
            {
                JsonObjectType jsonObjectType = ToJsonObjectType(schema.Type);

                ValidateArray(token, schema, jsonObjectType, propertyName, propertyPath, errors);
                ValidateString(token, schema, jsonObjectType, propertyName, propertyPath, errors);
                ValidateNumber(token, schema, jsonObjectType, propertyName, propertyPath, errors);
                ValidateInteger(token, schema, jsonObjectType, propertyName, propertyPath, errors);
                ValidateBoolean(token, schema, jsonObjectType, propertyName, propertyPath, errors);
                ValidateNull(token, schema, jsonObjectType, propertyName, propertyPath, errors);
                ValidateObject(token, schema, jsonObjectType, propertyName, propertyPath, errors);
            }
        }

        private static JsonObjectType ToJsonObjectType(string type)
        {
            return type switch
            {
                "none" => JsonObjectType.None,
                "array" => JsonObjectType.Array,
                "boolean" => JsonObjectType.Boolean,
                "integer" => JsonObjectType.Integer,
                "null" => JsonObjectType.Null,
                "number" => JsonObjectType.Number,
                "object" => JsonObjectType.Object,
                null => JsonObjectType.None,
                "string" => JsonObjectType.String,
                "File" => JsonObjectType.File,
                _ => throw new ArgumentOutOfRangeException(nameof(type)),
            };
        }

        private static IEnumerable<JsonObjectType> GetTypes(OpenApiSchema schema)
        {
            JsonObjectType jsonObjectType = ToJsonObjectType(schema.Type);
            return JsonObjectTypes.Where(t => (jsonObjectType & t) != 0);
        }

        private static void ValidateAnyOf(JsonElement token, OpenApiSchema schema, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (schema.AnyOf.Count > 0)
            {
                var propertyErrors = schema.AnyOf.ToDictionary(s => s, s => Validate(token, s, propertyName, propertyPath));
                if (propertyErrors.All(s => s.Value.Count != 0))
                {
                    errors.Add(new ChildSchemaValidationError(ValidationErrorKind.NotAnyOf, propertyName, propertyPath, propertyErrors, token, schema));
                }
            }
        }

        private static void ValidateAllOf(JsonElement token, OpenApiSchema schema, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (schema.AllOf.Count > 0)
            {
                var propertyErrors = schema.AllOf.ToDictionary(s => s, s => Validate(token, s, propertyName, propertyPath));
                if (propertyErrors.Any(s => s.Value.Count != 0))
                {
                    errors.Add(new ChildSchemaValidationError(ValidationErrorKind.NotAllOf, propertyName, propertyPath, propertyErrors, token, schema));
                }
            }
        }

        private static void ValidateOneOf(JsonElement token, OpenApiSchema schema, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (schema.OneOf.Count > 0)
            {
                var propertyErrors = schema.OneOf.ToDictionary(s => s, s => Validate(token, s, propertyName, propertyPath));
                if (propertyErrors.Count(s => s.Value.Count == 0) != 1)
                {
                    errors.Add(new ChildSchemaValidationError(ValidationErrorKind.NotOneOf, propertyName, propertyPath, propertyErrors, token, schema));
                }
            }
        }

        private static void ValidateNot(JsonElement token, OpenApiSchema schema, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (schema.Not != null)
            {
                if (Validate(token, schema.Not, propertyName, propertyPath).Count == 0)
                {
                    errors.Add(new ValidationError(ValidationErrorKind.ExcludedSchemaValidates, propertyName, propertyPath, token, schema));
                }
            }
        }

        private static void ValidateNull(JsonElement token, OpenApiSchema schema, JsonObjectType type, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if ((type & JsonObjectType.Null) != 0)
            {
                if (token.ValueKind != JsonValueKind.Null)
                {
                    errors.Add(new ValidationError(ValidationErrorKind.NullExpected, propertyName, propertyPath, token, schema));
                }
            }
        }

        private static void ValidateEnum(JsonElement token, OpenApiSchema schema, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (schema.Enum.Any(e => e.AnyType == AnyType.Null) && token.ValueKind == JsonValueKind.Null)
            {
                return;
            }

            if (schema.Enum.Count > 0 && schema.Enum.All(v => WriteToString(v) != token.ToString()))
            {
                errors.Add(new ValidationError(ValidationErrorKind.NotInEnumeration, propertyName, propertyPath, token, schema));
            }
        }

        private static string WriteToString(IOpenApiAny v)
        {
            using var textWriter = new StringWriter();
            var openApiWriter = new OpenApiJsonWriter(textWriter);
            openApiWriter.WriteAny(v);
            textWriter.Flush();
            return textWriter.ToString().Trim('"');
        }

        private static void ValidateString(JsonElement token, OpenApiSchema schema, JsonObjectType type, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (IsNullableFieldAndValueIsNull(token, schema))
            {
                return;
            }

            bool isString = token.ValueKind == JsonValueKind.String;

            if (isString)
            {
                string? value = token.GetString();
                if (value != null)
                {
                    if (!string.IsNullOrEmpty(schema.Pattern))
                    {
                        if (!Regex.IsMatch(value, schema.Pattern))
                        {
                            errors.Add(new ValidationError(ValidationErrorKind.PatternMismatch, propertyName, propertyPath, token, schema));
                        }
                    }

                    if (schema.MinLength.HasValue && value.Length < schema.MinLength)
                    {
                        errors.Add(new ValidationError(ValidationErrorKind.StringTooShort, propertyName, propertyPath, token, schema));
                    }

                    if (schema.MaxLength.HasValue && value.Length > schema.MaxLength)
                    {
                        errors.Add(new ValidationError(ValidationErrorKind.StringTooLong, propertyName, propertyPath, token, schema));
                    }

                    if (!string.IsNullOrEmpty(schema.Format))
                    {
                        if (schema.Format == JsonFormatStrings.DateTime)
                        {
                            string[] acceptableFormats = new string[]
                            {
                                "yyyy-MM-dd'T'HH:mm:ss.FFFK",
                                "yyyy-MM-dd' 'HH:mm:ss.FFFK",
                                "yyyy-MM-dd'T'HH:mm:ssK",
                                "yyyy-MM-dd' 'HH:mm:ssK",
                                "yyyy-MM-dd'T'HH:mm:ss",
                                "yyyy-MM-dd' 'HH:mm:ss",
                                "yyyy-MM-dd'T'HH:mm",
                                "yyyy-MM-dd' 'HH:mm",
                                "yyyy-MM-dd'T'HH",
                                "yyyy-MM-dd' 'HH",
                                "yyyy-MM-dd",
                                "yyyy-MM-dd",
                                "yyyyMMdd",
                                "yyyy-MM",
                                "yyyy",
                            };
                            if (!DateTimeOffset.TryParseExact(value, acceptableFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                            {
                                errors.Add(new ValidationError(ValidationErrorKind.DateTimeExpected, propertyName, propertyPath, token, schema));
                            }
                        }

                        if (schema.Format == JsonFormatStrings.Date)
                        {
                            if (!DateTime.TryParseExact(value, "yyyy-MM-dd", null, DateTimeStyles.None, out DateTime dateTimeResult) || dateTimeResult.Date != dateTimeResult)
                            {
                                errors.Add(new ValidationError(ValidationErrorKind.DateExpected, propertyName, propertyPath, token, schema));
                            }
                        }

                        if (schema.Format == JsonFormatStrings.Time)
                        {
                            if (!DateTime.TryParseExact(value, "HH:mm:ss.FFFFFFFK", null, DateTimeStyles.None, out _))
                            {
                                errors.Add(new ValidationError(ValidationErrorKind.TimeExpected, propertyName, propertyPath, token, schema));
                            }
                        }

                        if (schema.Format == JsonFormatStrings.TimeSpan)
                        {
                            if (!TimeSpan.TryParse(value, out _))
                            {
                                errors.Add(new ValidationError(ValidationErrorKind.TimeSpanExpected, propertyName, propertyPath, token, schema));
                            }
                        }

                        if (schema.Format == JsonFormatStrings.Uri)
                        {
                            if (!Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out _))
                            {
                                errors.Add(new ValidationError(ValidationErrorKind.UriExpected, propertyName, propertyPath, token, schema));
                            }
                        }

                        if (schema.Format == JsonFormatStrings.Email)
                        {
                            bool isEmail = Regex.IsMatch(
                                value,
                                @"^\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z$",
                                RegexOptions.IgnoreCase);

                            if (!isEmail)
                            {
                                errors.Add(new ValidationError(ValidationErrorKind.EmailExpected, propertyName, propertyPath, token, schema));
                            }
                        }

                        if (schema.Format == JsonFormatStrings.IpV4)
                        {
                            bool isIpV4 = Regex.IsMatch(
                                value,
                                "^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?).){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$",
                                RegexOptions.IgnoreCase);

                            if (!isIpV4)
                            {
                                errors.Add(new ValidationError(ValidationErrorKind.IpV4Expected, propertyName, propertyPath, token, schema));
                            }
                        }

                        if (schema.Format == JsonFormatStrings.IpV6)
                        {
                            bool isIpV6 = Uri.CheckHostName(value) == UriHostNameType.IPv6;

                            if (!isIpV6)
                            {
                                errors.Add(new ValidationError(ValidationErrorKind.IpV6Expected, propertyName, propertyPath, token, schema));
                            }
                        }

                        if (schema.Format == JsonFormatStrings.Guid)
                        {
                            if (!Guid.TryParse(value, out _))
                            {
                                errors.Add(new ValidationError(ValidationErrorKind.GuidExpected, propertyName, propertyPath, token, schema));
                            }
                        }

                        if (schema.Format == JsonFormatStrings.Hostname)
                        {
                            bool isHostname = Regex.IsMatch(
                                value,
                                "^(([a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9\\-]*[a-zA-Z0-9])\\.)*([A-Za-z0-9]|[A-Za-z0-9][A-Za-z0-9\\-]*[A-Za-z0-9])$",
                                RegexOptions.IgnoreCase);

                            if (!isHostname)
                            {
                                errors.Add(new ValidationError(ValidationErrorKind.HostnameExpected, propertyName, propertyPath, token, schema));
                            }
                        }

#pragma warning disable IDE0079 // The analyzer spuriously sometimes reports the next suppression as redundant
#pragma warning disable CS0618 // Base64 check is used for backward compatibility
                        if (schema.Format == JsonFormatStrings.Byte || schema.Format == JsonFormatStrings.Base64)
#pragma warning restore CS0618, IDE0079
                        {
                            bool isBase64 = (value.Length % 4 == 0) && Regex.IsMatch(value, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);

                            if (!isBase64)
                            {
                                errors.Add(new ValidationError(ValidationErrorKind.Base64Expected, propertyName, propertyPath, token, schema));
                            }
                        }
                    }
                }
            }
            else
            {
                if ((type & JsonObjectType.String) != 0)
                {
                    errors.Add(new ValidationError(ValidationErrorKind.StringExpected, propertyName, propertyPath, token, schema));
                }
            }
        }

        private static void ValidateNumber(JsonElement token, OpenApiSchema schema, JsonObjectType type, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (IsNullableFieldAndValueIsNull(token, schema))
            {
                return;
            }

            if ((type & JsonObjectType.Number) != 0)
            {
                if (token.ValueKind != JsonValueKind.Number)
                {
                    errors.Add(new ValidationError(ValidationErrorKind.NumberExpected, propertyName, propertyPath, token, schema));
                }
            }

            if (token.ValueKind == JsonValueKind.Number)
            {
                try
                {
                    decimal value = token.GetDecimal();

                    if (schema.Minimum.HasValue && ((schema.ExclusiveMinimum == true) ? value <= schema.Minimum : value < schema.Minimum))
                    {
                        errors.Add(new ValidationError(ValidationErrorKind.NumberTooSmall, propertyName, propertyPath, token, schema));
                    }

                    if (schema.Maximum.HasValue && ((schema.ExclusiveMaximum == true) ? value >= schema.Maximum : value > schema.Maximum))
                    {
                        errors.Add(new ValidationError(ValidationErrorKind.NumberTooBig, propertyName, propertyPath, token, schema));
                    }

                    if (schema.MultipleOf.HasValue && value % schema.MultipleOf != 0)
                    {
                        errors.Add(new ValidationError(ValidationErrorKind.NumberNotMultipleOf, propertyName, propertyPath, token, schema));
                    }
                }
                catch (OverflowException)
                {
                    double value = token.GetDouble();

                    if (schema.Minimum.HasValue && ((schema.ExclusiveMinimum == true) ? value <= (double)schema.Minimum : value < (double)schema.Minimum))
                    {
                        errors.Add(new ValidationError(ValidationErrorKind.NumberTooSmall, propertyName, propertyPath, token, schema));
                    }

                    if (schema.Maximum.HasValue && ((schema.ExclusiveMaximum == true) ? value >= (double)schema.Maximum : value > (double)schema.Maximum))
                    {
                        errors.Add(new ValidationError(ValidationErrorKind.NumberTooBig, propertyName, propertyPath, token, schema));
                    }

                    if (schema.MultipleOf.HasValue && value % (double)schema.MultipleOf != 0)
                    {
                        errors.Add(new ValidationError(ValidationErrorKind.NumberNotMultipleOf, propertyName, propertyPath, token, schema));
                    }
                }
            }
        }

        private static void ValidateInteger(JsonElement token, OpenApiSchema schema, JsonObjectType type, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if ((type & JsonObjectType.Integer) != 0)
            {
                if (IsNullableFieldAndValueIsNull(token, schema))
                {
                    return;
                }

                if (token.ValueKind != JsonValueKind.Number || !token.TryGetInt64(out _))
                {
                    errors.Add(new ValidationError(ValidationErrorKind.IntegerExpected, propertyName, propertyPath, token, schema));
                }
            }
        }

        private static void ValidateBoolean(JsonElement token, OpenApiSchema schema, JsonObjectType type, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if ((type & JsonObjectType.Boolean) != 0)
            {
                if (IsNullableFieldAndValueIsNull(token, schema))
                {
                    return;
                }

                if (token.ValueKind != JsonValueKind.True && token.ValueKind != JsonValueKind.False)
                {
                    errors.Add(new ValidationError(ValidationErrorKind.BooleanExpected, propertyName, propertyPath, token, schema));
                }
            }
        }

        private static void ValidateObject(JsonElement token, OpenApiSchema schema, JsonObjectType type, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if ((type & JsonObjectType.Object) != 0)
            {
                if (IsNullableFieldAndValueIsNull(token, schema))
                {
                    return;
                }

                if (token.ValueKind != JsonValueKind.Object)
                {
                    errors.Add(new ValidationError(ValidationErrorKind.ObjectExpected, propertyName, propertyPath, token, schema));
                }
            }
        }

        private static void ValidateProperties(JsonElement token, OpenApiSchema schema, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            JsonObjectType jsonObjectType = ToJsonObjectType(schema.Type);
            if (token.ValueKind == JsonValueKind.Null && (jsonObjectType & JsonObjectType.Null) != 0)
            {
                return;
            }

            foreach (KeyValuePair<string, OpenApiSchema> propertyInfo in schema.Properties)
            {
                string newPropertyPath = !string.IsNullOrEmpty(propertyPath) ? propertyPath + "." + propertyInfo.Key : propertyInfo.Key;

                if (token.ValueKind == JsonValueKind.Object && token.TryGetProperty(propertyInfo.Key, out JsonElement property))
                {
                    ICollection<ValidationError> propertyErrors = Validate(property, propertyInfo.Value, propertyInfo.Key, newPropertyPath);
                    errors.AddRange(propertyErrors);
                }
                else if (schema.Required.Contains(propertyInfo.Key))
                {
                    errors.Add(new ValidationError(ValidationErrorKind.PropertyRequired, propertyInfo.Key, newPropertyPath, token, schema));
                }
            }

            if (token.ValueKind == JsonValueKind.Object)
            {
                var properties = token.EnumerateObject().ToList();

                ValidateMaxProperties(token, properties, schema, propertyName, propertyPath, errors);
                ValidateMinProperties(token, properties, schema, propertyName, propertyPath, errors);

                var additionalProperties = properties.Where(p => !schema.Properties.ContainsKey(p.Name)).ToList();

                ValidateAdditionalProperties(additionalProperties, schema, propertyPath, errors);
            }
        }

        private static void ValidateMaxProperties(JsonElement token, List<JsonProperty> properties, OpenApiSchema schema, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (schema.MaxProperties > 0 && properties.Count > schema.MaxProperties)
            {
                errors.Add(new ValidationError(ValidationErrorKind.TooManyProperties, propertyName, propertyPath, token, schema));
            }
        }

        private static void ValidateMinProperties(JsonElement token, List<JsonProperty> properties, OpenApiSchema schema, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (schema.MinProperties > 0 && properties.Count < schema.MinProperties)
            {
                errors.Add(new ValidationError(ValidationErrorKind.TooFewProperties, propertyName, propertyPath, token, schema));
            }
        }

        private static void ValidateAdditionalProperties(
            List<JsonProperty> additionalProperties,
            OpenApiSchema schema,
            string propertyPath,
            List<ValidationError> errors)
        {
            if (schema.AdditionalProperties != null)
            {
                foreach (JsonProperty property in additionalProperties)
                {
                    string newPropertyPath = !string.IsNullOrEmpty(propertyPath) ? propertyPath + "." + property.Name : property.Name;

                    ChildSchemaValidationError? error = TryCreateChildSchemaError(
                        property.Value,
                        schema.AdditionalProperties,
                        ValidationErrorKind.AdditionalPropertiesNotValid,
                        property.Name,
                        newPropertyPath);
                    if (error != null)
                    {
                        errors.Add(error);
                    }
                }
            }
            else
            {
                if (!schema.AdditionalPropertiesAllowed && additionalProperties.Count > 0)
                {
                    foreach (JsonProperty property in additionalProperties)
                    {
                        string newPropertyPath = !string.IsNullOrEmpty(propertyPath) ? propertyPath + "." + property.Name : property.Name;
                        errors.Add(new ValidationError(ValidationErrorKind.NoAdditionalPropertiesAllowed, property.Name, newPropertyPath, property.Value, schema));
                    }
                }
            }
        }

        private static bool IsNullableFieldAndValueIsNull(JsonElement token, OpenApiSchema schema)
        {
            return schema.Nullable && token.ValueKind == JsonValueKind.Null;
        }

        private static void ValidateArray(JsonElement token, OpenApiSchema schema, JsonObjectType type, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (IsNullableFieldAndValueIsNull(token, schema))
            {
                return;
            }

            if (token.ValueKind == JsonValueKind.Array)
            {
                int arrayLength = token.GetArrayLength();
                if (schema.MinItems > 0 && arrayLength < schema.MinItems)
                {
                    errors.Add(new ValidationError(ValidationErrorKind.TooFewItems, propertyName, propertyPath, token, schema));
                }

                if (schema.MaxItems > 0 && arrayLength > schema.MaxItems)
                {
                    errors.Add(new ValidationError(ValidationErrorKind.TooManyItems, propertyName, propertyPath, token, schema));
                }

                if (schema.UniqueItems == true && arrayLength != token.EnumerateArray().Select(a => a.ToString()).Distinct().Count())
                {
                    errors.Add(new ValidationError(ValidationErrorKind.ItemsNotUnique, propertyName, propertyPath, token, schema));
                }

                int arrayIndex = 0;
                foreach (JsonElement item in token.EnumerateArray())
                {
                    string propertyIndex = string.Format("[{0}]", arrayIndex++);
                    string itemPath = !string.IsNullOrEmpty(propertyPath) ? propertyPath + propertyIndex : propertyIndex;

                    if (schema.Items != null)
                    {
                        ChildSchemaValidationError? error = TryCreateChildSchemaError(item, schema.Items, ValidationErrorKind.ArrayItemNotValid, propertyIndex, itemPath);
                        if (error != null)
                        {
                            errors.Add(error);
                        }
                    }
                }
            }
            else if ((type & JsonObjectType.Array) != 0)
            {
                errors.Add(new ValidationError(ValidationErrorKind.ArrayExpected, propertyName, propertyPath, token, schema));
            }
        }

        private static ChildSchemaValidationError? TryCreateChildSchemaError(JsonElement token, OpenApiSchema schema, ValidationErrorKind errorKind, string propertyName, string path)
        {
            // Note: we do not pass the property name through here, because from the child schema's
            // perspective, we are starting at the root, so we don't want to confuse the validation
            // process by supplying a property name that's meaningless from the perspective of the
            // schema we're validating against.
            // However, we do want to pass the path in so that any errors report the full location.
            ICollection<ValidationError> errors = Validate(token, schema, null, path);
            if (errors.Count == 0)
            {
                return null;
            }

            var errorDictionary = new Dictionary<OpenApiSchema, ICollection<ValidationError>>
            {
                [schema] = errors,
            };

            return new ChildSchemaValidationError(errorKind, propertyName, path, errorDictionary, token, schema);
        }
    }
}