using MessageApp.Data;
using MessageApp.DTOs;
using MessageApp.Interfaces;
using MessageApp.Models;
using MessageApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessageApp.Services
{
    public class MessageService: IMessageService
    {
        private IMessageRepository _messageRepository;
        private ITopicRepository _topicRepository;
        private IUserRepository _userRepository;

        public MessageService(IMessageRepository messageRepository, ITopicRepository topicRepository, IUserRepository userRepository)
        {

            _messageRepository = messageRepository;
            _topicRepository = topicRepository;
            _userRepository = userRepository;
        }

        public async Task<ActionResult<Message>> GetMessage(int id)
        {
            return await _messageRepository.GetMessage(id);
        }
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            return await _messageRepository.GetMessages();
        }

        public async Task<MessageAuthorDto> GetMessageAuthorDtoByMessageId(int messageId)
        {
            return await _messageRepository.GetMessageAuthorDtoByMessageId(messageId);
        }

        public async Task<List<MessageAuthorDto>> GetMessageAuthorDtos()
        {
            return await _messageRepository.GetMessageAuthorDtos();
        }

        public async Task<ActionResult<MessageAuthorDto>> PostMessage(string messageContent, int userId, int topicId)
        {
            var message = new Message();

            if (messageContent.Length > 5)
            {
                message.Content = messageContent;
                message.UserId = userId;
                message.TopicId = topicId;
                var date = (await _messageRepository.PostMessage(message)).Value;
                var user = (await _userRepository.GetUser(userId));
                return new MessageAuthorDto
                {
                    MessageID = date.MessageID,
                    Content = messageContent,
                    UserId = userId,
                    TopicId = topicId,
                    IsUserAdmin = user.IsAdmin,
                    UserLogin = user.Login,
                    Date = date.Date,
                };
            }
            else return new MessageAuthorDto();
        }
    }
}
