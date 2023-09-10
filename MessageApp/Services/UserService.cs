using MessageApp.Data;
using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace MessageApp.Services
{
    public class UserService: IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User?> GetUserByLogin(string login)
        {
            return await _userRepository.GetUserByLogin(login);
        }

        public async Task<ActionResult<string>> PostUser(User user)
        {
            return await _userRepository.PostUser(user);
        }

    }
}
