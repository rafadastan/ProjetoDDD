using Projeto.Domain.Models;
using ProjetoApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApplication.Contracts
{
    public interface IUsuarioApplicationService
    {
        void Insert(UsuarioCadastroModel model);
        Usuario GetByLogin(string login);
        Usuario GetByLoginAndSenha(UsuarioAutenticacaoModel model);

    }
}
