using CORE.Models;
using REPO.IRepositories;
using SERVICE.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Services
{
    public class DesignationService : IDesignationService
    {
        private readonly IDesignationRepository _repository;
        public DesignationService(IDesignationRepository repository)
        {
            _repository = repository;

        }

        public Task DeleteAsync(Designation obj)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Designation>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Designation> GetIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(Designation obj)
        {
            return _repository.InsertAsync(obj);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Designation obj)
        {
            throw new NotImplementedException();
        }
    }
}
