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
    public readonly partial struct SecurityScheme
    {
        public readonly partial struct TypeHttpEntity
        {
            public readonly partial struct IfEntity
            {
                /// <summary>
                /// A type generated from a JsonSchema specification.
                /// </summary>
                public readonly partial struct TypeEntity
                {
                    private static readonly TypeEntity __CorvusConstValue = JsonAny.Parse("\"http\"");
                    /// <summary>
                    /// Initializes a new instance of the <see cref = "TypeEntity"/> struct.
                    /// </summary>
                    public TypeEntity()
                    {
                        this.jsonElementBacking = __CorvusConstValue.jsonElementBacking;
                        this.stringBacking = __CorvusConstValue.stringBacking;
                        this.backing = __CorvusConstValue.backing;
                    }

                    /// <summary>
                    /// Gets the constant value for this instance
                    /// </summary>
                    public static TypeEntity ConstInstance => __CorvusConstValue;
                }
            }
        }
    }
}