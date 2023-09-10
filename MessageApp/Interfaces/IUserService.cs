using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUserById(int id);
        public Task<User?> GetUserByLogin(string login);
        public Task<ActionResult<string>> PostUser(User user);
    }
}
