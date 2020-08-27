using OnlineShopMASK.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopMASK.Core.ViewModels
{
    public class ProductManagerViewModel
    {
      public Product Product { get; set; }
      public IEnumerable<ProductCategory> ProductCategories { get; set; }
      public IEnumerable<ProductRating> ProductRating { get; set; }

    }
}
