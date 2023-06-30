using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUser(int id);
        public Task<ActionResult<IEnumerable<User>>> GetUsers();
        public Task<ActionResult<string>> PostUser(User user);
    }
}
