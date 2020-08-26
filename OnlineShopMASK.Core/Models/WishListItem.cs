using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopMASK.Core.Models
{
    public class WishListItem : BaseEntity
    {
        public string WishListId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
