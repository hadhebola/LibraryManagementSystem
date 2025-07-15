using LibraryManagementSystem.Api.Filters;
using LibraryManagementSystem.Application.Commands;
using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Application.QueryCommand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ApiControllerBase
    {

        [Authorize]
        [HttpPost, Route("InsertNewBook")]
        [ServiceFilter(typeof(LanguageFilter))]
        [TypeFilter(typeof(DecryptRequestDataFilter<AddNewBookCommand>))]
        public async Task<IActionResult> UpdateCountry([FromBody] BaseEncryptedRequestDTO encryptedRequestData, [FromQuery] AddNewBookCommand command)
        {
            var res = await Mediator.Send(command);
            return res.IsSuccessful ? Ok(res) : BadRequest(res);
        }
        [Authorize]
        [HttpGet, Route("RetrieveAllBooks")]
        [ServiceFilter(typeof(LanguageFilter))]
        [TypeFilter(typeof(DecryptRequestDataFilter<RetrieveAllBooksCommand>))]
        public async Task<IActionResult> RetrieveAllBooks()
        {
            var res = await Mediator.Send(new RetrieveAllBooksCommand { });
            return res.IsSuccessful ? Ok(res) : BadRequest(res);
        }

        [Authorize]
        [HttpPut, Route("UpdateBookDetails")]
        [ServiceFilter(typeof(LanguageFilter))]
        [TypeFilter(typeof(DecryptRequestDataFilter<UpdateBookCommand>))]
        public async Task<IActionResult> UpdateCountry([FromBody] BaseEncryptedRequestDTO encryptedRequestData, [FromQuery] UpdateBookCommand command)
        {
            var res = await Mediator.Send(command);
            return res.IsSuccessful ? Ok(res) : BadRequest(res);
        }

        [Authorize]
        [HttpDelete, Route("DeleteBook")]
        [ServiceFilter(typeof(LanguageFilter))]
        [TypeFilter(typeof(DecryptRequestDataFilter<DeleteBookCommand>))]
        public async Task<IActionResult> UpdateCountry(int Id)
        {
            var res = await Mediator.Send(new DeleteBookCommand { Id=Id});
            return res.IsSuccessful ? Ok(res) : BadRequest(res);
        }
    }
}
