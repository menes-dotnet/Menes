// <copyright file="ConversionOperatorDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder.Model
{
    /// <summary>
    /// Declaration of a conversion operator.
    /// </summary>
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
            GenericAs,

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
        /// Gets or sets the target type of the conversion.
        /// </summary>
        public TypeDeclaration? ToType { get; set; }

        /// <summary>
        /// Gets or sets the type of conversion to use in the implementation.
        /// </summary>
        public ConversionType Conversion { get; set; }
    }
}
