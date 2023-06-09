using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Interfaces
{
    public interface IMessageService
    {
        public Message GetMessage(int id);
        public Task<ActionResult<Message>> PostMessage(Message message);
    }
}
