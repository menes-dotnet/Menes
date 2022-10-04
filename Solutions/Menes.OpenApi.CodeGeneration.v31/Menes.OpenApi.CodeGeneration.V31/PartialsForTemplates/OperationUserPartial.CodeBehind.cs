// <copyright file="OperationUserPartial.CodeBehind.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections.Immutable;

namespace Menes.OpenApi.CodeGeneration.V31;

/// <summary>
/// The code behind for OperationUserPartial.tt.
/// </summary>
public partial class OperationUserPartial
{
    private readonly MenesOperation operation;

    /// <summary>
    /// Initializes a new instance of the <see cref="OperationUserPartial"/> class.
    /// </summary>
    /// <param name="ns">The namespace into which we are generating the types.</param>
    /// <param name="operation">The operation for which this is to be generated.</param>
    public OperationUserPartial(string ns, MenesOperation operation)
    {
        this.Namespace = ns;
        this.operation = operation;
    }

    /// <summary>
    /// Gets the namespace into which we are generating the types.
    /// </summary>
    public string Namespace { get; }

    /// <summary>
    /// Gets the Operation ID.
    /// </summary>
    public string OperationId => this.operation.Id;

    /// <summary>
    /// Gets the summary text for the operation, or null if no summary is found.
    /// </summary>
    public string? OperationSummary => this.operation.Summary;

    /// <summary>
    /// Gets the (short) dotnet type name for the operation.
    /// </summary>
    public string OperationDotnetTypeName => this.operation.DotnetTypeName;

    /// <summary>
    /// Gets the (short) dotnet type name for the operation result.
    /// </summary>
    public string OperationResultDotnetTypeName => this.operation.ResultDotnetTypeName;

    /// <summary>
    /// Gets the operation responses.
    /// </summary>
    public ImmutableArray<MenesResponse> OperationResponses => this.operation.Responses;
}