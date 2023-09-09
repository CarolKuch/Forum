using MessageApp.Controllers;
using MessageApp.Interfaces;
using MessageApp.Models;
using MessageApp.Repositories;
using MessageApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

using Microsoft.Extensions.Configuration;
using MessageApp.DTOs;
using DeepEqual.Syntax;
using System.Text;
using System.Reflection;

namespace MessageAppTests
{
    public class AccountServiceTests

    {
        private Mock<IAccountRepository> _mockAccountRepository = new Mock<IAccountRepository>();

        public AccountServiceTests()
        {
        }

        [Fact]
        public void CreateNewUser_ReturnsUser_WhenUserWasCreated()
        {
            IAccountService accountService = new AccountService(_mockAccountRepository.Object);

            MethodInfo methodInfo = typeof(AccountService).GetMethod("CreateNewUser", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { new RegisterDto
            {
                Login = "HabbBabbaa",
                LastName = "Babba",
                Name = "Baba",
                Password = "topsecret1"
            }};

            var result = methodInfo.Invoke(accountService, parameters);

            Assert.NotNull(result);
            Assert.IsType<User>(result);
        }

        [Fact]
        public async void UserExists_ReturnsTrue_WhenUserExists()
        {
            var takenUsername = "BobB";
            _mockAccountRepository.Setup(r => r.UserExists(takenUsername)).ReturnsAsync(true);
            IAccountService accountService = new AccountService(_mockAccountRepository.Object);


            var result = await accountService.UserExists(takenUsername);

            Assert.True(result);
        }

        [Fact]
        public async void Register_ReturnsUser_WhenUserWasRegistered()
        {
            var registerDto = new RegisterDto
            {
                Login = "HabbBabbaa",
                LastName = "Babba",
                Name = "Baba",
                Password = "topsecret1"
            };
            var user = new User();
            _mockAccountRepository.Setup(r => r.Register(It.IsAny<User>())).ReturnsAsync(user);
            IAccountService accountService = new AccountService(_mockAccountRepository.Object);

            var result = await accountService.Register(registerDto);

            Assert.NotNull(result);
            Assert.IsType<User>(result.Value);
        }
    }
}