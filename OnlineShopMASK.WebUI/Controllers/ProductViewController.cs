using OnlineShopMASK.Core.Contracts;
using OnlineShopMASK.Core.Models;
using OnlineShopMASK.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace OnlineShopMASK.WebUI.Controllers
{
    [AllowAnonymous]
    public class ProductViewController : Controller
    {
        // GET: ProductView
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;
        IRepository<ProductRating> productRating;

        public ProductViewController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext, IRepository<ProductRating> productRatingContext)
        {
            context = productContext;
            productCategories = productCategoryContext;
            productRating = productRatingContext;
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
            Debug.WriteLine("HHHHHHHHHHHHHHHH");
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {

                return View(product);
            }

        }
        public ActionResult AddRating(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.Product = product;
                viewModel.ProductCategories = productCategories.Collection();
                return View(viewModel);
            }
        }
        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            var comment = form["Comment"].ToString();
            var productId = form["ProductId"];
            var rating = int.Parse(form["Rating"]);

            ProductRating productRating = new ProductRating()
            {
                Id = productId,
                Comments = comment,
                Rating = rating,
                ThisDateTime = DateTime.Now
            };

            //productRating.Comments.Add(comment);
            

            return RedirectToAction("Details", "Articles", new { id = productId });
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