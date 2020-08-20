using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopMASK.Core.Interface;
using OnlineShopMASK.Core.Models;
using OnlineShopMASK.Core.ViewModels;

namespace OnlineShopMASK.WebUI.Controllers
{
    
    public class ProductViewController : Controller
    {
        IRepository<Product> context;
        IRepository<Category> ProductCategories;

        public ProductViewController(IRepository<Product> productcontext,IRepository<Category> productCategoriesContext)
        {
            context = productcontext;
            ProductCategories = productCategoriesContext;
        }
        
        // GET: ProductView
        public ActionResult Index(string Category = null)
        {
            List<Product> products;
            List<Category> categories = ProductCategories.Collection().ToList();
            if(Category==null)
            {
                products = context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(p => p.Category == Category).ToList();
            }
            ProductListViewModel model = new ProductListViewModel();
            model.Product = products;
            model.Categories = categories;
            return View(model);
        }

        public ActionResult Details(string id)
        {
            Product product = context.Find(id);
            if(product==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }
    }
}