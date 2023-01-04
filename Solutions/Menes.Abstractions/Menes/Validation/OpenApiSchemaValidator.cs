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
    using System.Text.RegularExpressions;
    using Menes.Exceptions;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Any;
    using Microsoft.OpenApi.Models;
    using Microsoft.OpenApi.Writers;
    using Newtonsoft.Json.Linq;

    /// <summary>Class to validate a JSON schema against a given <see cref="JToken"/>. </summary>
    public class OpenApiSchemaValidator
    {
        private static readonly IEnumerable<JsonObjectType> JsonObjectTypes = Enum
            .GetValues(typeof(JsonObjectType))
            .Cast<JsonObjectType>()
            .Where(t => t != JsonObjectType.None)
            .ToList();

        private readonly ILogger<OpenApiSchemaValidator> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiSchemaValidator"/> class.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        public OpenApiSchemaValidator(ILogger<OpenApiSchemaValidator> logger)
        {
            this.logger = logger;
        }

        /// <summary>Validates the given data, throwing an <see cref="OpenApiBadRequestException"/> augmented with <see cref="OpenApiProblemDetailsExtensions"/> detailing the errors.</summary>
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

        /// <summary>Validates the given data, throwing an <see cref="OpenApiBadRequestException"/> augmented with <see cref="OpenApiProblemDetailsExtensions"/> detailing the errors.</summary>
        /// <param name="data">The data.</param>
        /// <param name="schema">The schema.</param>
        public void ValidateAndThrow(JToken? data, OpenApiSchema schema)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug("Attempting to validate data to [{schema}]", schema.GetLoggingInformation());
            }

            data ??= JValue.CreateNull();

            ICollection<ValidationError> errors = Validate(data, schema);

            if (errors.Count > 0)
            {
                Exception exception = new OpenApiBadRequestException("Schema Validation Error", "The content does not conform to the required schema.")
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
            bool dataShouldBeJson = schema.Type == "object" || schema.Type == "array" || schema.Type == null;
            JToken jsonObject = dataShouldBeJson ? JToken.Parse(data) : data;

            return Validate(jsonObject, schema);
        }

        /// <summary>Validates the given JSON token.</summary>
        /// <param name="token">The token.</param>
        /// <param name="schema">The schema.</param>
        /// <returns>The list of validation errors.</returns>
        private static ICollection<ValidationError> Validate(JToken token, OpenApiSchema schema)
        {
            return Validate(token, schema, null, token.Path);
        }

        /// <summary>Validates the given JSON token.</summary>
        /// <param name="token">The token.</param>
        /// <param name="schema">The schema.</param>
        /// <param name="propertyName">The current property name.</param>
        /// <param name="propertyPath">The current property path.</param>
        /// <returns>The list of validation errors.</returns>
        private static ICollection<ValidationError> Validate(JToken token, OpenApiSchema schema, string? propertyName, string propertyPath)
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

        private static void ValidateType(JToken token, OpenApiSchema schema, string? propertyName, string propertyPath, List<ValidationError> errors)
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

        private static void ValidateAnyOf(JToken token, OpenApiSchema schema, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (schema.AnyOf.Count > 0)
            {
                var propertyErrors = schema.AnyOf.ToDictionary(s => s, s => Validate(token, s));
                if (propertyErrors.All(s => s.Value.Count != 0))
                {
                    errors.Add(new ChildSchemaValidationError(ValidationErrorKind.NotAnyOf, propertyName, propertyPath, propertyErrors, token, schema));
                }
            }
        }

        private static void ValidateAllOf(JToken token, OpenApiSchema schema, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (schema.AllOf.Count > 0)
            {
                var propertyErrors = schema.AllOf.ToDictionary(s => s, s => Validate(token, s));
                if (propertyErrors.Any(s => s.Value.Count != 0))
                {
                    errors.Add(new ChildSchemaValidationError(ValidationErrorKind.NotAllOf, propertyName, propertyPath, propertyErrors, token, schema));
                }
            }
        }

        private static void ValidateOneOf(JToken token, OpenApiSchema schema, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (schema.OneOf.Count > 0)
            {
                var propertyErrors = schema.OneOf.ToDictionary(s => s, s => Validate(token, s));
                if (propertyErrors.Count(s => s.Value.Count == 0) != 1)
                {
                    errors.Add(new ChildSchemaValidationError(ValidationErrorKind.NotOneOf, propertyName, propertyPath, propertyErrors, token, schema));
                }
            }
        }

        private static void ValidateNot(JToken token, OpenApiSchema schema, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (schema.Not != null)
            {
                if (Validate(token, schema.Not).Count == 0)
                {
                    errors.Add(new ValidationError(ValidationErrorKind.ExcludedSchemaValidates, propertyName, propertyPath, token, schema));
                }
            }
        }

        private static void ValidateNull(JToken token, OpenApiSchema schema, JsonObjectType type, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if ((type & JsonObjectType.Null) != 0)
            {
                if (token != null && token.Type != JTokenType.Null)
                {
                    errors.Add(new ValidationError(ValidationErrorKind.NullExpected, propertyName, propertyPath, token, schema));
                }
            }
        }

        private static void ValidateEnum(JToken token, OpenApiSchema schema, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (schema.Enum.Any(e => e.AnyType == AnyType.Null) && token.Type == JTokenType.Null)
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

        private static void ValidateString(JToken token, OpenApiSchema schema, JsonObjectType type, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (IsNullableFieldAndValueIsNull(token, schema))
            {
                return;
            }

            bool isString = token.Type == JTokenType.String || token.Type == JTokenType.Date
                           || token.Type == JTokenType.Guid || token.Type == JTokenType.TimeSpan
                           || token.Type == JTokenType.Uri;

            if (isString)
            {
                string? value = token.Type == JTokenType.Date ? (token as JValue)?.ToString("yyyy-MM-ddTHH:mm:ssK") : (token as JValue)?.ToString();
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
                            if (token.Type != JTokenType.Date && !DateTimeOffset.TryParseExact(value, acceptableFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                            {
                                errors.Add(new ValidationError(ValidationErrorKind.DateTimeExpected, propertyName, propertyPath, token, schema));
                            }
                        }

                        if (schema.Format == JsonFormatStrings.Date)
                        {
                            if (token.Type != JTokenType.Date && (!DateTime.TryParseExact(value, "yyyy-MM-dd", null, DateTimeStyles.None, out DateTime dateTimeResult) || dateTimeResult.Date != dateTimeResult))
                            {
                                errors.Add(new ValidationError(ValidationErrorKind.DateExpected, propertyName, propertyPath, token, schema));
                            }
                        }

                        if (schema.Format == JsonFormatStrings.Time)
                        {
                            if (token.Type != JTokenType.Date && !DateTime.TryParseExact(value, "HH:mm:ss.FFFFFFFK", null, DateTimeStyles.None, out _))
                            {
                                errors.Add(new ValidationError(ValidationErrorKind.TimeExpected, propertyName, propertyPath, token, schema));
                            }
                        }

                        if (schema.Format == JsonFormatStrings.TimeSpan)
                        {
                            if (token.Type != JTokenType.TimeSpan && !TimeSpan.TryParse(value, out _))
                            {
                                errors.Add(new ValidationError(ValidationErrorKind.TimeSpanExpected, propertyName, propertyPath, token, schema));
                            }
                        }

                        if (schema.Format == JsonFormatStrings.Uri)
                        {
                            if (token.Type != JTokenType.Uri && !Uri.TryCreate(value, UriKind.Absolute, out _))
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

        private static void ValidateNumber(JToken token, OpenApiSchema schema, JsonObjectType type, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (IsNullableFieldAndValueIsNull(token, schema))
            {
                return;
            }

            if ((type & JsonObjectType.Number) != 0)
            {
                if (token.Type != JTokenType.Float && token.Type != JTokenType.Integer)
                {
                    errors.Add(new ValidationError(ValidationErrorKind.NumberExpected, propertyName, propertyPath, token, schema));
                }
            }

            if (token.Type == JTokenType.Float || token.Type == JTokenType.Integer)
            {
                try
                {
                    decimal value = token.Value<decimal>();

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
                    double value = token.Value<double>();

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

        private static void ValidateInteger(JToken token, OpenApiSchema schema, JsonObjectType type, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if ((type & JsonObjectType.Integer) != 0)
            {
                if (IsNullableFieldAndValueIsNull(token, schema))
                {
                    return;
                }

                if (token.Type != JTokenType.Integer)
                {
                    errors.Add(new ValidationError(ValidationErrorKind.IntegerExpected, propertyName, propertyPath, token, schema));
                }
            }
        }

        private static void ValidateBoolean(JToken token, OpenApiSchema schema, JsonObjectType type, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if ((type & JsonObjectType.Boolean) != 0)
            {
                if (IsNullableFieldAndValueIsNull(token, schema))
                {
                    return;
                }

                if (token.Type != JTokenType.Boolean)
                {
                    errors.Add(new ValidationError(ValidationErrorKind.BooleanExpected, propertyName, propertyPath, token, schema));
                }
            }
        }

        private static void ValidateObject(JToken token, OpenApiSchema schema, JsonObjectType type, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if ((type & JsonObjectType.Object) != 0)
            {
                if (IsNullableFieldAndValueIsNull(token, schema))
                {
                    return;
                }

                if (token is not JObject)
                {
                    errors.Add(new ValidationError(ValidationErrorKind.ObjectExpected, propertyName, propertyPath, token, schema));
                }
            }
        }

        private static void ValidateProperties(JToken token, OpenApiSchema schema, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            JsonObjectType jsonObjectType = ToJsonObjectType(schema.Type);
            var obj = token as JObject;
            if (obj == null && (jsonObjectType & JsonObjectType.Null) != 0)
            {
                return;
            }

            foreach (KeyValuePair<string, OpenApiSchema> propertyInfo in schema.Properties)
            {
                string newPropertyPath = !string.IsNullOrEmpty(propertyPath) ? propertyPath + "." + propertyInfo.Key : propertyInfo.Key;

                JProperty? property = obj?.Property(propertyInfo.Key);
                if (property != null)
                {
                    ICollection<ValidationError> propertyErrors = Validate(property.Value, propertyInfo.Value, propertyInfo.Key, newPropertyPath);
                    errors.AddRange(propertyErrors);
                }
                else if (schema.Required.Contains(propertyInfo.Key))
                {
                    errors.Add(new ValidationError(ValidationErrorKind.PropertyRequired, propertyInfo.Key, newPropertyPath, token, schema));
                }
            }

            if (obj != null)
            {
                var properties = obj.Properties().ToList();

                ValidateMaxProperties(token, properties, schema, propertyName, propertyPath, errors);
                ValidateMinProperties(token, properties, schema, propertyName, propertyPath, errors);

                var additionalProperties = properties.Where(p => !schema.Properties.ContainsKey(p.Name)).ToList();

                ValidateAdditionalProperties(additionalProperties, schema, propertyPath, errors);
            }
        }

        private static void ValidateMaxProperties(JToken token, IList<JProperty> properties, OpenApiSchema schema, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (schema.MaxProperties > 0 && properties.Count > schema.MaxProperties)
            {
                errors.Add(new ValidationError(ValidationErrorKind.TooManyProperties, propertyName, propertyPath, token, schema));
            }
        }

        private static void ValidateMinProperties(JToken token, IList<JProperty> properties, OpenApiSchema schema, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (schema.MinProperties > 0 && properties.Count < schema.MinProperties)
            {
                errors.Add(new ValidationError(ValidationErrorKind.TooFewProperties, propertyName, propertyPath, token, schema));
            }
        }

        private static void ValidateAdditionalProperties(
            List<JProperty> additionalProperties,
            OpenApiSchema schema,
            string propertyPath,
            List<ValidationError> errors)
        {
            if (schema.AdditionalProperties != null)
            {
                foreach (JProperty property in additionalProperties)
                {
                    ChildSchemaValidationError? error = TryCreateChildSchemaError(
                        property.Value,
                        schema.AdditionalProperties,
                        ValidationErrorKind.AdditionalPropertiesNotValid,
                        property.Name,
                        property.Path);
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
                    foreach (JProperty property in additionalProperties)
                    {
                        string newPropertyPath = !string.IsNullOrEmpty(propertyPath) ? propertyPath + "." + property.Name : property.Name;
                        errors.Add(new ValidationError(ValidationErrorKind.NoAdditionalPropertiesAllowed, property.Name, newPropertyPath, property, schema));
                    }
                }
            }
        }

        private static bool IsNullableFieldAndValueIsNull(JToken token, OpenApiSchema schema)
        {
            return schema.Nullable && token?.Type == JTokenType.Null;
        }

        private static void ValidateArray(JToken token, OpenApiSchema schema, JsonObjectType type, string? propertyName, string propertyPath, List<ValidationError> errors)
        {
            if (IsNullableFieldAndValueIsNull(token, schema))
            {
                return;
            }

            if (token is JArray array)
            {
                if (schema.MinItems > 0 && array.Count < schema.MinItems)
                {
                    errors.Add(new ValidationError(ValidationErrorKind.TooFewItems, propertyName, propertyPath, token, schema));
                }

                if (schema.MaxItems > 0 && array.Count > schema.MaxItems)
                {
                    errors.Add(new ValidationError(ValidationErrorKind.TooManyItems, propertyName, propertyPath, token, schema));
                }

                if (schema.UniqueItems == true && array.Count != array.Select(a => a.ToString()).Distinct().Count())
                {
                    errors.Add(new ValidationError(ValidationErrorKind.ItemsNotUnique, propertyName, propertyPath, token, schema));
                }

                for (int index = 0; index < array.Count; index++)
                {
                    JToken item = array[index];

                    string propertyIndex = string.Format("[{0}]", index);
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

        private static  ChildSchemaValidationError? TryCreateChildSchemaError(JToken token, OpenApiSchema schema, ValidationErrorKind errorKind, string propertyName, string path)
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