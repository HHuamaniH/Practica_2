using Microsoft.EntityFrameworkCore;

namespace WApiSigoSFC.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(
            DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Provincia> Provincias { get; set; }

    }
}
