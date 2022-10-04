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
    public readonly partial struct OauthFlows
    {
        private ValidationContext ValidateRef(in ValidationContext validationContext, ValidationLevel level)
        {
            ValidationContext result = validationContext;
            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationProperty("$ref");
            }

            ValidationContext refResult = this.As<Menes.OpenApiSchema.V31.Document.SpecificationExtensions>().Validate(validationContext.CreateChildContext(), level);
            if (!refResult.IsValid)
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = validationContext.MergeResults(false, level, refResult);
                }
                else if (level >= ValidationLevel.Basic)
                {
                    result = validationContext.MergeResults(false, level, refResult);
                }
                else
                {
                    result = validationContext.WithResult(isValid: false);
                }
            }
            else
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.MergeResults(result.IsValid, level, refResult);
                }

                result = result.MergeChildContext(refResult, false);
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            return result;
        }
    }
}