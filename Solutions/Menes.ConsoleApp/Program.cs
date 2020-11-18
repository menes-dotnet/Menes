// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using Menes.Json;

    /// <summary>
    /// Console app for the Menes type generator.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main program entry point.
        /// </summary>
        public static void Main()
        {
            var test = new Test(default(Test));
        }

        /// <summary>
        /// A test <see cref="IJsonValue"/>.
        /// </summary>
        public readonly struct Test : IJsonValue
        {
            private readonly JsonValueBacking child;
#pragma warning disable SA1309 // Field names should not begin with underscore
            private readonly JsonElement _menesBackingElement;
#pragma warning restore SA1309 // Field names should not begin with underscore

            /// <summary>
            /// Initializes a new instance of the <see cref="Test"/> struct.
            /// </summary>
            /// <param name="child">The optional child.</param>
            public Test(Test? child = null)
            {
                this.child = JsonValueBacking.From(child);
                this._menesBackingElement = default;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Test"/> struct.
            /// </summary>
            /// <param name="jsonElement">The <see cref="JsonElement"/> backing this instance.</param>
            public Test(JsonElement jsonElement)
            {
                this.child = default;
                this._menesBackingElement = jsonElement;
            }

            /// <summary>
            /// Gets the child value.
            /// </summary>
            public Test? Child => this.child.Value<Test>();

            /// <inheritdoc/>
            public bool IsUndefined => this.JsonElement.ValueKind == JsonValueKind.Undefined && this.AllBackingFieldsAreNull();

            /// <inheritdoc/>
            public bool IsNull => (this.JsonElement.ValueKind == JsonValueKind.Undefined || this.JsonElement.ValueKind == JsonValueKind.Null) && this.AllBackingFieldsAreNull();

            /// <inheritdoc/>
            public bool HasJsonElement => this.JsonElement.ValueKind != JsonValueKind.Undefined;

            /// <inheritdoc/>
            public JsonElement JsonElement => this._menesBackingElement;

            /// <inheritdoc/>
            public T As<T>()
                where T : struct, IJsonValue
            {
                throw new NotImplementedException();
            }

            /// <inheritdoc/>
            public bool Is<T>()
                where T : struct, IJsonValue
            {
                throw new NotImplementedException();
            }

            /// <inheritdoc/>
            public bool TryGetProperty<T>(ReadOnlySpan<char> propertyName, out T property)
                where T : struct, IJsonValue
            {
                throw new NotImplementedException();
            }

            /// <inheritdoc/>
            public bool TryGetProperty<T>(string propertyName, out T property)
                where T : struct, IJsonValue
            {
                throw new NotImplementedException();
            }

            /// <inheritdoc/>
            public bool TryGetProperty<T>(ReadOnlySpan<byte> utf8PropertyName, out T property)
                where T : struct, IJsonValue
            {
                throw new NotImplementedException();
            }

            /// <inheritdoc/>
            public ValidationResult Validate(ValidationResult? validationContext = null, ValidationLevel level = ValidationLevel.Flag, HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)
            {
                throw new NotImplementedException();
            }

            /// <inheritdoc/>
            public void WriteTo(Utf8JsonWriter writer)
            {
                throw new NotImplementedException();
            }

            private bool AllBackingFieldsAreNull()
            {
                if (this.child.IsNull)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
