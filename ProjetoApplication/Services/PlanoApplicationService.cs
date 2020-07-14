using Projeto.Domain;
using Projeto.Domain.Contracts.Services;
using ProjetoApplication.Contracts;
using ProjetoApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApplication.Services
{
    public class PlanoApplicationService : IPlanoApplicationService
    {
        //atributo
        private IPlanoDomainService planoDomainService;

        //construtor para inicialização (injeção de dependência)
        public PlanoApplicationService(IPlanoDomainService planoDomainService)
        {
            this.planoDomainService = planoDomainService;
        }

        public void Insert(PlanoCadastroModel model)
        {
            var plano = new Plano();

            plano.Nome = model.Nome;
            plano.Sigla = model.Sigla;
            plano.Descricao = model.Descricao;

            planoDomainService.Insert(plano);
        }

        public void Update(PlanoEdicaoModel model)
        {
            var plano = new Plano();

            plano.Id = model.Id;
            plano.Nome = model.Nome;
            plano.Sigla = model.Sigla;
            plano.Descricao = model.Descricao;

            planoDomainService.Update(plano);
        }

        public void Delete(int id)
        {
            var plano = planoDomainService.GetById(id);
            planoDomainService.Delete(plano);
        }

        public List<Plano> GetAll()
        {
            return planoDomainService.GetAll();
        }

        public Plano GetById(int id)
        {
            return planoDomainService.GetById(id);
        }
    }
}
