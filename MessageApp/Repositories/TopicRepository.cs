using MessageApp.Data;
using MessageApp.DTOs;
using MessageApp.Interfaces;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessageApp.Services
{
    public class TopicRepository : ITopicRepository
    {
        private DataContext _context;
        private ICategoryRepository _categoryRepository;
        private IMessageRepository _messageRepository;

        public TopicRepository(DataContext context, ICategoryRepository categoryRepository, IMessageRepository messageRepository)
        {
            _context = context;
            _categoryRepository = categoryRepository;
            _messageRepository = messageRepository;
        }

        public async Task<ActionResult<Topic>> GetTopic(int topicId)
        {
            return await _context.Topics.Where(x => x.TopisID == topicId).FirstAsync();
        }

        public async Task<ActionResult<IEnumerable<MessageAuthorDto>>> GetMessagesInTopic(int topicId)
        {
            var messagesInTopic = await _context.Messages.Where(x => x.TopicId == topicId).ToListAsync();
            List<MessageAuthorDto> messageAuthorInTopicDtos = new List<MessageAuthorDto>();
            foreach(Message mess in messagesInTopic)
            {
                messageAuthorInTopicDtos.Add( await _messageRepository.GetMessageAuthorDtoByMessageId(mess.MessageID));
            };
            return messageAuthorInTopicDtos;
        }

        public async Task<ActionResult<IEnumerable<Topic>>> GetTopicsByCategoryId(int categoryId)
        {
            return await _context.Topics.Where(x => x.CategoryId == categoryId).ToListAsync();
        }

        public Task<ActionResult<IEnumerable<Topic>>> GetTopics()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<string>> PostTopic(Topic topic)
        {
            topic.Date = DateTime.Now;
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();
            return "Topic added successfully";
        }
    }
}
