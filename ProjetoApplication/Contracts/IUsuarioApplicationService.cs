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
        Usuario GetByLoginAndSenha(UsuarioAutenticacaoModel model);
    }
}
