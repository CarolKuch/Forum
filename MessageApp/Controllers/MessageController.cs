using MessageApp.Data;
using MessageApp.DTOs;
using MessageApp.Interfaces;
using MessageApp.Models;
using MessageApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            return await _messageService.GetMessages();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(int id)
        {
            return await _messageService.GetMessage(id);
        }

        [HttpGet("messageAuthorDto/{id}")]
        public async Task<MessageAuthorDto> GetMessageAuthorDtoByMessageId(int messageId)
        {
            return await _messageService.GetMessageAuthorDtoByMessageId(messageId);
        }

        [HttpGet("dtos")]
        public async Task<List<MessageAuthorDto>> GetMessageAuthorDtos()
        {
            return await _messageService.GetMessageAuthorDtos();
        }
       

        [HttpPost]
        public async Task<ActionResult<string>> PostMessage(MessageAuthorDto message)
        {
            if (message.Content?.Length > 5 
                && message.UserId != -1 
                && message.TopicId != -1)
            {
                return await _messageService.PostMessage(message.Content, message.UserId, message.TopicId);
            }
            else
            {
                return "Message invalid";
            }
        }
    }
}
