using MessageApp.Data;
using MessageApp.DTOs;
using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace MessageApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private DataContext _context;
        private IAccountService _accountService;

        public AccountController(DataContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Login)) return BadRequest("Login is taken");

            return await _accountService.Register(registerDto);
        }

        private async Task<bool> UserExists(string username)
        {
            return await _accountService.UserExists(username);
        }
    }
}
