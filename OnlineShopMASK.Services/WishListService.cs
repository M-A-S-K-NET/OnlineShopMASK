using OnlineShopMASK.Core.Contracts;
using OnlineShopMASK.Core.Models;
using OnlineShopMASK.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OnlineShopMASK.Services
{
    public class WishListService : IWishListService
    {
        IRepository<Product> productContext;
        IRepository<WishList> WishListContext;

        public const string WishListSessionName = "eCommerceWishList";

        public WishListService(IRepository<Product> ProductContext, IRepository<WishList> WishListContext)
        {
            this.WishListContext = WishListContext;
            this.productContext = ProductContext;
        }
        private WishList GetWishList(HttpContextBase httpContext, bool createIfNull)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(WishListSessionName);

            WishList WishList = new WishList();

            if (cookie != null)
            {
                string WishListId = cookie.Value;
                if (!string.IsNullOrEmpty(WishListId))
                {
                    WishList = WishListContext.Find(WishListId);
                }
                else
                {
                    if (createIfNull)
                    {
                        WishList = CreateNewWishList(httpContext);
                    }
                }

            }
            else
            {
                if (createIfNull)
                {
                    WishList = CreateNewWishList(httpContext);
                }
            }
            return WishList;
        }
        private WishList CreateNewWishList(HttpContextBase httpContext)
        {
            WishList WishList = new WishList();
            WishListContext.Insert(WishList);
            WishListContext.Commit();

            HttpCookie cookie = new HttpCookie(WishListSessionName);
            cookie.Value = WishList.Id;
            cookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(cookie);

            return WishList;
        }
        public void AddToWishList(HttpContextBase httpContext, string productId)
        {
            WishList WishList = GetWishList(httpContext, true);
            WishListItem item = WishList.WishListItem.FirstOrDefault(i => i.ProductId == productId);

            if (item == null)
            {
                item = new WishListItem()
                {
                    WishListId = WishList.Id,
                    ProductId = productId,
                    Quantity = 1
                };
                WishList.WishListItem.Add(item);
            }
            else
            {
                item.Quantity = item.Quantity + 1;
            }
            WishListContext.Commit();
        }
        public void RemoveFromWishList(HttpContextBase httpContext, string itemId)
        {
            WishList WishList = GetWishList(httpContext, true);
            WishListItem item = WishList.WishListItem.FirstOrDefault(i => i.Id == itemId);

            if (item != null)
            {
                WishList.WishListItem.Remove(item);
                WishListContext.Commit();
            }
        }
        public List<WishListItemViewModel> GetWishListItems(HttpContextBase httpContext)
        {
            WishList WishList = GetWishList(httpContext, false);

            if (WishList != null)
            {
                var results = (from b in WishList.WishListItem
                               join p in productContext.Collection() on b.ProductId equals p.Id
                               select new WishListItemViewModel()
                               {
                                   Id = b.Id,
                                   Quantity = b.Quantity,
                                   ProductName = p.Name,
                                   Image = p.Image,
                                   Price = p.Price
                               }
                               ).ToList();
                return results;
            }
            else
            {
                return new List<WishListItemViewModel>();
            }
        }
        public WishListSummaryViewModel GetWishListSummary(HttpContextBase httpContext)
        {
            WishList WishList = GetWishList(httpContext, false);
            WishListSummaryViewModel model = new WishListSummaryViewModel(0, 0);
            if (WishList != null)
            {
                int? WishListCount = (from item in WishList.WishListItem
                                    select item.Quantity).Sum();

                decimal? WishListTotal = (from item in WishList.WishListItem
                                        join p in productContext.Collection() on item.ProductId equals p.Id
                                        select item.Quantity * p.Price).Sum();

                model.WishListCount = WishListCount ?? 0;
                model.WishListTotal = WishListTotal ?? decimal.Zero;
                return model;
            }
            else
            {
                return model;
            }
        }
        public void ClearWishList(HttpContextBase httpContext)
        {
            WishList WishList = GetWishList(httpContext, false);
            WishList.WishListItem.Clear();
            WishListContext.Commit();
        }
    }
}
