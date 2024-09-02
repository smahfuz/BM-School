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
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;
        public ResultService(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
            
        }

        public async Task<List<ResultSheet>> GetResultsByStudentIdAsync(int studentId)
        {
            return await _resultRepository.GetResultsByStudentIdAsync(studentId);
        }

        public Task DeleteAsync(ResultSheet obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ResultSheet>> GetAllAsync()
        {
            return await _resultRepository.GetAllAsync();

        }

        public Task<ResultSheet> GetIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultSheet>> GetStudentByClassIdAsync(int id)
        {
            return _resultRepository.GetStudentByClassIdAsync(id);
        }

        public async Task InsertAsync(ResultSheet obj)
        {
            await _resultRepository.InsertAsync(obj);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ResultSheet obj)
        {
            throw new NotImplementedException();
        }
    }
}
