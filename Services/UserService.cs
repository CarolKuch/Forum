using MessageApp.Data;
using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessageApp.Services
{
    public class UserService: IUserService
    {
        private DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public User GetUser(int id)
        {
            var user = new User();
            
            return user;
        }
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new OkObjectResult(await _context.Users.FirstAsync());
        }
    }
}
