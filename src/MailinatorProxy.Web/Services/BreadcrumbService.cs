using System.Collections.Generic;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace MailinatorProxy.Web.Services
{
    public class BreadcrumbService : IBreadcrumbService
    {
        private readonly IStringLocalizer<BreadcrumbService> _localizer;

        public BreadcrumbService(IStringLocalizer<BreadcrumbService> localizer)
        {
            _localizer = localizer;
        }

        public List<BreadcrumbItem> GetInboxBreadcrumbs(string domain, string? mailId = null)
        {
            var items = new List<BreadcrumbItem>
            {
                new(_localizer["Home_Label"], "", false, icon: Icons.Material.Filled.Home),
                new(domain, $"/{domain}", true, icon: Icons.Material.Filled.Domain)
            };

            if (string.IsNullOrEmpty(mailId))
            {
                items.Add(new(_localizer["Inbox_Label"], null, true, icon: Icons.Material.Filled.Inbox));
            }
            else
            {
                items.Add(new(_localizer["Inbox_Label"], $"/{domain}/Inbox", false, icon: Icons.Material.Filled.Inbox));
                items.Add(new(_localizer["Details_Label"], null, true, icon: Icons.Material.Filled.Email));
            }

            return items;
        }
    }
}

