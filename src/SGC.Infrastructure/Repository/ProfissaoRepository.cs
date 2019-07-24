using SGC.ApplicationCore.Entity;
using SGC.ApplicationCore.Interfaces.Repository;
using SGC.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGC.Infrastructure.Repository
{
    public class ProfissaoRepository : EFRepository<Profissao>, IProfissaoRepository
    {
        public ProfissaoRepository(ClienteContext dbContext) : base(dbContext)
        {

        }
    }
}
