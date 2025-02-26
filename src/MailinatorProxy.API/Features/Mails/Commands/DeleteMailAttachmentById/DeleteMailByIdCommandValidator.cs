using FluentValidation;

namespace MailinatorProxy.API.Features.Mails.Commands.DeleteMailAttachmentById;

internal class DeleteMailByIdCommandValidator : AbstractValidator<DeleteMailByIdCommand>
{
    public DeleteMailByIdCommandValidator()
    {
        RuleFor(x => x.Domain).NotEmpty();
        RuleFor(x => x.Inbox).NotEmpty();
        RuleFor(x => x.MessageId).NotEmpty();
    }
}
