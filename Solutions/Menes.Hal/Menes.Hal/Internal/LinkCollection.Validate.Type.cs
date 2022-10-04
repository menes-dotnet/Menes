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
public readonly partial struct LinkCollection
{
    private ValidationContext ValidateType(JsonValueKind valueKind, in ValidationContext validationContext, ValidationLevel level)
    {
        ValidationContext result = validationContext;
        bool isValid = false;
        ValidationContext localResultArray = Corvus.Json.Validate.TypeArray(valueKind, result.CreateChildContext(), level);
        if (level == ValidationLevel.Flag && localResultArray.IsValid)
        {
            return validationContext;
        }

        if (localResultArray.IsValid)
        {
            isValid = true;
        }

        result = result.MergeResults(isValid, level, localResultArray);
        return result;
    }
}