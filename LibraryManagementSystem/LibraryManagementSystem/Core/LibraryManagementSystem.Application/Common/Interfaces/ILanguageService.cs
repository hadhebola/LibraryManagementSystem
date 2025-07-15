using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Common.Interfaces
{
    public interface ILanguageService
    {
        void SetLanguageCode(string languageCode);
        string GetLanguageCode();
    }
}
