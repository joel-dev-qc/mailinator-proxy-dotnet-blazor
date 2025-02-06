// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.API.Common.Dtos;

public class MessageDto
{
    public string Subject { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string Id { get; set; }
    public long Time { get; set; }
    public long SecondsAgo { get; set; }
    public string Domain { get; set; }
    public bool IsFirstExchange { get; set; }
    public string Fromfull { get; set; }
    public Dictionary<string, object> Headers { get; set; }
    public List<PartDto> Parts { get; set; }
    public string Origfrom { get; set; }
    public string Mrid { get; set; }
    public int Size { get; set; }
    public string Stream { get; set; }
    public string MsgType { get; set; }
    public string Source { get; set; }
    public string Text { get; set; }
}
