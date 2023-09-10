using MessageApp.Data;
using MessageApp.Interfaces;
using MessageApp.Models;
using MessageApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("userId")]
        public async Task<User> GetUserById(int id)
        {
            return await _userService.GetUserById(id);
        }

        [HttpGet("login")]
        public async Task<User?> GetUserByLogin(string login)
        {
            return await _userService.GetUserByLogin(login);
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostUser(User user)
        {
            return await _userService.PostUser(user);
        }

        //[HttpPut]
        //public void UpdateMessage(int id, [FromBody] string value)
        //{
        //}

        //[HttpDelete]
        //public void DeleteMessage(int id)
        //{
        //}
    }
}
