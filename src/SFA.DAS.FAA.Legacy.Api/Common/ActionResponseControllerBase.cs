﻿using Microsoft.AspNetCore.Mvc;
using SFA.DAS.FAA.Legacy.Application.Mediatr.Responses;
using System.Diagnostics.CodeAnalysis;
using FluentValidation.Results;
using SFA.DAS.FAA.Legacy.Application.Common;

namespace SFA.DAS.FAA.Legacy.Api.Common
{
    [ExcludeFromCodeCoverage]
    public abstract class ActionResponseControllerBase : ControllerBase
    {
        private const string GetMethodName = "Get";
        public const string PutMethodName = "Put";

        protected abstract string ControllerName { get; }

        protected IActionResult GetResponse<T>(ValidatedResponse<T> response) where T : class
        {
            if (response.Result == null && response.IsValidResponse) return NotFound();

            if (response.IsValidResponse) return new OkObjectResult(response.Result);

            return new BadRequestObjectResult(FormatErrors(response.Errors));
        }

        protected IActionResult GetPostResponse<T>(ValidatedResponse<T> response, object? routeParameters)
            where T : class
        {
            if (response.IsValidResponse)
            {
                return new CreatedAtActionResult(GetMethodName, ControllerName, routeParameters, response.Result);
            }

            return new BadRequestObjectResult(FormatErrors(response.Errors));
        }

        protected IActionResult GetPutResponse(ValidatedResponse<SuccessCommandResult> response)
        {
            return response.IsValidResponse ? NoContent() : new BadRequestObjectResult(FormatErrors(response.Errors));
        }

        protected IActionResult GetPatchResponse(ValidatedResponse<SuccessCommandResult> response)
        {
            if (response.Result is {IsSuccess: false}) return NotFound();

            if (response.IsValidResponse) return NoContent();

            return new BadRequestObjectResult(FormatErrors(response.Errors));
        }

        private static List<ValidationError> FormatErrors(IEnumerable<ValidationFailure> errors)
        {
            return errors.Select(err => new ValidationError
            {
                PropertyName = err.PropertyName,
                ErrorMessage = err.ErrorMessage
            }).ToList();
        }
    }
}