﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Common.Responses
{
    public class ResponseCodes
    {
        public const string USER_EXIST = "E001";
        public const string WRONG_USERNAME_PASSQORD = "E004";
        public const string INVALID_SESSION = "E003";
        public const string INVALID_PASSWORD_FORMAT = "E002";
        public const string INVALID_USER = "E005";
        public const string SUCCESSFUL = "S00";
        public const string DATA_EXIST = "D01";
        public const string DATA_NOT_EXIST = "D02";
        public const string INVALID_TOKEN = "E0089";
        public const string INVALID_INPUT_PARAMETER = "E0032";
        public const string SYSTEM_ERROR = "E1000";
        public const string INVALID_LANGUAGE_CODE = "E10";
        public const string INVALID_COUNTRY_CODE = "E11";
        public const string UNUTHORIZED = "E77";
    }
}
