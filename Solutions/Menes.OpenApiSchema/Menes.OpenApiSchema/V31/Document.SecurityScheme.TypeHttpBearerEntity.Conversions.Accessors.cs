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
    public readonly partial struct SecurityScheme
    {
        /// <summary>
        /// A type generated from a JsonSchema specification.
        /// </summary>
        public readonly partial struct TypeHttpBearerEntity
        {
            /// <summary>
            /// Gets the value as a <see cref = "Menes.OpenApiSchema.V31.Document.SecurityScheme.TypeHttpBearerEntity.ThenEntity"/>.
            /// </summary>
            public Menes.OpenApiSchema.V31.Document.SecurityScheme.TypeHttpBearerEntity.ThenEntity AsThenEntity
            {
                get
                {
                    return (Menes.OpenApiSchema.V31.Document.SecurityScheme.TypeHttpBearerEntity.ThenEntity)this;
                }
            }

            /// <summary>
            /// Gets a value indicating whether this is a valid <see cref = "Menes.OpenApiSchema.V31.Document.SecurityScheme.TypeHttpBearerEntity.ThenEntity"/>.
            /// </summary>
            public bool IsThenEntity
            {
                get
                {
                    return ((Menes.OpenApiSchema.V31.Document.SecurityScheme.TypeHttpBearerEntity.ThenEntity)this).IsValid();
                }
            }

            /// <summary>
            /// Gets the value as a <see cref = "Menes.OpenApiSchema.V31.Document.SecurityScheme.TypeHttpBearerEntity.ThenEntity"/>.
            /// </summary>
            /// <param name = "result">The result of the conversion.</param>
            /// <returns><c>True</c> if the conversion was valid.</returns>
            public bool TryGetAsThenEntity(out Menes.OpenApiSchema.V31.Document.SecurityScheme.TypeHttpBearerEntity.ThenEntity result)
            {
                result = (Menes.OpenApiSchema.V31.Document.SecurityScheme.TypeHttpBearerEntity.ThenEntity)this;
                return result.IsValid();
            }
        }
    }
}