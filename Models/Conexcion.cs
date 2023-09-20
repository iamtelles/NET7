using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class Conexcion : DbContext
    {
        public Conexcion(DbContextOptions<Conexcion> options)
            : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; } = null!;
    }
}