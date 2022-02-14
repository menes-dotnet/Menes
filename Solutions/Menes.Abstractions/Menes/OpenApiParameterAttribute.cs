// <copyright file="OpenApiParameterAttribute.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;

    /// <summary>
    /// Describes a parameter on an Open Api operation method corresponds.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class OpenApiParameterAttribute : Attribute
    {
        /// <summary>
        /// Creates a <see cref="OpenApiParameterAttribute"/> describing the name of the input
        /// parameter in the request that this method parameter corresponds to.
        /// </summary>
        /// <param name="parameterName">
        /// The name of the request parameter that this method parameter corresponds to.
        /// </param>
        public OpenApiParameterAttribute(string parameterName)
        {
            this.ParameterName = parameterName;
        }

        /// <summary>
        /// Gets the name of the request parameter that this method parameter corresponds to.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This enables the use of input parameters with names that are not legal C# parameter
        /// names. E.g.:
        /// </para>
        /// <code>
        /// <![CDATA[
        /// public async Task<OpenApiResult>(
        ///     [OpenApiParameter("x-tenant")] Tenant tenant)
        /// ]]>
        /// </code>
        /// <para>
        /// The attribute is necessary in this case because <c>x-tenant</c> is not an allowable
        /// name for a method parameter in C#.
        /// </para>
        /// </remarks>
        public string ParameterName { get; }
    }
}