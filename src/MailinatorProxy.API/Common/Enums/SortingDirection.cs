// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Text.Json.Serialization;

namespace MailinatorProxy.API.Common.Enums;

[JsonConverter(typeof(JsonStringEnumConverter<SortingDirection>))]
public enum SortingDirection
{
    Ascending,
    Descending
}
