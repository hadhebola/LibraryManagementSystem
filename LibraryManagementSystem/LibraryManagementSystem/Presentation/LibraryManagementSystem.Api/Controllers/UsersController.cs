using Confluent.Kafka;
using LibraryManagementSystem.Api.Filters;
using LibraryManagementSystem.Api.Middlewares;
using LibraryManagementSystem.Application.Commands;
using LibraryManagementSystem.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers
{
    [Route("api/v1/SSOUser")]
    [ApiController]
    public class UsersController : ApiControllerBase
    {
        [HttpPost, Route("OnboardSS0User")]
        [ServiceFilter(typeof(LanguageFilter))]
        [ServiceFilter(typeof(CountryFilter))]
        [TypeFilter(typeof(DecryptRequestDataFilter<CreateUserCommand>))]
        public async Task<IActionResult> CreateSSOUser([FromBody] BaseEncryptedRequestDTO encryptedRequestData, [FromQuery] CreateUserCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }


        [HttpPost, Route("getToken")]
        [ServiceFilter(typeof(LanguageFilter))]
        [ServiceFilter(typeof(CountryFilter))]
        [TypeFilter(typeof(DecryptRequestDataFilter<GetTokenCommand>))]
        public async Task<IActionResult> CreateSSOUser([FromBody] BaseEncryptedRequestDTO encryptedRequestData, [FromQuery] GetTokenCommand command)
        {
            var res = await Mediator.Send(command);            
            return res.IsSuccessful ? Ok(res) : BadRequest(res);
        }



    }
}
