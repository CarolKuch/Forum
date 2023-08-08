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

namespace MessageAppTests
{
    public class MessageServiceTests

    {
        private User _user = new User()
        {
            IsAdmin = false,
            UserId = 1,
            Login = "BOB",
            Name = "BOB",
            LastName = "B",
        };
        
        private Topic _topic = new Topic()
        {
            Title = "ABC",
            TopisID = 1,
            CategoryId = 1
        };

        private Mock<IUserRepository> _mockUserRepository = new Mock<IUserRepository>();
        private Mock<ITopicRepository> _mockTopicRepository = new Mock<ITopicRepository>();
        private Mock<IMessageRepository> _mockMessageRepository = new Mock<IMessageRepository>();

        public MessageServiceTests()
        {
        }

        [Fact]
        public async void PostMessage_ReturnsString_WhenMessagePosted()
        {
            var message = new Message()
            {
                Content = "ABCXXX",
                TopicId = 1,
                UserId = 1
            };

            var expectedObjectFromRepository = new Message()
            {
                Content = "ABCXXX",
                TopicId = 1,
                UserId = 1,
                MessageID = 1,
                Date = DateTime.MaxValue
            };

            var expected = new MessageAuthorDto() {
                Content = "ABCXXX",
                TopicId = 1,
                UserId = 1,
                MessageID = 1,
                Date = DateTime.MaxValue,
                IsUserAdmin = _user.IsAdmin,
                UserLogin = _user.Login
             };
            _mockUserRepository.Setup(r => r.GetUser(message.UserId)).ReturnsAsync(_user);
            _mockTopicRepository.Setup(r => r.GetTopic(message.TopicId)).ReturnsAsync(_topic);
            _mockMessageRepository.Setup(r => r.PostMessage(It.Is<Message>(x => x.UserId == _user.UserId && x.TopicId == _topic.TopisID)))
                .ReturnsAsync(expectedObjectFromRepository);
            IMessageService messageService = new MessageService(
                _mockMessageRepository.Object, _mockTopicRepository.Object, _mockUserRepository.Object);

            var result = (await messageService.PostMessage(message.Content, message.UserId, message.TopicId)).Value;
            expected.WithDeepEqual(result).Assert();
        }

        [Fact]
        public async void PostMessage_ReturnsString_WhenMessageInvalid()
        {
            string invalidMessageContent = "";

            var expected = new MessageAuthorDto();

            IMessageService messageService = new MessageService(
                _mockMessageRepository.Object, _mockTopicRepository.Object, _mockUserRepository.Object);

            var result = (await messageService.PostMessage(invalidMessageContent, _user.UserId, _topic.TopisID)).Value;

            expected.WithDeepEqual(result).Assert();
        }
    }
}