using System;
using System.Web.Mvc;

namespace ProblemShare.Web
{
    /// <summary>
    /// Specifies whether the current action supports returning its view as the result of an asyncronous javascript request (AJAX)
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class AsyncAttribute : ActionFilterAttribute
    {
        private readonly bool allowAsync;

        public AsyncAttribute(bool allowAsyncRequests = true) : base()
        {
            allowAsync = allowAsyncRequests;
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var requestParams = filterContext.RequestContext.HttpContext.Request.Params;
            if (allowAsync && requestParams["partial"] != null)
            {
                if (requestParams["partial"] == "true")
                {
                    filterContext.HttpContext.Items.Add("ContentOnly", true);
                }
            }
            base.OnResultExecuting(filterContext);
        }
    }
}