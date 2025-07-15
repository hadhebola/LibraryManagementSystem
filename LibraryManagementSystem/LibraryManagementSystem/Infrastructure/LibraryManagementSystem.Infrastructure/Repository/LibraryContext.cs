using LibraryManagementSystem.Domain.Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem.Infrastructure.Repository
{
    public class LibraryContext: DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options):base(options) 
        {            
        }

        public DbSet<BookDto> Books { get; set; }
    }
}
