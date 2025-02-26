// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailAttachments;

public class AttachmentSummaryDto
{
    public string Filename;
    public string ContentDisposition;
    public string ContentTransferEncoding;
    public string ContentType;
    public int AttachmentId;
}
