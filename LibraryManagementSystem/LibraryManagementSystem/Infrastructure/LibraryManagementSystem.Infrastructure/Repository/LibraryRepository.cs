using Confluent.Kafka;
using LibraryManagementSystem.Domain.Entities.Dtos;
using LibraryManagementSystem.Domain.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.Repository
{
    public class LibraryRepository: ILibraryRepository//, IDisposable
    {
        //private LibraryContext _context;
        private DbContextOptionsBuilder<LibraryContext> optionsBuilder;
        private IConfiguration _config;
        public LibraryRepository(LibraryContext context, DbContextOptionsBuilder<LibraryContext> dbContextOptionsBuilder, IConfiguration config)
        {
            _config = config;
            optionsBuilder = dbContextOptionsBuilder;
            optionsBuilder.UseSqlServer(config.GetValue<string>( "ConnectionStrings:DefaultConnection"));
           
        }

        public async Task DeleteBook(int Id)
        {
            using (var context = new LibraryContext(optionsBuilder.Options))
            {
                BookDto? book = await context.Books.FindAsync(Id);
                context.Books.Remove(book!);
                await context.SaveChangesAsync();
            }
           
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {

            using (var context = new LibraryContext(optionsBuilder.Options))
            {
                return await context.Books.ToListAsync();
            }
            
        }

        public async Task< BookDto> GetBooksByID(int Id)
        {

            using (var context = new LibraryContext(optionsBuilder.Options))
            {
                return await context.Books.FindAsync(Id);
            }
           
        }

        public async Task InsertBookAsyn(BookDto book)
        {          

            using (var context = new LibraryContext(optionsBuilder.Options))
            {
               await context.Books.AddAsync(book);
               await context.SaveChangesAsync(); 
            }          
        }

        

        public async Task  UpdateBook(BookDto book)
        {
            using (var context = new LibraryContext(optionsBuilder.Options))
            {
                context.Entry(book).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
