using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Interfaces
{
    public interface ICategoryService
    {
        public Task<ActionResult<Category>> GetCategory(int id);
        public Task<ActionResult<IEnumerable<Category>>> GetCategories();
        public Task<ActionResult<string>> PostCategory(Category category);
    }
}
