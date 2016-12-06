using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITS.Models;

namespace ITS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "About ITS";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact ITS";

            return View();
        }

        public ActionResult Statistics()
        {
            return View(new IssuesViewModel());
        }
    }
}