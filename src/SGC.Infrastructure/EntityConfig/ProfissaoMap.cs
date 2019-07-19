using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EntityConfig
{
    public class ProfissaoMap : IEntityTypeConfiguration<Profissao>
    {
        public void Configure(EntityTypeBuilder<Profissao> builder)
        {
            builder
                .Property(prof => prof.Nome)
                .HasColumnType("varchar(400)")
                .IsRequired();

            builder
                .Property(prof => prof.Descricao)
                .HasColumnType("varchar(1000)")
                .IsRequired();

            builder
                .Property(prof => prof.CBO)
                .HasColumnType("varchar(11)")
                .IsRequired();
        }
    }
}
