// <copyright file="ExceptionDetail.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Fakes
{
    using System;
    using Corvus.Monitoring.Instrumentation;

    /// <summary>
    /// Describes exception instrumentation that was delivered to one of our fakes.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This represents a single call to <see cref="IExceptionsInstrumentation.ReportException(Exception, AdditionalInstrumentationDetail)"/>.
    /// </para>
    /// </remarks>
    public class ExceptionDetail
    {
        public ExceptionDetail(
            Exception x,
            AdditionalInstrumentationDetail? additionalDetail,
            OperationDetail operationInProgressAtTime)
        {
            this.Exception = x;
            this.AdditionalDetail = additionalDetail;
            this.OperationInProgressAtTime = operationInProgressAtTime;
        }

        /// <summary>
        /// Gets the exception passed to the call to <see cref="IExceptionsInstrumentation.ReportException(Exception, AdditionalInstrumentationDetail)"/>.
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Gets the additional instrumentation detail (if any) passed to the call to
        /// <see cref="IExceptionsInstrumentation.ReportException(Exception, AdditionalInstrumentationDetail)"/>.
        /// </summary>
        public AdditionalInstrumentationDetail? AdditionalDetail { get; }

        /// <summary>
        /// Gets the <see cref="OperationDetail"/> that was in progress at the instant this exception was reported.
        /// </summary>
        public OperationDetail OperationInProgressAtTime { get; }
    }
}