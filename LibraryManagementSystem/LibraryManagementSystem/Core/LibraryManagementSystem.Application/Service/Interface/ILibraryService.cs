using LibraryManagementSystem.Application.Common.Responses;
using LibraryManagementSystem.Domain.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Service.Interface
{
    public interface ILibraryService
    {
        // token is supposed to be a different service but i got busy with other stuff and just need to make it work. In real time. Things will be well aligned
        Task<PayloadResponse<object>> GetToken(LoginDto login);
        Task<PayloadResponse<object>> AddBook(BookDto book);
        Task<PayloadResponse<object>> GetBooks();
        Task<PayloadResponse<object>> UpdateBook(BookDto book);
        Task<PayloadResponse<object>> DeleteBook(int Id);
    }
}
