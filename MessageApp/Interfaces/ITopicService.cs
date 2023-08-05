using MessageApp.DTOs;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Interfaces
{
    public interface ITopicService
    {
        public Task<ActionResult<Topic>> GetTopic(int id);
        public Task<ActionResult<IEnumerable<Topic>>> GetTopicsByCategoryId(int categoryId);
        public Task<ActionResult<IEnumerable<Topic>>> GetTopics();
        public Task<ActionResult<IEnumerable<MessageAuthorDto>>> GetMessagesInTopic(int topicId);
        public Task<ActionResult<string>> PostTopic(string title, int categoryId);
    }
}
