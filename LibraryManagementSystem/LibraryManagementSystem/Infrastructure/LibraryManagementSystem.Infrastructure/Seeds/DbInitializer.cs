using LibraryManagementSystem.Domain.Entities.Dtos;
using LibraryManagementSystem.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.Seeds
{
    public class DbInitializer
    {
        public static void Seed(LibraryContext context)
        {
            
            context.Database.EnsureCreated();
            context.Database.Migrate();
            
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                     new BookDto { Title = "Ade book1", Author = "Adebola Aremu", ISBN = "ISBN 1", PublishedDate = DateTime.Now },
                new BookDto {  Title = "Ade book2", Author = "Adebola Aremu", ISBN = "ISBN 2", PublishedDate = DateTime.Now },
                new BookDto {  Title = "Wasiu book 1", Author = "Wasiu Keggs", ISBN = "ISBN 1", PublishedDate = DateTime.Now }
                );
                context.SaveChanges();
            }
        }

    }
}
