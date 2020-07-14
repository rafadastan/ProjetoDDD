using Projeto.Domain;
using ProjetoApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApplication.Contracts
{
    public interface IPlanoApplicationService
    {
        void Insert(PlanoCadastroModel model);
        void Update(PlanoEdicaoModel model);
        void Delete(int id);
        List<Plano> GetAll();
        Plano GetById(int id);
    }
}
