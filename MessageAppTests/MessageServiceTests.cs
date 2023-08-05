using MessageApp.Controllers;
using MessageApp.Interfaces;
using MessageApp.Models;
using MessageApp.Repositories;
using MessageApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

using Microsoft.Extensions.Configuration;



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
                Content = "ABC",
                TopicId = 1,
                UserId = 1
            };

            var expectedMessage = "Message added successfully";

            _mockUserRepository.Setup(r => r.GetUser(message.UserId)).ReturnsAsync(_user);
            _mockTopicRepository.Setup(r => r.GetTopic(message.TopicId)).ReturnsAsync(_topic);
            _mockMessageRepository.Setup(r => r.PostMessage(It.Is<Message>(x => x.UserId == _user.UserId && x.TopicId == _topic.TopisID)))
                .ReturnsAsync(expectedMessage);
            IMessageService messageService = new MessageService(
                _mockMessageRepository.Object, _mockTopicRepository.Object, _mockUserRepository.Object);

            var result = await messageService.PostMessage(message.Content, message.UserId, message.TopicId);
            Assert.Equal(expectedMessage, result?.Value?.ToString());
        }

        [Fact]
        public async void PostMessage_ReturnsString_WhenMessageInvalid()
        {
            var message = new Message()
            {
                Content = "",
                TopicId = 1,
                UserId = 1
            };

            var expectedMessage = "Message invalid";

            _mockUserRepository.Setup(r => r.GetUser(message.UserId)).ReturnsAsync(_user);
            _mockTopicRepository.Setup(r => r.GetTopic(message.TopicId)).ReturnsAsync(_topic);
            _mockMessageRepository.Setup(r => r.PostMessage(It.Is<Message>(x => x.UserId == _user.UserId && x.TopicId == _topic.TopisID)))
                .ReturnsAsync(expectedMessage);
            IMessageService messageService = new MessageService(
                _mockMessageRepository.Object, _mockTopicRepository.Object, _mockUserRepository.Object);

            var result = await messageService.PostMessage(message.Content, message.UserId, message.TopicId);
            Assert.Equal(expectedMessage, result?.Value?.ToString());
        }
    }
}