using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class PlanoMap : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            //nome da tabela
            builder.ToTable("Plano");

            //chave primária
            builder.HasKey(p => p.Id);

            //campos da tabela
            builder.Property(p => p.Id)
                .HasColumnName("IdPlano");

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Sigla)
                .HasColumnName("Sigla")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}
