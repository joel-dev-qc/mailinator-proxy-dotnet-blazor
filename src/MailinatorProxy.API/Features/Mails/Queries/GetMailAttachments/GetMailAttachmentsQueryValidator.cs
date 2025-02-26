using FluentValidation;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailAttachments;

internal class GetMailAttachmentsQueryValidator : AbstractValidator<GetMailAttachmentsQuery>
{
    public GetMailAttachmentsQueryValidator()
    {
        RuleFor(x => x.Domain).NotEmpty();
        RuleFor(x => x.MessageId).NotEmpty();
    }
}
