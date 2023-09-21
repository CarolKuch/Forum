using MessageApp.Data;
using MessageApp.DTOs;
using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace MessageApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
        private IUserService _userService;
        private ITokenService _tokenService;

        public AccountController(IAccountService accountService, IUserService userService, ITokenService tokenService)
        {
            _accountService = accountService;
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Login)) return BadRequest("Login is taken");

            var user = (await _accountService.Register(registerDto)).Value;

            return new UserDto
            {
                Login = user.Login,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userService.GetUserByLogin(loginDto.Login);
            if (user == null) return Unauthorized("User doesn't exist");

            var isPasswordCorrect = _accountService.CheckIfPasswordIsCorrect(user, loginDto.Password);

            return (isPasswordCorrect) ? 
                new UserDto
                {
                    Login = user.Login,
                    Token = _tokenService.CreateToken(user)
                } 
                : Unauthorized("Invalid password");
        }

        private async Task<bool> UserExists(string username)
        {
            return await _accountService.UserExists(username);
        }
    }
}
