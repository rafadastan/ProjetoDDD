using Projeto.Domain;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Models.Enums;
using ProjetoApplication.Contracts;
using ProjetoApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApplication.Services
{
    public class DependenteApplicationService : IDependenteApplicationService
    {
        //atributo
        private IDependenteDomainService dependenteDomainService;

        //construtor para inicialização (injeção de dependência)
        public DependenteApplicationService(IDependenteDomainService dependenteDomainService)
        {
            this.dependenteDomainService = dependenteDomainService;
        }

        public void Insert(DependenteCadastroModel model)
        {
            var dependente = new Dependente();

            dependente.Nome = model.Nome;
            dependente.DataNascimento = model.DataNascimento;
            dependente.Sexo = model.Sexo.Equals("F") ? Sexo.Feminino : Sexo.Masculino;
            dependente.ClienteId = model.ClienteId;

            dependenteDomainService.Insert(dependente);
        }

        public void Update(DependenteEdicaoModel model)
        {
            var dependente = new Dependente();

            dependente.Id = model.Id;
            dependente.Nome = model.Nome;
            dependente.DataNascimento = model.DataNascimento;
            dependente.Sexo = model.Sexo.Equals("F") ? Sexo.Feminino : Sexo.Masculino;
            dependente.ClienteId = model.ClienteId;

            dependenteDomainService.Insert(dependente);
        }

        public void Delete(int id)
        {
            var dependente = dependenteDomainService.GetById(id);
            dependenteDomainService.Delete(dependente);
        }

        public List<Dependente> GetAll()
        {
            return dependenteDomainService.GetAll();
        }

        public Dependente GetById(int id)
        {
            return dependenteDomainService.GetById(id);
        }

    }
}
