// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MudBlazor;

namespace MailinatorProxy.Web.Shared;

public class CustomTheme : MudTheme
{
    public CustomTheme() : base()
    {
        Typography = s_pageTypography;
    }

    private static readonly Typography s_pageTypography = new()
    {
        Default = new DefaultTypography()
        {
            FontFamily = new[] { "Radio Canada", "serif", "Roboto", "Arial", "sans-serif" },
            LetterSpacing = "normal"
        },
        H1 = new H1Typography()
        {
            FontSize = "2.25rem",
            FontWeight = "300",
        },

        H2 = new H2Typography()
        {
            FontSize = "2.00rem",
            FontWeight = "250",
        },
        H3 = new H3Typography()
        {
            FontSize = "1.8rem",
            FontWeight = "200",
            LineHeight = "1.8",
        },
        H4 = new H4Typography()
        {
            FontSize = "1.6rem",
            FontWeight = "260",
        },
        H5 = new H5Typography()
        {
            FontSize = "1.5rem",
            FontWeight = "250",
            LineHeight = "2",
        },
        H6 = new H6Typography()
        {
            FontSize = "1.125rem",
            FontWeight = "260",
            LineHeight = "2",
        },
        Subtitle1 = new Subtitle1Typography()
        {
            FontSize = "1.1rem",
            FontWeight = "500"
        },
        Subtitle2 = new Subtitle2Typography()
        {
            FontSize = "1rem",
            FontWeight = "600",
            LineHeight = "1.8",
        },
        Body1 = new Body1Typography()
        {
            FontSize = "1rem",
            FontWeight = "400"
        },
        Button = new ButtonTypography()
        {
            TextTransform = "none"
        }
    };
}
