using CORE.Models;
using REPO.IRepositories;
using REPO.Repositories;
using SERVICE.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Services
{
    public class ClasslevelService : IClassLevelService
    {
        private readonly IClasslevelRepository _repository;
        public ClasslevelService(IClasslevelRepository repository)
        {
            _repository = repository;

        }
        public Task DeleteAsync(ClassLevel obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClassLevel>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<ClassLevel> GetIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(ClassLevel obj)
        {
            return _repository.InsertAsync(obj);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ClassLevel obj)
        {
            throw new NotImplementedException();
        }
    }
}
