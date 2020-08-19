﻿using OnlineShopMASK.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopMASK.Core.ViewModels
{
    public class ProductViewModel
    {
      public IEnumerable<Product> Products { get; set; }
      public IEnumerable<Category> Categories { get; set; }
    }
}