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
    /// <summary>
    /// A type generated from a JsonSchema specification.
    /// </summary>
    public readonly partial struct Parameter
    {
        /// <summary>
        /// Gets this value cast to the 'then' type for the If/Then/Else clause.
        /// </summary>
        public Menes.OpenApiSchema.V31.Document.Parameter.ThenEntity IfEntityMatched
        {
            get
            {
                return this.As<Menes.OpenApiSchema.V31.Document.Parameter.ThenEntity>();
            }
        }

        /// <summary>
        /// Gets a value indicating whether this matches an If/Then case, return the value as the type defined for the then case.
        /// </summary>
        /// <param name = "result">This value cast to the 'then' type, when the 'if' schema matches, otherwise an Undefined instance of the 'then' type.</param>
        /// <returns><c>True</c> if the 'if' case matched, and the 'else' instance was provided.</returns>
        public bool TryMatchIfEntity(out Menes.OpenApiSchema.V31.Document.Parameter.ThenEntity result)
        {
            if (this.As<Menes.OpenApiSchema.V31.Document.Parameter.IfEntity>().IsValid())
            {
                result = this.As<Menes.OpenApiSchema.V31.Document.Parameter.ThenEntity>();
                return true;
            }

            result = Menes.OpenApiSchema.V31.Document.Parameter.ThenEntity.Undefined;
            return false;
        }
    }
}