using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EntityConfig
{
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder
                .HasKey(con => con.ContatoId);

            builder
                .HasOne(con => con.Cliente)
                .WithMany(con => con.Contatos)
                .HasForeignKey(con => con.ClienteId)
                .HasPrincipalKey(con => con.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(con => con.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder
                .Property(con => con.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(con => con.Telefone)
                .HasColumnType("varchar(15)");
        }
    }
}
