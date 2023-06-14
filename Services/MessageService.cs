using MessageApp.Data;
using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessageApp.Services
{
    public class MessageService: IMessageService
    {
        private IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Message> GetMessage(int id)
        {
            return await _messageRepository.GetMessage(id);
        }
        public async Task<ActionResult<string>> PostMessage(Message message)
        {
            return await _messageRepository.PostMessage(message);
        }
    }
}
