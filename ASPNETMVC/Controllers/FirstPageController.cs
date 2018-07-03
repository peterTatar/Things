using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETMVC.Controllers
{
    public class FirstPageController : Controller
    {
        // GET: FirstPage
        public ActionResult Index() {
          ViewBag.ThisCanBeEverything = "Hello Peti " + DateTime.Now.ToString();
          ViewBag.ThisCanBeEverything1 = "Hello Peti1 " + DateTime.Now.ToString();
          ViewBag.ThisCanBeEverything2 = "Hello Peti2 " + DateTime.Now.ToString();
            return View();
        }
    }
}