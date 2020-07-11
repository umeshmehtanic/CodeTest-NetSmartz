using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeTest.Service.Core.Model
{
    public class ProductModel
    {
        public ProductModel()
        {
            CategoryItems = new List<CategoryModel>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Category Name is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Discount is required.")]
        public decimal Discount { get; set; }
        [Required(ErrorMessage = "Expiration Date is required.")]
        public DateTime ExpirationDate { get; set; }
        [Required(ErrorMessage = "Select Category")]
        public int CategoryId { get; set; }
        public List<CategoryModel> CategoryItems { get; set; }
    }
}
