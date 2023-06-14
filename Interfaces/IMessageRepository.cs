using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Interfaces
{
    public interface IMessageRepository
    {
        public Task<Message> GetMessage(int id);
        public Task<ActionResult<string>> PostMessage(Message message);
    }
}
