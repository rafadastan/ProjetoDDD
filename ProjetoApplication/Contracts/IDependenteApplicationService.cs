using Projeto.Domain;
using ProjetoApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApplication.Contracts
{
    public interface IDependenteApplicationService
    {
        void Insert(DependenteCadastroModel model);
        void Update(DependenteEdicaoModel model);
        void Delete(int id);
        List<Dependente> GetAll();
        Dependente GetById(int id);
    }
}
