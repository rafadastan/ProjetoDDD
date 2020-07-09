using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("IdCliente");

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnName("Email")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Cpf)
               .HasColumnName("Cpf")
               .HasMaxLength(15)
               .IsRequired();

            builder.Property(c => c.PlanoId)
               .HasColumnName("IdPlano")
               .IsRequired();

            #region Mapeamento de ForeignKey

            //Cliente TEM 1 Plano / Plano TEM MUITOS Clientes
            builder.HasOne(c => c.Plano) //Cliente TEM 1 Plano
                .WithMany(p => p.Clientes) //Plano TEM * Clientes
                .HasForeignKey(c => c.PlanoId); //Chave estrangeira

            #endregion

        }
    }
}
