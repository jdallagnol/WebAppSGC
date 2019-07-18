using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SGC.ApplicationCore.Entity;

namespace SGC.Infrastructure.Data
{
    public static class dbInitializer
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
                    CPF = "12345678901"
                }
            };
        }
    }
}
