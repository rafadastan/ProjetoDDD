using Projeto.Domain;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class PlanoRepository : BaseRepository<Plano>, IPlanoRepository
    {
        private DataContext dataContext;

        public PlanoRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public int CountClientes(int idPlano)
        {
            return dataContext.Cliente.Count(c => c.PlanoId == idPlano);
        }

        public Plano GetBySigla(string sigla)
        {
            return dataContext.Plano.FirstOrDefault(p => p.Sigla.Equals(sigla));
        }
    }
}
