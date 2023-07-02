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

        [HttpGet("dtos")]
        public async Task<List<MessageAuthorDto>> GetMessageAuthorDtos()
        {
            return await _messageService.GetMessageAuthorDtos();
        }
       

        [HttpPost]
        public async Task<ActionResult<string>> PostMessage(Message message)
        {

            if (message.Content?.Length > 0)
            {
                return await _messageService.PostMessage(message);
            }
            else
            {
                return "Message invalid";
            }
        }
    }
}
