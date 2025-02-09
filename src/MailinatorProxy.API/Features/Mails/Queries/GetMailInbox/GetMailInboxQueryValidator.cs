// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using FluentValidation;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailInbox;

internal class GetMailInboxQueryValidator : AbstractValidator<GetMailInboxQuery>
{
    public GetMailInboxQueryValidator()
    {
        RuleFor(x => x.Domain)
            .NotEmpty()
            .WithMessage("Domain is required.");

        RuleFor(x => x.Inbox)
            .NotEmpty()
            .WithMessage("Inbox is required.");

        RuleFor(x => x.Skip)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Skip must be greater than or equal to 0.");

        RuleFor(x => x.Limit)
            .InclusiveBetween(1, 50)
            .WithMessage("Limit must be between 1 and 50.");

        RuleFor(x => x.Sort)
            .IsInEnum()
            .WithMessage("Invalid sorting direction.");

        RuleFor(x => x.DecodeSubject)
            .NotNull()
            .WithMessage("DecodeSubject is required.");
    }
}
