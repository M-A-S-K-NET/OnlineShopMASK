using OnlineShopMASK.Core.Interface;
using OnlineShopMASK.Core.Models;
using OnlineShopMASK.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopMASK.WebUI.Controllers
{
    public class CategoryManagerController : Controller
    {
        IRepository<Category> context;

        public CategoryManagerController(IRepository<Category> _context)
        {
            this.context = _context;
        }

        // GET: CategoryManager
        public ActionResult Index()
        {
            List<Category> Categories = context.Collection().ToList();
            return View(Categories);
        }
        //public ActionResult Create()
        //{
        //    Category category = new Category();
        //    return View(category);
        //}

        //[HttpPost]
        //public ActionResult Create(Category category)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(category);
        //    }
        //    else
        //    {
        //        context.Insert(category);
        //        context.Commit();
        //        return RedirectToAction("Index");
        //    }
        //}



    }
}