﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SFA.DAS.FAA.Legacy.Application.Mediatr.Responses;
using System.Diagnostics.CodeAnalysis;

namespace SFA.DAS.FAA.Legacy.Application.Mediatr.Behaviours
{
    [ExcludeFromCodeCoverage]
    public class ValidationBehaviour<TRequest, TResponse>(
        IValidator<TRequest> compositeValidator,
        ILogger<TRequest> logger)
        : IPipelineBehavior<TRequest, TResponse>
        where TResponse : ValidatedResponse
        where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            logger.LogTrace("Validating FAA Legacy API Connector request");

            var result = await compositeValidator.ValidateAsync(request, cancellationToken);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(s => s.ErrorMessage).Aggregate(
                    (acc, current) => acc + string.Concat(' ', current)
                );

                logger.LogTrace("{errors}", errors);

                var responseType = typeof(TResponse);

                if (responseType.IsGenericType)
                {
                    var resultType = responseType.GetGenericArguments()[0];
                    var invalidResponseType = typeof(ValidatedResponse<>).MakeGenericType(resultType);

                    if (Activator.CreateInstance(invalidResponseType,
                            result.Errors) as TResponse is { } invalidResponse)
                        return invalidResponse;
                }
            }

            logger.LogTrace("Validation passed");

            var response = await next();

            return response;
        }
    }
}