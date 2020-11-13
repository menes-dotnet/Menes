// <copyright file="ConversionOperatorDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder.Model
{
    using System;

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
        /// Gets a conversion operation declaration which is used
        /// to effect a chain of conversion to the target type.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If we have:
        /// </para>
        /// <code>
        /// [<![CDATA[TypeA anyOf TypeB anyOf TypeC]]>
        /// </code>
        /// <para>
        /// then we will normally generate implicit conversion to and from a TypeB from a TypeA.
        /// But you would not be able to implicitly convert from TypeC to TypeA and vice-versa.
        /// </para>
        /// <para>
        /// By adding a <see cref="Via"/>, we can create an additional conversion in TypeA to and/or from TypeB which goes
        /// via the conversion in TypeB to and/or from TypeC.
        /// </para>
        /// <para>
        /// You can (and will!) nest these Vias, creating a chain that looks something like this.
        /// </para>
        /// <code>
        /// [<![CDATA[var typeAInstance = typeCInstance.As<TypeB>().As<TypeA>();]]>
        /// </code>
        /// <para>
        /// Or for the constructor case.
        /// </para>
        /// <code>
        /// [<![CDATA[var typeAInstance = new TypeA(new TypeB(typeCInstance));]]>
        /// </code>
        /// <para>
        /// Or casting.
        /// </para>
        /// <code>
        /// [<![CDATA[var typeAInstance = (TypeA)(TypeB)typeCInstance;]]>
        /// </code>
        /// <para>
        /// The Parent's <see cref="Direction"/> should match that of the Via.
        /// </para>
        /// <para>Use <see cref="CreateViaTo(TypeDeclaration)"/> to create an instance of a conversion with a via.</para>
        /// </remarks>
        public ConversionOperatorDeclaration? Via { get; private set; }

        /// <summary>
        /// Creates a conversion to/from a target type via this conversion.
        /// </summary>
        /// <param name="targetType">The target type to which to convert.</param>
        /// <returns>An instance of a <see cref="ConversionOperatorDeclaration"/> with can convert to the target type via this conversion type.</returns>
        public ConversionOperatorDeclaration CreateViaTo(TypeDeclaration targetType)
        {
            return new ConversionOperatorDeclaration
            {
                Conversion = this.Conversion,
                Direction = this.Direction,
                //// Ultimately we want to get to this conversion's type
                TargetType = this.TargetType,
                Via = new ConversionOperatorDeclaration
                {
                    Conversion = this.Conversion,
                    Direction = this.Direction,
                    //// And we have to go via this target type
                    TargetType = targetType,
                },
            };
        }
    }
}
