using Mster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mster.Controllers
{
    public class HomeController : Controller
    {
        private BuytnaEntities db = new BuytnaEntities();
        public ActionResult Index()
        {
            var c=db.Estates.ToList();


            return View(c);
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

        public ActionResult Dashboard()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


       

    }
}