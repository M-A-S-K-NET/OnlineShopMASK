using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopMASK.Core.Models
{
    public class Category : BaseEntity
    {
        [Display(Name = "Category Name")]
        [Required]
        [StringLength(100)]
        public string  CategoryName { get; set; }
        [Display(Name = "Description")]
        [StringLength(600)]
        public string Description { get; set; }
       
    }
}
