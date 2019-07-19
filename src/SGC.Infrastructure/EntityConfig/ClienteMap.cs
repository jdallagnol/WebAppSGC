using Microsoft.EntityFrameworkCore;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EntityConfig
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cliente> builder)
        {
            builder
                .HasKey(cli => cli.ClienteId);

            builder
                .HasMany(cli => cli.Contatos)
                .WithOne(cli => cli.Cliente)
                .HasForeignKey(cli => cli.ClienteId)
                .HasPrincipalKey(cli => cli.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(cli => cli.Endereco)
                .WithOne(cli => cli.Cliente)
                .HasForeignKey<Endereco>(cli => cli.ClienteId);

            builder
                .Property(cli => cli.CPF)
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder
                .Property(cli => cli.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();
        }
    }
}
