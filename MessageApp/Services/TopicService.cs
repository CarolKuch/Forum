using MessageApp.DTOs;
using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Services
{
    public class TopicService : ITopicService
    {
        private ITopicRepository _topicRepository;
        private ICategoryRepository _categoryRepository;

        public TopicService(ITopicRepository topicRepository, ICategoryRepository categoryRepository)
        {
            _topicRepository = topicRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ActionResult<Topic>> GetTopic(int topicId)
        {
            return await _topicRepository.GetTopic(topicId);
        }

        public async Task<ActionResult<IEnumerable<MessageAuthorDto>>> GetMessagesInTopic(int topicId)
        {
            return await _topicRepository.GetMessagesInTopic(topicId);
        }

        public async Task<ActionResult<IEnumerable<Topic>>> GetTopicsByCategoryId(int categoryId)
        {
            return await _topicRepository.GetTopicsByCategoryId(categoryId);
        }

        public Task<ActionResult<IEnumerable<Topic>>> GetTopics()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<string>> PostTopic(string title, int categoryId)
        {
            var topic = new Topic();
            if (title.Length > 0 && categoryId != -1)
            {
                topic.Title = title;
                topic.CategoryId = _categoryRepository.GetCategory(categoryId).Result.Value.CategoryID;
                return await _topicRepository.PostTopic(topic);
            }
            else
            {
                return "Message invalid";
            }
        }
    }
}
