using Projeto.Domain;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class DependenteRepository : BaseRepository<Dependente>, IDependenteRepository
    {
        private DataContext dataContext;

        public DependenteRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}