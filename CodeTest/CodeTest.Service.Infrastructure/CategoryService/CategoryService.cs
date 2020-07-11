using CodeTest.Context.Entities;
using CodeTest.Core.Abstraction;
using CodeTest.Service.Core.Abstraction;
using CodeTest.Service.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Service.Infrastructure.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task Add(CategoryModel model)
        {
            Category category = new Category
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                PriceRange = model.PriceRange,
                DisplayOrder = model.DisplayOrder
            };
            await _categoryRepository.Add(category);
        }

        public async Task Delete(int id)
        {
            await _categoryRepository.Delete(id);
        }

        public async Task Edit(CategoryModel model)
        {
            Category category = new Category
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                PriceRange = model.PriceRange,
                DisplayOrder = model.DisplayOrder
            };
            await _categoryRepository.Edit(category);
        }

        public async Task<List<CategoryModel>> GetAll()
        {
            ICollection<Category> categories = await _categoryRepository.GetAll();
            return categories.Select(x => new CategoryModel()
            {
               Id = x.Id,
               Description = x.Description,
               Name = x.Name,
               DisplayOrder = x.DisplayOrder,
               PriceRange = x.PriceRange
            }).OrderBy(x=>x.DisplayOrder).ToList();
        }

        public async Task<CategoryModel> GetById(int id)
        {
            Category category = await _categoryRepository.GetById(id);
            return new CategoryModel()
            {
                Id = category.Id,
                Description = category.Description,
                Name = category.Name,
                DisplayOrder = category.DisplayOrder,
                PriceRange = category.PriceRange
            };
        }
    }
}
