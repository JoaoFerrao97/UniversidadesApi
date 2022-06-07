using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace UniversidadesApi.Models
{
    public class UniversidadesContext : DbContext
    {
        public UniversidadesContext(DbContextOptions<UniversidadesContext> options)
           : base(options)
        {
        }

        public DbSet<UniversidadesItem> UniversidadesItems { get; set; } = null!;
    }
}
