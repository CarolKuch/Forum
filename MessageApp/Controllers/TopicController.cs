using MessageApp.DTOs;
using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet("{id}")]
        public Task<ActionResult<Topic>> GetTopic(int id)
        {
            return _topicService.GetTopic(id);
        }

        [HttpGet("{id}/messages")]
        public Task<ActionResult<IEnumerable<MessageAuthorDto>>> GetMessagesInTopic(int id)
        {
            return _topicService.GetMessagesInTopic(id);
        }

        [HttpGet("categoryId/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Topic>>> GetTopicsByCategoryId(int categoryId)
        {
            return await _topicService.GetTopicsByCategoryId(categoryId);
        }

        [HttpGet]
        public Task<ActionResult<IEnumerable<Topic>>> GetTopics()
        {
            return _topicService.GetTopics();
        }

        [HttpPost]
        public Task<ActionResult<string>> PostTopic(string title, int categoryId)
        {
            return _topicService.PostTopic(title, categoryId);
        }
    }
}
