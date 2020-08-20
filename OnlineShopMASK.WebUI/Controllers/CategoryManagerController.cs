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

        public ActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            else
            {
                context.Insert(category);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(String Id)
        {
            Category category = context.Find(Id);
            if (category == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(category);
            }
        }

        [HttpPost]
        public ActionResult Edit(Category category, string Id)
        {
            Category categoryEdit = context.Find(Id);
            if (categoryEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }
                categoryEdit.CategoryName = category.CategoryName;
                categoryEdit.Description = category.Description;
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Category categoryToDelete = context.Find(Id);

            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Category categoryToDelete = context.Find(Id);

            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }



    }
}