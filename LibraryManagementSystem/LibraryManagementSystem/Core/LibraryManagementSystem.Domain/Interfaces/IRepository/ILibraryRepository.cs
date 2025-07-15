using LibraryManagementSystem.Domain.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Interfaces.IRepository
{
    public interface ILibraryRepository
    {

        Task<IEnumerable<BookDto>> GetBooksAsync();

        Task<BookDto> GetBooksByID(int Id);

        Task InsertBookAsyn(BookDto book);
        Task DeleteBook(int Id);
        Task UpdateBook(BookDto book);
        
    }
}
