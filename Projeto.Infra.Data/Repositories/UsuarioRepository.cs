using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Models;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private DataContext dataContext;

        public UsuarioRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public Usuario GetByLogin(string login)
        {
            return dataContext.Usuario.FirstOrDefault(u => u.Login.Equals(login));
        }

        public Usuario GetByLoginAndSenha(string login, string senha)
        {
            return dataContext.Usuario.FirstOrDefault(u => u.Login.Equals(login)
                                                        && u.Senha.Equals(senha));
        }
    }
}
