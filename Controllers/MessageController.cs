using MessageApp.Data;
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
        public Message GetMessage(int id)
        {
            return _messageService.GetMessage(id);
        }

        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
            return await _messageService.PostMessage(message);
        }

        //[HttpPut]
        //public void UpdateMessage(int id, [FromBody] string value)
        //{
        //}

        //[HttpDelete]
        //public void DeleteMessage(int id)
        //{
        //}
    }
}
