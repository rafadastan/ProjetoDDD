using Projeto.Domain.Contracts.CrossCutting;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class UsuarioDomainService : BaseDomainService<Usuario>, IUsuarioDomainService
    {
        private IUsuarioRepository usuarioRepository;
        private IMD5Cryptography cryptography;

        public UsuarioDomainService(IUsuarioRepository usuarioRepository, 
                                    IMD5Cryptography cryptography) : base(usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.cryptography = cryptography;
        }

        public Usuario GetByLoginAndSenha(string login, string senha)
        {
            var registro = usuarioRepository.GetByLoginAndSenha(login,cryptography.Encrypt(senha));

            if (registro != null)
            {
                return registro;
            }
            else
            {
                throw new Exception("Usuario não foi encontrado.");
            }
        }

        public override void Insert(Usuario obj)
        {
            if (usuarioRepository.GetByLogin(obj.Login) == null)
            {
                obj.Senha = cryptography.Encrypt(obj.Senha);

                usuarioRepository.Insert(obj);
            }
            else
            {
                throw new Exception("Erro. O login informado já encontra-se cadastrado");
            }
        }

        public override void Update(Usuario obj)
        {
            var registro = usuarioRepository.GetById(obj.Id);

            if (registro != null)
            {
                registro.Nome = obj.Nome;
                registro.Senha = cryptography.Encrypt(obj.Senha);

                usuarioRepository.Update(registro);
            }
            else
            {
                throw new Exception("Erro. Usuário não foi encontrado");
            }
        }

    }
}
