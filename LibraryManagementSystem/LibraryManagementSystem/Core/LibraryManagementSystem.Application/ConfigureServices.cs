using System.Reflection;
using Cachelibrary;
using FluentValidation;
using KafkaLibrary;
using LibraryManagementSystem.Application.Common.Behaviors;
using LibraryManagementSystem.Application.Common.Cache;
using LibraryManagementSystem.Application.Common.HttpClientRequest;
using LibraryManagementSystem.Application.Common.Interfaces;
using LibraryManagementSystem.Application.Common.MessageProviders;
using LibraryManagementSystem.Application.Common.Utils;
using LibraryManagementSystem.Application.Factories.Implementations;
using LibraryManagementSystem.Application.Factories.Interfaces;
using LibraryManagementSystem.Application.Handler;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Application.kafkaConsumer;
using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Application.Service.Implementation;
using LibraryManagementSystem.Application.Service.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace LibraryManagementSystem.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddScoped<IGetUserByCondition, GetUserByCondition>();
            services.AddSingleton<ILanguageService, LanguageService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddSingleton<IMessageProvider, MessageProvider>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IMessageFullProvider, MessageFullProvider>();
            services.AddSingleton<IClientRequest, ClientRequest>();
            services.Configure<MessageFullSettings>(opt => configuration.GetSection("MessageFullSettings").Bind(opt));
            services.Configure<SystemSetting>(opt => configuration.GetSection("SystemSettings").Bind(opt));

            services.AddTransient<NigeriaUserStrategyFactory>();
            services.AddTransient<ILibraryService, LibraryService>();
            

            services.AddTransient<IUserStrategyFactory, UserStrategyFactory>();


            #region RedisSetup

            var cacheConfig = configuration.GetSection("Redis").Get<ConfigurationOptions>();


            var endPoints = configuration.GetSection("Redis:EndPoints")!.Get<string[]>()!.ToArray();

            var useSentinel = configuration.GetSection("Redis:UserSentinel")!.Get<bool>();

            var useRedisFlag = configuration.GetSection("Redis:UseRedis")!.Get<bool>();
            var encryptionKey = configuration.GetValue<string>("SystemSettings:EncryptionKey");
            var password = GeneralUtil.Decryptor(cacheConfig!.Password, encryptionKey);

            foreach (var item in endPoints)
            {
                cacheConfig!.EndPoints.Add(item);
            }

            services.AddCacheServices<CacheOptionsProvider, CacheEnum>(opt =>
            {

                foreach (var item in cacheConfig!.EndPoints)
                {
                    opt.EndPoints.Add(item);
                }
                opt.Password = password;

                if (useSentinel) opt.CommandMap = CommandMap.Sentinel;

                opt.AbortOnConnectFail = cacheConfig!.AbortOnConnectFail;
            }, useRedis: useRedisFlag);

            #endregion

            #region KafkaSetup

            var kafkaConfig = configuration.GetSection("Kafka");
            services.AddKafkaServices<Consumer>(kafkaConfig);

            #endregion
            return services;
        }
    }
}
