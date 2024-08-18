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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;

        }
        public Task DeleteAsync(Student obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public Task<Student> GetIdAsync(int id)
        {
            return _studentRepository.GetIdAsync(id);

        }

        public Task<List<Student>> GetStudentByClassIdAsync(int id)
        {
            return _studentRepository.GetStudentByClassIdAsync( id);
        }

        public async Task InsertAsync(Student obj)
        {
              await _studentRepository.InsertAsync(obj);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Student obj)
        {
            throw new NotImplementedException();
        }
    }
}
