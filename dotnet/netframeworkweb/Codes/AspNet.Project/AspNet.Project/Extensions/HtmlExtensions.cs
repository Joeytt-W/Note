using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNet.Project.Extensions
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString Br(this HtmlHelper helper)
        {
            var builder = new TagBuilder("br");

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }


        public static MvcHtmlString Image(this HtmlHelper helper, string src, string alt, string title,
            object htmlAttribute, string defaultClass = "btn btn-default")
        {
            var builder = new TagBuilder("Img");
            builder.MergeAttribute("src",src);
            builder.MergeAttribute("alt", alt);
            builder.MergeAttribute("title", title);
            builder.MergeAttribute("class", defaultClass);
            builder.MergeAttributes<string,object>(new RouteValueDictionary(htmlAttribute));

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}