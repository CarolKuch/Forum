using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            return await _categoryRepository.GetCategory(id);
        }

        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            return categories;
        }

        public async Task<ActionResult<string>> PostCategory(Category category)
        {

            if (category.Title?.Length > 0)
            {
                return await _categoryRepository.PostCategory(category);
            }
            else
            {
                return "Category invalid";
            }
        }
    }
}
