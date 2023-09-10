using MessageApp.Data;
using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessageApp.Services
{
    public class AccountRepository : IAccountRepository
    {
        private DataContext _context;

        public AccountRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<User>> Register(User user)
        {
            user.EnrollmentDate = DateTime.Now;
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(u => u.Name == username.ToLower());
        }
    }
}
