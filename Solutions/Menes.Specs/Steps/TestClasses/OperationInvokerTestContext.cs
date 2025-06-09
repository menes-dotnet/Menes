// <copyright file="OperationInvokerTestContext.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps.TestClasses
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Idg.AsyncTest;

    using Menes.Auditing;
    using Menes.Internal;

    using Microsoft.Extensions.DependencyInjection;

    using NSubstitute;

    /// <summary>
    /// Provides the various supporting objects required to be able to instantiate an
    /// <see cref="OpenApiOperationInvoker{TRequest, TResponse}"/>.
    /// </summary>
    internal class OperationInvokerTestContext
    {        /// <summary>
        /// Gets an object enabling the calls to the <see cref="IOpenApiAccessChecker"/> to be inspected and its
        /// responses determined. This is only available if you call <see cref="UseManualAccessChecks"/>.
        /// </summary>
        public CompletionSourceWithArgs<CheckAccessArguments, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>>? AccessCheckCalls { get; private set; }

        public IOpenApiServiceOperationLocator OperationLocator { get; } = Substitute.For<IOpenApiServiceOperationLocator>();

        public IOpenApiExceptionMapper ExceptionMapper { get; } = Substitute.For<IOpenApiExceptionMapper>();

        public IOpenApiResultBuilder<object> ResultBuilder { get; } = Substitute.For<IOpenApiResultBuilder<object>>();

        public IOpenApiParameterBuilder<object> ParameterBuilder { get; } = Substitute.For<IOpenApiParameterBuilder<object>>();

        public CompletionSource OperationCompletionSource { get; } = new CompletionSource();

        public Task? OperationInvocationTask { get; set; }

        public int ReportedOperationCountWhenOperationBodyInvoked { get; set; }

        public static void AddServices(IServiceCollection services)
        {
            var context = new OperationInvokerTestContext();
            services.AddSingleton(context);
            services.AddSingleton(context.OperationLocator);
            services.AddSingleton<IOpenApiAccessChecker>(new AccessChecker(context));
            services.AddSingleton(context.ExceptionMapper);
            services.AddSingleton(context.ResultBuilder);
            services.AddSingleton(context.ParameterBuilder);
            services.AddSingleton(Substitute.For<IAuditContext>());
            services.AddSingleton<OpenApiOperationInvoker<object, object>>();
        }

        /// <summary>
        /// Disables the default behaviour in which all access checks past, and instead enables access checking to be
        /// controlled through the <see cref="AccessCheckCalls"/> property.
        /// </summary>
        public void UseManualAccessChecks()
        {
            this.AccessCheckCalls = new CompletionSourceWithArgs<CheckAccessArguments, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>>();
        }

        public class CheckAccessArguments
        {
            public CheckAccessArguments(IOpenApiContext context, AccessCheckOperationDescriptor[] requests)
            {
                this.Context = context;
                this.Requests = requests;
            }

            public IOpenApiContext Context { get; set; }

            public AccessCheckOperationDescriptor[] Requests { get; set; }
        }

        private class AccessChecker : IOpenApiAccessChecker
        {
            private static readonly AccessControlPolicyResult Allowed = new(AccessControlPolicyResultType.Allowed);
            private readonly OperationInvokerTestContext context;

            public AccessChecker(OperationInvokerTestContext context)
            {
                this.context = context;
            }

            public Task<IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> CheckAccessPoliciesAsync(
                IOpenApiContext context,
                params AccessCheckOperationDescriptor[] descriptors)
            {
                return this.context.AccessCheckCalls == null
                    ? Task.FromResult<IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>>(descriptors.ToDictionary(d => d, __ => Allowed))
                    : this.context.AccessCheckCalls.GetTask(new CheckAccessArguments(context, descriptors));
            }
        }
    }
}