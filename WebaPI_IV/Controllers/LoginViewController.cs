using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebaPI_IV.Controllers
{
    public class LoginViewController : Controller
    {
        // GET: LoginView
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
    }
}