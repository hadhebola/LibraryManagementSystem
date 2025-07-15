using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Application.Factories.Abstracts;
using LibraryManagementSystem.Application.Factories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.Application.Factories.Implementations
{
    public class UserStrategyFactory : IUserStrategyFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public UserStrategyFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public UserStrategyService UserBaseOnStrategy(string countryId)
        {
            switch (countryId)
            {

                case "01":
                    return _serviceProvider.GetService<NigeriaUserStrategyFactory>()!;
                default:
                    throw new ArgumentException($"Unsupported country: {countryId}");
            }
        }
    }
}
