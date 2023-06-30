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
        public Task<ActionResult<Category>> GetCategory(int id)
        {
            return _categoryService.GetCategory(id);
        }

        [HttpGet]
        public Task<ActionResult<IEnumerable<Category>>> GetCatergories()
        {
            return _categoryService.GetCategories();
        }

        [HttpPost]
        public Task<ActionResult<string>> PostCategory(Category category) 
        { 
            return _categoryService.PostCategory(category);
        }
    }
}
