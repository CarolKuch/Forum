using MessageApp.Data;
using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessageApp.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private DataContext _context;

        public MessageRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Message> GetMessage(int id)
        {
            return await _context.Messages.Where(x => x.MessageID == id).SingleAsync();
        }

        public async Task<ActionResult<string>> PostMessage(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return "Message added successfully";
        }
    }
}
