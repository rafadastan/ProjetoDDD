using ProjetoApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api.Tests.Factories
{
    public class UsuarioFactory
    {
        public static UsuarioCadastroModel CreateUsuario
        {
            get
            {
                var random = new Random();
                var login = "raphael" + random.Next(999999);

                var model = new UsuarioCadastroModel
                {
                    Nome = "Raphael Augusto Pereira de Assis",
                    Login = login,
                    Senha = "adminadmin",
                    SenhaConfirmacao = "adminadmin"
                };

                return model;
            }
        }

        public static UsuarioCadastroModel CreateUsuarioEmpty
        {
            get
            {
                var model = new UsuarioCadastroModel
                {
                    Nome = string.Empty,
                    Login = string.Empty,
                    Senha = string.Empty,
                    SenhaConfirmacao = string.Empty
                };

                return model;
            }
        }
    }
}
