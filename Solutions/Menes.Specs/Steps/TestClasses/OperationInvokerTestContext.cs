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
    using Moq;

    /// <summary>
    /// Provides the various supporting objects required to be able to instantiate an
    /// <see cref="OpenApiOperationInvoker{TRequest, TResponse}"/>.
    /// </summary>
    internal class OperationInvokerTestContext
    {
        /// <summary>
        /// Gets an object enabling the calls to the <see cref="IOpenApiAccessChecker"/> to be inspected and its
        /// responses determined. This is only available if you call <see cref="UseManualAccessChecks"/>.
        /// </summary>
        public CompletionSourceWithArgs<CheckAccessArguments, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>>? AccessCheckCalls { get; private set; }

        public Mock<IOpenApiServiceOperationLocator> OperationLocator { get; } = new Mock<IOpenApiServiceOperationLocator>();

        public Mock<IOpenApiExceptionMapper> ExceptionMapper { get; } = new Mock<IOpenApiExceptionMapper>();

        public Mock<IOpenApiResultBuilder<object>> ResultBuilder { get; } = new Mock<IOpenApiResultBuilder<object>>();

        public Mock<IOpenApiParameterBuilder<object>> ParameterBuilder { get; } = new Mock<IOpenApiParameterBuilder<object>>();

        public CompletionSource OperationCompletionSource { get; } = new CompletionSource();

        public Task? OperationInvocationTask { get; set; }

        public int ReportedOperationCountWhenOperationBodyInvoked { get; set; }

        public static void AddServices(IServiceCollection services)
        {
            var context = new OperationInvokerTestContext();
            services.AddSingleton(context);
            services.AddSingleton<IOpenApiConfiguration, OpenApiConfiguration>();
            services.AddSingleton(context.OperationLocator.Object);
            services.AddSingleton<IOpenApiAccessChecker>(new AccessChecker(context));
            services.AddSingleton(context.ExceptionMapper.Object);
            services.AddSingleton(context.ResultBuilder.Object);
            services.AddSingleton(context.ParameterBuilder.Object);
            services.AddSingleton(new Mock<IAuditContext>().Object);
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
            public CheckAccessArguments(
                IOpenApiContext context,
                AccessCheckOperationDescriptor[] requests)
            {
                this.Context = context;
                this.Requests = requests;
            }

            public IOpenApiContext Context { get; set; }

            public AccessCheckOperationDescriptor[] Requests { get; set; }
        }

        private class AccessChecker : IOpenApiAccessChecker
        {
            private static readonly AccessControlPolicyResult Allowed = new AccessControlPolicyResult(AccessControlPolicyResultType.Allowed);
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