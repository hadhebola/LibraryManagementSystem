using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Application.Factories.Abstracts;

namespace LibraryManagementSystem.Application.Factories.Interfaces
{
    public interface IUserStrategyFactory
    {
        UserStrategyService UserBaseOnStrategy(string countryId);
    }
}
