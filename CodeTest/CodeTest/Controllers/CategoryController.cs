using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTest.Context.Entities;
using CodeTest.Service.Core.Abstraction;
using CodeTest.Service.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<CategoryModel> categories = await _categoryService.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _categoryService.Add(model);
                    return RedirectToAction("Index", "Category" );
                }
            }
            catch (Exception)
            {
                throw;
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _categoryService.Edit(model);
                    return RedirectToAction("Index", "Category");
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
                await _categoryService.Delete(id);
                return RedirectToAction("Index", "Category");
            }
            catch(Exception exp)
            {
                throw exp;
            }
        }
    }
}