using MessageApp.Data;
using MessageApp.DTOs;
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

        public async Task<ActionResult<Message>> GetMessage(int id)
        {
            return await _messageRepository.GetMessage(id);
        }
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            return await _messageRepository.GetMessages();
        }

        public async Task<List<MessageAuthorDto>> GetMessageAuthorDtos()
        {
            return await _messageRepository.GetMessageAuthorDtos();
        }
        public async Task<ActionResult<string>> PostMessage(Message message)
        {
            if (message.Content?.Length > 0)
            {
                return await _messageRepository.PostMessage(message);
            }
            else
            {
                return "Message invalid";
            }
        }
    }
}
