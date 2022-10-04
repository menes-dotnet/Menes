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
    public readonly partial struct ExampleOrReference
    {
        /// <summary>
        /// Gets this value cast to the 'then' type for the If/Then/Else clause.
        /// </summary>
        public Menes.OpenApiSchema.V31.Document.Reference IfEntityMatched
        {
            get
            {
                return this.As<Menes.OpenApiSchema.V31.Document.Reference>();
            }
        }

        /// <summary>
        /// Gets this value cast to the 'else' type for the If/Then/Else clause.
        /// </summary>
        public Menes.OpenApiSchema.V31.Document.Example IfEntityNotMatched
        {
            get
            {
                return this.As<Menes.OpenApiSchema.V31.Document.Example>();
            }
        }

        /// <summary>
        /// Gets a value indicating whether this matches an If/Then case, return the value as the type defined for the then case.
        /// </summary>
        /// <param name = "result">This value cast to the 'then' type, when the 'if' schema matches, otherwise an Undefined instance of the 'then' type.</param>
        /// <returns><c>True</c> if the 'if' case matched, and the 'else' instance was provided.</returns>
        public bool TryMatchIfEntity(out Menes.OpenApiSchema.V31.Document.Reference result)
        {
            if (this.As<Menes.OpenApiSchema.V31.Document.ExampleOrReference.IfEntity>().IsValid())
            {
                result = this.As<Menes.OpenApiSchema.V31.Document.Reference>();
                return true;
            }

            result = Menes.OpenApiSchema.V31.Document.Reference.Undefined;
            return false;
        }

        /// <summary>
        /// Gets a value indicating whether this matches an If/Then/Else case, providing the 'else' type when the 'if' schema does not match.
        /// </summary>
        /// <param name = "result">This value cast to the 'else' type, when the 'if' schema does not match, otherwise an Undefined instance of the else type.</param>
        /// <returns><c>True</c> if the if case did not match, and the else instance was provided.</returns>
        public bool TryNotMatchedIfEntity(out Menes.OpenApiSchema.V31.Document.Example result)
        {
            if (!this.As<Menes.OpenApiSchema.V31.Document.ExampleOrReference.IfEntity>().IsValid())
            {
                result = this.As<Menes.OpenApiSchema.V31.Document.Example>();
                return true;
            }

            result = Menes.OpenApiSchema.V31.Document.Example.Undefined;
            return false;
        }
    }
}