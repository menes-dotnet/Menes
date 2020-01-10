// <copyright file="OpenApiServiceOperation.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;

    /// <summary>
    /// An OpenAPI service operation.
    /// </summary>
    public class OpenApiServiceOperation
    {
        private readonly Type serviceType;
        private readonly object serviceInstance;
        private readonly MethodInfo operation;
        private readonly IOpenApiConfiguration configuration;
        private readonly object[] defaultValues;
        private readonly bool[] hasDefaultValues;
        private readonly string[] parameterNames;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiServiceOperation"/> class.
        /// </summary>
        /// <param name="serviceType">The type of the service hosting the operation.</param>
        /// <param name="operation">The operation.</param>
        /// <param name="configuration">The OpenAPI configuration.</param>
        public OpenApiServiceOperation(Type serviceType, MethodInfo operation, IOpenApiConfiguration configuration)
            : this(operation, configuration)
        {
            this.serviceType = serviceType ?? throw new ArgumentNullException(nameof(serviceType));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiServiceOperation"/> class.
        /// </summary>
        /// <param name="serviceInstance">The instance of the service hosting the operation.</param>
        /// <param name="operation">The operation.</param>
        /// <param name="configuration">The OpenAPI configuration.</param>
        public OpenApiServiceOperation(object serviceInstance, MethodInfo operation, IOpenApiConfiguration configuration)
            : this(operation, configuration)
        {
            this.serviceInstance = serviceInstance ?? throw new ArgumentNullException(nameof(serviceInstance));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiServiceOperation"/> class.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="configuration">The OpenAPI configuration.</param>
        private OpenApiServiceOperation(MethodInfo operation, IOpenApiConfiguration configuration)
        {
            this.operation = operation ?? throw new ArgumentNullException(nameof(operation));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            ParameterInfo[] parameters = this.operation.GetParameters();
            this.defaultValues = new object[parameters.Length];
            this.hasDefaultValues = new bool[parameters.Length];
            this.parameterNames = new string[parameters.Length];

            for (int i = 0; i < parameters.Length; ++i)
            {
                ParameterInfo parameter = parameters[i];

                if (parameter.HasDefaultValue)
                {
                    this.hasDefaultValues[i] = true;
                    this.defaultValues[i] = parameter.DefaultValue;
                }

                OpenApiParameterAttribute parameterAttribute = parameter.GetCustomAttribute<OpenApiParameterAttribute>();
                this.parameterNames[i] = parameterAttribute?.ParameterName ?? parameter.Name;
            }
        }

        /// <summary>
        /// Execute the service operation.
        /// </summary>
        /// <param name="serviceProvider">The service provider associated with the execution context.</param>
        /// <param name="inputParameters">The parameters for the operation.</param>
        /// <returns>The result.</returns>
        public object Execute(
            IServiceProvider serviceProvider,
            IDictionary<string, object> inputParameters)
        {
            if (inputParameters is null)
            {
                throw new ArgumentNullException(nameof(inputParameters));
            }

            object[] paramArray = new object[this.parameterNames.Length];

            for (int index = 0; index < this.parameterNames.Length; ++index)
            {
                string parameterName = this.parameterNames[index];
                Type targetType = this.operation.GetParameters()[index].ParameterType;

                if (inputParameters.TryGetValue(parameterName, out object value)
                    || (this.configuration.EnableNonExactParameterMatching
                     && TryGetInputParameterWithNonExactMatch(inputParameters, parameterName, out value)))
                {
                    if (parameterName == "body" && value is string stringValue)
                    {
                        if (targetType.IsAssignableFrom(value.GetType()))
                        {
                            paramArray[index] = value;
                        }
                        else if (targetType.IsEnum)
                        {
                            paramArray[index] = Enum.Parse(targetType, stringValue, ignoreCase: true);
                        }
                        else
                        {
                            paramArray[index] = JsonConvert.DeserializeObject(stringValue, targetType, this.configuration.SerializerSettings);
                        }
                    }
                    else if (targetType.IsEnum)
                    {
                        if (value is string stringValue2)
                        {
                            paramArray[index] = Enum.Parse(targetType, stringValue2, ignoreCase: true);
                        }
                        else
                        {
                            paramArray[index] = Enum.ToObject(targetType, value);
                        }
                    }
                    else
                    {
                        paramArray[index] = value;
                    }
                }
                else
                {
                    if (this.hasDefaultValues[index])
                    {
                        paramArray[index] = this.defaultValues[index];
                    }
                }
            }

            return this.operation.Invoke(this.serviceInstance ?? serviceProvider.GetService(this.serviceType), paramArray);
        }

        /// <summary>
        /// Gets the name of the operation.
        /// </summary>
        /// <returns>A string containing the name of the operation.</returns>
        public string GetName()
        {
            return this.operation.Name;
        }

        private static bool TryGetInputParameterWithNonExactMatch(
            IDictionary<string, object> inputParameters,
            string parameterName,
            out object value)
        {
            value = null;
            string canonicalizedName = CanonicalizeParameterNameForMatching(parameterName);
            foreach (KeyValuePair<string, object> kv in inputParameters)
            {
                if (CanonicalizeParameterNameForMatching(kv.Key) == canonicalizedName)
                {
                    value = kv.Value;
                    return true;
                }
            }

            return false;
        }

        private static string CanonicalizeParameterNameForMatching(string name)
            => new string(name.Where(c => c != '-').Select(c => char.ToLowerInvariant(c)).ToArray());
    }
}