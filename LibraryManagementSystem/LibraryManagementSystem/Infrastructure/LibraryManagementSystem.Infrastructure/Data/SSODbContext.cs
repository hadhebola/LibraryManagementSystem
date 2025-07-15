using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Entities.Dals;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.Data
{
    public class SSODbContext : DbContext
    {
        public SSODbContext(DbContextOptions<SSODbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<Users> Users { get; set; }
    }
}
