using ProblemShare.Web.Extentions;
using ProblemShare.Web.Interface;
using ProblemShare.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProblemShare.Web.Controllers
{
    [Async]
    [Authorize]
    public class DocumentsController : Controller
    {
        // Everything is GET because all saving is done on the fly with AJAX (no annoying issues trying to get data back into a useable format!)

        public DocumentsController(IDocumentBO docBO, IFileManagerBO fileBO)
        {
            _docBO = docBO;
            _fileBO = fileBO;
        }

        private readonly IDocumentBO _docBO;
        private readonly IFileManagerBO _fileBO;

        // GET: Documents
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Save(Guid id, DocumentViewModel document)
        {
            var result = AjaxResultType.Success;
            var message = string.Empty;
            if (!_docBO.Save(document, id)) {
                result = AjaxResultType.Failure;
                message = "Unable to save document! Please try again.";
            }
            return new AjaxResult(result, message);
        }

        [HttpPost]
        public JsonResult Upload(Guid? id)
        {
            if (Request.Files.Count == 0) return new AjaxResult(AjaxResultType.Error, "No files in the request!");

            var file = Request.Files[0];
            using (var fStream = _fileBO.GetWriteStream(file.FileName))
            {
                file.InputStream.CopyTo(fStream);
            }

            return new AjaxResult(message: "Success!");
        }
    }
}