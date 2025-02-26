// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using FluentValidation;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailInbox;

internal class GetMailInboxQueryValidator : AbstractValidator<GetMailInboxQuery>
{
    public GetMailInboxQueryValidator()
    {
        RuleFor(x => x.Domain)
            .NotEmpty();

        RuleFor(x => x.Inbox)
            .NotEmpty();

        RuleFor(x => x.Skip)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Limit)
            .InclusiveBetween(1, 50);

        RuleFor(x => x.Sort)
            .IsInEnum();

        RuleFor(x => x.DecodeSubject)
            .NotNull();
    }
}
