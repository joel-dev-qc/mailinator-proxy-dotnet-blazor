// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Text.RegularExpressions;

namespace MailinatorProxy.Web.Extensions;

public static class StringExtensions
{
    public static List<(string name, string link)> GetLinksFromHtml(this string? html)
    {
        var links = new List<(string name, string link)>();
        if (string.IsNullOrEmpty(html))
            return links;

        var htmlDoc = new HtmlAgilityPack.HtmlDocument();
        htmlDoc.LoadHtml(html);
        var anchorLinks = htmlDoc.DocumentNode.SelectNodes("//a");

        foreach (var anchorLink in anchorLinks ?? Enumerable.Empty<HtmlAgilityPack.HtmlNode>())
        {
            var href = anchorLink.GetAttributeValue("href", string.Empty);
            if (!string.IsNullOrEmpty(href))
            {
                links.Add((anchorLink.InnerText, href));
            }
        }
        return links;
    }

    public static List<(string name, string link)> GetLinksFromText(this string? text)
    {
        var links = new List<(string name, string link)>();
        if (string.IsNullOrEmpty(text))
            return links;

        var urlRegex = new Regex(@"https?://[^\s<>""']+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        var matches = urlRegex.Matches(text);

        foreach (Match match in matches)
        {
            var url = match.Value;
            links.Add((string.Empty, url));
        }
        return links;
    }
}
