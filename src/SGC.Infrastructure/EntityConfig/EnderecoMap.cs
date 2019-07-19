using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EntityConfig
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder
                .HasKey(end => end.EnderecoId);

            builder
                .HasOne(end => end.Cliente)
                .WithMany()
                .HasForeignKey(end => end.ClienteId)
                .HasPrincipalKey(con => con.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(end => end.Bairro)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder
                .Property(end => end.CEP)
                .HasColumnType("varchar(8)")
                .IsRequired();

            builder
                .Property(end => end.Logradouro)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder
                .Property(end => end.Referencia)
                .HasColumnType("varchar(400)");
        }
    }
}
