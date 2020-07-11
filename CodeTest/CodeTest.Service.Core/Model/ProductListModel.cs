using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest.Service.Core.Model
{
    public class ProductListModel
    {
        public ProductListModel()
        {
            Products = new List<ProductModel>();
            Categories = new List<CategoryModel>();
        }
        public int CategoryId { get; set; }

        public List<ProductModel> Products { get; set; }
        public List<CategoryModel> Categories { get; set; }
    }
}
