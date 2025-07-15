using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Application.Common.MessageProviders;

namespace LibraryManagementSystem.Application.Common.Interfaces
{
    public interface IMessageFullProvider
    {
        MessageFull GetPack();
    }
}
