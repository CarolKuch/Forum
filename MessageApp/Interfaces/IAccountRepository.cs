using MessageApp.DTOs;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Interfaces
{
    public interface IAccountRepository
    {
        public Task<ActionResult<User>> Register(User user);
        public Task<bool> UserExists(string username);
    }
}
