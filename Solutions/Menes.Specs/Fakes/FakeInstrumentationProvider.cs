// <copyright file="FakeInstrumentationProvider.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Menes.Specs.Fakes
{
    using System;
    using System.Collections.Generic;
    using Corvus.Monitoring.Instrumentation;
    using NUnit.Framework;

    /// <summary>
    /// Implements instrumentation interfaces, and reports what they see.
    /// </summary>
    internal class FakeInstrumentationProvider : IOperationsInstrumentation, IExceptionsInstrumentation
    {
        private readonly List<OperationDetail> operations = new List<OperationDetail>();
        private readonly List<ExceptionDetail> exceptions = new List<ExceptionDetail>();
        private readonly Stack<OperationDetail> operationsInProgress = new Stack<OperationDetail>();

        /// <summary>
        /// Gets a list of the operations supplied to the fake <see cref="IOperationsInstrumentation"/> implementation.
        /// </summary>
        public IReadOnlyList<OperationDetail> Operations => this.operations;

        /// <summary>
        /// Gets a list of the exceptions supplied to the fake <see cref="IExceptionsInstrumentation"/> implementation.
        /// </summary>
        public IReadOnlyList<ExceptionDetail> Exceptions => this.exceptions;

        /// <inheritdoc/>
        public IOperationInstance StartOperation(string name, AdditionalInstrumentationDetail additionalDetail = null)
        {
            var result = new OperationDetail(
                name,
                additionalDetail,
                detailJustPopped =>
                {
                    OperationDetail current = this.operationsInProgress.Pop();
                    Assert.AreSame(detailJustPopped, current);
                });
            this.operationsInProgress.Push(result);
            this.operations.Add(result);
            return result;
        }

        /// <inheritdoc/>
        public void ReportException(Exception x, AdditionalInstrumentationDetail additionalDetail = null)
        {
            this.exceptions.Add(new ExceptionDetail(x, additionalDetail, this.operationsInProgress.Peek()));
        }
    }
}