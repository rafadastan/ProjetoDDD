using Microsoft.EntityFrameworkCore;
using Projeto.Domain;
using Projeto.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Dependente> Dependente { get; set; }
        public DbSet<Plano> Plano { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new DependenteMap());
            modelBuilder.ApplyConfiguration(new PlanoMap());

            modelBuilder.Entity<Cliente>(entity => {
                entity.HasIndex(c => c.Cpf).IsUnique();
                entity.HasIndex(c => c.Email).IsUnique();
            });

            modelBuilder.Entity<Plano>(entity => {
                entity.HasIndex(p => p.Sigla).IsUnique();
            });
        }
    }
}
