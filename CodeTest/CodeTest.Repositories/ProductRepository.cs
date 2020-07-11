using CodeTest.Context;
using CodeTest.Context.Entities;
using CodeTest.Core.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private CodeTestContext _codeTestContext;

        public ProductRepository(CodeTestContext codeTestContext)
        {
            this._codeTestContext = codeTestContext;
        }
        public async Task Add(Product product)
        {
            _codeTestContext.Products.Add(product);
            _codeTestContext.Entry(product).State = EntityState.Added;
            await _codeTestContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Product product = new Product { Id = id };
            _codeTestContext.Entry(product).State = EntityState.Deleted;
            await _codeTestContext.SaveChangesAsync();
        }

        public async Task Edit(Product product)
        {
            _codeTestContext.Products.Update(product);
            _codeTestContext.Entry(product).State = EntityState.Modified;
            await _codeTestContext.SaveChangesAsync();
        }

        public async Task<ICollection<Product>> GetAll()
        {
            return await _codeTestContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Product>> GetAllByCategory(int categoryId)
        {
            return await _codeTestContext.Products.Where(x=>x.CategoryId==categoryId).AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _codeTestContext.Products.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
        }
    }
}
