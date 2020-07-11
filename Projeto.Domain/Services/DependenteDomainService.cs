using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class DependenteDomainService : BaseDomainService<Dependente>, IDependenteDomainService
    {
        //atributos
        private IDependenteRepository dependenteRepository;
        private IClienteRepository clienteRepository;

        //construtor para injeção de dependência (inicialização)
        public DependenteDomainService(IDependenteRepository dependenteRepository, IClienteRepository clienteRepository)
            : base(dependenteRepository)
        {
            this.dependenteRepository = dependenteRepository;
            this.clienteRepository = clienteRepository;
        }

        public override void Insert(Dependente obj)
        {
            //verificar se o dependente é menor de idade
            if (IsMenorDeIdade(obj.DataNascimento))
            {
                //verificar se o cliente possui menos de 3 dependentes
                if (clienteRepository.CountDependentes(obj.ClienteId) < 3)
                {
                    dependenteRepository.Insert(obj); //gravando..
                }
                else
                {
                    throw new Exception("Erro. Cliente não pode ter mais de 3 dependentes.");
                }
            }
            else
            {
                throw new Exception("Erro. Dependente deve ser menor de idade.");
            }
        }

        public override void Update(Dependente obj)
        {
            var registro = dependenteRepository.GetById(obj.Id);

            //verificando se o registro foi encontrado
            if (registro != null)
            {
                //verificando se a data de nascimento e o cliente não foram alterados
                if (registro.DataNascimento.Equals(obj.DataNascimento)
                    && registro.ClienteId.Equals(obj.ClienteId))
                {
                    dependenteRepository.Update(obj);
                }
                else
                {
                    throw new Exception("Erro. Não é permitido alterar a Data de Nascimento ou o Cliente do Dependente.");
                }
            }
            else
            {
                throw new Exception("Dependente não encontrado.");
            }
        }

        //método para verificar se o dependente é menor de idade
        private bool IsMenorDeIdade(DateTime dataNascimento)
        {
            int idade = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade = (idade - 1);
            }

            return idade < 18;
        }
    }
}
