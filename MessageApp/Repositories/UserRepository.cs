using MessageApp.Data;
using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessageApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;

        public UserRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.Where(x => x.UserId == id).SingleAsync();
        }

        public async Task<User?> GetUserByLogin(string login)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Login == login.ToLower());
            if (user == null) return null;
            return user;
        }
       
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ActionResult<string>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "User added successfully";
        }
    }
}
