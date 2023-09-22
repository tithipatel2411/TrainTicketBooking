using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecordManagementSystem.Models
{
    public class Student
    {
        public int Id { set; get; }
        [Required]
        public int Product_id { set; get; }
        [Required]
        public string SubcategoryName { set; get; }
        [Required]
        public string CategoryDescription { set; get; }
        [Required]
        public int price { set; get; }
        [Required]
        public string Location { set; get; }
    }
}