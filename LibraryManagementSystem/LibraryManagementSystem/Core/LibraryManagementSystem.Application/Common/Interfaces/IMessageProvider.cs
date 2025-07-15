using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Application.Common.Enums;

namespace LibraryManagementSystem.Application.Common.Interfaces
{
    public interface IMessageProvider
    {
        string GetMessage(string code);
        string GetOtpMessage(OtpPurpose otpPurpose);
    }
}
