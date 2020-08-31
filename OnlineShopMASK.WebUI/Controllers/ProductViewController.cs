using OnlineShopMASK.Core.Contracts;
using OnlineShopMASK.Core.Models;
using OnlineShopMASK.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Net;

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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = context.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.ProductId = id;

            var comments = productRating.Collection().Where(d => d.Id.Equals(id)).ToList();
            ViewBag.Comments = comments;

            var ratings = productRating.Collection().Where(d => d.Id.Equals(id)).ToList();
            if (ratings.Count() > 0)
            {
                var ratingSum = ratings.Sum(d => d.Rating.Value);
                ViewBag.RatingSum = ratingSum;
                var ratingCount = ratings.Count();
                ViewBag.RatingCount = ratingCount;
            }
            else
            {
                ViewBag.RatingSum = 0;
                ViewBag.RatingCount = 0;
            }

            return View(product);
        }
        public ActionResult Add(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductListViewModel viewModel = new ProductListViewModel();
                viewModel.ProductRating = productRating.Collection();
                return View(viewModel);
            }
        }
        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            var comment = form["Comment"].ToString();
            var productId = form["ProductId"];
            var rating = int.Parse(form["Rating"]);

            ProductRating pr = new ProductRating()
            {
                Id = productId,
                Comments = comment,
                Rating = rating,
                ThisDateTime = DateTime.Now
            };


            productRating.Collection().ToList().Add(pr);

            return RedirectToAction("Details", "Product", new { id = productId });
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