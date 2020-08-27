namespace OnlineShopMASK.DataAccess.SQL.Migrations
{
    using OnlineShopMASK.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineShopMASK.DataAccess.SQL.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OnlineShopMASK.DataAccess.SQL.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (!context.products.Any(p => p.Id.Equals(string.Empty)))
            {
                if (!context.productCategories.Any())
                {
                    var categories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Category= "Laptop",
                            Id= Guid.NewGuid().ToString(),
                            CreatedAt= DateTime.Now
                        },
                         new ProductCategory
                        {
                            Category= "Tablets",
                            Id= Guid.NewGuid().ToString(),
                            CreatedAt= DateTime.Now
                        },
                          new ProductCategory
                        {
                            Category= "Mobiles",
                            Id= Guid.NewGuid().ToString(),
                            CreatedAt= DateTime.Now
                        },
                    };
                    context.productCategories.AddRange(categories);
                    context.SaveChanges();
                }

                if (!context.products.Any())
                {
                    var cat_Laptop = context.productCategories.FirstOrDefault(x => x.Category.Equals("Laptop")).Category;
                    var cat_tablet = context.productCategories.FirstOrDefault(x=>x.Category.Equals("Tablets")).Category;
                    var cat_Mobile = context.productCategories.FirstOrDefault(x => x.Category.Equals("Mobiles")).Category;
                    var pro = new List<Product>
                    {
                        // LAPTOPS
                        new Product
                        {
                            Name="Samsung Galaxy Book Flex 13.3 2-in-1 (royal blue)",
                            Description=" The Samsung Galaxy Book Flex 2-in-1 combines extremely light weight, high performance and the functionality of a laptop and a 13 inch tablet. Along with its QLED display, you can take on tasks that require high color accuracy.",
                            Price=23,
                            Category=cat_Laptop,
                            Image="28ede8f9-569d-4486-915c-cfe64a579042.jpg",
                            Id="28ede8f9-569d-4486-915c-cfe64a579042",
                            CreatedAt= DateTime.Now
                        },
                         new Product
                        {
                            Name="Asus VivoBook 14 laptop",
                            Description="Its thin profile and light weight make the Asus VivoBook 14 laptop a perfect helper in everyday life and is great when you want to write, surf or perform easier editing. The sleek format allows you to easily take it anywhere",
                            Price =43,
                            Category=cat_Laptop,
                            Image="11cbf337-e361-4ec9-a58d-3b336c442a30.jpg",
                            Id="11cbf337-e361-4ec9-a58d-3b336c442a30",
                            CreatedAt= DateTime.Now
                        },
                          new Product
                        {
                            Name="Lenovo Ideapad 3 14 laptop (platinum gray)",
                            Description="Lenovo Ideapad 3 14-inch laptop is a great choice for those on the go. The computer has a weight of only 1.2 kg and a super thin profile of 1.79 cm, making it easy to take anywhere.Intel® Core® i5-1035G1 processor8GB DDR4 RAM256GB NVMe SSD",
                            Price =43,
                            Category=cat_Laptop,
                            Image = "89e65120-7d47-4377-8d7f-28d4677e8fcd.jfif",
                            Id= "89e65120-7d47-4377-8d7f-28d4677e8fcd",
                            CreatedAt= DateTime.Now
                        },
                          //TABLETS
                        new Product
                        {
                            Name="Lenovo Tab M10 HD 32GB WiFi 10.1 tablet",
                            Description="With the Lenovo Tab M10 HD tablet, you can enjoy all your favorite media in crisp Full HD quality with captivating sound from two front-facing speakers. The lightweight, compact design makes it easy to take anywhere.10.1 HD IPS DisplayAndroid 9.0 Pie, WiFi-ac Dual front-facing speakers",
                            Price = 13,
                            Category=cat_tablet,
                            Image = "bc0104cd-2bd9-4980-bf9a-1a44a01538d4.jfif",
                            Id= "bc0104cd-2bd9-4980-bf9a-1a44a01538d4",
                            CreatedAt= DateTime.Now
                        },
                           new Product
                        {
                            Name="Samsung Galaxy Tab A 10.1 WiFi 2019 32 GB (black)",
                            Description="With the Samsung Galaxy Tab A 10.1 2019 WiFi tablet, the whole family can have fun and browse the digital world with personalized access to all content. The 10.1-inch 1200p IPS LCD touchscreen is a joy to look at with its wide viewing angles.10.1 1200p IPS LCD Monitor Samsung One UI with Android 9 Pie 2GB RAM, 32GB internal memory",
                            Price = 23,
                            Category=cat_tablet,
                            Image = "603f9174-1697-454a-b39d-ebe1d6829c28.jpg",
                            Id= "603f9174-1697-454a-b39d-ebe1d6829c28",
                            CreatedAt= DateTime.Now
                        },
                           new Product
                        {
                            Name="iPad Pro 12.9 2020 128GB WiFi (space grey)",
                            Description = "With the new iPad Pro 12.9 inch, you can realize all your ideas. Whether you're an aspiring interior designer, app developer, innovative architect or just a dreamer with a vivid imagination, iPadPro offers everything you need Edge-to-edge Liquid Retina Display 8-core A12Z Bionic processor Face ID, LiDAR Scanner",
                            Price = 33,
                            Category=cat_tablet,
                            Image = "a20e5ba5-a979-4e2e-9825-246f19711686.jfif",
                            Id= "a20e5ba5-a979-4e2e-9825-246f19711686",
                            CreatedAt= DateTime.Now
                        },
                           //MOBILES
                           new Product
                        {
                            Name="iPhone 7 32 GB (matte black)",
                            Description = "With the new iPad Pro 12.9 inch, you can realize all your ideas. Whether you're an aspiring interior designer, app developer, innovative architect or just a dreamer with a vivid imagination, iPadPro offers everything you need Edge-to-edge Liquid Retina Display 8-core A12Z Bionic processor Face ID, LiDAR Scanner",
                            Price = 33,
                            Category=cat_Mobile,
                            Image = "c9e75c57-9779-4e81-acef-be8cfe38d5be.jpg",
                            Id= "c9e75c57-9779-4e81-acef-be8cfe38d5be",
                            CreatedAt= DateTime.Now
                        },
                            new Product
                        {
                            Name="Samsung Galaxy Note 10 Lite smartphone (aura glow)",
                            Description="Samsung Galaxy Note10 Lite smartphone har en ikonisk S Pen och vacker modern design med Infinity-O pekskärm och hållbar 3D Glasstic-baksida i kombinerad glas och plast.6.7 FHD+ Super AMOLED pekskärm 12+12+12Mpx bakre trippelkamera S Pen",
                            Price = 549,
                            Category=cat_Mobile,
                            Image = "f2f3ed2d-e647-4bc8-ab1c-f825f3230f6a.jpg",
                            Id= "f2f3ed2d-e647-4bc8-ab1c-f825f3230f6a",
                            CreatedAt= DateTime.Now
                        },
                             new Product
                        {
                            Name="Huawei P30 Pro smartphone 128 GB (breathing crystal)",
                            Description="Huawei P30 Pro smartphone is with its Leica quad camera designed to help you capture all the small details. 8-core Kirin 980 processor and 6GB of RAM provide powerful performance and on-screen fingerprint readers provide fast and secure access.6.47 FHD+ OLED Touch Screen Android 9.0 Pie + EMUI 9.1 40/20/8 Mpx + TOF Leica quad camera",
                            Price = 293,
                            Category=cat_Mobile,
                            Image = "739bbafd-487a-484b-93fd-6d567c8358a6.jpg",
                            Id= "739bbafd-487a-484b-93fd-6d567c8358a6",
                            CreatedAt= DateTime.Now
                        },


                    };
                    context.products.AddRange(pro);
                    context.SaveChanges();
                }

            }
        }
    }
}
