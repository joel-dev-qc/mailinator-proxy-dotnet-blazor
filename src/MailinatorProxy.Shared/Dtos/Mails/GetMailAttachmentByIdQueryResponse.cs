namespace MailinatorProxy.Shared.Dtos.Mails;

public class GetMailAttachmentByIdQueryResponse
{
    public byte[] Bytes { get; set; }

    public string Content { get; set; }

    public string ContentType { get; set; }
}
