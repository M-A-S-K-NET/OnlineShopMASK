using OnlineShopMASK.Core.Contracts;
using OnlineShopMASK.Core.Models;
using OnlineShopMASK.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopMASK.WebUI.Controllers
{
    [AllowAnonymous]
    public class ProductViewController : Controller
    {
        // GET: ProductView
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;

        public ProductViewController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
        {
            context = productContext;
            productCategories = productCategoryContext;
        }
        public ActionResult Index(string SearchString, string Category = null)
        {
            List<Product> products;
            List<ProductCategory> categories = productCategories.Collection().ToList();
           
            if (Category == null)
            {
                products = context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(p => p.Category == Category).ToList();

            }

            if (!String.IsNullOrEmpty(SearchString))
            {
                products = context.Collection().Where(s => s.Name.Contains(SearchString)).ToList();

            }
            ProductListViewModel model = new ProductListViewModel();
            model.Products = products;
            model.ProductCategory = categories;
            return View(model);

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

        public ActionResult Search(string SearchString)
        {
            var products = from p in context.Collection()
                           select p;

            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.Name.Contains(SearchString));
               
            }

            return View(products.ToList());
        }
    }
}