using PRSiteUmbraco.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PRSiteUmbraco.Entities
{
    public class NavigationListItem
    {
        public string Text { get; set; }
        public NavigationLink Link { get; set; }
        public List<NavigationListItem> Items { get; set; }
        public bool HasChildren => Items != null && Items.Any() && Items.Count > 0;

        public NavigationListItem()
        { }

        public NavigationListItem(NavigationLink link)
        {
            Link = link;
        }

        public NavigationListItem(string text)
        {
            Text = text;
        }
    }
}