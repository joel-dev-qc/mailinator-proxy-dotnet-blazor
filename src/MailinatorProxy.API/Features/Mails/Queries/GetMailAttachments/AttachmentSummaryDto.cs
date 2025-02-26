// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailAttachments;

public class AttachmentSummaryDto
{
    public string Filename { get; set; }
    public string ContentDisposition { get; set; }
    public string ContentTransferEncoding { get; set; }
    public string ContentType { get; set; }
    public int AttachmentId { get; set; }
}
