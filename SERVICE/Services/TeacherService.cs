using CORE.Models;
using REPO.IRepositories;
using SERVICE.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SERVICE.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;
        public TeacherService(ITeacherRepository repository)
        {
            _repository = repository;

        }

        public async Task DeleteAsync(Teacher tea)
        {
            await _repository.DeleteAsync(tea);


        }

        public Task<IList<Teacher>> GetAllAsync()
        {
            return _repository.GetAllAsync();

        }


        public async Task<Teacher> GetIdAsync(int id)
        {
            return await _repository.GetIdAsync(id);
        }

        public async Task InsertAsync(Teacher tea)
        {
            await _repository.InsertAsync(tea);

        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Teacher tea)
        {
            await _repository.UpdateAsync(tea);
        }
    }
}