// <copyright file="ConversionOperatorDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder.Model
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Declaration of a conversion operator.
    /// </summary>
    [DebuggerDisplay("Target: {TargetType}, Via: {Via}, {Conversion}")]
    public class ConversionOperatorDeclaration
    {
        /// <summary>
        /// The type of converter to generator.
        /// </summary>
        public enum ConversionType
        {
            /// <summary>
            /// Convert by using a constructor.
            /// </summary>
            /// <remarks>
            /// Will generate a method body like
            /// <code>
            /// [<![CDATA[
            /// return new {ToTypeName}(fromType);
            /// ]]>
            /// </code>
            /// </remarks>
            Constructor,

            /// <summary>
            /// Convert by using an As method.
            /// </summary>
            /// <remarks>
            /// Will generate a method body like
            /// <code>
            /// [<![CDATA[
            /// return fromType.As<{ToTypeName}>();
            /// ]]>
            /// </code>
            /// </remarks>
            GenericAsAndStaticFrom,

            /// <summary>
            /// Convert by using an explicit cast.
            /// </summary>
            /// <remarks>
            /// Will generate a method body like
            /// <code>
            /// [<![CDATA[
            /// return ({ToTypeName})fromType;
            /// ]]>
            /// </code>
            /// </remarks>
            Cast,
        }

        /// <summary>
        /// Conversion operator directiong.
        /// </summary>
        /// <remarks>
        /// <para>Combine these flags values to produce the combination of operators you require.</para>
        /// <para>For example <c>ConversionDirection.ToImplicit &amp; ConversionDirection.FromExplicit</c>.</para>
        /// </remarks>
        [Flags]
        public enum ConversionDirection
        {
            /// <summary>
            /// Implicit operator, to the <see cref="TargetType"/>.
            /// </summary>
            ToImplicit = 1,

            /// <summary>
            /// Implicit operator, from the <see cref="TargetType"/>.
            /// </summary>
            FromImplicit = 2,

            /// <summary>
            /// Implicit operators, to and from the <see cref="TargetType"/>.
            /// </summary>
            BidirectionalImplicit = 3,

            /// <summary>
            /// Explicit operator, to the <see cref="TargetType"/>.
            /// </summary>
            ToExplicit = 4,

            /// <summary>
            /// Explicit operator, from the <see cref="TargetType"/>.
            /// </summary>
            FromExplicit = 8,

            /// <summary>
            /// Explicit operators, to and from the <see cref="TargetType"/>.
            /// </summary>
            BidirectionalExplicit = 12,
        }

        /// <summary>
        /// Gets or sets the conversion direction.
        /// </summary>
        public ConversionDirection Direction { get; set; }

        /// <summary>
        /// Gets or sets the target type of the conversion.
        /// </summary>
        public TypeDeclaration? TargetType { get; set; }

        /// <summary>
        /// Gets or sets the type of conversion to use in the implementation.
        /// </summary>
        public ConversionType Conversion { get; set; }

        /// <summary>
        /// Gets or sets the type via which a conversion is performed.
        /// </summary>
        public TypeDeclaration? Via { get; set; }
    }
}
