using Projeto.Domain;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class DependenteRepository : BaseRepository<Dependente>
    {
        private DataContext dataContext;

        public DependenteRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}