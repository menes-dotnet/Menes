// <copyright file="UriTemplateConverter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// Derived from Tavis.UriTemplate https://github.com/tavis-software/Tavis.UriTemplates/blob/master/License.txt

namespace Menes.Json.UriTemplates
{
    using System;
    using System.ComponentModel;
    using System.Globalization;

    /// <summary>
    /// Converts to <see cref="UriTemplate"/> instances from other representations.
    /// </summary>
    public sealed class UriTemplateConverter
        : TypeConverter
    {
        /// <inheritdoc/>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        /// <inheritdoc/>
        public override object? ConvertFrom(
            ITypeDescriptorContext context,
            CultureInfo culture,
            object value)
        {
            if (value == null)
            {
                return null;
            }

            if (value is string template)
            {
                if (template.Length == 0)
                {
                    // For TypeConverter purposes, an empty string is "no value."
                    return null;
                }

                return new UriTemplate(template);
            }

            throw (NotSupportedException)this.GetConvertFromException(value);
        }
    }
}
