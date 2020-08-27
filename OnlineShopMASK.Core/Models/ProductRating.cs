using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopMASK.Core.Models
{
    public class ProductRating : BaseEntity
    {
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        public DateTime? ThisDateTime { get; set; }
        public int? Rating { get; set; }
    }
}