using CodeTest.Context;
using CodeTest.Context.Entities;
using CodeTest.Core.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private CodeTestContext _codeTestContext;
        public CategoryRepository(CodeTestContext codeTestContext)
        {
            _codeTestContext = codeTestContext;
        }
        public async Task Add(Category category)
        {
            _codeTestContext.Categories.Add(category);
            _codeTestContext.Entry(category).State = EntityState.Added;
            await _codeTestContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Category category = new Category { Id = id };
            _codeTestContext.Entry(category).State = EntityState.Deleted;
            await _codeTestContext.SaveChangesAsync();
        }

        public async Task Edit(Category category)
        {
            _codeTestContext.Categories.Update(category);
            _codeTestContext.Entry(category).State = EntityState.Modified;
            await _codeTestContext.SaveChangesAsync();
        }

        public async Task<ICollection<Category>> GetAll()
        {
            return await _codeTestContext.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _codeTestContext.Categories.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
        }
    }
}
