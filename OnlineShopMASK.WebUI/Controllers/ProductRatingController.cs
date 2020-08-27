using OnlineShopMASK.Core.Contracts;
using OnlineShopMASK.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopMASK.WebUI.Controllers
{
    public class ProductRatingController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductRating> RatingContext;

        public ProductRatingController(IRepository<Product> productContext, IRepository<ProductRating> ratingContext)
        {
            this.context = productContext;
            this.RatingContext = ratingContext;
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
            
            var Comment = RatingContext.Collection().Where(c => c.Id.Equals(id)).ToList();
            
            ViewBag.Comments = Comment;

            var ratings = RatingContext.Collection().Where(r => r.Id.Equals(id)).ToList();
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
    }
}
