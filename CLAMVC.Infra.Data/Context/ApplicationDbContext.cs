using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CLAMVC.Domain.Entities;
using CLAMVC.Infra.Data.EntitiesConfiguration;

namespace CLAMVC.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Configuração Automática - de configuração de classes que herdadam de IEntityTypeConfiguration<Tipo> dentro deste Assembly usando Reflections
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            //Configuração Manual - de cada configuração de classe
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}
