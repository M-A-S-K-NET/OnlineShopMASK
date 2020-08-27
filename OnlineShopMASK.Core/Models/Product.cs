using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopMASK.Core.Models
{
    public class Product:BaseEntity
    {
        [Display(Name = "Product Name")]
        
        public string Name { get; set; }
        
        
        public string Description { get; set; }

        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string Category { get; set; }
        public string Image { get; set; }

        public int? Rating { get; set; }
        public string Comment { get; set; }
    }
}
