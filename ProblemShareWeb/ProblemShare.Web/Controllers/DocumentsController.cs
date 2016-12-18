using ProblemShare.Web.Extentions;
using ProblemShare.Web.Interface;
using ProblemShare.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProblemShare.Web.Controllers
{
    [Authorize]
    public class DocumentsController : Controller
    {
        // Everything is GET because all saving is done on the fly with AJAX (no annoying issues trying to get data back into a useable format!)

        public DocumentsController(IDocumentBO docBO)
        {
            _docBO = docBO;
        }

        IDocumentBO _docBO;

        // GET: Documents
        public ActionResult Index()
        {
            return base.View();
        }

        public ActionResult Edit()
        {
            return base.View();
        }

        [HttpPost]
        public JsonResult Save(Guid id, DocumentViewModel document)
        {
            _docBO.Save(document, new Guid(""));
            return new AjaxResult(AjaxResultType.Success);
        }
    }
}