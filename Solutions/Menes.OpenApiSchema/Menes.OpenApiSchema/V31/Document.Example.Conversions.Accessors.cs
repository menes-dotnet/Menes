//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
using Corvus.Json;

namespace Menes.OpenApiSchema.V31;
public readonly partial struct Document
{
    /// <summary>
    /// A type generated from a JsonSchema specification.
    /// </summary>
    public readonly partial struct Example
    {
        /// <summary>
        /// Gets the value as a <see cref = "Menes.OpenApiSchema.V31.Document.SpecificationExtensions"/>.
        /// </summary>
        public Menes.OpenApiSchema.V31.Document.SpecificationExtensions AsSpecificationExtensions
        {
            get
            {
                return (Menes.OpenApiSchema.V31.Document.SpecificationExtensions)this;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is a valid <see cref = "Menes.OpenApiSchema.V31.Document.SpecificationExtensions"/>.
        /// </summary>
        public bool IsSpecificationExtensions
        {
            get
            {
                return ((Menes.OpenApiSchema.V31.Document.SpecificationExtensions)this).IsValid();
            }
        }

        /// <summary>
        /// Gets the value as a <see cref = "Menes.OpenApiSchema.V31.Document.SpecificationExtensions"/>.
        /// </summary>
        /// <param name = "result">The result of the conversion.</param>
        /// <returns><c>True</c> if the conversion was valid.</returns>
        public bool TryGetAsSpecificationExtensions(out Menes.OpenApiSchema.V31.Document.SpecificationExtensions result)
        {
            result = (Menes.OpenApiSchema.V31.Document.SpecificationExtensions)this;
            return result.IsValid();
        }
    }
}