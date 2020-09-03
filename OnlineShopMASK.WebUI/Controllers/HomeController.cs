using OnlineShopMASK.Core.Contracts;
using OnlineShopMASK.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopMASK.WebUI.Controllers
{
    
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;

        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
        {
            context = productContext;
            productCategories = productCategoryContext;
        }
        [AllowAnonymous]
        public ActionResult Index(string SearchString)
        {
            var products = from p in context.Collection()
                           select p;

            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.Name.Contains(SearchString));

            }

            return View(products.ToList());
        }

        [AllowAnonymous]
        public ActionResult Details(string id)
        {
            Product product = context.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {

                return View(product);
            }

        }
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Welcome to MaskShopping.se";
            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Information";
            return View();
        }

        [AllowAnonymous]
        public ActionResult Conditions()
        {
            ViewBag.Message = "Terms & Conditions ";
            return View();
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
        public ActionResult Warranty()
        {
            ViewBag.Message = "Return & Repair ";
            return View();
        }

        [AllowAnonymous]

        public ActionResult FAQ()
        {
            ViewBag.Message = "Frequently Asked Questions ";
            return View();
        }

        public ActionResult AdminPage()
        {
            ViewBag.Message = "Admin";
            return View();
        }
    }
}