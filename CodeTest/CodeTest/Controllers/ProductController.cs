using CodeTest.Service.Core.Abstraction;
using CodeTest.Service.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeTest.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index(int categoryId)
        {
            ProductListModel model = new ProductListModel
            {
                Categories = await _categoryService.GetAll(),
                CategoryId = categoryId
            };
           // if category is not selected from dropdown.
            if (categoryId == 0)
            {
                model.Products = await _productService.GetAll();
            }
            else
            {
                model.Products = await _productService.GetAllByCategory(categoryId);
            }

            return View(model);
        }

        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            ProductListModel model = new ProductListModel
            {
                Categories = await _categoryService.GetAll(),
                CategoryId = categoryId,
                Products = await _productService.GetAllByCategory(categoryId)
            };
            return RedirectToAction("index", model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ProductModel model = new ProductModel
            {
                CategoryItems = await _categoryService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _productService.Add(model);
                    return RedirectToAction("Index", "Product");
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            product.CategoryItems = await _categoryService.GetAll();
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _productService.Edit(model);
                    return RedirectToAction("Index", "Product");
                }
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.Delete(id);
                return RedirectToAction("Index", "Product");
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}