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
using System.Text.RegularExpressions;
using Corvus.Json;
using Corvus.Json.Internal;

namespace Menes.OpenApiSchema.V31;
public readonly partial struct Document
{
    public readonly partial struct SecurityScheme
    {
        public readonly partial struct TypeHttpBearerEntity
        {
            public readonly partial struct IfEntity
            {
                /// <summary>
                /// A type generated from a JsonSchema specification.
                /// </summary>
                public readonly partial struct SchemeEntity
                {
                    private static Regex __CorvusPatternExpression => new Regex("^[Bb][Ee][Aa][Rr][Ee][Rr]$", RegexOptions.Compiled, TimeSpan.FromSeconds(1));
                }
            }
        }
    }
}