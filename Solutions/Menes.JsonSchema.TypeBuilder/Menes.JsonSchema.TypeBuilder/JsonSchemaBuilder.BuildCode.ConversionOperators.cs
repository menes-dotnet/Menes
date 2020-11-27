// <copyright file="JsonSchemaBuilder.BuildCode.ConversionOperators.cs" company="Endjin Limited">
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
        private void BuildArrayConversionOperators(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.ArrayConversionOperators is not List<ArrayConversionOperatorDeclaration> arrayConversionOperators)
            {
                return;
            }

            foreach (ArrayConversionOperatorDeclaration arrayConversionOperator in arrayConversionOperators)
            {
                string targetItemTypeName = arrayConversionOperator.TargetItemType?.FullyQualifiedDotNetTypeName ?? throw new InvalidOperationException("You must set the target item type before generating code.");

                memberBuilder.AppendLine($"public static implicit operator {typeDeclaration.DotnetTypeName}(System.Collections.Immutable.ImmutableArray<{targetItemTypeName}> items)");
                memberBuilder.AppendLine("{");
                if (arrayConversionOperator.ViaItemType is TypeDeclaration viaType && arrayConversionOperator.ViaArrayType is TypeDeclaration viaArrayType)
                {
                    memberBuilder.AppendLine($"    var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<{viaType.FullyQualifiedDotNetTypeName}>();");
                    memberBuilder.AppendLine("    foreach (var item in items)");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine($"        arrayBuilder.Add(({viaType.FullyQualifiedDotNetTypeName})item);");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine($"    return ({typeDeclaration.DotnetTypeName})({viaArrayType.FullyQualifiedDotNetTypeName})arrayBuilder.ToImmutable();");
                }
                else
                {
                    if (typeDeclaration.IsArrayType)
                    {
                        memberBuilder.AppendLine($"    return new {typeDeclaration.FullyQualifiedDotNetTypeName}(items);");
                    }
                    else
                    {
                        memberBuilder.AppendLine($"    return ({typeDeclaration.FullyQualifiedDotNetTypeName})items;");
                    }
                }

                memberBuilder.AppendLine("}");
            }
        }

        private void BuildConversionOperators(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.ConversionOperators is null)
            {
                return;
            }

            foreach (ConversionOperatorDeclaration op in typeDeclaration.ConversionOperators)
            {
                if (op.TargetType is null)
                {
                    throw new InvalidOperationException("You must set the conversion operator target type before use.");
                }

                if (op.Direction.HasFlag(ConversionOperatorDeclaration.ConversionDirection.FromImplicit))
                {
                    memberBuilder.AppendLine($"public static implicit operator {op.TargetType.FullyQualifiedDotNetTypeName}({typeDeclaration.DotnetTypeName} value)");
                    memberBuilder.AppendLine("{");

                    if (op.Via is TypeDeclaration via)
                    {
                        this.BuildConversionOperator(op.Conversion, op.TargetType, via, memberBuilder);
                    }
                    else
                    {
                        this.BuildConversionOperator(op.Conversion, op.TargetType, memberBuilder);
                    }

                    memberBuilder.AppendLine("}");
                }

                if (op.Direction.HasFlag(ConversionOperatorDeclaration.ConversionDirection.FromExplicit))
                {
                    memberBuilder.AppendLine($"public static explicit operator {op.TargetType.FullyQualifiedDotNetTypeName}({typeDeclaration.DotnetTypeName} value)");
                    memberBuilder.AppendLine("{");
                    if (op.Via is TypeDeclaration via)
                    {
                        this.BuildConversionOperator(op.Conversion, op.TargetType, via, memberBuilder);
                    }
                    else
                    {
                        this.BuildConversionOperator(op.Conversion, op.TargetType, memberBuilder);
                    }

                    memberBuilder.AppendLine("}");
                }

                if (op.Direction.HasFlag(ConversionOperatorDeclaration.ConversionDirection.ToImplicit))
                {
                    memberBuilder.AppendLine($"public static implicit operator {typeDeclaration.DotnetTypeName}({op.TargetType.FullyQualifiedDotNetTypeName} value)");
                    memberBuilder.AppendLine("{");
                    if (op.Via is TypeDeclaration via)
                    {
                        this.BuildConversionOperator(op.Conversion, typeDeclaration, via, memberBuilder);
                    }
                    else
                    {
                        this.BuildConversionOperator(op.Conversion, typeDeclaration, memberBuilder);
                    }

                    memberBuilder.AppendLine("}");
                }

                if (op.Direction.HasFlag(ConversionOperatorDeclaration.ConversionDirection.ToExplicit))
                {
                    memberBuilder.AppendLine($"public static explicit operator {typeDeclaration.DotnetTypeName}({op.TargetType.FullyQualifiedDotNetTypeName} value)");
                    memberBuilder.AppendLine("{");
                    if (op.Via is TypeDeclaration via)
                    {
                        this.BuildConversionOperator(op.Conversion, typeDeclaration, via, memberBuilder);
                    }
                    else
                    {
                        this.BuildConversionOperator(op.Conversion, typeDeclaration, memberBuilder);
                    }

                    memberBuilder.AppendLine("}");
                }
            }
        }

        private void BuildConversionOperator(ConversionOperatorDeclaration.ConversionType conversion, TypeDeclaration targetType, StringBuilder memberBuilder)
        {
            switch (conversion)
            {
                case ConversionOperatorDeclaration.ConversionType.Cast:
                    memberBuilder.AppendLine($"    return ({targetType.FullyQualifiedDotNetTypeName})value;");
                    break;
                case ConversionOperatorDeclaration.ConversionType.Constructor:
                    memberBuilder.AppendLine($"    return new {targetType.FullyQualifiedDotNetTypeName}(value);");
                    break;
                case ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom:
                    memberBuilder.AppendLine($"    return value.As<{targetType.FullyQualifiedDotNetTypeName}>();");
                    break;
            }
        }

        private void BuildConversionOperator(ConversionOperatorDeclaration.ConversionType conversion, TypeDeclaration targetType, TypeDeclaration via, StringBuilder memberBuilder)
        {
            switch (conversion)
            {
                case ConversionOperatorDeclaration.ConversionType.Cast:
                    memberBuilder.AppendLine($"    return ({targetType.FullyQualifiedDotNetTypeName})({via.FullyQualifiedDotNetTypeName})value;");
                    break;
                case ConversionOperatorDeclaration.ConversionType.Constructor:
                    memberBuilder.AppendLine($"    return new {targetType.FullyQualifiedDotNetTypeName}(new {via.FullyQualifiedDotNetTypeName}(value));");
                    break;
                case ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom:
                    memberBuilder.AppendLine($"    return value.As<{via.FullyQualifiedDotNetTypeName}>().As<{targetType.FullyQualifiedDotNetTypeName}>();");
                    break;
            }
        }
    }
}
