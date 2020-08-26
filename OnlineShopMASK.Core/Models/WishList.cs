using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopMASK.Core.Models
{
    public class WishList : BaseEntity
    {
        public virtual ICollection<WishListItem> WishListItem { get; set; }

        public WishList()
        {
            this.WishListItem = new List<WishListItem>();
        }
    }
}
