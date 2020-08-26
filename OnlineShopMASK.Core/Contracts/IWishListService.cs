using OnlineShopMASK.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OnlineShopMASK.Core.Contracts
{
    public interface IWishListService
    {
        void AddToWishList(HttpContextBase httpContext, string productId);
        void RemoveFromWishList(HttpContextBase httpContext, string itemId);
        List<WishListItemViewModel> GetWishListItems(HttpContextBase httpContext);
        WishListSummaryViewModel GetWishListSummary(HttpContextBase httpContext);
        void ClearWishList(HttpContextBase httpContext);
    }
}
