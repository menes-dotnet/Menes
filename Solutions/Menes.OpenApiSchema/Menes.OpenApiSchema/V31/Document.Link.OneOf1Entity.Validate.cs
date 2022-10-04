//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
using System.Text.Json;
using Corvus.Json;

namespace Menes.OpenApiSchema.V31;
public readonly partial struct Document
{
    public readonly partial struct Link
    {
        /// <summary>
        /// A type generated from a JsonSchema specification.
        /// </summary>
        public readonly partial struct OneOf1Entity
        {
            /// <inheritdoc/>
            public ValidationContext Validate(in ValidationContext validationContext, ValidationLevel level = ValidationLevel.Flag)
            {
                ValidationContext result = validationContext;
                if (level > ValidationLevel.Flag)
                {
                    result = result.UsingResults();
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.UsingStack();
                    result = result.PushSchemaLocation("https://spec.openapis.org/oas/3.1/schema/2022-02-27#/$defs/link/oneOf/1");
                }

                JsonValueKind valueKind = this.ValueKind;
                result = this.ValidateObject(valueKind, result, level);
                if (level == ValidationLevel.Flag && !result.IsValid)
                {
                    return result;
                }

                if (level != ValidationLevel.Flag)
                {
                    result = result.PopLocation();
                }

                return result;
            }
        }
    }
}