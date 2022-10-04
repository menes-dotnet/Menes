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
    public readonly partial struct ResponseOrReference
    {
        /// <summary>
        /// Gets the value as a <see cref = "Menes.OpenApiSchema.V31.Document.Reference"/>.
        /// </summary>
        public Menes.OpenApiSchema.V31.Document.Reference AsReference
        {
            get
            {
                return (Menes.OpenApiSchema.V31.Document.Reference)this;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is a valid <see cref = "Menes.OpenApiSchema.V31.Document.Reference"/>.
        /// </summary>
        public bool IsReference
        {
            get
            {
                return ((Menes.OpenApiSchema.V31.Document.Reference)this).IsValid();
            }
        }

        /// <summary>
        /// Gets the value as a <see cref = "Menes.OpenApiSchema.V31.Document.Reference"/>.
        /// </summary>
        /// <param name = "result">The result of the conversion.</param>
        /// <returns><c>True</c> if the conversion was valid.</returns>
        public bool TryGetAsReference(out Menes.OpenApiSchema.V31.Document.Reference result)
        {
            result = (Menes.OpenApiSchema.V31.Document.Reference)this;
            return result.IsValid();
        }

        /// <summary>
        /// Gets the value as a <see cref = "Menes.OpenApiSchema.V31.Document.Response"/>.
        /// </summary>
        public Menes.OpenApiSchema.V31.Document.Response AsResponse
        {
            get
            {
                return (Menes.OpenApiSchema.V31.Document.Response)this;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is a valid <see cref = "Menes.OpenApiSchema.V31.Document.Response"/>.
        /// </summary>
        public bool IsResponse
        {
            get
            {
                return ((Menes.OpenApiSchema.V31.Document.Response)this).IsValid();
            }
        }

        /// <summary>
        /// Gets the value as a <see cref = "Menes.OpenApiSchema.V31.Document.Response"/>.
        /// </summary>
        /// <param name = "result">The result of the conversion.</param>
        /// <returns><c>True</c> if the conversion was valid.</returns>
        public bool TryGetAsResponse(out Menes.OpenApiSchema.V31.Document.Response result)
        {
            result = (Menes.OpenApiSchema.V31.Document.Response)this;
            return result.IsValid();
        }
    }
}