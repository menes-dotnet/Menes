// <copyright file="IJsonArray.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections;

    /// <summary>
    /// Represents any object value that can be represented as Json.
    /// </summary>
    public interface IJsonArray : IJsonValue, IEnumerable
    {
    }
}