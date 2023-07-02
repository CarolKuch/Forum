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
            throw new NotImplementedException();
        }

        public async Task<ActionResult<string>> PostCategory(Category category)
        {
            return await _categoryRepository.PostCategory(category);
        }
    }
}
