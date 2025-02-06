// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using mailinator_csharp_client.Models.Messages.Entities;
using MailinatorProxy.API.Common.Dtos;
using Riok.Mapperly.Abstractions;

namespace MailinatorProxy.API.Common.Mappers;

[Mapper]
internal static partial class MessageMapper
{
    public static partial MessageDto MapMessageDto(this Message message);
}
