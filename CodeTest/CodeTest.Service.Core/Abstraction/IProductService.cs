using CodeTest.Service.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Service.Core.Abstraction
{
    public interface IProductService
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        Task<List<ProductModel>> GetAll();
        /// <summary>
        /// Get all products by category id
        /// </summary>
        /// <returns></returns>
        Task<List<ProductModel>> GetAllByCategory(int categoryId);
        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductModel> GetById(int id);
        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task Add(ProductModel model);
        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task Edit(ProductModel model);
        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);
    }
}
