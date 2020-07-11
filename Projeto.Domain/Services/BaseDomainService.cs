using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class BaseDomainService<T> : IBaseDomainService<T>
        where T : class
    {
        private IBaseRepository<T> baseRepository;

        public BaseDomainService(IBaseRepository<T> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public virtual void Delete(T obj)
        {
            baseRepository.Delete(obj);
        }

        public virtual List<T> GetAll()
        {
            return baseRepository.GetAll();
        }

        public virtual T GetById(int id)
        {
            return baseRepository.GetById(id);
        }

        public virtual void Insert(T obj)
        {
            baseRepository.Insert(obj);
        }

        public virtual void Update(T obj)
        {
            baseRepository.Update(obj);
        }
    }
}
