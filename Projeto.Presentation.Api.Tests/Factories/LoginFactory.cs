using ProjetoApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api.Tests.Factories
{
    public class LoginFactory
    {
        public static UsuarioAutenticacaoModel CreateAuth(string login, string senha)
        {
            var model = new UsuarioAutenticacaoModel();
            model.Login = login;
            model.Senha = senha;

            return model;
        }
    }
}
