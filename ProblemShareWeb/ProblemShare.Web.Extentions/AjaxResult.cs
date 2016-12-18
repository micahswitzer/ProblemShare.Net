using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProblemShare.Web.Extentions
{
    public class AjaxResult : JsonResult
    {
        public AjaxResult(object data) : base()
        {
            this.Data = data;
        }
        public AjaxResult(string result) : base()
        {
            this.Data = new { result = result };
        }
        public AjaxResult(AjaxResultType resultType) : base()
        {
            this.Data = new { result = resultType.ToString().ToLower() };
        }
    }

    public enum AjaxResultType
    {
        Success,
        Failure,
        Error
    }
}
