// <copyright file="OperationInvokerTestContext.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps.TestClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Idg.AsyncTest;
    using Menes;
    using Menes.Auditing;
    using Menes.Internal;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using TechTalk.SpecFlow.Assist;

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
        public CompletionSourceWithArgs<CheckAccessArguments, IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> AccessCheckCalls { get; private set; }
        public CompletionSourceWithArgs<ScopeBuilderArguments<object>> ScopeBuilderCalls { get; private set; }

        public Mock<IOpenApiServiceOperationLocator> OperationLocator { get; } = new Mock<IOpenApiServiceOperationLocator>();
        public Mock<IOpenApiExceptionMapper> ExceptionMapper { get; } = new Mock<IOpenApiExceptionMapper>();
        public Mock<IOpenApiResultBuilder<object>> ResultBuilder { get; } = new Mock<IOpenApiResultBuilder<object>>();
        public Mock<IOpenApiParameterBuilder<object>> ParameterBuilder { get; } = new Mock<IOpenApiParameterBuilder<object>>();
        public CompletionSource OperationCompletionSource { get; } = new CompletionSource();
        public Task OperationInvocationTask { get; set; }
        public int ReportedOperationCountWhenOperationBodyInvoked { get; set; }

        public static void AddServices(IServiceCollection services)
        {
            var context = new OperationInvokerTestContext();
            services.AddSingleton(context);
            services.AddSingleton<IOpenApiConfiguration, OpenApiConfiguration>();
            services.AddSingleton(context.OperationLocator.Object);
            services.AddSingleton<IOpenApiAccessChecker>(new AccessChecker(context));
            services.AddOpenApiScopeBuilder<ScopeBuilder, object>(_ => new ScopeBuilder(context));
            services.AddSingleton(context.ExceptionMapper.Object);
            services.AddSingleton(context.ResultBuilder.Object);
            services.AddSingleton(context.ParameterBuilder.Object);
            services.AddSingleton(new Mock<IAuditContext>().Object);
            services.AddRequestScopeFactory<object>();
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

        /// <summary>
        /// Disables the default behaviour in which all access checks past, and instead enables access checking to be
        /// controlled through the <see cref="AccessCheckCalls"/> property.
        /// </summary>
        public void UseScopeBuilder()
        {
            this.ScopeBuilderCalls = new CompletionSourceWithArgs<ScopeBuilderArguments<object>>();
        }


        public class CheckAccessArguments
        {
            public AccessCheckOperationDescriptor[] Requests { get; set; }
        }

        public class ScopeBuilderArguments<TRequest>
        {
            public IServiceProvider ServiceProvider { get; set; }

            public string Path { get; set; }

            public string Method { get; set; }

            public TRequest Request { get; set; }

            public object Parameters { get; set; }

            public OpenApiOperationPathTemplate OperationPathTemplate { get; set; }
        }

        private class ScopeBuilder : IOpenApiScopeBuilder<object>
        {
            private readonly OperationInvokerTestContext context;

            public ScopeBuilder(OperationInvokerTestContext context)
            {
                this.context = context;
            }

            public Task BuildScope(IServiceProvider serviceProvider, string path, string method, object request, object parameters, OpenApiOperationPathTemplate operationPathTemplate)
            {
                return this.context.ScopeBuilderCalls == null
                    ? Task.CompletedTask
                    : this.context.ScopeBuilderCalls.GetTask(
                        new ScopeBuilderArguments<object>
                        {
                            ServiceProvider = serviceProvider,
                            Path = path,
                            Method = method,
                            Request = request,
                            Parameters = parameters,
                            OperationPathTemplate = operationPathTemplate,
                        });
            }
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
                params AccessCheckOperationDescriptor[] descriptors)
            {
                return this.context.AccessCheckCalls == null
                    ? Task.FromResult<IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>>(descriptors.ToDictionary(d => d, __ => Allowed))
                    : this.context.AccessCheckCalls.GetTask(new CheckAccessArguments { Requests = descriptors });
            }
        }
    }
}