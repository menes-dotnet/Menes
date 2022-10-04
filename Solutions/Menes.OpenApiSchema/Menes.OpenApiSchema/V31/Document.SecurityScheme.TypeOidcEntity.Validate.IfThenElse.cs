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
        public readonly partial struct TypeOidcEntity
        {
            private ValidationContext ValidateIfThenElse(in ValidationContext validationContext, ValidationLevel level)
            {
                ValidationContext result = validationContext;
                if (level > ValidationLevel.Basic)
                {
                    result = result.PushValidationLocationProperty("if");
                }

                ValidationContext ifResult = this.As<Menes.OpenApiSchema.V31.Document.SecurityScheme.TypeOidcEntity.IfEntity>().Validate(validationContext.CreateChildContext(), level);
                if (!ifResult.IsValid)
                {
                    if (level >= ValidationLevel.Verbose)
                    {
                        result = validationContext.MergeResults(false, level, ifResult, ifResult);
                    }
                }
                else
                {
                    if (level >= ValidationLevel.Verbose)
                    {
                        result = result.MergeChildContext(ifResult, true);
                    }
                    else
                    {
                        result = result.MergeChildContext(ifResult, false);
                    }
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.PopLocation(); // if
                }

                if (ifResult.IsValid)
                {
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationProperty("then");
                    }

                    ValidationContext thenResult = this.As<Menes.OpenApiSchema.V31.Document.SecurityScheme.TypeOidcEntity.ThenEntity>().Validate(validationContext.CreateChildContext(), level);
                    if (!thenResult.IsValid)
                    {
                        if (level >= ValidationLevel.Detailed)
                        {
                            result = validationContext.MergeResults(false, level, ifResult, thenResult).WithResult(isValid: false, "Validation 9.2.2.2. then - failed to validate against the then schema.");
                        }
                        else if (level >= ValidationLevel.Basic)
                        {
                            result = validationContext.MergeResults(false, level, ifResult, thenResult).WithResult(isValid: false, "Validation 9.2.2.2. then - failed to validate against the then schema.");
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
                            result = result.MergeChildContext(thenResult, true);
                        }

                        result = result.MergeChildContext(thenResult, false);
                    }

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation(); // then
                    }
                }

                return result;
            }
        }
    }
}