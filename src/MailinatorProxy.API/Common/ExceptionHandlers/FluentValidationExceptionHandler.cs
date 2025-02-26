// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MailinatorProxy.API.Common.ExceptionHandlers;

internal class FluentValidationExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not ValidationException fluentValidationException)
        {
            return false;
        }

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        await problemDetailsService.TryWriteAsync(new ProblemDetailsContext()
        {
            HttpContext = httpContext,
            ProblemDetails = new ValidationProblemDetails
            {
                Title = "Validation Error",
                Detail = "Validation failed for one or more properties.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Status = StatusCodes.Status400BadRequest,
                Errors = fluentValidationException.Errors
                    .ToDictionary(e => e.PropertyName, e => new[] {e.ErrorMessage})
            },
            Exception = fluentValidationException,
        }).ConfigureAwait(false);
        return true;
    }
}
