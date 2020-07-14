using Projeto.Domain;
using ProjetoApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApplication.Contracts
{
    public interface IClienteApplicationService
    {
        void Insert(ClienteCadastroModel model);
        void Update(ClienteEdicaoModel model);
        void Delete(int id);
        List<Cliente> GetAll();
        Cliente GetById(int id);
    }
}
