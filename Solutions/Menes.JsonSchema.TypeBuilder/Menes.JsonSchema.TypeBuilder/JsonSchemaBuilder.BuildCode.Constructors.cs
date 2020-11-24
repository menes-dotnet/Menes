﻿// <copyright file="JsonSchemaBuilder.BuildCode.Constructors.cs" company="Endjin Limited">
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
        private void BuildConstructors(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            // Common public constructor
            this.BuildJsonElementConstructor(typeDeclaration, memberBuilder);

            // We use this to keep track of the constructors we have created so that we don't
            // create multiple with the same signature.
            var constructorParameterDeclarations = new HashSet<string>();

            // Public constructors
            this.BuildRequiredPropertiesConstructor(typeDeclaration, memberBuilder, constructorParameterDeclarations);

            this.BuildTypeConstructors(typeDeclaration, memberBuilder, constructorParameterDeclarations);
            this.BuildOneOfConstructors(typeDeclaration, memberBuilder, constructorParameterDeclarations);
            this.BuildAnyOfConstructors(typeDeclaration, memberBuilder, constructorParameterDeclarations);

            this.BuildArrayConstructors(typeDeclaration, memberBuilder, constructorParameterDeclarations);

            // Private constructors
            this.BuildRawArrayConstructor(typeDeclaration, memberBuilder, constructorParameterDeclarations);
            this.BuildRawEntityConstructor(typeDeclaration, memberBuilder, constructorParameterDeclarations);
        }

        private void BuildRawArrayConstructor(TypeDeclaration typeDeclaration, StringBuilder memberBuilder, HashSet<string> constructorParameterDeclarations)
        {
            if (!typeDeclaration.IsArrayTypeDeclaration)
            {
                return;
            }

            TypeDeclaration itemsType = this.GetItemsTypeFor(typeDeclaration);
            bool containsReference = itemsType.ContainsReferenceTo(typeDeclaration);

            // We only need this private constructor if we contain a recursive reference value; otherwise
            // we will be using the public constructor
            if (!containsReference)
            {
                return;
            }

            var parameterDeclarations = new StringBuilder();

            parameterDeclarations.Append($"System.Collections.Immutable.ImmutableArray<Menes.JsonArrayValueBacking> value");

            string parameterDeclaration = parameterDeclarations.ToString();
            if (!constructorParameterDeclarations.Contains(parameterDeclaration) && !string.IsNullOrEmpty(parameterDeclaration))
            {
                constructorParameterDeclarations.Add(parameterDeclaration);
                memberBuilder.AppendLine($"private {typeDeclaration.DotnetTypeName}({parameterDeclaration})");
                memberBuilder.AppendLine("{");

                memberBuilder.AppendLine("    this._menesArrayValueBacking = value;");

                memberBuilder.AppendLine("    this._menesJsonElementBacking = default;");
                this.BuildAssignNullOrDefaultAdditionalPropertiesBackingField(typeDeclaration, memberBuilder);
                this.BuildAssignNullOrDefaultPropertyBackingFields(typeDeclaration, memberBuilder);
                this.BuildAssignNullOrDefaultTypeBackingFields(typeDeclaration, memberBuilder);
                this.BuildAssignNullOrDefaultOneOfBackingFields(typeDeclaration, memberBuilder);
                this.BuildAssignNullOrDefaultAnyOfBackingFields(typeDeclaration, memberBuilder);

                memberBuilder.AppendLine("}");
            }
        }

        private void BuildArrayConstructors(TypeDeclaration typeDeclaration, StringBuilder memberBuilder, HashSet<string> constructorParameterDeclarations)
        {
            if (!typeDeclaration.IsArrayTypeDeclaration)
            {
                return;
            }

            var parameterDeclarations = new StringBuilder();

            TypeDeclaration itemsType = this.GetItemsTypeFor(typeDeclaration);
            parameterDeclarations.Append($"System.Collections.Immutable.ImmutableArray<{itemsType.FullyQualifiedDotNetTypeName}> value");

            string parameterDeclaration = parameterDeclarations.ToString();
            if (!constructorParameterDeclarations.Contains(parameterDeclaration) && !string.IsNullOrEmpty(parameterDeclaration))
            {
                constructorParameterDeclarations.Add(parameterDeclaration);
                memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName}({parameterDeclaration})");
                memberBuilder.AppendLine("{");

                if (itemsType.ContainsReferenceTo(typeDeclaration))
                {
                    memberBuilder.AppendLine("    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonArrayValueBacking>();");
                    memberBuilder.AppendLine("    foreach (var item in value)");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine($"        arrayBuilder.Add(Menes.JsonArrayValueBacking.From<{itemsType.FullyQualifiedDotNetTypeName}>(item));");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("    this._menesArrayValueBacking = arrayBuilder.ToImmutable();");
                }
                else
                {
                    memberBuilder.AppendLine("    this._menesArrayValueBacking = value;");
                }

                memberBuilder.AppendLine("    this._menesJsonElementBacking = default;");
                this.BuildAssignNullOrDefaultAdditionalPropertiesBackingField(typeDeclaration, memberBuilder);
                this.BuildAssignNullOrDefaultPropertyBackingFields(typeDeclaration, memberBuilder);
                this.BuildAssignNullOrDefaultTypeBackingFields(typeDeclaration, memberBuilder);
                this.BuildAssignNullOrDefaultOneOfBackingFields(typeDeclaration, memberBuilder);
                this.BuildAssignNullOrDefaultAnyOfBackingFields(typeDeclaration, memberBuilder);

                memberBuilder.AppendLine("}");
            }
        }

        private void BuildRequiredPropertiesConstructor(TypeDeclaration typeDeclaration, StringBuilder memberBuilder, HashSet<string> constructorParameterDeclarations)
        {
            var parameterDeclarations = new StringBuilder();
            this.BuildPropertyConstructorParameters(true, typeDeclaration, parameterDeclarations);

            string parameterDeclaration = parameterDeclarations.ToString();
            if (constructorParameterDeclarations.Contains(parameterDeclaration) || string.IsNullOrEmpty(parameterDeclaration))
            {
                return;
            }

            constructorParameterDeclarations.Add(parameterDeclaration);
            memberBuilder.Append($"public {typeDeclaration.DotnetTypeName}(");
            memberBuilder.Append(parameterDeclaration);
            memberBuilder.AppendLine(")");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    this._menesJsonElementBacking = default;");
            this.BuildPropertyConstructorAssignment(typeDeclaration, memberBuilder);
            this.BuildAssignNullOrDefaultAdditionalPropertiesBackingField(typeDeclaration, memberBuilder);
            this.BuildAssignNullOrDefaultArrayBackingField(typeDeclaration, memberBuilder);
            this.BuildAssignNullOrDefaultTypeBackingFields(typeDeclaration, memberBuilder);
            this.BuildAssignNullOrDefaultOneOfBackingFields(typeDeclaration, memberBuilder);
            this.BuildAssignNullOrDefaultAnyOfBackingFields(typeDeclaration, memberBuilder);
            memberBuilder.AppendLine("}");
        }

        private void BuildTypeConstructors(TypeDeclaration typeDeclaration, StringBuilder memberBuilder, HashSet<string> constructorParameterDeclarations)
        {
            if (typeDeclaration.Type is not null)
            {
                foreach (string type in typeDeclaration.Type)
                {
                    if (type != "object" && type != "array" && type != "null")
                    {
                        var parameterDeclarations = new StringBuilder();

                        string typeName = TypeDeclarations.GetTypeNameFor(type, typeDeclaration.Format);
                        string typeAsPascalCase = Formatting.ToPascalCaseWithReservedWords(type).ToString();
                        parameterDeclarations.Append($"{typeName} value");

                        string parameterDeclaration = parameterDeclarations.ToString();
                        if (constructorParameterDeclarations.Contains(parameterDeclaration) || string.IsNullOrEmpty(parameterDeclaration))
                        {
                            return;
                        }

                        constructorParameterDeclarations.Add(parameterDeclaration);
                        memberBuilder.Append($"public {typeDeclaration.DotnetTypeName}(");
                        memberBuilder.Append(parameterDeclaration);
                        memberBuilder.AppendLine(")");
                        memberBuilder.AppendLine("{");
                        memberBuilder.AppendLine("    this._menesJsonElementBacking = default;");
                        memberBuilder.AppendLine($"    this._menes{typeAsPascalCase}TypeBacking = value;");

                        this.BuildAssignNullOrDefaultAdditionalPropertiesBackingField(typeDeclaration, memberBuilder);
                        this.BuildAssignNullOrDefaultPropertyBackingFields(typeDeclaration, memberBuilder);
                        this.BuildAssignNullOrDefaultArrayBackingField(typeDeclaration, memberBuilder);
                        this.BuildAssignNullOrDefaultTypeBackingFields(typeDeclaration, memberBuilder, type);
                        this.BuildAssignNullOrDefaultOneOfBackingFields(typeDeclaration, memberBuilder);
                        this.BuildAssignNullOrDefaultAnyOfBackingFields(typeDeclaration, memberBuilder);
                        memberBuilder.AppendLine("}");
                    }
                }
            }
        }

        private void BuildOneOfConstructors(TypeDeclaration typeDeclaration, StringBuilder memberBuilder, HashSet<string> constructorParameterDeclarations)
        {
            if (typeDeclaration.IsConcreteOneOf)
            {
                foreach (TypeDeclaration type in typeDeclaration.OneOf!)
                {
                    var parameterDeclarations = new StringBuilder();

                    parameterDeclarations.Append($"{type.FullyQualifiedDotNetTypeName} value");

                    string parameterDeclaration = parameterDeclarations.ToString();
                    if (constructorParameterDeclarations.Contains(parameterDeclaration) || string.IsNullOrEmpty(parameterDeclaration))
                    {
                        return;
                    }

                    constructorParameterDeclarations.Add(parameterDeclaration);
                    memberBuilder.Append($"public {typeDeclaration.DotnetTypeName}(");
                    memberBuilder.Append(parameterDeclaration);
                    memberBuilder.AppendLine(")");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    this._menesJsonElementBacking = default;");
                    memberBuilder.AppendLine($"    this._menes{Formatting.ToPascalCaseWithReservedWords(type.FullyQualifiedDotNetTypeName!).ToString()}OneOfBacking = value;");

                    this.BuildAssignNullOrDefaultAdditionalPropertiesBackingField(typeDeclaration, memberBuilder);
                    this.BuildAssignNullOrDefaultPropertyBackingFields(typeDeclaration, memberBuilder);
                    this.BuildAssignNullOrDefaultArrayBackingField(typeDeclaration, memberBuilder);
                    this.BuildAssignNullOrDefaultTypeBackingFields(typeDeclaration, memberBuilder);
                    this.BuildAssignNullOrDefaultOneOfBackingFields(typeDeclaration, memberBuilder, type);
                    this.BuildAssignNullOrDefaultAnyOfBackingFields(typeDeclaration, memberBuilder, type);
                    memberBuilder.AppendLine("}");
                }
            }
        }

        private void BuildAnyOfConstructors(TypeDeclaration typeDeclaration, StringBuilder memberBuilder, HashSet<string> constructorParameterDeclarations)
        {
            if (typeDeclaration.IsConcreteAnyOf)
            {
                foreach (TypeDeclaration type in typeDeclaration.AnyOf!)
                {
                    var parameterDeclarations = new StringBuilder();

                    parameterDeclarations.Append($"{type.FullyQualifiedDotNetTypeName} value");

                    string parameterDeclaration = parameterDeclarations.ToString();
                    if (constructorParameterDeclarations.Contains(parameterDeclaration) || string.IsNullOrEmpty(parameterDeclaration))
                    {
                        return;
                    }

                    constructorParameterDeclarations.Add(parameterDeclaration);
                    memberBuilder.Append($"public {typeDeclaration.DotnetTypeName}(");
                    memberBuilder.Append(parameterDeclaration);
                    memberBuilder.AppendLine(")");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    this._menesJsonElementBacking = default;");
                    memberBuilder.AppendLine($"    this._menes{Formatting.ToPascalCaseWithReservedWords(type.FullyQualifiedDotNetTypeName!).ToString()}AnyOfBacking = value;");

                    this.BuildAssignNullOrDefaultAdditionalPropertiesBackingField(typeDeclaration, memberBuilder);
                    this.BuildAssignNullOrDefaultPropertyBackingFields(typeDeclaration, memberBuilder);
                    this.BuildAssignNullOrDefaultArrayBackingField(typeDeclaration, memberBuilder);
                    this.BuildAssignNullOrDefaultTypeBackingFields(typeDeclaration, memberBuilder);
                    this.BuildAssignNullOrDefaultOneOfBackingFields(typeDeclaration, memberBuilder);
                    this.BuildAssignNullOrDefaultAnyOfBackingFields(typeDeclaration, memberBuilder, type);
                    memberBuilder.AppendLine("}");
                }
            }
        }

        private void BuildRawEntityConstructor(TypeDeclaration typeDeclaration, StringBuilder memberBuilder, HashSet<string> constructorParameterDeclarations)
        {
            var parameterDeclarations = new StringBuilder();
            bool isFirstParameter = true;
            isFirstParameter = this.BuildRawPropertyConstructorParameters(isFirstParameter, typeDeclaration, parameterDeclarations);
            isFirstParameter = this.BuildRawTypeConstructorParameters(isFirstParameter, typeDeclaration, parameterDeclarations);
            isFirstParameter = this.BuildRawOneOfConstructorParameters(isFirstParameter, typeDeclaration, parameterDeclarations);
            isFirstParameter = this.BuildRawAnyOfConstructorParameters(isFirstParameter, typeDeclaration, parameterDeclarations);
            this.BuildRawAdditionalPropertiesConstructorParameters(isFirstParameter, typeDeclaration, parameterDeclarations);

            string parameterDeclaration = parameterDeclarations.ToString();
            if (constructorParameterDeclarations.Contains(parameterDeclaration) || string.IsNullOrEmpty(parameterDeclaration))
            {
                return;
            }

            constructorParameterDeclarations.Add(parameterDeclaration);
            memberBuilder.Append($"private {typeDeclaration.DotnetTypeName}(");
            memberBuilder.Append(parameterDeclaration);
            memberBuilder.AppendLine(")");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    this._menesJsonElementBacking = default;");
            this.BuildRawPropertyConstructorAssignment(typeDeclaration, memberBuilder);
            this.BuildRawTypeConstructorAssignment(typeDeclaration, memberBuilder);
            this.BuildRawOneOfConstructorAssignment(typeDeclaration, memberBuilder);
            this.BuildRawAnyOfConstructorAssignment(typeDeclaration, memberBuilder);
            this.BuildRawAdditionalPropertiesConstructorAssignment(typeDeclaration, memberBuilder);
            memberBuilder.AppendLine("}");
        }

        private void BuildPropertyConstructorAssignment(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Properties is not null)
            {
                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
                    if (property.TypeDeclaration is null)
                    {
                        throw new InvalidOperationException($"You must set the type declaration before generating the property {property.JsonPropertyName} in {typeDeclaration.FullyQualifiedDotNetTypeName}.");
                    }

                    if (property.TypeDeclaration.ContainsReferenceTo(typeDeclaration))
                    {
                        memberBuilder.AppendLine($"this.{property.DotnetFieldName} = Menes.JsonValueBacking.From<{property.TypeDeclaration.FullyQualifiedDotNetTypeName}>({property.DotnetFieldName});");
                    }
                    else
                    {
                        memberBuilder.AppendLine($"this.{property.DotnetFieldName} = {property.DotnetFieldName};");
                    }
                }
            }
        }

        private bool BuildPropertyConstructorParameters(bool isFirstParameter, TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Properties is not null)
            {
                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
                    if (!property.IsRequired)
                    {
                        continue;
                    }

                    if (property.TypeDeclaration is null)
                    {
                        throw new InvalidOperationException($"You must set the type declaration before generating the property {property.JsonPropertyName} in {typeDeclaration.FullyQualifiedDotNetTypeName}.");
                    }

                    isFirstParameter = this.AppendParameterComma(isFirstParameter, memberBuilder);
                    memberBuilder.Append($"{property.TypeDeclaration.FullyQualifiedDotNetTypeName} {property.DotnetFieldName}");
                }

                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
                    if (property.IsRequired)
                    {
                        continue;
                    }

                    if (property.TypeDeclaration is null)
                    {
                        throw new InvalidOperationException($"You must set the type declaration before generating the property {property.JsonPropertyName} in {typeDeclaration.FullyQualifiedDotNetTypeName}.");
                    }

                    isFirstParameter = this.AppendParameterComma(isFirstParameter, memberBuilder);
                    memberBuilder.Append($"{property.TypeDeclaration.FullyQualifiedDotNetTypeName}? {property.DotnetFieldName} = null");
                }
            }

            return isFirstParameter;
        }

        private void BuildRawPropertyConstructorAssignment(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Properties is not null)
            {
                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
                    memberBuilder.AppendLine($"this.{property.DotnetFieldName} = {property.DotnetFieldName};");
                }
            }
        }

        private void BuildRawTypeConstructorAssignment(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Type is not null)
            {
                foreach (string type in typeDeclaration.Type)
                {
                    if (type != "object" && type != "array" && type != "null")
                    {
                        string typeAsPascalCase = Formatting.ToPascalCaseWithReservedWords(type).ToString();
                        memberBuilder.AppendLine($"this._menes{typeAsPascalCase}TypeBacking = _menes{typeAsPascalCase}TypeBacking;");
                    }
                }
            }
        }

        private void BuildRawOneOfConstructorAssignment(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IsConcreteOneOf)
            {
                foreach (TypeDeclaration type in typeDeclaration.OneOf!)
                {
                    string typeAsPascalCase = Formatting.ToPascalCaseWithReservedWords(type.FullyQualifiedDotNetTypeName!).ToString();
                    memberBuilder.AppendLine($"this._menes{typeAsPascalCase}OneOfBacking = _menes{typeAsPascalCase}OneOfBacking;");
                }
            }
        }

        private void BuildRawAnyOfConstructorAssignment(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IsConcreteAnyOf)
            {
                foreach (TypeDeclaration type in typeDeclaration.AnyOf!)
                {
                    string typeAsPascalCase = Formatting.ToPascalCaseWithReservedWords(type.FullyQualifiedDotNetTypeName!).ToString();
                    memberBuilder.AppendLine($"this._menes{typeAsPascalCase}AnyOfBacking = _menes{typeAsPascalCase}AnyOfBacking;");
                }
            }
        }

        private void BuildRawAdditionalPropertiesConstructorAssignment(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AllowsAdditionalProperties)
            {
                memberBuilder.AppendLine($"this._menesAdditionalPropertiesBacking = _menesAdditionalPropertiesBacking;");
            }
        }

        private bool BuildRawAdditionalPropertiesConstructorParameters(bool isFirstParameter, TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AllowsAdditionalProperties)
            {
                isFirstParameter = this.AppendParameterComma(isFirstParameter, memberBuilder);

                TypeDeclaration additionalPropertyType = typeDeclaration.AdditionalProperties ?? TypeDeclarations.AnyTypeDeclaration;

                if (!additionalPropertyType.ContainsReferenceTo(typeDeclaration))
                {
                    memberBuilder.Append($"in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<{additionalPropertyType.FullyQualifiedDotNetTypeName}>> _menesAdditionalPropertiesBacking");
                }
                else
                {
                    memberBuilder.Append($"in System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty> _menesAdditionalPropertiesBacking");
                }
            }

            return isFirstParameter;
        }

        private bool BuildRawTypeConstructorParameters(bool isFirstParameter, TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Type is not null)
            {
                foreach (string type in typeDeclaration.Type)
                {
                    if (type != "object" && type != "array" && type != "null")
                    {
                        isFirstParameter = this.AppendParameterComma(isFirstParameter, memberBuilder);

                        string typeType = TypeDeclarations.GetTypeNameFor(type, typeDeclaration.Format);
                        string typeAsPascalCase = Formatting.ToPascalCaseWithReservedWords(type).ToString();
                        memberBuilder.Append($"{typeType}? _menes{typeAsPascalCase}TypeBacking");
                    }
                }
            }

            return isFirstParameter;
        }

        private bool BuildRawOneOfConstructorParameters(bool isFirstParameter, TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IsConcreteOneOf)
            {
                foreach (TypeDeclaration type in typeDeclaration.OneOf!)
                {
                    isFirstParameter = this.AppendParameterComma(isFirstParameter, memberBuilder);
                    string typeAsPascalCase = Formatting.ToPascalCaseWithReservedWords(type.FullyQualifiedDotNetTypeName!).ToString();
                    memberBuilder.Append($"{type.FullyQualifiedDotNetTypeName}? _menes{typeAsPascalCase}OneOfBacking");
                }
            }

            return isFirstParameter;
        }

        private bool BuildRawAnyOfConstructorParameters(bool isFirstParameter, TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IsConcreteAnyOf)
            {
                foreach (TypeDeclaration type in typeDeclaration.AnyOf!)
                {
                    isFirstParameter = this.AppendParameterComma(isFirstParameter, memberBuilder);
                    string typeAsPascalCase = Formatting.ToPascalCaseWithReservedWords(type.FullyQualifiedDotNetTypeName!).ToString();
                    memberBuilder.Append($"{type.FullyQualifiedDotNetTypeName}? _menes{typeAsPascalCase}AnyOfBacking");
                }
            }

            return isFirstParameter;
        }

        private bool BuildRawPropertyConstructorParameters(bool isFirstParameter, TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
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
                    if (property.TypeDeclaration.ContainsReferenceTo(typeDeclaration))
                    {
                        memberBuilder.Append($"Menes.JsonValueBacking {property.DotnetFieldName}");
                    }
                    else
                    {
                        memberBuilder.Append($"{property.TypeDeclaration.FullyQualifiedDotNetTypeName}? {property.DotnetFieldName}");
                    }
                }
            }

            return isFirstParameter;
        }

        private void BuildJsonElementConstructor(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName}(System.Text.Json.JsonElement jsonElement)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    this._menesJsonElementBacking = jsonElement;");
            this.BuildAssignNullOrDefaultBackingFields(typeDeclaration, memberBuilder);
            memberBuilder.AppendLine("}");
        }

        private void BuildAssignNullOrDefaultBackingFields(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            this.BuildAssignNullOrDefaultAdditionalPropertiesBackingField(typeDeclaration, memberBuilder);
            this.BuildAssignNullOrDefaultTypeBackingFields(typeDeclaration, memberBuilder);
            this.BuildAssignNullOrDefaultOneOfBackingFields(typeDeclaration, memberBuilder);
            this.BuildAssignNullOrDefaultAnyOfBackingFields(typeDeclaration, memberBuilder);
            this.BuildAssignNullOrDefaultPropertyBackingFields(typeDeclaration, memberBuilder);
            this.BuildAssignNullOrDefaultArrayBackingField(typeDeclaration, memberBuilder);
        }

        private void BuildAssignNullOrDefaultPropertyBackingFields(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Properties is not null)
            {
                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
                    memberBuilder.AppendLine($"this.{property.DotnetFieldName} = default;");
                }
            }
        }

        private void BuildAssignNullOrDefaultArrayBackingField(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IsArrayTypeDeclaration)
            {
                memberBuilder.AppendLine("this._menesArrayValueBacking = default;");
            }
        }

        private void BuildAssignNullOrDefaultTypeBackingFields(TypeDeclaration typeDeclaration, StringBuilder memberBuilder, string? typeToSkip = null)
        {
            if (typeDeclaration.Type is not null)
            {
                foreach (string type in typeDeclaration.Type)
                {
                    if (type != "object" && type != "array" && type != "null" && type != typeToSkip)
                    {
                        string typeAsPascalCase = Formatting.ToPascalCaseWithReservedWords(type).ToString();
                        memberBuilder.AppendLine($"this._menes{typeAsPascalCase}TypeBacking = default;");
                    }
                }
            }
        }

        private void BuildAssignNullOrDefaultOneOfBackingFields(TypeDeclaration typeDeclaration, StringBuilder memberBuilder, TypeDeclaration? typeToSkip = null)
        {
            if (typeDeclaration.IsConcreteOneOf)
            {
                foreach (TypeDeclaration type in typeDeclaration.OneOf!)
                {
                    if (typeToSkip?.FullyQualifiedDotNetTypeName != type.FullyQualifiedDotNetTypeName)
                    {
                        memberBuilder.AppendLine($"this._menes{Formatting.ToPascalCaseWithReservedWords(type.FullyQualifiedDotNetTypeName!).ToString()}OneOfBacking = default;");
                    }
                }
            }
        }

        private void BuildAssignNullOrDefaultAnyOfBackingFields(TypeDeclaration typeDeclaration, StringBuilder memberBuilder, TypeDeclaration? typeToSkip = null)
        {
            if (typeDeclaration.IsConcreteAnyOf)
            {
                foreach (TypeDeclaration type in typeDeclaration.AnyOf!)
                {
                    if (typeToSkip?.FullyQualifiedDotNetTypeName != type.FullyQualifiedDotNetTypeName)
                    {
                        memberBuilder.AppendLine($"this._menes{Formatting.ToPascalCaseWithReservedWords(type.FullyQualifiedDotNetTypeName!).ToString()}AnyOfBacking = default;");
                    }
                }
            }
        }

        private void BuildAssignNullOrDefaultAdditionalPropertiesBackingField(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AllowsAdditionalProperties)
            {
                TypeDeclaration additionalPropertyType = typeDeclaration.AdditionalProperties ?? TypeDeclarations.AnyTypeDeclaration;

                if (!additionalPropertyType.ContainsReferenceTo(typeDeclaration))
                {
                    memberBuilder.AppendLine($"this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<{additionalPropertyType.FullyQualifiedDotNetTypeName}>>.Empty;");
                }
                else
                {
                    memberBuilder.AppendLine($"this._menesAdditionalPropertiesBacking = System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty>.Empty;");
                }
            }
        }
    }
}