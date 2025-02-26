// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using FluentValidation;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailById;

public class GetMailByIdQueryValidator : AbstractValidator<GetMailByIdQuery>
{
    public GetMailByIdQueryValidator()
    {
        RuleFor(x => x.Domain)
            .NotEmpty();

        RuleFor(x => x.MessageId)
            .NotEmpty();
    }
}
