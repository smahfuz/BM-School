using CORE.Models;
using REPO.IRepositories;
using SERVICE.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SERVICE.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task DeleteAsync(Student obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            await _studentRepository.DeleteAsync(obj);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student> GetIdAsync(int id)
        {
            var student = await _studentRepository.GetIdAsync(id);
            if (student == null) throw new KeyNotFoundException($"Student with id {id} not found.");
            return student;
        }

        public async Task<List<Student>> GetStudentByClassIdAsync(int id)
        {
            var students = await _studentRepository.GetStudentByClassIdAsync(id);
            if (students == null || students.Count == 0) throw new KeyNotFoundException($"No students found for class id {id}.");
            return students;
        }

        public async Task InsertAsync(Student obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            await _studentRepository.InsertAsync(obj);
        }

        public async Task SaveChangesAsync()
        {
            await _studentRepository.SaveChangesAsync(); // Ensure this method exists in IStudentRepository and is implemented
        }

        public async Task UpdateAsync(Student obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            await _studentRepository.UpdateAsync(obj);
        }
    }
}
