using MessageApp.Data;
using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessageApp.Services
{
    public class UserService: IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUser(int id)
        {
            return await _userRepository.GetUser(id);
        }
        public async Task<ActionResult<string>> PostUser(User user)
        {
            return await _userRepository.PostUser(user);
        }

    }
}
