using System;
using System.Web.Mvc;

namespace ProblemShare.Web
{
    public static class HtmlHelpers
    {
        public static MaterialDesignCard Card<T>(this HtmlHelper<T> htmlHelper)
        {
            htmlHelper.ViewContext.Writer.Write("<div class=\"card\"><div class=\"card-body card-padding\">");
            return new MaterialDesignCard(htmlHelper.ViewContext);
        }
    }

    public class MaterialDesignCard : IDisposable
    {
        private ViewContext _viewContext;
        public MaterialDesignCard(ViewContext viewContext)
        {
            _viewContext = viewContext;
        }
        public void Dispose()
        {
            _viewContext.Writer.Write("</div></div>");
            _viewContext = null;
        }
    }
}