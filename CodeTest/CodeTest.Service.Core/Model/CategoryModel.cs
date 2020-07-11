using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeTest.Service.Core.Model
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Category Name is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Price Range is required.")]
        public string PriceRange { get; set; }
        [Required(ErrorMessage = "Display Order is required.")]
        public int DisplayOrder { get; set; }
    }
}
