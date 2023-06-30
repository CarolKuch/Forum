using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Services
{
    public class CategoryService : ICategoryService
    {
        public Task<ActionResult<Category>> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<string>> PostCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
