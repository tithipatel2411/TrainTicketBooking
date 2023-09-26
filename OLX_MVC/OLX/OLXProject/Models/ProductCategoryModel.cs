using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLXProject.Models
{


    public class ProductCategoryModel
    {
        public int productCategoryId { get; set; }
        public string productCategoryName { get; set; }

        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }
    }

    public class ProductSubCategoryModel
    {
        public int productSubCategoryId { get; set; }
        public int productCategoryId { get; set; }
        public string productSubCategoryName { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }
    }

    public class ProductDetailsModel
    {
        public int productDetailsId { get; set; }
        //public string productSubCategoryName { get; set; }
        [Required]
        public int productSubCategoryId { get; set; }
        [Required]
        public string productTitle { get; set; }
        [Required]
        public string productDescription { get; set; }
        [Required]
        public float productPrice { get; set; }
        [Required]
        public int productImageId { get; set; }
        [Required]
        public int cityId { get; set; }

        //public bool productStatus { get; set; }
        [Required]
        public int userId { get; set; }
        public DateTime createdOn { get; set; }

        public DateTime updatedOn { get; set; }

    }


    // join two table 
    public class ProductDetailsModel1
    {
        public int productDetailsId { get; set; }
        //public string productSubCategoryName { get; set; }
        [Required]
        public string productSubCategoryName { get; set; }
        [Required]
        public string productTitle { get; set; }
        [Required]
        public string productDescription { get; set; }
        [Required]
        public float productPrice { get; set; }
        [Required]
        public int productImageId { get; set; }
        [Required]
        public int cityId { get; set; }

        //public bool productStatus { get; set; }
        [Required]
        public int userId { get; set; }
        public DateTime createdOn { get; set; }

        public DateTime updatedOn { get; set; }

    }

    public class ProductImagesModel
    {
        public int productImageId { get; set; }
        public int productDetailsId { get; set; }
        public byte[] imageData { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }

    }

}