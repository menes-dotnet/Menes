// <copyright file="ResultBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// Derived from Tavis.UriTemplate https://github.com/tavis-software/Tavis.UriTemplates/blob/master/License.txt

namespace Menes.Json.UriTemplates
{
    using System;
    using System.Collections.Immutable;
    using System.Text;

    /// <summary>
    /// A result builder for a parameter set in a URI template.
    /// </summary>
    internal ref struct ResultBuilder
    {
        private const string UriReservedSymbols = ":/?#[]@!$&'()*+,;=";
        private const string UriUnreservedSymbols = "-._~";
        private static readonly char[] HexDigits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        private readonly StringBuilder result;
        private readonly ImmutableArray<string>.Builder parameterNames;

        private ResultBuilder(StringBuilder result, ImmutableArray<string>.Builder parameterNames)
        {
            this.result = result;
            this.parameterNames = parameterNames;
            this.ErrorDetected = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether an error has been detected.
        /// </summary>
        public bool ErrorDetected { get; set; }

        /// <summary>
        /// Gets the parameter names.
        /// </summary>
        public ImmutableArray<string> ParameterNames => this.parameterNames.ToImmutable();

        /// <summary>
        /// Gets an instance of a <see cref="ResultBuilder"/>.
        /// </summary>
        /// <returns>The empty result builder.</returns>
        public static ResultBuilder Get()
        {
            return new ResultBuilder(StringBuilderPool.Shared.Get(), ImmutableArray.CreateBuilder<string>());
        }

        /// <summary>
        /// Returns an instance of the result builder.
        /// </summary>
        /// <param name="builder">The builder to return.</param>
        public static void Return(ref ResultBuilder builder)
        {
            StringBuilderPool.Shared.Return(builder.result);
        }

        /// <summary>
        /// Adds a parameter name to the result set.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        public void AddParameterName(string parameterName)
        {
            this.parameterNames.Add(parameterName);
        }

        /// <summary>
        /// Appends a character to the result.
        /// </summary>
        /// <param name="value">The character to append.</param>
        public void Append(char value)
        {
            this.result.Append(value);
        }

        /// <summary>
        /// Appends a string to the result.
        /// </summary>
        /// <param name="value">The string to append.</param>
        /// <returns>The updated string.</returns>
        public StringBuilder Append(ReadOnlySpan<char> value)
        {
            return this.result.Append(value);
        }

        /// <summary>
        /// Gets the result as a string.
        /// </summary>
        /// <returns>The result as a string.</returns>
        public override string ToString()
        {
            return this.result.ToString();
        }

        /// <summary>
        /// Append a variable to the result.
        /// </summary>
        /// <param name="variable">The variable name.</param>
        /// <param name="op">The operator info.</param>
        /// <param name="valueIsEmpty">True if the value is empty.</param>
        public void AppendName(string variable, in OperatorInfo op, bool valueIsEmpty)
        {
            this.result.Append(variable);
            if (valueIsEmpty)
            {
                this.result.Append(op.IfEmpty);
            }
            else
            {
                this.result.Append("=");
            }
        }

        /// <summary>
        /// Append an array to the result.
        /// </summary>
        /// <param name="op">The operator info.</param>
        /// <param name="explode">Whether to explode the array.</param>
        /// <param name="variable">The variable name.</param>
        /// <param name="array">The array to add.</param>
        public void AppendArray(in OperatorInfo op, bool explode, string variable, in JsonArray array)
        {
            foreach (JsonAny item in array.EnumerateArray())
            {
                if (op.Named && explode)
                {
                    this.result.Append(variable);
                    this.result.Append("=");
                }

                this.AppendValue(item, 0, op.AllowReserved);

                this.result.Append(explode ? op.Separator : ',');
            }

            if (array.Length > 0)
            {
                this.result.Remove(this.result.Length - 1, 1);
            }
        }

        /// <summary>
        /// Append an object to the output.
        /// </summary>
        /// <param name="op">The operator info.</param>
        /// <param name="explode">Whether to explode the object.</param>
        /// <param name="instance">The object instance to append.</param>
        public void AppendObject(in OperatorInfo op, bool explode, JsonObject instance)
        {
            foreach (Property value in instance.EnumerateObject())
            {
                string name = value.Name;
                Span<char> output = stackalloc char[Encoding.UTF8.GetMaxByteCount(name.Length) * 3];
                int written = Encode(name.AsSpan(), output, op.AllowReserved);
                this.result.Append(output.Slice(0, written));
                if (explode)
                {
                    this.result.Append('=');
                }
                else
                {
                    this.result.Append(',');
                }

                this.AppendValue(value.Value, 0, op.AllowReserved);

                if (explode)
                {
                    this.result.Append(op.Separator);
                }
                else
                {
                    this.result.Append(',');
                }
            }

            if (instance.HasProperties())
            {
                this.result.Remove(this.result.Length - 1, 1);
            }
        }

        /// <summary>
        /// Appends a value to the result.
        /// </summary>
        /// <param name="value">The value to append.</param>
        /// <param name="prefixLength">The prefix length.</param>
        /// <param name="allowReserved">Whether to allow reserved characters.</param>
        public void AppendValue(JsonAny value, int prefixLength, bool allowReserved)
        {
            ReadOnlySpan<char> valueString;
            valueString = value.ToString();

            if (prefixLength != 0)
            {
                if (prefixLength < valueString.Length)
                {
                    valueString = valueString.Slice(0, prefixLength);
                }
            }

            Span<char> result = stackalloc char[Encoding.UTF8.GetMaxByteCount(valueString.Length) * 3];
            int written = Encode(valueString, result, allowReserved);
            this.result.Append(result.Slice(0, written));
        }

        private static int Encode(ReadOnlySpan<char> p, Span<char> result, bool allowReserved)
        {
            int written = 0;
            foreach (char c in p)
            {
                if ((c >= 'A' && c <= 'z')                                      //// Alpha
                    || (c >= '0' && c <= '9')                                   //// Digit
                    || UriUnreservedSymbols.IndexOf(c) != -1                    //// Unreserved symbols  - These should never be percent encoded
                    || (allowReserved && UriReservedSymbols.IndexOf(c) != -1))  //// Reserved symbols - should be included if requested (+)
                {
                    result[written++] = c;
                }
                else
                {
                    Span<char> source = stackalloc char[1];
                    source[0] = c;
                    Span<byte> bytes = stackalloc byte[Encoding.UTF8.GetMaxByteCount(1)];
                    int encoded = Encoding.UTF8.GetBytes(source, bytes);
                    foreach (byte abyte in bytes.Slice(0, encoded))
                    {
                        result[written++] = '%';
                        result[written++] = HexDigits[(abyte & 240) >> 4];
                        result[written++] = HexDigits[abyte & 15];
                    }
                }
            }

            return written;
        }
    }
}