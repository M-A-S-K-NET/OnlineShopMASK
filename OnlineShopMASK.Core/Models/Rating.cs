using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopMASK.Core.Models
{
    public class Rating : BaseEntity
    {
        [Range(1,5)]
        public int Stars { get; set; }
    }
}
