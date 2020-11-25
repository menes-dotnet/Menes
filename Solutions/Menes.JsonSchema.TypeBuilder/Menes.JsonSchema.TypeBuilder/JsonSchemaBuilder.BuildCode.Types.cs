// <copyright file="JsonSchemaBuilder.BuildCode.Types.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System.Text;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        private void BuildTypeBackingFields(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Type is not null)
            {
                foreach (string type in typeDeclaration.Type)
                {
                    if (type != "object" && type != "array" && type != "null")
                    {
                        string typeAsPascalCase = Formatting.ToPascalCaseWithReservedWords(type).ToString();
                        string typeName = TypeDeclarations.GetTypeNameFor(type, typeDeclaration.Format);

                        memberBuilder.AppendLine($"private readonly {typeName}? _menes{typeAsPascalCase}TypeBacking;");
                    }
                }
            }
        }

        private void BuildTypeBackingFieldsAreNull(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Type is not null)
            {
                foreach (string type in typeDeclaration.Type)
                {
                    if (type != "object" && type != "array" && type != "null")
                    {
                        string typeAsPascalCase = Formatting.ToPascalCaseWithReservedWords(type).ToString();

                        memberBuilder.AppendLine($"if (this._menes{typeAsPascalCase}TypeBacking is not null)");
                        memberBuilder.AppendLine("{");
                        memberBuilder.AppendLine("    return false;");
                        memberBuilder.AppendLine("}");
                    }
                }
            }
        }

        private void BuildWriteTypeBackingValues(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Type is not null)
            {
                foreach (string type in typeDeclaration.Type)
                {
                    if (type != "object" && type != "array" && type != "null")
                    {
                        string typeAsPascalCase = Formatting.ToPascalCaseWithReservedWords(type).ToString();
                        memberBuilder.AppendLine($"        this._menes{typeAsPascalCase}TypeBacking?.WriteTo(writer);");
                    }
                }
            }
        }

        private void BuildOneOfBackingFields(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IsConcreteOneOf)
            {
                foreach (TypeDeclaration type in typeDeclaration.OneOf!)
                {
                    memberBuilder.AppendLine($"private readonly {type.FullyQualifiedDotNetTypeName}? _menes{Formatting.ToPascalCaseWithReservedWords(type.FullyQualifiedDotNetTypeName!).ToString()}OneOfBacking;");
                }
            }
        }

        private void BuildOneOfBackingFieldsAreNull(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IsConcreteOneOf)
            {
                foreach (TypeDeclaration type in typeDeclaration.OneOf!)
                {
                    memberBuilder.AppendLine($"if (this._menes{Formatting.ToPascalCaseWithReservedWords(type.FullyQualifiedDotNetTypeName!).ToString()}OneOfBacking is not null)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    return false;");
                    memberBuilder.AppendLine("}");
                }
            }
        }

        private void BuildWriteOneOfBackingValues(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IsConcreteOneOf)
            {
                foreach (TypeDeclaration type in typeDeclaration.OneOf!)
                {
                    memberBuilder.AppendLine($"        this._menes{Formatting.ToPascalCaseWithReservedWords(type.FullyQualifiedDotNetTypeName!).ToString()}OneOfBacking?.WriteTo(writer);");
                }
            }
        }

        private void BuildAnyOfBackingFields(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IsConcreteAnyOf)
            {
                foreach (TypeDeclaration type in typeDeclaration.AnyOf!)
                {
                    memberBuilder.AppendLine($"private readonly {type.FullyQualifiedDotNetTypeName}? _menes{Formatting.ToPascalCaseWithReservedWords(type.FullyQualifiedDotNetTypeName!).ToString()}AnyOfBacking;");
                }
            }
        }

        private void BuildAnyOfBackingFieldsAreNull(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IsConcreteAnyOf)
            {
                foreach (TypeDeclaration type in typeDeclaration.AnyOf!)
                {
                    memberBuilder.AppendLine($"if (this._menes{Formatting.ToPascalCaseWithReservedWords(type.FullyQualifiedDotNetTypeName!).ToString()}AnyOfBacking is not null)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    return false;");
                    memberBuilder.AppendLine("}");
                }
            }
        }

        private void BuildWriteAnyOfBackingValues(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IsConcreteAnyOf)
            {
                foreach (TypeDeclaration type in typeDeclaration.AnyOf!)
                {
                    memberBuilder.AppendLine($"        this._menes{Formatting.ToPascalCaseWithReservedWords(type.FullyQualifiedDotNetTypeName!).ToString()}AnyOfBacking?.WriteTo(writer);");
                }
            }
        }
    }
}
