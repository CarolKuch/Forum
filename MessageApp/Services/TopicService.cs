using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Services
{
    public class TopicService : ITopicService
    {
        public Task<ActionResult<Topic>> GetTopic(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<Topic>>> GetTopics()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<string>> PostTopic(Topic topic)
        {
            throw new NotImplementedException();
        }
    }
}
