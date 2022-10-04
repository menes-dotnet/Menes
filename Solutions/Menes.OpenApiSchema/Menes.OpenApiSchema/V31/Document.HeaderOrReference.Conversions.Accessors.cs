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
    public readonly partial struct HeaderOrReference
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
        /// Gets the value as a <see cref = "Menes.OpenApiSchema.V31.Document.Header"/>.
        /// </summary>
        public Menes.OpenApiSchema.V31.Document.Header AsHeader
        {
            get
            {
                return (Menes.OpenApiSchema.V31.Document.Header)this;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is a valid <see cref = "Menes.OpenApiSchema.V31.Document.Header"/>.
        /// </summary>
        public bool IsHeader
        {
            get
            {
                return ((Menes.OpenApiSchema.V31.Document.Header)this).IsValid();
            }
        }

        /// <summary>
        /// Gets the value as a <see cref = "Menes.OpenApiSchema.V31.Document.Header"/>.
        /// </summary>
        /// <param name = "result">The result of the conversion.</param>
        /// <returns><c>True</c> if the conversion was valid.</returns>
        public bool TryGetAsHeader(out Menes.OpenApiSchema.V31.Document.Header result)
        {
            result = (Menes.OpenApiSchema.V31.Document.Header)this;
            return result.IsValid();
        }
    }
}