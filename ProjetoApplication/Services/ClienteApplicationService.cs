using Projeto.Domain;
using Projeto.Domain.Contracts.Services;
using ProjetoApplication.Contracts;
using ProjetoApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApplication.Services
{
    public class ClienteApplicationService : IClienteApplicationService
    {
        private IClienteDomainService clienteDomainService;

        public ClienteApplicationService(IClienteDomainService clienteDomainService)
        {
            this.clienteDomainService = clienteDomainService;
        }

        public void Delete(int id)
        {
            var cliente = clienteDomainService.GetById(id);
            clienteDomainService.Delete(cliente);
        }

        public List<Cliente> GetAll()
        {
            return clienteDomainService.GetAll();
        }

        public Cliente GetById(int id)
        {
            return clienteDomainService.GetById(id);
        }

        public void Insert(ClienteCadastroModel model)
        {
            var cliente = new Cliente();

            cliente.Nome = model.Nome;
            cliente.Email = model.Email;
            cliente.Cpf = model.Cpf;
            cliente.PlanoId = model.PlanoId;

            clienteDomainService.Insert(cliente);
        }

        public void Update(ClienteEdicaoModel model)
        {
            var cliente = new Cliente();

            cliente.Id = model.Id;
            cliente.Nome = model.Nome;
            cliente.Email = model.Email;
            cliente.Cpf = model.Cpf;
            cliente.PlanoId = model.PlanoId;

            clienteDomainService.Update(cliente);
        }
    }
}
