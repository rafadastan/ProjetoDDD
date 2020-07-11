using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class PlanoDomainService : BaseDomainService<Plano>, IPlanoDomainService
    {
        //atributo
        private IPlanoRepository planoRepository;

        //construtor para injeção de dependência
        public PlanoDomainService(IPlanoRepository planoRepository) : base(planoRepository)
        {
            this.planoRepository = planoRepository;
        }

        public override void Insert(Plano obj)
        {
            //verificando se a Sigla informada já foi cadastrada
            if (planoRepository.GetBySigla(obj.Sigla) != null)
            {
                throw new Exception($"A Sigla {obj.Sigla} do Plano já encontra-se cadastrada.");
            }
            else
            {
                //gravando o Plano
                planoRepository.Insert(obj);
            }
        }

        public override void Update(Plano obj)
        {
            //buscando o plano no banco de dados atraves do ID
            var registro = planoRepository.GetById(obj.Id);

            //verificando se o plano foi encontrado
            if (registro != null)
            {
                //verificando se a Sigla do Plano não foi alterada
                if (registro.Sigla.Equals(obj.Sigla))
                {
                    //atualizando o Plano
                    planoRepository.Update(obj);
                }
                else
                {
                    throw new Exception("Erro. Não é permitido alterar a Sigla do Plano.");
                }
            }
            else
            {
                throw new Exception("Plano não encontrado.");
            }
        }

        public override void Delete(Plano obj)
        {
            //verificar se o plano não possui clientes
            if (planoRepository.CountClientes(obj.Id) == 0)
            {
                //excluindo o plano
                planoRepository.Delete(obj);
            }
            else
            {
                throw new Exception("Não é permitido excluir Plano que possua Clientes.");
            }
        }
    }
}
