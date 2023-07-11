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

        public Task<ActionResult<Category>> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return _categoryRepository.GetCategories();
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
