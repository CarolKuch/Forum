using MessageApp.DTOs;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Interfaces
{
    public interface IMessageService
    {
        public Task<ActionResult<Message>> GetMessage(int id);
        public Task<ActionResult<IEnumerable<Message>>> GetMessages();
        public Task<MessageAuthorDto> GetMessageAuthorDtoByMessageId(int messageId);
        public Task<List<MessageAuthorDto>> GetMessageAuthorDtos();
        public Task<ActionResult<string>> PostMessage(string messageContent, int userId, int topicId);
    }
}
