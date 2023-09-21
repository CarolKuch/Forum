using AutoMapper;
using MessageApp.AutoMapper;
using MessageApp.Data;
using MessageApp.Interfaces;
using MessageApp.Repositories;
using MessageApp.Services;
using Microsoft.EntityFrameworkCore;

namespace MessageApp.Extensions
{
    public static class AppServiceExtension
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(options =>
                options.UseSqlite(config.GetConnectionString("DefaultConnection")));
            services.AddCors();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MessageProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
