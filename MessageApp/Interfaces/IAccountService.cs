using MessageApp.DTOs;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Interfaces
{
    public interface IAccountService
    {
        public Task<ActionResult<User>> Register(RegisterDto registerDto);
        public Task<bool> UserExists(string username);
    }
}
