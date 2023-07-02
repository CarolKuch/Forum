using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUser(int id);
        public Task<ActionResult<string>> PostUser(User user);
    }
}
