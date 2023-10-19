using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLX.Models.Admin
{
    //public class ProductSubCategoryModeljoin
    //{
    //    [Required]
    //    public int productSubCategoryId { get; set; }
    //    [Required]
    //    public string productCategoryName { get; set; }
    //    [Required]
    //    public int productCategoryId { get; set; }
    //    [Required]
    //    public string productSubCategoryName { get; set; }
    //    //[Required]
    //    public DateTime createdOn { get; set; }
    //    // [Required]
    //    public DateTime updatedOn { get; set; }
    //}

    public class ProductSubCategoryModeljoin
    {
        [Required]
        public int productSubCategoryId { get; set; }

        [Required]
        [Display(Name = "Product Category ID")]
        public int productCategoryId { get; set; }

        [Required]
        [Display(Name = "Product Subcategory Name")]
        public string productSubCategoryName { get; set; }

        // Additional properties for display purposes
        public string productCategoryName { get; set; } // This property will store the product name fetched from the database

        [Required]
        [Display(Name = "Created On")]
        public DateTime createdOn { get; set; }

        [Required]
        [Display(Name = "Updated On")]
        public DateTime updatedOn { get; set; }


    }
}
