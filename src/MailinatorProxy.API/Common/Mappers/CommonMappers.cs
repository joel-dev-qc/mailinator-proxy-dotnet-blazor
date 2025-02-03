// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using mailinator_csharp_client.Models.Messages.Entities;
using MailinatorProxy.API.Common.Enums;

namespace MailinatorProxy.API.Common.Mappers;

internal static class CommonMappers
{
    public static Sort MapSort(this SortingDirection sort)
    {
        return sort switch
        {
            SortingDirection.Ascending => Sort.asc,
            SortingDirection.Descending => Sort.desc,
            _ => Sort.desc
        };
    }
}
