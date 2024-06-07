using ControleAtletas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtletas.Context
{
    public class AppDbContext:DbContext
    {
      
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }
            public DbSet<Atleta> Atleta { get; set; }
      
    }
}
