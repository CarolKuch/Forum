using MessageApp.Data;
using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessageApp.Services
{
    public class MessageService: IMessageService
    {
        private DataContext _context;

        public MessageService(DataContext context)
        {
            _context = context;
        }

        public Message GetMessage(int id)
        {
            var message = new Message();
            message.Content = "ABC";
            return message;
        }
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return new OkObjectResult(await _context.Messages.FirstAsync());
        }
    }
}
