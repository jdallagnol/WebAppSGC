using Microsoft.EntityFrameworkCore;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.Data
{
    public class ClienteContext: DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Contato>().ToTable("Contato");
            modelBuilder.Entity<Profissao>().ToTable("Profissao");
            modelBuilder.Entity<Endereco>().ToTable("Endereco");
            modelBuilder.Entity<ProfissaoCliente>().ToTable("ProfissaoCliente");

            #region Configurações de Cliente

            modelBuilder.Entity<Cliente>()
                .HasKey(cli => cli.ClienteId);

            modelBuilder.Entity<Cliente>()
                .HasMany(cli => cli.Contatos)
                .WithOne(cli => cli.Cliente)
                .HasForeignKey(cli => cli.ClienteId)
                .HasPrincipalKey(cli => cli.ClienteId);

            modelBuilder.Entity<Cliente>()
                .Property(cli => cli.CPF)
                .HasColumnType("varchar(11)")
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(cli => cli.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();
            #endregion

            #region Configurações de Contato

            modelBuilder.Entity<Contato>()
                .HasKey(con => con.ContatoId);

            modelBuilder.Entity<Contato>()
                .HasOne(con => con.Cliente)
                .WithMany(con => con.Contatos)
                .HasForeignKey(con => con.ClienteId)
                .HasPrincipalKey(con => con.ClienteId);

            modelBuilder.Entity<Contato>()
                .Property(con => con.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();

            modelBuilder.Entity<Contato>()
                .Property(con => con.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            modelBuilder.Entity<Contato>()
                .Property(con => con.Telefone)
                .HasColumnType("varchar(15)");
            #endregion

            #region Configurações de Profissão

            modelBuilder.Entity<Profissao>()
                .Property(prof => prof.Nome)
                .HasColumnType("varchar(400)")
                .IsRequired();

            modelBuilder.Entity<Profissao>()
                .Property(prof => prof.Descricao)
                .HasColumnType("varchar(1000)")
                .IsRequired();

            modelBuilder.Entity<Profissao>()
                .Property(prof => prof.CBO)
                .HasColumnType("varchar(11)")
                .IsRequired();
            #endregion

            #region Configurações de Endereço

            modelBuilder.Entity<Endereco>()
                .Property(end => end.Bairro)
                .HasColumnType("varchar(200)")
                .IsRequired();

            modelBuilder.Entity<Endereco>()
                .Property(end => end.CEP)
                .HasColumnType("varchar(8)")
                .IsRequired();

            modelBuilder.Entity<Endereco>()
                .Property(end => end.Logradouro)
                .HasColumnType("varchar(200)")
                .IsRequired();

            modelBuilder.Entity<Endereco>()
                .Property(end => end.Referencia)
                .HasColumnType("varchar(400)");
            #endregion

            #region Configurações de Profissão Cliente

            modelBuilder.Entity<ProfissaoCliente>()
                .HasKey(pc => pc.Id);

            modelBuilder.Entity<ProfissaoCliente>()
                .HasOne(pc => pc.Cliente)
                .WithMany(pc => pc.ProfissoesClientes)
                .HasForeignKey(pc => pc.ClienteId);

            modelBuilder.Entity<ProfissaoCliente>()
                .HasOne(pc => pc.Profissao)
                .WithMany(pc => pc.ProfissoesClientes)
                .HasForeignKey(pc => pc.ProfissaoId);
            #endregion

            #region Configurações de Menu

            modelBuilder.Entity<Menu>()
                .HasMany(m => m.SubMenu)
                .WithOne()
                .HasForeignKey(m => m.MenuId);            
            #endregion
        }
    }
}
