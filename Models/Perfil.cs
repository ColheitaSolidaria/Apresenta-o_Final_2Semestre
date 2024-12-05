using Microsoft.EntityFrameworkCore;

namespace ColheitaSolidaria.Models
{
    public class AppDbContext : DbContext
    {

        public DbSet<Perfil> Perfis { get; set; }
        public object Perfil { get; internal set; }
        public object Login { get; internal set; }
    }

}