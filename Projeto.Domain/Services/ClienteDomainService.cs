using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class ClienteDomainService : BaseDomainService<Cliente>, IClienteDomainService
    {
        //atributo
        private IClienteRepository clienteRepository;

        //construtor para injeção de dependência (inicialiação)
        public ClienteDomainService(IClienteRepository clienteRepository) : base(clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public override void Insert(Cliente obj)
        {
            //verificar se o email informado já está cadastrado no banco de dados
            if (clienteRepository.GetByEmail(obj.Email) != null)
            {
                //lançar uma exceção
                throw new Exception($"O email {obj.Email} já encontra-se cadastrado no sistema.");
            }
            //verificar se o CPF informado já está cadastrado no banco de dados
            else if (clienteRepository.GetByCpf(obj.Cpf) != null)
            {
                //lançar uma exceção
                throw new Exception($"O CPF {obj.Cpf} já encontra-se cadastrado no sistema.");
            }
            else
            {
                //cadastrar o cliente
                clienteRepository.Insert(obj);
            }
        }

        public override void Update(Cliente obj)
        {
            //buscar o cliente no banco de dados pelo id
            var registro = clienteRepository.GetById(obj.Id);

            //verificar se o registro foi encontrado
            if (registro != null)
            {
                //verificar se o email o cpf do registro obtido no banco
                //é igual ao do cliente informado no método de edição
                if (registro.Email.Equals(obj.Email) && registro.Cpf.Equals(obj.Cpf))
                {
                    clienteRepository.Update(obj); //atualizar o cliente
                }
                else
                {
                    throw new Exception("Erro. Não é permitido alterar o Email ou CPF do Cliente.");
                }
            }
            else
            {
                throw new Exception("Cliente não encontrado.");
            }
        }

        public override void Delete(Cliente obj)
        {
            //verificar se o cliente não possui dependentes
            if (clienteRepository.CountDependentes(obj.Id) == 0)
            {
                //excluindo o cliente
                clienteRepository.Delete(obj);
            }
            else
            {
                throw new Exception("Não é permitido excluir Cliente que possua Dependentes.");
            }
        }
    }
}
