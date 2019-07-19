using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SGC.ApplicationCore.Entity;

namespace SGC.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ClienteContext context)
        {
            // Se tiver clientes cadastrados, retorna...
            if (context.Clientes.Any())
            {
                return;
            }

            var clientes = new Cliente[]
            {
                new Cliente
                {
                    Nome = "Joelmir Luiz Dallagnol",
                    CPF = "11111111111"
                },

                new Cliente
                {
                    Nome = "Rodrigo Peroza",
                    CPF = "22222222222"
                },

                new Cliente
                {
                    Nome = "Edson Domenech",
                    CPF = "33333333333"
                }
            };

            // Adiciona os Clientes
            context.AddRange(clientes);

            var contatos = new Contato[]
            {
                new Contato
                {
                    Nome = "Contato Joelmir",
                    Email = "joelmir@teste.com",
                    Telefone = "554935669663",
                    Cliente = clientes[0]
                },

                new Contato
                {
                    Nome = "Contato Rodrigo",
                    Email = "rodrigo@teste.com",
                    Telefone = "554935669751",
                    Cliente = clientes[1]
                },

                new Contato
                {
                    Nome = "Contato Edson",
                    Email = "edson@teste.com",
                    Telefone = "554935669756",
                    Cliente = clientes[2]
                }
            };

            // Adiciona os Contatos
            context.AddRange(contatos);

            // Salva no contexto e adiciona no Banco
            context.SaveChanges();
        }
    }
}
