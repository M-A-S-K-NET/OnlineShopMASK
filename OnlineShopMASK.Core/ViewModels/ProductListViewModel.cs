using OnlineShopMASK.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopMASK.Core.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductCategory> ProductCategory { get; set; }
        public IEnumerable<Rating> ProductRating { get; set; }
        public IEnumerable<Review> ProductReview { get; set; }
    }
}
