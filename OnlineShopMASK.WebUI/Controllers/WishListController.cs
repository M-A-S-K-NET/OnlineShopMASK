using OnlineShopMASK.Core.Contracts;
using OnlineShopMASK.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopMASK.WebUI.Controllers
{
    public class WishListController : Controller
    {
        IRepository<Customer> customers;
        IWishListService WishListService;
        public WishListController(IWishListService WishListService, IRepository<Customer> Customers)
        {
            this.WishListService = WishListService;
            this.customers = Customers;
        }
        // GET: WishList
        public ActionResult Index()
        {
            var model = WishListService.GetWishListItems(this.HttpContext);
            return View(model);
        }
        public ActionResult AddToWishList(string Id)
        {
            WishListService.AddToWishList(this.HttpContext, Id);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromWishList(string Id)
        {
            WishListService.RemoveFromWishList(this.HttpContext, Id);
            return RedirectToAction("Index");
        }
        public PartialViewResult WishListSummary()
        {
            var WishListSummary = WishListService.GetWishListSummary(this.HttpContext);

            return PartialView(WishListSummary);
        }
    }

}