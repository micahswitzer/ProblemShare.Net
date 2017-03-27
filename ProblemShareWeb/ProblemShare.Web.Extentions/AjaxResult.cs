using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProblemShare.Web.Extentions
{
    public class AjaxResult : JsonResult
    {
        public AjaxResult(object data) : base()
        {
            this.Data = data;
        }
        public AjaxResult(string redirectUrl) : base()
        {
            this.Data = new AjaxResultData() { result = AjaxResultType.Success, redirectUrl = redirectUrl };
        }
        public AjaxResult(AjaxResultType resultType = AjaxResultType.Success, string message = "", string redirectUrl = @"/", object paramData = null) : base()
        {
            this.Data = new AjaxResultData() { result = resultType, message = message, redirectUrl = string.Concat(redirectUrl, convertParamsToString(paramData)) };
        }

        private string convertParamsToString(object data)
        {
            if (data == null) return "";

            var sb = new StringBuilder("?");
            var count = 0;
            foreach (var prop in data.GetType().GetProperties())
            {
                if (count > 0) sb.Append("&");
                sb.AppendFormat("{0}={1}", prop.Name, HttpContext.Current.Server.UrlEncode(prop.GetValue(data, null) as string));
                count++;
            }
            return sb.ToString();
        }
    }

    public enum AjaxResultType
    {
        Success,
        Failure,
        Error
    }

    public class AjaxResultData
    {
        public AjaxResultType result { get; set; }
        public string message { get; set; }
        public string redirectUrl { get; set; }    
    }
}
