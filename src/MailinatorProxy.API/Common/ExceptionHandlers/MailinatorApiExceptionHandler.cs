// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using mailinator_csharp_client.Helpers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MailinatorProxy.API.Common.ExceptionHandlers;

internal class MailinatorApiExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not ApiException apiException)
        {
            return false;
        }

        httpContext.Response.StatusCode = (int)apiException.HttpStatusCode;
        await problemDetailsService.TryWriteAsync(new ProblemDetailsContext()
        {
            HttpContext = httpContext,
            ProblemDetails = new ProblemDetails
            {
                Title = apiException.StatusDescription,
                Detail = apiException.Message,
                Status = (int)apiException.HttpStatusCode,
            },
            Exception = apiException,
        });
        return true;
    }
}
