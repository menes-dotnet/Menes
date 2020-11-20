// <copyright file="JsonSchemaBuilder.BuildCode.WithProperties.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        private void BuildWithPropertyMethods(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Properties is List<PropertyDeclaration> properties)
            {
                foreach (PropertyDeclaration property in properties)
                {
                    memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} With{property.DotnetPropertyName}({property.TypeDeclaration!.FullyQualifiedDotNetTypeName} value)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.Append($"    return new {typeDeclaration.DotnetTypeName}(");
                    bool isFirstParameter = true;
                    isFirstParameter = this.BuildRawPropertyConstructorInstances(isFirstParameter, typeDeclaration, memberBuilder, property.DotnetPropertyName);
                    isFirstParameter = this.BuildRawTypeConstructorInstances(isFirstParameter, typeDeclaration, memberBuilder);
                    this.BuildRawAdditionalPropertiesConstructorInstances(isFirstParameter, typeDeclaration, memberBuilder);

                    memberBuilder.AppendLine($");");
                    memberBuilder.AppendLine("}");
                }
            }
        }

        private bool BuildRawAdditionalPropertiesConstructorInstances(bool isFirstParameter, TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AllowsAdditionalProperties)
            {
                isFirstParameter = this.AppendParameterComma(isFirstParameter, memberBuilder);
                memberBuilder.Append($"this._menesAdditionalPropertiesBacking");
            }

            return isFirstParameter;
        }

        private bool BuildRawTypeConstructorInstances(bool isFirstParameter, TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Type is not null)
            {
                foreach (string type in typeDeclaration.Type)
                {
                    if (type != "object" && type != "array" && type != "null")
                    {
                        isFirstParameter = this.AppendParameterComma(isFirstParameter, memberBuilder);

                        string typeAsPascalCase = Formatting.ToPascalCaseWithReservedWords(type).ToString();
                        memberBuilder.Append($"this._menes{typeAsPascalCase}TypeBacking");
                    }
                }
            }

            return isFirstParameter;
        }

        private bool BuildRawPropertyConstructorInstances(bool isFirstParameter, TypeDeclaration typeDeclaration, StringBuilder memberBuilder, string? propertyName)
        {
            if (typeDeclaration.Properties is not null)
            {
                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
                    if (property.TypeDeclaration is null)
                    {
                        throw new InvalidOperationException($"You must set the type declaration before generating the property {property.JsonPropertyName} in {typeDeclaration.FullyQualifiedDotNetTypeName}.");
                    }

                    isFirstParameter = this.AppendParameterComma(isFirstParameter, memberBuilder);
                    if (property.DotnetPropertyName == propertyName)
                    {
                        if (property.TypeDeclaration.ContainsReferenceTo(typeDeclaration))
                        {
                            memberBuilder.Append($"Menes.JsonValueBacking.From<{property.TypeDeclaration.FullyQualifiedDotNetTypeName}>(value)");
                        }
                        else
                        {
                            memberBuilder.Append("value");
                        }
                    }
                    else
                    {
                        memberBuilder.Append($"this.{property.DotnetFieldName}");
                    }
                }
            }

            return isFirstParameter;
        }
    }
}