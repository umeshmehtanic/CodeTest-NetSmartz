using CodeTest.Context.Entities;
using CodeTest.Core.Abstraction;
using CodeTest.Service.Core.Abstraction;
using CodeTest.Service.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Service.Infrastructure.ProductService
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task Add(ProductModel model)
        {
            Product product = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Discount = model.Discount,
                ExpirationDate = model.ExpirationDate,
                Price = model.Price,
                Quantity = model.Quantity
            };
            await _productRepository.Add(product);
        }

        public async Task Delete(int id)
        {
            await _productRepository.Delete(id);
        }

        public async Task Edit(ProductModel model)
        {
            Product product = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Discount = model.Discount,
                ExpirationDate = model.ExpirationDate,
                Price = model.Price,
                Quantity = model.Quantity
            };
            await _productRepository.Edit(product);
        }

        public async Task<List<ProductModel>> GetAll()
        {
            ICollection<Product> products = await _productRepository.GetAll();
            return products.Select(x => new ProductModel()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                CategoryId = x.CategoryId,
                Discount = x.Discount,
                ExpirationDate = x.ExpirationDate,
                Price = x.Price,
                Quantity = x.Quantity
            }).ToList();
        }

        public async Task<List<ProductModel>> GetAllByCategory(int categoryId)
        {
            ICollection<Product> products = await _productRepository.GetAllByCategory(categoryId);
            return products.Select(x => new ProductModel()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                CategoryId = x.CategoryId,
                Discount = x.Discount,
                ExpirationDate = x.ExpirationDate,
                Price = x.Price,
                Quantity = x.Quantity
            }).ToList();
        }

        public async Task<ProductModel> GetById(int id)
        {
            Product product = await _productRepository.GetById(id);
            return new ProductModel
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Discount = product.Discount,
                ExpirationDate = product.ExpirationDate,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }
    }
}
