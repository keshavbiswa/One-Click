using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OneClick.WebUI.HtmlHelpers
{
    public static class ButtonHelper
    {
        public static MvcHtmlString ButtonLinks(this HtmlHelper html,
                                               string link, string text)
        {
            StringBuilder result = new StringBuilder();
            TagBuilder tag = new TagBuilder("a");

            tag.MergeAttribute("href", link);
            tag.MergeAttribute("alt", text);
            tag.AddCssClass("btn btn-default");
            return MvcHtmlString.Create(result.ToString());
        }
    }
}