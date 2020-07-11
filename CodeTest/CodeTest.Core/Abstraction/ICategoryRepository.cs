using CodeTest.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Core.Abstraction
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        Task<ICollection<Category>> GetAll();
        /// <summary>
        /// Get category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Category> GetById(int id);
        /// <summary>
        /// Add Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task Add(Category category);
        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task Edit(Category category);
        /// <summary>
        /// Delete Category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);
    }
}
