﻿using System.Net;
using LibraryManagementSystem.Application.Common.Interfaces;
using LibraryManagementSystem.Application.Common.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Serilog;

namespace LibraryManagementSystem.Api.Filters
{
    public class LanguageFilter : IAsyncActionFilter
    {
        private const string HEADER_KEY = "LanguageCode";
        private readonly IMessageProvider _messageProvider;
        private readonly ILanguageService _languageService;
        public LanguageFilter(IMessageProvider messageProvider, ILanguageService languageService)
        {
            _messageProvider = messageProvider;
            _languageService = languageService;

        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string languageCode;
            if (!context.HttpContext.Request.Headers.TryGetValue(HEADER_KEY, out var headers))
            {
                languageCode = "en";

            }
            else
            {
                languageCode = headers.FirstOrDefault();
            }


            if (string.IsNullOrEmpty(languageCode))
            {
                context.Result = new ObjectResult(ResponseStatus<string>.Create<PayloadResponse<string>>(ResponseCodes.INVALID_LANGUAGE_CODE, _messageProvider.GetMessage(ResponseCodes.INVALID_LANGUAGE_CODE), null))
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                return;
            }

            try
            {

                _languageService.SetLanguageCode(languageCode.ToLower());
                await next();


            }
            catch (Exception e)
            {
                Log.Information($"LanguageFilter System error {JsonConvert.SerializeObject(e)}");
                context.Result = new ObjectResult(ResponseStatus<string>.Create<PayloadResponse<string>>(ResponseCodes.INVALID_LANGUAGE_CODE, _messageProvider.GetMessage(ResponseCodes.INVALID_LANGUAGE_CODE), null))
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

    }
}
