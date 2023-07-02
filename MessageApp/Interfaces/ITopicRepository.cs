using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Interfaces
{
    public interface ITopicRepository
    {
        public Task<ActionResult<Topic>> GetTopic(int id);
        public Task<ActionResult<IEnumerable<Topic>>> GetTopics();
        public Task<ActionResult<string>> PostTopic(Topic topic);
    }
}
