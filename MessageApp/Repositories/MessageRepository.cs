using AutoMapper;
using MessageApp.AutoMapper;
using MessageApp.Data;
using MessageApp.DTOs;
using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MessageApp.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private DataContext _context;
        private IMapper _mapper;
        private IUserRepository _userRepository;

        public MessageRepository(DataContext context, IMapper mapper, IUserRepository userRepository)
        {
            _context = context;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ActionResult<Message>> GetMessage(int id)
        {
            return await _context.Messages.Where(x => x.MessageID == id).SingleAsync();
        }

        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task<MessageAuthorDto> GetMessageAuthorDtoByMessageId(int messageId)
        {
            var message = await _mapper.ProjectTo<MessageAuthorDto>(_context.Messages.Where(x => x.MessageID == messageId)).FirstAsync();
            var user = await _userRepository.GetUser(message.UserId);
            message.UserLogin = user.Login;
            message.IsUserAdmin = user.IsAdmin;
            return message;
        }

        public Task<List<MessageAuthorDto>> GetMessageAuthorDtos()
        {
            var result = _mapper.ProjectTo<MessageAuthorDto>(_context.Messages).ToListAsync();
            result.Result.ForEach(message =>
            {
                var user = _userRepository.GetUser(message.UserId);
                message.UserLogin = user.Result.Login;
                message.IsUserAdmin = user.Result.IsAdmin;
            });
     
            return result;
        }

        public async Task<ActionResult<string>> PostMessage(Message message)
        {
            message.Date = DateTime.Now;
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return "Message added successfully";
        }
    }
}
