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