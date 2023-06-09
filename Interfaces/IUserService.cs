using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Interfaces
{
    public interface IUserService
    {
        public User GetUser(int id);
        public Task<ActionResult<User>> PostUser(User user);
    }
}
