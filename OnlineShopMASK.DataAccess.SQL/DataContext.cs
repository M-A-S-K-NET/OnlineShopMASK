using OnlineShopMASK.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopMASK.DataAccess.SQL
{
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
            {

            }

        public DbSet<Product> products { get; set; }
        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<WishListItem> WishListItems { get; set; }
        //Add customers in here and Add-Migration
        public DbSet<Customer> Customers { get; set; }
        //Add those models to Entity Framework... And when you done with that add a new migration...
        public DbSet<Order> Orders { get; set; }
    }
}
