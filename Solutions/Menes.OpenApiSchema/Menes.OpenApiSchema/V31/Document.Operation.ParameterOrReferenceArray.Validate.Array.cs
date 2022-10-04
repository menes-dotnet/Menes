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
    public readonly partial struct Operation
    {
        /// <summary>
        /// A type generated from a JsonSchema specification.
        /// </summary>
        public readonly partial struct ParameterOrReferenceArray
        {
            private ValidationContext ValidateArray(JsonValueKind valueKind, in ValidationContext validationContext, ValidationLevel level)
            {
                ValidationContext result = validationContext;
                if (valueKind != JsonValueKind.Array)
                {
                    return result;
                }

                int arrayLength = 0;
                using JsonArrayEnumerator<Menes.OpenApiSchema.V31.Document.ParameterOrReference> arrayEnumerator = this.EnumerateArray();
                while (arrayEnumerator.MoveNext())
                {
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushDocumentArrayIndex(arrayLength);
                    }

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationProperty("items");
                    }

                    result = arrayEnumerator.Current.Validate(result, level);
                    if (level == ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation(); // items
                    }

                    result = result.WithLocalItemIndex(arrayLength);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation(); // array index
                    }

                    arrayLength++;
                }

                return result;
            }
        }
    }
}