//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Corvus.Json;
using Corvus.Json.Internal;

namespace Menes.OpenApiSchema.V31;
public readonly partial struct Document
{
    public readonly partial struct Parameter
    {
        public readonly partial struct SchemaEntity
        {
            public readonly partial struct StylesForFormEntity
            {
                public readonly partial struct ThenEntity
                {
                    /// <summary>
                    /// A type generated from a JsonSchema specification.
                    /// </summary>
                    public readonly partial struct ExplodeEntity : IJsonBoolean<ExplodeEntity>
                    {
                        /// <summary>
                        /// Initializes a new instance of the <see cref = "ExplodeEntity"/> struct.
                        /// </summary>
                        /// <param name = "value">The value from which to construct the instance.</param>
                        public ExplodeEntity(bool value)
                        {
                            this.jsonElementBacking = default;
                            this.backing = Backing.Bool;
                            this.boolBacking = value;
                            this.stringBacking = string.Empty;
                            this.numberBacking = default;
                            this.arrayBacking = ImmutableList<JsonAny>.Empty;
                            this.objectBacking = ImmutableDictionary<JsonPropertyName, JsonAny>.Empty;
                        }

                        /// <summary>
                        /// Conversion from JsonBoolean.
                        /// </summary>
                        /// <param name = "value">The value from which to convert.</param>
                        public static implicit operator JsonBoolean(ExplodeEntity value)
                        {
                            return value.AsBoolean;
                        }

                        /// <summary>
                        /// Conversion to JsonBoolean.
                        /// </summary>
                        /// <param name = "value">The value from which to convert.</param>
                        public static implicit operator ExplodeEntity(JsonBoolean value)
                        {
                            if (value.HasJsonElementBacking)
                            {
                                return new(value.AsJsonElement);
                            }

                            return new((bool)value);
                        }

                        /// <summary>
                        /// Conversion from bool.
                        /// </summary>
                        /// <param name = "value">The value from which to convert.</param>
                        public static implicit operator ExplodeEntity(bool value)
                        {
                            return new(value);
                        }

                        /// <summary>
                        /// Conversion to bool.
                        /// </summary>
                        /// <param name = "value">The value from which to convert.</param>
                        /// <exception cref = "InvalidOperationException">The value was not a string.</exception>
                        public static implicit operator bool (ExplodeEntity value)
                        {
                            if ((value.backing & Backing.JsonElement) != 0)
                            {
                                return value.jsonElementBacking.GetBoolean();
                            }

                            if ((value.backing & Backing.Bool) != 0)
                            {
                                return value.boolBacking;
                            }

                            throw new InvalidOperationException();
                        }
                    }
                }
            }
        }
    }
}