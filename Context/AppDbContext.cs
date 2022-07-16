using ApiBuscaCepV2.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBuscaCepV2.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Usuario>? Usuario { get; set; }
        public DbSet<Endereco>? Enderecos { get; set; }
    }
}