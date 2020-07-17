using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario> 
    {
        Usuario GetByLogin(string login);
        Usuario GetByLoginAndSenha(string login, string senha);

    }
}
