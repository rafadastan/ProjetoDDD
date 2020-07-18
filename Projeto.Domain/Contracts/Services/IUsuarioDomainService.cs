using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Services
{
    public interface IUsuarioDomainService : IBaseDomainService<Usuario>
    {
        Usuario GetByLoginAndSenha(string login, string senha);
        Usuario GetByLogin(string login);
    }
}
