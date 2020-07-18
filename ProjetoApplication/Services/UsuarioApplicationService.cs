using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Models;
using ProjetoApplication.Contracts;
using ProjetoApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApplication.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private IUsuarioDomainService usuarioDomainService;

        public UsuarioApplicationService(IUsuarioDomainService usuarioDomainService)
        {
            this.usuarioDomainService = usuarioDomainService;
        }

        public Usuario GetByLogin(string login)
        {
            return usuarioDomainService.GetByLogin(login);
        }

        public Usuario GetByLoginAndSenha(UsuarioAutenticacaoModel model)
        {
            return usuarioDomainService.GetByLoginAndSenha(model.Login, model.Senha);
        }

        public void Insert(UsuarioCadastroModel model)
        {
            var usuario = new Usuario();

            usuario.Nome = model.Nome;
            usuario.Login = model.Login;
            usuario.Senha = model.Senha;
            usuario.DataCriacao = DateTime.Now;

            usuarioDomainService.Insert(usuario);
        }
    }
}
