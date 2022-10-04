//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Corvus.Json;
using Corvus.Json.Internal;

namespace Menes.OpenApiSchema.V31;
public readonly partial struct Document
{
    public readonly partial struct Parameter
    {
        /// <summary>
        /// A type generated from a JsonSchema specification.
        /// </summary>
        public readonly partial struct InEntity
        {
            /// <summary>
            /// Permitted values.
            /// </summary>
            public static class EnumValues
            {
                /// <summary>
                /// Query.
                /// </summary>
                /// <remarks>
                /// {Description}.
                /// </remarks>
                public static readonly InEntity Query = InEntity.Parse("\"query\"");
                /// <summary>
                /// Header.
                /// </summary>
                /// <remarks>
                /// {Description}.
                /// </remarks>
                public static readonly InEntity Header = InEntity.Parse("\"header\"");
                /// <summary>
                /// Path.
                /// </summary>
                /// <remarks>
                /// {Description}.
                /// </remarks>
                public static readonly InEntity Path = InEntity.Parse("\"path\"");
                /// <summary>
                /// Cookie.
                /// </summary>
                /// <remarks>
                /// {Description}.
                /// </remarks>
                public static readonly InEntity Cookie = InEntity.Parse("\"cookie\"");
                /// <summary>
                /// [{Title} || Item 0] (with predictable naming).
                /// </summary>
                /// <remarks>
                /// {Description}.
                /// </remarks>
                internal static readonly InEntity Item0 = InEntity.Parse("\"query\"");
                /// <summary>
                /// [{Title} || Item 1] (with predictable naming).
                /// </summary>
                /// <remarks>
                /// {Description}.
                /// </remarks>
                internal static readonly InEntity Item1 = InEntity.Parse("\"header\"");
                /// <summary>
                /// [{Title} || Item 2] (with predictable naming).
                /// </summary>
                /// <remarks>
                /// {Description}.
                /// </remarks>
                internal static readonly InEntity Item2 = InEntity.Parse("\"path\"");
                /// <summary>
                /// [{Title} || Item 3] (with predictable naming).
                /// </summary>
                /// <remarks>
                /// {Description}.
                /// </remarks>
                internal static readonly InEntity Item3 = InEntity.Parse("\"cookie\"");
            }
        }
    }
}