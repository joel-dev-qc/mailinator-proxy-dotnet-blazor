using FluentValidation;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailAttachmentById;

public class GetMailAttachmentByIdQueryValidator : AbstractValidator<GetMailAttachmentByIdQuery>
{
    public GetMailAttachmentByIdQueryValidator()
    {
        RuleFor(x => x.Domain).NotEmpty();
        RuleFor(x => x.Inbox).NotEmpty();
        RuleFor(x => x.MessageId).NotEmpty();
        RuleFor(x => x.AttachmentId).NotEmpty();
    }
}
