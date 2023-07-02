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
        readonly Mock<IConfiguration> configuration;
        readonly Mock<ILogger<IMessageService>> logger;

        public MessageServiceTests()
        {
            this.configuration = new Mock<IConfiguration>();
            this.logger = new Mock<ILogger<IMessageService>>();
        }

        [Fact]
        public async void PostMessage_ReturnsString_WhenMessagePosted()
        {
            //Arrange
            Message message = new Message()
            {
                Content = "XYZ",
                TopicId = 3,
                UserId = 1
            };
            Mock<IMessageRepository> mockMessageRepository = new Mock<IMessageRepository>();
            mockMessageRepository.Setup(r => r.PostMessage(message)).ReturnsAsync("Message added successfully");
            IMessageService messageService = new MessageService(mockMessageRepository.Object);
            string expected = "Message added successfully";

            //Act
            
            var result = await messageService.PostMessage(message);

            //Assert
            Assert.Equal(expected, result?.Value?.ToString());

        }

        [Fact]
        public async void PostMessage_ReturnsString_WhenMessageInvalid()
        {
            //Arrange
            Message message = new Message();
            Mock<IMessageRepository> mockMessageRepository = new Mock<IMessageRepository>();
            mockMessageRepository.Setup(r => r.PostMessage(message)).ReturnsAsync("Message added successfully");
            IMessageService messageService = new MessageService(mockMessageRepository.Object);
            string expected = "Message invalid";

            //Act

            var result = await messageService.PostMessage(message);

            //Assert
            Assert.Equal(expected, result?.Value?.ToString());
        }
    }
}