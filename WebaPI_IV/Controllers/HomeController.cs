using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebaPI_IV.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult API()
        {
            ViewBag.Title = "API Page";
            return View("API");
        }

        public ActionResult test()
        {
            ViewBag.Title = "Teste";
            return View("test");
        }
    }
}
