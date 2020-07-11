using CodeTest.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Core.Abstraction
{
    public interface IProductRepository
    {
        /// <summary>
        /// Get all products 
        /// </summary>
        /// <returns></returns>
        Task<ICollection<Product>> GetAll();
        /// <summary>
        /// Get all products by category id
        /// </summary>
        /// <returns></returns>
        Task<ICollection<Product>> GetAllByCategory(int categoryId);
        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetById(int id);
        /// <summary>
        /// Add product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task Add(Product product);
        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task Edit(Product product);
        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);
    }
}
