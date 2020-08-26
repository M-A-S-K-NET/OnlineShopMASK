using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopMASK.Core.ViewModels
{
    public class WishListSummaryViewModel
    {
        public int WishListCount { get; set; }
        public decimal WishListTotal { get; set; }

        public WishListSummaryViewModel()
        {

        }
        public WishListSummaryViewModel(int wishListCount, decimal wishListTotal)
        {
            this.WishListCount = wishListCount;
            this.WishListTotal = wishListTotal;
        }

    }
}
