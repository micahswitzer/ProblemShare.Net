using ProblemShare.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProblemShare.Web.Controllers
{
    public class HomeController : Controller
    {
        private IDocumentBO _documentBO;

        public HomeController(IDocumentBO documentBO)
        {
            _documentBO = documentBO;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}