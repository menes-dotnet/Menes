// <copyright file="FakeInstrumentationProvider.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Menes.Specs.Fakes
{
    using System.Collections.Generic;
    using Corvus.Monitoring.Instrumentation;

    /// <summary>
    /// Implements instrumentation interfaces, and reports what they see.
    /// </summary>
    internal class FakeInstrumentationProvider : IOperationsInstrumentation
    {
        private readonly List<OperationDetail> operations = new List<OperationDetail>();

        /// <summary>
        /// Gets a list of the operations supplied to the fake <see cref="IOperationsInstrumentation"/> implementation.
        /// </summary>
        public IReadOnlyList<OperationDetail> Operations => this.operations;

        /// <inheritdoc/>
        public IOperationInstance StartOperation(string name, AdditionalInstrumentationDetail additionalDetail = null)
        {
            var result = new OperationDetail(name, additionalDetail);
            this.operations.Add(result);
            return result;
        }
    }
}