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
            var user = CreateNewUser(registerDto);
            return await _accountRepository.Register(user);
        }

        public Task<bool> UserExists(string username)
        {
            return _accountRepository.UserExists(username);
        }

        public bool CheckIfPasswordIsCorrect(User user, string password)
        {
            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return false;
            }
            return true;
        }

        private User CreateNewUser(RegisterDto registerDto)
        {
            using var hmac = new HMACSHA512();
            return new User
            {
                Login = registerDto.Login.ToLower(),
                LastName = registerDto.LastName,
                Name = registerDto.Name,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
        }

    }
}
