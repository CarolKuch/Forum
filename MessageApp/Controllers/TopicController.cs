using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet]
        public Task<ActionResult<IEnumerable<Topic>>> GetTopics()
        {
            return _topicService.GetTopics();
        }

        [HttpPost]
        public Task<ActionResult<string>> PostTopic(Topic topic)
        {
            return _topicService.PostTopic(topic);
        }
    }
}
