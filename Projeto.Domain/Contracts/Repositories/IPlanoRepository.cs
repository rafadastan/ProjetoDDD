using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Repositories
{
    public interface IPlanoRepository : IBaseRepository<Plano>
    {
        Plano GetBySigla(string sigla);
    }
}
