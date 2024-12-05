using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ColheitaSolidaria.Models;

namespace ColheitaSolidaria.Data
{
    public class ColheitaSolidariaContext : DbContext
    {
        public ColheitaSolidariaContext (DbContextOptions<ColheitaSolidariaContext> options)
            : base(options)
        {
        }

        public DbSet<ColheitaSolidaria.Models.Perfil> Perfil { get; set; } = default!;
        public DbSet<ColheitaSolidaria.Models.DoadorModel> DoadorModel { get; set; } = default!;
        public DbSet<ColheitaSolidaria.Models.AdministradorModel> AdministradorModel { get; set; } = default!;
        public DbSet<ColheitaSolidaria.Models.RecebedorModel> RecebedorModel { get; set; } = default!;
        public DbSet<ColheitaSolidaria.Models.DoacaoModel> DoacaoModel { get; set; } = default!;
        public DbSet<ColheitaSolidaria.Models.AprovacaoModel> AprovacaoModel { get; set; } = default!;
    }
}
