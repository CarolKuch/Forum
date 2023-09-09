using MessageApp.DTOs;
using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace MessageApp.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<ActionResult<User>> Register(RegisterDto registerDto)
        {
            using var hmac = new HMACSHA512();
            var user = new User
            {
                Login = registerDto.Login.ToLower(),
                LastName = registerDto.LastName,
                Name = registerDto.Name,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            return await _accountRepository.Register(user);
        }

        public Task<bool> UserExists(string username)
        {
            return _accountRepository.UserExists(username);
        }
    }
}
