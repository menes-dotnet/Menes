// <copyright file="OperationInvokerTestContext.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps.TestClasses
{
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
        public Mock<IOpenApiServiceOperationLocator> OperationLocator { get; } = new Mock<IOpenApiServiceOperationLocator>();
        public Mock<IOpenApiAccessChecker> AccessChecker { get; } = new Mock<IOpenApiAccessChecker>();
        public Mock<IOpenApiExceptionMapper> ExceptionMapper { get; } = new Mock<IOpenApiExceptionMapper>();
        public Mock<IOpenApiResultBuilder<object>> ResultBuilder { get; } = new Mock<IOpenApiResultBuilder<object>>();
        public Mock<IOpenApiParameterBuilder<object>> ParameterBuilder { get; } = new Mock<IOpenApiParameterBuilder<object>>();

        public static void AddServices(IServiceCollection services)
        {
            var context = new OperationInvokerTestContext();
            services.AddSingleton(context);
            services.AddSingleton<IOpenApiConfiguration, OpenApiConfiguration>();
            services.AddSingleton(context.OperationLocator.Object);
            services.AddSingleton(context.AccessChecker.Object);
            services.AddSingleton(context.ExceptionMapper.Object);
            services.AddSingleton(context.ResultBuilder.Object);
            services.AddSingleton(context.ParameterBuilder.Object);
            services.AddSingleton(new Mock<IAuditContext>().Object);
            services.AddSingleton<OpenApiOperationInvoker<object, object>>();
        }
    }
}