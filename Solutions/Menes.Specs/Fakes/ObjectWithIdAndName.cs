// <copyright file="ObjectWithIdAndName.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Fakes;

/// <summary>
/// Type used to test serialization of responses from objects with simple properties.
/// </summary>
/// <param name="Id">A unique id.</param>
/// <param name="Name">A name.</param>
public record ObjectWithIdAndName(int Id, string Name);