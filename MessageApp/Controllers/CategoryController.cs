using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            return await _categoryService.GetCategory(id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCatergories()
        {
            return await _categoryService.GetCategories();
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostCategory(Category category) 
        { 
            return await _categoryService.PostCategory(category);
        }

    }
}
