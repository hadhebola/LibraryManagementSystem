using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Application.Common.Interfaces;

namespace LibraryManagementSystem.Application.Common.MessageProviders
{
    public class LanguageService : ILanguageService
    {
        private string _languageCode;

        public void SetLanguageCode(string languageCode)
        {
            _languageCode = languageCode;
        }

        public string GetLanguageCode()
        {
            return _languageCode;
        }
    }
}
