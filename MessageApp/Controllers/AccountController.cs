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
        private IUserService _userService;

        public AccountController(DataContext context, IAccountService accountService, IUserService userService)
        {
            _context = context;
            _accountService = accountService;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Login)) return BadRequest("Login is taken");

            return await _accountService.Register(registerDto);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(LoginDto loginDto)
        {
            var user = await _userService.GetUserByLogin(loginDto.Login);
            if (user == null) return Unauthorized("User doesn't exist");

            var isPasswordCorrect = _accountService.CheckIfPasswordIsCorrect(user, loginDto.Password);

            return (isPasswordCorrect) ? user : Unauthorized("Invalid password");
        }

        private async Task<bool> UserExists(string username)
        {
            return await _accountService.UserExists(username);
        }
    }
}
