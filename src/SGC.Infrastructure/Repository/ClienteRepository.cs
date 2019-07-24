using SGC.ApplicationCore.Entity;
using SGC.ApplicationCore.Interfaces.Repository;
using SGC.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGC.Infrastructure.Repository
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ClienteContext dbContext) : base(dbContext)
        {

        }
        public Cliente ObterPorProfissao(int clienteId)
        {
            return Buscar(x => x.ProfissoesClientes.Any(p => p.ClienteId == clienteId))
                .FirstOrDefault();
        }
    }
}
