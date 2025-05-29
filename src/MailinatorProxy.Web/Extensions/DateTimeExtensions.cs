// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Globalization;

namespace MailinatorProxy.Web.Extensions;

public static class DateTimeExtensions
{
    public static string ToRelativeDateString(this DateTime date)
    {
        if (date == default)
        {
            return string.Empty;
        }

        var now = DateTime.UtcNow;
        var culture = CultureInfo.CurrentCulture;
        string todayText = culture.TwoLetterISOLanguageName == "fr" ? "Aujourd'hui" : "Today";
        string yesterdayText = culture.TwoLetterISOLanguageName == "fr" ? "Hier" : "Yesterday";
        var timeSpan = now - date;

        if (date.Date == now.Date)
        {
            switch (timeSpan.TotalSeconds)
            {
                case < 60:
                    return culture.TwoLetterISOLanguageName == "fr" ? $"Il y a {timeSpan.Seconds} s" : $"{timeSpan.Seconds} seconds ago";
                default:
                {
                    switch (timeSpan.TotalMinutes)
                    {
                        case < 60:
                            return culture.TwoLetterISOLanguageName == "fr" ? $"Il y a {timeSpan.Minutes} minutes" : $"{timeSpan.Minutes} minutes ago";
                        default:
                        {
                            if (timeSpan.TotalHours < 6)
                            {
                                return culture.TwoLetterISOLanguageName == "fr" ? $"Il y a {timeSpan.Hours} h" : $"{timeSpan.Hours} hours ago";
                            }

                            return todayText;
                        }
                    }
                }
            }
        }

        if (date.Date == now.Date.AddDays(-1))
        {
            return yesterdayText;
        }

        return date.ToString("yyyy-MM-dd", culture);
    }

    public static DateTime ToDateTime(this long dateInTime)
    {
        return DateTimeOffset.FromUnixTimeMilliseconds(dateInTime).DateTime;
    }
}
