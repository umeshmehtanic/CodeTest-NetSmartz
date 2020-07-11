using CodeTest.Service.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Service.Core.Abstraction
{
    public interface ICategoryService
    {
        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        Task<List<CategoryModel>> GetAll();
        /// <summary>
        /// Get Category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CategoryModel> GetById(int id);
        /// <summary>
        /// add new category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task Add(CategoryModel model);
        /// <summary>
        /// update category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task Edit(CategoryModel model);
        /// <summary>
        /// Delete category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);
    }
}
