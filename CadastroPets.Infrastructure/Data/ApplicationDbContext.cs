using CadastroPets.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroPets.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
