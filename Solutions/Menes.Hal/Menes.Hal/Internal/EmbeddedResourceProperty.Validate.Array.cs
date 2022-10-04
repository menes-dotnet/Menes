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

namespace Menes.Hal;
/// <summary>
/// A type generated from a JsonSchema specification.
/// </summary>
public readonly partial struct EmbeddedResourceProperty
{
    private ValidationContext ValidateArray(JsonValueKind valueKind, in ValidationContext validationContext, ValidationLevel level)
    {
        ValidationContext result = validationContext;
        if (valueKind != JsonValueKind.Array)
        {
            return result;
        }

        int arrayLength = 0;
        using JsonArrayEnumerator arrayEnumerator = this.EnumerateArray();
        while (arrayEnumerator.MoveNext())
        {
            if (level > ValidationLevel.Basic)
            {
                result = result.PushDocumentArrayIndex(arrayLength);
            }

            using JsonArrayEnumerator innerEnumerator = this.EnumerateArray();
            int innerIndex = -1;
            while (innerIndex < arrayLength && innerEnumerator.MoveNext())
            {
                innerIndex++;
            }

            while (innerEnumerator.MoveNext())
            {
                if (innerEnumerator.Current.Equals(arrayEnumerator.Current))
                {
                    if (level >= ValidationLevel.Detailed)
                    {
                        result = result.WithResult(isValid: false, $"6.4.3. uniqueItems - duplicate items were found at indices {arrayLength} and {innerIndex}.");
                    }
                    else if (level >= ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, "6.4.3. uniqueItems - duplicate items were found.");
                    }
                    else
                    {
                        return result.WithResult(isValid: false);
                    }
                }
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation(); // array index
            }

            arrayLength++;
        }

        return result;
    }
}