using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopMASK.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Mask Online Shop";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Information";
            return View();
        }

        public ActionResult Conditions()
        {
            ViewBag.Message = "Terms & Conditions ";
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            ViewBag.Message = "Privacy Policy ";
            return View();
        }

        public ActionResult OurServices()
        {
            ViewBag.Message = "Our Services ";
            return View();
        }

        public ActionResult Warranty()
        {
            ViewBag.Message = "Warranty & Repair ";
            return View();
        }

        public ActionResult FAQ()
        {
            ViewBag.Message = "Frequently Asked Questions ";
            return View();
        }
    }
}