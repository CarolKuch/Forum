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
    public class TopicServiceTests

    {
        private Mock<ITopicRepository> _mockTopicRepository = new Mock<ITopicRepository>();
        private Mock<ICategoryRepository> _mockCategoryRepository = new Mock<ICategoryRepository>();

        public TopicServiceTests()
        {
        }

        [Fact]
        public async void GetMessagesInTopic_ReturnsMessageAuthorDtoList_WhenTopicExistAndContainsMessages()
        {
            int validTopicId = 2;
            var messageAuthorDtos = new List<MessageAuthorDto>() { new MessageAuthorDto(), new MessageAuthorDto() };

            _mockTopicRepository.Setup(r => r.GetMessagesInTopic(validTopicId)).ReturnsAsync(messageAuthorDtos);
            ITopicService topicService = new TopicService(
               _mockTopicRepository.Object, _mockCategoryRepository.Object);
            var result = (await topicService.GetMessagesInTopic(validTopicId)).Value;

            messageAuthorDtos.WithDeepEqual(result).Assert();
        }

        [Fact]
        public async void GetMessagesInTopic_ReturnsMessageAuthorDtoList_WhenTopicDoesNotExist()
        {
            int invalidTopicId = -8;

            ITopicService topicService = new TopicService(
               _mockTopicRepository.Object, _mockCategoryRepository.Object);

            Assert.ThrowsAsync<Exception>(async () => await topicService.GetMessagesInTopic(invalidTopicId));
        }
    }
}